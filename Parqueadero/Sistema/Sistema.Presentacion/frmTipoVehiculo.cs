using System;
using System.Windows.Forms;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class frmTipoVehiculo : Form
    {
        private string TipoAnt;
        public frmTipoVehiculo()
        {
            InitializeComponent();
        }

        #region Metodos
        private void Listar()
        {

            try
            {
                dgListado.DataSource = NTipoVehiculo.Listar();
                this.Formato();
                this.Limpiar();
                lblTotal.Text = "Total Registros: " + dgListado.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                //informacion de la pila de llamadas antes de la excepcion
                MessageBox.Show(ex.Message + ex.StackTrace);
                throw;
            }
        }
        private void Formato()
        {
            dgListado.Columns[0].Visible = false;
            dgListado.Columns[1].Visible = false;
            dgListado.Columns[2].Width = 100;
            dgListado.Columns[5].Width = 100;
            dgListado.Columns[3].HeaderText = "Descripción";
        }
        private void Buscar()
        {

            try
            {
                dgListado.DataSource = NTipoVehiculo.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotal.Text = "Total Registros: " + dgListado.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                //informacion de la pila de llamadas antes de la excepcion
                MessageBox.Show(ex.Message + ex.StackTrace);
                throw;
            }
        }
        private void Limpiar()
        {
            try
            {
                txtBuscar.Clear();
                txtId.Clear();
                txtTipo.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
                btnInsertar.Visible = true;
                btnActualizar.Visible = false;
                errorIcono.Clear();

                dgListado.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;
                chkSelecionar.Checked = false;
            }
            catch (Exception ex)
            {
                //informacion de la pila de llamadas antes de la excepcion
                MessageBox.Show(ex.Message + ex.StackTrace);
                throw;
            }
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Parqueadero", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Parqueadero", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region eventos 
        private void frmTipoVehiculo_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtTipo.Text == string.Empty)
                {
                    this.MensajeError("falta ingresar datos");
                    errorIcono.SetError(txtTipo, "Ingrese un Tipo");
                }
                else
                {
                    Rpta = NTipoVehiculo.Insertar(txtTipo.Text.Trim(),
                        txtDescripcion.Text.Trim(), decimal.Parse(txtPrecio.Text.Trim()));
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto correctamente el Registro");
                        this.Limpiar();
                        this.Listar();
                        tapGeneral.SelectedIndex = 0;
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                //informacion de la pila de llamadas antes de la excepcion
                MessageBox.Show(ex.Message + ex.StackTrace);
                throw;
            }
        }      
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tapGeneral.SelectedIndex = 0;
        }
        private void dgListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ID desde sp listar
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = dgListado.CurrentRow.Cells["ID"].Value.ToString();
                this.TipoAnt = dgListado.CurrentRow.Cells["Tipo"].Value.ToString();
                txtTipo.Text = dgListado.CurrentRow.Cells["Tipo"].Value.ToString();
                txtDescripcion.Text = dgListado.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dgListado.CurrentRow.Cells["Precio"].Value.ToString();
                tapGeneral.SelectedIndex = 1;
            }
            catch (Exception)
            {                
                MessageBox.Show("Seleccione desde la celda tipo");               
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtTipo.Text == string.Empty || txtId.Text == string.Empty)
                {
                    this.MensajeError("falta ingresar datos");
                    errorIcono.SetError(txtTipo, "Ingrese un Tipo");
                }
                else
                {
                    Rpta = NTipoVehiculo.Actualizar(
                        Convert.ToInt32(txtId.Text.Trim()),
                        this.TipoAnt,
                        txtTipo.Text.Trim(),
                        txtDescripcion.Text.Trim(),
                        decimal.Parse(txtPrecio.Text.Trim()));
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Actualizo correctamente el Registro");
                        this.Limpiar();
                        this.Listar();
                        tapGeneral.SelectedIndex = 0;
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                //informacion de la pila de llamadas antes de la excepcion
                MessageBox.Show(ex.Message + ex.StackTrace);
                throw;
            }
        }
        private void chkSelecionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelecionar.Checked)
            {
                dgListado.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;
            }
            else {
                dgListado.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;
            }
        }
        private void dgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = //igual a la celda seleccionada
                    (DataGridViewCheckBoxCell)dgListado.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Option;
                Option = MessageBox.Show("Realmente si deseas eliminar el(los) registro(s)", "Parqueadero", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Option == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dgListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NTipoVehiculo.Eliminar(Codigo);
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Elimino El Registro" + row.Cells[2].Value.ToString());
                            }
                            else {
                                this.MensajeError(Rpta);
                            }
                        } 
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                //informacion de la pila de llamadas antes de la excepcion
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Option;
                Option = MessageBox.Show("Realmente si deseas Activar el(los) registro(s)", "Parqueadero", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Option == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dgListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NTipoVehiculo.Activar(Codigo);
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Activo El Registro" + row.Cells[2].Value.ToString());
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
                //informacion de la pila de llamadas antes de la excepcion
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Option;
                Option = MessageBox.Show("Realmente si deseas Desactivar el(los) registro(s)", "Parqueadero", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Option == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dgListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NTipoVehiculo.Desactivar(Codigo);
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Desactivo El Registro" + row.Cells[2].Value.ToString());
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
                //informacion de la pila de llamadas antes de la excepcion
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

    }
}
