using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace uy.edu.ort.obligatorio.Commons
{
    [Serializable]
    [DataContract]
    public class DeviceFailureInfo
    {
        [DataMember]
        public int AlarmType { get; set; }

        [DataMember]
        public int AlarmLevel { get; set; }

        [DataMember]
        public DateTime AlarmDateTime { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Tipo: ").Append(AlarmType);
            sb.Append(", ").Append("Nivel: ").Append(AlarmLevel);
            sb.Append(", ").Append("Fecha: ").Append(AlarmDateTime.ToString(ParseConstants.DATE_TIME_FORMAT));
            return sb.ToString();
        }
    }

    [Serializable]
    [DataContract]
    public class DeviceFailureInfoWrapper
    {
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public bool Error { get; set; }
        [DataMember]
        public DeviceFailureInfo DeviceFailureInfo { get; set; }
    }
}
