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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Id: ").Append(DeviceId);
            sb.Append(", ").Append("Estado: ").Append(StatusOnOff ? "On" : "Off");
            sb.Append(", ").Append("Uptimer: ").Append(UpTime);
            return sb.ToString();
        }

    }
}
