using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ort.edu.uy.obligatorio2.ClientDevicesLogic
{
    public class DevicesData : MarshalByRefObject, IDevicesData
    {
        public string GetDevicesStatus()
        {
            return "Este es el estado de los devices";
        }
    }
}
