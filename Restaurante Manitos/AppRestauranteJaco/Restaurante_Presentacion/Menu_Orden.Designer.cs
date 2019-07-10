namespace Restaurante_Presentacion
{
    partial class Menu_Orden
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Orden));
            this.panelCompleto = new System.Windows.Forms.Panel();
            this.btnComandar = new System.Windows.Forms.Button();
            this.panelConsumido = new System.Windows.Forms.Panel();
            this.btnCerrarPanel = new System.Windows.Forms.Button();
            this.gbConsumido = new System.Windows.Forms.GroupBox();
            this.lblTotalCompra = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.dgvConsumoActual = new System.Windows.Forms.DataGridView();
            this.SubFamiliaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblConsumido = new System.Windows.Forms.Label();
            this.lblTimerLabel = new System.Windows.Forms.Label();
            this.panelGuarniciones = new System.Windows.Forms.Panel();
            this.cmbTerminos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCerrarGuarnicion = new System.Windows.Forms.Button();
            this.btnSeleccionaGuarniciones = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelGuarnicionesMostrar = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_VerOrden = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbPrueba = new System.Windows.Forms.GroupBox();
            this.panelprueba = new System.Windows.Forms.Panel();
            this.panelFamilias = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelObservaciones = new System.Windows.Forms.Panel();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSeleccionaObservaciones = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tls_Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsNombreRest = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsWebHtml = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelCompleto.SuspendLayout();
            this.panelConsumido.SuspendLayout();
            this.gbConsumido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumoActual)).BeginInit();
            this.panelGuarniciones.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPrueba.SuspendLayout();
            this.panelObservaciones.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCompleto
            // 
            this.panelCompleto.Controls.Add(this.btnComandar);
            this.panelCompleto.Controls.Add(this.panelConsumido);
            this.panelCompleto.Controls.Add(this.lblTimerLabel);
            this.panelCompleto.Controls.Add(this.panelGuarniciones);
            this.panelCompleto.Controls.Add(this.btn_VerOrden);
            this.panelCompleto.Controls.Add(this.label5);
            this.panelCompleto.Controls.Add(this.btnRegresar);
            this.panelCompleto.Controls.Add(this.groupBox1);
            this.panelCompleto.Controls.Add(this.lblTitulo);
            this.panelCompleto.Location = new System.Drawing.Point(25, 1);
            this.panelCompleto.Name = "panelCompleto";
            this.panelCompleto.Size = new System.Drawing.Size(1052, 535);
            this.panelCompleto.TabIndex = 21;
            // 
            // btnComandar
            // 
            this.btnComandar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComandar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComandar.Location = new System.Drawing.Point(652, 8);
            this.btnComandar.Name = "btnComandar";
            this.btnComandar.Size = new System.Drawing.Size(136, 46);
            this.btnComandar.TabIndex = 30;
            this.btnComandar.Text = "COMANDAR";
            this.btnComandar.UseVisualStyleBackColor = true;
            this.btnComandar.Click += new System.EventHandler(this.btnComandar_Click);
            // 
            // panelConsumido
            // 
            this.panelConsumido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConsumido.Controls.Add(this.btnCerrarPanel);
            this.panelConsumido.Controls.Add(this.gbConsumido);
            this.panelConsumido.Controls.Add(this.lblConsumido);
            this.panelConsumido.Location = new System.Drawing.Point(0, 3);
            this.panelConsumido.Name = "panelConsumido";
            this.panelConsumido.Size = new System.Drawing.Size(1012, 435);
            this.panelConsumido.TabIndex = 23;
            this.panelConsumido.Visible = false;
            // 
            // btnCerrarPanel
            // 
            this.btnCerrarPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarPanel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarPanel.Location = new System.Drawing.Point(774, 9);
            this.btnCerrarPanel.Name = "btnCerrarPanel";
            this.btnCerrarPanel.Size = new System.Drawing.Size(81, 42);
            this.btnCerrarPanel.TabIndex = 21;
            this.btnCerrarPanel.Text = "CERRAR";
            this.btnCerrarPanel.UseVisualStyleBackColor = true;
            this.btnCerrarPanel.Click += new System.EventHandler(this.btnCerrarPanel_Click);
            // 
            // gbConsumido
            // 
            this.gbConsumido.Controls.Add(this.lblTotalCompra);
            this.gbConsumido.Controls.Add(this.btnFacturar);
            this.gbConsumido.Controls.Add(this.dgvConsumoActual);
            this.gbConsumido.Controls.Add(this.label6);
            this.gbConsumido.Controls.Add(this.lblMesa);
            this.gbConsumido.Controls.Add(this.lblHora);
            this.gbConsumido.Controls.Add(this.lblFecha);
            this.gbConsumido.Location = new System.Drawing.Point(188, 67);
            this.gbConsumido.Name = "gbConsumido";
            this.gbConsumido.Size = new System.Drawing.Size(648, 367);
            this.gbConsumido.TabIndex = 10;
            this.gbConsumido.TabStop = false;
            this.gbConsumido.Text = "Consumido";
            // 
            // lblTotalCompra
            // 
            this.lblTotalCompra.AutoSize = true;
            this.lblTotalCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalCompra.Location = new System.Drawing.Point(346, 333);
            this.lblTotalCompra.Name = "lblTotalCompra";
            this.lblTotalCompra.Size = new System.Drawing.Size(49, 21);
            this.lblTotalCompra.TabIndex = 14;
            this.lblTotalCompra.Text = "Total:";
            this.lblTotalCompra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.Location = new System.Drawing.Point(508, 318);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(134, 36);
            this.btnFacturar.TabIndex = 13;
            this.btnFacturar.Text = "FACTURAR";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
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
            this.SubFamiliaId,
            this.Cantidad,
            this.Descripcion,
            this.Detalle,
            this.Precio,
            this.Eliminar});
            this.dgvConsumoActual.Location = new System.Drawing.Point(6, 65);
            this.dgvConsumoActual.Name = "dgvConsumoActual";
            this.dgvConsumoActual.ReadOnly = true;
            this.dgvConsumoActual.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvConsumoActual.RowTemplate.Height = 30;
            this.dgvConsumoActual.Size = new System.Drawing.Size(636, 244);
            this.dgvConsumoActual.TabIndex = 12;
            this.dgvConsumoActual.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsumoActual_CellContentClick);
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
            this.Descripcion.FillWeight = 45.45454F;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Detalle
            // 
            this.Detalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Detalle.DataPropertyName = "Detalle";
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Precio.DataPropertyName = "Precio";
            this.Precio.FillWeight = 154.5455F;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 73;
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
            this.Eliminar.Width = 130;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(12, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(630, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------";
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblMesa.Location = new System.Drawing.Point(569, 21);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(53, 21);
            this.lblMesa.TabIndex = 6;
            this.lblMesa.Text = "Mesa:";
            this.lblMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblHora.Location = new System.Drawing.Point(263, 21);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(50, 21);
            this.lblHora.TabIndex = 4;
            this.lblHora.Text = "Hora:";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblFecha.Location = new System.Drawing.Point(12, 21);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(56, 21);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConsumido
            // 
            this.lblConsumido.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblConsumido.Location = new System.Drawing.Point(353, 8);
            this.lblConsumido.Name = "lblConsumido";
            this.lblConsumido.Size = new System.Drawing.Size(353, 39);
            this.lblConsumido.TabIndex = 7;
            this.lblConsumido.Text = "Orden-Consumido ";
            this.lblConsumido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimerLabel
            // 
            this.lblTimerLabel.AutoSize = true;
            this.lblTimerLabel.Font = new System.Drawing.Font("Bodoni MT Condensed", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTimerLabel.ForeColor = System.Drawing.Color.Maroon;
            this.lblTimerLabel.Location = new System.Drawing.Point(163, 21);
            this.lblTimerLabel.Name = "lblTimerLabel";
            this.lblTimerLabel.Size = new System.Drawing.Size(68, 26);
            this.lblTimerLabel.TabIndex = 29;
            this.lblTimerLabel.Text = "00:00:00";
            this.lblTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelGuarniciones
            // 
            this.panelGuarniciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGuarniciones.Controls.Add(this.cmbTerminos);
            this.panelGuarniciones.Controls.Add(this.label2);
            this.panelGuarniciones.Controls.Add(this.btnCerrarGuarnicion);
            this.panelGuarniciones.Controls.Add(this.btnSeleccionaGuarniciones);
            this.panelGuarniciones.Controls.Add(this.label1);
            this.panelGuarniciones.Controls.Add(this.panelGuarnicionesMostrar);
            this.panelGuarniciones.Controls.Add(this.label8);
            this.panelGuarniciones.Location = new System.Drawing.Point(5, 556);
            this.panelGuarniciones.Name = "panelGuarniciones";
            this.panelGuarniciones.Size = new System.Drawing.Size(664, 439);
            this.panelGuarniciones.TabIndex = 24;
            this.panelGuarniciones.Visible = false;
            // 
            // cmbTerminos
            // 
            this.cmbTerminos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerminos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTerminos.FormattingEnabled = true;
            this.cmbTerminos.Items.AddRange(new object[] {
            "NO TERMINO",
            "ROJO",
            "MEDIO ROJO",
            "MEDIO",
            "TRES CUARTOS ¾",
            "BIEN COCIDO"});
            this.cmbTerminos.Location = new System.Drawing.Point(249, 60);
            this.cmbTerminos.Name = "cmbTerminos";
            this.cmbTerminos.Size = new System.Drawing.Size(197, 24);
            this.cmbTerminos.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(122, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "Termino:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrarGuarnicion
            // 
            this.btnCerrarGuarnicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarGuarnicion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCerrarGuarnicion.Location = new System.Drawing.Point(431, 11);
            this.btnCerrarGuarnicion.Name = "btnCerrarGuarnicion";
            this.btnCerrarGuarnicion.Size = new System.Drawing.Size(87, 42);
            this.btnCerrarGuarnicion.TabIndex = 22;
            this.btnCerrarGuarnicion.Text = "CERRAR";
            this.btnCerrarGuarnicion.UseVisualStyleBackColor = true;
            this.btnCerrarGuarnicion.Click += new System.EventHandler(this.btnCerrarGuarnicion_Click);
            // 
            // btnSeleccionaGuarniciones
            // 
            this.btnSeleccionaGuarniciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionaGuarniciones.Location = new System.Drawing.Point(258, 438);
            this.btnSeleccionaGuarniciones.Name = "btnSeleccionaGuarniciones";
            this.btnSeleccionaGuarniciones.Size = new System.Drawing.Size(134, 36);
            this.btnSeleccionaGuarniciones.TabIndex = 14;
            this.btnSeleccionaGuarniciones.Text = "SELECCIONAR";
            this.btnSeleccionaGuarniciones.UseVisualStyleBackColor = true;
            this.btnSeleccionaGuarniciones.Click += new System.EventHandler(this.btnSeleccionaGuarniciones_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(123, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Seleccione 2 guarniciones para acompañar:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelGuarnicionesMostrar
            // 
            this.panelGuarnicionesMostrar.AutoScroll = true;
            this.panelGuarnicionesMostrar.Location = new System.Drawing.Point(127, 111);
            this.panelGuarnicionesMostrar.Name = "panelGuarnicionesMostrar";
            this.panelGuarnicionesMostrar.Size = new System.Drawing.Size(394, 321);
            this.panelGuarnicionesMostrar.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(226, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 39);
            this.label8.TabIndex = 7;
            this.label8.Text = "GUARNICIONES ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_VerOrden
            // 
            this.btn_VerOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_VerOrden.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VerOrden.Location = new System.Drawing.Point(794, 8);
            this.btn_VerOrden.Name = "btn_VerOrden";
            this.btn_VerOrden.Size = new System.Drawing.Size(116, 46);
            this.btn_VerOrden.TabIndex = 26;
            this.btn_VerOrden.Text = "VER ORDEN";
            this.btn_VerOrden.UseVisualStyleBackColor = true;
            this.btn_VerOrden.Click += new System.EventHandler(this.btn_VerOrden_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 23);
            this.label5.TabIndex = 25;
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
            this.btnRegresar.TabIndex = 24;
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbPrueba);
            this.groupBox1.Controls.Add(this.panelFamilias);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1096, 437);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menú";
            // 
            // gbPrueba
            // 
            this.gbPrueba.Controls.Add(this.panelprueba);
            this.gbPrueba.Location = new System.Drawing.Point(158, 19);
            this.gbPrueba.Name = "gbPrueba";
            this.gbPrueba.Size = new System.Drawing.Size(841, 407);
            this.gbPrueba.TabIndex = 24;
            this.gbPrueba.TabStop = false;
            this.gbPrueba.Text = "Menú";
            // 
            // panelprueba
            // 
            this.panelprueba.AutoScroll = true;
            this.panelprueba.Location = new System.Drawing.Point(4, 13);
            this.panelprueba.Name = "panelprueba";
            this.panelprueba.Size = new System.Drawing.Size(831, 388);
            this.panelprueba.TabIndex = 3;
            // 
            // panelFamilias
            // 
            this.panelFamilias.AutoScroll = true;
            this.panelFamilias.Location = new System.Drawing.Point(7, 19);
            this.panelFamilias.Name = "panelFamilias";
            this.panelFamilias.Size = new System.Drawing.Size(145, 414);
            this.panelFamilias.TabIndex = 10;
            this.panelFamilias.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFamilias_Paint);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(278, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(353, 39);
            this.lblTitulo.TabIndex = 21;
            this.lblTitulo.Text = "Atendiendo a la mesa: ";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelObservaciones
            // 
            this.panelObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelObservaciones.Controls.Add(this.txtObservaciones);
            this.panelObservaciones.Controls.Add(this.label4);
            this.panelObservaciones.Controls.Add(this.button1);
            this.panelObservaciones.Controls.Add(this.btnSeleccionaObservaciones);
            this.panelObservaciones.Controls.Add(this.label10);
            this.panelObservaciones.Location = new System.Drawing.Point(391, 569);
            this.panelObservaciones.Name = "panelObservaciones";
            this.panelObservaciones.Size = new System.Drawing.Size(664, 232);
            this.panelObservaciones.TabIndex = 27;
            this.panelObservaciones.Visible = false;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtObservaciones.Location = new System.Drawing.Point(290, 60);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(237, 66);
            this.txtObservaciones.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(163, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 25;
            this.label4.Text = "Observaciones:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(409, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 42);
            this.button1.TabIndex = 22;
            this.button1.Text = "CERRAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnSeleccionaObservaciones
            // 
            this.btnSeleccionaObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionaObservaciones.Location = new System.Drawing.Point(284, 151);
            this.btnSeleccionaObservaciones.Name = "btnSeleccionaObservaciones";
            this.btnSeleccionaObservaciones.Size = new System.Drawing.Size(134, 36);
            this.btnSeleccionaObservaciones.TabIndex = 14;
            this.btnSeleccionaObservaciones.Text = "SELECCIONAR";
            this.btnSeleccionaObservaciones.UseVisualStyleBackColor = true;
            this.btnSeleccionaObservaciones.Click += new System.EventHandler(this.btnSeleccionaObservaciones_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(204, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 39);
            this.label10.TabIndex = 7;
            this.label10.Text = "OBSERVACIONES";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tls_Usuario,
            this.tlsNombreRest,
            this.tlsWebHtml,
            this.tlsFecha,
            this.tlsHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 638);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1148, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 35;
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Menu_Orden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1148, 662);
            this.Controls.Add(this.panelObservaciones);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelCompleto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Menu_Orden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_Orden_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Orden_Load);
            this.Resize += new System.EventHandler(this.Menu_Orden_Resize);
            this.panelCompleto.ResumeLayout(false);
            this.panelCompleto.PerformLayout();
            this.panelConsumido.ResumeLayout(false);
            this.gbConsumido.ResumeLayout(false);
            this.gbConsumido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumoActual)).EndInit();
            this.panelGuarniciones.ResumeLayout(false);
            this.panelGuarniciones.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gbPrueba.ResumeLayout(false);
            this.panelObservaciones.ResumeLayout(false);
            this.panelObservaciones.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCompleto;
        private System.Windows.Forms.Button btn_VerOrden;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tls_Usuario;
        private System.Windows.Forms.ToolStripStatusLabel tlsNombreRest;
        private System.Windows.Forms.ToolStripStatusLabel tlsWebHtml;
        private System.Windows.Forms.ToolStripStatusLabel tlsFecha;
        private System.Windows.Forms.ToolStripStatusLabel tlsHora;
        private System.Windows.Forms.Panel panelFamilias;
        private System.Windows.Forms.GroupBox gbPrueba;
        private System.Windows.Forms.Panel panelprueba;
        private System.Windows.Forms.Panel panelConsumido;
        private System.Windows.Forms.Button btnCerrarPanel;
        private System.Windows.Forms.GroupBox gbConsumido;
        private System.Windows.Forms.Label lblTotalCompra;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.DataGridView dgvConsumoActual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblConsumido;
        private System.Windows.Forms.Panel panelGuarniciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelGuarnicionesMostrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeleccionaGuarniciones;
        private System.Windows.Forms.Button btnCerrarGuarnicion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTerminos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTimerLabel;
        private System.Windows.Forms.Button btnComandar;
        private System.Windows.Forms.Panel panelObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSeleccionaObservaciones;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubFamiliaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewLinkColumn Eliminar;
    }
}