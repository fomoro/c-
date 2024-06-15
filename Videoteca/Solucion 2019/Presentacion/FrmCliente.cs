using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.Listar();
            //this.CargarCategoria();
        }

        private void Listar()
        {
            try
            {
                var result = new ClienteBL().ObtenerClientes();
                DgvListado.DataSource = result;
                this.Formato();
                this.Limpiar();
                LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
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
                DgvListado.DataSource = new ClienteBL().BuscarClientePorNombre(TxtBuscar.Text);
                this.Formato();
                LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            DgvListado.Columns[0].Width = 50;
            //DgvListado.Columns[0].Visible = false;

            //Id
            DgvListado.Columns[1].Width = 30;
            //DgvListado.Columns[1].Visible = false;

            //Identificacion            
            DgvListado.Columns[2].Width = 100;

            //Nombre                                            
            DgvListado.Columns[3].Width = 100;

            //PrimerApellido                 
            DgvListado.Columns[4].Width = 100;

            //SegundoApellido                                  
            DgvListado.Columns[5].Width = 100;
            //DgvListado.Columns[4].HeaderText = "Categoría";

            //FechaNacimiento
            DgvListado.Columns[6].Width = 100;
            //DgvListado.Columns[4].HeaderText = "Categoría";

            //FechaRegistro       
            DgvListado.Columns[6].Width = 100;
            //DgvListado.Columns[5].HeaderText = "Lanzamiento";
        }
        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtIdentifiacion.Clear();
            TxtNombre.Clear();
            TxtPrimerApellido.Clear();
            TxtSegundoApellido.Clear();
            
            BtnInsertar.Visible = true;
            BtnActualizar.Visible = false;
            ErrorIcono.Clear();
            //this.RutaDestino = "";
            //this.RutaOrigen = "";

            DgvListado.Columns[0].Visible = false;
            //BtnActivar.Visible = false;
            //BtnDesactivar.Visible = false;
            BtnEliminar.Visible = false;
            ChkSeleccionar.Checked = false;
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Hoteles Resorts", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Hoteles Resorts", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtNombre.Text == string.Empty || LblIdentificacion.Text == string.Empty || TxtPrimerApellido.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(LblIdentificacion, "Ingrese una identificación.");
                    ErrorIcono.SetError(TxtPrimerApellido, "Ingrese un apellido.");
                }
                else
                {
                    Cliente cliente = new Cliente
                    {
                        Identificacion = TxtIdentifiacion.Text.Trim(),
                        Nombre = TxtNombre.Text.Trim(),
                        PrimerApellido = TxtPrimerApellido.Text.Trim(),
                        SegundoApellido = TxtSegundoApellido.Text.Trim(),
                        FechaNacimiento = DtpFechaNacimiento.Value,
                        FechaRegistro = DtpFechaRegistro.Value,
                        Activo = true // 'true' por 'CheckboxActivo.Checked'
                    };

                    Rpta = new ClienteBL().AgregarCliente(cliente);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó de forma correcta el registro");
                        this.Limpiar();
                        this.Listar();
                        TabGeneral.SelectedIndex = 0;
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }
    }
}
