namespace ort.edu.uy.obligatorio2.ClientDevicesGUI
{
    partial class ModifiyClient
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
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDevices = new System.Windows.Forms.Label();
            this.listBoxAvailable = new System.Windows.Forms.ListBox();
            this.listBoxSelected = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSelectClient = new System.Windows.Forms.Label();
            this.comboBoxAllClients = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(90, 60);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(165, 20);
            this.txtBoxName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 63);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nombre:";
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(15, 100);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(118, 13);
            this.lblDevices.TabIndex = 2;
            this.lblDevices.Text = "Dispositivos Asociados:";
            // 
            // listBoxAvailable
            // 
            this.listBoxAvailable.FormattingEnabled = true;
            this.listBoxAvailable.Location = new System.Drawing.Point(18, 131);
            this.listBoxAvailable.Name = "listBoxAvailable";
            this.listBoxAvailable.Size = new System.Drawing.Size(145, 160);
            this.listBoxAvailable.TabIndex = 3;
            // 
            // listBoxSelected
            // 
            this.listBoxSelected.FormattingEnabled = true;
            this.listBoxSelected.Location = new System.Drawing.Point(271, 131);
            this.listBoxSelected.Name = "listBoxSelected";
            this.listBoxSelected.Size = new System.Drawing.Size(145, 160);
            this.listBoxSelected.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(180, 131);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(180, 160);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Quitar";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(180, 189);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(75, 38);
            this.btnAddAll.TabIndex = 7;
            this.btnAddAll.Text = "Agregar Todos";
            this.btnAddAll.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(180, 233);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 34);
            this.btnRemoveAll.TabIndex = 8;
            this.btnRemoveAll.Text = "Quitar Todos";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(236, 313);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblSelectClient
            // 
            this.lblSelectClient.AutoSize = true;
            this.lblSelectClient.Location = new System.Drawing.Point(15, 21);
            this.lblSelectClient.Name = "lblSelectClient";
            this.lblSelectClient.Size = new System.Drawing.Size(69, 13);
            this.lblSelectClient.TabIndex = 11;
            this.lblSelectClient.Text = "Seleccionar: ";
            // 
            // comboBoxAllClients
            // 
            this.comboBoxAllClients.FormattingEnabled = true;
            this.comboBoxAllClients.Location = new System.Drawing.Point(90, 18);
            this.comboBoxAllClients.Name = "comboBoxAllClients";
            this.comboBoxAllClients.Size = new System.Drawing.Size(165, 21);
            this.comboBoxAllClients.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ModifiyClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 359);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxAllClients);
            this.Controls.Add(this.lblSelectClient);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listBoxSelected);
            this.Controls.Add(this.listBoxAvailable);
            this.Controls.Add(this.lblDevices);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModifiyClient";
            this.Text = "Modificar Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDevices;
        private System.Windows.Forms.ListBox listBoxAvailable;
        private System.Windows.Forms.ListBox listBoxSelected;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSelectClient;
        private System.Windows.Forms.ComboBox comboBoxAllClients;
        private System.Windows.Forms.Button button1;
    }
}