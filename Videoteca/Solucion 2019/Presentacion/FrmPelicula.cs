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
    public partial class FrmPelicula : Form
    {
        public FrmPelicula()
        {
            InitializeComponent();
        }

        private void FrmPelicula_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarCategoria();
            DtpLanzamiento.Format = DateTimePickerFormat.Custom;
            DtpLanzamiento.CustomFormat = "yyyy";

        }
        private void CargarCategoria()
        {
            try
            {
                CboCategoria.DataSource = new CategoriaPeliculaBL().ObtenerCategorias();
                CboCategoria.ValueMember = "Id";
                CboCategoria.DisplayMember = "Nombre";
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
                var result = new PeliculaBL().ObtenerPeliculasConDetalle();
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

            //Titulo
            DgvListado.Columns[1].Width = 50;
            DgvListado.Columns[1].Visible = false;

            //Titulo                    
            DgvListado.Columns[2].Width = 130;

            //IdCategoria            
            DgvListado.Columns[3].Width = 50;
            DgvListado.Columns[3].Visible = false;

            //Categoria       
            DgvListado.Columns[4].Width = 130;
            DgvListado.Columns[4].HeaderText = "Categoría";

            //Lanzamiento       
            DgvListado.Columns[5].Width = 70;
            DgvListado.Columns[5].HeaderText = "Lanzamiento";
        }
        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtId.Clear();

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
                if (CboCategoria.Text == string.Empty || TxtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(CboCategoria, "Seleccione un encargado.");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");
                }
                else
                {
                    Pelicula pelicula = new Pelicula
                    {
                        Categoria = (CategoriaPelicula)CboCategoria.SelectedItem,
                        Titulo = TxtNombre.Text.Trim(),
                        AnoLanzamiento = DtpLanzamiento.Value.Year,
                        Idioma = CboIdioma.SelectedItem.ToString(),
                        Estado = true
                    };

                    Rpta = new PeliculaBL().AgregarPelicula(pelicula);

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
