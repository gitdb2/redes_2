using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ort.edu.uy.obligatorio2.ClientWebServiceLogic.ServiceReference1;

namespace ort.edu.uy.obligatorio2.WebServiceClientGUI
{
    public class DeviceFailureInfoWrapper : DeviceFailureInfo
    {
        private const string DATE_TIME_FORMAT = "yyyyMMdd HH:mm:ss";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Tipo: ").Append(AlarmType);
            sb.Append(", ").Append("Nivel: ").Append(AlarmLevel);
            sb.Append(", ").Append("Fecha: ").Append(AlarmDateTime.ToString(DATE_TIME_FORMAT));
            return sb.ToString();
        }

    }
}
