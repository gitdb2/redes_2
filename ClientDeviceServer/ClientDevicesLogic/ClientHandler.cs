using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using uy.edu.ort.obligatorio.Commons;
using Comunicacion;
using log4net;

namespace ort.edu.uy.obligatorio2.ClientDevicesLogic
{
    public class ClientHandler
    {
        
        private static ClientHandler instance = new ClientHandler();
        private TcpChannel tcpChannel;
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private ClientHandler() { }
        
        public static ClientHandler GetInstance()
        {
            return instance;
        }

        public List<DeviceInfo> GetDevices()
        {
            ICommServer iCommServer = ConnectToCommServer();
            List<DeviceInfo> devices = iCommServer.GetDevices();
            DisconnectFromCommServer();
            return devices;
        }

        private ICommServer ConnectToCommServer()
        {
            log.Info("Estableciendo la conexion al servidor de comunicaciones");
            this.tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel, false);
            Type requiredType = typeof(ICommServer);
            return (ICommServer) Activator.GetObject(requiredType, GetCommServerConnectionString());
        }

        private void DisconnectFromCommServer()
        {
            try
            {
                log.Info("Cerrando la conexion al servidor de comunicaciones");
                ChannelServices.UnregisterChannel(this.tcpChannel);
            }
            catch (Exception ex)
            {
                log.Error("Error cerrando la conexion al servidor de comunicaciones", ex);
            }
        }

        private string GetCommServerConnectionString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("tcp://");
            sb.Append(Settings.GetInstance().GetProperty("commserver.ip", "localhost"));
            sb.Append(":").Append(Settings.GetInstance().GetProperty("commserver.port", "9998")).Append("/");
            sb.Append(Settings.GetInstance().GetProperty("commserver.name", "CommServer"));
            return sb.ToString();
        }

    }
}
