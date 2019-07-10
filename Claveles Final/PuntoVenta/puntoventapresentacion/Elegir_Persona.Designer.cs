namespace PuntoVentaPresentacion
{
    partial class Elegir_Persona
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_personas = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoElectronico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ident_Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receptor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Emisor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ubi_Provicia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubi_Canton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubi_Distrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubi_OtrasSenas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel_CodigoPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel_NumeroTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax_CodigoPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax_NumeroTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_Persona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreComercial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_personas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_personas
            // 
            this.dgv_personas.AllowUserToAddRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_personas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_personas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_personas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Cedula,
            this.CorreoElectronico,
            this.Ident_Tipo,
            this.Rol,
            this.Receptor,
            this.Emisor,
            this.Ubi_Provicia,
            this.Ubi_Canton,
            this.Ubi_Distrito,
            this.Ubi_OtrasSenas,
            this.Tel_CodigoPais,
            this.Tel_NumeroTelefono,
            this.Fax_CodigoPais,
            this.Fax_NumeroTelefono,
            this.id_Persona,
            this.NombreComercial});
            this.dgv_personas.Location = new System.Drawing.Point(78, 12);
            this.dgv_personas.MultiSelect = false;
            this.dgv_personas.Name = "dgv_personas";
            this.dgv_personas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_personas.Size = new System.Drawing.Size(445, 250);
            this.dgv_personas.TabIndex = 95;
            this.dgv_personas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgv_personas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Elegir_Persona_CellDoubleClick);
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Cedula
            // 
            this.Cedula.DataPropertyName = "Ident_Numero";
            this.Cedula.HeaderText = "Cedula";
            this.Cedula.Name = "Cedula";
            // 
            // CorreoElectronico
            // 
            this.CorreoElectronico.DataPropertyName = "CorreoElectronico";
            this.CorreoElectronico.HeaderText = "CorreoElectronico";
            this.CorreoElectronico.Name = "CorreoElectronico";
            this.CorreoElectronico.Width = 200;
            // 
            // Ident_Tipo
            // 
            this.Ident_Tipo.DataPropertyName = "Ident_Tipo";
            this.Ident_Tipo.HeaderText = "Ident_Tipo";
            this.Ident_Tipo.Name = "Ident_Tipo";
            this.Ident_Tipo.Visible = false;
            // 
            // Rol
            // 
            this.Rol.DataPropertyName = "Rol";
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.Visible = false;
            // 
            // Receptor
            // 
            this.Receptor.DataPropertyName = "Receptor";
            this.Receptor.HeaderText = "Receptor";
            this.Receptor.Name = "Receptor";
            this.Receptor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Receptor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Receptor.Visible = false;
            // 
            // Emisor
            // 
            this.Emisor.DataPropertyName = "Emisor";
            this.Emisor.HeaderText = "Emisor";
            this.Emisor.Name = "Emisor";
            this.Emisor.Visible = false;
            // 
            // Ubi_Provicia
            // 
            this.Ubi_Provicia.DataPropertyName = "Ubi_Provicia";
            this.Ubi_Provicia.HeaderText = "Ubi_Provicia";
            this.Ubi_Provicia.Name = "Ubi_Provicia";
            this.Ubi_Provicia.Visible = false;
            // 
            // Ubi_Canton
            // 
            this.Ubi_Canton.DataPropertyName = "Ubi_Canton";
            this.Ubi_Canton.HeaderText = "Ubi_Canton";
            this.Ubi_Canton.Name = "Ubi_Canton";
            this.Ubi_Canton.Visible = false;
            // 
            // Ubi_Distrito
            // 
            this.Ubi_Distrito.DataPropertyName = "Ubi_Distrito";
            this.Ubi_Distrito.HeaderText = "Ubi_Distrito";
            this.Ubi_Distrito.Name = "Ubi_Distrito";
            this.Ubi_Distrito.Visible = false;
            // 
            // Ubi_OtrasSenas
            // 
            this.Ubi_OtrasSenas.DataPropertyName = "Ubi_OtrasSenas";
            this.Ubi_OtrasSenas.HeaderText = "Ubi_OtrasSenas";
            this.Ubi_OtrasSenas.Name = "Ubi_OtrasSenas";
            this.Ubi_OtrasSenas.Visible = false;
            // 
            // Tel_CodigoPais
            // 
            this.Tel_CodigoPais.DataPropertyName = "Tel_CodigoPais";
            this.Tel_CodigoPais.HeaderText = "Tel_CodigoPais";
            this.Tel_CodigoPais.Name = "Tel_CodigoPais";
            this.Tel_CodigoPais.Visible = false;
            // 
            // Tel_NumeroTelefono
            // 
            this.Tel_NumeroTelefono.DataPropertyName = "Tel_NumeroTelefono";
            this.Tel_NumeroTelefono.HeaderText = "Tel_NumeroTelefono";
            this.Tel_NumeroTelefono.Name = "Tel_NumeroTelefono";
            this.Tel_NumeroTelefono.Visible = false;
            // 
            // Fax_CodigoPais
            // 
            this.Fax_CodigoPais.DataPropertyName = "Fax_CodigoPais";
            this.Fax_CodigoPais.HeaderText = "Fax_CodigoPais";
            this.Fax_CodigoPais.Name = "Fax_CodigoPais";
            this.Fax_CodigoPais.Visible = false;
            // 
            // Fax_NumeroTelefono
            // 
            this.Fax_NumeroTelefono.DataPropertyName = "Fax_NumeroTelefono";
            this.Fax_NumeroTelefono.HeaderText = "Fax_NumeroTelefono";
            this.Fax_NumeroTelefono.Name = "Fax_NumeroTelefono";
            this.Fax_NumeroTelefono.Visible = false;
            // 
            // id_Persona
            // 
            this.id_Persona.DataPropertyName = "id_Persona";
            this.id_Persona.HeaderText = "id_Persona";
            this.id_Persona.Name = "id_Persona";
            this.id_Persona.Visible = false;
            // 
            // NombreComercial
            // 
            this.NombreComercial.DataPropertyName = "NombreComercial";
            this.NombreComercial.HeaderText = "NombreComercial";
            this.NombreComercial.Name = "NombreComercial";
            this.NombreComercial.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(319, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 48);
            this.button1.TabIndex = 97;
            this.button1.Text = "Elegir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(319, 322);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 48);
            this.button2.TabIndex = 98;
            this.button2.Text = "Nuevo";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Elegir_Persona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 404);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_personas);
            this.Name = "Elegir_Persona";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elegir_Persona";
            this.Load += new System.EventHandler(this.Elegir_Persona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_personas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_personas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorreoElectronico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ident_Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Receptor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Emisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubi_Provicia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubi_Canton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubi_Distrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubi_OtrasSenas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel_CodigoPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel_NumeroTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax_CodigoPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax_NumeroTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Persona;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreComercial;
        private System.Windows.Forms.Button button2;
    }
}