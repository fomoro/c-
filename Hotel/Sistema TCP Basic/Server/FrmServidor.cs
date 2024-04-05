using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServidor : Form
    {
        public FrmServidor()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;
        private void FrmServidor_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DelimiterDataReceived += Server_DataReceived;
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            TxtStatus.Invoke((MethodInvoker)delegate () {
                //TxtStatus.Text += e.MessageString;
                TxtStatus.AppendText(e.MessageString + Environment.NewLine);
                e.ReplyLine(string.Format("you said: {0} ", e.MessageString));
            });
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            TxtStatus.Text += "Server starting..." + Environment.NewLine;

            try
            {
                IPAddress ip = IPAddress.Parse(TxtHost.Text);
                server.Start(ip, Convert.ToInt32(TxtPort.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid IP address format. Please enter a valid IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (server != null && server.IsStarted)
            {
                server.Stop();
                TxtStatus.AppendText("Server stopped." + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("Server is not running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
