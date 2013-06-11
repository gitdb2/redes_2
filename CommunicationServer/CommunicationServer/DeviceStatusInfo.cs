using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uy.edu.ort.obligatorio2.CommunicationServer
{
    public class DeviceStatusInfo
    {

        public string DeviceId { get; set; }
        public bool StatusOnOff { get; set; }
        public long UpTime { get; set; }

    }
}
