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
            this.lblName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOnOff = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStatusOnOff = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblFailures = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSendFailure = new System.Windows.Forms.Button();
            this.listBoxMessageLog = new System.Windows.Forms.ListBox();
            this.lblMessageLog = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btnOnOff
            // 
            this.btnOnOff.Location = new System.Drawing.Point(56, 52);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(121, 23);
            this.btnOnOff.TabIndex = 2;
            this.btnOnOff.Text = "Encender";
            this.btnOnOff.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelName,
            this.toolStripStatusLabelStatusOnOff});
            this.statusStrip.Location = new System.Drawing.Point(0, 348);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(304, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "Estado Actual:";
            // 
            // toolStripStatusLabelName
            // 
            this.toolStripStatusLabelName.Name = "toolStripStatusLabelName";
            this.toolStripStatusLabelName.Size = new System.Drawing.Size(82, 17);
            this.toolStripStatusLabelName.Text = "Estado Actual:";
            // 
            // toolStripStatusLabelStatusOnOff
            // 
            this.toolStripStatusLabelStatusOnOff.Name = "toolStripStatusLabelStatusOnOff";
            this.toolStripStatusLabelStatusOnOff.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabelStatusOnOff.Text = "Apagado";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 57);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Estado:";
            // 
            // lblFailures
            // 
            this.lblFailures.AutoSize = true;
            this.lblFailures.Location = new System.Drawing.Point(10, 99);
            this.lblFailures.Name = "lblFailures";
            this.lblFailures.Size = new System.Drawing.Size(37, 13);
            this.lblFailures.TabIndex = 5;
            this.lblFailures.Text = "Fallas:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(56, 96);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // btnSendFailure
            // 
            this.btnSendFailure.Location = new System.Drawing.Point(193, 94);
            this.btnSendFailure.Name = "btnSendFailure";
            this.btnSendFailure.Size = new System.Drawing.Size(88, 23);
            this.btnSendFailure.TabIndex = 7;
            this.btnSendFailure.Text = "Reportar Falla";
            this.btnSendFailure.UseVisualStyleBackColor = true;
            // 
            // listBoxMessageLog
            // 
            this.listBoxMessageLog.FormattingEnabled = true;
            this.listBoxMessageLog.Location = new System.Drawing.Point(12, 164);
            this.listBoxMessageLog.Name = "listBoxMessageLog";
            this.listBoxMessageLog.Size = new System.Drawing.Size(268, 173);
            this.listBoxMessageLog.TabIndex = 8;
            // 
            // lblMessageLog
            // 
            this.lblMessageLog.AutoSize = true;
            this.lblMessageLog.Location = new System.Drawing.Point(9, 137);
            this.lblMessageLog.Name = "lblMessageLog";
            this.lblMessageLog.Size = new System.Drawing.Size(91, 13);
            this.lblMessageLog.TabIndex = 9;
            this.lblMessageLog.Text = "Log de Mensajes:";
            // 
            // Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 370);
            this.Controls.Add(this.lblMessageLog);
            this.Controls.Add(this.listBoxMessageLog);
            this.Controls.Add(this.btnSendFailure);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblFailures);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnOnOff);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Device";
            this.Text = "Dispositivo de Monitoreo";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatusOnOff;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblFailures;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSendFailure;
        private System.Windows.Forms.ListBox listBoxMessageLog;
        private System.Windows.Forms.Label lblMessageLog;
    }
}

