namespace Restaurante_Presentacion
{
    partial class Administrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrador));
            this.bgUsuarios = new System.Windows.Forms.GroupBox();
            this.btnNuevoUsuario = new System.Windows.Forms.Button();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvUsuariosXtipo = new System.Windows.Forms.DataGridView();
            this.UsuarioId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tls_Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsNombreRest = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsWebHtml = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbMantenimiento = new System.Windows.Forms.GroupBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.chkNoActivo = new System.Windows.Forms.CheckBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.bgUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosXtipo)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.gbMantenimiento.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgUsuarios
            // 
            this.bgUsuarios.Controls.Add(this.btnNuevoUsuario);
            this.bgUsuarios.Controls.Add(this.cmbUsuarios);
            this.bgUsuarios.Controls.Add(this.label1);
            this.bgUsuarios.Controls.Add(this.dgvUsuariosXtipo);
            this.bgUsuarios.Location = new System.Drawing.Point(11, 56);
            this.bgUsuarios.Name = "bgUsuarios";
            this.bgUsuarios.Size = new System.Drawing.Size(397, 336);
            this.bgUsuarios.TabIndex = 9;
            this.bgUsuarios.TabStop = false;
            this.bgUsuarios.Text = "Usuarios del sistema";
            // 
            // btnNuevoUsuario
            // 
            this.btnNuevoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoUsuario.Location = new System.Drawing.Point(257, 294);
            this.btnNuevoUsuario.Name = "btnNuevoUsuario";
            this.btnNuevoUsuario.Size = new System.Drawing.Size(134, 36);
            this.btnNuevoUsuario.TabIndex = 17;
            this.btnNuevoUsuario.Text = "NUEVO";
            this.btnNuevoUsuario.UseVisualStyleBackColor = true;
            this.btnNuevoUsuario.Click += new System.EventHandler(this.btnNuevoUsuario_Click);
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.DisplayMember = "Descripcion";
            this.cmbUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(105, 24);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(286, 28);
            this.cmbUsuarios.TabIndex = 2;
            this.cmbUsuarios.ValueMember = "Id";
            this.cmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.cmbUsuarios_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo:";
            // 
            // dgvUsuariosXtipo
            // 
            this.dgvUsuariosXtipo.AllowUserToAddRows = false;
            this.dgvUsuariosXtipo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuariosXtipo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsuariosXtipo.ColumnHeadersHeight = 30;
            this.dgvUsuariosXtipo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsuarioId,
            this.Login,
            this.Modificar,
            this.Eliminar});
            this.dgvUsuariosXtipo.Location = new System.Drawing.Point(19, 58);
            this.dgvUsuariosXtipo.Name = "dgvUsuariosXtipo";
            this.dgvUsuariosXtipo.ReadOnly = true;
            this.dgvUsuariosXtipo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgvUsuariosXtipo.RowTemplate.Height = 30;
            this.dgvUsuariosXtipo.Size = new System.Drawing.Size(372, 230);
            this.dgvUsuariosXtipo.TabIndex = 0;
            this.dgvUsuariosXtipo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuariosXtipo_CellContentClick);
            // 
            // UsuarioId
            // 
            this.UsuarioId.DataPropertyName = "Id";
            this.UsuarioId.HeaderText = "UsuarioId";
            this.UsuarioId.Name = "UsuarioId";
            this.UsuarioId.ReadOnly = true;
            this.UsuarioId.Visible = false;
            // 
            // Login
            // 
            this.Login.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Login.DataPropertyName = "Login";
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            // 
            // Modificar
            // 
            this.Modificar.DataPropertyName = "Modificar";
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Modificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Eliminar
            // 
            this.Eliminar.DataPropertyName = "Eliminar";
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tls_Usuario,
            this.tlsNombreRest,
            this.tlsWebHtml,
            this.tlsFecha,
            this.tlsHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 472);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(734, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
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
            this.tls_Usuario.Size = new System.Drawing.Size(75, 19);
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
            this.tlsNombreRest.Size = new System.Drawing.Size(250, 19);
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
            this.tlsWebHtml.Size = new System.Drawing.Size(225, 19);
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
            // gbMantenimiento
            // 
            this.gbMantenimiento.Controls.Add(this.txtApellidos);
            this.gbMantenimiento.Controls.Add(this.label4);
            this.gbMantenimiento.Controls.Add(this.txtNombre);
            this.gbMantenimiento.Controls.Add(this.label5);
            this.gbMantenimiento.Controls.Add(this.btnGuardar);
            this.gbMantenimiento.Controls.Add(this.cmbRol);
            this.gbMantenimiento.Controls.Add(this.lblRol);
            this.gbMantenimiento.Controls.Add(this.chkNoActivo);
            this.gbMantenimiento.Controls.Add(this.chkActivo);
            this.gbMantenimiento.Controls.Add(this.txtPassword);
            this.gbMantenimiento.Controls.Add(this.label2);
            this.gbMantenimiento.Controls.Add(this.txtLogin);
            this.gbMantenimiento.Controls.Add(this.label3);
            this.gbMantenimiento.Location = new System.Drawing.Point(415, 56);
            this.gbMantenimiento.Name = "gbMantenimiento";
            this.gbMantenimiento.Size = new System.Drawing.Size(307, 298);
            this.gbMantenimiento.TabIndex = 11;
            this.gbMantenimiento.TabStop = false;
            this.gbMantenimiento.Text = "Mantenimiento Usuarios";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtApellidos.Location = new System.Drawing.Point(109, 60);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(180, 26);
            this.txtApellidos.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(7, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Apellidos:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNombre.Location = new System.Drawing.Point(109, 28);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 26);
            this.txtNombre.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(7, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Nombre:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(86, 252);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(134, 36);
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbRol
            // 
            this.cmbRol.DisplayMember = "Descripcion";
            this.cmbRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(109, 186);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(180, 28);
            this.cmbRol.TabIndex = 19;
            this.cmbRol.ValueMember = "Id";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblRol.Location = new System.Drawing.Point(9, 206);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(43, 20);
            this.lblRol.TabIndex = 18;
            this.lblRol.Text = "Tipo:";
            // 
            // chkNoActivo
            // 
            this.chkNoActivo.AutoSize = true;
            this.chkNoActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkNoActivo.Location = new System.Drawing.Point(109, 156);
            this.chkNoActivo.Name = "chkNoActivo";
            this.chkNoActivo.Size = new System.Drawing.Size(93, 24);
            this.chkNoActivo.TabIndex = 24;
            this.chkNoActivo.Text = "No activo";
            this.chkNoActivo.UseVisualStyleBackColor = true;
            this.chkNoActivo.CheckedChanged += new System.EventHandler(this.chkNoActivo_CheckedChanged);
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkActivo.Location = new System.Drawing.Point(13, 156);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(71, 24);
            this.chkActivo.TabIndex = 23;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            this.chkActivo.CheckedChanged += new System.EventHandler(this.chkActivo_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPassword.Location = new System.Drawing.Point(109, 124);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(180, 26);
            this.txtPassword.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(7, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Contraseña:";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtLogin.Location = new System.Drawing.Point(109, 92);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(180, 26);
            this.txtLogin.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(7, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Login:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(151, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(401, 32);
            this.lblTitulo.TabIndex = 30;
            this.lblTitulo.Text = "MÓDULO DE ADMINISTRADOR";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.bgUsuarios);
            this.panel1.Controls.Add(this.gbMantenimiento);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 471);
            this.panel1.TabIndex = 31;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.BackgroundImage")));
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(602, 360);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 100);
            this.btnCerrar.TabIndex = 98;
            this.btnCerrar.Text = "&C";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Administrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Administrador_Load);
            this.Resize += new System.EventHandler(this.Administrador_Resize);
            this.bgUsuarios.ResumeLayout(false);
            this.bgUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosXtipo)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbMantenimiento.ResumeLayout(false);
            this.gbMantenimiento.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox bgUsuarios;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tls_Usuario;
        private System.Windows.Forms.ToolStripStatusLabel tlsNombreRest;
        private System.Windows.Forms.ToolStripStatusLabel tlsWebHtml;
        private System.Windows.Forms.ToolStripStatusLabel tlsFecha;
        private System.Windows.Forms.ToolStripStatusLabel tlsHora;
        private System.Windows.Forms.GroupBox gbMantenimiento;
        private System.Windows.Forms.DataGridView dgvUsuariosXtipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.Button btnNuevoUsuario;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkNoActivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewLinkColumn Modificar;
        private System.Windows.Forms.DataGridViewLinkColumn Eliminar;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;

    }
}