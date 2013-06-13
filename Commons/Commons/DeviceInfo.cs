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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Id: ").Append(LastStatusInfo.DeviceId);
            sb.Append(", Estado: ").Append(LastStatusInfo.StatusOnOff ? "On" : "Off");
            return sb.ToString();
        }

    }
}
