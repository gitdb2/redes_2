﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ort.edu.uy.obligatorio2.ClientDevicesGUI
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

        public void LoadLogLines()
        {
            
        }
    }
}
