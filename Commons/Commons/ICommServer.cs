using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uy.edu.ort.obligatorio.Commons
{
    public interface ICommServer
    {

        void SetDeviceStatus(string id, bool status, long upTime);

        List<DeviceInfo> GetDevices();

    }
}
