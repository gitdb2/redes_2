using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using uy.edu.ort.obligatorio.Commons;
using System.ServiceModel;

namespace ort.edu.uy.obligatorio2.ClientDevicesWebService
{
    [ServiceContract]
    public interface IClientDevicesService
    {

        [OperationContract]
        string Echo(string text);

        [OperationContract]
        List<DeviceInfo> GetDevicesForClient(string idClient);

        [OperationContract]
        List<DeviceFailureInfo> GetDeviceFaults(string idDevice, int resultMaxSize);

        [OperationContract]
        List<DeviceStatusInfo> GetDeviceStatuses(string idDevice, int resultMaxSize);

    }


   
}
