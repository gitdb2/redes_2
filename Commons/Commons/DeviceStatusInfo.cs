using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace uy.edu.ort.obligatorio.Commons
{
    [Serializable]
    [DataContract]
    public class DeviceStatusInfo
    {
        [DataMember]
        public string DeviceId { get; set; }
        
        [DataMember]
        public bool StatusOnOff { get; set; }
        
        [DataMember]
        public long UpTime { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Id: ").Append(DeviceId);
            sb.Append(", ").Append("Estado: ").Append(StatusOnOff ? "On" : "Off");
            sb.Append(", ").Append("Uptime: ").Append(UpTime);
            return sb.ToString();
        }

    }
}
