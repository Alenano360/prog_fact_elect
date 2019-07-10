namespace PuntoVentaPresentacion
{
    partial class BitacoraInventario
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.C = new System.Windows.Forms.DataGridView();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadUnidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfecha = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.C)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(174, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(584, 45);
            this.lblTitulo.TabIndex = 106;
            this.lblTitulo.Text = "Bitacora de Movimientos de inventario";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 108;
            this.label1.Text = "MOVIMIENTO:";
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.BackColor = System.Drawing.SystemColors.Window;
            this.cmbOrdenar.DisplayMember = "Descripcion";
            this.cmbOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.IntegralHeight = false;
            this.cmbOrdenar.ItemHeight = 18;
            this.cmbOrdenar.Items.AddRange(new object[] {
            "--Seleccione--",
            "Codigo",
            "Descripcion",
            "Proveedor",
            "Familia",
            "Existencia",
            "Ultima Compra",
            "Precio",
            "Precio Final"});
            this.cmbOrdenar.Location = new System.Drawing.Point(140, 63);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(195, 26);
            this.cmbOrdenar.TabIndex = 107;
            this.cmbOrdenar.SelectedIndexChanged += new System.EventHandler(this.cmbOrdenar_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 109;
            this.label2.Text = "USUARIO:";
            // 
            // C
            // 
            this.C.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.C.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.id_producto,
            this.DescripcionProducto,
            this.cantidadUnidades,
            this.Nombre,
            this.fecha});
            this.C.Location = new System.Drawing.Point(36, 119);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(722, 241);
            this.C.TabIndex = 111;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Movimiento";
            this.Descripcion.Name = "Descripcion";
            // 
            // id_producto
            // 
            this.id_producto.DataPropertyName = "id_producto";
            this.id_producto.HeaderText = "Codigo Producto";
            this.id_producto.Name = "id_producto";
            // 
            // DescripcionProducto
            // 
            this.DescripcionProducto.DataPropertyName = "DescripcionProducto";
            this.DescripcionProducto.HeaderText = "Descripcion";
            this.DescripcionProducto.Name = "DescripcionProducto";
            this.DescripcionProducto.Width = 130;
            // 
            // cantidadUnidades
            // 
            this.cantidadUnidades.DataPropertyName = "cantidadUnidades";
            this.cantidadUnidades.HeaderText = "Cantidad";
            this.cantidadUnidades.Name = "cantidadUnidades";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Usuario";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 130;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.HeaderText = "fecha";
            this.fecha.Name = "fecha";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.CerrarIcono;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(638, 366);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 100);
            this.btnCerrar.TabIndex = 112;
            this.btnCerrar.Text = "&C";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cmbUser
            // 
            this.cmbUser.BackColor = System.Drawing.SystemColors.Window;
            this.cmbUser.DisplayMember = "Nombre";
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.IntegralHeight = false;
            this.cmbUser.ItemHeight = 18;
            this.cmbUser.Items.AddRange(new object[] {
            "--Seleccione--",
            "Codigo",
            "Descripcion",
            "Proveedor",
            "Familia",
            "Existencia",
            "Ultima Compra",
            "Precio",
            "Precio Final"});
            this.cmbUser.Location = new System.Drawing.Point(418, 65);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(195, 26);
            this.cmbUser.TabIndex = 113;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(619, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 114;
            this.label3.Text = "Fecha:";
            // 
            // txtfecha
            // 
            this.txtfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtfecha.Location = new System.Drawing.Point(680, 67);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(125, 24);
            this.txtfecha.TabIndex = 115;
            this.txtfecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfecha_KeyDown);
            this.txtfecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfecha_KeyPress);
            // 
            // BitacoraInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 478);
            this.Controls.Add(this.txtfecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.C);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOrdenar);
            this.Controls.Add(this.lblTitulo);
            this.Name = "BitacoraInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BitacoraInventario";
            this.Load += new System.EventHandler(this.BitacoraInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.C)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView C;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadUnidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtfecha;
    }
}