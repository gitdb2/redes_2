using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Text.RegularExpressions;
using uy.edu.ort.obligatorio.Commons.frameDecoder;
using uy.edu.ort.obligatorio.Commons;

namespace uy.edu.ort.obligatorio2.ServidorEstadisticas
{
    public class SingletonStatsHistory
    {
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        Dictionary<string, List<DeviceStatusInfo>> statusMap = new Dictionary<string, List<DeviceStatusInfo>>();
        Dictionary<string, List<DeviceFailureInfo>> faultsMap = new Dictionary<string, List<DeviceFailureInfo>>();

        private static SingletonStatsHistory instance = new SingletonStatsHistory();

        private SingletonStatsHistory() { }

        public static SingletonStatsHistory GetInstance()
        {
            return instance;
        }

        public void AddStatus( StatusFrameDecoded newStatus)
        {
            List<DeviceStatusInfo> statusList = null;
            lock (statusMap)
            {
                if (!statusMap.ContainsKey(newStatus.DeviceId))
                {
                    statusList = new List<DeviceStatusInfo>();
                    statusMap.Add(newStatus.DeviceId, statusList);
                }
                else
                {
                    try
                    {
                        statusMap.TryGetValue(newStatus.DeviceId, out statusList);
                    }
                    catch  //si no pudo obtener la lista desde el mapa
                    {
                        statusList = new List<DeviceStatusInfo>();
                        statusMap.Add(newStatus.DeviceId, statusList);
                    }
                }
                
            }
            //para agreagr se hace lock en la lista seleccionada
            lock (statusList)
            {
                statusList.Add(new DeviceStatusInfo() { DeviceId = newStatus.DeviceId, StatusOnOff = newStatus.StatusOnOff, UpTime = newStatus.UpTime });
            }
        }

        public void AddFault( FaultFrameDecoded newFault)
        {

            List<DeviceFailureInfo> faultsList = null;
            lock (faultsMap)
            {
                if (!faultsMap.ContainsKey(newFault.DeviceId))
                {
                    faultsList = new List<DeviceFailureInfo>();
                    faultsMap.Add(newFault.DeviceId, faultsList);
                }
                else
                {
                    try
                    {
                        faultsMap.TryGetValue(newFault.DeviceId, out faultsList);
                    }
                    catch  //si no pudo obtener la lista desde el mapa
                    {
                        faultsList = new List<DeviceFailureInfo>();
                        faultsMap.Add(newFault.DeviceId, faultsList);
                    }
                }

            }
            //para agreagr se hace lock en la lista seleccionada
            lock (faultsList)
            {
                faultsList.Add(new DeviceFailureInfo() { AlarmDateTime = newFault.AlarmDateTime, AlarmLevel = newFault.AlarmLevel, AlarmType = newFault.AlarmType});
            }
        }

        public List<DeviceFailureInfo> GetDeviceFaults(string idDevice)
        {
            List<DeviceFailureInfo> ret = new List<DeviceFailureInfo>();
            try
            {
                List<DeviceFailureInfo> tmp = null;
                faultsMap.TryGetValue(idDevice, out tmp);
                lock (tmp)
                {
                    ret.AddRange(tmp);
                }
            }
            catch  //si no pudo obtener la lista desde el mapa
            {
            }

            return ret;

        }

        public List<DeviceStatusInfo> GetDeviceStatus(string idDevice)
        {
            List<DeviceStatusInfo> ret = new List<DeviceStatusInfo>();
            try
            {
                List<DeviceStatusInfo> tmp = null;
                statusMap.TryGetValue(idDevice, out tmp);
                lock (tmp)
                {
                    ret.AddRange(tmp);
                }
            }
            catch  //si no pudo obtener la lista desde el mapa
            {
            }

            return ret;

        }
       

    
    }
}
