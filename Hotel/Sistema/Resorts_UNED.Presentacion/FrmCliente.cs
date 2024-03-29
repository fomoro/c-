using Resorts_UNED.Entidades;
using Resorts_UNED.Negocio;
using System;
using System.Windows.Forms;

namespace Resorts_UNED.Presentacion
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }
        private void Listar()
        {
            try
            {
                DgvListado.DataSource = new NCliente().Listar();
                this.Formato();
                this.Limpiar();
                LblTotal.Text = "Total Registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Buscar()
        {
            try
            {
                DgvListado.DataSource = new NCliente().Buscar(TxtBuscar.Text);
                this.Formato();
                LblTotal.Text = "Total Registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato()
        {
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[0].Width = 70;
            DgvListado.Columns[1].Visible = false;
            DgvListado.Columns[2].Width = 120;
            DgvListado.Columns[3].Width = 120;
            DgvListado.Columns[4].Width = 120;
            DgvListado.Columns[5].Width = 80;
            DgvListado.Columns[6].Width = 50;
        }

        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtId.Clear();
            TxtPrimerApellido.Clear();
            TxtSegundoApellido.Clear();
            DtpFechaNacimiento.Value = DateTime.Today;
            CboGenero.SelectedIndex = 0;

            BtnInsertar.Visible = true;
            BtnActualizar.Visible = false;
            ErrorIcono.Clear();

            DgvListado.Columns[0].Visible = false;            
            BtnEliminar.Visible = false;
            ChkSeleccionar.Checked = false;
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de RESORTS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de RESORTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtNombre.Text == string.Empty || TxtPrimerApellido.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(TxtPrimerApellido, "Ingrese un Apellido.");
                }
                else
                {

                    Cliente cliente = new Cliente();
                    cliente.Identificacion = TxtId.Text.Trim();
                    cliente.Nombre = TxtNombre.Text.Trim();
                    cliente.PrimerApellido = TxtPrimerApellido.Text.Trim();
                    cliente.SegundoApellido = TxtSegundoApellido.Text.Trim();
                    cliente.FechaNacimiento = DtpFechaNacimiento.Value;
                    cliente.Genero = Convert.ToChar(CboGenero.SelectedItem.ToString());

                    // Insertar cliente utilizando la lógica de negocio
                    Rpta = new NCliente().Insertar(cliente);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó de forma correcta el registro");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }
    }
}
