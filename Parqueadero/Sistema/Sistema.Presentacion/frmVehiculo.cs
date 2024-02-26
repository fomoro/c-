using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class frmVehiculo : Form
    {
        private string PlacaAnt;

        public frmVehiculo()
        {
            InitializeComponent();
        }

        #region Metodos
        private void Listar()
        {

            try
            {
                dgListado.DataSource = NVehiculo.Listar();
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
            dgListado.Columns[2].Visible = false;
            dgListado.Columns[3].Width = 100;
            //dgListado.Columns[3].HeaderText = "Tipo De Vehiculo";
            dgListado.Columns[4].Width = 100;
            dgListado.Columns[6].HeaderText = "Descripción";
        }
        private void Limpiar()
        {
            try
            {
                txtBuscar.Clear();
                txtId.Clear();
                txtPlaca.Clear();
                txtDescripcion.Clear();
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
        private void Buscar()
        {

            try
            {
                dgListado.DataSource = NVehiculo.Buscar(txtBuscar.Text);
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
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Parqueadero", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Parqueadero", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CargarTiposVehiculo()
        {
            try
            {
                cboTipoVehiculo.DataSource = NTipoVehiculo.Seleccionar();
                cboTipoVehiculo.ValueMember = "Id";
                cboTipoVehiculo.DisplayMember = "Tipo";
            }
            catch (Exception ex)
            {
                //informacion de la pila de llamadas antes de la excepcion
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Eventos
        private void frmVehiculo_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarTiposVehiculo();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (cboTipoVehiculo.Text == string.Empty ||
                    txtPlaca.Text == string.Empty)
                {
                    this.MensajeError("falta ingresar datos");
                    errorIcono.SetError(cboTipoVehiculo, "Ingrese un Tipo");
                    errorIcono.SetError(txtPlaca, "Ingrese una placa");
                }
                else
                {
                    Rpta = NVehiculo.Insertar(Convert.ToInt32(cboTipoVehiculo.SelectedValue), txtPlaca.Text.Trim(), txtDescripcion.Text.Trim());
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
        private void dgListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ID desde sp listar
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = dgListado.CurrentRow.Cells["ID"].Value.ToString();

                txtPlaca.Text = dgListado.CurrentRow.Cells["Placa"].Value.ToString();
                this.PlacaAnt = dgListado.CurrentRow.Cells["Placa"].Value.ToString();

                txtDescripcion.Text = dgListado.CurrentRow.Cells["Descripcion"].Value.ToString();
                tapGeneral.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione desde la celda Placa | Error: " + ex.Message);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtPlaca.Text == string.Empty || txtId.Text == string.Empty || cboTipoVehiculo.Text == string.Empty)
                {
                    this.MensajeError("falta ingresar datos");
                    errorIcono.SetError(txtPlaca, "Ingrese una Placa");
                    errorIcono.SetError(cboTipoVehiculo, "Ingrese un Tipo");
                }
                else
                {
                    Rpta = NVehiculo.Actualizar(
                        Convert.ToInt32(txtId.Text.Trim()),
                        Convert.ToInt32(cboTipoVehiculo.SelectedValue),
                        txtPlaca.Text.Trim(),
                        this.PlacaAnt,
                        txtDescripcion.Text.Trim());
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
        private void dgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = //igual a la celda seleccionada
                    (DataGridViewCheckBoxCell)dgListado.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
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
            else
            {
                dgListado.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;
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
                            Rpta = NVehiculo.Eliminar(Codigo);
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Elimino El Registro " + row.Cells[4].Value.ToString());
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
                            Rpta = NVehiculo.Desactivar(Codigo);
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
                            Rpta = NVehiculo.Activar(Codigo);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tapGeneral.SelectedIndex = 0;
        }
        #endregion

    }
}
