using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace uy.edu.ort.obligatorio.Commons
{
    [Serializable]
    [DataContract]
    public class DeviceInfo
    {
        [DataMember]
        public string DeviceId { get; set; }
        [DataMember]
        public DeviceFailureInfo LastFailureInfo { get; set; }
        [DataMember]
        public DeviceStatusInfo LastStatusInfo { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Id: ").Append(LastStatusInfo.DeviceId);
            sb.Append(", Estado: ").Append(LastStatusInfo.StatusOnOff ? "On" : "Off");
            return sb.ToString();
        }

    }
}
