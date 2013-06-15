using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ort.edu.uy.obligatorio2.ClientWebServiceLogic.ServiceReference1;

namespace ort.edu.uy.obligatorio2.WebServiceClientGUI
{
    public class DeviceInfoWrapper : DeviceInfo
    {

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
}
