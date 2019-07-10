namespace Restaurante_Presentacion
{
    partial class AgregarPersona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarPersona));
            this.distritoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.puntoVentaAutoPartsOnDemandDataTablesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cantonBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.provinciaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.familiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_nombre = new Bunifu.Framework.UI.BunifuTextbox();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Ot_S = new Bunifu.Framework.UI.BunifuTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_correo = new Bunifu.Framework.UI.BunifuTextbox();
            this.txt_ident_num = new Bunifu.Framework.UI.BunifuTextbox();
            this.cb_emisor = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ident_tipo = new System.Windows.Forms.ComboBox();
            this.cb_Provincia = new System.Windows.Forms.ComboBox();
            this.cb_Canton = new System.Windows.Forms.ComboBox();
            this.cb_Distrito = new System.Windows.Forms.ComboBox();
            this.Agregar = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.distritoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puntoVentaAutoPartsOnDemandDataTablesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantonBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiaBindingSource)).BeginInit();
            this.Agregar.SuspendLayout();
            this.SuspendLayout();
            // 
            // distritoBindingSource
            // 
            this.distritoBindingSource.DataSource = this.puntoVentaAutoPartsOnDemandDataTablesBindingSource;
            // 
            // cantonBindingSource1
            // 
            this.cantonBindingSource1.DataSource = this.puntoVentaAutoPartsOnDemandDataTablesBindingSource;
            // 
            // provinciaBindingSource1
            // 
            this.provinciaBindingSource1.DataSource = this.puntoVentaAutoPartsOnDemandDataTablesBindingSource;
            // 
            // familiaBindingSource
            // 
            this.familiaBindingSource.DataSource = this.puntoVentaAutoPartsOnDemandDataTablesBindingSource;
            // 
            // txt_nombre
            // 
            this.txt_nombre.BackColor = System.Drawing.Color.White;
            this.txt_nombre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_nombre.BackgroundImage")));
            this.txt_nombre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nombre.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_nombre.Icon = ((System.Drawing.Image)(resources.GetObject("txt_nombre.Icon")));
            this.txt_nombre.Location = new System.Drawing.Point(13, 71);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(274, 40);
            this.txt_nombre.TabIndex = 4;
            this.txt_nombre.text = "Nombre";
            this.txt_nombre.Enter += new System.EventHandler(this.txt_nombre_hint);
            this.txt_nombre.Leave += new System.EventHandler(this.txt_nombre_leave);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.Black;
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.DimGray;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "Agregar";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = false;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(435, 240);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.DimGray;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.DimGray;
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(150, 36);
            this.bunifuFlatButton1.TabIndex = 19;
            this.bunifuFlatButton1.Text = "Agregar";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Identificación";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 31);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ubicación";
            // 
            // txt_Ot_S
            // 
            this.txt_Ot_S.BackColor = System.Drawing.Color.White;
            this.txt_Ot_S.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_Ot_S.BackgroundImage")));
            this.txt_Ot_S.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txt_Ot_S.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Ot_S.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_Ot_S.Icon = ((System.Drawing.Image)(resources.GetObject("txt_Ot_S.Icon")));
            this.txt_Ot_S.Location = new System.Drawing.Point(311, 153);
            this.txt_Ot_S.Name = "txt_Ot_S";
            this.txt_Ot_S.Size = new System.Drawing.Size(274, 40);
            this.txt_Ot_S.TabIndex = 24;
            this.txt_Ot_S.text = "Otras señas";
            this.txt_Ot_S.Enter += new System.EventHandler(this.txt_Ot_S_e);
            this.txt_Ot_S.Leave += new System.EventHandler(this.txt_Ot_S_l);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 31);
            this.label3.TabIndex = 30;
            this.label3.Text = "Datos Generales";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_correo
            // 
            this.txt_correo.BackColor = System.Drawing.Color.White;
            this.txt_correo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_correo.BackgroundImage")));
            this.txt_correo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txt_correo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_correo.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_correo.Icon = ((System.Drawing.Image)(resources.GetObject("txt_correo.Icon")));
            this.txt_correo.Location = new System.Drawing.Point(13, 117);
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.Size = new System.Drawing.Size(274, 40);
            this.txt_correo.TabIndex = 39;
            this.txt_correo.text = "Correo";
            this.txt_correo.OnTextChange += new System.EventHandler(this.txt_correo_OnTextChange);
            this.txt_correo.Enter += new System.EventHandler(this.txt_correo_e);
            this.txt_correo.Leave += new System.EventHandler(this.txt_correo_l);
            // 
            // txt_ident_num
            // 
            this.txt_ident_num.BackColor = System.Drawing.Color.White;
            this.txt_ident_num.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_ident_num.BackgroundImage")));
            this.txt_ident_num.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txt_ident_num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ident_num.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_ident_num.Icon = ((System.Drawing.Image)(resources.GetObject("txt_ident_num.Icon")));
            this.txt_ident_num.Location = new System.Drawing.Point(13, 190);
            this.txt_ident_num.Name = "txt_ident_num";
            this.txt_ident_num.Size = new System.Drawing.Size(274, 40);
            this.txt_ident_num.TabIndex = 41;
            this.txt_ident_num.text = "Número";
            this.txt_ident_num.OnTextChange += new System.EventHandler(this.txt_ident_num_OnTextChange);
            this.txt_ident_num.Enter += new System.EventHandler(this.txt_ident_num_e);
            this.txt_ident_num.Leave += new System.EventHandler(this.txt_ident_num_l);
            // 
            // cb_emisor
            // 
            this.cb_emisor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cb_emisor.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.cb_emisor.Checked = false;
            this.cb_emisor.CheckedOnColor = System.Drawing.Color.Black;
            this.cb_emisor.ForeColor = System.Drawing.Color.White;
            this.cb_emisor.Location = new System.Drawing.Point(567, 204);
            this.cb_emisor.Name = "cb_emisor";
            this.cb_emisor.Size = new System.Drawing.Size(20, 20);
            this.cb_emisor.TabIndex = 43;
            this.cb_emisor.OnChange += new System.EventHandler(this.cb_emisor_OnChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(379, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "Registrar Como Emisor?";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cb_ident_tipo
            // 
            this.cb_ident_tipo.FormattingEnabled = true;
            this.cb_ident_tipo.Location = new System.Drawing.Point(122, 162);
            this.cb_ident_tipo.Name = "cb_ident_tipo";
            this.cb_ident_tipo.Size = new System.Drawing.Size(165, 21);
            this.cb_ident_tipo.TabIndex = 45;
            this.cb_ident_tipo.Text = "Tipo";
            // 
            // cb_Provincia
            // 
            this.cb_Provincia.FormattingEnabled = true;
            this.cb_Provincia.Location = new System.Drawing.Point(385, 71);
            this.cb_Provincia.Name = "cb_Provincia";
            this.cb_Provincia.Size = new System.Drawing.Size(200, 21);
            this.cb_Provincia.TabIndex = 46;
            this.cb_Provincia.SelectedIndexChanged += new System.EventHandler(this.cb_Provincia_SelectedIndexChanged);
            // 
            // cb_Canton
            // 
            this.cb_Canton.FormattingEnabled = true;
            this.cb_Canton.Location = new System.Drawing.Point(385, 98);
            this.cb_Canton.Name = "cb_Canton";
            this.cb_Canton.Size = new System.Drawing.Size(200, 21);
            this.cb_Canton.TabIndex = 47;
            this.cb_Canton.SelectedIndexChanged += new System.EventHandler(this.cb_Distrito_SelectedIndexChanged);
            // 
            // cb_Distrito
            // 
            this.cb_Distrito.FormattingEnabled = true;
            this.cb_Distrito.Location = new System.Drawing.Point(385, 125);
            this.cb_Distrito.Name = "cb_Distrito";
            this.cb_Distrito.Size = new System.Drawing.Size(200, 21);
            this.cb_Distrito.TabIndex = 48;
            this.cb_Distrito.SelectedIndexChanged += new System.EventHandler(this.cb_Distrito_SelectedIndexChanged_1);
            // 
            // Agregar
            // 
            this.Agregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Agregar.BackgroundImage")));
            this.Agregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Agregar.Controls.Add(this.label7);
            this.Agregar.Controls.Add(this.label6);
            this.Agregar.Controls.Add(this.label4);
            this.Agregar.Controls.Add(this.cb_Distrito);
            this.Agregar.Controls.Add(this.cb_Canton);
            this.Agregar.Controls.Add(this.cb_Provincia);
            this.Agregar.Controls.Add(this.cb_ident_tipo);
            this.Agregar.Controls.Add(this.label5);
            this.Agregar.Controls.Add(this.cb_emisor);
            this.Agregar.Controls.Add(this.txt_ident_num);
            this.Agregar.Controls.Add(this.txt_correo);
            this.Agregar.Controls.Add(this.label3);
            this.Agregar.Controls.Add(this.txt_Ot_S);
            this.Agregar.Controls.Add(this.label2);
            this.Agregar.Controls.Add(this.label1);
            this.Agregar.Controls.Add(this.bunifuFlatButton1);
            this.Agregar.Controls.Add(this.txt_nombre);
            this.Agregar.GradientBottomLeft = System.Drawing.Color.White;
            this.Agregar.GradientBottomRight = System.Drawing.Color.White;
            this.Agregar.GradientTopLeft = System.Drawing.Color.White;
            this.Agregar.GradientTopRight = System.Drawing.Color.White;
            this.Agregar.Location = new System.Drawing.Point(-1, 0);
            this.Agregar.Name = "Agregar";
            this.Agregar.Quality = 10;
            this.Agregar.Size = new System.Drawing.Size(1204, 586);
            this.Agregar.TabIndex = 0;
            this.Agregar.Paint += new System.Windows.Forms.PaintEventHandler(this.bunifuGradientPanel1_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(307, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 51;
            this.label7.Text = "Distrito";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(307, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 50;
            this.label6.Text = "Canton";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(307, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 49;
            this.label4.Text = "Provincia";
            // 
            // AgregarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 585);
            this.Controls.Add(this.Agregar);
            this.Name = "AgregarPersona";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarPersona";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AgregarPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.distritoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puntoVentaAutoPartsOnDemandDataTablesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantonBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiaBindingSource)).EndInit();
            this.Agregar.ResumeLayout(false);
            this.Agregar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuTextbox txt_ident_tipo;
        private System.Windows.Forms.BindingSource puntoVentaAutoPartsOnDemandDataTablesBindingSource;
        private System.Windows.Forms.BindingSource familiaBindingSource;
        private System.Windows.Forms.BindingSource provinciaBindingSource1;
        private System.Windows.Forms.BindingSource cantonBindingSource1;
        private System.Windows.Forms.BindingSource distritoBindingSource;
        private Bunifu.Framework.UI.BunifuTextbox txt_nombre;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuTextbox txt_Ot_S;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuTextbox txt_correo;
        private Bunifu.Framework.UI.BunifuTextbox txt_ident_num;
        private Bunifu.Framework.UI.BunifuCheckbox cb_emisor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_ident_tipo;
        private System.Windows.Forms.ComboBox cb_Provincia;
        private System.Windows.Forms.ComboBox cb_Canton;
        private System.Windows.Forms.ComboBox cb_Distrito;
        private Bunifu.Framework.UI.BunifuGradientPanel Agregar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}