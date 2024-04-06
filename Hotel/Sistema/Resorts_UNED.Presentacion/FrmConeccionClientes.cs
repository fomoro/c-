using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Resorts_UNED.Entidades;
using Resorts_UNED.Negocio;
using SimpleTCP;

namespace Resorts_UNED.Presentacion
{
    public partial class FrmConeccionClientes : Form
    {        
        private SimpleTcpServer server;
        public FrmConeccionClientes()
        {
            InitializeComponent();
        }
        private void FrmConeccionClientes_Load(object sender, EventArgs e)
        {
            DgvClientes.AutoGenerateColumns = true;
            DgvClientes.DataSource = new NCliente().Listar();

            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DelimiterDataReceived += Server_DataReceived;
            server.ClientConnected += Server_ClientConnected;
        }
        private void UpdateStatus(string message)
        {
            TxtStatus.Invoke((MethodInvoker)delegate ()
            {
                TxtStatus.AppendText(message + Environment.NewLine);
            });
        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Server_ClientConnected(object sender, TcpClient e)
        {
            UpdateStatus("Cliente conectado exitosamente.");
        }
        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            ProcessMessage(e);
        }
        private void ProcessMessage(SimpleTCP.Message e)
        {
            string message = e.MessageString.Trim();

            try
            {
                Login receivedClient = JsonConvert.DeserializeObject<Login>(message);
                UpdateStatus($"Datos Recibidos: Id: {receivedClient.Id} clave : {receivedClient.Clave}");
                e.ReplyLine($"Datos enviados por el servidor: Se conecto bien");

                //DgvArticuloHotel.DataSource = new NArticulo().ObtenerPorCliente(receivedClient.Id);
                //Cliente foundClient = new NArticulo().ObtenerPorCliente(receivedClient.Id);
                var foundClient = new NArticulo().ObtenerPorCliente(receivedClient.Id);
                if (foundClient != null)
                {
                    //SendClientDetails(e, foundClient);
                    //SendArticles(e);
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
            string clienteJson = JsonConvert.SerializeObject(cliente);
            e.ReplyLine("Cliente" + clienteJson);
        }
        private void SendArticles(SimpleTCP.Message e)
        {
            //var articulos = new NArticulo().Listar();
            //List<Articulo> articulos = data.ObtenerProductos();
            //string articlesJson = JsonConvert.SerializeObject(articulos);
            //e.ReplyLine("Articulos" + articlesJson);
        }        
        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtHost != null && TxtPort != null)
                {
                    StartServer();
                }
                else
                {
                    ShowError("Los controles TxtHost y TxtPort no están inicializados correctamente.");
                }
            }
            catch (FormatException)
            {
                ShowError("Formato de dirección IP no válido. Introduzca una dirección IP válida.");
            }
            catch (Exception ex)
            {
                ShowError("Error al iniciar el servidor: " + ex.Message);
            }
        }

        private void StartServer()
        {
            var ip = IPAddress.Parse(TxtHost.Text);
            server.Start(ip, Convert.ToInt32(TxtPort.Text));
            UpdateStatus("Servidor iniciado.");
        }
        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (server != null && server.IsStarted)
            {
                server.Stop();
                UpdateStatus("Servidor detenido.");
            }
            else
            {
                ShowInfo("El servidor no está funcionando.");
            }
        }
        
    }
}
