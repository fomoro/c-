
namespace Resorts_UNED.Presentacion
{
    partial class FrmConeccionClientes
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
            this.LblClientes = new System.Windows.Forms.Label();
            this.DgvClientes = new System.Windows.Forms.DataGridView();
            this.TxtStatus = new System.Windows.Forms.TextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.BtnStop = new System.Windows.Forms.Button();
            this.LblPort = new System.Windows.Forms.Label();
            this.LblHost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // LblClientes
            // 
            this.LblClientes.AutoSize = true;
            this.LblClientes.Location = new System.Drawing.Point(33, 228);
            this.LblClientes.Name = "LblClientes";
            this.LblClientes.Size = new System.Drawing.Size(58, 17);
            this.LblClientes.TabIndex = 59;
            this.LblClientes.Text = "Clientes";
            // 
            // DgvClientes
            // 
            this.DgvClientes.AllowUserToAddRows = false;
            this.DgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClientes.Location = new System.Drawing.Point(33, 270);
            this.DgvClientes.Name = "DgvClientes";
            this.DgvClientes.ReadOnly = true;
            this.DgvClientes.RowHeadersWidth = 51;
            this.DgvClientes.RowTemplate.Height = 24;
            this.DgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvClientes.Size = new System.Drawing.Size(899, 150);
            this.DgvClientes.TabIndex = 58;
            // 
            // TxtStatus
            // 
            this.TxtStatus.Location = new System.Drawing.Point(33, 78);
            this.TxtStatus.Multiline = true;
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.Size = new System.Drawing.Size(899, 127);
            this.TxtStatus.TabIndex = 57;
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(431, 22);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(92, 30);
            this.BtnStart.TabIndex = 56;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(321, 26);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(56, 22);
            this.TxtPort.TabIndex = 55;
            this.TxtPort.Text = "8910";
            // 
            // TxtHost
            // 
            this.TxtHost.Location = new System.Drawing.Point(84, 27);
            this.TxtHost.Name = "TxtHost";
            this.TxtHost.Size = new System.Drawing.Size(152, 22);
            this.TxtHost.TabIndex = 54;
            this.TxtHost.Text = "127.0.0.1";
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(529, 23);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(87, 30);
            this.BtnStop.TabIndex = 53;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // LblPort
            // 
            this.LblPort.AutoSize = true;
            this.LblPort.Location = new System.Drawing.Point(277, 29);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(34, 17);
            this.LblPort.TabIndex = 52;
            this.LblPort.Text = "Port";
            // 
            // LblHost
            // 
            this.LblHost.AutoSize = true;
            this.LblHost.Location = new System.Drawing.Point(30, 30);
            this.LblHost.Name = "LblHost";
            this.LblHost.Size = new System.Drawing.Size(37, 17);
            this.LblHost.TabIndex = 51;
            this.LblHost.Text = "Host";
            // 
            // FrmConeccionClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 446);
            this.Controls.Add(this.LblClientes);
            this.Controls.Add(this.DgvClientes);
            this.Controls.Add(this.TxtStatus);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.TxtPort);
            this.Controls.Add(this.TxtHost);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.LblPort);
            this.Controls.Add(this.LblHost);
            this.Name = "FrmConeccionClientes";
            this.Text = "FrmConeccionClientes";
            this.Load += new System.EventHandler(this.FrmConeccionClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblClientes;
        private System.Windows.Forms.DataGridView DgvClientes;
        private System.Windows.Forms.TextBox TxtStatus;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.TextBox TxtHost;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Label LblPort;
        private System.Windows.Forms.Label LblHost;
    }
}