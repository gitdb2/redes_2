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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!FormUtils.TextBoxIsEmpty(this.txtBoxName) && this.listBoxSelected.Items.Count > 0)
            {
                try
                {
                    List<DeviceInfo> userDevices = new List<DeviceInfo>();
                    foreach (var item in this.listBoxSelected.Items)
                    {
                        userDevices.Add((DeviceInfo)item);
                    }
                    ClientHandler.GetInstance().AddUser(this.txtBoxName.Text.Trim(), userDevices);
                    MessageBox.Show("Usuario agregado correctamente", "Alta de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void ClearForm()
        {
            this.txtBoxName.Text = null;
            FormUtils.MoveAllItems(this.listBoxSelected, this.listBoxAvailable);
        }

    }
}
