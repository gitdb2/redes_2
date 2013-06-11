using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comunicacion;
using uy.edu.ort.obligatorio.Commons;
using System.Text.RegularExpressions;
using uy.edu.ort.obligatorio.Commons.frameDecoder;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using uy.edu.ort.obligatorio2.CommunicationServer.queue;
using uy.edu.ort.obligatorio.Commons.queue;

namespace uy.edu.ort.obligatorio2.CommunicationServer
{
    public class CommandHandler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static CommandHandler instance = new CommandHandler();

        private CommandHandler() { }

        public static CommandHandler GetInstance()
        {
            return instance;
        }

        public void Handle(Connection connection, Data dato)
        {
            if (connection.Name == Connection.UNKNOWN)
            {
                DeveicePayloadFrameDecoded tmp = new DeveicePayloadFrameDecoded();
                tmp.Parse(dato.Payload.Message);
                connection.Name = tmp.DeviceId;
            }

            //si no tengo la conexion mapeada, la guardo
            if (!SingletonDeviceConnection.GetInstance().IsConnected(connection.Name))
            {
                SingletonDeviceConnection.GetInstance().AddDevice(connection);
            }

            Console.WriteLine("[{0}] connection owner: {1} ;  The data: {2} ", DateTime.Now, connection.Name, dato.ToString());
            switch (dato.OpCode)
            {
                case OpCodeConstants.REQ_SEND_STATUS_REPORT: //viene el status de un dispositivo
                    CommandREQStatusReport(connection, dato);
                    break;
                case OpCodeConstants.RES_SEND_FAILURE_REPORT: //viene una Alarma de falla de un dispositivo
                    CommandREQFailureReport(connection, dato);
                    break;
                default:
                    break;
            }
        }

        private void CommandREQFailureReport(Connection clientConnection, Data dato)
        {
            FaultFrameDecoded message = new FaultFrameDecoded();
            message.Parse(dato.Payload.Message);
            SingletonDeviceInfoHandler.GetInstance().UpdateDeviceStatus(message);
            log.DebugFormat("Llego REQ Failure con {0}", message.ToString());
            log.DebugFormat("Notificar a server dispositivos y estadisticas");

            MessageBean messageBean = new MessageBean() { Message = dato.Payload.Message, MessageType = MessageTypeEnum.FAULT };
            StatisticsQueueClient.GetInstance().SendMessages(messageBean);
        }

        private void CommandREQStatusReport(Connection clientConnection, Data dato)
        {
            StatusFrameDecoded message = new StatusFrameDecoded();
            message.Parse(dato.Payload.Message);
            SingletonDeviceInfoHandler.GetInstance().UpdateDeviceStatus(message);
            log.DebugFormat("Llego REQ STATUS con {0}", message.ToString());
            log.DebugFormat("Notificar a server estadisticas");

            MessageBean messageBean = new MessageBean(){Message = dato.Payload.Message, MessageType = MessageTypeEnum.STATUS};
            StatisticsQueueClient.GetInstance().SendMessages(messageBean);
        }

        private void CallRemotingGestionServer(StatusFrameDecoded message)
        {
            TcpChannel tcpChannel = null;
            try
            {
                tcpChannel = new TcpChannel();
                ChannelServices.RegisterChannel(tcpChannel, false);

                Type requiredType = typeof(IDevicesData);

                IDevicesData remoteObject = (IDevicesData)Activator.GetObject(requiredType, "tcp://localhost:9998/CommServer");
                remoteObject.SetDeviceStatus(message.DeviceId, message.StatusOnOff, message.UpTime);
            }
            catch (Exception e)
            {
                log.Error("Se cagó", e);
            }
            finally
            {
                if (tcpChannel != null)
                {
                    ChannelServices.UnregisterChannel(tcpChannel);
                }
            }

        }

        public void Logout(Connection clientConnection)
        {
            log.InfoFormat("Desconectando el Dispositivo {0}", clientConnection.Name);
            Console.WriteLine("Desconectando el Dispositivo {0}", clientConnection.Name);
            SingletonDeviceConnection.GetInstance().RemoveDevice(clientConnection.Name);
        }

    }
}
