using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Text.RegularExpressions;
using uy.edu.ort.obligatorio.Commons.frameDecoder;

namespace uy.edu.ort.obligatorio2.ServidorEstadisticas
{
    public class SingletonStatsHistory
    {
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        Dictionary<string, List<StatusFrameDecoded>> statusMap  = new Dictionary<string, List<StatusFrameDecoded>>();
        Dictionary<string, List<FaultFrameDecoded>>  faultsMap  = new Dictionary<string, List<FaultFrameDecoded>>();

        private static SingletonStatsHistory instance = new SingletonStatsHistory();

        private SingletonStatsHistory() { }

        public static SingletonStatsHistory GetInstance()
        {
            return instance;
        }

        public void AddStatus( StatusFrameDecoded newStatus)
        {
            List<StatusFrameDecoded> statusList = null;
            lock (statusMap)
            {
                if (!statusMap.ContainsKey(newStatus.DeviceId))
                {
                    statusList = new List<StatusFrameDecoded>();
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
                        statusList = new List<StatusFrameDecoded>();
                        statusMap.Add(newStatus.DeviceId, statusList);
                    }
                }
                
            }
            //para agreagr se hace lock en la lista seleccionada
            lock (statusList)
            {
                statusList.Add(newStatus);
            }
        }

        public void AddFault( FaultFrameDecoded newFault)
        {
          
            List<FaultFrameDecoded> faultsList = null;
            lock (faultsMap)
            {
                if (!faultsMap.ContainsKey(newFault.DeviceId))
                {
                    faultsList = new List<FaultFrameDecoded>();
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
                        faultsList = new List<FaultFrameDecoded>();
                        faultsMap.Add(newFault.DeviceId, faultsList);
                    }
                }

            }
            //para agreagr se hace lock en la lista seleccionada
            lock (faultsList)
            {
                faultsList.Add(newFault);
            }
        }

        public List<FaultFrameDecoded> GetDeviceFaults(string idDevice)
        {
            List<FaultFrameDecoded> ret = new List<FaultFrameDecoded>();
            try
            {
                List<FaultFrameDecoded> tmp = null;
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

        public List<StatusFrameDecoded> GetDeviceStatus(string idDevice)
        {
            List<StatusFrameDecoded> ret = new List<StatusFrameDecoded>();
            try
            {
                List<StatusFrameDecoded> tmp = null;
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
