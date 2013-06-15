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
    public partial class ModifiyClient : Form
    {

        public ModifiyClient()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadDevices()
        {
            try
            {
                this.listBoxAvailable.Items.Clear();
                this.listBoxAvailable.Items.AddRange(ClientHandler.GetInstance().GetDevices().ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            try
            {
                this.comboBoxAllClients.Items.Clear();
                this.listBoxSelected.Items.Clear();
                this.listBoxAvailable.Items.Clear();
                Dictionary<string, List<DeviceInfo>> users = ClientHandler.GetInstance().GetUsers();
                foreach (KeyValuePair<string, List<DeviceInfo>> item in users)
                {
                    this.comboBoxAllClients.Items.Add(new ComboItem() { UserName = item.Key, Devices = item.Value });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DeviceInfo deviceSelected = (DeviceInfo)this.listBoxAvailable.SelectedItem;
            if (deviceSelected != null)
            {
                FormUtils.MoveSingleItem(deviceSelected, this.listBoxAvailable, this.listBoxSelected);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DeviceInfo deviceSelected = (DeviceInfo)this.listBoxSelected.SelectedItem;
            if (deviceSelected != null)
            {
                FormUtils.MoveSingleItem(deviceSelected, this.listBoxSelected, this.listBoxAvailable);
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (this.listBoxAvailable.Items.Count > 0)
            {
                FormUtils.MoveAllItems(this.listBoxAvailable, this.listBoxSelected);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (this.listBoxSelected.Items.Count > 0)
            {
                FormUtils.MoveAllItems(this.listBoxSelected, this.listBoxAvailable);
            }
        }

        private void comboBoxAllClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxAllClients.SelectedItem != null)
            {
                ComboItem userSelected = (ComboItem)this.comboBoxAllClients.SelectedItem;
                this.listBoxSelected.Items.Clear();
                this.listBoxAvailable.Items.Clear();
                this.listBoxSelected.Items.AddRange(userSelected.Devices.ToArray());
                LoadAvailableDevices(userSelected.Devices);
            }
        }

        private void LoadAvailableDevices(List<DeviceInfo> userSelectedDevices)
        {
            try
            {
                List<DeviceInfo> allDevices = ClientHandler.GetInstance().GetDevices();
                foreach (DeviceInfo deviceAvailable in allDevices)
                {
                    bool add = true;
                    foreach (DeviceInfo userDevice in userSelectedDevices)
                    {
                        if (deviceAvailable.LastStatusInfo.DeviceId.Equals(userDevice.LastStatusInfo.DeviceId))
                        {
                            add = false;
                            break;
                        }
                    }
                    if (add)
                    {
                        this.listBoxAvailable.Items.Add(deviceAvailable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBoxAllClients.SelectedItem !=null && this.listBoxSelected.Items.Count > 0)
            {
                try
                {
                    ComboItem userSelected = (ComboItem)this.comboBoxAllClients.SelectedItem;
                    List<DeviceInfo> userNewDevices = new List<DeviceInfo>();
                    foreach (var item in this.listBoxSelected.Items)
                    {
                        userNewDevices.Add((DeviceInfo)item);
                    }
                    ClientHandler.GetInstance().ModifyUser(userSelected.UserName, userNewDevices);
                    MessageBox.Show("Usuario modificado correctamente", "Modificacion de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Modificacion de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
