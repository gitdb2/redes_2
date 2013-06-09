﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ort.edu.uy.obligatorio2.MonitoringDeviceLogic;

namespace ort.edu.uy.obligatorio2.MonitoringDeviceGUI
{
    public partial class Device : Form
    {
        private MonitoringDeviceHandler deviceHandler;
        private int timerInterval;
        private DateTime startTime = DateTime.Now;

        public Device()
        {
            InitializeComponent();
            deviceHandler = new MonitoringDeviceHandler();
            this.timerInterval = deviceHandler.GetTimerInterval();
            ChangeStatusLabels();
        }

        private void btnOnOff_Click(object sender, EventArgs e)
        {
            if (this.deviceHandler.IsTurnedOn)
            {
                this.deviceHandler.TurnOff();
                ChangeStatusLabels();
            }
            else
            {
                if (!TextBoxIsEmpty(this.txtBoxName))
                {
                    this.deviceHandler.TurnOn(this.txtBoxName.Text.Trim());
                    ChangeStatusLabels();
                }
            }
        }

        private void ChangeStatusLabels()
        {
            if (this.deviceHandler.IsTurnedOn)
            {
                this.toolStripStatusLabelStatusOnOff.Text = "ENCENDIDO";
                this.btnOnOff.Text = "Apagar";
            }
            else
            {
                this.toolStripStatusLabelStatusOnOff.Text = "APAGADO";
                this.btnOnOff.Text = "Encender";
            }
        }

        private bool TextBoxIsEmpty(TextBox txtBox)
        {
            return txtBox.Text == null || txtBox.Text.Trim().Equals("");
        }

        private void timerSendStatus_Tick(object sender, EventArgs e)
        {
            var delta = DateTime.Now - startTime;
            AppendToLog(this.deviceHandler.SendStatusReport(delta));
        }

        private void AppendToLog(string message)
        {
            this.listBoxMessageLog.Items.Add(message);
        }

    }
}
