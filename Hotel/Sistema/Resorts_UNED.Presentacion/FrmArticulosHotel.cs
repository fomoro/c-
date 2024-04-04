using Resorts_UNED.Entidades;
using Resorts_UNED.Negocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace Resorts_UNED.Presentacion
{
    public partial class FrmArticulosHotel : Form
    {
        private DataTable DtDetalle = new DataTable();
        public FrmArticulosHotel()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtTelefono.Clear();
            TxtDireccion.Clear();
            DtDetalle.Clear();
            DgvListado.Columns[0].Visible = false;                        
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Listar()
        {
            try
            {
                DgvListado.DataSource = new NCompra().Listar();
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
                DgvListado.DataSource = new NCompra().Buscar(TxtBuscar.Text);
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
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[0].Width = 70;
            DgvListado.Columns[1].Visible = false;
            DgvListado.Columns[2].Width = 150;
            DgvListado.Columns[3].Width = 200;
            DgvListado.Columns[3].HeaderText = "Dirección";
            DgvListado.Columns[4].Width = 60;
            DgvListado.Columns[5].Width = 100;
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
        


        private void CrearTabla()
        {
            this.DtDetalle.Columns.Add("Id", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("Categoria", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("Nombre", System.Type.GetType("System.String"));            
            this.DtDetalle.Columns.Add("Precio Unidad", System.Type.GetType("System.Decimal"));            

            DgvDetalle.DataSource = this.DtDetalle;            

            DgvDetalle.Columns[0].Visible = false;
            DgvDetalle.Columns[1].HeaderText = "Categoria";
            DgvDetalle.Columns[1].Width = 100;
            DgvDetalle.Columns[2].HeaderText = "Articulo";
            DgvDetalle.Columns[2].Width = 150;            
            DgvDetalle.Columns[3].HeaderText = "Precio Unidad";
            DgvDetalle.Columns[3].Width = 100;

            DgvDetalle.Columns[1].ReadOnly = true;
            DgvDetalle.Columns[2].ReadOnly = true;
            DgvDetalle.Columns[3].ReadOnly = true;
        }
        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["IdHotel"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtDireccion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Direccion"].Value);
                TxtTelefono.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Telefono"].Value);
                TabGeneral.SelectedIndex = 1;

                DgvDetalle.DataSource = new NArticulo().ObtenerPorHotel(TxtId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione desde la celda nombre." + "| Error: " + ex.Message);
            }
        }


        private void FormatoArticulos()
        {
            DgvArticulos.Columns[0].Visible = false;
            DgvArticulos.Columns[1].HeaderText = "Categoria";
            DgvArticulos.Columns[1].Width = 100;
            DgvArticulos.Columns[2].HeaderText = "Articulo";
            DgvArticulos.Columns[2].Width = 150;
            DgvArticulos.Columns[3].HeaderText = "Precio Unidad";
            DgvArticulos.Columns[3].Width = 100;
        }
        private void BtnVerArticulos_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = true;            
            try
            {
                var result = new NArticulo().ObtenerConCategoria();
                DgvArticulos.DataSource = result;
                this.FormatoArticulos();                
                LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void DgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdArticulo;
            string Categoria, Articulo;
            decimal Precio;
            IdArticulo = Convert.ToInt32(DgvArticulos.CurrentRow.Cells["ID"].Value);
            Categoria = Convert.ToString(DgvArticulos.CurrentRow.Cells["Categoria"].Value);
            Articulo = Convert.ToString(DgvArticulos.CurrentRow.Cells["Nombre"].Value);
            Precio = Convert.ToDecimal(DgvArticulos.CurrentRow.Cells["Precio Unidad"].Value);
            this.AgregarDetalle(IdArticulo, Categoria, Articulo, Precio);
        }
        private void AgregarDetalle(int IdArticulo, string Categoria, string Articulo, decimal Precio)
        {
            DataTable existingData = (DataTable)DgvDetalle.DataSource;
            
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
                DgvDetalle.DataSource = existingData;
            }
            else
            {
                MessageBox.Show("El ID ya existe en los datos existentes.");
            }
        }
        
        private void FrmArticulosHotel_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CrearTabla();
        }
        
        
        private void BtnCerrarArticulos_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = false;
        }        
        private void BtnFiltrarArticulos_Click(object sender, EventArgs e)
        {            
            try
            {
                DgvArticulos.DataSource = new NArticulo().BuscarConCategoria(TxtBuscarArticulo.Text);
                this.FormatoArticulos();
                LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        
        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            //haga una transaccion que borre todo lo que tiene en DgvDetalle.DataSource;
            //y luego tome todo lo que tiene aca DgvDetalle.DataSource y lo agrege 
            try
            {
                string Rpta = "";
                /*if (TxtIdProveedor.Text == string.Empty || TxtImpuesto.Text == string.Empty || TxtNumComprobante.Text == string.Empty || DtDetalle.Rows.Count == 0)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(TxtIdProveedor, "Seleccione un proveedor.");
                    ErrorIcono.SetError(TxtImpuesto, "Ingrese un impuesto.");
                    ErrorIcono.SetError(TxtNumComprobante, "Ingrese el número del comprobante.");
                    ErrorIcono.SetError(DgvDetalle, "Debe tener al menos un detalle.");
                }
                else
                {
                    Rpta = NIngreso.Insertar(Convert.ToInt32(TxtIdProveedor.Text), Variables.IdUsuario, CboComprobante.Text, TxtSerieComprobante.Text.Trim(), TxtNumComprobante.Text.Trim(), Convert.ToDecimal(TxtImpuesto.Text), Convert.ToDecimal(TxtTotal.Text), DtDetalle);
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
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void DgvDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void DgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRow Fila = (DataRow)DtDetalle.Rows[e.RowIndex];
            decimal Precio = Convert.ToDecimal(Fila["precio"]);
            int Cantidad = Convert.ToInt32(Fila["cantidad"]);
            Fila["importe"] = Precio * Cantidad;            
        }
        

        /*
        
        
        
    
    
        private void BtnCerrarDetalle_Click(object sender, EventArgs e)
        {
            PanelMostrar.Visible = false;
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }
        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccionar.Checked)
            {
                DgvListado.Columns[0].Visible = true;
                BtnAnular.Visible = true;
            }
            else
            {
                DgvListado.Columns[0].Visible = false;
                BtnAnular.Visible = false;
            }
        }
        private void BtnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas anular el(los) registro(s)?", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se anuló el registro: " + Convert.ToString(row.Cells[6].Value) + "-" + Convert.ToString(row.Cells[7].Value));
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }*/
    }
}
