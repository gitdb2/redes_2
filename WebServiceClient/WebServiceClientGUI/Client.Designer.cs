namespace ort.edu.uy.obligatorio2.WebServiceClientGUI
{
    partial class Client
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
            this.txtBoxClientId = new System.Windows.Forms.TextBox();
            this.lblClientId = new System.Windows.Forms.Label();
            this.btnSearchClient = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.listBoxDevices = new System.Windows.Forms.ListBox();
            this.lblDevices = new System.Windows.Forms.Label();
            this.lblMaxResults = new System.Windows.Forms.Label();
            this.txtMaxResults = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // txtBoxClientId
            // 
            this.txtBoxClientId.Location = new System.Drawing.Point(88, 19);
            this.txtBoxClientId.Name = "txtBoxClientId";
            this.txtBoxClientId.Size = new System.Drawing.Size(114, 20);
            this.txtBoxClientId.TabIndex = 0;
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(13, 22);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(71, 13);
            this.lblClientId.TabIndex = 1;
            this.lblClientId.Text = "Id del Cliente:";
            // 
            // btnSearchClient
            // 
            this.btnSearchClient.Location = new System.Drawing.Point(219, 17);
            this.btnSearchClient.Name = "btnSearchClient";
            this.btnSearchClient.Size = new System.Drawing.Size(75, 23);
            this.btnSearchClient.TabIndex = 2;
            this.btnSearchClient.Text = "Traer Datos";
            this.btnSearchClient.UseVisualStyleBackColor = true;
            this.btnSearchClient.Click += new System.EventHandler(this.btnSearchClient_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(116, 328);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listBoxDevices
            // 
            this.listBoxDevices.FormattingEnabled = true;
            this.listBoxDevices.Location = new System.Drawing.Point(16, 123);
            this.listBoxDevices.Name = "listBoxDevices";
            this.listBoxDevices.Size = new System.Drawing.Size(278, 199);
            this.listBoxDevices.TabIndex = 4;
            this.listBoxDevices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxDevices_MouseDown);
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(13, 98);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(118, 13);
            this.lblDevices.TabIndex = 5;
            this.lblDevices.Text = "Dispositivos Asociados:";
            // 
            // lblMaxResults
            // 
            this.lblMaxResults.AutoSize = true;
            this.lblMaxResults.Location = new System.Drawing.Point(13, 64);
            this.lblMaxResults.Name = "lblMaxResults";
            this.lblMaxResults.Size = new System.Drawing.Size(180, 13);
            this.lblMaxResults.TabIndex = 6;
            this.lblMaxResults.Text = "Cantidad de Fallas o Estados a traer:";
            // 
            // txtMaxResults
            // 
            this.txtMaxResults.Location = new System.Drawing.Point(199, 61);
            this.txtMaxResults.Mask = "00000";
            this.txtMaxResults.Name = "txtMaxResults";
            this.txtMaxResults.PromptChar = ' ';
            this.txtMaxResults.Size = new System.Drawing.Size(95, 20);
            this.txtMaxResults.TabIndex = 7;
            this.txtMaxResults.Text = "100";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 363);
            this.Controls.Add(this.txtMaxResults);
            this.Controls.Add(this.lblMaxResults);
            this.Controls.Add(this.lblDevices);
            this.Controls.Add(this.listBoxDevices);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearchClient);
            this.Controls.Add(this.lblClientId);
            this.Controls.Add(this.txtBoxClientId);
            this.Name = "Client";
            this.Text = "Cliente WebService";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxClientId;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.Button btnSearchClient;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox listBoxDevices;
        private System.Windows.Forms.Label lblDevices;
        private System.Windows.Forms.Label lblMaxResults;
        private System.Windows.Forms.MaskedTextBox txtMaxResults;
    }
}

