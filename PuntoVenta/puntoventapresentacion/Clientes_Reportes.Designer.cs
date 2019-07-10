namespace PuntoVentaPresentacion
{
    partial class Clientes_Reportes
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPreliminar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExpXLS = new System.Windows.Forms.Button();
            this.btnExpPDF = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.gbExistencias = new System.Windows.Forms.GroupBox();
            this.rbSaldoNegativo = new System.Windows.Forms.RadioButton();
            this.rbTodosSaldo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pdReporte = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.gbExistencias.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDatos);
            this.panel1.Controls.Add(this.btnPreliminar);
            this.panel1.Controls.Add(this.btnImprimir);
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
            this.panel1.Location = new System.Drawing.Point(5, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 353);
            this.panel1.TabIndex = 12;
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
            this.Id,
            this.Nombre,
            this.ap,
            this.contacto,
            this.cedula,
            this.tel1,
            this.tel2,
            this.saldo});
            this.dgvDatos.Location = new System.Drawing.Point(111, 309);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 30;
            this.dgvDatos.Size = new System.Drawing.Size(773, 363);
            this.dgvDatos.TabIndex = 91;
            this.dgvDatos.Visible = false;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // ap
            // 
            this.ap.DataPropertyName = "Apellidos";
            this.ap.HeaderText = "Apellidos";
            this.ap.Name = "ap";
            this.ap.ReadOnly = true;
            // 
            // contacto
            // 
            this.contacto.DataPropertyName = "Contacto";
            this.contacto.HeaderText = "Contacto";
            this.contacto.Name = "contacto";
            this.contacto.ReadOnly = true;
            // 
            // cedula
            // 
            this.cedula.DataPropertyName = "Cedula";
            this.cedula.HeaderText = "Cédula";
            this.cedula.Name = "cedula";
            this.cedula.ReadOnly = true;
            // 
            // tel1
            // 
            this.tel1.DataPropertyName = "Telefono1";
            this.tel1.HeaderText = "Teléfono 1";
            this.tel1.Name = "tel1";
            this.tel1.ReadOnly = true;
            // 
            // tel2
            // 
            this.tel2.DataPropertyName = "Telefono2";
            this.tel2.HeaderText = "Teléfono 2";
            this.tel2.Name = "tel2";
            this.tel2.ReadOnly = true;
            // 
            // saldo
            // 
            this.saldo.DataPropertyName = "Saldo";
            this.saldo.HeaderText = "Saldo";
            this.saldo.Name = "saldo";
            this.saldo.ReadOnly = true;
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
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.Facturar;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(379, 233);
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
            this.label2.Location = new System.Drawing.Point(10, 167);
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
            "Apellido",
            "Cédula",
            "Saldo"});
            this.cmbOrdenar.Location = new System.Drawing.Point(81, 162);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(195, 26);
            this.cmbOrdenar.TabIndex = 4;
            // 
            // gbExistencias
            // 
            this.gbExistencias.Controls.Add(this.rbSaldoNegativo);
            this.gbExistencias.Controls.Add(this.rbTodosSaldo);
            this.gbExistencias.Location = new System.Drawing.Point(13, 84);
            this.gbExistencias.Name = "gbExistencias";
            this.gbExistencias.Size = new System.Drawing.Size(759, 69);
            this.gbExistencias.TabIndex = 94;
            this.gbExistencias.TabStop = false;
            this.gbExistencias.Text = "Saldo";
            // 
            // rbSaldoNegativo
            // 
            this.rbSaldoNegativo.AutoSize = true;
            this.rbSaldoNegativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbSaldoNegativo.Location = new System.Drawing.Point(252, 31);
            this.rbSaldoNegativo.Name = "rbSaldoNegativo";
            this.rbSaldoNegativo.Size = new System.Drawing.Size(177, 21);
            this.rbSaldoNegativo.TabIndex = 1;
            this.rbSaldoNegativo.Text = "Sólo con saldo negativo";
            this.rbSaldoNegativo.UseVisualStyleBackColor = true;
            // 
            // rbTodosSaldo
            // 
            this.rbTodosSaldo.AutoSize = true;
            this.rbTodosSaldo.Checked = true;
            this.rbTodosSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbTodosSaldo.Location = new System.Drawing.Point(22, 31);
            this.rbTodosSaldo.Name = "rbTodosSaldo";
            this.rbTodosSaldo.Size = new System.Drawing.Size(133, 21);
            this.rbTodosSaldo.TabIndex = 0;
            this.rbTodosSaldo.TabStop = true;
            this.rbTodosSaldo.Text = "Todos los saldos";
            this.rbTodosSaldo.UseVisualStyleBackColor = true;
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
            this.printPreviewControl1.Location = new System.Drawing.Point(778, 15);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(209, 318);
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
            // Clientes_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 367);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Clientes_Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de clientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Clientes_Reportes_Load);
            this.Resize += new System.EventHandler(this.Clientes_Reportes_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.GroupBox gbExistencias;
        private System.Windows.Forms.RadioButton rbSaldoNegativo;
        private System.Windows.Forms.RadioButton rbTodosSaldo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Drawing.Printing.PrintDocument pdReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ap;
        private System.Windows.Forms.DataGridViewTextBoxColumn contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo;
    }
}