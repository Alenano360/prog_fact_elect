namespace PuntoVentaPresentacion
{
    partial class Gasto_Reportes
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
            this.btnPreliminar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExpXLS = new System.Windows.Forms.Button();
            this.btnExpPDF = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.gbExistencias = new System.Windows.Forms.GroupBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.rbFiltro = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pdReporte = new System.Drawing.Printing.PrintDocument();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Autoriza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.gbExistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDatos);
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
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 350);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnPreliminar
            // 
            this.btnPreliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnPreliminar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.PreviewIcono;
            this.btnPreliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreliminar.FlatAppearance.BorderSize = 0;
            this.btnPreliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPreliminar.Location = new System.Drawing.Point(13, 233);
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
            this.label3.Location = new System.Drawing.Point(9, 209);
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
            this.btnExpXLS.Location = new System.Drawing.Point(253, 233);
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
            this.btnExpPDF.Location = new System.Drawing.Point(127, 233);
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
            this.btnAceptar.Location = new System.Drawing.Point(526, 233);
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
            this.label2.Location = new System.Drawing.Point(11, 175);
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
            "Fecha",
            "Importe"});
            this.cmbOrdenar.Location = new System.Drawing.Point(82, 170);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(195, 26);
            this.cmbOrdenar.TabIndex = 4;
            // 
            // gbExistencias
            // 
            this.gbExistencias.Controls.Add(this.dtpHasta);
            this.gbExistencias.Controls.Add(this.label5);
            this.gbExistencias.Controls.Add(this.rbFiltro);
            this.gbExistencias.Controls.Add(this.rbTodos);
            this.gbExistencias.Controls.Add(this.label4);
            this.gbExistencias.Controls.Add(this.dtpDesde);
            this.gbExistencias.Location = new System.Drawing.Point(13, 84);
            this.gbExistencias.Name = "gbExistencias";
            this.gbExistencias.Size = new System.Drawing.Size(759, 80);
            this.gbExistencias.TabIndex = 94;
            this.gbExistencias.TabStop = false;
            this.gbExistencias.Text = "Fecha";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpHasta.Location = new System.Drawing.Point(397, 47);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(249, 23);
            this.dtpHasta.TabIndex = 119;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(328, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 118;
            this.label5.Text = "HASTA:";
            // 
            // rbFiltro
            // 
            this.rbFiltro.AutoSize = true;
            this.rbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbFiltro.Location = new System.Drawing.Point(252, 31);
            this.rbFiltro.Name = "rbFiltro";
            this.rbFiltro.Size = new System.Drawing.Size(69, 21);
            this.rbFiltro.TabIndex = 1;
            this.rbFiltro.Text = "Fecha:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(327, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 116;
            this.label4.Text = "DESDE:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpDesde.Location = new System.Drawing.Point(397, 18);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(249, 23);
            this.dtpDesde.TabIndex = 117;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
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
            this.Fecha,
            this.Hora,
            this.Descripcion,
            this.Comprobante,
            this.Autoriza,
            this.Monto});
            this.dgvDatos.Location = new System.Drawing.Point(14, 321);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 30;
            this.dgvDatos.Size = new System.Drawing.Size(884, 363);
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
            this.printPreviewControl1.Location = new System.Drawing.Point(783, 15);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(211, 318);
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
            this.btnCerrar.Location = new System.Drawing.Point(652, 233);
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
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha1";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "Hora";
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Comprobante
            // 
            this.Comprobante.DataPropertyName = "ComprobanteId";
            this.Comprobante.HeaderText = "Comprobante";
            this.Comprobante.Name = "Comprobante";
            this.Comprobante.ReadOnly = true;
            // 
            // Autoriza
            // 
            this.Autoriza.DataPropertyName = "Nombre";
            this.Autoriza.HeaderText = "Autoriza";
            this.Autoriza.Name = "Autoriza";
            this.Autoriza.ReadOnly = true;
            this.Autoriza.Width = 350;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            this.Monto.HeaderText = "Importe";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // Gasto_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 360);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Gasto_Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de gastos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Gasto_Reportes_Load);
            this.Resize += new System.EventHandler(this.Gasto_Reportes_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Drawing.Printing.PrintDocument pdReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Autoriza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
    }
}