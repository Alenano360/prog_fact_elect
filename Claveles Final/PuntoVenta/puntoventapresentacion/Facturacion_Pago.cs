using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Printing;

namespace PuntoVentaPresentacion
{
    public partial class Facturacion_Pago : Form
    {
        public Facturacion_Mod _owner;

        Sel_NotaCredito _owner2;

        ApartadoCrear _owner3;

        ApartadoAgrega_Abono _owner4;

        PuntoVentaBL.Ticket objTicket = new PuntoVentaBL.Ticket();

        PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();

        PuntoVentaDAL.CONEXIONDataContext db = new PuntoVentaDAL.CONEXIONDataContext();

        PuntoVentaBL.InformacionGeneral objInformacionGeneral = new PuntoVentaBL.InformacionGeneral();

        public PuntoVentaBL.Persona objReceptor = null;

        public int ValTemp = 0;

        public Int64 proformaid = 0;

        public Int64 prefacturaid = 0;

        public decimal Descuento = 0;

        public decimal Total = 0;

        public decimal TotalD = 0;

        public int Proforma = 0;

        public int Prefactura = 0;

        public int NotaCredito = 0;

        public int Apartado = 0;

        public decimal MontoNotasCredito = 0;

        public List<string> ListaNotasCredito = new List<string>();

        public Int64 _ApartadoId = 0;

        public int SwitchCheckbox = 2;

        PuntoVentaBL.Proforma objProformas = new PuntoVentaBL.Proforma();

        PuntoVentaBL.Prefactura objprefactura = new PuntoVentaBL.Prefactura();

        PuntoVentaBL.Apartados objApartado = new PuntoVentaBL.Apartados();

        public Facturacion_Pago(Facturacion_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        public Facturacion_Pago(Sel_NotaCredito owner2)
        {
            InitializeComponent();

            _owner2 = owner2;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing2);
        }

        public Facturacion_Pago(ApartadoCrear owner3)
        {
            InitializeComponent();

            _owner3 = owner3;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing3);
        }

