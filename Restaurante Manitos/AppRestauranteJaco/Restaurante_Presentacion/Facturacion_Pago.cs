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
using Restaurante_BL;

namespace Restaurante_Presentacion
{
    public partial class Facturacion_Pago : Form
    {
        public Facturar _owner;
        
        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();

        public int ValTemp = 0;

        public decimal Descuento = 0;

        public decimal Total = 0;

        public string Impresora = string.Empty;

        public int Apartado = 0;

        public Restaurante_BL.Persona objReceptor = null;


        public Facturacion_Pago(Facturar owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            //this._owner.Facturar_Load();
            this._owner.CierraFacturar();
            this._owner.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F9)//salir
            {
                this.Close();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.Enter)
            {
                if (ValTemp == 1)//quiere decir que ya pago y se muestra el cambio
                {
                    _owner.Facturar_Load();

                    _owner.LLamaCierraPanel();

                    _owner.Close();

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Facturacion_Pago_Load(object sender, EventArgs e)
        {
            try
            {
                this.gbMuestraCambio.Visible = false;

                this.objInformacionGeneral.ObtieneUsuarios(this.cmbUsuarios);

                this.ResizeLoad();

                this.ObtieneInfoInferior();

                this.txtTotal.Text = Convert.ToDecimal(this.Total).ToString("F");

                Total = Convert.ToDecimal(this.Total);
            }
            catch (Exception)
            {                                
            }
        }

        private void ObtieneInfoInferior()
        {
            try
            {
                this.objInformacionGeneral.ObtengoInformacionRestaurante();

                this.tls_Usuario.Text = "Usuario: " + Login.LoginUsuarioFinal.ToString().ToUpper();

                this.tlsNombreRest.Text = "Restaurante: " + this.objInformacionGeneral.Nombre.ToString();

                this.tlsWebHtml.Text = "Web: " + this.objInformacionGeneral.Web.ToString();

                this.tlsFecha.Text = "Fecha: " + System.DateTime.Now.ToShortDateString();

                this.tlsHora.Text = "Hora: " + System.DateTime.Now.ToShortTimeString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Facturacion_Pago_Resize(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();
            }
            catch (Exception)
            {
            }
        }

        private void ResizeLoad()
        {
            try
            {
                var width = this.Width;
                var height = (this.Height - 85) / 5;

                this.tls_Usuario.Width = ((this.Width / 9) * 2) + 15;
                this.tlsNombreRest.Width = ((this.Width / 9) * 3) - 32;
                this.tlsWebHtml.Width = (this.Width / 9) * 2;
                this.tlsFecha.Width = (this.Width / 9);
                this.tlsHora.Width = (this.Width / 9);

                this.panelCompleto.Location = new Point(((this.Width - this.panelCompleto.Width) / 2), 0);
            }
            catch (Exception)
            {
            }
        }

        private void chkTarjetaCredito_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                    if (this.chkTarjetaCredito.Checked)
                    {
                        this.txtPagaCon.Text = "0.00";

                        this.txtSaldo.Text = "0.00";

                        this.txtCambio.Text = "0.00";

                        this.chkVentaCredito.Checked = false;
                    }
                
            }
            catch (Exception)
            {
                
            }
        }

        private void btnPrefactura_Click(object sender, EventArgs e)
        {
            try
            {
                _owner.total = Convert.ToDecimal(this.txtTotal.Text);
                //_owner.descuento = Convert.ToDecimal(this.txtDescuento.Text);
                _owner.descuento = Total * (Convert.ToDecimal(this.txtDescuento.Text) / 100);
                _owner.UserIdTemp = Login.UserId;
                _owner.UserNameTemp = Login.LoginUsuarioFinal;
                if (Convert.ToInt32(this.cmbUsuarios.SelectedValue) != Login.UserId)
                {
                    _owner.UserIdTemp = Convert.ToInt32(this.cmbUsuarios.SelectedValue);
                    _owner.UserNameTemp = this.cmbUsuarios.Text;
                }

                if (this.chkServicioRestaurante.Checked)
                {
                    _owner.serviciorestaurante = 1;
                }
                else
                {
                    _owner.serviciorestaurante = 0;
                }
                if (this.txtNombreCliente.Text.Length > 0)
                {
                    _owner.nombrecliente = this.txtNombreCliente.Text;
                }
                else
                {
                    _owner.nombrecliente = "";
                }
                _owner.ConstruyeTicketPrefactura();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la prefactura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmitirFactura_Click(object sender, EventArgs e)
        {
            try
            {
                _owner.total    = Convert.ToDecimal(this.txtTotal.Text);
                _owner.recibido = Convert.ToDecimal(this.txtPagaCon.Text);
                _owner.cambio   = Convert.ToDecimal(this.txtCambio.Text);
                //_owner.descuento = Convert.ToDecimal(this.txtDescuento.Text);
                _owner.descuento = Total*(Convert.ToDecimal(this.txtDescuento.Text)/100);
                _owner.propina = Convert.ToDecimal(this.txtPropina.Text);
                _owner.UserIdTemp = Login.UserId;
                _owner.UserNameTemp = Login.LoginUsuarioFinal;

                _owner.recibido2 = Convert.ToDecimal(this.txtTarjetaCredito.Text);

                //Salonero:
                if (Convert.ToInt32(this.cmbUsuarios.SelectedValue)!=Login.UserId)
                {
                    _owner.UserIdTemp = Convert.ToInt32(this.cmbUsuarios.SelectedValue);
                    _owner.UserNameTemp = this.cmbUsuarios.Text;
                }

                //Servicio Restaurante:
                if (this.chkServicioRestaurante.Checked)
                {
                     _owner.serviciorestaurante = 1;
                }
                else
                {
                    _owner.serviciorestaurante = 0;
                }
                //Cliente:
                if (this.txtNombreCliente.Text.Length>0)
                {
                    _owner.nombrecliente = this.txtNombreCliente.Text;
                }
                else
                {
                    _owner.nombrecliente = "";
                }

                //Pago Mixto:
                if ((Convert.ToDecimal(this.txtPagaCon.Text) > 0)&&(Convert.ToDecimal(this.txtTarjetaCredito.Text) > 0))
                {
                    _owner.tipopago = 2;
                    _owner.tipopago2 = 1;
                }
                //Pago Contado:
                else  if ((Convert.ToDecimal(this.txtPagaCon.Text) > 0) && (Convert.ToDecimal(this.txtTarjetaCredito.Text) ==0))

                {
                    _owner.tipopago = 2;
                    _owner.tipopago2 = 0;

                }

                //Pago TarjetaCredito:
                if ((Convert.ToDecimal(this.txtPagaCon.Text) == 0) && (Convert.ToDecimal(this.txtTarjetaCredito.Text) > 0))
                {
                    _owner.tipopago = 1;
                    _owner.tipopago2 = 1;

                }
                //TIPO DE PAGO:
                //1-TarjetaCredito 2-Efectivo 3-CreditoCredito

                //
                if (this.chkVentaCredito.Checked)
                {
                    _owner.tipopago  = 3;
                }

                _owner.ConstruyeFactura();


                /*          if (Convert.ToDecimal(this.txtSaldo.Text) > 0)
                          {
                              if (DialogResult.OK == MessageBox.Show("¿Desea agregar el saldo restante a la cuenta de crédito del cliente?", "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                              {
                                  this.chkVentaCredito.Checked = true;

                                  if (this._owner.VerficaCliente() == false)
                                  {
                                      return;
                                  }

                                  _owner.VentaCreditoMonto = Convert.ToDecimal(this.txtSaldo.Text);

                                  _owner.AgregaCreditoCliente();
                              }
                              else
                              {
                                  return;
                              }
                          }*/

                _owner.objTicket._TipoDocumento = "";
                _owner.objTicket._Clave = "";
                if (this.chkFactura_Electronica.Checked)
                {
                    if (chk_Factura_Elect.Checked)
                    {
                        _owner.Reporte_Hacienda(true, this.chkImpServicio.Checked);
                    }
                    else
                    {
                        _owner.Reporte_Hacienda(false, this.chkImpServicio.Checked);
                    }
                }

                if (this.chkImprimeTicket.Checked)
                {
                    _owner.ConstruyeTicket();
                }
                //_owner.Facturar_Load();

                PrinterSettings ps = new PrinterSettings();
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

                //this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        decimal x = 0;

                        x = Convert.ToDecimal(this.txtDescuento.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Digite unicamente numeros: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtDescuento.Text = string.Empty;                          
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void panelCompleto_Paint(object sender, PaintEventArgs e)
        {

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
                catch (Exception ex)
                {
                    MessageBox.Show("Para el monto de pago digite sólo números: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (Convert.ToDecimal(this.txtTotal.Text) < Convert.ToDecimal(this.txtPagaCon.Text))
                {
                    this.txtSaldo.Text = "0.00";
                    this.txtCambio.Text = (Convert.ToDecimal(this.txtPagaCon.Text) - Convert.ToDecimal(this.txtTotal.Text)).ToString("F");
                }
                else
                {
                    this.txtCambio.Text = "0.00";
                    this.txtSaldo.Text = (Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtPagaCon.Text)).ToString("F");
                }

                //e.Handled = true;
                //e.SuppressKeyPress = true; 
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los datos de la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (e.KeyCode==Keys.Enter)
                //{
                if (this.txtDescuento.Text.Length == 0)
                {
                    this.txtTotal.Text = (Convert.ToDecimal(Total)).ToString("F");
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtDescuento.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el porcentaje de descuento digite sólo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDescuento.Text = "0.00";
                }

                this.txtTotal.Text = (Convert.ToDecimal(Total) - (Convert.ToDecimal(Total)*(Convert.ToDecimal(this.txtDescuento.Text)/100))).ToString("F");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el descuento: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void gbMuestraCambio_Enter(object sender, EventArgs e)
        {

        }

        public void CalculaSaldo()
        {
            try
            {
                decimal Total = Convert.ToDecimal(this.txtTotal.Text);
                decimal PagaCon = Convert.ToDecimal(this.txtPagaCon.Text);

                decimal TarjetaCredito = Convert.ToDecimal(this.txtTarjetaCredito.Text);

                this.txtSaldo.Text = (Total - (PagaCon  + TarjetaCredito)).ToString("F");

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

        private void txtTarjetaCredito_TextChanged(object sender, EventArgs e)
        {
            try
            {

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
                MessageBox.Show("Hubo un inconveniente al intentar obtener los datos de la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
         /*   NotaCredito_Pago form = new NotaCredito_Pago(this);
            form.TopLevel = false;
            form.Parent = this;
            form.Show();*/
        }

        private void chkVentaCredito_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_cliente_Click(object sender, EventArgs e)
        {
            Elegir_Persona form = new Elegir_Persona(this);
            form.TopLevel = false;
            form.Parent = this;
            form.BringToFront();
            form.Show();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Factura_Elect.Checked)
            {
                btn_cliente.Enabled = true;
            }
            else
            {
                btn_cliente.Enabled = false;
                objReceptor = null;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkServicioRestaurante_CheckedChanged(object sender, EventArgs e)
        {
            
            
            if ( this.chkServicioRestaurante.Checked)
            {
                double decimalTotalAmount = Convert.ToDouble(this.txtTotal.Text) * 1.23;
                decimalTotalAmount = decimalTotalAmount / 1.13;
                this.txtTotal.Text = decimalTotalAmount.ToString();
            }
            else
            {
                double decimalTotalAmount = Convert.ToDouble(this.txtTotal.Text) / 1.23;
                decimalTotalAmount = decimalTotalAmount * 1.13;
                this.txtTotal.Text = decimalTotalAmount.ToString();
            }




        }

        private void chkFactura_Electronica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFactura_Electronica.Checked)
            {
                chkImpServicio.Enabled = true; 
            }
            else
            {
                chkImpServicio.Enabled = false; 
            }
        }
    }
}
