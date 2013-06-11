using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uy.edu.ort.obligatorio.Commons
{
    [Serializable]
    public class DeviceInfo
    {

        public DeviceFailureInfo LastFailureInfo { get; set; }

        public DeviceStatusInfo LastStatusInfo { get; set; }

    }
}