        public Facturacion_Pago(ApartadoAgrega_Abono owner4)
        {
            InitializeComponent();

            _owner4 = owner4;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing4);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            this._owner.Facturacion_Mod_Load();
            this._owner.Show();
        }

        private void Form2_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this._owner2.Close();
            this._owner.Facturacion_Mod_Load();
            this._owner.Show();
        }

        private void Form2_FormClosing3(object sender, FormClosingEventArgs e)
        {
            this._owner3.Show();
        }

        private void Form2_FormClosing4(object sender, FormClosingEventArgs e)
        {
            this._owner4.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)//borra linea
            {
                if (this.txtPagaCon.Focus())
                {
                    this.txtTarjetaCredito.Focus();
                    this.txtTarjetaCredito.Text = this.txtTotal.Text;
                    return true;    // indicate that you handled this keystroke
                }

            }
            if (keyData == Keys.F1)//borra linea
            {
                this.txtPagaCon.Focus();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F5)//consulto precio linea
            {
                this.btnEmitirFactura.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == Keys.F9)//Factura Electronica
            {
                if (!chk_Factura_Elect.Checked)
                {
                    chk_Factura_Elect.Checked = true;
                    Abrir_ElegirPersona();
                }
                else
                {
                    chk_Factura_Elect.Checked = false;
                }
                return true;

            }
            if (keyData == Keys.F10)//Salir
            {
                this.Close();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == Keys.F11)//Reporte Hacienda
            {
                if (chkFactura_Electronica.Checked) { chkFactura_Electronica.Checked = false; }
                else { chkFactura_Electronica.Checked = true; }
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F12)//salir
            {
                if (SwitchCheckbox % 2 == 0)
                {
                    this.chkImprimeTicket.Checked = false;
                }
                else
                {
                    this.chkImprimeTicket.Checked = true;
                }
                SwitchCheckbox++;
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.Enter)
            {
                if (ValTemp == 1)//quiere decir que ya pago y se muestra el cambio
                {
                    //_owner.LimpiaFactura();

                    //_owner.Facturacion_Mod_Load();

                    this.Close();

                    // Call the base class
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                //this.btnEmitirFactura.PerformClick();
                //this.ValTemp = 1;
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Facturacion_Pago_Load(object sender, EventArgs e)
        {
            try
            {
                
                this.objInformacionGeneral.ObtengoInformacion();
                

                this.gbMuestraCambio.Visible = false;
                this.txtTipoCambio.Text = this.objInformacionGeneral.TipoCambio.ToString("F");

                this.txtTotal.Text = Total.ToString("##,#0.#0");
                TotalD=Convert.ToDecimal(txtTotal.Text)/Convert.ToDecimal(txtTipoCambio.Text);

                this.txtTotalD.Text = TotalD.ToString("##,#0.#0");

                this.txtPagaCon.Text = Total.ToString("##,#0.#0");
                if (this.Apartado != 0)
                {
                    this.chkVentaCredito.Visible = false;
                    this.chkImprimeTicket.Visible = false;

                    //this.txtPagaCon.Text = this.txtTotal.Text;
                    //this.txtPagaCon.ReadOnly = true;
                    //this.txtPagaCon.BackColor = Color.White;
                }
                this.CalculaSaldo();

            }
            catch (Exception ex)
            {
                MessageBox.Show("2Hubo un inconveniente al intentar obtener los datos de la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Facturacion_Pago_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void txtPagaCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnEmitirFactura.PerformClick();
                this.ValTemp = 1;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        //1-TarjetaCreidto 2-Efectivo 3-CreditoCredito

        private void btnEmitirFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if ((chkFactura_Electronica.Checked && ((chk_Factura_Elect.Checked && _owner.objReceptor != null) || !chk_Factura_Elect.Checked)) || !chkFactura_Electronica.Checked)
                {
                    if (this.objModulo.ObtieneCajaDiaria() == false)
                    {
                        return;
                    }

                    PrinterSettings ps = new PrinterSettings();
                    foreach (string printer in PrinterSettings.InstalledPrinters)
                    {
                        ps.PrinterName = printer;
                        if (ps.IsDefaultPrinter)
                        {
                            Impresora = printer;
                        }
                    }
                    if (Convert.ToDecimal(txtPagaCon.Text) >= Convert.ToDecimal(txtTotal.Text) || Convert.ToDecimal(txtTarjetaCredito.Text) >= Convert.ToDecimal(txtTotal.Text))
                        // Imprime 
                        RawPrinterHelper.SendStringToPrinter(Impresora, System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, 112, 48, 55, 121 }));//para abrir la caja

                    if (this.Apartado == 1)//abono inicial con el que abre el apartado
                    {
                        this.chkImprimeTicket.Visible = false;
                        //if (Convert.ToDecimal(this.txtPagaCon.Text) <= 0)
                        //{
                        //    if (Convert.ToDecimal(this.txtTarjetaCredito.Text) <= 0)
                        //    {
                        //        MessageBox.Show("Por favor digite el monto con el que se va a pagar!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        //        return;
                        //    }
                        //    //if (this.chkTarjetaCredito.Checked==false)
                        //    //{
                        //    //    MessageBox.Show("Por favor digite el monto con el que se va a pagar!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        //    //    return;
                        //    //}                        
                        //}

                        if (Convert.ToDecimal(this.txtSaldo.Text) > 0)
                        {
                            //if (Convert.ToDecimal(this.txtTarjetaCredito.Text) <= 0)
                            //{
                            MessageBox.Show("Por favor digite el monto con el que se va a pagar!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                            //}
                            //if (this.chkTarjetaCredito.Checked == false)
                            //{
                            //    MessageBox.Show("Por favor digite el monto con el que se va a pagar!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            //    return;
                            //}  
                        }

                        this.btnEmitirFactura.Enabled = false;

                        this.gbMuestraCambio.Visible = true;

                        this.lblCambioMostrar.Text = Convert.ToDecimal(this.txtCambio.Text).ToString("F");

                        //if (!this.chkTarjetaCredito.Checked )
                        //{
                        //    this._owner3.DescuentoCajaDiaria = 1;
                        //}
                        //if (this.chkTarjetaCredito.Checked)
                        //{
                        //    this._owner3.DescuentoCajaDiaria = 2;
                        //}





                        //if (Convert.ToDecimal(this.txtPagaCon.Text) > 0)
                        //{
                        //    this._owner3.DescuentoCajaDiaria = 1;
                        //    this._owner3.MontoEfectivo = Convert.ToDecimal(this.txtPagaCon.Text);
                        //}

                        //if (Convert.ToDecimal(this.txtTarjetaCredito.Text) > 0)
                        //{
                        //    this._owner3.DescuentoCajaDiaria = 2;
                        //    this._owner3.MontoTarjeta = Convert.ToDecimal(this.txtTarjetaCredito.Text);
                        //}

                        //if (Convert.ToDecimal(this.txtNotasCredito.Text) > 0)
                        //{
                        //    this._owner3.MontoNotaCredito = Convert.ToDecimal(this.txtNotasCredito.Text);  
                        //}
                        //if (DescCajaDiaria == 1)//efectivo
                        //if (DescCajaDiaria == 2)//tarjeta credito
                        //if (DescCajaDiaria == 3)//nota credito

                        decimal pagacon = Convert.ToDecimal(this.txtPagaCon.Text) - Convert.ToDecimal(this.txtCambio.Text);
                        decimal tarje = Convert.ToDecimal(this.txtTarjetaCredito.Text);
                        decimal not = Convert.ToDecimal(this.txtNotasCredito.Text);


                        this._owner3.RealizoApartado(); //aquiii

                        this.OpenConn();

                        if (pagacon > 0)
                        {
                            var equipo = (from x in db.Equipos
                                          where x.NombreEquipo == System.Environment.MachineName.ToString()
                                          select x).First();

                            var bus = (from x in db.CajaDiarias
                                       join eq in db.Equipos on x.EquipoId equals eq.Id
                                       orderby x.Id descending
                                       select new { x.Saldo, eq.Id, x.Hora }).First();

                            var ap = (from f in db.ApartadoEncabezados
                                      orderby f.Id descending
                                      select f).First();

                            _ApartadoId = ap.Id;

                            PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                            _NewCajaDiaria.MovimientoId = 5;
                            _NewCajaDiaria.ComprobanteId = Convert.ToInt64(_ApartadoId);

                            _NewCajaDiaria.Descripcion = "Cobranza de apartado en efectivo: " + _ApartadoId.ToString();
                            _NewCajaDiaria.Monto = pagacon;
                            _NewCajaDiaria.Saldo = bus.Saldo + pagacon;

                            _NewCajaDiaria.UsuarioId = Login.UserId;
                            _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                            _NewCajaDiaria.Hora = (System.DateTime.Now.ToShortTimeString());
                            _NewCajaDiaria.EquipoId = equipo.Id;
                            _NewCajaDiaria.Activo = true;
                            _NewCajaDiaria.Visible = true;

                            db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                            db.SubmitChanges();
                        }

                        if (tarje > 0)
                        {
                            var equipo = (from x in db.Equipos
                                          where x.NombreEquipo == System.Environment.MachineName.ToString()
                                          select x).First();

                            var bus = (from x in db.CajaDiarias
                                       join eq in db.Equipos on x.EquipoId equals eq.Id
                                       orderby x.Id descending
                                       select new { x.Saldo, eq.Id, x.Hora }).First();

                            var ap = (from f in db.ApartadoEncabezados
                                      orderby f.Id descending
                                      select f).First();

                            _ApartadoId = ap.Id;

                            PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                            _NewCajaDiaria.MovimientoId = 5;
                            _NewCajaDiaria.ComprobanteId = Convert.ToInt64(_ApartadoId);
                            string NumTarjeta = txtNumTarjeta.Text;
                            _NewCajaDiaria.Descripcion = "Cobranza de apartado tarjeta de crédito: " + _ApartadoId.ToString() + "-" + "tarjeta #" + NumTarjeta.ToString();
                            _NewCajaDiaria.Monto = tarje;
                            _NewCajaDiaria.Saldo = bus.Saldo + tarje;

                            _NewCajaDiaria.UsuarioId = Login.UserId;
                            _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                            _NewCajaDiaria.Hora = (System.DateTime.Now.ToShortTimeString());
                            _NewCajaDiaria.EquipoId = equipo.Id;
                            _NewCajaDiaria.Activo = true;
                            _NewCajaDiaria.Visible = true;

                            db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                            db.SubmitChanges();
                        }

                        if (not > 0)
                        {
                            this.OpenConn();

                            foreach (string item in this.ListaNotasCredito)
                            {
                                var bus = from x in db.NotaEncabezados
                                          where x.Id == Convert.ToInt64(item)
                                          select x;

                                bus.First().Activo = false;

                                db.SubmitChanges();
                            }
                        }

                        this._owner3.LimpiaFactura();

                    }



                    //fin apartado



                    if (this.Apartado == 2)//abonos
                    {
                        this.chkImprimeTicket.Visible = false;

                        //if (Convert.ToDecimal(this.txtPagaCon.Text) <= 0)
                        //{
                        //    if (Convert.ToDecimal(this.txtTarjetaCredito.Text) <= 0)
                        //    {
                        //        MessageBox.Show("Por favor digite el monto con el que se va a pagar!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        //        return;
                        //    }
                        //}

                        if (Convert.ToDecimal(this.txtSaldo.Text) > 0)
                        {
                            //if (Convert.ToDecimal(this.txtTarjetaCredito.Text) <= 0)
                            //{
                            MessageBox.Show("Por favor digite el monto con el que se va a pagar!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                            //}
                        }

                        ps = new PrinterSettings();
                        foreach (string printer in PrinterSettings.InstalledPrinters)
                        {
                            ps.PrinterName = printer;
                            if (ps.IsDefaultPrinter)
                            {
                                Impresora = printer;
                            }
                        }

                        RawPrinterHelper.SendStringToPrinter(Impresora, System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, 112, 48, 55, 121 }));//para abrir la caja

                        this.btnEmitirFactura.Enabled = false;

                        this.gbMuestraCambio.Visible = true;

                        this.lblCambioMostrar.Text = Convert.ToDecimal(this.txtCambio.Text).ToString("F");

                        //if (!this.chkTarjetaCredito.Checked)
                        //{
                        //    this._owner4.DescuentoCajaDiaria = 1;
                        //}
                        //if (this.chkTarjetaCredito.Checked)
                        //{
                        //    this._owner4.DescuentoCajaDiaria = 2;
                        //}

                        //if (Convert.ToDecimal(this.txtTarjetaCredito.Text) <= 0)
                        //{
                        //    this._owner4.DescuentoCajaDiaria = 1;
                        //}

                        //if (Convert.ToDecimal(this.txtTarjetaCredito.Text) > 0)
                        //{
                        //    this._owner4.DescuentoCajaDiaria = 2;
                        //}

                        decimal pagacon = Convert.ToDecimal(this.txtPagaCon.Text) - Convert.ToDecimal(this.txtCambio.Text);
                        decimal tarje = Convert.ToDecimal(this.txtTarjetaCredito.Text);
                        decimal not = Convert.ToDecimal(this.txtNotasCredito.Text);

                        this._owner4.RealizoAbono();

                        this.OpenConn();

                        if (pagacon > 0)
                        {
                            var equipo = (from x in db.Equipos
                                          where x.NombreEquipo == System.Environment.MachineName.ToString()
                                          select x).First();

                            var bus = (from x in db.CajaDiarias
                                       join eq in db.Equipos on x.EquipoId equals eq.Id
                                       orderby x.Id descending
                                       select new { x.Saldo, eq.Id, x.Hora }).First();

                            //var ap = (from f in db.ApartadoEncabezados
                            //          orderby f.Id descending
                            //          select f).First();

                            //_ApartadoId = ap.Id;

                            //el _apartadoid ya esta asignado desde apartadoagrega_abono

                            PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                            _NewCajaDiaria.MovimientoId = 5;
                            _NewCajaDiaria.ComprobanteId = Convert.ToInt64(_ApartadoId);

                            _NewCajaDiaria.Descripcion = "Cobranza de apartado en efectivo: " + _ApartadoId.ToString();
                            _NewCajaDiaria.Monto = pagacon;
                            _NewCajaDiaria.Saldo = bus.Saldo + pagacon;

                            _NewCajaDiaria.UsuarioId = Login.UserId;
                            _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                            _NewCajaDiaria.Hora = (System.DateTime.Now.ToShortTimeString());
                            _NewCajaDiaria.EquipoId = equipo.Id;
                            _NewCajaDiaria.Activo = true;
                            _NewCajaDiaria.Visible = true;

                            db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                            db.SubmitChanges();
                        }

                        if (tarje > 0)
                        {
                            var equipo = (from x in db.Equipos
                                          where x.NombreEquipo == System.Environment.MachineName.ToString()
                                          select x).First();

                            var bus = (from x in db.CajaDiarias
                                       join eq in db.Equipos on x.EquipoId equals eq.Id
                                       orderby x.Id descending
                                       select new { x.Saldo, eq.Id, x.Hora }).First();

                            //var ap = (from f in db.ApartadoEncabezados
                            //          orderby f.Id descending
                            //          select f).First();

                            //_ApartadoId = ap.Id;

                            //el _apartadoid ya esta asignado desde apartadoagrega_abono

                            PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                            _NewCajaDiaria.MovimientoId = 5;
                            _NewCajaDiaria.ComprobanteId = Convert.ToInt64(_ApartadoId);

                            string NumTarjeta = txtNumTarjeta.Text;
                            _NewCajaDiaria.Descripcion = "Cobranza de apartado tarjeta de crédito: " + _ApartadoId.ToString() + "-" + "tarjeta #" + NumTarjeta.ToString();
                            _NewCajaDiaria.Monto = tarje;
                            _NewCajaDiaria.Saldo = bus.Saldo + tarje;

                            _NewCajaDiaria.UsuarioId = Login.UserId;
                            _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                            _NewCajaDiaria.Hora = (System.DateTime.Now.ToShortTimeString());
                            _NewCajaDiaria.EquipoId = equipo.Id;
                            _NewCajaDiaria.Activo = true;
                            _NewCajaDiaria.Visible = true;

                            db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                            db.SubmitChanges();
                        }

                        if (not > 0)
                        {
                            this.OpenConn();

                            foreach (string item in this.ListaNotasCredito)
                            {
                                var bus = from x in db.NotaEncabezados
                                          where x.Id == Convert.ToInt64(item)
                                          select x;

                                bus.First().Activo = false;

                                db.SubmitChanges();
                            }
                        }

                        this._owner4.ConstruyeTicketApartado();
                    }



                    //fin apartado dos


                    if (this.Apartado == 4)//cancela apartado
                    {
                        this.chkImprimeTicket.Visible = false;

                        //if (Convert.ToDecimal(this.txtPagaCon.Text) <= 0)
                        //{
                        //    if (Convert.ToDecimal(this.txtTarjetaCredito.Text) <= 0)
                        //    {
                        //        MessageBox.Show("Por favor digite el monto con el que se va a pagar!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        //        return;
                        //    }
                        //}

                        if (Convert.ToDecimal(this.txtSaldo.Text) > 0)
                        {
                            //if (Convert.ToDecimal(this.txtTarjetaCredito.Text) <= 0)
                            //{
                            MessageBox.Show("Por favor digite el monto con el que se va a pagar!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                            //}
                        }

                        foreach (string printer in PrinterSettings.InstalledPrinters)
                        {
                            ps.PrinterName = printer;
                            if (ps.IsDefaultPrinter)
                            {
                                Impresora = printer;
                            }
                        }

                        RawPrinterHelper.SendStringToPrinter(Impresora, System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, 112, 48, 55, 121 }));//para abrir la caja

                        this.btnEmitirFactura.Enabled = false;

                        this.gbMuestraCambio.Visible = true;

                        this.lblCambioMostrar.Text = Convert.ToDecimal(this.txtCambio.Text).ToString("F");

                        //if (!this.chkTarjetaCredito.Checked)
                        //{
                        //    this._owner4.DescuentoCajaDiaria = 1;
                        //}
                        //if (this.chkTarjetaCredito.Checked)
                        //{
                        //    this._owner4.DescuentoCajaDiaria = 2;
                        //}


                        //if (Convert.ToDecimal(this.txtTarjetaCredito.Text) <= 0)
                        //{
                        //    this._owner4.DescuentoCajaDiaria = 1;
                        //}

                        //if (Convert.ToDecimal(this.txtTarjetaCredito.Text) > 0)
                        //{
                        //    this._owner4.DescuentoCajaDiaria = 2;
                        //}

                        decimal pagacon = Convert.ToDecimal(this.txtPagaCon.Text) - Convert.ToDecimal(this.txtCambio.Text);
                        decimal tarje = Convert.ToDecimal(this.txtTarjetaCredito.Text);
                        decimal not = Convert.ToDecimal(this.txtNotasCredito.Text);

                        this._owner4.RealizoAbono();

                        this.OpenConn();

                        if (pagacon > 0)
                        {
                            var equipo = (from x in db.Equipos
                                          where x.NombreEquipo == System.Environment.MachineName.ToString()
                                          select x).First();

                            var bus = (from x in db.CajaDiarias
                                       join eq in db.Equipos on x.EquipoId equals eq.Id
                                       orderby x.Id descending
                                       select new { x.Saldo, eq.Id, x.Hora }).First();

                            //var ap = (from f in db.ApartadoEncabezados
                            //          orderby f.Id descending
                            //          select f).First();

                            //_ApartadoId = ap.Id;

                            //el _apartadoid ya esta asignado desde apartadoagrega_abono

                            PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                            _NewCajaDiaria.MovimientoId = 5;
                            _NewCajaDiaria.ComprobanteId = Convert.ToInt64(_ApartadoId);

                            _NewCajaDiaria.Descripcion = "Cobranza de apartado en efectivo: " + _ApartadoId.ToString();
                            _NewCajaDiaria.Monto = pagacon;
                            _NewCajaDiaria.Saldo = bus.Saldo + pagacon;

                            _NewCajaDiaria.UsuarioId = Login.UserId;
                            _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                            _NewCajaDiaria.Hora = (System.DateTime.Now.ToShortTimeString());
                            _NewCajaDiaria.EquipoId = equipo.Id;
                            _NewCajaDiaria.Activo = true;
                            _NewCajaDiaria.Visible = true;

                            db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                            db.SubmitChanges();
                        }

                        if (tarje > 0)
                        {
                            var equipo = (from x in db.Equipos
                                          where x.NombreEquipo == System.Environment.MachineName.ToString()
                                          select x).First();

                            var bus = (from x in db.CajaDiarias
                                       join eq in db.Equipos on x.EquipoId equals eq.Id
                                       orderby x.Id descending
                                       select new { x.Saldo, eq.Id, x.Hora }).First();

                            //var ap = (from f in db.ApartadoEncabezados
                            //          orderby f.Id descending
                            //          select f).First();

                            //_ApartadoId = ap.Id;

                            //el _apartadoid ya esta asignado desde apartadoagrega_abono

                            PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                            _NewCajaDiaria.MovimientoId = 5;
                            _NewCajaDiaria.ComprobanteId = Convert.ToInt64(_ApartadoId);

                            string NumTarjeta = txtNumTarjeta.Text;
                            _NewCajaDiaria.Descripcion = "Cobranza de apartado tarjeta de crédito: " + _ApartadoId.ToString() + "-" + "tarjeta #" + NumTarjeta.ToString();
                            _NewCajaDiaria.Monto = tarje;
                            _NewCajaDiaria.Saldo = bus.Saldo + tarje;

                            _NewCajaDiaria.UsuarioId = Login.UserId;
                            _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                            _NewCajaDiaria.Hora = (System.DateTime.Now.ToShortTimeString());
                            _NewCajaDiaria.EquipoId = equipo.Id;
                            _NewCajaDiaria.Activo = true;
                            _NewCajaDiaria.Visible = true;

                            db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                            db.SubmitChanges();
                        }

                        if (not > 0)
                        {
                            this.OpenConn();

                            foreach (string item in this.ListaNotasCredito)
                            {
                                var bus = from x in db.NotaEncabezados
                                          where x.Id == Convert.ToInt64(item)
                                          select x;

                                bus.First().Activo = false;

                                db.SubmitChanges();
                            }
                        }



                        this._owner4.ConstruyeTicketApartado();

                        this._owner4.IngresaEncabezadoYDetalle();

                        this._owner4.ConstruyeTicket();

                    }

                    //cancela apartado




                    if (Apartado == 0)
                    {

                        if (Convert.ToInt64(proformaid) != 0)
                        {
                            this.objProformas.Id = Convert.ToInt64(proformaid);

                            this.objProformas.EliminaProforma();
                        }

                        if (Convert.ToInt64(prefacturaid) != 0)
                        {
                            this.objprefactura.Id = Convert.ToInt64(prefacturaid);

                            this.objprefactura.EliminaPrefactura();
                        }



                        if (txtPagaCon.Text != "0.00" && txtTarjetaCredito.Text == "0.00")
                        {
                            _owner.recibido = Convert.ToDecimal(this.txtPagaCon.Text);

                        }
                        else if (txtTarjetaCredito.Text != "0.00" && txtPagaCon.Text == "0.00")
                        {
                            _owner.recibido = Convert.ToDecimal(this.txtTarjetaCredito.Text);

                        }
                        else if (txtPagaCon.Text != "0.00" && txtTarjetaCredito.Text != "0.00")
                        {
                            _owner.recibido = Convert.ToDecimal(Convert.ToDecimal(this.txtTarjetaCredito.Text) + Convert.ToDecimal(this.txtPagaCon.Text));


                        }
                        else
                            return;

                        _owner.cambio = Convert.ToDecimal(this.txtCambio.Text);

                        //_owner.FormaPagoId = 1;//1 efectivo 2 tarjeta creidto 3credito

                        _owner.VentaEfectivo = Convert.ToDecimal(this.txtPagaCon.Text);

                        _owner.VentaTarjetaCredito = Convert.ToDecimal(this.txtTarjetaCredito.Text);


                        _owner.VentaNotaCredito = Convert.ToDecimal(this.txtNotasCredito.Text);

                        if (Convert.ToDecimal(this.txtNotasCredito.Text) > 0)
                        {
                            //string[] temp = item.Split(';');
                            this.OpenConn();

                            foreach (string item in this.ListaNotasCredito)
                            {
                                var bus = from x in db.NotaEncabezados
                                          where x.Id == Convert.ToInt64(item)
                                          select x;

                                bus.First().Activo = false;

                                db.SubmitChanges();
                            }
                        }

                        _owner.FormaPagoId = 1;

                        if (this.chkVentaCredito.Checked)
                        {
                            _owner.FormaPagoId = 3;
                        }


                        if (Convert.ToDecimal(this.txtSaldo.Text) == 0)
                        {
                            _owner.NumTarjeta = txtNumTarjeta.Text;
                            _owner.GeneraFacturaTotal();
                        }


                        if (Convert.ToDecimal(this.txtSaldo.Text) > 0)
                        {
                            if (DialogResult.OK == MessageBox.Show("¿Desea agregar el saldo restante a la cuenta de crédito del cliente?", "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                            {
                                this.chkVentaCredito.Checked = true;

                                if (this._owner.VerficaCliente() == false)
                                {
                                    return;
                                }
                                _owner.NumTarjeta = txtNumTarjeta.Text;
                                _owner.GeneraFacturaTotal(); //problema aquiii
                                _owner.VentaCreditoMonto = Convert.ToDecimal(this.txtSaldo.Text);

                                _owner.AgregaCreditoCliente();
                            }
                            else
                            {
                                return;
                            }
                        }

                        //if (this.chkTarjetaCredito.Checked)
                        //{
                        //    _owner.FormaPagoId = 2;
                        //    if (_owner.GeneraFacturaConTarjetaCredito() == false)
                        //    {

                        //        return;
                        //    }
                        //}

                        ////para pagos a contado y/o con  parte credito
                        //if (this.chkTarjetaCredito.Checked == false && this.chkVentaCredito.Checked == false)
                        //{
                        //    _owner.FormaPagoId = 1;

                        //    if (this.txtPagaCon.Text == "0.00")
                        //    {
                        //        MessageBox.Show("Por favor digite el monto con el que se va a pagar!", "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        //        return;
                        //    }

                        //    if (Convert.ToDecimal(this.txtSaldo.Text) > 0)
                        //    {
                        //        if (DialogResult.OK == MessageBox.Show("¿Desea agregar el saldo restante a la cuenta de crédito del cliente?", "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                        //        {
                        //            if (_owner.ObtieneCliente() == false)
                        //            {
                        //                return;
                        //            }
                        //            _owner.pagoparcial = Convert.ToDecimal(this.txtPagaCon.Text);

                        //            _owner.GeneraFacturaContado();

                        //            _owner.SaldoRestantePorPagar = Convert.ToDecimal(this.txtSaldo.Text);//envio el saldo y lo agrego al credito

                        //            if (_owner.AgregaCreditoClientePorPagar() == false)
                        //            { return; }

                        //        }
                        //        else
                        //        {
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        _owner.GeneraFacturaContado();
                        //    }
                        //}

                        _owner.objTicket._TipoDocumento = "";
                        _owner.objTicket._Clave = "";

                        if (this.chkFactura_Electronica.Checked)
                        {
                            if (chk_Factura_Elect.Checked)
                            {
                                _owner.Reporte_Hacienda(true);
                            }
                            else
                            {
                                _owner.Reporte_Hacienda(false);
                            }
                        }

                        if (this.chkImprimeTicket.Checked)
                        {
                            _owner.ConstruyeTicket();
                        }

                        this.btnEmitirFactura.Enabled = false;

                        this.gbMuestraCambio.Visible = true;

                        this.lblCambioMostrar.Text = Convert.ToDecimal(this.txtCambio.Text).ToString("F");

                        _owner.LimpiaFactura();

                        _owner.cajeronombretemp = string.Empty;

                        this._owner.CierraFacturacion();
                    }
                    //apartado
                }
                else {
                    MessageBox.Show("Favor elegir un receptor si quieres enviar una factura electronica, de lo contrario desmarcar la casilla. ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenConn()
        {
            if (db == null) db = new PuntoVentaDAL.CONEXIONDataContext();
        }

        public void CloseConn()
        {
            if (db != null)
            {
                if (db.Connection.State == System.Data.ConnectionState.Open)
                    db.Connection.Close();

                db.Dispose();
                db = null;
            }
        }


        public string Impresora = "EPSON TM-T20II Receipt5";

        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "My C#.NET RAW Document";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }

            public static bool SendFileToPrinter(string szPrinterName, string szFileName)
            {
                // Open the file.
                FileStream fs = new FileStream(szFileName, FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                // Dim an array of bytes big enough to hold the file's contents.
                Byte[] bytes = new Byte[fs.Length];
                bool bSuccess = false;
                // Your unmanaged pointer.
                IntPtr pUnmanagedBytes = new IntPtr(0);
                int nLength;

                nLength = Convert.ToInt32(fs.Length);
                // Read the contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes);
                return bSuccess;
            }
            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        }

        private void EmiteFactura()
        {
            //try
            //{
            //    if (this.chkImprimeTicket.Checked && this.chkVentaCredito.Checked == false)//ingresa factura con ticket y no resta credito
            //    {
            //        _owner.GeneraFacturaConTicketNoCredito();

            //        _owner.Facturacion_Mod_Load();

            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hubo un inconveniente al intentar emitar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void chkVentaCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkVentaCredito.Checked)
            {
                this.txtPagaCon.Text = "0.00";
                this.txtTarjetaCredito.Text = "0.00";
            }

            //this.txtPagaCon.Enabled = false;
            //this.txtTarjetaCredito.Enabled = false;
           


            //this.txtSaldo.Text = "0.00";

            //this.txtCambio.Text = "0.00";

        }

        private void chkTarjetaCredito_CheckedChanged(object sender, EventArgs e)
        {

            if (Apartado == 4)
            {
                if (this.chkTarjetaCredito.Checked)
                {
                    this.txtPagaCon.Text = this.txtTotal.Text;

                    this.txtSaldo.Text = "0.00";

                    this.txtCambio.Text = "0.00";
                }
                else
                {
                    this.txtPagaCon.ReadOnly = false;
                }
            } if (Apartado == 2)
            {
                if (this.chkTarjetaCredito.Checked)
                {
                    this.txtPagaCon.Text = this.txtTotal.Text;

                    this.txtSaldo.Text = "0.00";

                    this.txtCambio.Text = "0.00";
                }
                else
                {
                    this.txtPagaCon.ReadOnly = false;
                }
            }
            if (Apartado == 1)
            {
                if (this.chkTarjetaCredito.Checked)
                {
                    this.txtPagaCon.Text = this.txtTotal.Text;

                    this.txtSaldo.Text = "0.00";

                    this.txtCambio.Text = "0.00";
                }
                else
                {
                    this.txtPagaCon.ReadOnly = false;
                }
            }
            else if (Apartado == 0)
            {
                if (this.chkTarjetaCredito.Checked)
                {
                    this.txtPagaCon.Text = "0.00";

                    this.txtSaldo.Text = "0.00";

                    this.txtCambio.Text = "0.00";

                    this.chkVentaCredito.Checked = false;
                }
            }
        }

        private void txtPagaCon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (e.KeyCode==Keys.Enter)
                //{
             

                if (this.txtPagaCon.Text.Length == 0)
                {
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtPagaCon.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el monto de pago digite sólo números", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToDecimal(this.txtTotal.Text) < Convert.ToDecimal(this.txtPagaCon.Text))
                {
                    //this.txtSaldo.Text = "0.00";
                    this.txtCambio.Text = (Convert.ToDecimal(this.txtPagaCon.Text) - Convert.ToDecimal(this.txtTotal.Text)).ToString("F");
                }
                else
                {
                    this.txtCambio.Text = "0.00";
                    //this.txtSaldo.Text = (Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtPagaCon.Text)).ToString("F");
                }

                if (Convert.ToDecimal(this.txtTotal.Text) == Convert.ToDecimal(this.txtPagaCon.Text))
                {
                    this.txtTarjetaCredito.Text = "0.00";
                }

                this.CalculaSaldo();

            }
            catch (Exception ex)
            {
                MessageBox.Show("4Hubo un inconveniente al intentar obtener los datos de la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CalculaSaldo()
        {
            try
            {
                decimal Total = Convert.ToDecimal(this.txtTotal.Text);
                decimal PagaCon = Convert.ToDecimal(this.txtPagaCon.Text);
                decimal NotasCredito = Convert.ToDecimal(this.txtNotasCredito.Text);
                decimal TarjetaCredito = Convert.ToDecimal(this.txtTarjetaCredito.Text);

                this.txtSaldo.Text = (Total - (PagaCon + NotasCredito + TarjetaCredito)).ToString("F");

                if (Convert.ToDecimal(this.txtSaldo.Text) < 0)
                {
                    this.txtSaldo.Text = "0.00";
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Hubo un inconveniente al intentar obtener el saldo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CambiaNotaCreditoMonto()
        {
            try
            {
                this.txtNotasCredito.Text = this.MontoNotasCredito.ToString("F");
            }
            catch (Exception)
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void txtTarjetaCredito_TextChanged(object sender, EventArgs e)
        {
            try
            {
            

               chkVentaCredito.Enabled = false;
               chkVentaCredito.Checked = false;

                
               if (Convert.ToDecimal(txtTarjetaCredito.Text) == Convert.ToDecimal(txtTotal.Text))
               {
                   txtPagaCon.Text = "0.00";
               }


                if (this.txtTarjetaCredito.Text.Length == 0)
                {
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtTarjetaCredito.Text);
              
                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el monto de tarjeta de crédito digite sólo números", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                this.CalculaSaldo();

            }
            catch (Exception ex)
            {
                MessageBox.Show("1Hubo un inconveniente al intentar obtener los datos de la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            NotaCredito_Pago form = new NotaCredito_Pago(this);
            form.TopLevel = false;
            form.Parent = this;
            form.Show();
        }

        private void txtNotasCredito_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.CalculaSaldo();

            }
            catch (Exception)
            {
            }
        }

        private void gbMuestraCambio_Enter(object sender, EventArgs e)
        {

        }

        private void lblCambioMostrar_Click(object sender, EventArgs e)
        {

        }

        private void chkImprimeTicket_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void chkImprimeTicket_KeyDown(object sender, KeyEventArgs e)
        {
            CheckBox chkImprimeTicket = this.ActiveControl as CheckBox;
            if (e.KeyData == Keys.F10 && this.ActiveControl.Equals(chkImprimeTicket))
                chkImprimeTicket.Checked = true;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtTarjetaCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnEmitirFactura.PerformClick();
                this.ValTemp = 1;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void chkFactura_Electronica_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abrir_ElegirPersona();
        }
        private void Abrir_ElegirPersona()
        {
            Elegir_Persona form = new Elegir_Persona(this);
            form.TopLevel = false;
            form.Parent = this;
            form.BringToFront();
            form.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Factura_Elect.Checked)
            {
                btn_cliente.Enabled = true;
            }
            else {
                btn_cliente.Enabled = false;
                objReceptor = null;
            }
        }
    }



}


    


