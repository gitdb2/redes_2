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
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al intentar conectar al WebService");
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                result = this.webServiceProvider.GetDevicesForClient(clientId).Cast<DeviceInfo>().ToList();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al obtener los Dispositivos");
            }
            finally
            {
               CloseWebServiceInterface();
            }
            return result;
        }

        public List<DeviceFailureInfo> GetDeviceFailuresList(string deviceId, int maxResults)
        {
            List<DeviceFailureInfo> result = new List<DeviceFailureInfo>();
            try
            {
                OpenWebServiceInterface();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                result = this.webServiceProvider.GetDeviceFaults(deviceId, maxResults).Cast<DeviceFailureInfo>().ToList();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al obtener la lista de Fallas");
            }
            finally
            {
                CloseWebServiceInterface();
            }
            return result;
        }

        public List<DeviceStatusInfo> GetDeviceStatusList(string deviceId, int maxResults)
        {
            List<DeviceStatusInfo> result = new List<DeviceStatusInfo>();
            try
            {
                OpenWebServiceInterface();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                result = this.webServiceProvider.GetDeviceStatuses(deviceId, maxResults).Cast<DeviceStatusInfo>().ToList();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al obtener la lista de Estados");
            }
            finally
            {
                CloseWebServiceInterface();
            }
            return result;
        }

    }
}
