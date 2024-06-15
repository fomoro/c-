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
    public partial class FrmSucursal : Form
    {
        public FrmSucursal()
        {
            InitializeComponent();
        }

        private void FrmSucursal_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarEncargado();
        }
        private void CargarEncargado()
        {
            try
            {
                CboEncargado.DataSource = new EncargadoBL().ObtenerEncargados();
                CboEncargado.ValueMember = "Id";
                CboEncargado.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Listar()
        {
            try
            {
                //var result = new SucursalBL().ObtenerSucursales();
                var result = new SucursalBL().ObtenerSucursalesConDetalle();
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
                DgvListado.DataSource = new SucursalBL().BuscarSucursalPorNombre(TxtBuscar.Text);
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
            DgvListado.Columns[0].Visible = false;

            //Id
            DgvListado.Columns[1].Width = 30;
            //DgvListado.Columns[1].Visible = false;

            //Identificacion            
            //DgvListado.Columns[2].Width = 100;

            //Nombre                                            
            //DgvListado.Columns[3].Width = 100;

            //Direccion                 
            //DgvListado.Columns[4].Width = 100;

            //Telefono                                  
            //DgvListado.Columns[5].Width = 100;
            //DgvListado.Columns[4].HeaderText = "Categoría";

            //IdEncargado
            //DgvListado.Columns[6].Width = 100;

            //NombreEncargado       
            //DgvListado.Columns[7].Width = 100;

            //Activo       
            //DgvListado.Columns[8].Width = 100;
        }
        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtId.Clear();
            TxtDireccion.Clear();
            TxtTelefono.Clear();

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
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }
        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (CboEncargado.Text == string.Empty || TxtNombre.Text == string.Empty || TxtDireccion.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(CboEncargado, "Seleccione un encargado.");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(TxtDireccion, "Ingrese una dirección.");
                }
                else
                {
                    Sucursal sucursal = new Sucursal
                    {
                        Encargado = (Encargado)CboEncargado.SelectedItem,
                        Nombre = TxtNombre.Text.Trim(),
                        Direccion = TxtDireccion.Text.Trim(),
                        Telefono = TxtTelefono.Text.Trim(),
                        Activo = true
                    };

                    Rpta = new SucursalBL().AgregarSucursal(sucursal);

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

    }
}
