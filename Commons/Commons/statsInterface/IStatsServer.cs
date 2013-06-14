using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uy.edu.ort.obligatorio.Commons.statsInterface
{
    public interface IStatsServer
    {
        List<DeviceFailureInfo> GetDeviceFaults(string idDevice, int resultMaxSize);
        List<DeviceStatusInfo> GetDeviceStatus(string idDevice, int resultMaxSize);
    }
}
