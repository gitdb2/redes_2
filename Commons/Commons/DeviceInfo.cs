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
            sb.Append("Id: ").Append(DeviceId);
            sb.Append(", Estado: ");
            if (LastStatusInfo != null)
            {
                sb.Append(LastStatusInfo.StatusOnOff ? "On" : "Off");
            }
            else
            {
                sb.Append("Sin Datos");
            }
            return sb.ToString();
        }

    }


    [Serializable]
    [DataContract]
    public class DeviceInfoWrapper
    {
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public bool Error { get; set; }
        [DataMember]
        public DeviceInfo DeviceInfo { get; set; }



    }
}
