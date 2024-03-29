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
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }
        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                BtnActualizar.Visible = true;
                BtnInsertar.Visible = false;
                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Identificacion"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtPrimerApellido.Text = Convert.ToString(DgvListado.CurrentRow.Cells["PrimerApellido"].Value);
                TxtSegundoApellido.Text = Convert.ToString(DgvListado.CurrentRow.Cells["SegundoApellido"].Value);
                DtpFechaNacimiento.Value = Convert.ToDateTime(DgvListado.CurrentRow.Cells["FechaNacimiento"].Value);                
                CboGenero.SelectedItem = DgvListado.CurrentRow.Cells["Genero"].Value.ToString();
                TabGeneral.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione desde la celda nombre." + "| Error: " + ex.Message);
            }
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtId.Text == string.Empty || TxtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");                    
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");
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
                    Rpta = new NCliente().Actualizar(cliente);
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizó de forma correcta el registro");
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
                BtnEliminar.Visible = true;
            }
            else
            {
                DgvListado.Columns[0].Visible = false;
                BtnEliminar.Visible = false;
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas eliminar el(los) registro(s)?", "Sistema Resorts UNED", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";                    

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = row.Cells[1].Value.ToString();
                            Rpta = new NCliente().Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó el registro: " + Convert.ToString(row.Cells[5].Value));
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
        }

    }
}
