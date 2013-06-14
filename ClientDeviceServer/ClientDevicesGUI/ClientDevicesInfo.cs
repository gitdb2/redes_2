using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using uy.edu.ort.obligatorio.Commons;
using ort.edu.uy.obligatorio2.ClientDevicesLogic;

namespace ort.edu.uy.obligatorio2.ClientDevicesGUI
{
    public partial class ClientDevicesInfo : Form
    {
        private const string OPTION_VIEW_STATUS = "Ver Estados";
        private const string OPTION_VIEW_FAILURES = "Ver Fallas";
        private ToolStripItem itemViewStatus;
        private ToolStripItem itemViewFailures;
        private ContextMenuStrip listboxContextMenu;
        private DeviceInfo deviceSelected;

        public ClientDevicesInfo()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            this.comboBoxAllClients.Items.Clear();
            Dictionary<string, List<DeviceInfo>> users = ClientHandler.GetInstance().GetUsers();
            foreach (KeyValuePair<string, List<DeviceInfo>> item in users)
            {
                this.comboBoxAllClients.Items.Add(new ComboItem() { UserName = item.Key, Devices = item.Value });
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxAllClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxAllClients.SelectedItem != null)
            {
                ComboItem userSelected = (ComboItem)this.comboBoxAllClients.SelectedItem;
                this.listBoxAvailable.Items.Clear();
                this.listBoxAvailable.Items.AddRange(userSelected.Devices.ToArray());
            }
        }

        private void listBoxAvailable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.listBoxAvailable.SelectedIndex = this.listBoxAvailable.IndexFromPoint(e.Location);
                if (this.listBoxAvailable.SelectedIndex != -1)
                {
                    this.deviceSelected = (DeviceInfo)this.listBoxAvailable.SelectedItem;
                    this.listboxContextMenu.Show();
                }
            }
        }

        private void ClientDevicesInfo_Load(object sender, EventArgs e)
        {
            this.listboxContextMenu = new ContextMenuStrip();
            this.listBoxAvailable.ContextMenuStrip = listboxContextMenu;
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
            //ClientHandler.GetStatus(deviceID);
            dl.LoadLogLines();
            dl.Show();
        }

        private void itemViewFailures_Click(object sender, EventArgs e)
        {
            DeviceLog dl = new DeviceLog();
            dl.Text = "Fallas del Dispositivo " + this.deviceSelected.LastStatusInfo.DeviceId;
            //ClientHandler.GetFailures(deviceID);
            dl.LoadLogLines();
            dl.Show();
        }

    }
}
