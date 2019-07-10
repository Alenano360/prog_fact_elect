namespace Restaurante_Presentacion
{
    partial class Facturar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facturar));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tls_Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsNombreRest = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsWebHtml = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelCompleto = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMontoPagar = new System.Windows.Forms.Label();
            this.PanelFacturar = new System.Windows.Forms.Panel();
            this.dgvConsumoActual = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.gbFactura = new System.Windows.Forms.GroupBox();
            this.lblTotalXPagar = new System.Windows.Forms.Label();
            this.btnCompleto = new System.Windows.Forms.Button();
            this.PanelConsumido = new System.Windows.Forms.Panel();
            this.dgvPagarMostrar = new System.Windows.Forms.DataGridView();
            this.SubFamiliaIdMostrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadMostrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionMostrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioMostrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagarMostrar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvConsumoActualXPagar = new System.Windows.Forms.DataGridView();
            this.SubFamiliaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pagar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.panelCompleto.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PanelFacturar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumoActual)).BeginInit();
            this.gbFactura.SuspendLayout();
            this.PanelConsumido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagarMostrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumoActualXPagar)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tls_Usuario,
            this.tlsNombreRest,
            this.tlsWebHtml,
            this.tlsFecha,
            this.tlsHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(934, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tls_Usuario
            // 
            this.tls_Usuario.AutoSize = false;
            this.tls_Usuario.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tls_Usuario.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tls_Usuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tls_Usuario.Name = "tls_Usuario";
            this.tls_Usuario.Size = new System.Drawing.Size(200, 19);
            this.tls_Usuario.Text = "Usuario:";
            this.tls_Usuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlsNombreRest
            // 
            this.tlsNombreRest.AutoSize = false;
            this.tlsNombreRest.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlsNombreRest.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tlsNombreRest.Name = "tlsNombreRest";
            this.tlsNombreRest.Size = new System.Drawing.Size(350, 19);
            this.tlsNombreRest.Text = "Nombre del restaurante";
            // 
            // tlsWebHtml
            // 
            this.tlsWebHtml.AutoSize = false;
            this.tlsWebHtml.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlsWebHtml.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tlsWebHtml.Name = "tlsWebHtml";
            this.tlsWebHtml.Size = new System.Drawing.Size(270, 19);
            this.tlsWebHtml.Text = "DireccionWeb";
            // 
            // tlsFecha
            // 
            this.tlsFecha.AutoSize = false;
            this.tlsFecha.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlsFecha.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tlsFecha.Name = "tlsFecha";
            this.tlsFecha.Size = new System.Drawing.Size(100, 19);
            this.tlsFecha.Text = "Fecha";
            // 
            // tlsHora
            // 
            this.tlsHora.AutoSize = false;
            this.tlsHora.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlsHora.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tlsHora.Name = "tlsHora";
            this.tlsHora.Size = new System.Drawing.Size(80, 19);
            this.tlsHora.Text = "Hora";
            // 
            // panelCompleto
            // 
            this.panelCompleto.Controls.Add(this.groupBox1);
            this.panelCompleto.Controls.Add(this.gbFactura);
            this.panelCompleto.Controls.Add(this.label5);
            this.panelCompleto.Controls.Add(this.btnRegresar);
            this.panelCompleto.Controls.Add(this.lblTitulo);
            this.panelCompleto.Location = new System.Drawing.Point(12, 0);
            this.panelCompleto.Name = "panelCompleto";
            this.panelCompleto.Size = new System.Drawing.Size(922, 485);
            this.panelCompleto.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMontoPagar);
            this.groupBox1.Controls.Add(this.PanelFacturar);
            this.groupBox1.Controls.Add(this.lblTotalPagar);
            this.groupBox1.Controls.Add(this.btnFacturar);
            this.groupBox1.Location = new System.Drawing.Point(457, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 418);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Factura";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblMontoPagar
            // 
            this.lblMontoPagar.AutoSize = true;
            this.lblMontoPagar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblMontoPagar.Location = new System.Drawing.Point(223, 382);
            this.lblMontoPagar.Name = "lblMontoPagar";
            this.lblMontoPagar.Size = new System.Drawing.Size(0, 21);
            this.lblMontoPagar.TabIndex = 19;
            this.lblMontoPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelFacturar
            // 
            this.PanelFacturar.Controls.Add(this.dgvConsumoActual);
            this.PanelFacturar.Location = new System.Drawing.Point(6, 19);
            this.PanelFacturar.Name = "PanelFacturar";
            this.PanelFacturar.Size = new System.Drawing.Size(451, 351);
            this.PanelFacturar.TabIndex = 18;
            // 
            // dgvConsumoActual
            // 
            this.dgvConsumoActual.AllowUserToAddRows = false;
            this.dgvConsumoActual.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsumoActual.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsumoActual.ColumnHeadersHeight = 30;
            this.dgvConsumoActual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.PrecioFactura,
            this.Eliminar});
            this.dgvConsumoActual.Location = new System.Drawing.Point(3, 4);
            this.dgvConsumoActual.Name = "dgvConsumoActual";
            this.dgvConsumoActual.ReadOnly = true;
            this.dgvConsumoActual.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvConsumoActual.RowTemplate.Height = 30;
            this.dgvConsumoActual.Size = new System.Drawing.Size(443, 330);
            this.dgvConsumoActual.TabIndex = 16;
            this.dgvConsumoActual.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsumoActual_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodigoArticulo";
            this.dataGridViewTextBoxColumn1.HeaderText = "CodigoArticulo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Cantidad";
            this.dataGridViewTextBoxColumn2.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // PrecioFactura
            // 
            this.PrecioFactura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PrecioFactura.DataPropertyName = "Precio";
            this.PrecioFactura.HeaderText = "Precio";
            this.PrecioFactura.Name = "PrecioFactura";
            this.PrecioFactura.ReadOnly = true;
            this.PrecioFactura.Width = 73;
            // 
            // Eliminar
            // 
            this.Eliminar.DataPropertyName = "Eliminar";
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.LinkColor = System.Drawing.Color.Blue;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.Width = 75;
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalPagar.Location = new System.Drawing.Point(166, 382);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(49, 21);
            this.lblTotalPagar.TabIndex = 17;
            this.lblTotalPagar.Text = "Total:";
            this.lblTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.Location = new System.Drawing.Point(323, 376);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(134, 36);
            this.btnFacturar.TabIndex = 15;
            this.btnFacturar.Text = "FACTURAR";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // gbFactura
            // 
            this.gbFactura.Controls.Add(this.lblTotalXPagar);
            this.gbFactura.Controls.Add(this.btnCompleto);
            this.gbFactura.Controls.Add(this.PanelConsumido);
            this.gbFactura.Location = new System.Drawing.Point(12, 67);
            this.gbFactura.Name = "gbFactura";
            this.gbFactura.Size = new System.Drawing.Size(434, 418);
            this.gbFactura.TabIndex = 20;
            this.gbFactura.TabStop = false;
            this.gbFactura.Text = "Consumido";
            // 
            // lblTotalXPagar
            // 
            this.lblTotalXPagar.AutoSize = true;
            this.lblTotalXPagar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalXPagar.Location = new System.Drawing.Point(133, 382);
            this.lblTotalXPagar.Name = "lblTotalXPagar";
            this.lblTotalXPagar.Size = new System.Drawing.Size(49, 21);
            this.lblTotalXPagar.TabIndex = 17;
            this.lblTotalXPagar.Text = "Total:";
            this.lblTotalXPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCompleto
            // 
            this.btnCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleto.Location = new System.Drawing.Point(290, 376);
            this.btnCompleto.Name = "btnCompleto";
            this.btnCompleto.Size = new System.Drawing.Size(134, 36);
            this.btnCompleto.TabIndex = 16;
            this.btnCompleto.Text = "COMPLETO";
            this.btnCompleto.UseVisualStyleBackColor = true;
            this.btnCompleto.Click += new System.EventHandler(this.btnCompleto_Click);
            // 
            // PanelConsumido
            // 
            this.PanelConsumido.Controls.Add(this.dgvPagarMostrar);
            this.PanelConsumido.Controls.Add(this.dgvConsumoActualXPagar);
            this.PanelConsumido.Location = new System.Drawing.Point(6, 19);
            this.PanelConsumido.Name = "PanelConsumido";
            this.PanelConsumido.Size = new System.Drawing.Size(418, 351);
            this.PanelConsumido.TabIndex = 19;
            // 
            // dgvPagarMostrar
            // 
            this.dgvPagarMostrar.AllowUserToAddRows = false;
            this.dgvPagarMostrar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPagarMostrar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPagarMostrar.ColumnHeadersHeight = 30;
            this.dgvPagarMostrar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubFamiliaIdMostrar,
            this.CantidadMostrar,
            this.DescripcionMostrar,
            this.PrecioMostrar,
            this.PagarMostrar});
            this.dgvPagarMostrar.Location = new System.Drawing.Point(7, 3);
            this.dgvPagarMostrar.Name = "dgvPagarMostrar";
            this.dgvPagarMostrar.ReadOnly = true;
            this.dgvPagarMostrar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPagarMostrar.RowTemplate.Height = 30;
            this.dgvPagarMostrar.Size = new System.Drawing.Size(404, 331);
            this.dgvPagarMostrar.TabIndex = 18;
            this.dgvPagarMostrar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagarMostrar_CellContentClick);
            // 
            // SubFamiliaIdMostrar
            // 
            this.SubFamiliaIdMostrar.DataPropertyName = "CodigoArticulo";
            this.SubFamiliaIdMostrar.HeaderText = "CodigoArticulo";
            this.SubFamiliaIdMostrar.Name = "SubFamiliaIdMostrar";
            this.SubFamiliaIdMostrar.ReadOnly = true;
            this.SubFamiliaIdMostrar.Visible = false;
            // 
            // CantidadMostrar
            // 
            this.CantidadMostrar.DataPropertyName = "Cantidad";
            this.CantidadMostrar.HeaderText = "Cantidad";
            this.CantidadMostrar.Name = "CantidadMostrar";
            this.CantidadMostrar.ReadOnly = true;
            this.CantidadMostrar.Width = 70;
            // 
            // DescripcionMostrar
            // 
            this.DescripcionMostrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DescripcionMostrar.DataPropertyName = "Descripcion";
            this.DescripcionMostrar.HeaderText = "Descripcion";
            this.DescripcionMostrar.Name = "DescripcionMostrar";
            this.DescripcionMostrar.ReadOnly = true;
            // 
            // PrecioMostrar
            // 
            this.PrecioMostrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PrecioMostrar.DataPropertyName = "Precio";
            this.PrecioMostrar.HeaderText = "Precio";
            this.PrecioMostrar.Name = "PrecioMostrar";
            this.PrecioMostrar.ReadOnly = true;
            this.PrecioMostrar.Width = 73;
            // 
            // PagarMostrar
            // 
            this.PagarMostrar.DataPropertyName = "Pagar";
            this.PagarMostrar.HeaderText = "Pagar";
            this.PagarMostrar.LinkColor = System.Drawing.Color.Blue;
            this.PagarMostrar.Name = "PagarMostrar";
            this.PagarMostrar.ReadOnly = true;
            this.PagarMostrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PagarMostrar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PagarMostrar.Text = "Pagar";
            this.PagarMostrar.Width = 75;
            // 
            // dgvConsumoActualXPagar
            // 
            this.dgvConsumoActualXPagar.AllowUserToAddRows = false;
            this.dgvConsumoActualXPagar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsumoActualXPagar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConsumoActualXPagar.ColumnHeadersHeight = 30;
            this.dgvConsumoActualXPagar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubFamiliaId,
            this.Cantidad,
            this.Descripcion,
            this.Precio,
            this.Pagar});
            this.dgvConsumoActualXPagar.Location = new System.Drawing.Point(7, 3);
            this.dgvConsumoActualXPagar.Name = "dgvConsumoActualXPagar";
            this.dgvConsumoActualXPagar.ReadOnly = true;
            this.dgvConsumoActualXPagar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvConsumoActualXPagar.RowTemplate.Height = 30;
            this.dgvConsumoActualXPagar.Size = new System.Drawing.Size(404, 331);
            this.dgvConsumoActualXPagar.TabIndex = 12;
            this.dgvConsumoActualXPagar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsumoActualXPagar_CellContentClick);
            // 
            // SubFamiliaId
            // 
            this.SubFamiliaId.DataPropertyName = "CodigoArticulo";
            this.SubFamiliaId.HeaderText = "CodigoArticulo";
            this.SubFamiliaId.Name = "SubFamiliaId";
            this.SubFamiliaId.ReadOnly = true;
            this.SubFamiliaId.Visible = false;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 70;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 70;
            // 
            // Pagar
            // 
            this.Pagar.DataPropertyName = "Pagar";
            this.Pagar.HeaderText = "Pagar";
            this.Pagar.LinkColor = System.Drawing.Color.Blue;
            this.Pagar.Name = "Pagar";
            this.Pagar.ReadOnly = true;
            this.Pagar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Pagar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Pagar.Text = "Pagar";
            this.Pagar.Width = 75;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "Regresar";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Transparent;
            this.btnRegresar.BackgroundImage = global::Restaurante_Presentacion.Properties.Resources.Regresar2;
            this.btnRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Location = new System.Drawing.Point(12, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(50, 50);
            this.btnRegresar.TabIndex = 18;
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(288, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(320, 39);
            this.lblTitulo.TabIndex = 17;
            this.lblTitulo.Text = "Atendiendo a la mesa: ";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 512);
            this.Controls.Add(this.panelCompleto);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Facturar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Facturar_Load);
            this.Resize += new System.EventHandler(this.Facturar_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelCompleto.ResumeLayout(false);
            this.panelCompleto.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PanelFacturar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumoActual)).EndInit();
            this.gbFactura.ResumeLayout(false);
            this.gbFactura.PerformLayout();
            this.PanelConsumido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagarMostrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumoActualXPagar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tls_Usuario;
        private System.Windows.Forms.ToolStripStatusLabel tlsNombreRest;
        private System.Windows.Forms.ToolStripStatusLabel tlsWebHtml;
        private System.Windows.Forms.ToolStripStatusLabel tlsFecha;
        private System.Windows.Forms.ToolStripStatusLabel tlsHora;
        private System.Windows.Forms.Panel panelCompleto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel PanelFacturar;
        private System.Windows.Forms.DataGridView dgvConsumoActual;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.GroupBox gbFactura;
        private System.Windows.Forms.Button btnCompleto;
        private System.Windows.Forms.Panel PanelConsumido;
        private System.Windows.Forms.DataGridView dgvConsumoActualXPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubFamiliaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewLinkColumn Pagar;
        private System.Windows.Forms.Label lblTotalXPagar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioFactura;
        private System.Windows.Forms.DataGridViewLinkColumn Eliminar;
        private System.Windows.Forms.Label lblMontoPagar;
        private System.Windows.Forms.DataGridView dgvPagarMostrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubFamiliaIdMostrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadMostrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionMostrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioMostrar;
        private System.Windows.Forms.DataGridViewLinkColumn PagarMostrar;
    }
}