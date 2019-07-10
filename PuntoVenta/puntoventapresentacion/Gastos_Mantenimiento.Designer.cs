namespace PuntoVentaPresentacion
{
    partial class Gasto_Mantenimiento
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbGenerales = new System.Windows.Forms.GroupBox();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.btnBuscaUsuario = new System.Windows.Forms.Button();
            this.cmbAutoriza = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbGenerales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.gbGenerales);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 405);
            this.panel1.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.CerrarIcono;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(531, 295);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 100);
            this.btnCerrar.TabIndex = 94;
            this.btnCerrar.Text = "&C";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.AceptarIcono;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.Location = new System.Drawing.Point(405, 295);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 100);
            this.btnAceptar.TabIndex = 95;
            this.btnAceptar.Text = "&A";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbGenerales
            // 
            this.gbGenerales.Controls.Add(this.txtComprobante);
            this.gbGenerales.Controls.Add(this.btnBuscaUsuario);
            this.gbGenerales.Controls.Add(this.cmbAutoriza);
            this.gbGenerales.Controls.Add(this.label6);
            this.gbGenerales.Controls.Add(this.label4);
            this.gbGenerales.Controls.Add(this.label3);
            this.gbGenerales.Controls.Add(this.txtImporte);
            this.gbGenerales.Controls.Add(this.label5);
            this.gbGenerales.Controls.Add(this.txtDescripcion);
            this.gbGenerales.Controls.Add(this.dtpFecha);
            this.gbGenerales.Controls.Add(this.label2);
            this.gbGenerales.Controls.Add(this.lblHora);
            this.gbGenerales.Controls.Add(this.txtHora);
            this.gbGenerales.Location = new System.Drawing.Point(12, 51);
            this.gbGenerales.Name = "gbGenerales";
            this.gbGenerales.Size = new System.Drawing.Size(639, 238);
            this.gbGenerales.TabIndex = 92;
            this.gbGenerales.TabStop = false;
            this.gbGenerales.Text = "Datos Generales";
            // 
            // txtComprobante
            // 
            this.txtComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtComprobante.Location = new System.Drawing.Point(421, 164);
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(203, 26);
            this.txtComprobante.TabIndex = 109;
            // 
            // btnBuscaUsuario
            // 
            this.btnBuscaUsuario.Location = new System.Drawing.Point(595, 196);
            this.btnBuscaUsuario.Name = "btnBuscaUsuario";
            this.btnBuscaUsuario.Size = new System.Drawing.Size(29, 26);
            this.btnBuscaUsuario.TabIndex = 108;
            this.btnBuscaUsuario.Text = "...";
            this.btnBuscaUsuario.UseVisualStyleBackColor = true;
            this.btnBuscaUsuario.Click += new System.EventHandler(this.btnBuscaUsuario_Click);
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
            this.cmbAutoriza.Location = new System.Drawing.Point(109, 196);
            this.cmbAutoriza.Name = "cmbAutoriza";
            this.cmbAutoriza.Size = new System.Drawing.Size(477, 26);
            this.cmbAutoriza.TabIndex = 107;
            this.cmbAutoriza.ValueMember = "Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(7, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 106;
            this.label6.Text = "Importe:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(6, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 104;
            this.label4.Text = "Autoriza:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(318, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 102;
            this.label3.Text = "Comprobante:";
            // 
            // txtImporte
            // 
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtImporte.Location = new System.Drawing.Point(109, 163);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(203, 26);
            this.txtImporte.TabIndex = 103;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(7, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 100;
            this.label5.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDescripcion.Location = new System.Drawing.Point(109, 64);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(515, 93);
            this.txtDescripcion.TabIndex = 101;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFecha.Location = new System.Drawing.Point(109, 33);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(257, 23);
            this.dtpFecha.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 98;
            this.label2.Text = "Fecha:";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblHora.Location = new System.Drawing.Point(372, 38);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(43, 17);
            this.lblHora.TabIndex = 96;
            this.lblHora.Text = "Hora:";
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtHora.Location = new System.Drawing.Point(421, 32);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(203, 26);
            this.txtHora.TabIndex = 97;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(273, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(122, 45);
            this.lblTitulo.TabIndex = 91;
            this.lblTitulo.Text = "GASTO";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Gasto_Mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 407);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "Gasto_Mantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de gastos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Gasto_Mantenimiento_Load);
            this.Resize += new System.EventHandler(this.Gasto_Mantenimiento_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbGenerales.ResumeLayout(false);
            this.gbGenerales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gbGenerales;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscaUsuario;
        private System.Windows.Forms.ComboBox cmbAutoriza;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComprobante;
    }
}