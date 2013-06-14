using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uy.edu.ort.obligatorio.Commons.statsInterface
{
    public interface IStatsServer
    {
        
        public List<DeviceFailureInfo> GetDeviceFaults(string idDevice, int resultMaxSize);

        public List<DeviceStatusInfo> GetDeviceStatuses(string idDevice, int resultMaxSize);

    }
}
