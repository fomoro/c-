using SimpleTCP;
using System;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Server_Con_Objetos
{
    public partial class FrmServidor : Form
    {
        private Data data; 
        private SimpleTcpServer server;

        public FrmServidor()
        {
            InitializeComponent();
        }

        private void FrmServidor_Load(object sender, EventArgs e)
        {
            data = new Data();
            DgvClientes.AutoGenerateColumns = true;
            DgvClientes.DataSource = data.Clientes;

            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DelimiterDataReceived += Server_DataReceived;
            server.ClientConnected += Server_ClientConnected; // Se suscribe al evento de conexión de cliente
        }

        private void Server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
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
                string mensaje = e.MessageString.Trim();
                string[] partes = mensaje.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                if (partes.Length < 2) // Se valida la longitud del mensaje
                {
                    e.ReplyLine("Mensaje incompleto");
                    return;
                }

                Cliente cliente;
                try
                {
                    cliente = Newtonsoft.Json.JsonConvert.DeserializeObject<Cliente>(partes[0]);
                }
                catch (Exception ex)
                {
                    e.ReplyLine("Error al deserializar el cliente: " + ex.Message);
                    return;
                }

                if (data.ClienteExiste(cliente))
                {
                    TxtStatus.AppendText($"Cliente: {cliente.Nombre} {cliente.Apellido}, ID: {cliente.Id}, Fecha de nacimiento: {cliente.FechaNacimiento}" + Environment.NewLine);
                    TxtStatus.AppendText($"Mensaje: {partes[1]}" + Environment.NewLine);
                    e.ReplyLine($"Mensaje recibido de {cliente.Nombre} {cliente.Apellido}");
                }
                else
                {
                    e.ReplyLine("Cliente no existe");
                }
            });
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            // Se elimina la asignación a TxtStatus.Text

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
