using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using SimpleTCP;

namespace Client_Con_Objetos
{
    public partial class FrmCliente : Form
    {
        private SimpleTcpClient client;
        private bool isConnected = false;
        private List<Articulo> articulos;
        private List<Articulo> articulosCliente;
        public FrmCliente()
        {
            InitializeComponent();
            InitializeClient();
        }
        private void InitializeClient()
        {
            client = new SimpleTcpClient
            {
                StringEncoder = Encoding.UTF8
            };
            client.DelimiterDataReceived += Client_DataReceived;
            BtnDesconectar.Enabled = false;
        }
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                MessageBox.Show("El cliente ya está conectado al servidor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (!ValidateIpAddress() || !ValidatePort() || !ValidateClientCredentials())
                    return;

                ConnectToServer();
                isConnected = true;
                BtnConnect.Enabled = false;
                BtnDesconectar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar al servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateIpAddress()
        {
            if (!IPAddress.TryParse(TxtHost.Text, out IPAddress ip))
            {
                MessageBox.Show("Formato de dirección IP no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ValidatePort()
        {
            int port = Convert.ToInt32(TxtPort.Text);
            if (port < 0 || port > 65535)
            {
                MessageBox.Show("Número de puerto no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ValidateClientCredentials()
        {
            if (string.IsNullOrEmpty(TxtIdCliente.Text) || string.IsNullOrEmpty(TxtClave.Text))
            {
                MessageBox.Show("Introduzca un ID y una Clave de cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void ConnectToServer()
        {
            Login cliente = new Login
            {
                Id = TxtIdCliente.Text,
                Clave = TxtClave.Text
            };

            string mensaje = JsonConvert.SerializeObject(cliente);
            client.Connect(TxtHost.Text, Convert.ToInt32(TxtPort.Text));
            client.WriteLineAndGetReply(mensaje, TimeSpan.FromSeconds(2));
        }
        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            ProcessMessage(e);
        }
        private void ProcessMessage(SimpleTCP.Message e)
        {
            string mensaje = e.MessageString.Trim();
            UpdateStatus("Mensaje recibido del servidor: " + mensaje + Environment.NewLine);

            if (e.MessageString.StartsWith("Articulos"))
            {
                DisplayArticles(e.MessageString);
            }
            else if (e.MessageString.StartsWith("Cliente"))
            {
                DisplayClient(e.MessageString);
            }
        }
        private void DisplayArticles(string message)
        {
            string articulosJson = message.Substring("Articulos".Length);
            articulos = JsonConvert.DeserializeObject<List<Articulo>>(articulosJson);       

            Invoke((MethodInvoker)delegate {
                DgvArticulos.AutoGenerateColumns = true;
                CboArticulos.DataSource = articulos;
                CboArticulos.DisplayMember = "Nombre";
                CboArticulos.ValueMember = "IdArticulo";
            });
        }
        private void DisplayClient(string message)
        {
            string clienteJson = message.Substring("Cliente".Length);
            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(clienteJson);
            articulosCliente = cliente.Articulos;
            Invoke((MethodInvoker)delegate {
                DgvArticulos.AutoGenerateColumns = true;
                DgvArticulos.DataSource = articulosCliente;
            });
        }
        private void UpdateStatus(string message)
        {
            TxtStatus.Invoke((MethodInvoker)delegate ()
            {
                TxtStatus.AppendText(message + Environment.NewLine);
            });
        }
        private void BtnDesconectar_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                DisconnectFromServer();
            }
            else
            {
                MessageBox.Show("El cliente ya está desconectado del servidor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DisconnectFromServer()
        {
            client.Disconnect();
            isConnected = false;
            BtnConnect.Enabled = true;
            BtnDesconectar.Enabled = false;
            articulos.Clear();
            DgvArticulos.DataSource = null;
        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (CboArticulos.SelectedItem != null)
            {
                Articulo articuloSeleccionado = (Articulo)CboArticulos.SelectedItem;
                AgregarArticuloAlDataGridView(articuloSeleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione un artículo para agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AgregarArticuloAlDataGridView(Articulo articulo)
        {            
            DgvArticulos.AutoGenerateColumns = true;
            articulosCliente.Add(articulo);            
            DgvArticulos.DataSource = null;
            DgvArticulos.DataSource = articulosCliente;
        }

    }
}
