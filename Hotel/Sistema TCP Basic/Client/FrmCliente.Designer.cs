
namespace Client
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
            this.SuspendLayout();
            // 
            // TxtStatus
            // 
            this.TxtStatus.Location = new System.Drawing.Point(12, 196);
            this.TxtStatus.Multiline = true;
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.Size = new System.Drawing.Size(522, 169);
            this.TxtStatus.TabIndex = 54;
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(459, 154);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 36);
            this.BtnSend.TabIndex = 53;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // TxtMessage
            // 
            this.TxtMessage.Location = new System.Drawing.Point(12, 72);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(522, 62);
            this.TxtMessage.TabIndex = 52;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(459, 13);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 36);
            this.BtnConnect.TabIndex = 51;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(278, 20);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(152, 22);
            this.TxtPort.TabIndex = 50;
            this.TxtPort.Text = "8910";
            // 
            // TxtHost
            // 
            this.TxtHost.Location = new System.Drawing.Point(56, 17);
            this.TxtHost.Name = "TxtHost";
            this.TxtHost.Size = new System.Drawing.Size(152, 22);
            this.TxtHost.TabIndex = 49;
            this.TxtHost.Text = "127.0.0.1";
            // 
            // LblPort
            // 
            this.LblPort.AutoSize = true;
            this.LblPort.Location = new System.Drawing.Point(232, 23);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(34, 17);
            this.LblPort.TabIndex = 48;
            this.LblPort.Text = "Port";
            // 
            // LblHost
            // 
            this.LblHost.AutoSize = true;
            this.LblHost.Location = new System.Drawing.Point(9, 20);
            this.LblHost.Name = "LblHost";
            this.LblHost.Size = new System.Drawing.Size(37, 17);
            this.LblHost.TabIndex = 47;
            this.LblHost.Text = "Host";
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 383);
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
    }
}