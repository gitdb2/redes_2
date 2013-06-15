using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ort.edu.uy.obligatorio2.ClientDevicesLogic;
using uy.edu.ort.obligatorio.Commons;

namespace ort.edu.uy.obligatorio2.ClientDevicesGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.ShowDialog();
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletClient deleteClient = new DeletClient();
            deleteClient.ShowDialog();
        }

        private void modificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifiyClient modifyClient = new ModifiyClient();
            modifyClient.ShowDialog();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientDevicesInfo cdi = new ClientDevicesInfo();
            cdi.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WebServicesServer.GetInstance().Stop();
        }
    }
}
