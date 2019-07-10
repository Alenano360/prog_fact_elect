namespace Restaurante_Presentacion
{
    partial class CajaDiaria_Detalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CajaDiaria_Detalle));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.gbGenerales = new System.Windows.Forms.GroupBox();
            this.chkCheque = new System.Windows.Forms.CheckBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFacturaCompra = new System.Windows.Forms.TextBox();
            this.cmbAutoriza = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbMovimientos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbGenerales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.gbGenerales);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 437);
            this.panel1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(133, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 32);
            this.label10.TabIndex = 125;
            this.label10.Text = "CAJA DIARIA";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbGenerales
            // 
            this.gbGenerales.Controls.Add(this.chkCheque);
            this.gbGenerales.Controls.Add(this.btnCerrar);
            this.gbGenerales.Controls.Add(this.label9);
            this.gbGenerales.Controls.Add(this.txtFacturaCompra);
            this.gbGenerales.Controls.Add(this.cmbAutoriza);
            this.gbGenerales.Controls.Add(this.label8);
            this.gbGenerales.Controls.Add(this.label7);
            this.gbGenerales.Controls.Add(this.txtHora);
            this.gbGenerales.Controls.Add(this.label6);
            this.gbGenerales.Controls.Add(this.dtpFecha);
            this.gbGenerales.Controls.Add(this.label5);
            this.gbGenerales.Controls.Add(this.txtSaldo);
            this.gbGenerales.Controls.Add(this.label4);
            this.gbGenerales.Controls.Add(this.txtMonto);
            this.gbGenerales.Controls.Add(this.label3);
            this.gbGenerales.Controls.Add(this.txtDescripcion);
            this.gbGenerales.Controls.Add(this.cmbMovimientos);
            this.gbGenerales.Controls.Add(this.label2);
            this.gbGenerales.Controls.Add(this.txtComprobante);
            this.gbGenerales.Controls.Add(this.label1);
            this.gbGenerales.Location = new System.Drawing.Point(12, 52);
            this.gbGenerales.Name = "gbGenerales";
            this.gbGenerales.Size = new System.Drawing.Size(420, 374);
            this.gbGenerales.TabIndex = 93;
            this.gbGenerales.TabStop = false;
            this.gbGenerales.Text = "Datos Generales";
            // 
            // chkCheque
            // 
            this.chkCheque.AutoSize = true;
            this.chkCheque.Enabled = false;
            this.chkCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkCheque.Location = new System.Drawing.Point(143, 267);
            this.chkCheque.Name = "chkCheque";
            this.chkCheque.Size = new System.Drawing.Size(138, 21);
            this.chkCheque.TabIndex = 129;
            this.chkCheque.Text = "Pagó con cheque";
            this.chkCheque.UseVisualStyleBackColor = true;
            this.chkCheque.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::Restaurante_Presentacion.Properties.Resources.CerrarIcono;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(280, 268);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 100);
            this.btnCerrar.TabIndex = 96;
            this.btnCerrar.Text = "&C";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(6, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 17);
            this.label9.TabIndex = 127;
            this.label9.Text = "Factura de compra:";
            this.label9.Visible = false;
            // 
            // txtFacturaCompra
            // 
            this.txtFacturaCompra.BackColor = System.Drawing.Color.White;
            this.txtFacturaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFacturaCompra.Location = new System.Drawing.Point(143, 295);
            this.txtFacturaCompra.Name = "txtFacturaCompra";
            this.txtFacturaCompra.ReadOnly = true;
            this.txtFacturaCompra.Size = new System.Drawing.Size(257, 26);
            this.txtFacturaCompra.TabIndex = 128;
            this.txtFacturaCompra.Visible = false;
            // 
            // cmbAutoriza
            // 
            this.cmbAutoriza.BackColor = System.Drawing.SystemColors.Window;
            this.cmbAutoriza.DisplayMember = "Nombre";
            this.cmbAutoriza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutoriza.Enabled = false;
            this.cmbAutoriza.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbAutoriza.FormattingEnabled = true;
            this.cmbAutoriza.IntegralHeight = false;
            this.cmbAutoriza.ItemHeight = 18;
            this.cmbAutoriza.Location = new System.Drawing.Point(143, 263);
            this.cmbAutoriza.Name = "cmbAutoriza";
            this.cmbAutoriza.Size = new System.Drawing.Size(257, 26);
            this.cmbAutoriza.TabIndex = 126;
            this.cmbAutoriza.ValueMember = "Id";
            this.cmbAutoriza.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(32, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 125;
            this.label8.Text = "Autorizado por:";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(94, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 123;
            this.label7.Text = "Hora:";
            // 
            // txtHora
            // 
            this.txtHora.BackColor = System.Drawing.Color.White;
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtHora.Location = new System.Drawing.Point(143, 231);
            this.txtHora.Name = "txtHora";
            this.txtHora.ReadOnly = true;
            this.txtHora.Size = new System.Drawing.Size(257, 26);
            this.txtHora.TabIndex = 124;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(86, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 17);
            this.label6.TabIndex = 122;
            this.label6.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFecha.Location = new System.Drawing.Point(143, 202);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(257, 23);
            this.dtpFecha.TabIndex = 121;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(89, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 111;
            this.label5.Text = "Saldo:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.White;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSaldo.Location = new System.Drawing.Point(143, 170);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(257, 26);
            this.txtSaldo.TabIndex = 112;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(86, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 109;
            this.label4.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.White;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMonto.Location = new System.Drawing.Point(143, 138);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(257, 26);
            this.txtMonto.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(51, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 107;
            this.label3.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDescripcion.Location = new System.Drawing.Point(143, 83);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(257, 49);
            this.txtDescripcion.TabIndex = 108;
            // 
            // cmbMovimientos
            // 
            this.cmbMovimientos.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMovimientos.DisplayMember = "Descripcion";
            this.cmbMovimientos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovimientos.Enabled = false;
            this.cmbMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbMovimientos.FormattingEnabled = true;
            this.cmbMovimientos.IntegralHeight = false;
            this.cmbMovimientos.ItemHeight = 18;
            this.cmbMovimientos.Location = new System.Drawing.Point(143, 19);
            this.cmbMovimientos.Name = "cmbMovimientos";
            this.cmbMovimientos.Size = new System.Drawing.Size(257, 26);
            this.cmbMovimientos.TabIndex = 106;
            this.cmbMovimientos.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(40, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Comprobante:";
            // 
            // txtComprobante
            // 
            this.txtComprobante.BackColor = System.Drawing.Color.White;
            this.txtComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtComprobante.Location = new System.Drawing.Point(143, 51);
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.ReadOnly = true;
            this.txtComprobante.Size = new System.Drawing.Size(257, 26);
            this.txtComprobante.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(54, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Movimiento:";
            // 
            // CajaDiaria_Detalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 437);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CajaDiaria_Detalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CajaDiaria_Detalle_Load);
            this.Resize += new System.EventHandler(this.CajaDiaria_Detalle_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbGenerales.ResumeLayout(false);
            this.gbGenerales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox gbGenerales;
        private System.Windows.Forms.CheckBox chkCheque;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFacturaCompra;
        private System.Windows.Forms.ComboBox cmbAutoriza;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbMovimientos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComprobante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
    }
}