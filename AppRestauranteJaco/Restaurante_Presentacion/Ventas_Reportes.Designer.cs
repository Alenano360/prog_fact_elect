namespace Restaurante_Presentacion
{
    partial class Ventas_Reportes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventas_Reportes));
            this.panelCompleto = new System.Windows.Forms.Panel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.gb_Familias = new System.Windows.Forms.GroupBox();
            this.cmbFamilia = new System.Windows.Forms.ComboBox();
            this.rbFamilia = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.chkArticulosReporte = new System.Windows.Forms.CheckBox();
            this.gbVentas = new System.Windows.Forms.GroupBox();
            this.rbTarjetaCredito = new System.Windows.Forms.RadioButton();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.btnPreliminar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExpXLS = new System.Windows.Forms.Button();
            this.btnExpPDF = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.gbFechas = new System.Windows.Forms.GroupBox();
            this.rbEntreFechas = new System.Windows.Forms.RadioButton();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvDatos1 = new System.Windows.Forms.DataGridView();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad_Vendida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdReporte = new System.Drawing.Printing.PrintDocument();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tls_Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsNombreRest = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsWebHtml = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelCompleto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.gb_Familias.SuspendLayout();
            this.gbVentas.SuspendLayout();
            this.gbFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCompleto
            // 
            this.panelCompleto.Controls.Add(this.dgvDatos);
            this.panelCompleto.Controls.Add(this.label7);
            this.panelCompleto.Controls.Add(this.gb_Familias);
            this.panelCompleto.Controls.Add(this.chkArticulosReporte);
            this.panelCompleto.Controls.Add(this.gbVentas);
            this.panelCompleto.Controls.Add(this.btnPreliminar);
            this.panelCompleto.Controls.Add(this.btnImprimir);
            this.panelCompleto.Controls.Add(this.label3);
            this.panelCompleto.Controls.Add(this.btnExpXLS);
            this.panelCompleto.Controls.Add(this.btnExpPDF);
            this.panelCompleto.Controls.Add(this.btnAceptar);
            this.panelCompleto.Controls.Add(this.label2);
            this.panelCompleto.Controls.Add(this.cmbOrdenar);
            this.panelCompleto.Controls.Add(this.gbFechas);
            this.panelCompleto.Controls.Add(this.label1);
            this.panelCompleto.Controls.Add(this.printPreviewControl1);
            this.panelCompleto.Controls.Add(this.btnCerrar);
            this.panelCompleto.Location = new System.Drawing.Point(0, 0);
            this.panelCompleto.Name = "panelCompleto";
            this.panelCompleto.Size = new System.Drawing.Size(934, 475);
            this.panelCompleto.TabIndex = 14;
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
            this.Comprobante,
            this.Cliente,
            this.Fecha,
            this.Hora,
            this.Descuento,
            this.Importe_total});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatos.Location = new System.Drawing.Point(69, 384);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDatos.RowTemplate.Height = 30;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(786, 106);
            this.dgvDatos.TabIndex = 105;
            this.dgvDatos.Visible = false;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // Comprobante
            // 
            this.Comprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Comprobante.DataPropertyName = "Id";
            this.Comprobante.HeaderText = "Comprobante";
            this.Comprobante.Name = "Comprobante";
            this.Comprobante.ReadOnly = true;
            this.Comprobante.Width = 131;
            // 
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cliente.DataPropertyName = "Nombre";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
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
            this.Hora.DataPropertyName = "Hora";
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            // 
            // Descuento
            // 
            this.Descuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Descuento.DataPropertyName = "Descuento";
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 112;
            // 
            // Importe_total
            // 
            this.Importe_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Importe_total.DataPropertyName = "Total";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Importe_total.DefaultCellStyle = dataGridViewCellStyle2;
            this.Importe_total.HeaderText = "Importe_Total";
            this.Importe_total.Name = "Importe_total";
            this.Importe_total.ReadOnly = true;
            this.Importe_total.Width = 133;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(248, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(285, 32);
            this.label7.TabIndex = 124;
            this.label7.Text = "REPORTES DE VENTAS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_Familias
            // 
            this.gb_Familias.Controls.Add(this.cmbFamilia);
            this.gb_Familias.Controls.Add(this.rbFamilia);
            this.gb_Familias.Controls.Add(this.radioButton7);
            this.gb_Familias.Location = new System.Drawing.Point(13, 240);
            this.gb_Familias.Name = "gb_Familias";
            this.gb_Familias.Size = new System.Drawing.Size(717, 60);
            this.gb_Familias.TabIndex = 118;
            this.gb_Familias.TabStop = false;
            this.gb_Familias.Text = "Listado de productos vendidos por familia";
            this.gb_Familias.Visible = false;
            // 
            // cmbFamilia
            // 
            this.cmbFamilia.BackColor = System.Drawing.SystemColors.Window;
            this.cmbFamilia.DisplayMember = "Descripcion";
            this.cmbFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbFamilia.FormattingEnabled = true;
            this.cmbFamilia.IntegralHeight = false;
            this.cmbFamilia.ItemHeight = 18;
            this.cmbFamilia.Location = new System.Drawing.Point(356, 20);
            this.cmbFamilia.Name = "cmbFamilia";
            this.cmbFamilia.Size = new System.Drawing.Size(326, 26);
            this.cmbFamilia.TabIndex = 116;
            this.cmbFamilia.ValueMember = "Id";
            this.cmbFamilia.SelectedIndexChanged += new System.EventHandler(this.cmbFamilia_SelectedIndexChanged);
            // 
            // rbFamilia
            // 
            this.rbFamilia.AutoSize = true;
            this.rbFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbFamilia.Location = new System.Drawing.Point(254, 23);
            this.rbFamilia.Name = "rbFamilia";
            this.rbFamilia.Size = new System.Drawing.Size(74, 21);
            this.rbFamilia.TabIndex = 114;
            this.rbFamilia.Text = "Familia:";
            this.rbFamilia.UseVisualStyleBackColor = true;
            this.rbFamilia.CheckedChanged += new System.EventHandler(this.rbFamilia_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Checked = true;
            this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButton7.Location = new System.Drawing.Point(22, 23);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(66, 21);
            this.radioButton7.TabIndex = 0;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Todos";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // chkArticulosReporte
            // 
            this.chkArticulosReporte.AutoSize = true;
            this.chkArticulosReporte.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.chkArticulosReporte.Location = new System.Drawing.Point(12, 210);
            this.chkArticulosReporte.Name = "chkArticulosReporte";
            this.chkArticulosReporte.Size = new System.Drawing.Size(245, 25);
            this.chkArticulosReporte.TabIndex = 121;
            this.chkArticulosReporte.Text = "Reporte de venta de artículos";
            this.chkArticulosReporte.UseVisualStyleBackColor = true;
            this.chkArticulosReporte.CheckedChanged += new System.EventHandler(this.chkArticulosReporte_CheckedChanged);
            // 
            // gbVentas
            // 
            this.gbVentas.Controls.Add(this.rbTarjetaCredito);
            this.gbVentas.Controls.Add(this.rbEfectivo);
            this.gbVentas.Controls.Add(this.radioButton5);
            this.gbVentas.Location = new System.Drawing.Point(13, 157);
            this.gbVentas.Name = "gbVentas";
            this.gbVentas.Size = new System.Drawing.Size(720, 47);
            this.gbVentas.TabIndex = 117;
            this.gbVentas.TabStop = false;
            this.gbVentas.Text = "Listado de ventas";
            // 
            // rbTarjetaCredito
            // 
            this.rbTarjetaCredito.AutoSize = true;
            this.rbTarjetaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbTarjetaCredito.Location = new System.Drawing.Point(484, 18);
            this.rbTarjetaCredito.Name = "rbTarjetaCredito";
            this.rbTarjetaCredito.Size = new System.Drawing.Size(201, 21);
            this.rbTarjetaCredito.TabIndex = 115;
            this.rbTarjetaCredito.Text = "Ventas en tarjeta de crédito";
            this.rbTarjetaCredito.UseVisualStyleBackColor = true;
            // 
            // rbEfectivo
            // 
            this.rbEfectivo.AutoSize = true;
            this.rbEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbEfectivo.Location = new System.Drawing.Point(254, 18);
            this.rbEfectivo.Name = "rbEfectivo";
            this.rbEfectivo.Size = new System.Drawing.Size(143, 21);
            this.rbEfectivo.TabIndex = 114;
            this.rbEfectivo.Text = "Ventas en efectivo";
            this.rbEfectivo.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Checked = true;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButton5.Location = new System.Drawing.Point(22, 18);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(66, 21);
            this.radioButton5.TabIndex = 0;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Todas";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // btnPreliminar
            // 
            this.btnPreliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnPreliminar.BackgroundImage = global::Restaurante_Presentacion.Properties.Resources.PreviewIcono;
            this.btnPreliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreliminar.FlatAppearance.BorderSize = 0;
            this.btnPreliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPreliminar.Location = new System.Drawing.Point(14, 372);
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
            this.btnImprimir.BackgroundImage = global::Restaurante_Presentacion.Properties.Resources.Facturar;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(380, 372);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 100);
            this.btnImprimir.TabIndex = 103;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(388, 21);
            this.label3.TabIndex = 100;
            this.label3.Text = "Seleccione a que formato desea exportar el reporte";
            // 
            // btnExpXLS
            // 
            this.btnExpXLS.BackColor = System.Drawing.Color.Transparent;
            this.btnExpXLS.BackgroundImage = global::Restaurante_Presentacion.Properties.Resources.ExcelIcono;
            this.btnExpXLS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpXLS.FlatAppearance.BorderSize = 0;
            this.btnExpXLS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpXLS.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExpXLS.Location = new System.Drawing.Point(254, 372);
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
            this.btnExpPDF.BackgroundImage = global::Restaurante_Presentacion.Properties.Resources.PDFIcono;
            this.btnExpPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpPDF.FlatAppearance.BorderSize = 0;
            this.btnExpPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpPDF.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExpPDF.Location = new System.Drawing.Point(128, 372);
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
            this.btnAceptar.BackgroundImage = global::Restaurante_Presentacion.Properties.Resources.AceptarIcono;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.Location = new System.Drawing.Point(527, 372);
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
            this.label2.Location = new System.Drawing.Point(11, 311);
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
            "Fecha ",
            "Comprobante",
            "Cliente",
            "Familia"});
            this.cmbOrdenar.Location = new System.Drawing.Point(82, 306);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(195, 26);
            this.cmbOrdenar.TabIndex = 4;
            // 
            // gbFechas
            // 
            this.gbFechas.Controls.Add(this.rbEntreFechas);
            this.gbFechas.Controls.Add(this.dtpHasta);
            this.gbFechas.Controls.Add(this.label5);
            this.gbFechas.Controls.Add(this.dtpDesde);
            this.gbFechas.Controls.Add(this.label4);
            this.gbFechas.Controls.Add(this.rbTodos);
            this.gbFechas.Location = new System.Drawing.Point(13, 79);
            this.gbFechas.Name = "gbFechas";
            this.gbFechas.Size = new System.Drawing.Size(720, 72);
            this.gbFechas.TabIndex = 94;
            this.gbFechas.TabStop = false;
            this.gbFechas.Text = "Listado por fecha";
            // 
            // rbEntreFechas
            // 
            this.rbEntreFechas.AutoSize = true;
            this.rbEntreFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbEntreFechas.Location = new System.Drawing.Point(254, 26);
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
            this.dtpHasta.Location = new System.Drawing.Point(436, 42);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(249, 23);
            this.dtpHasta.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(366, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 112;
            this.label5.Text = "HASTA:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpDesde.Location = new System.Drawing.Point(436, 13);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(249, 23);
            this.dtpDesde.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(366, 18);
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
            this.rbTodos.Location = new System.Drawing.Point(22, 26);
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
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 21);
            this.label1.TabIndex = 93;
            this.label1.Text = "Seleccione los elementos que desee para el reporte";
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(739, 53);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(183, 308);
            this.printPreviewControl1.TabIndex = 10;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::Restaurante_Presentacion.Properties.Resources.CerrarIcono;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(653, 372);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 100);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "&C";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvDatos1
            // 
            this.dgvDatos1.AllowUserToAddRows = false;
            this.dgvDatos1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDatos1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Articulo,
            this.Familia,
            this.Cantidad_Vendida,
            this.Precio});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDatos1.Location = new System.Drawing.Point(69, 453);
            this.dgvDatos1.Name = "dgvDatos1";
            this.dgvDatos1.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDatos1.RowTemplate.Height = 30;
            this.dgvDatos1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos1.Size = new System.Drawing.Size(786, 93);
            this.dgvDatos1.TabIndex = 122;
            this.dgvDatos1.Visible = false;
            // 
            // Articulo
            // 
            this.Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Articulo.DataPropertyName = "Descripcion";
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            // 
            // Familia
            // 
            this.Familia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Familia.DataPropertyName = "Familia";
            this.Familia.HeaderText = "Familia";
            this.Familia.Name = "Familia";
            this.Familia.ReadOnly = true;
            // 
            // Cantidad_Vendida
            // 
            this.Cantidad_Vendida.DataPropertyName = "CantidadVendida";
            this.Cantidad_Vendida.HeaderText = "Cantidad Vendida";
            this.Cantidad_Vendida.Name = "Cantidad_Vendida";
            this.Cantidad_Vendida.ReadOnly = true;
            this.Cantidad_Vendida.Width = 200;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // pdReporte
            // 
            this.pdReporte.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdReporte_PrintPage);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tls_Usuario,
            this.tlsNombreRest,
            this.tlsWebHtml,
            this.tlsFecha,
            this.tlsHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(934, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 39;
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
            // Ventas_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 502);
            this.Controls.Add(this.dgvDatos1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelCompleto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Ventas_Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ventas_Reportes_Load);
            this.Resize += new System.EventHandler(this.Ventas_Reportes_Resize);
            this.panelCompleto.ResumeLayout(false);
            this.panelCompleto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.gb_Familias.ResumeLayout(false);
            this.gb_Familias.PerformLayout();
            this.gbVentas.ResumeLayout(false);
            this.gbVentas.PerformLayout();
            this.gbFechas.ResumeLayout(false);
            this.gbFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCompleto;
        private System.Windows.Forms.DataGridView dgvDatos1;
        private System.Windows.Forms.CheckBox chkArticulosReporte;
        private System.Windows.Forms.GroupBox gb_Familias;
        private System.Windows.Forms.ComboBox cmbFamilia;
        private System.Windows.Forms.RadioButton rbFamilia;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.GroupBox gbVentas;
        private System.Windows.Forms.RadioButton rbEfectivo;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnPreliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExpXLS;
        private System.Windows.Forms.Button btnExpPDF;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.GroupBox gbFechas;
        private System.Windows.Forms.RadioButton rbEntreFechas;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbTarjetaCredito;
        private System.Drawing.Printing.PrintDocument pdReporte;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tls_Usuario;
        private System.Windows.Forms.ToolStripStatusLabel tlsNombreRest;
        private System.Windows.Forms.ToolStripStatusLabel tlsWebHtml;
        private System.Windows.Forms.ToolStripStatusLabel tlsFecha;
        private System.Windows.Forms.ToolStripStatusLabel tlsHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad_Vendida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe_total;
    }
}