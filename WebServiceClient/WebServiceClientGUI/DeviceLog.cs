using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using uy.edu.ort.obligatorio.Commons;

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
            this.listBoxDeviceLog.Items.AddRange(statuses.ToArray());
        }


        public void LoadLogLines(List<DeviceFailureInfo> failures)
        {
            this.listBoxDeviceLog.Items.Clear();
            this.listBoxDeviceLog.Items.AddRange(failures.ToArray());
        }

    }
}
