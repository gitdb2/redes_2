using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using uy.edu.ort.obligatorio.Commons.statsInterface;
using uy.edu.ort.obligatorio.Commons;
using uy.edu.ort.obligatorio2.ServidorEstadisticas;
namespace ort.edu.uy.obligatorio2.ServidorEstadisticas.remoting
{


    public class StatsServerImpl : MarshalByRefObject, IStatsServer
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
   
        public List<DeviceFailureInfo>  GetDeviceFaults(string idDevice, int resultMaxSize)
        {
            List<DeviceFailureInfo> ret =  SingletonStatsHistory.GetInstance().GetDeviceFaults(idDevice);
            if (ret.Count > 0)
            {
                ret.Reverse();
                ret = ret.GetRange(0, resultMaxSize);
            }
            return ret;
        }

        public List<DeviceStatusInfo>  GetDeviceStatuses(string idDevice, int resultMaxSize)
        {
           List<DeviceStatusInfo> ret =  SingletonStatsHistory.GetInstance().GetDeviceStatus(idDevice);
           if (ret.Count > 0)
           {
               ret.Reverse();
               ret =  ret.GetRange(0, resultMaxSize);
           }
           return ret;
        }
    }

}
