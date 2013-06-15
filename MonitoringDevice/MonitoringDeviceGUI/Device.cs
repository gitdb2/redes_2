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
        private Stopwatch stopwatch;

        public Device()
        {
            InitializeComponent();
            statusButton.Tag = true;
            deviceHandler = new MonitoringDeviceHandler();
            this.stopwatch = new Stopwatch();
            ChangeStatusLabels();
            timerSendStatus.Interval = deviceHandler.GetTimerInterval();
           
        }

        private void btnConnectOnclick(object sender, EventArgs e)
        {
            if (this.deviceHandler.IsConnected)
            {
                this.deviceHandler.Disconnect();
                stopwatch.Stop();
                stopwatch.Reset();
                ChangeStatusLabels();
                txtBoxName.Enabled = true;
                txtBoxName.ReadOnly = false;
            }
            else
            {
                if (!TextBoxIsEmpty(this.txtBoxName))
                {
                    try
                    {
                        this.deviceHandler.Connect(this.txtBoxName.Text.Trim());
                        stopwatch.Reset();
                        stopwatch.Start();
                        ChangeStatusLabels();
                        txtBoxName.Enabled = false;
                        txtBoxName.ReadOnly = true;
              
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error al conectar con el servidor de comunicaciones");
                    }
                }
               
            }
        }

        private string getStatusButtonState()
        {
            if (this.deviceHandler.IsTurnedOn)
            {
                return "Encendido";
            }
            else
            {
                return "Apagado";
            }
        }

        private void ChangeStatusLabels()
        {
            statusButton.Text = (this.deviceHandler.IsTurnedOn) ? "Apagar" : "Encender";
            if (this.deviceHandler.IsConnected)
            {
                this.toolStripStatusLabelStatusOnOff.Text = "Conectado - " + getStatusButtonState();
                this.btnOnOff.Text = "Desconectar";
            }
            else
            {
                this.toolStripStatusLabelStatusOnOff.Text = "Desconectado - " + getStatusButtonState();
                this.btnOnOff.Text = "Conectar";
            }
        }

        private bool TextBoxIsEmpty(TextBox txtBox)
        {
            return txtBox.Text == null || txtBox.Text.Trim().Equals("");
        }

        private void timerSendStatus_Tick(object sender, EventArgs e)
        {
            if (this.deviceHandler.IsConnected)
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
                string formattedDate = DateTime.Now.ToString(ParseConstants.DATE_TIME_FORMAT);
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
            this.deviceHandler.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
            this.deviceHandler.IsTurnedOn = !this.deviceHandler.IsTurnedOn;
            ChangeStatusLabels();
            stopwatch.Reset();
            stopwatch.Start();
        }

    }
}
