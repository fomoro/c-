
namespace Client_Con_Objetos
{
    partial class FrmCliente
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
            this.TxtStatus = new System.Windows.Forms.TextBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.LblPort = new System.Windows.Forms.Label();
            this.LblHost = new System.Windows.Forms.Label();
            this.TxtApellidoCliente = new System.Windows.Forms.TextBox();
            this.TxtNombreCliente = new System.Windows.Forms.TextBox();
            this.LblNombreCliente = new System.Windows.Forms.Label();
            this.LblApellidoCliente = new System.Windows.Forms.Label();
            this.LblIdCliente = new System.Windows.Forms.Label();
            this.TxtIdCliente = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtStatus
            // 
            this.TxtStatus.Location = new System.Drawing.Point(12, 269);
            this.TxtStatus.Multiline = true;
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.Size = new System.Drawing.Size(522, 169);
            this.TxtStatus.TabIndex = 62;
            // 
            // BtnSend
            // 
            this.BtnSend.Enabled = false;
            this.BtnSend.Location = new System.Drawing.Point(554, 178);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 36);
            this.BtnSend.TabIndex = 61;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // TxtMessage
            // 
            this.TxtMessage.Location = new System.Drawing.Point(12, 178);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(522, 62);
            this.TxtMessage.TabIndex = 60;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(554, 24);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 36);
            this.BtnConnect.TabIndex = 59;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(382, 31);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(152, 22);
            this.TxtPort.TabIndex = 58;
            this.TxtPort.Text = "8910";
            // 
            // TxtHost
            // 
            this.TxtHost.Location = new System.Drawing.Point(110, 25);
            this.TxtHost.Name = "TxtHost";
            this.TxtHost.Size = new System.Drawing.Size(152, 22);
            this.TxtHost.TabIndex = 57;
            this.TxtHost.Text = "127.0.0.1";
            // 
            // LblPort
            // 
            this.LblPort.AutoSize = true;
            this.LblPort.Location = new System.Drawing.Point(312, 34);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(34, 17);
            this.LblPort.TabIndex = 56;
            this.LblPort.Text = "Port";
            // 
            // LblHost
            // 
            this.LblHost.AutoSize = true;
            this.LblHost.Location = new System.Drawing.Point(20, 28);
            this.LblHost.Name = "LblHost";
            this.LblHost.Size = new System.Drawing.Size(37, 17);
            this.LblHost.TabIndex = 55;
            this.LblHost.Text = "Host";
            // 
            // TxtApellidoCliente
            // 
            this.TxtApellidoCliente.Location = new System.Drawing.Point(382, 104);
            this.TxtApellidoCliente.Name = "TxtApellidoCliente";
            this.TxtApellidoCliente.Size = new System.Drawing.Size(152, 22);
            this.TxtApellidoCliente.TabIndex = 64;
            // 
            // TxtNombreCliente
            // 
            this.TxtNombreCliente.Location = new System.Drawing.Point(110, 104);
            this.TxtNombreCliente.Name = "TxtNombreCliente";
            this.TxtNombreCliente.Size = new System.Drawing.Size(152, 22);
            this.TxtNombreCliente.TabIndex = 63;
            // 
            // LblNombreCliente
            // 
            this.LblNombreCliente.AutoSize = true;
            this.LblNombreCliente.Location = new System.Drawing.Point(20, 109);
            this.LblNombreCliente.Name = "LblNombreCliente";
            this.LblNombreCliente.Size = new System.Drawing.Size(58, 17);
            this.LblNombreCliente.TabIndex = 65;
            this.LblNombreCliente.Text = "Nombre";
            // 
            // LblApellidoCliente
            // 
            this.LblApellidoCliente.AutoSize = true;
            this.LblApellidoCliente.Location = new System.Drawing.Point(312, 109);
            this.LblApellidoCliente.Name = "LblApellidoCliente";
            this.LblApellidoCliente.Size = new System.Drawing.Size(58, 17);
            this.LblApellidoCliente.TabIndex = 66;
            this.LblApellidoCliente.Text = "Apellido";
            // 
            // LblIdCliente
            // 
            this.LblIdCliente.AutoSize = true;
            this.LblIdCliente.Location = new System.Drawing.Point(20, 72);
            this.LblIdCliente.Name = "LblIdCliente";
            this.LblIdCliente.Size = new System.Drawing.Size(19, 17);
            this.LblIdCliente.TabIndex = 67;
            this.LblIdCliente.Text = "Id";
            // 
            // TxtIdCliente
            // 
            this.TxtIdCliente.Location = new System.Drawing.Point(110, 68);
            this.TxtIdCliente.Name = "TxtIdCliente";
            this.TxtIdCliente.Size = new System.Drawing.Size(152, 22);
            this.TxtIdCliente.TabIndex = 68;
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 450);
            this.Controls.Add(this.TxtIdCliente);
            this.Controls.Add(this.LblIdCliente);
            this.Controls.Add(this.LblApellidoCliente);
            this.Controls.Add(this.LblNombreCliente);
            this.Controls.Add(this.TxtApellidoCliente);
            this.Controls.Add(this.TxtNombreCliente);
            this.Controls.Add(this.TxtStatus);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.TxtPort);
            this.Controls.Add(this.TxtHost);
            this.Controls.Add(this.LblPort);
            this.Controls.Add(this.LblHost);
            this.Name = "FrmCliente";
            this.Text = "FrmCliente";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtStatus;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.TextBox TxtHost;
        private System.Windows.Forms.Label LblPort;
        private System.Windows.Forms.Label LblHost;
        private System.Windows.Forms.TextBox TxtApellidoCliente;
        private System.Windows.Forms.TextBox TxtNombreCliente;
        private System.Windows.Forms.Label LblNombreCliente;
        private System.Windows.Forms.Label LblApellidoCliente;
        private System.Windows.Forms.Label LblIdCliente;
        private System.Windows.Forms.TextBox TxtIdCliente;
    }
}