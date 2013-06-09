using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uy.edu.ort.obligatorio.Commons;

namespace ort.edu.uy.obligatorio2.ClientDevicesLogic
{
    public class DevicesData : MarshalByRefObject, IDevicesData
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

   

        public void SetDeviceStatus(string id, bool status, long upTime)
        {
            log.InfoFormat("id: {0}, status: {1}, uptime: {2}",  id, status, upTime);
        }
    }
}
