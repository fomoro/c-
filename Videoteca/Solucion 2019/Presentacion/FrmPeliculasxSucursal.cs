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
    public partial class FrmPeliculasxSucursal : Form
    {
        public FrmPeliculasxSucursal()
        {
            InitializeComponent();
        }

        private void FrmPeliculasxSucursal_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.ListarPeliculas();
            this.CargarSucursales();
        }

        private void CargarSucursales()
        {
            try
            {
                CboSucursal.DataSource = new SucursalBL().ObtenerSucursales();
                CboSucursal.ValueMember = "Id";
                CboSucursal.DisplayMember = "Nombre";
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
                var result = new PeliculaxSucursalBL().ObtenerPeliculasxSucursalDetalle();
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
        private void ListarPeliculas()
        {
            try
            {
                var result = new PeliculaBL().ObtenerPeliculas();
                DgvListadoPeliculas.DataSource = result;
                //this.FormatoListadoPeliculas();
                //this.Limpiar();
                //LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
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
                DgvListado.DataSource = new PeliculaBL().BuscarPeliculasPorTitulo(TxtBuscar.Text);
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
            //IdArticulo
            //DgvListado.Columns[0].Visible = false;  
            //DgvListado.Columns[0].Width = 100;

            //IdPelicula
            DgvListado.Columns[1].Width = 50;
            DgvListado.Columns[1].Visible = false;

            //IdSucursal
            DgvListado.Columns[3].Width = 50;
            DgvListado.Columns[3].Visible = false;

            //Titulo                    
            //DgvListado.Columns[2].Width = 130;

            //IdCategoria            
            //DgvListado.Columns[3].Width = 50;
            //DgvListado.Columns[3].Visible = false;

            //Categoria       
            //DgvListado.Columns[4].Width = 130;
            //DgvListado.Columns[4].HeaderText = "Categoría";

            //Lanzamiento       
            //DgvListado.Columns[5].Width = 70;
            //DgvListado.Columns[5].HeaderText = "Lanzamiento";
        }
        private void Limpiar()
        {
            TxtBuscar.Clear();
            BtnInsertar.Visible = true;
            BtnActualizar.Visible = false;
            ErrorIcono.Clear();
         
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
    }
}
