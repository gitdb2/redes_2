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
    public partial class DeletClient : Form
    {

        public DeletClient()
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

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (this.comboBoxAllClients.SelectedItem != null)
            {
                ComboItem userSelected = (ComboItem)this.comboBoxAllClients.SelectedItem;
                try
                {
                    ClientHandler.GetInstance().DeleteUser(userSelected.UserName);
                    MessageBox.Show("Usuario eliminado correctamente", "Baja de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Baja de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            this.comboBoxAllClients.Text = null;
            this.listBoxAvailable.Items.Clear();
        }

    }
}
