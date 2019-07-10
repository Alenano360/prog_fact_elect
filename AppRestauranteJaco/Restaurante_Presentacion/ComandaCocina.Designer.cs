namespace Restaurante_Presentacion
{
    partial class ComandaCocina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComandaCocina));
            this.gbEntregar = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCocina = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tls_Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsNombreRest = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsWebHtml = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelCompleto = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbEntregar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelCompleto.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEntregar
            // 
            this.gbEntregar.Controls.Add(this.label4);
            this.gbEntregar.Controls.Add(this.label3);
            this.gbEntregar.Controls.Add(this.label2);
            this.gbEntregar.Controls.Add(this.label1);
            this.gbEntregar.Controls.Add(this.panelCocina);
            this.gbEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gbEntregar.Location = new System.Drawing.Point(4, 48);
            this.gbEntregar.Name = "gbEntregar";
            this.gbEntregar.Size = new System.Drawing.Size(977, 454);
            this.gbEntregar.TabIndex = 14;
            this.gbEntregar.TabStop = false;
            this.gbEntregar.Text = "Por entregar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(787, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "ENTREGADO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(669, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "MESA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(497, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "CANTIDAD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(37, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "PRODUCTO";
            // 
            // panelCocina
            // 
            this.panelCocina.Location = new System.Drawing.Point(12, 19);
            this.panelCocina.Name = "panelCocina";
            this.panelCocina.Size = new System.Drawing.Size(959, 425);
            this.panelCocina.TabIndex = 5;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(354, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(271, 32);
            this.lblTitulo.TabIndex = 11;
            this.lblTitulo.Text = "Comanda Cocina:";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tls_Usuario,
            this.tlsNombreRest,
            this.tlsWebHtml,
            this.tlsFecha,
            this.tlsHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 20;
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
            this.tls_Usuario.Size = new System.Drawing.Size(150, 19);
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
            this.tlsNombreRest.Size = new System.Drawing.Size(575, 19);
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
            this.tlsWebHtml.Size = new System.Drawing.Size(575, 19);
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
            // panelCompleto
            // 
            this.panelCompleto.Controls.Add(this.gbEntregar);
            this.panelCompleto.Controls.Add(this.lblTitulo);
            this.panelCompleto.Location = new System.Drawing.Point(0, 32);
            this.panelCompleto.Name = "panelCompleto";
            this.panelCompleto.Size = new System.Drawing.Size(1000, 503);
            this.panelCompleto.TabIndex = 21;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ComandaCocina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelCompleto);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComandaCocina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ComandaCocina_Load);
            this.Resize += new System.EventHandler(this.ComandaCocina_Resize);
            this.gbEntregar.ResumeLayout(false);
            this.gbEntregar.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelCompleto.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEntregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tls_Usuario;
        private System.Windows.Forms.ToolStripStatusLabel tlsNombreRest;
        private System.Windows.Forms.ToolStripStatusLabel tlsWebHtml;
        private System.Windows.Forms.ToolStripStatusLabel tlsFecha;
        private System.Windows.Forms.ToolStripStatusLabel tlsHora;
        private System.Windows.Forms.Panel panelCompleto;
        private System.Windows.Forms.Panel panelCocina;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}