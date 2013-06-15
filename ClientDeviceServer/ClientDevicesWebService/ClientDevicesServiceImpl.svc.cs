using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ort.edu.uy.obligatorio2.ClientDevicesLogic;
using uy.edu.ort.obligatorio.Commons;

namespace ort.edu.uy.obligatorio2.ClientDevicesWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
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
    }
}
