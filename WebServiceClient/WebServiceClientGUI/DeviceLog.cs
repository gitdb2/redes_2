using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using ort.edu.uy.obligatorio2.ClientWebServiceLogic.ServiceReference1;

namespace ort.edu.uy.obligatorio2.WebServiceClientGUI
{
    public partial class DeviceLog : Form
    {

        public DeviceLog()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadLogLines(List<DeviceStatusInfo> statuses)
        {
            this.listBoxDeviceLog.Items.Clear();
            foreach (DeviceStatusInfo item in statuses)
            {
                this.listBoxDeviceLog.Items.Add(new DeviceStatusInfoWrapper() { 
                    DeviceId = item.DeviceId, 
                    StatusOnOff = item.StatusOnOff, 
                    UpTime = item.UpTime });
            }
        }

        public void LoadLogLines(List<DeviceFailureInfo> failures)
        {
            this.listBoxDeviceLog.Items.Clear();
            foreach (DeviceFailureInfo item in failures)
            {
                this.listBoxDeviceLog.Items.Add(new DeviceFailureInfoWrapper() {
                    AlarmLevel = item.AlarmLevel,
                    AlarmType = item.AlarmType,
                    AlarmDateTime = item.AlarmDateTime
                });
            }
        }

    }
}
