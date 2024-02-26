using Resorts_UNED.Negocio;
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
    public partial class frmRol : Form
    {
        public frmRol()
        {
            InitializeComponent();
        }
        private void Listar()
        {

            try
            {
                dgListado.DataSource = NRol.Listar();
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
        private void Formato()
        {            
            dgListado.Columns[0].Width = 100;
            dgListado.Columns[0].HeaderText = "ID";
            dgListado.Columns[1].Width = 100;
            dgListado.Columns[1].HeaderText = "Nombre";
        }
        private void frmRol_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
