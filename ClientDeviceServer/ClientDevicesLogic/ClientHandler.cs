using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using uy.edu.ort.obligatorio.Commons;
using Comunicacion;
using log4net;
using uy.edu.ort.obligatorio.Commons.statsInterface;

namespace ort.edu.uy.obligatorio2.ClientDevicesLogic
{
    public class ClientHandler
    {
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ClientHandler instance = new ClientHandler();
        private TcpChannel commServerTcpChannel;
        private TcpChannel statsServerTcpChannel;
        private Dictionary<string, List<DeviceInfo>> userData = new Dictionary<string, List<DeviceInfo>>();

        private ClientHandler() { }
        
        public static ClientHandler GetInstance()
        {
            return instance;
        }

      

        public List<DeviceInfo> GetDevices()
        {
            ICommServer iCommServer = ConnectToCommServer();
            List<DeviceInfo> devices = iCommServer.GetDevices();
            DisconnectFromRemotingServer(this.commServerTcpChannel);
            return devices;
        }

        private IStatsServer ConnectToStatsServer()
        {
            log.Info("Estableciendo la conexion al servidor de estadisticas");
            this.statsServerTcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(statsServerTcpChannel, false);
            Type requiredType = typeof(IStatsServer);
            return (IStatsServer)Activator.GetObject(requiredType, GetStatsServerConnectionString());
        }

        private string GetStatsServerConnectionString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("tcp://");
            sb.Append(Settings.GetInstance().GetProperty("remoting.statsserver.ip", "localhost"));
            sb.Append(":").Append(Settings.GetInstance().GetProperty("remoting.statsserver.port", "9997")).Append("/");
            sb.Append(Settings.GetInstance().GetProperty("remoting.statsserver.name", "StatsServer"));
            return sb.ToString();
        }

        private ICommServer ConnectToCommServer()
        {
            log.Info("Estableciendo la conexion al servidor de comunicaciones");
            this.commServerTcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(commServerTcpChannel, false);
            Type requiredType = typeof(ICommServer);
            return (ICommServer) Activator.GetObject(requiredType, GetCommServerConnectionString());
        }

        private void DisconnectFromRemotingServer(TcpChannel tcpChannel)
        {
            try
            {
                log.Info("Cerrando la conexion al servidor de remoting");
                ChannelServices.UnregisterChannel(tcpChannel);
            }
            catch (Exception ex)
            {
                log.Error("Error cerrando la conexion al servidor de remoting", ex);
            }
            finally 
            {
                tcpChannel = null;
            }
        }

        private string GetCommServerConnectionString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("tcp://");
            sb.Append(Settings.GetInstance().GetProperty("remoting.commserver.ip", "localhost"));
            sb.Append(":").Append(Settings.GetInstance().GetProperty("remoting.commserver.port", "9998")).Append("/");
            sb.Append(Settings.GetInstance().GetProperty("remoting.commserver.name", "CommServer"));
            return sb.ToString();
        }

        public void AddUser(string userName, List<DeviceInfo> userDevices)
        {
            if (this.userData.ContainsKey(userName))
            {
                throw new Exception("El usuario ya existe");
            }
            else
            {
                this.userData.Add(userName, userDevices);
            }
        }

        public Dictionary<string, List<DeviceInfo>> GetUsers()
        {
            Dictionary<string, List<DeviceInfo>> copy = new Dictionary<string, List<DeviceInfo>>();
            foreach (KeyValuePair<string, List<DeviceInfo>> pair in this.userData)
            {
                copy.Add(pair.Key, pair.Value);
            }
            return copy;
        }


        public List<DeviceInfo> GetUserDevices(string idUser)
        {
            List<DeviceInfo> ret = new List<DeviceInfo>();
            try
            {
                userData.TryGetValue(idUser, out ret);
            }
            catch  //si no pudo obtener la lista desde el mapa
            {
                ret = new List<DeviceInfo>();
            }

            return ret;
        }

        public void DeleteUser(string userName)
        {
            if (this.userData.ContainsKey(userName))
            {
                this.userData.Remove(userName);
            }
            else 
            {
                throw new Exception("El usuario no existe");
            }
        }

        public void ModifyUser(string userName, List<DeviceInfo> userNewDevices)
        {
            if (!this.userData.ContainsKey(userName))
            {
                throw new Exception("El usuario no existe");
            }
            else
            {
                this.userData[userName] = userNewDevices;                
            }
        }

        public List<DeviceStatusInfo> GetDeviceStatusList(string deviceId)
        {
           
            int maxResults = int.Parse(Settings.GetInstance().GetProperty("commserver.statuses.maxresults", "100"));
            return GetDeviceStatusList(deviceId, maxResults);
        }

        /// <summary>
        /// retorna las  maxresults ultimas status de un dispositivo
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        public List<DeviceStatusInfo> GetDeviceStatusList(string deviceId, int maxResults)
        {
            IStatsServer iStatsServer = ConnectToStatsServer();
            List<DeviceStatusInfo> statuses = iStatsServer.GetDeviceStatuses(deviceId, maxResults);
            DisconnectFromRemotingServer(this.statsServerTcpChannel);
            return statuses;
        }

        public List<DeviceFailureInfo> GetDeviceFailuresList(string deviceId)
        {
            int maxResults = int.Parse(Settings.GetInstance().GetProperty("commserver.failures.maxresults", "100"));
            return GetDeviceFailuresList(deviceId, maxResults);
        }
        /// <summary>
        /// retorna las  maxresults ultimas fallas de un dispositivo
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        public List<DeviceFailureInfo> GetDeviceFailuresList(string deviceId, int maxResults)
        {
            IStatsServer iStatsServer = ConnectToStatsServer();
            List<DeviceFailureInfo> failures = iStatsServer.GetDeviceFaults(deviceId, maxResults);
            DisconnectFromRemotingServer(this.statsServerTcpChannel);
            return failures;
        }


    }
}
