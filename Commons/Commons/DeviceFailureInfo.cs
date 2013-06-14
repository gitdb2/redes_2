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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Tipo: ").Append(AlarmType);
            sb.Append(", ").Append("Nivel: ").Append(AlarmLevel);
            sb.Append(", ").Append("Fecha: ").Append(AlarmDateTime.ToString(ParseConstants.DATE_TIME_FORMAT));
            return sb.ToString();
        }

    }
}
