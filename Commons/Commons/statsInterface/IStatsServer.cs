using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uy.edu.ort.obligatorio.Commons.statsInterface
{
    interface IStatsServer
    {
        public List<DeviceFailureInfo> GetDeviceFaults(string idDevice, int resultMaxSize);
        public List<DeviceStatusInfo> GetDeviceFaults(string idDevice, int resultMaxSize);
    }
}
