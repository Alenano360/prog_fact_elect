namespace PuntoVentaPresentacion
{
    partial class Sel_NotaCredito
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscaFactura = new System.Windows.Forms.Button();
            this.txtFacturaId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkImprimeTicket = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gbGenerales = new System.Windows.Forms.GroupBox();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            this.rbSaldo = new System.Windows.Forms.RadioButton();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.rbRegistra = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.gbGenerales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscaFactura);
            this.panel1.Controls.Add(this.txtFacturaId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkImprimeTicket);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.gbGenerales);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 394);
            this.panel1.TabIndex = 2;
            // 
            // btnBuscaFactura
            // 
            this.btnBuscaFactura.Location = new System.Drawing.Point(404, 68);
            this.btnBuscaFactura.Name = "btnBuscaFactura";
            this.btnBuscaFactura.Size = new System.Drawing.Size(29, 26);
            this.btnBuscaFactura.TabIndex = 127;
            this.btnBuscaFactura.Text = "...";
            this.btnBuscaFactura.UseVisualStyleBackColor = true;
            this.btnBuscaFactura.Click += new System.EventHandler(this.btnBuscaFactura_Click);
            // 
            // txtFacturaId
            // 
            this.txtFacturaId.BackColor = System.Drawing.Color.White;
            this.txtFacturaId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFacturaId.Location = new System.Drawing.Point(195, 63);
            this.txtFacturaId.Name = "txtFacturaId";
            this.txtFacturaId.ReadOnly = true;
            this.txtFacturaId.Size = new System.Drawing.Size(203, 31);
            this.txtFacturaId.TabIndex = 126;
            this.txtFacturaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 16);
            this.label3.TabIndex = 125;
            this.label3.Text = "NÚMERO DE FACTURA:";
            // 
            // chkImprimeTicket
            // 
            this.chkImprimeTicket.AutoSize = true;
            this.chkImprimeTicket.Checked = true;
            this.chkImprimeTicket.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImprimeTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.chkImprimeTicket.Location = new System.Drawing.Point(12, 359);
            this.chkImprimeTicket.Name = "chkImprimeTicket";
            this.chkImprimeTicket.Size = new System.Drawing.Size(170, 24);
            this.chkImprimeTicket.TabIndex = 124;
            this.chkImprimeTicket.Text = "IMPRIME TICKET";
            this.chkImprimeTicket.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.AceptarIcono;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.Location = new System.Drawing.Point(187, 283);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 100);
            this.btnAceptar.TabIndex = 123;
            this.btnAceptar.Text = "&A";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.CerrarIcono;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(313, 283);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 100);
            this.btnCerrar.TabIndex = 96;
            this.btnCerrar.Text = "&C";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gbGenerales
            // 
            this.gbGenerales.Controls.Add(this.rbRegistra);
            this.gbGenerales.Controls.Add(this.rbEfectivo);
            this.gbGenerales.Controls.Add(this.rbSaldo);
            this.gbGenerales.Location = new System.Drawing.Point(13, 116);
            this.gbGenerales.Name = "gbGenerales";
            this.gbGenerales.Size = new System.Drawing.Size(420, 161);
            this.gbGenerales.TabIndex = 93;
            this.gbGenerales.TabStop = false;
            this.gbGenerales.Text = "Datos Generales";
            // 
            // rbEfectivo
            // 
            this.rbEfectivo.AutoSize = true;
            this.rbEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEfectivo.Location = new System.Drawing.Point(42, 66);
            this.rbEfectivo.Name = "rbEfectivo";
            this.rbEfectivo.Size = new System.Drawing.Size(238, 24);
            this.rbEfectivo.TabIndex = 1;
            this.rbEfectivo.TabStop = true;
            this.rbEfectivo.Text = "ENTREGADA EN EFECTIVO";
            this.rbEfectivo.UseVisualStyleBackColor = true;
            // 
            // rbSaldo
            // 
            this.rbSaldo.AutoSize = true;
            this.rbSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSaldo.Location = new System.Drawing.Point(42, 24);
            this.rbSaldo.Name = "rbSaldo";
            this.rbSaldo.Size = new System.Drawing.Size(311, 24);
            this.rbSaldo.TabIndex = 0;
            this.rbSaldo.TabStop = true;
            this.rbSaldo.Text = "AGREGADA AL SALDO DEL CLIENTE";
            this.rbSaldo.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(79, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(297, 45);
            this.lblTitulo.TabIndex = 92;
            this.lblTitulo.Text = "NOTA DE CRÉDITO";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbRegistra
            // 
            this.rbRegistra.AutoSize = true;
            this.rbRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRegistra.Location = new System.Drawing.Point(42, 111);
            this.rbRegistra.Name = "rbRegistra";
            this.rbRegistra.Size = new System.Drawing.Size(248, 24);
            this.rbRegistra.TabIndex = 2;
            this.rbRegistra.TabStop = true;
            this.rbRegistra.Text = "REGISTRAR EN EL SISTEMA";
            this.rbRegistra.UseVisualStyleBackColor = true;
            // 
            // Sel_NotaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 395);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "Sel_NotaCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de nota de crédito";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Sel_NotaCredito_Load);
            this.Resize += new System.EventHandler(this.Sel_NotaCredito_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbGenerales.ResumeLayout(false);
            this.gbGenerales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox gbGenerales;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.RadioButton rbEfectivo;
        private System.Windows.Forms.RadioButton rbSaldo;
        private System.Windows.Forms.CheckBox chkImprimeTicket;
        private System.Windows.Forms.TextBox txtFacturaId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscaFactura;
        private System.Windows.Forms.RadioButton rbRegistra;
    }
}