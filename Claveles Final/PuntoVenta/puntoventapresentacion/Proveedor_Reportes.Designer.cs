namespace PuntoVentaPresentacion
{
    partial class Proveedor_Reportes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTodosProveedores = new System.Windows.Forms.RadioButton();
            this.rbProveedor = new System.Windows.Forms.RadioButton();
            this.btnBuscaProveedor = new System.Windows.Forms.Button();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.rbEntre = new System.Windows.Forms.RadioButton();
            this.btnPreliminar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExpXLS = new System.Windows.Forms.Button();
            this.btnExpPDF = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.gbExistencias = new System.Windows.Forms.GroupBox();
            this.rbFiltro = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pdReporte = new System.Drawing.Printing.PrintDocument();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioIVU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio2IVU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreacionFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbExistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDatos);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnPreliminar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnExpXLS);
            this.panel1.Controls.Add(this.btnExpPDF);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbOrdenar);
            this.panel1.Controls.Add(this.gbExistencias);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.printPreviewControl1);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 499);
            this.panel1.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbTodosProveedores);
            this.groupBox2.Controls.Add(this.rbProveedor);
            this.groupBox2.Controls.Add(this.btnBuscaProveedor);
            this.groupBox2.Controls.Add(this.cmbProveedor);
            this.groupBox2.Location = new System.Drawing.Point(13, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(786, 69);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Por proveedor";
            this.groupBox2.Visible = false;
            // 
            // rbTodosProveedores
            // 
            this.rbTodosProveedores.AutoSize = true;
            this.rbTodosProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbTodosProveedores.Location = new System.Drawing.Point(22, 31);
            this.rbTodosProveedores.Name = "rbTodosProveedores";
            this.rbTodosProveedores.Size = new System.Drawing.Size(172, 21);
            this.rbTodosProveedores.TabIndex = 111;
            this.rbTodosProveedores.Text = "Todos los proveedores";
            this.rbTodosProveedores.UseVisualStyleBackColor = true;
            // 
            // rbProveedor
            // 
            this.rbProveedor.AutoSize = true;
            this.rbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbProveedor.Location = new System.Drawing.Point(252, 31);
            this.rbProveedor.Name = "rbProveedor";
            this.rbProveedor.Size = new System.Drawing.Size(92, 21);
            this.rbProveedor.TabIndex = 110;
            this.rbProveedor.Text = "Proveedor";
            this.rbProveedor.UseVisualStyleBackColor = true;
            // 
            // btnBuscaProveedor
            // 
            this.btnBuscaProveedor.Location = new System.Drawing.Point(554, 28);
            this.btnBuscaProveedor.Name = "btnBuscaProveedor";
            this.btnBuscaProveedor.Size = new System.Drawing.Size(29, 26);
            this.btnBuscaProveedor.TabIndex = 109;
            this.btnBuscaProveedor.Text = "...";
            this.btnBuscaProveedor.UseVisualStyleBackColor = true;
            this.btnBuscaProveedor.Click += new System.EventHandler(this.btnBuscaProveedor_Click);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.BackColor = System.Drawing.SystemColors.Window;
            this.cmbProveedor.DisplayMember = "Nombre";
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.IntegralHeight = false;
            this.cmbProveedor.ItemHeight = 18;
            this.cmbProveedor.Location = new System.Drawing.Point(350, 28);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(195, 26);
            this.cmbProveedor.TabIndex = 106;
            this.cmbProveedor.ValueMember = "Id";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.dtpFechaFinal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpFechaInicial);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbEntre);
            this.groupBox1.Location = new System.Drawing.Point(13, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 69);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Por periodo";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButton1.Location = new System.Drawing.Point(22, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(66, 21);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Todos";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFechaFinal.Location = new System.Drawing.Point(606, 31);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(168, 23);
            this.dtpFechaFinal.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(519, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 107;
            this.label5.Text = "Fecha final:";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFechaInicial.Location = new System.Drawing.Point(345, 31);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(168, 23);
            this.dtpFechaInicial.TabIndex = 106;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(249, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 105;
            this.label4.Text = "Fecha inicial:";
            // 
            // rbEntre
            // 
            this.rbEntre.AutoSize = true;
            this.rbEntre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbEntre.Location = new System.Drawing.Point(137, 31);
            this.rbEntre.Name = "rbEntre";
            this.rbEntre.Size = new System.Drawing.Size(106, 21);
            this.rbEntre.TabIndex = 0;
            this.rbEntre.Text = "Entre fechas";
            this.rbEntre.UseVisualStyleBackColor = true;
            // 
            // btnPreliminar
            // 
            this.btnPreliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnPreliminar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.PreviewIcono;
            this.btnPreliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreliminar.FlatAppearance.BorderSize = 0;
            this.btnPreliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPreliminar.Location = new System.Drawing.Point(13, 383);
            this.btnPreliminar.Name = "btnPreliminar";
            this.btnPreliminar.Size = new System.Drawing.Size(108, 100);
            this.btnPreliminar.TabIndex = 104;
            this.btnPreliminar.Text = "&A";
            this.btnPreliminar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPreliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPreliminar.UseVisualStyleBackColor = false;
            this.btnPreliminar.Click += new System.EventHandler(this.btnPreliminar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(388, 21);
            this.label3.TabIndex = 100;
            this.label3.Text = "Seleccione a que formato desea exportar el reporte";
            // 
            // btnExpXLS
            // 
            this.btnExpXLS.BackColor = System.Drawing.Color.Transparent;
            this.btnExpXLS.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.ExcelIcono;
            this.btnExpXLS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpXLS.FlatAppearance.BorderSize = 0;
            this.btnExpXLS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpXLS.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExpXLS.Location = new System.Drawing.Point(253, 383);
            this.btnExpXLS.Name = "btnExpXLS";
            this.btnExpXLS.Size = new System.Drawing.Size(120, 100);
            this.btnExpXLS.TabIndex = 99;
            this.btnExpXLS.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExpXLS.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExpXLS.UseVisualStyleBackColor = false;
            this.btnExpXLS.Click += new System.EventHandler(this.btnExpXLS_Click);
            // 
            // btnExpPDF
            // 
            this.btnExpPDF.BackColor = System.Drawing.Color.Transparent;
            this.btnExpPDF.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.PDFIcono;
            this.btnExpPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpPDF.FlatAppearance.BorderSize = 0;
            this.btnExpPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpPDF.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExpPDF.Location = new System.Drawing.Point(127, 383);
            this.btnExpPDF.Name = "btnExpPDF";
            this.btnExpPDF.Size = new System.Drawing.Size(120, 100);
            this.btnExpPDF.TabIndex = 98;
            this.btnExpPDF.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExpPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExpPDF.UseVisualStyleBackColor = false;
            this.btnExpPDF.Click += new System.EventHandler(this.btnExpPDF_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.AceptarIcono;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.Location = new System.Drawing.Point(553, 383);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 100);
            this.btnAceptar.TabIndex = 97;
            this.btnAceptar.Text = "&A";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(10, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ordenar:";
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.BackColor = System.Drawing.SystemColors.Window;
            this.cmbOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.IntegralHeight = false;
            this.cmbOrdenar.ItemHeight = 18;
            this.cmbOrdenar.Items.AddRange(new object[] {
            "--Seleccione--",
            "Nombre",
            "Contacto",
            "Inicio relaciones"});
            this.cmbOrdenar.Location = new System.Drawing.Point(127, 312);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(195, 26);
            this.cmbOrdenar.TabIndex = 4;
            // 
            // gbExistencias
            // 
            this.gbExistencias.Controls.Add(this.rbFiltro);
            this.gbExistencias.Controls.Add(this.rbTodos);
            this.gbExistencias.Location = new System.Drawing.Point(13, 84);
            this.gbExistencias.Name = "gbExistencias";
            this.gbExistencias.Size = new System.Drawing.Size(786, 69);
            this.gbExistencias.TabIndex = 94;
            this.gbExistencias.TabStop = false;
            this.gbExistencias.Text = "Fecha";
            // 
            // rbFiltro
            // 
            this.rbFiltro.AutoSize = true;
            this.rbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbFiltro.Location = new System.Drawing.Point(137, 31);
            this.rbFiltro.Name = "rbFiltro";
            this.rbFiltro.Size = new System.Drawing.Size(202, 21);
            this.rbFiltro.TabIndex = 1;
            this.rbFiltro.Text = "Relaciones en el último mes";
            this.rbFiltro.UseVisualStyleBackColor = true;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbTodos.Location = new System.Drawing.Point(22, 31);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(66, 21);
            this.rbTodos.TabIndex = 0;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 21);
            this.label1.TabIndex = 93;
            this.label1.Text = "Seleccione los elementos que desee para el reporte";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeight = 27;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Descripcion,
            this.PrecioIVU,
            this.Precio2IVU,
            this.Telefono2,
            this.CreacionFecha});
            this.dgvDatos.Location = new System.Drawing.Point(219, 427);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 30;
            this.dgvDatos.Size = new System.Drawing.Size(773, 363);
            this.dgvDatos.TabIndex = 91;
            this.dgvDatos.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(323, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 45);
            this.lblTitulo.TabIndex = 90;
            this.lblTitulo.Text = "Reportes";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(805, 15);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(187, 288);
            this.printPreviewControl1.TabIndex = 10;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.CerrarIcono;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(679, 383);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 100);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "&C";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pdReporte
            // 
            this.pdReporte.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdReporte_PrintPage);
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Contacto";
            this.Descripcion.HeaderText = "Contacto";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // PrecioIVU
            // 
            this.PrecioIVU.DataPropertyName = "Cedula";
            this.PrecioIVU.HeaderText = "Cedula";
            this.PrecioIVU.Name = "PrecioIVU";
            this.PrecioIVU.ReadOnly = true;
            // 
            // Precio2IVU
            // 
            this.Precio2IVU.DataPropertyName = "Telefono1";
            this.Precio2IVU.HeaderText = "Telefono 1";
            this.Precio2IVU.Name = "Precio2IVU";
            this.Precio2IVU.ReadOnly = true;
            // 
            // Telefono2
            // 
            this.Telefono2.DataPropertyName = "Telefono2";
            this.Telefono2.HeaderText = "Telefono 2";
            this.Telefono2.Name = "Telefono2";
            this.Telefono2.ReadOnly = true;
            // 
            // CreacionFecha
            // 
            this.CreacionFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreacionFecha.DataPropertyName = "CreacionFecha1";
            this.CreacionFecha.HeaderText = "Inicio relaciones";
            this.CreacionFecha.Name = "CreacionFecha";
            this.CreacionFecha.ReadOnly = true;
            // 
            // Proveedor_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 505);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Proveedor_Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de proveedores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Proveedor_Reportes_Load);
            this.Resize += new System.EventHandler(this.Proveedor_Reportes_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbExistencias.ResumeLayout(false);
            this.gbExistencias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPreliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExpXLS;
        private System.Windows.Forms.Button btnExpPDF;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox gbExistencias;
        private System.Windows.Forms.RadioButton rbFiltro;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbEntre;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Drawing.Printing.PrintDocument pdReporte;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Button btnBuscaProveedor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbProveedor;
        private System.Windows.Forms.RadioButton rbTodosProveedores;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioIVU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio2IVU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreacionFecha;
    }
}