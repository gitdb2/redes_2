using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.ServiceModel.Web;
using System.Text;
using ort.edu.uy.obligatorio2.ClientDevicesLogic;
using uy.edu.ort.obligatorio.Commons;
using ort.edu.uy.obligatorio2.ClientDevicesWebService;
using log4net;

namespace ort.edu.uy.obligatorio2.ClientDevicesLogic
{
    public class ClientDevicesServiceImpl : IClientDevicesService
    {

        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DeviceInfoWrapper GetDevicesForClient(string idClient)
        {
            DeviceInfoWrapper ret;
            log.InfoFormat("GetDevicesForClient({0})",idClient); 
            try 
	        {	        
		        List<DeviceInfo> tmp =  ClientHandler.GetInstance().GetUserDevices(idClient);
                ret = new DeviceInfoWrapper(){List = tmp,  Error=false};
	        }
	        catch (Exception e)
	        {
		
		        ret = new DeviceInfoWrapper(){List = new List<DeviceInfo>(),  Error=true,ErrorMessage= e.Message};
	        }

            return ret;
        }

        public DeviceFailureInfoWrapper GetDeviceFaults(string idDevice, int resultMaxSize)
        {
            DeviceFailureInfoWrapper ret;
            log.InfoFormat("GetDeviceFaults({0}, {1})", idDevice, resultMaxSize);
            try
            {
                List<DeviceFailureInfo> tmp =  ClientHandler.GetInstance().GetDeviceFailuresList(idDevice, resultMaxSize);
                ret = new DeviceFailureInfoWrapper() { List = tmp, Error = false };
            }
	        catch (Exception e)
	        {
                ret = new DeviceFailureInfoWrapper() { List = new List<DeviceFailureInfo>(), Error = true, ErrorMessage = e.Message };
	        }

            return ret;
        }

        public DeviceStatusInfoWrapper GetDeviceStatuses(string idDevice, int resultMaxSize)
        {
            
            DeviceStatusInfoWrapper ret;
            log.InfoFormat("GetDeviceStatuses({0}, {1})", idDevice, resultMaxSize);
            try
            {
                List<DeviceStatusInfo> tmp = ClientHandler.GetInstance().GetDeviceStatusList(idDevice, resultMaxSize);
                ret = new DeviceStatusInfoWrapper() { List = tmp, Error = false };
            }
            catch (Exception e)
            {
                ret = new DeviceStatusInfoWrapper() { List = new List<DeviceStatusInfo>(), Error = true, ErrorMessage = e.Message };
            }

            return ret;


        }

        public string Echo(string text)
        {
            return "Echo: " + text;
        }

    }
}
