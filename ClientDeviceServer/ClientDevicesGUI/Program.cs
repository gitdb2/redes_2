using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ort.edu.uy.obligatorio2.ClientDevicesLogic;
using System.IO;

namespace ort.edu.uy.obligatorio2.ClientDevicesGUI
{
    static class Program
    {
        private static log4net.ILog log;

   
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            log4net.GlobalContext.Properties["serverName"] = "Cliente";
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            log.Info("Inicia");
            RemotingServer.StartRemotingServer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
