namespace ort.edu.uy.obligatorio2.MonitoringDeviceGUI
{
    partial class Device
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.btnOnOff = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStatusOnOff = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.listBoxMessageLog = new System.Windows.Forms.ListBox();
            this.lblMessageLog = new System.Windows.Forms.Label();
            this.comboFailureType = new System.Windows.Forms.ComboBox();
            this.comboFailureAlertLevel = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFailureAlert = new System.Windows.Forms.Label();
            this.lblFailureType = new System.Windows.Forms.Label();
            this.btnSendFailure = new System.Windows.Forms.Button();
            this.lblLog = new System.Windows.Forms.Label();
            this.timerSendStatus = new System.Windows.Forms.Timer(this.components);
            this.statusButton = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(63, 20);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre:";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(133, 16);
            this.txtBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(109, 22);
            this.txtBoxName.TabIndex = 1;
            // 
            // btnOnOff
            // 
            this.btnOnOff.Location = new System.Drawing.Point(270, 14);
            this.btnOnOff.Margin = new System.Windows.Forms.Padding(4);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(113, 28);
            this.btnOnOff.TabIndex = 2;
            this.btnOnOff.Text = "Conectar";
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.btnConnectOnclick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelName,
            this.toolStripStatusLabelStatusOnOff});
            this.statusStrip.Location = new System.Drawing.Point(0, 565);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(396, 25);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "Estado Actual:";
            // 
            // toolStripStatusLabelName
            // 
            this.toolStripStatusLabelName.Name = "toolStripStatusLabelName";
            this.toolStripStatusLabelName.Size = new System.Drawing.Size(103, 20);
            this.toolStripStatusLabelName.Text = "Estado Actual:";
            // 
            // toolStripStatusLabelStatusOnOff
            // 
            this.toolStripStatusLabelStatusOnOff.Name = "toolStripStatusLabelStatusOnOff";
            this.toolStripStatusLabelStatusOnOff.Size = new System.Drawing.Size(0, 20);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 70);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(112, 17);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Cambiar Estado:";
            // 
            // listBoxMessageLog
            // 
            this.listBoxMessageLog.FormattingEnabled = true;
            this.listBoxMessageLog.ItemHeight = 16;
            this.listBoxMessageLog.Location = new System.Drawing.Point(24, 335);
            this.listBoxMessageLog.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMessageLog.Name = "listBoxMessageLog";
            this.listBoxMessageLog.Size = new System.Drawing.Size(348, 212);
            this.listBoxMessageLog.TabIndex = 8;
            // 
            // lblMessageLog
            // 
            this.lblMessageLog.AutoSize = true;
            this.lblMessageLog.Location = new System.Drawing.Point(49, 268);
            this.lblMessageLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessageLog.Name = "lblMessageLog";
            this.lblMessageLog.Size = new System.Drawing.Size(120, 17);
            this.lblMessageLog.TabIndex = 9;
            this.lblMessageLog.Text = "Log de Mensajes:";
            // 
            // comboFailureType
            // 
            this.comboFailureType.FormattingEnabled = true;
            this.comboFailureType.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboFailureType.Location = new System.Drawing.Point(143, 23);
            this.comboFailureType.Margin = new System.Windows.Forms.Padding(4);
            this.comboFailureType.Name = "comboFailureType";
            this.comboFailureType.Size = new System.Drawing.Size(191, 24);
            this.comboFailureType.TabIndex = 11;
            // 
            // comboFailureAlertLevel
            // 
            this.comboFailureAlertLevel.FormattingEnabled = true;
            this.comboFailureAlertLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboFailureAlertLevel.Location = new System.Drawing.Point(143, 69);
            this.comboFailureAlertLevel.Margin = new System.Windows.Forms.Padding(4);
            this.comboFailureAlertLevel.Name = "comboFailureAlertLevel";
            this.comboFailureAlertLevel.Size = new System.Drawing.Size(191, 24);
            this.comboFailureAlertLevel.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFailureAlert);
            this.groupBox1.Controls.Add(this.lblFailureType);
            this.groupBox1.Controls.Add(this.btnSendFailure);
            this.groupBox1.Controls.Add(this.comboFailureType);
            this.groupBox1.Controls.Add(this.comboFailureAlertLevel);
            this.groupBox1.Location = new System.Drawing.Point(17, 111);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(356, 174);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fallas";
            // 
            // lblFailureAlert
            // 
            this.lblFailureAlert.AutoSize = true;
            this.lblFailureAlert.Location = new System.Drawing.Point(29, 73);
            this.lblFailureAlert.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFailureAlert.Name = "lblFailureAlert";
            this.lblFailureAlert.Size = new System.Drawing.Size(104, 17);
            this.lblFailureAlert.TabIndex = 15;
            this.lblFailureAlert.Text = "Nivel de Alerta:";
            // 
            // lblFailureType
            // 
            this.lblFailureType.AutoSize = true;
            this.lblFailureType.Location = new System.Drawing.Point(93, 23);
            this.lblFailureType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFailureType.Name = "lblFailureType";
            this.lblFailureType.Size = new System.Drawing.Size(40, 17);
            this.lblFailureType.TabIndex = 14;
            this.lblFailureType.Text = "Tipo:";
            // 
            // btnSendFailure
            // 
            this.btnSendFailure.Location = new System.Drawing.Point(93, 126);
            this.btnSendFailure.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendFailure.Name = "btnSendFailure";
            this.btnSendFailure.Size = new System.Drawing.Size(169, 28);
            this.btnSendFailure.TabIndex = 13;
            this.btnSendFailure.Text = "Reportar Falla";
            this.btnSendFailure.UseVisualStyleBackColor = true;
            this.btnSendFailure.Click += new System.EventHandler(this.btnSendFailure_Click);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(20, 304);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(120, 17);
            this.lblLog.TabIndex = 14;
            this.lblLog.Text = "Log de Mensajes:";
            // 
            // timerSendStatus
            // 
            this.timerSendStatus.Enabled = true;
            this.timerSendStatus.Interval = 5000;
            this.timerSendStatus.Tick += new System.EventHandler(this.timerSendStatus_Tick);
            // 
            // statusButton
            // 
            this.statusButton.Location = new System.Drawing.Point(133, 61);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(251, 34);
            this.statusButton.TabIndex = 15;
            this.statusButton.Tag = "";
            this.statusButton.Text = "Apagar";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 590);
            this.Controls.Add(this.statusButton);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMessageLog);
            this.Controls.Add(this.listBoxMessageLog);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnOnOff);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Device";
            this.Text = "Dispositivo de Monitoreo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Device_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatusOnOff;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox listBoxMessageLog;
        private System.Windows.Forms.Label lblMessageLog;
        private System.Windows.Forms.ComboBox comboFailureType;
        private System.Windows.Forms.ComboBox comboFailureAlertLevel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFailureAlert;
        private System.Windows.Forms.Label lblFailureType;
        private System.Windows.Forms.Button btnSendFailure;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Timer timerSendStatus;
        private System.Windows.Forms.Button statusButton;
    }
}

