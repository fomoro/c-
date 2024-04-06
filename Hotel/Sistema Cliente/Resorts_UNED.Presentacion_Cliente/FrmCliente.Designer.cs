
namespace Resorts_UNED.Presentacion_Cliente
{
    partial class FrmCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.CboArticulos = new System.Windows.Forms.ComboBox();
            this.BtnDesconectar = new System.Windows.Forms.Button();
            this.DgvPedidos = new System.Windows.Forms.DataGridView();
            this.TxtIdCliente = new System.Windows.Forms.TextBox();
            this.LblIdCliente = new System.Windows.Forms.Label();
            this.LblClave = new System.Windows.Forms.Label();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.TxtStatus = new System.Windows.Forms.TextBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.LblPort = new System.Windows.Forms.Label();
            this.LblHost = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(704, 79);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(105, 24);
            this.BtnAgregar.TabIndex = 86;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // CboArticulos
            // 
            this.CboArticulos.FormattingEnabled = true;
            this.CboArticulos.Location = new System.Drawing.Point(505, 79);
            this.CboArticulos.Name = "CboArticulos";
            this.CboArticulos.Size = new System.Drawing.Size(179, 24);
            this.CboArticulos.TabIndex = 85;
            // 
            // BtnDesconectar
            // 
            this.BtnDesconectar.Location = new System.Drawing.Point(678, 28);
            this.BtnDesconectar.Name = "BtnDesconectar";
            this.BtnDesconectar.Size = new System.Drawing.Size(131, 31);
            this.BtnDesconectar.TabIndex = 84;
            this.BtnDesconectar.Text = "Desconectar";
            this.BtnDesconectar.UseVisualStyleBackColor = true;
            this.BtnDesconectar.Click += new System.EventHandler(this.BtnDesconectar_Click);
            // 
            // DgvPedidos
            // 
            this.DgvPedidos.AllowUserToAddRows = false;
            this.DgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPedidos.Location = new System.Drawing.Point(33, 129);
            this.DgvPedidos.Name = "DgvPedidos";
            this.DgvPedidos.ReadOnly = true;
            this.DgvPedidos.RowHeadersWidth = 51;
            this.DgvPedidos.RowTemplate.Height = 24;
            this.DgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPedidos.Size = new System.Drawing.Size(1039, 242);
            this.DgvPedidos.TabIndex = 83;
            this.DgvPedidos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvPedidos_KeyDown);
            // 
            // TxtIdCliente
            // 
            this.TxtIdCliente.Location = new System.Drawing.Point(80, 76);
            this.TxtIdCliente.Name = "TxtIdCliente";
            this.TxtIdCliente.Size = new System.Drawing.Size(152, 22);
            this.TxtIdCliente.TabIndex = 82;
            // 
            // LblIdCliente
            // 
            this.LblIdCliente.AutoSize = true;
            this.LblIdCliente.Location = new System.Drawing.Point(30, 78);
            this.LblIdCliente.Name = "LblIdCliente";
            this.LblIdCliente.Size = new System.Drawing.Size(19, 17);
            this.LblIdCliente.TabIndex = 81;
            this.LblIdCliente.Text = "Id";
            // 
            // LblClave
            // 
            this.LblClave.AutoSize = true;
            this.LblClave.Location = new System.Drawing.Point(255, 79);
            this.LblClave.Name = "LblClave";
            this.LblClave.Size = new System.Drawing.Size(43, 17);
            this.LblClave.TabIndex = 80;
            this.LblClave.Text = "Clave";
            // 
            // TxtClave
            // 
            this.TxtClave.Location = new System.Drawing.Point(308, 77);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.Size = new System.Drawing.Size(152, 22);
            this.TxtClave.TabIndex = 79;
            // 
            // TxtStatus
            // 
            this.TxtStatus.Location = new System.Drawing.Point(33, 427);
            this.TxtStatus.Multiline = true;
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtStatus.Size = new System.Drawing.Size(1039, 157);
            this.TxtStatus.TabIndex = 78;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(515, 29);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(133, 30);
            this.BtnConnect.TabIndex = 77;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(308, 32);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(152, 22);
            this.TxtPort.TabIndex = 76;
            this.TxtPort.Text = "8910";
            // 
            // TxtHost
            // 
            this.TxtHost.Location = new System.Drawing.Point(80, 32);
            this.TxtHost.Name = "TxtHost";
            this.TxtHost.Size = new System.Drawing.Size(152, 22);
            this.TxtHost.TabIndex = 75;
            this.TxtHost.Text = "127.0.0.1";
            // 
            // LblPort
            // 
            this.LblPort.AutoSize = true;
            this.LblPort.Location = new System.Drawing.Point(255, 34);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(34, 17);
            this.LblPort.TabIndex = 74;
            this.LblPort.Text = "Port";
            // 
            // LblHost
            // 
            this.LblHost.AutoSize = true;
            this.LblHost.Location = new System.Drawing.Point(30, 34);
            this.LblHost.Name = "LblHost";
            this.LblHost.Size = new System.Drawing.Size(37, 17);
            this.LblHost.TabIndex = 73;
            this.LblHost.Text = "Host";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(643, 382);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(166, 39);
            this.BtnGuardar.TabIndex = 87;
            this.BtnGuardar.Text = "Guardar Pedido";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 653);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.CboArticulos);
            this.Controls.Add(this.BtnDesconectar);
            this.Controls.Add(this.DgvPedidos);
            this.Controls.Add(this.TxtIdCliente);
            this.Controls.Add(this.LblIdCliente);
            this.Controls.Add(this.LblClave);
            this.Controls.Add(this.TxtClave);
            this.Controls.Add(this.TxtStatus);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.TxtPort);
            this.Controls.Add(this.TxtHost);
            this.Controls.Add(this.LblPort);
            this.Controls.Add(this.LblHost);
            this.Name = "FrmCliente";
            this.Text = "FrmCliente";
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.ComboBox CboArticulos;
        private System.Windows.Forms.Button BtnDesconectar;
        private System.Windows.Forms.DataGridView DgvPedidos;
        private System.Windows.Forms.TextBox TxtIdCliente;
        private System.Windows.Forms.Label LblIdCliente;
        private System.Windows.Forms.Label LblClave;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.TextBox TxtStatus;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.TextBox TxtHost;
        private System.Windows.Forms.Label LblPort;
        private System.Windows.Forms.Label LblHost;
        private System.Windows.Forms.Button BtnGuardar;
    }
}