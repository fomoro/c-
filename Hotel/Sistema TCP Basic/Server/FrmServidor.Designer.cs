
namespace Server
{
    partial class FrmServidor
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
            this.BtnStart = new System.Windows.Forms.Button();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.BtnStop = new System.Windows.Forms.Button();
            this.LblPort = new System.Windows.Forms.Label();
            this.LblHost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtStatus
            // 
            this.TxtStatus.Location = new System.Drawing.Point(12, 74);
            this.TxtStatus.Multiline = true;
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.Size = new System.Drawing.Size(583, 127);
            this.TxtStatus.TabIndex = 41;
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(410, 18);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(92, 30);
            this.BtnStart.TabIndex = 40;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(300, 22);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(56, 22);
            this.TxtPort.TabIndex = 39;
            this.TxtPort.Text = "8910";
            // 
            // TxtHost
            // 
            this.TxtHost.Location = new System.Drawing.Point(63, 23);
            this.TxtHost.Name = "TxtHost";
            this.TxtHost.Size = new System.Drawing.Size(152, 22);
            this.TxtHost.TabIndex = 38;
            this.TxtHost.Text = "127.0.0.1";
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(508, 19);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(87, 30);
            this.BtnStop.TabIndex = 37;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // LblPort
            // 
            this.LblPort.AutoSize = true;
            this.LblPort.Location = new System.Drawing.Point(256, 25);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(34, 17);
            this.LblPort.TabIndex = 36;
            this.LblPort.Text = "Port";
            // 
            // LblHost
            // 
            this.LblHost.AutoSize = true;
            this.LblHost.Location = new System.Drawing.Point(20, 25);
            this.LblHost.Name = "LblHost";
            this.LblHost.Size = new System.Drawing.Size(37, 17);
            this.LblHost.TabIndex = 35;
            this.LblHost.Text = "Host";
            // 
            // FrmServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 214);
            this.Controls.Add(this.TxtStatus);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.TxtPort);
            this.Controls.Add(this.TxtHost);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.LblPort);
            this.Controls.Add(this.LblHost);
            this.Name = "FrmServidor";
            this.Text = "FrmServidor";
            this.Load += new System.EventHandler(this.FrmServidor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtStatus;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.TextBox TxtHost;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Label LblPort;
        private System.Windows.Forms.Label LblHost;
    }
}