using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uy.edu.ort.obligatorio.Commons
{
    [Serializable]
    public class DeviceFailureInfo
    {

        public int AlarmType { get; set; }
        public int AlarmLevel { get; set; }
        public DateTime AlarmDateTime { get; set; }

    }
}
