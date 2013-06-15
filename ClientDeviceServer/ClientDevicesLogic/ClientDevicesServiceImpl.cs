using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.ServiceModel.Web;
using System.Text;
using ort.edu.uy.obligatorio2.ClientDevicesLogic;
using uy.edu.ort.obligatorio.Commons;
using ort.edu.uy.obligatorio2.ClientDevicesWebService;
using log4net;

namespace ort.edu.uy.obligatorio2.ClientDevicesLogic
{
    public class ClientDevicesServiceImpl : IClientDevicesService
    {

        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<DeviceInfo> GetDevicesForClient(string idClient)
        {
            log.InfoFormat("GetDevicesForClient({0})",idClient); 
            return ClientHandler.GetInstance().GetUserDevices(idClient);
        }

        public List<DeviceFailureInfo> GetDeviceFaults(string idDevice, int resultMaxSize)
        {
            log.InfoFormat("GetDeviceFaults({0}, {1})", idDevice, resultMaxSize);
            return ClientHandler.GetInstance().GetDeviceFailuresList(idDevice, resultMaxSize);
        }

        public List<DeviceStatusInfo> GetDeviceStatuses(string idDevice, int resultMaxSize)
        {
            log.InfoFormat("GetDeviceStatuses({0}, {1})", idDevice, resultMaxSize);
            return ClientHandler.GetInstance().GetDeviceStatusList(idDevice, resultMaxSize);
        }

        public string Echo(string text)
        {
            return "Echo: " + text;
        }

    }
}
