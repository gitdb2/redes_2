using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uy.edu.ort.obligatorio.Commons
{
    [Serializable]
    public class DeviceStatusInfo
    {

        public string DeviceId { get; set; }
        public bool StatusOnOff { get; set; }
        public long UpTime { get; set; }

    }
}
