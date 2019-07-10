namespace Restaurante_Presentacion
{
    partial class Cierre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cierre));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbGenerales = new System.Windows.Forms.GroupBox();
            this.chkCierreTicket = new System.Windows.Forms.CheckBox();
            this.chkNoRep = new System.Windows.Forms.CheckBox();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.gbGenerales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.gbGenerales);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 361);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(41, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 32);
            this.label2.TabIndex = 125;
            this.label2.Text = "CAJA DIARIA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::Restaurante_Presentacion.Properties.Resources.CerrarIcono;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(138, 251);
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
            this.btnAceptar.BackgroundImage = global::Restaurante_Presentacion.Properties.Resources.AceptarIcono;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.Location = new System.Drawing.Point(3, 251);
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
            this.gbGenerales.Controls.Add(this.chkCierreTicket);
            this.gbGenerales.Controls.Add(this.chkNoRep);
            this.gbGenerales.Controls.Add(this.chkExcel);
            this.gbGenerales.Controls.Add(this.chkPDF);
            this.gbGenerales.Location = new System.Drawing.Point(5, 61);
            this.gbGenerales.Name = "gbGenerales";
            this.gbGenerales.Size = new System.Drawing.Size(260, 184);
            this.gbGenerales.TabIndex = 92;
            this.gbGenerales.TabStop = false;
            this.gbGenerales.Text = "Datos Generales";
            // 
            // chkCierreTicket
            // 
            this.chkCierreTicket.AutoSize = true;
            this.chkCierreTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkCierreTicket.Location = new System.Drawing.Point(42, 87);
            this.chkCierreTicket.Name = "chkCierreTicket";
            this.chkCierreTicket.Size = new System.Drawing.Size(177, 21);
            this.chkCierreTicket.TabIndex = 17;
            this.chkCierreTicket.Text = "Exportar cierre en ticket";
            this.chkCierreTicket.UseVisualStyleBackColor = true;
            // 
            // chkNoRep
            // 
            this.chkNoRep.AutoSize = true;
            this.chkNoRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkNoRep.Location = new System.Drawing.Point(42, 117);
            this.chkNoRep.Name = "chkNoRep";
            this.chkNoRep.Size = new System.Drawing.Size(137, 21);
            this.chkNoRep.TabIndex = 15;
            this.chkNoRep.Text = "Cierre sin reporte";
            this.chkNoRep.UseVisualStyleBackColor = true;
            this.chkNoRep.CheckedChanged += new System.EventHandler(this.chkNoRep_CheckedChanged);
            // 
            // chkExcel
            // 
            this.chkExcel.AutoSize = true;
            this.chkExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkExcel.Location = new System.Drawing.Point(42, 60);
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.Size = new System.Drawing.Size(169, 21);
            this.chkExcel.TabIndex = 14;
            this.chkExcel.Text = "Exportar cierre a Excel";
            this.chkExcel.UseVisualStyleBackColor = true;
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkPDF.Location = new System.Drawing.Point(42, 33);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(163, 21);
            this.chkPDF.TabIndex = 13;
            this.chkPDF.Text = "Exportar cierre a PDF";
            this.chkPDF.UseVisualStyleBackColor = true;
            // 
            // Cierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 364);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cierre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Cierre_Load);
            this.Resize += new System.EventHandler(this.Cierre_Resize);
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
        private System.Windows.Forms.CheckBox chkNoRep;
        private System.Windows.Forms.CheckBox chkExcel;
        private System.Windows.Forms.CheckBox chkPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCierreTicket;
    }
}