using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmCliente : Form
    {        
        public FrmCliente()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect(TxtHost.Text, Convert.ToInt32(TxtPort.Text));                                
                BtnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar al servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (client != null && client.TcpClient.Connected)
            {
                client.WriteLineAndGetReply(TxtMessage.Text, TimeSpan.FromSeconds(2));
            }
            else
            {
                MessageBox.Show("Cliente no conectado al servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DelimiterDataReceived += Client_DataReceived;
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            TxtMessage.Text = "";
            TxtStatus.Invoke((MethodInvoker)delegate ()
            {
                //TxtStatus.Text += e.MessageString;
                TxtStatus.AppendText(e.MessageString + Environment.NewLine);
            });
        }

    }
}
