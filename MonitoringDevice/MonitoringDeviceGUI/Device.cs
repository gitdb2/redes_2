using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ort.edu.uy.obligatorio2.MonitoringDeviceLogic;
using System.Diagnostics;

namespace ort.edu.uy.obligatorio2.MonitoringDeviceGUI
{
    public partial class Device : Form
    {
        private MonitoringDeviceHandler deviceHandler;
        private int timerInterval;
        private Stopwatch stopwatch;

        public Device()
        {
            InitializeComponent();
            deviceHandler = new MonitoringDeviceHandler();
            this.timerInterval = deviceHandler.GetTimerInterval();
            this.stopwatch = new Stopwatch();
            ChangeStatusLabels();
        }

        private void btnOnOff_Click(object sender, EventArgs e)
        {
            if (this.deviceHandler.IsTurnedOn)
            {
                this.deviceHandler.TurnOff();
                stopwatch.Stop();
                stopwatch.Reset();
                ChangeStatusLabels();
            }
            else
            {
                if (!TextBoxIsEmpty(this.txtBoxName))
                {
                    this.deviceHandler.TurnOn(this.txtBoxName.Text.Trim());
                    stopwatch.Reset();
                    stopwatch.Start();
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
            if (this.deviceHandler.IsTurnedOn)
            {
                this.deviceHandler.SendStatusReport(stopwatch.ElapsedMilliseconds);
            }
        }

        private void AppendToLog(string message)
        {
            this.listBoxMessageLog.Items.Add(message);
        }

        private void btnSendFailure_Click(object sender, EventArgs e)
        {

        }

    }
}
