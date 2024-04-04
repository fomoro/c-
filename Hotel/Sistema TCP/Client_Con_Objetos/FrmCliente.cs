using SimpleTCP;
using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Client_Con_Objetos
{
    public partial class FrmCliente : Form
    {
        private SimpleTcpClient client;
        private bool isConnected = false;
        private List<Articulo> articulos = new List<Articulo>();

        public FrmCliente()
        {
            InitializeComponent();
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DelimiterDataReceived += Client_DataReceived;
        }
    
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                try
                {
                    if (!IPAddress.TryParse(TxtHost.Text, out IPAddress ip))
                    {
                        MessageBox.Show("Formato de dirección IP no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int port = Convert.ToInt32(TxtPort.Text);
                    if (port < 0 || port > 65535)
                    {
                        MessageBox.Show("Número de puerto no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrEmpty(TxtIdCliente.Text))
                    {
                        MessageBox.Show("Introduzca un ID de cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Cliente cliente = new Cliente
                    {
                        Id = TxtIdCliente.Text,
                        Clave = TxtClave.Text,
                        FechaNacimiento = DateTime.Now
                    };

                    string mensaje = JsonConvert.SerializeObject(cliente);
                    client.Connect(TxtHost.Text, port);
                    client.WriteLineAndGetReply(mensaje, TimeSpan.FromSeconds(2));

                    isConnected = true;
                    BtnConnect.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar al servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El cliente ya está conectado al servidor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            TxtStatus.Invoke((MethodInvoker)delegate ()
            {
                ProcessMessage(e);
            });
        }

        private void ProcessMessage(SimpleTCP.Message e)
        {
            string mensaje = e.MessageString.Trim();
            TxtStatus.AppendText("Mensaje recibido del servidor: " + mensaje + Environment.NewLine);

            if (e.MessageString.StartsWith("ARTICULOS"))
            {
                string articulosJson = e.MessageString.Substring("ARTICULOS".Length);
                List<Articulo> articulosList = JsonConvert.DeserializeObject<List<Articulo>>(articulosJson);

                articulos.Clear();
                articulos.AddRange(articulosList);
                DgvArticulos.AutoGenerateColumns = true;
                DgvArticulos.DataSource = articulos;
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                client.Disconnect();
                isConnected = false;
                BtnConnect.Enabled = true;
                articulos.Clear();
                DgvArticulos.DataSource = null;
            }
            else
            {
                MessageBox.Show("El cliente ya está desconectado del servidor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
