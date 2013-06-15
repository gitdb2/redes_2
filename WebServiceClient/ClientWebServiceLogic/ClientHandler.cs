using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ort.edu.uy.obligatorio2.ClientWebServiceLogic.ServiceReference1;

namespace ort.edu.uy.obligatorio2.WebServiceClientLogic
{
    public class ClientHandler
    {

        private static ClientHandler instance = new ClientHandler();
        private ClientDevicesServiceClient webServiceProvider;

        private ClientHandler() { }

        private void OpenWebServiceInterface()
        {
            try
            {
                webServiceProvider = new ClientDevicesServiceClient();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CloseWebServiceInterface()
        {
            try
            {
                webServiceProvider.Close();
            }
            catch (Exception ex)
            {
                //loguear
            }
            finally
            {
                webServiceProvider = null;
            }
        }

        public static ClientHandler GetInstance()
        {
            return instance;
        }

        public List<DeviceInfo> GetDeviceList(string clientId)
        {
            List<DeviceInfo> result = new List<DeviceInfo>();
            try
            {
                OpenWebServiceInterface();
                result = this.webServiceProvider.GetDevicesForClient(clientId).Cast<DeviceInfo>().ToList();
            }
            catch (Exception ex)
            {
                //loguear
            }
            finally
            {
               CloseWebServiceInterface();
            }
            return result;
        }

        public List<DeviceFailureInfo> GetDeviceFailuresList(string deviceId)
        {
            List<DeviceFailureInfo> result = new List<DeviceFailureInfo>();
            try
            {
                OpenWebServiceInterface();
                result = this.webServiceProvider.GetDeviceFaults(deviceId, 100).Cast<DeviceFailureInfo>().ToList();
            }
            catch (Exception ex)
            {
                //loguear
            }
            finally
            {
                CloseWebServiceInterface();
            }
            return result;
        }

        public List<DeviceStatusInfo> GetDeviceStatusList(string deviceId)
        {
            List<DeviceStatusInfo> result = new List<DeviceStatusInfo>();
            try
            {
                OpenWebServiceInterface();
                result = this.webServiceProvider.GetDeviceStatuses(deviceId, 100).Cast<DeviceStatusInfo>().ToList();
            }
            catch (Exception ex)
            {
                //loguear
            }
            finally
            {
                CloseWebServiceInterface();
            }
            return result;
        }

    }
}
