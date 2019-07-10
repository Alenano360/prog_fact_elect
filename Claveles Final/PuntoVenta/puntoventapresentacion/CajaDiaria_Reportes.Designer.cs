namespace PuntoVentaPresentacion
{
    partial class CajaDiaria_Reportes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbEntreFechas = new System.Windows.Forms.RadioButton();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbReporteDetallado = new System.Windows.Forms.RadioButton();
            this.rbReporteResumido = new System.Windows.Forms.RadioButton();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Movimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPreliminar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExpXLS = new System.Windows.Forms.Button();
            this.btnExpPDF = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbExistencias = new System.Windows.Forms.GroupBox();
            this.rbUsuario = new System.Windows.Forms.RadioButton();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.rbTodosUsuario = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pdReporte = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.gbExistencias.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dgvDatos);
            this.panel1.Controls.Add(this.btnPreliminar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnExpXLS);
            this.panel1.Controls.Add(this.btnExpPDF);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.gbExistencias);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.printPreviewControl1);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Location = new System.Drawing.Point(9, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 481);
            this.panel1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbEntreFechas);
            this.groupBox2.Controls.Add(this.dtpHasta);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpDesde);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rbTodos);
            this.groupBox2.Location = new System.Drawing.Point(13, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(759, 86);
            this.groupBox2.TabIndex = 122;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado por fecha";
            // 
            // rbEntreFechas
            // 
            this.rbEntreFechas.AutoSize = true;
            this.rbEntreFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbEntreFechas.Location = new System.Drawing.Point(276, 31);
            this.rbEntreFechas.Name = "rbEntreFechas";
            this.rbEntreFechas.Size = new System.Drawing.Size(106, 21);
            this.rbEntreFechas.TabIndex = 114;
            this.rbEntreFechas.Text = "Entre fechas";
            this.rbEntreFechas.UseVisualStyleBackColor = true;
            // 
            // dtpHasta
            // 
            this.dtpHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpHasta.Location = new System.Drawing.Point(458, 49);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(249, 23);
            this.dtpHasta.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(388, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 112;
            this.label5.Text = "HASTA:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpDesde.Location = new System.Drawing.Point(458, 20);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(249, 23);
            this.dtpDesde.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(388, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 110;
            this.label4.Text = "DESDE:";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbReporteDetallado);
            this.groupBox1.Controls.Add(this.rbReporteResumido);
            this.groupBox1.Location = new System.Drawing.Point(13, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 69);
            this.groupBox1.TabIndex = 114;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipode reporte";
            // 
            // rbReporteDetallado
            // 
            this.rbReporteDetallado.AutoSize = true;
            this.rbReporteDetallado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbReporteDetallado.Location = new System.Drawing.Point(276, 31);
            this.rbReporteDetallado.Name = "rbReporteDetallado";
            this.rbReporteDetallado.Size = new System.Drawing.Size(139, 21);
            this.rbReporteDetallado.TabIndex = 113;
            this.rbReporteDetallado.Text = "Reporte detallado";
            this.rbReporteDetallado.UseVisualStyleBackColor = true;
            // 
            // rbReporteResumido
            // 
            this.rbReporteResumido.AutoSize = true;
            this.rbReporteResumido.Checked = true;
            this.rbReporteResumido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbReporteResumido.Location = new System.Drawing.Point(22, 31);
            this.rbReporteResumido.Name = "rbReporteResumido";
            this.rbReporteResumido.Size = new System.Drawing.Size(139, 21);
            this.rbReporteResumido.TabIndex = 0;
            this.rbReporteResumido.TabStop = true;
            this.rbReporteResumido.Text = "Reporte resumido";
            this.rbReporteResumido.UseVisualStyleBackColor = true;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Movimiento,
            this.Comprobante,
            this.Descripcion,
            this.Monto,
            this.Saldo,
            this.Nombre,
            this.Fecha,
            this.Hora});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.Location = new System.Drawing.Point(26, 421);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatos.RowTemplate.Height = 30;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(786, 162);
            this.dgvDatos.TabIndex = 105;
            this.dgvDatos.Visible = false;
            // 
            // Movimiento
            // 
            this.Movimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Movimiento.DataPropertyName = "Movimiento";
            this.Movimiento.HeaderText = "Movimiento";
            this.Movimiento.Name = "Movimiento";
            this.Movimiento.ReadOnly = true;
            this.Movimiento.Width = 114;
            // 
            // Comprobante
            // 
            this.Comprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Comprobante.DataPropertyName = "ComprobanteId";
            this.Comprobante.HeaderText = "Comprobante";
            this.Comprobante.Name = "Comprobante";
            this.Comprobante.ReadOnly = true;
            this.Comprobante.Width = 131;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Monto.DataPropertyName = "Monto";
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 79;
            // 
            // Saldo
            // 
            this.Saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Saldo.DataPropertyName = "Saldo";
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.Width = 75;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 79;
            // 
            // Hora
            // 
            this.Hora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Hora.DataPropertyName = "Hora";
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Width = 69;
            // 
            // btnPreliminar
            // 
            this.btnPreliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnPreliminar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.PreviewIcono;
            this.btnPreliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreliminar.FlatAppearance.BorderSize = 0;
            this.btnPreliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPreliminar.Location = new System.Drawing.Point(13, 358);
            this.btnPreliminar.Name = "btnPreliminar";
            this.btnPreliminar.Size = new System.Drawing.Size(108, 100);
            this.btnPreliminar.TabIndex = 104;
            this.btnPreliminar.Text = "&A";
            this.btnPreliminar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPreliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPreliminar.UseVisualStyleBackColor = false;
            this.btnPreliminar.Click += new System.EventHandler(this.btnPreliminar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.Facturar;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(379, 358);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 100);
            this.btnImprimir.TabIndex = 103;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 334);
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
            this.btnExpXLS.Location = new System.Drawing.Point(253, 358);
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
            this.btnExpPDF.Location = new System.Drawing.Point(127, 358);
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
            this.btnAceptar.Location = new System.Drawing.Point(526, 358);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 100);
            this.btnAceptar.TabIndex = 97;
            this.btnAceptar.Text = "&A";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbExistencias
            // 
            this.gbExistencias.Controls.Add(this.rbUsuario);
            this.gbExistencias.Controls.Add(this.cmbUsuario);
            this.gbExistencias.Controls.Add(this.rbTodosUsuario);
            this.gbExistencias.Location = new System.Drawing.Point(13, 84);
            this.gbExistencias.Name = "gbExistencias";
            this.gbExistencias.Size = new System.Drawing.Size(759, 69);
            this.gbExistencias.TabIndex = 94;
            this.gbExistencias.TabStop = false;
            this.gbExistencias.Text = "Usuarios";
            // 
            // rbUsuario
            // 
            this.rbUsuario.AutoSize = true;
            this.rbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbUsuario.Location = new System.Drawing.Point(276, 31);
            this.rbUsuario.Name = "rbUsuario";
            this.rbUsuario.Size = new System.Drawing.Size(75, 21);
            this.rbUsuario.TabIndex = 113;
            this.rbUsuario.Text = "Usuario";
            this.rbUsuario.UseVisualStyleBackColor = true;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.cmbUsuario.DisplayMember = "Nombre";
            this.cmbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.IntegralHeight = false;
            this.cmbUsuario.ItemHeight = 18;
            this.cmbUsuario.Location = new System.Drawing.Point(357, 28);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(339, 26);
            this.cmbUsuario.TabIndex = 111;
            this.cmbUsuario.ValueMember = "Id";
            // 
            // rbTodosUsuario
            // 
            this.rbTodosUsuario.AutoSize = true;
            this.rbTodosUsuario.Checked = true;
            this.rbTodosUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbTodosUsuario.Location = new System.Drawing.Point(22, 31);
            this.rbTodosUsuario.Name = "rbTodosUsuario";
            this.rbTodosUsuario.Size = new System.Drawing.Size(146, 21);
            this.rbTodosUsuario.TabIndex = 0;
            this.rbTodosUsuario.TabStop = true;
            this.rbTodosUsuario.Text = "Todos los usuarios";
            this.rbTodosUsuario.UseVisualStyleBackColor = true;
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
            this.printPreviewControl1.Location = new System.Drawing.Point(778, 7);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(209, 462);
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
            this.btnCerrar.Location = new System.Drawing.Point(652, 358);
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
            // CajaDiaria_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 496);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CajaDiaria_Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de caja diaria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CajaDiaria_Reportes_Load);
            this.Resize += new System.EventHandler(this.CajaDiaria_Reportes_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.gbExistencias.ResumeLayout(false);
            this.gbExistencias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPreliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExpXLS;
        private System.Windows.Forms.Button btnExpPDF;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gbExistencias;
        private System.Windows.Forms.RadioButton rbTodosUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Drawing.Printing.PrintDocument pdReporte;
        private System.Windows.Forms.RadioButton rbUsuario;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbReporteDetallado;
        private System.Windows.Forms.RadioButton rbReporteResumido;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbEntreFechas;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
    }
}