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
            this.btnAccept = new System.Windows.Forms.Button();
            this.lvlSelectedDevices = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(17, 68);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(123, 13);
            this.lblDevices.TabIndex = 2;
            this.lblDevices.Text = "Dispositivos Disponibles:";
            // 
            // listBoxAvailable
            // 
            this.listBoxAvailable.FormattingEnabled = true;
            this.listBoxAvailable.Location = new System.Drawing.Point(20, 99);
            this.listBoxAvailable.Name = "listBoxAvailable";
            this.listBoxAvailable.Size = new System.Drawing.Size(145, 160);
            this.listBoxAvailable.TabIndex = 3;
            // 
            // listBoxSelected
            // 
            this.listBoxSelected.FormattingEnabled = true;
            this.listBoxSelected.Location = new System.Drawing.Point(273, 99);
            this.listBoxSelected.Name = "listBoxSelected";
            this.listBoxSelected.Size = new System.Drawing.Size(145, 160);
            this.listBoxSelected.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(182, 99);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(182, 128);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Quitar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(182, 157);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(75, 38);
            this.btnAddAll.TabIndex = 7;
            this.btnAddAll.Text = "Agregar Todos";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(182, 201);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 34);
            this.btnRemoveAll.TabIndex = 8;
            this.btnRemoveAll.Text = "Quitar Todos";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(238, 281);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.comboBoxAllClients.SelectedIndexChanged += new System.EventHandler(this.comboBoxAllClients_SelectedIndexChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(127, 281);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvlSelectedDevices
            // 
            this.lvlSelectedDevices.AutoSize = true;
            this.lvlSelectedDevices.Location = new System.Drawing.Point(270, 68);
            this.lvlSelectedDevices.Name = "lvlSelectedDevices";
            this.lvlSelectedDevices.Size = new System.Drawing.Size(118, 13);
            this.lvlSelectedDevices.TabIndex = 14;
            this.lvlSelectedDevices.Text = "Dispositivos Asociados:";
            // 
            // ModifiyClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 320);
            this.Controls.Add(this.lvlSelectedDevices);
            this.Controls.Add(this.btnAccept);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModifiyClient";
            this.Text = "Modificar Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lvlSelectedDevices;
    }
}