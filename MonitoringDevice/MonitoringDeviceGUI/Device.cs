using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ort.edu.uy.obligatorio2.MonitoringDeviceLogic;
using uy.edu.ort.obligatorio.Commons;
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
                long elapsedTime = stopwatch.ElapsedMilliseconds;
                this.deviceHandler.SendStatusReport(elapsedTime);
                AppendToLog(CreateStatusMessage(elapsedTime));
            }
        }

        private string CreateStatusMessage(long elapsedTime)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Reporte de Estado: ").Append(": ");
            sb.Append("Identificacion: ").Append(this.deviceHandler.DeviceName).Append(", ");
            sb.Append("Encendido: ").Append(this.deviceHandler.IsTurnedOn).Append(", ");
            sb.Append("Uptime: ").Append(elapsedTime);
            return sb.ToString();
        }

        private void btnSendFailure_Click(object sender, EventArgs e)
        {
            if (ItemIsSelected(this.comboFailureAlertLevel) && ItemIsSelected(this.comboFailureType))
            {
                int alertLevel = Int16.Parse((string)this.comboFailureAlertLevel.SelectedItem);
                int failureType = Int16.Parse((string)this.comboFailureType.SelectedItem);
                string formattedDate = DateTime.Now.ToString(ParseConstants.DATE_FORMAT_FAILURE_REPORT);
                this.deviceHandler.SendFailureReport(alertLevel, failureType, formattedDate);
                AppendToLog(CreateFailureMessage(alertLevel, failureType, formattedDate));
            }
        }

        private string CreateFailureMessage(int alertLevel, int failureType, string formattedDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Reporte de Falla: ").Append(": ");
            sb.Append("Identificacion: ").Append(this.deviceHandler.DeviceName).Append(", ");
            sb.Append("Tipo: ").Append(failureType).Append(", ");
            sb.Append("Nivel: ").Append(alertLevel).Append(", ");
            sb.Append("Fecha: ").Append(formattedDate);
            return sb.ToString();
        }

        private bool ItemIsSelected(ComboBox comboBox)
        {
            return comboBox.SelectedIndex > -1;
        }

        private void AppendToLog(string message)
        {
            this.listBoxMessageLog.Items.Add(message);
        }

        private void Device_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.deviceHandler.TurnOff();
        }

    }
}
