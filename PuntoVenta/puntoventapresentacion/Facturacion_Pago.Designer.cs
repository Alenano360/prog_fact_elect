namespace PuntoVentaPresentacion
{
    partial class Facturacion_Pago
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
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPagaCon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkImprimeTicket = new System.Windows.Forms.CheckBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkVentaCredito = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbMuestraCambio = new System.Windows.Forms.GroupBox();
            this.lblCambioMostrar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumTarjeta = new System.Windows.Forms.TextBox();
            this.txtTipoCambio = new System.Windows.Forms.TextBox();
            this.txtTotalD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscaCliente = new System.Windows.Forms.Button();
            this.txtNotasCredito = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTarjetaCredito = new System.Windows.Forms.TextBox();
            this.chkTarjetaCredito = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEmitirFactura = new System.Windows.Forms.Button();
            this.chk_Factura_Elect = new System.Windows.Forms.CheckBox();
            this.chkFactura_Electronica = new System.Windows.Forms.CheckBox();
            this.btn_cliente = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbMuestraCambio.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(205, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(235, 45);
            this.lblTitulo.TabIndex = 91;
            this.lblTitulo.Text = "FACTURACIÓN";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(15, 115);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(316, 50);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.Text = "0.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(15, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 31);
            this.label11.TabIndex = 92;
            this.label11.Text = "TOTAL";
            // 
            // txtPagaCon
            // 
            this.txtPagaCon.BackColor = System.Drawing.Color.White;
            this.txtPagaCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.txtPagaCon.Location = new System.Drawing.Point(15, 202);
            this.txtPagaCon.Name = "txtPagaCon";
            this.txtPagaCon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPagaCon.Size = new System.Drawing.Size(316, 50);
            this.txtPagaCon.TabIndex = 2;
            this.txtPagaCon.Text = "0.00";
            this.txtPagaCon.TextChanged += new System.EventHandler(this.txtPagaCon_TextChanged);
            this.txtPagaCon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPagaCon_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(93, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 31);
            this.label1.TabIndex = 94;
            this.label1.Text = "PAGA CON";
            // 
            // txtCambio
            // 
            this.txtCambio.BackColor = System.Drawing.Color.White;
            this.txtCambio.Enabled = false;
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.txtCambio.Location = new System.Drawing.Point(337, 202);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCambio.Size = new System.Drawing.Size(316, 50);
            this.txtCambio.TabIndex = 100;
            this.txtCambio.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(415, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 31);
            this.label2.TabIndex = 96;
            this.label2.Text = "SU CAMBIO";
            // 
            // chkImprimeTicket
            // 
            this.chkImprimeTicket.AutoSize = true;
            this.chkImprimeTicket.Checked = true;
            this.chkImprimeTicket.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImprimeTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.chkImprimeTicket.Location = new System.Drawing.Point(417, 605);
            this.chkImprimeTicket.Name = "chkImprimeTicket";
            this.chkImprimeTicket.Size = new System.Drawing.Size(157, 24);
            this.chkImprimeTicket.TabIndex = 100;
            this.chkImprimeTicket.Text = "Imprimir Tiquete";
            this.chkImprimeTicket.UseVisualStyleBackColor = true;
            this.chkImprimeTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkImprimeTicket_KeyDown);
            this.chkImprimeTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkImprimeTicket_KeyPress);
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.White;
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.txtSaldo.Location = new System.Drawing.Point(15, 464);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSaldo.Size = new System.Drawing.Size(316, 50);
            this.txtSaldo.TabIndex = 100;
            this.txtSaldo.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(118, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 31);
            this.label3.TabIndex = 100;
            this.label3.Text = "SALDO";
            // 
            // chkVentaCredito
            // 
            this.chkVentaCredito.AutoSize = true;
            this.chkVentaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.chkVentaCredito.Location = new System.Drawing.Point(417, 515);
            this.chkVentaCredito.Name = "chkVentaCredito";
            this.chkVentaCredito.Size = new System.Drawing.Size(154, 24);
            this.chkVentaCredito.TabIndex = 100;
            this.chkVentaCredito.Text = "Venta a Crédito";
            this.chkVentaCredito.UseVisualStyleBackColor = true;
            this.chkVentaCredito.CheckedChanged += new System.EventHandler(this.chkVentaCredito_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbMuestraCambio);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtNumTarjeta);
            this.panel1.Controls.Add(this.txtTipoCambio);
            this.panel1.Controls.Add(this.txtTotalD);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnBuscaCliente);
            this.panel1.Controls.Add(this.txtNotasCredito);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTarjetaCredito);
            this.panel1.Controls.Add(this.chkTarjetaCredito);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.chkVentaCredito);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.btnEmitirFactura);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSaldo);
            this.panel1.Controls.Add(this.txtPagaCon);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkImprimeTicket);
            this.panel1.Controls.Add(this.txtCambio);
            this.panel1.Controls.Add(this.chk_Factura_Elect);
            this.panel1.Controls.Add(this.chkFactura_Electronica);
            this.panel1.Controls.Add(this.btn_cliente);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 631);
            this.panel1.TabIndex = 105;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // gbMuestraCambio
            // 
            this.gbMuestraCambio.Controls.Add(this.lblCambioMostrar);
            this.gbMuestraCambio.Controls.Add(this.label4);
            this.gbMuestraCambio.Location = new System.Drawing.Point(0, 0);
            this.gbMuestraCambio.Name = "gbMuestraCambio";
            this.gbMuestraCambio.Size = new System.Drawing.Size(775, 491);
            this.gbMuestraCambio.TabIndex = 108;
            this.gbMuestraCambio.TabStop = false;
            this.gbMuestraCambio.Visible = false;
            this.gbMuestraCambio.Enter += new System.EventHandler(this.gbMuestraCambio_Enter);
            // 
            // lblCambioMostrar
            // 
            this.lblCambioMostrar.BackColor = System.Drawing.Color.Transparent;
            this.lblCambioMostrar.Font = new System.Drawing.Font("Segoe UI Semibold", 75F, System.Drawing.FontStyle.Bold);
            this.lblCambioMostrar.Location = new System.Drawing.Point(11, 271);
            this.lblCambioMostrar.Name = "lblCambioMostrar";
            this.lblCambioMostrar.Size = new System.Drawing.Size(644, 131);
            this.lblCambioMostrar.TabIndex = 110;
            this.lblCambioMostrar.Text = "SU CAMBIO:";
            this.lblCambioMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCambioMostrar.Click += new System.EventHandler(this.lblCambioMostrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 50F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(116, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(415, 89);
            this.label4.TabIndex = 109;
            this.label4.Text = "SU CAMBIO:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(334, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 31);
            this.label8.TabIndex = 115;
            this.label8.Text = "NUM.";
            // 
            // txtNumTarjeta
            // 
            this.txtNumTarjeta.BackColor = System.Drawing.Color.White;
            this.txtNumTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.txtNumTarjeta.Location = new System.Drawing.Point(340, 289);
            this.txtNumTarjeta.Name = "txtNumTarjeta";
            this.txtNumTarjeta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumTarjeta.Size = new System.Drawing.Size(159, 50);
            this.txtNumTarjeta.TabIndex = 114;
            this.txtNumTarjeta.Text = "0";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.BackColor = System.Drawing.Color.White;
            this.txtTipoCambio.Enabled = false;
            this.txtTipoCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.txtTipoCambio.Location = new System.Drawing.Point(533, 60);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.ReadOnly = true;
            this.txtTipoCambio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTipoCambio.Size = new System.Drawing.Size(120, 50);
            this.txtTipoCambio.TabIndex = 113;
            this.txtTipoCambio.Text = "0.00";
            this.txtTipoCambio.Visible = false;
            // 
            // txtTotalD
            // 
            this.txtTotalD.BackColor = System.Drawing.Color.White;
            this.txtTotalD.Enabled = false;
            this.txtTotalD.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.txtTotalD.Location = new System.Drawing.Point(337, 115);
            this.txtTotalD.Name = "txtTotalD";
            this.txtTotalD.ReadOnly = true;
            this.txtTotalD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalD.Size = new System.Drawing.Size(316, 50);
            this.txtTotalD.TabIndex = 112;
            this.txtTotalD.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(334, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 31);
            this.label7.TabIndex = 111;
            this.label7.Text = "TOTAL $";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnBuscaCliente
            // 
            this.btnBuscaCliente.Location = new System.Drawing.Point(337, 376);
            this.btnBuscaCliente.Name = "btnBuscaCliente";
            this.btnBuscaCliente.Size = new System.Drawing.Size(50, 50);
            this.btnBuscaCliente.TabIndex = 5;
            this.btnBuscaCliente.Text = "...";
            this.btnBuscaCliente.UseVisualStyleBackColor = true;
            this.btnBuscaCliente.Click += new System.EventHandler(this.btnBuscaCliente_Click);
            // 
            // txtNotasCredito
            // 
            this.txtNotasCredito.BackColor = System.Drawing.Color.White;
            this.txtNotasCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.txtNotasCredito.Location = new System.Drawing.Point(15, 376);
            this.txtNotasCredito.Name = "txtNotasCredito";
            this.txtNotasCredito.ReadOnly = true;
            this.txtNotasCredito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNotasCredito.Size = new System.Drawing.Size(316, 50);
            this.txtNotasCredito.TabIndex = 4;
            this.txtNotasCredito.Text = "0.00";
            this.txtNotasCredito.TextChanged += new System.EventHandler(this.txtNotasCredito_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(23, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(300, 31);
            this.label6.TabIndex = 110;
            this.label6.Text = "NOTAS DE CRÉDITO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(32, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(282, 31);
            this.label5.TabIndex = 109;
            this.label5.Text = "TARJETA CRÉDITO";
            // 
            // txtTarjetaCredito
            // 
            this.txtTarjetaCredito.BackColor = System.Drawing.Color.White;
            this.txtTarjetaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.txtTarjetaCredito.Location = new System.Drawing.Point(15, 289);
            this.txtTarjetaCredito.Name = "txtTarjetaCredito";
            this.txtTarjetaCredito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTarjetaCredito.Size = new System.Drawing.Size(316, 50);
            this.txtTarjetaCredito.TabIndex = 3;
            this.txtTarjetaCredito.Text = "0.00";
            this.txtTarjetaCredito.TextChanged += new System.EventHandler(this.txtTarjetaCredito_TextChanged);
            this.txtTarjetaCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTarjetaCredito_KeyDown);
            // 
            // chkTarjetaCredito
            // 
            this.chkTarjetaCredito.AutoSize = true;
            this.chkTarjetaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.chkTarjetaCredito.Location = new System.Drawing.Point(417, 485);
            this.chkTarjetaCredito.Name = "chkTarjetaCredito";
            this.chkTarjetaCredito.Size = new System.Drawing.Size(147, 24);
            this.chkTarjetaCredito.TabIndex = 100;
            this.chkTarjetaCredito.Text = "Tarjeta Crédito";
            this.chkTarjetaCredito.UseVisualStyleBackColor = true;
            this.chkTarjetaCredito.Visible = false;
            this.chkTarjetaCredito.CheckedChanged += new System.EventHandler(this.chkTarjetaCredito_CheckedChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(486, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(167, 49);
            this.label15.TabIndex = 106;
            this.label15.Text = "F1-PAGA CON\r\nF5-EMITIR FACTURA\r\nF9-SALIR\r\n";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.CerrarIcono;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(12, 520);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 100);
            this.btnCerrar.TabIndex = 90;
            this.btnCerrar.Text = "&C";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEmitirFactura
            // 
            this.btnEmitirFactura.BackColor = System.Drawing.SystemColors.Control;
            this.btnEmitirFactura.BackgroundImage = global::PuntoVentaPresentacion.Properties.Resources.EmitirIcono;
            this.btnEmitirFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmitirFactura.FlatAppearance.BorderSize = 0;
            this.btnEmitirFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmitirFactura.ForeColor = System.Drawing.Color.Black;
            this.btnEmitirFactura.Location = new System.Drawing.Point(670, 538);
            this.btnEmitirFactura.Name = "btnEmitirFactura";
            this.btnEmitirFactura.Size = new System.Drawing.Size(91, 82);
            this.btnEmitirFactura.TabIndex = 4;
            this.btnEmitirFactura.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEmitirFactura.UseVisualStyleBackColor = false;
            this.btnEmitirFactura.Click += new System.EventHandler(this.btnEmitirFactura_Click);
            // 
            // chk_Factura_Elect
            // 
            this.chk_Factura_Elect.AutoSize = true;
            this.chk_Factura_Elect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.chk_Factura_Elect.Location = new System.Drawing.Point(417, 544);
            this.chk_Factura_Elect.Name = "chk_Factura_Elect";
            this.chk_Factura_Elect.Size = new System.Drawing.Size(185, 24);
            this.chk_Factura_Elect.TabIndex = 118;
            this.chk_Factura_Elect.Text = "Factura Electrónica";
            this.chk_Factura_Elect.UseVisualStyleBackColor = true;
            this.chk_Factura_Elect.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkFactura_Electronica
            // 
            this.chkFactura_Electronica.AutoSize = true;
            this.chkFactura_Electronica.Checked = true;
            this.chkFactura_Electronica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFactura_Electronica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.chkFactura_Electronica.Location = new System.Drawing.Point(417, 574);
            this.chkFactura_Electronica.Name = "chkFactura_Electronica";
            this.chkFactura_Electronica.Size = new System.Drawing.Size(189, 24);
            this.chkFactura_Electronica.TabIndex = 116;
            this.chkFactura_Electronica.Text = "Reporte a Hacienda";
            this.chkFactura_Electronica.UseVisualStyleBackColor = true;
            this.chkFactura_Electronica.CheckedChanged += new System.EventHandler(this.chkFactura_Electronica_CheckedChanged);
            // 
            // btn_cliente
            // 
            this.btn_cliente.Enabled = false;
            this.btn_cliente.Location = new System.Drawing.Point(608, 543);
            this.btn_cliente.Name = "btn_cliente";
            this.btn_cliente.Size = new System.Drawing.Size(27, 25);
            this.btn_cliente.TabIndex = 117;
            this.btn_cliente.Text = "...";
            this.btn_cliente.UseVisualStyleBackColor = true;
            this.btn_cliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // Facturacion_Pago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 633);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Facturacion_Pago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago de factura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Facturacion_Pago_Load);
            this.Resize += new System.EventHandler(this.Facturacion_Pago_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbMuestraCambio.ResumeLayout(false);
            this.gbMuestraCambio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPagaCon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkImprimeTicket;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEmitirFactura;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.CheckBox chkVentaCredito;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkTarjetaCredito;
        private System.Windows.Forms.GroupBox gbMuestraCambio;
        private System.Windows.Forms.Label lblCambioMostrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTarjetaCredito;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNotasCredito;
        private System.Windows.Forms.Button btnBuscaCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalD;
        private System.Windows.Forms.TextBox txtTipoCambio;
        private System.Windows.Forms.TextBox txtNumTarjeta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkFactura_Electronica;
        private System.Windows.Forms.CheckBox chk_Factura_Elect;
        private System.Windows.Forms.Button btn_cliente;
    }
}