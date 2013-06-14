namespace ort.edu.uy.obligatorio2.ClientDevicesGUI
{
    partial class DeviceLog
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
            this.listBoxDeviceLog = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxDeviceLog
            // 
            this.listBoxDeviceLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxDeviceLog.FormattingEnabled = true;
            this.listBoxDeviceLog.HorizontalScrollbar = true;
            this.listBoxDeviceLog.Location = new System.Drawing.Point(0, 0);
            this.listBoxDeviceLog.Name = "listBoxDeviceLog";
            this.listBoxDeviceLog.Size = new System.Drawing.Size(446, 251);
            this.listBoxDeviceLog.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(186, 261);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DeviceLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 292);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.listBoxDeviceLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DeviceLog";
            this.Text = "DeviceLog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDeviceLog;
        private System.Windows.Forms.Button btnClose;
    }
}