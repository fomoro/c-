using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Resorts_UNED.Entidades;
using SimpleTCP;

namespace Resorts_UNED.Presentacion_Cliente
{
    public partial class FrmCliente : Form
    {
        private SimpleTcpClient client;
        private bool isConnected = false;
        private List<Articulo> _articulos;
        private List<Pedido> _pedidosCliente;
        public FrmCliente()
        {
            InitializeComponent();
            InitializeClient();
        }
        private void InitializeClient()
        {
            _articulos = new List<Articulo>();
            _pedidosCliente = new List<Pedido>();
            client = new SimpleTcpClient
            {
                StringEncoder = Encoding.UTF8
            };
            client.DelimiterDataReceived += Client_DataReceived;
            BtnDesconectar.Enabled = false;
        }
        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            ProcessMessage(e);
        }
        private void ProcessMessage(SimpleTCP.Message e)
        {
            string mensaje = e.MessageString.Trim();
            UpdateStatus("Mensaje recibido del servidor: " + mensaje + Environment.NewLine);

            if (e.MessageString.StartsWith("ClienteDetalles"))
            {
                DisplayClientDetails(e.MessageString);
                //FormatArticlesDataGridView();
            }
            else if (e.MessageString.StartsWith("Articulos"))
            {
                DisplayArticles(e.MessageString);
            }
            else if (e.MessageString.StartsWith("No"))
            {
                DisconnectFromServer();
            }
        }
        private void FormatArticlesDataGridView()
        {

            // Ocultar la primera columna
            DgvPedidos.Columns[0].Visible = false;
            DgvPedidos.Columns[1].Visible = false;
            DgvPedidos.Columns[2].Visible = false;
            DgvPedidos.Columns[3].Visible = false;
            DgvPedidos.Columns[4].Visible = false;

            // Establecer el encabezado y ancho de las columnas
        }
        private void DisplayArticles(string message)
        {
            string articulosJson = message.Substring("Articulos".Length);
            _articulos = JsonConvert.DeserializeObject<List<Articulo>>(articulosJson);

            Invoke((MethodInvoker)delegate
            {
                DgvPedidos.AutoGenerateColumns = true;
                CboArticulos.DataSource = _articulos;
                CboArticulos.DisplayMember = "Nombre";
                CboArticulos.ValueMember = "ID";
            });
        }
        private void UpdateStatus(string message)
        {
            TxtStatus.Invoke((MethodInvoker)delegate ()
            {
                TxtStatus.AppendText(message + Environment.NewLine);
            });
        }
        private void DisplayClientDetails(string message)
        {
            string articulosJson = message.Substring("ClienteDetalles".Length);
            _pedidosCliente = JsonConvert.DeserializeObject<List<Pedido>>(articulosJson);

            Invoke((MethodInvoker)delegate
            {
                DgvPedidos.AutoGenerateColumns = true;
                DgvPedidos.DataSource = _pedidosCliente;
                FormatArticlesDataGridView();
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
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)DisconnectFromServer);
                return;
            }

            client.Disconnect();
            isConnected = false;
            _articulos.Clear();
            DgvPedidos.DataSource = null;
            BtnDesconectar.Enabled = false;
            BtnConnect.Enabled = true;
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
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (CboArticulos.SelectedItem != null && CboArticulos.SelectedItem is Articulo articuloSeleccionado)
            {
                Articulo articuloEnLista = _articulos.FirstOrDefault(articulo => articulo.ID == articuloSeleccionado.ID);

                if (articuloEnLista != null)
                {
                    Pedido newProduct = new Pedido()
                    {
                        FechaPedido = DateTime.Now,
                        IdCliente = TxtIdCliente.Text,
                        IdArticulo = articuloEnLista.ID,
                        Precio_Unidad = articuloEnLista.Precio_Venta,
                        Nombre = articuloEnLista.Nombre
                    };
                    AgregarPedidoAlDataGridView(newProduct);
                }
                else
                {
                    MessageBox.Show("El artículo seleccionado no se encuentra en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un artículo para agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AgregarPedidoAlDataGridView(Pedido pedido)
        {
            // Verificar si el artículo ya existe en la lista de pedidos del cliente
            bool articuloExistente = _pedidosCliente.Any(p => p.IdArticulo == pedido.IdArticulo);

            if (!articuloExistente)
            {
                // Agregar el nuevo pedido a la lista de pedidos del cliente
                _pedidosCliente.Add(pedido);

                // Actualizar el DataGridView
                DgvPedidos.AutoGenerateColumns = true;
                DgvPedidos.DataSource = null;
                DgvPedidos.DataSource = _pedidosCliente;

                // Formatear el DataGridView
                FormatArticlesDataGridView();
            }
            else
            {
                MessageBox.Show("El artículo ya ha sido agregado al pedido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DgvPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataGridViewSelectedRowCollection filasSeleccionadas = DgvPedidos.SelectedRows;

                if (filasSeleccionadas.Count > 0)
                {
                    foreach (DataGridViewRow fila in filasSeleccionadas)
                    {
                        if (fila.Index >= 0 && fila.Index < _pedidosCliente.Count)
                        {
                            _pedidosCliente.RemoveAt(fila.Index); // Elimina el pedido de la lista
                        }
                    }
                    // Actualiza el DataGridView
                    DgvPedidos.DataSource = null;
                    DgvPedidos.DataSource = _pedidosCliente;
                    FormatArticlesDataGridView();
                }
            }
        }
        
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un DataTable
                DataTable dataTable = new DataTable();

                // Agregar las columnas al DataTable
                dataTable.Columns.Add("FechaPedido", typeof(DateTime));
                dataTable.Columns.Add("IdCliente", typeof(string));
                dataTable.Columns.Add("IdArticulo", typeof(int));
                dataTable.Columns.Add("IdPedido", typeof(int));
                dataTable.Columns.Add("Precio_Unidad", typeof(decimal));
                dataTable.Columns.Add("Nombre", typeof(string));

                // Llenar el DataTable con los datos de la lista de pedidos
                foreach (Pedido pedido in _pedidosCliente)
                {
                    dataTable.Rows.Add(pedido.FechaPedido, pedido.IdCliente, 
                        pedido.IdArticulo, pedido.IdPedido, 
                        pedido.Precio_Unidad, pedido.Nombre);
                }

                // Convertir el DataTable a formato JSON
                string mensaje = JsonConvert.SerializeObject(dataTable);

                mensaje = "ClientePedidos:" + mensaje;

                // Enviar el mensaje al servidor
                client.WriteLineAndGetReply(mensaje, TimeSpan.FromSeconds(2));

                MessageBox.Show("Guardado Exitoso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
