using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ort.edu.uy.obligatorio2.ClientWebServiceLogic.ServiceReference1;

namespace ort.edu.uy.obligatorio2.WebServiceClientGUI
{
    public class DeviceStatusInfoWrapper : DeviceStatusInfo
    {

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
