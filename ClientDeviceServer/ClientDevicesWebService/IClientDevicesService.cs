using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using uy.edu.ort.obligatorio.Commons;

namespace ort.edu.uy.obligatorio2.ClientDevicesWebService
{
    [ServiceContract]
    public interface IClientDevicesService
    {
        [OperationContract]
        List<DeviceInfo> GetDevicesForClient(string idClient);

        [OperationContract]
        List<DeviceFailureInfo> GetDeviceFaults(string idDevice, int resultMaxSize);

        [OperationContract]
        List<DeviceStatusInfo> GetDeviceStatuses(string idDevice, int resultMaxSize);
    }


   
}
