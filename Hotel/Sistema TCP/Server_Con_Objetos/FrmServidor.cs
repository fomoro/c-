using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using SimpleTCP;

namespace Server_Con_Objetos
{
    public partial class FrmServidor : Form
    {
        private readonly Data data = new Data();
        private SimpleTcpServer server;

        public FrmServidor()
        {
            InitializeComponent();
        }

        private void FrmServidor_Load(object sender, EventArgs e)
        {
            DgvClientes.AutoGenerateColumns = true;
            DgvClientes.DataSource = data.Clientes;

            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DelimiterDataReceived += Server_DataReceived;
            server.ClientConnected += Server_ClientConnected;
        }

        private void Server_ClientConnected(object sender, TcpClient e)
        {
            TxtStatus.Invoke((MethodInvoker)delegate ()
            {
                TxtStatus.AppendText("Cliente conectado exitosamente." + Environment.NewLine);
            });
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            TxtStatus.Invoke((MethodInvoker)delegate ()
            {
                ProcessMessage(e);
            });
        }

        private void ProcessMessage(SimpleTCP.Message e)
        {
            string message = e.MessageString.Trim();

            try
            {
                Cliente receivedClient = JsonConvert.DeserializeObject<Cliente>(message);
                Cliente foundClient = data.ObtenerClientePorId(receivedClient.Id);

                if (foundClient != null)
                {
                    SendClientDetails(e, foundClient);
                    SendClientArticles(e, foundClient);
                }
                else
                {
                    e.ReplyLine("Cliente no existe");
                }
            }
            catch (Exception ex)
            {
                e.ReplyLine("Error al deserializar el cliente: " + ex.Message);
            }
        }
        private void SendClientDetails(SimpleTCP.Message e, Cliente cliente)
        {
            string details = $"Cliente: {cliente.Nombre} {cliente.Apellido}, ID: {cliente.Id}, Fecha de nacimiento: {cliente.FechaNacimiento}";
            e.ReplyLine(details + Environment.NewLine);
            TxtStatus.AppendText(details + Environment.NewLine);
            e.ReplyLine($"Datos del cliente recibidos: {cliente.Nombre} {cliente.Apellido}, ID: {cliente.Id}");
        }
        private void SendClientArticles(SimpleTCP.Message e, Cliente cliente)
        {
            List<Articulo> articulos = data.ObtenerArticulosPorClienteId(cliente.Id);
            string articlesJson = JsonConvert.SerializeObject(articulos);
            e.ReplyLine("ARTICULOS" + articlesJson);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(TxtHost.Text);
                server.Start(ip, Convert.ToInt32(TxtPort.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Formato de dirección IP no válido. Introduzca una dirección IP válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar el servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TxtStatus.AppendText("Servidor iniciado." + Environment.NewLine);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (server != null && server.IsStarted)
            {
                server.Stop();
                TxtStatus.AppendText("Servidor detenido." + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("El servidor no está funcionando.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
