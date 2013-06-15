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

namespace ort.edu.uy.obligatorio2.ClientDevicesLogic
{
    public class ClientDevicesServiceImpl : IClientDevicesService
    {

        public List<DeviceInfo> GetDevicesForClient(string idClient)
        {
            return ClientHandler.GetInstance().GetUserDevices(idClient);
        }

        public List<DeviceFailureInfo> GetDeviceFaults(string idDevice, int resultMaxSize)
        {
            return ClientHandler.GetInstance().GetDeviceFailuresList(idDevice, resultMaxSize);
        }

        public List<DeviceStatusInfo> GetDeviceStatuses(string idDevice, int resultMaxSize)
        {
            return ClientHandler.GetInstance().GetDeviceStatusList(idDevice, resultMaxSize);
        }

        public string Echo(string text)
        {
            return "Echo: " + text;
        }
    }
}
