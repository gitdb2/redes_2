namespace ort.edu.uy.obligatorio2.ClientDevicesGUI
{
    partial class ClientDevicesInfo
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
            this.comboBoxAllClients = new System.Windows.Forms.ComboBox();
            this.lblSelectClient = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.listBoxAvailable = new System.Windows.Forms.ListBox();
            this.lblDevices = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAllClients
            // 
            this.comboBoxAllClients.FormattingEnabled = true;
            this.comboBoxAllClients.Location = new System.Drawing.Point(97, 20);
            this.comboBoxAllClients.Name = "comboBoxAllClients";
            this.comboBoxAllClients.Size = new System.Drawing.Size(165, 21);
            this.comboBoxAllClients.TabIndex = 18;
            this.comboBoxAllClients.SelectedIndexChanged += new System.EventHandler(this.comboBoxAllClients_SelectedIndexChanged);
            // 
            // lblSelectClient
            // 
            this.lblSelectClient.AutoSize = true;
            this.lblSelectClient.Location = new System.Drawing.Point(22, 23);
            this.lblSelectClient.Name = "lblSelectClient";
            this.lblSelectClient.Size = new System.Drawing.Size(69, 13);
            this.lblSelectClient.TabIndex = 17;
            this.lblSelectClient.Text = "Seleccionar: ";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(104, 257);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listBoxAvailable
            // 
            this.listBoxAvailable.FormattingEnabled = true;
            this.listBoxAvailable.Location = new System.Drawing.Point(24, 82);
            this.listBoxAvailable.Name = "listBoxAvailable";
            this.listBoxAvailable.Size = new System.Drawing.Size(237, 160);
            this.listBoxAvailable.TabIndex = 14;
            this.listBoxAvailable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxAvailable_MouseDown);
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(21, 54);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(118, 13);
            this.lblDevices.TabIndex = 13;
            this.lblDevices.Text = "Dispositivos Asociados:";
            // 
            // ClientDevicesInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 300);
            this.Controls.Add(this.comboBoxAllClients);
            this.Controls.Add(this.lblSelectClient);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.listBoxAvailable);
            this.Controls.Add(this.lblDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClientDevicesInfo";
            this.Text = "Dispositivos de Cliente";
            this.Load += new System.EventHandler(this.ClientDevicesInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAllClients;
        private System.Windows.Forms.Label lblSelectClient;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox listBoxAvailable;
        private System.Windows.Forms.Label lblDevices;
    }
}