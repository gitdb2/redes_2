using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uy.edu.ort.obligatorio.Commons;

namespace ort.edu.uy.obligatorio2.ClientDevicesGUI
{
    public class ComboItem
    {

        public string UserName { get; set; }
        
        public List<DeviceInfo> Devices { get; set; }

        public override string ToString()
        {
            return UserName;
        }

    }
}
