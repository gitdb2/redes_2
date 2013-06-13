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
    public partial class AddClient : Form
    {
        
        public AddClient()
        {
            InitializeComponent();
            LoadDevices();
        }

        private void LoadDevices()
        {
            this.listBoxAvailable.Items.Clear();
            this.listBoxAvailable.Items.AddRange(ClientHandler.GetInstance().GetDevices().ToArray());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (this.listBoxAvailable.Items.Count > 0)
            {
                moveAllItems(this.listBoxAvailable, this.listBoxSelected);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (this.listBoxSelected.Items.Count > 0)
            {
                moveAllItems(this.listBoxSelected, this.listBoxAvailable);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DeviceInfo deviceSelected = (DeviceInfo)this.listBoxAvailable.SelectedItem;
            if (deviceSelected != null)
            {
                moveSingleItem(deviceSelected, this.listBoxAvailable, this.listBoxSelected);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DeviceInfo deviceSelected = (DeviceInfo)this.listBoxSelected.SelectedItem;
            if (deviceSelected != null)
            {
                moveSingleItem(deviceSelected, this.listBoxSelected, this.listBoxAvailable);
            }
        }

        private void moveSingleItem(DeviceInfo device, ListBox from, ListBox to)
        {
            to.Items.Add(device);
            from.Items.Remove(device);
        }

        private void moveAllItems(ListBox from, ListBox to)
        {
            to.Items.AddRange(from.Items);
            from.Items.Clear();
        }

    }
}
