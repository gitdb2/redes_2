using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uy.edu.ort.obligatorio.Commons;

namespace ort.edu.uy.obligatorio2.WebServiceClientLogic
{
    public class ClientHandler
    {

        private static ClientHandler instance = new ClientHandler();

        private ClientHandler() { }

        public static ClientHandler GetInstance()
        {
            return instance;
        }

        public List<DeviceInfo> GetDeviceList(string clientId)
        {
            return new List<DeviceInfo>();
        }

        public List<DeviceFailureInfo> GetDeviceFailuresList(string deviceId)
        {
            return new List<DeviceFailureInfo>();
        }

        public List<DeviceStatusInfo> GetDeviceStatusList(string deviceId)
        {
            return new List<DeviceStatusInfo>();
        }
    }
}
