namespace Restaurante_Presentacion
{
    partial class Reporte_Electronico
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numeroFacturaLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xMLFacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoFacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canceladaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.enviadaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_FacturaElectronica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_TiqueteElectronico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkEnv = new System.Windows.Forms.CheckBox();
            this.btnEnviar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lb_hasta = new System.Windows.Forms.Label();
            this.lb_desde = new System.Windows.Forms.Label();
            this.cbDateHasta = new System.Windows.Forms.DateTimePicker();
            this.cbDateDesde = new System.Windows.Forms.DateTimePicker();
            this.txt_monto_total = new System.Windows.Forms.Label();
            this.txt_lbMonto = new System.Windows.Forms.Label();
            this.chk_t_fact = new System.Windows.Forms.CheckBox();
            this.chk_t_tiquete = new System.Windows.Forms.CheckBox();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.chk_cancelar = new System.Windows.Forms.CheckBox();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroFacturaLocalDataGridViewTextBoxColumn,
            this.xMLFacturaDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.montoFacturaDataGridViewTextBoxColumn,
            this.canceladaDataGridViewCheckBoxColumn,
            this.enviadaDataGridViewCheckBoxColumn,
            this.id_FacturaElectronica,
            this.id_TiqueteElectronico});
            this.dataGridView1.Location = new System.Drawing.Point(34, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(853, 369);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // numeroFacturaLocalDataGridViewTextBoxColumn
            // 
            this.numeroFacturaLocalDataGridViewTextBoxColumn.DataPropertyName = "Numero_Factura_Local";
            this.numeroFacturaLocalDataGridViewTextBoxColumn.HeaderText = "# Factura Local";
            this.numeroFacturaLocalDataGridViewTextBoxColumn.Name = "numeroFacturaLocalDataGridViewTextBoxColumn";
            this.numeroFacturaLocalDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroFacturaLocalDataGridViewTextBoxColumn.Width = 150;
            // 
            // xMLFacturaDataGridViewTextBoxColumn
            // 
            this.xMLFacturaDataGridViewTextBoxColumn.DataPropertyName = "XML_Factura";
            this.xMLFacturaDataGridViewTextBoxColumn.HeaderText = "Datos";
            this.xMLFacturaDataGridViewTextBoxColumn.Name = "xMLFacturaDataGridViewTextBoxColumn";
            this.xMLFacturaDataGridViewTextBoxColumn.ReadOnly = true;
            this.xMLFacturaDataGridViewTextBoxColumn.Width = 200;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 130;
            // 
            // montoFacturaDataGridViewTextBoxColumn
            // 
            this.montoFacturaDataGridViewTextBoxColumn.DataPropertyName = "Monto_Factura";
            this.montoFacturaDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoFacturaDataGridViewTextBoxColumn.Name = "montoFacturaDataGridViewTextBoxColumn";
            this.montoFacturaDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoFacturaDataGridViewTextBoxColumn.Width = 150;
            // 
            // canceladaDataGridViewCheckBoxColumn
            // 
            this.canceladaDataGridViewCheckBoxColumn.DataPropertyName = "Cancelada";
            this.canceladaDataGridViewCheckBoxColumn.HeaderText = "Cancelada";
            this.canceladaDataGridViewCheckBoxColumn.Name = "canceladaDataGridViewCheckBoxColumn";
            this.canceladaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // enviadaDataGridViewCheckBoxColumn
            // 
            this.enviadaDataGridViewCheckBoxColumn.DataPropertyName = "Enviada";
            this.enviadaDataGridViewCheckBoxColumn.HeaderText = "Enviada";
            this.enviadaDataGridViewCheckBoxColumn.Name = "enviadaDataGridViewCheckBoxColumn";
            this.enviadaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // id_FacturaElectronica
            // 
            this.id_FacturaElectronica.DataPropertyName = "id_FacturaElectronica";
            this.id_FacturaElectronica.HeaderText = "id_FacturaElectronica";
            this.id_FacturaElectronica.Name = "id_FacturaElectronica";
            this.id_FacturaElectronica.ReadOnly = true;
            this.id_FacturaElectronica.Visible = false;
            // 
            // id_TiqueteElectronico
            // 
            this.id_TiqueteElectronico.DataPropertyName = "id_TiqueteElectronico";
            this.id_TiqueteElectronico.HeaderText = "id_TiqueteElectronico";
            this.id_TiqueteElectronico.Name = "id_TiqueteElectronico";
            this.id_TiqueteElectronico.ReadOnly = true;
            this.id_TiqueteElectronico.Visible = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(30, 384);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(143, 20);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "Filtrar reportes por:";
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Checked = true;
            this.chkDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDate.Location = new System.Drawing.Point(179, 429);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(93, 20);
            this.chkDate.TabIndex = 3;
            this.chkDate.Text = "Aceptadas";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // chkEnv
            // 
            this.chkEnv.AutoSize = true;
            this.chkEnv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnv.Location = new System.Drawing.Point(278, 429);
            this.chkEnv.Name = "chkEnv";
            this.chkEnv.Size = new System.Drawing.Size(105, 20);
            this.chkEnv.TabIndex = 4;
            this.chkEnv.Text = "No Enviadas";
            this.chkEnv.UseVisualStyleBackColor = true;
            this.chkEnv.CheckedChanged += new System.EventHandler(this.chkEnv_CheckedChanged);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Activecolor = System.Drawing.Color.DarkGray;
            this.btnEnviar.BackColor = System.Drawing.Color.DarkGray;
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnviar.BorderRadius = 0;
            this.btnEnviar.ButtonText = "Re enviar tiquetes";
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.DisabledColor = System.Drawing.Color.Gray;
            this.btnEnviar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEnviar.Iconimage = null;
            this.btnEnviar.Iconimage_right = null;
            this.btnEnviar.Iconimage_right_Selected = null;
            this.btnEnviar.Iconimage_Selected = null;
            this.btnEnviar.IconMarginLeft = 0;
            this.btnEnviar.IconMarginRight = 0;
            this.btnEnviar.IconRightVisible = true;
            this.btnEnviar.IconRightZoom = 0D;
            this.btnEnviar.IconVisible = true;
            this.btnEnviar.IconZoom = 90D;
            this.btnEnviar.IsTab = false;
            this.btnEnviar.Location = new System.Drawing.Point(646, 390);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Normalcolor = System.Drawing.Color.DarkGray;
            this.btnEnviar.OnHovercolor = System.Drawing.Color.DarkGray;
            this.btnEnviar.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.btnEnviar.selected = false;
            this.btnEnviar.Size = new System.Drawing.Size(241, 48);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "Re enviar tiquetes";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEnviar.Textcolor = System.Drawing.Color.White;
            this.btnEnviar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Visible = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lb_hasta
            // 
            this.lb_hasta.AutoSize = true;
            this.lb_hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hasta.Location = new System.Drawing.Point(420, 437);
            this.lb_hasta.Name = "lb_hasta";
            this.lb_hasta.Size = new System.Drawing.Size(56, 20);
            this.lb_hasta.TabIndex = 16;
            this.lb_hasta.Text = "Hasta:";
            // 
            // lb_desde
            // 
            this.lb_desde.AutoSize = true;
            this.lb_desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_desde.Location = new System.Drawing.Point(420, 384);
            this.lb_desde.Name = "lb_desde";
            this.lb_desde.Size = new System.Drawing.Size(64, 20);
            this.lb_desde.TabIndex = 15;
            this.lb_desde.Text = "Desde: ";
            this.lb_desde.Click += new System.EventHandler(this.lb_desde_Click);
            // 
            // cbDateHasta
            // 
            this.cbDateHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cbDateHasta.Location = new System.Drawing.Point(424, 460);
            this.cbDateHasta.Name = "cbDateHasta";
            this.cbDateHasta.Size = new System.Drawing.Size(200, 26);
            this.cbDateHasta.TabIndex = 17;
            this.cbDateHasta.ValueChanged += new System.EventHandler(this.cbDateHasta_ValueChanged);
            // 
            // cbDateDesde
            // 
            this.cbDateDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cbDateDesde.Location = new System.Drawing.Point(424, 408);
            this.cbDateDesde.Name = "cbDateDesde";
            this.cbDateDesde.Size = new System.Drawing.Size(200, 26);
            this.cbDateDesde.TabIndex = 18;
            this.cbDateDesde.ValueChanged += new System.EventHandler(this.cbDateDesde_ValueChanged);
            // 
            // txt_monto_total
            // 
            this.txt_monto_total.AutoSize = true;
            this.txt_monto_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_monto_total.Location = new System.Drawing.Point(863, 465);
            this.txt_monto_total.Name = "txt_monto_total";
            this.txt_monto_total.Size = new System.Drawing.Size(24, 25);
            this.txt_monto_total.TabIndex = 20;
            this.txt_monto_total.Text = "0";
            // 
            // txt_lbMonto
            // 
            this.txt_lbMonto.AutoSize = true;
            this.txt_lbMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lbMonto.Location = new System.Drawing.Point(641, 444);
            this.txt_lbMonto.Name = "txt_lbMonto";
            this.txt_lbMonto.Size = new System.Drawing.Size(132, 25);
            this.txt_lbMonto.TabIndex = 19;
            this.txt_lbMonto.Text = "Monto Total:";
            // 
            // chk_t_fact
            // 
            this.chk_t_fact.AutoSize = true;
            this.chk_t_fact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_t_fact.Location = new System.Drawing.Point(258, 387);
            this.chk_t_fact.Name = "chk_t_fact";
            this.chk_t_fact.Size = new System.Drawing.Size(72, 20);
            this.chk_t_fact.TabIndex = 21;
            this.chk_t_fact.Text = "Factura";
            this.chk_t_fact.UseVisualStyleBackColor = true;
            this.chk_t_fact.CheckedChanged += new System.EventHandler(this.chk_t_fact_CheckedChanged);
            // 
            // chk_t_tiquete
            // 
            this.chk_t_tiquete.AutoSize = true;
            this.chk_t_tiquete.Checked = true;
            this.chk_t_tiquete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_t_tiquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_t_tiquete.Location = new System.Drawing.Point(179, 390);
            this.chk_t_tiquete.Name = "chk_t_tiquete";
            this.chk_t_tiquete.Size = new System.Drawing.Size(73, 20);
            this.chk_t_tiquete.TabIndex = 22;
            this.chk_t_tiquete.Text = "Tiquete";
            this.chk_t_tiquete.UseVisualStyleBackColor = true;
            this.chk_t_tiquete.CheckedChanged += new System.EventHandler(this.chk_t_tiquet_CheckedChanged);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(179, 413);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(196, 10);
            this.bunifuSeparator1.TabIndex = 23;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // chk_cancelar
            // 
            this.chk_cancelar.AutoSize = true;
            this.chk_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_cancelar.Location = new System.Drawing.Point(179, 471);
            this.chk_cancelar.Name = "chk_cancelar";
            this.chk_cancelar.Size = new System.Drawing.Size(196, 20);
            this.chk_cancelar.TabIndex = 24;
            this.chk_cancelar.Text = "Canceladas / No aceptadas";
            this.chk_cancelar.UseVisualStyleBackColor = true;
            this.chk_cancelar.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(179, 455);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(201, 10);
            this.bunifuSeparator2.TabIndex = 25;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // Reporte_Electronico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 498);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.chk_cancelar);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.chk_t_tiquete);
            this.Controls.Add(this.chk_t_fact);
            this.Controls.Add(this.txt_monto_total);
            this.Controls.Add(this.txt_lbMonto);
            this.Controls.Add(this.cbDateDesde);
            this.Controls.Add(this.cbDateHasta);
            this.Controls.Add(this.lb_hasta);
            this.Controls.Add(this.lb_desde);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.chkEnv);
            this.Controls.Add(this.chkDate);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Reporte_Electronico";
            this.ShowIcon = false;
            this.Text = "Reporte_Electronico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reporte_Electronico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkEnv;
        private Bunifu.Framework.UI.BunifuFlatButton btnEnviar;
        private System.Windows.Forms.Label lb_hasta;
        private System.Windows.Forms.Label lb_desde;
        private System.Windows.Forms.DateTimePicker cbDateHasta;
        private System.Windows.Forms.DateTimePicker cbDateDesde;
        private System.Windows.Forms.Label txt_monto_total;
        private System.Windows.Forms.Label txt_lbMonto;
        private System.Windows.Forms.CheckBox chk_t_fact;
        private System.Windows.Forms.CheckBox chk_t_tiquete;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroFacturaLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xMLFacturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoFacturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canceladaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enviadaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_FacturaElectronica;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_TiqueteElectronico;
        private System.Windows.Forms.CheckBox chk_cancelar;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
    }
}