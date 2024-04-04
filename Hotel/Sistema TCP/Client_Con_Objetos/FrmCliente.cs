using SimpleTCP;
using System;
using System.Text;
using System.Windows.Forms;
using System.Net; // Añadido para la validación de la dirección IP

namespace Client_Con_Objetos
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private SimpleTcpClient client;
        private bool isConnected = false; // Bandera para rastrear el estado de la conexión

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DelimiterDataReceived += Client_DataReceived;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (!isConnected) // Prevenir intentos de conexión redundantes
            {
                try
                {
                    // Validar el formato de la dirección IP
                    if (!IPAddress.TryParse(TxtHost.Text, out IPAddress ip))
                    {
                        MessageBox.Show("Formato de dirección IP no válido. Introduzca una dirección IP válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validar el número de puerto (dentro del rango válido)
                    int port = Convert.ToInt32(TxtPort.Text);
                    if (port < 0 || port > 65535)
                    {
                        MessageBox.Show("Número de puerto no válido. Introduzca un número de puerto válido (0-65535).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Cliente cliente = new Cliente
                    {
                        Id = TxtIdCliente.Text,
                        Nombre = TxtNombreCliente.Text,
                        Apellido = TxtApellidoCliente.Text,
                        FechaNacimiento = DateTime.Now
                    };

                    string mensaje = Newtonsoft.Json.JsonConvert.SerializeObject(cliente);
                    client.Connect(TxtHost.Text, port);
                    client.WriteLineAndGetReply(mensaje, TimeSpan.FromSeconds(2));

                    isConnected = true; // Actualizar el estado de la conexión
                    BtnConnect.Enabled = false;
                    BtnSend.Enabled = true;
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

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                Cliente cliente = new Cliente
                {
                    Id = TxtIdCliente.Text,
                    Nombre = TxtNombreCliente.Text,
                    Apellido = TxtApellidoCliente.Text,
                    FechaNacimiento = DateTime.Now
                };

                string mensaje = Newtonsoft.Json.JsonConvert.SerializeObject(cliente) + Environment.NewLine + TxtMessage.Text;
                client.WriteLineAndGetReply(mensaje, TimeSpan.FromSeconds(2));
            }
            else
            {
                MessageBox.Show("Cliente no conectado al servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            TxtStatus.Invoke((MethodInvoker)delegate ()
            {
                string mensaje = e.MessageString.Trim();
                TxtStatus.AppendText("Mensaje recibido del servidor: " + mensaje + Environment.NewLine);
            });
        }
    }
}
