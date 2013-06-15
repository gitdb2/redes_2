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
    public partial class Client : Form
    {

        private const string OPTION_VIEW_STATUS = "Ver Estados";
        private const string OPTION_VIEW_FAILURES = "Ver Fallas";
        private ToolStripItem itemViewStatus;
        private ToolStripItem itemViewFailures;
        private ContextMenuStrip listboxContextMenu;
        private DeviceInfo deviceSelected;

        public Client()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            this.listboxContextMenu = new ContextMenuStrip();
            this.listBoxDevices.ContextMenuStrip = listboxContextMenu;
            this.listboxContextMenu.Items.Clear();
            this.itemViewStatus = listboxContextMenu.Items.Add(OPTION_VIEW_STATUS);
            this.itemViewStatus.Click += new EventHandler(itemViewStatus_Click);
            this.itemViewFailures = listboxContextMenu.Items.Add(OPTION_VIEW_FAILURES);
            this.itemViewFailures.Click += new EventHandler(itemViewFailures_Click);
        }

        private void itemViewStatus_Click(object sender, EventArgs e)
        {
            DeviceLog dl = new DeviceLog();
            dl.Text = "Estados del Dispositivo " + this.deviceSelected.LastStatusInfo.DeviceId;
            dl.LoadLogLines(ClientHandler.GetInstance().GetDeviceStatusList(deviceSelected.LastStatusInfo.DeviceId));
            dl.Show();
        }

        private void itemViewFailures_Click(object sender, EventArgs e)
        {
            DeviceLog dl = new DeviceLog();
            dl.Text = "Fallas del Dispositivo " + this.deviceSelected.LastStatusInfo.DeviceId;
            dl.LoadLogLines(ClientHandler.GetInstance().GetDeviceFailuresList(deviceSelected.LastStatusInfo.DeviceId));
            dl.Show();
        }

        private void listBoxDevices_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.listBoxDevices.SelectedIndex = this.listBoxDevices.IndexFromPoint(e.Location);
                if (this.listBoxDevices.SelectedIndex != -1)
                {
                    this.deviceSelected = (DeviceInfo)this.listBoxDevices.SelectedItem;
                    this.listboxContextMenu.Show();
                }
            }
        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {

        }

    }
}
