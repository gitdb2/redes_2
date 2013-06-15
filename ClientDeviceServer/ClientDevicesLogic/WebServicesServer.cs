using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using log4net;
using Comunicacion;
using System.Threading;
using System.Net;

namespace ort.edu.uy.obligatorio2.ClientDevicesLogic
{
    public class WebServicesServer 
    {
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
        private static WebServicesServer instance = new WebServicesServer();

        public static WebServicesServer GetInstance() { return instance; }

        private string uri = "";

        private Boolean running = false;

        public Boolean Running
        {
            get { return running; }
            set { running = value; }
        }

        private Boolean stopService = false;

        private string GetIP()
        {
            var hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            var ip = (
                       from addr in hostEntry.AddressList
                       where addr.AddressFamily.ToString() == "InterNetwork"
                       select addr.ToString()
                ).FirstOrDefault();
            return ip;
        }

        private Thread service;

        private  WebServicesServer()
        {

            Boolean autoResolveIp   = Boolean.Parse(Settings.GetInstance().GetProperty("auto.resolve.endpoint.ip", "false"));
            string host             = Settings.GetInstance().GetProperty("webservice.url.host", "localhost");
            string port             = Settings.GetInstance().GetProperty("webservice.url.port", "8080");
            string service          = Settings.GetInstance().GetProperty("webservice.url.service", "clientDevicesService");

            if(autoResolveIp)
            {
                host = GetIP();
            }
            uri = "http://" + host.Trim() + ":" + port.Trim() + "/" + service.Trim();
           // uri = Settings.GetInstance().GetProperty("webservice.url", "http://localhost:8080/clientDevicesService");
        }

        public void Stop()
        {
            stopService = true;
        }

        public Boolean Start()
        {
            lock (this)
            {
                log.Debug("start thread "+ uri);
                if (!running)
                {
                   
                    (service = new Thread(new ThreadStart(StartServices))).Start();
                }
                return service.IsAlive;
            }
           
        }

        private void StartServices(){

            if (!running)
            {

                log.Debug("StartServices");
                Running = true;

                Uri baseAddress = new Uri(uri);


                // Create the ServiceHost.
                using (ServiceHost host = new ServiceHost(typeof(ClientDevicesServiceImpl), baseAddress))
                {
                    // Enable metadata publishing.
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    host.Description.Behaviors.Add(smb);

                    host.Open();
                    log.InfoFormat("The service is ready at {0}", baseAddress);
                    while (!stopService)
                    {
                       // log.Debug("duerme thread");
                        Thread.Sleep(2000);
                    }
                  
                    host.Close();
                }
            }
        }
        
    }
}
