using Resorts_UNED.Entidades;
using Resorts_UNED.Negocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace Resorts_UNED.Presentacion
{
    public partial class FrmArticulosHotel : Form
    {
        private DataTable DtDetalleCurrent = new DataTable();
        public FrmArticulosHotel()
        {
            InitializeComponent();
            DtDetalleCurrent.Clear();
        }
        
        private void ClearFields()
        {
            TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtTelefono.Clear();
            TxtDireccion.Clear();
            DtDetalleCurrent.Clear();
            DgvListado.Columns[0].Visible = false;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Sistema Hoteles Resorts", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Sistema Hoteles Resorts", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ListHotels()
        {
            try
            {
                DgvListado.DataSource = new NHotel().Listar();
                FormatDataGridView();
                ClearFields();
                UpdateTotalLabel();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message + ex.StackTrace);
            }
        }
        private void UpdateTotalLabel()
        {
            LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
        }
        private void FormatDataGridView()
        {
            // Ocultar la primera columna
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[1].Visible = false;

            // Establecer el ancho de las columnas
            DgvListado.Columns[2].Width = 150; // Nombre
            DgvListado.Columns[3].Width = 200; // Dirección
            DgvListado.Columns[4].Width = 60;  // Teléfono
            DgvListado.Columns[5].Width = 100; // OtraColumna

            // Establecer el encabezado de la columna Dirección
            DgvListado.Columns[3].HeaderText = "Dirección";
        }
        private void SearchHotels(string searchText)
        {
            try
            {
                DgvListado.DataSource = new NHotel().Buscar(searchText);
                FormatDataGridView();
                UpdateTotalLabel();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message + ex.StackTrace);
            }
        }
        private void LoadHotelDetails()
        {
            try
            {
                ClearFields();
                TxtIdHotel.Text = Convert.ToString(DgvListado.CurrentRow.Cells["IdHotel"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtDireccion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Direccion"].Value);
                TxtTelefono.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Telefono"].Value);
                TabGeneral.SelectedIndex = 1;                
                DgvArticuloHotel.DataSource = new NArticulo().ObtenerPorHotel(TxtIdHotel.Text);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Seleccione desde la celda nombre." + "| Error: " + ex.Message);
            }
        }
        private void FormatArticlesDataGridView()
        {
            // Ocultar la primera columna
            DgvArticulos.Columns[0].Visible = false;

            // Establecer el encabezado y ancho de las columnas
            DgvArticulos.Columns[1].HeaderText = "Categoria";
            DgvArticulos.Columns[1].Width = 100;
            DgvArticulos.Columns[2].HeaderText = "Articulo";
            DgvArticulos.Columns[2].Width = 150;
            DgvArticulos.Columns[3].HeaderText = "Precio Unidad";
            DgvArticulos.Columns[3].Width = 100;
        }
        private void ShowArticlesPanel()
        {
            PanelArticulos.Visible = true;
            try
            {
                var result = new NArticulo().ObtenerConCategoria();
                DgvArticulos.DataSource = result;
                FormatArticlesDataGridView();
                UpdateTotalLabel();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message + ex.StackTrace);
            }
        }
        private void LoadArticleDetails()
        {
            try
            {
                int IdArticulo;
                string Categoria, Articulo;
                decimal Precio;

                // Obtener los detalles del artículo seleccionado en el DataGridView
                IdArticulo = Convert.ToInt32(DgvArticulos.CurrentRow.Cells["ID"].Value);
                Categoria = Convert.ToString(DgvArticulos.CurrentRow.Cells["Categoria"].Value);
                Articulo = Convert.ToString(DgvArticulos.CurrentRow.Cells["Nombre"].Value);
                Precio = Convert.ToDecimal(DgvArticulos.CurrentRow.Cells["Precio Unidad"].Value);

                // Llamar al método para agregar el detalle al DataTable
                AddDetail(IdArticulo, Categoria, Articulo, Precio);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error al cargar los detalles del artículo: " + ex.Message);
            }
        }
        private void AddDetail(int IdArticulo, string Categoria, string Articulo, decimal Precio)
        {
            try
            {
                DataTable existingData = (DataTable)DgvArticuloHotel.DataSource;

                bool idExists = false;
                foreach (DataRow row in existingData.Rows)
                {
                    if (row["Id"].ToString() == IdArticulo.ToString())
                    {
                        idExists = true;
                        break;
                    }
                }

                if (!idExists)
                {
                    DataRow newRow = existingData.NewRow();
                    newRow["Id"] = IdArticulo;
                    newRow["Categoria"] = Categoria;
                    newRow["Nombre"] = Articulo;
                    newRow["Precio Unidad"] = Precio;

                    existingData.Rows.Add(newRow);
                    DgvArticuloHotel.DataSource = existingData;
                }
                else
                {
                    MessageBox.Show("El ID ya existe en los datos existentes.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error al agregar detalle: " + ex.Message);
            }
        }
        private void FilterArticles(string searchText)
        {
            try
            {
                DgvArticulos.DataSource = new NArticulo().BuscarConCategoria(searchText);
                FormatArticlesDataGridView();
                UpdateTotalLabel();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message + ex.StackTrace);
            }
        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            SearchHotels(TxtBuscar.Text);
        }               
        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadHotelDetails();
        }       
        private void BtnVerArticulos_Click(object sender, EventArgs e)
        {
            ShowArticlesPanel();
        }
        private void DgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    LoadArticleDetails();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error al cargar los detalles del artículo: " + ex.Message);
            }
        }                
        private void FrmArticulosHotel_Load(object sender, EventArgs e)
        {
            ListHotels();
        }
        
        
        private void BtnCerrarArticulos_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = false;
        }        
        private void BtnFiltrarArticulos_Click(object sender, EventArgs e)
        {
            FilterArticles(TxtBuscarArticulo.Text);
        }


        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable existingData = (DataTable)DgvArticuloHotel.DataSource;
                DtDetalleCurrent = new NArticulo().ObtenerPorHotel(TxtIdHotel.Text);
                new NArticuloHotel().ActualizarDetalle(DtDetalleCurrent, existingData, Int32.Parse(TxtIdHotel.Text));
                ShowSuccessMessage("Guardado Exitoso");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}
