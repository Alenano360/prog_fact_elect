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
    public partial class Recibos_Mantenimiento : Form
    {
        ReciboCliente _owner;
        PuntoVentaBL.ReciboClientes objRecibo = new PuntoVentaBL.ReciboClientes();
        PuntoVentaBL.Cliente objcliente = new PuntoVentaBL.Cliente();
        PuntoVentaBL.TicketRecibo objTicket = new PuntoVentaBL.TicketRecibo();
        public int Accion = 0;
        public int ReciboId = 0;
        public int ClienteId = 0;
        public string Cuenta = "";
        public string Impresora = "EPSON TM-T20II Receipt5";

        public Recibos_Mantenimiento(ReciboCliente owner)
        {
            InitializeComponent();
            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }
        private void Recibos_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2); 
        }

        private void Recibos_Mantenimiento_Load(object sender, EventArgs e)
        {
            if (Accion == 1)
            {
                this.objcliente.ObtieneClientes(this.cmbCliente);
               this.objRecibo.ObtieneRecibos(this.txtRecibo);
            }

            if (Accion == 2)
            {
                this.objRecibo.Id = ReciboId;
                this.objcliente.ObtieneClientes(this.cmbCliente);
                this.objRecibo.ObtieneReciboBusqueda();
                txtRecibo.Text = Convert.ToString(this.objRecibo.Id);
                dtpFechaCreacion.Value = this.objRecibo.FechaCreacion;
                cmbCliente.SelectedValue = this.objRecibo.ClienteId;
                txtTotalLetras.Text = this.objRecibo.TotalLetras;
                txtTotal.Text = Convert.ToString(this.objRecibo.Total);
                txtConcepto.Text = this.objRecibo.Concepto;
                txtSaldoAnterior.Text = Convert.ToString(this.objRecibo.SaldoAnterior);
                txtAbono.Text = Convert.ToString(this.objRecibo.Abono);
                txtSaldoActual.Text = Convert.ToString(this.objRecibo.SaldoActual);
                txtNumeroCuenta.Text = this.objRecibo.Cuenta;
                int tipopago = this.objRecibo.TipoPago;
                if (tipopago == 1)
                    chkEfectivo.Checked = true;
                else if(tipopago == 2)
                    chkCheque.Checked = true;
            }

            if(Accion==3)
            {
                this.objcliente.ObtieneClientes(this.cmbCliente);
                this.objRecibo.ClienteId = ClienteId;
                this.objRecibo.Cuenta = Cuenta;
                this.objRecibo.ObtieneRecibos(this.txtRecibo);                
                this.objRecibo.obtenerultimo_abono();
                cmbCliente.SelectedValue = ClienteId;
                txtConcepto.Text ="ABONO "+""+Convert.ToString(this.objRecibo.Concepto);
              //  txtTotalLetras.Text = Convert.ToString(this.objRecibo.TotalLetras);
              //  txtTotal.Text = Convert.ToString(this.objRecibo.Total);
                txtSaldoAnterior.Text = Convert.ToString(this.objRecibo.SaldoActual);
                txtNumeroCuenta.Text = this.objRecibo.Cuenta;
                txtNumeroCuenta.Enabled = false;
                int tipopago = this.objRecibo.TipoPago;
                if (tipopago == 1)
                    chkEfectivo.Checked = true;
                else if (tipopago == 2)
                    chkCheque.Checked = true;
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

        public void ConstruyeTicket()
        {           
            try
            {

                this.objTicket.ReciboId =Convert.ToInt32(txtRecibo.Text);
                this.objTicket.FechaCreacion = dtpFechaCreacion.Value;
                this.objTicket.ClienteNombre = cmbCliente.Text;
                this.objTicket.ClienteCedula = txtCedula.Text;
                this.objTicket.TotalLetras = txtTotalLetras.Text;
                this.objTicket.Total = Convert.ToDecimal(txtTotal.Text);
                this.objTicket.Concepto = txtConcepto.Text;
                this.objTicket.SaldoAnterior = Convert.ToDecimal(txtSaldoAnterior.Text);
                this.objTicket.Abono = Convert.ToDecimal(txtAbono.Text);
                this.objTicket.SaldoActual = Convert.ToDecimal(txtSaldoActual.Text);
                this.objTicket.NumCuenta = txtNumeroCuenta.Text;
                if (chkEfectivo.Checked)
                {
                    this.objTicket.TipoRecibo = "Efectivo";

                }
                else if (chkCheque.Checked)
                {
                    this.objTicket.TipoRecibo = "Cheque";

                }


                this.objTicket.print();

                this.objTicket.Offset = 40;
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
            if (Accion == 1)
            {
                if (txtNumeroCuenta.Text == " ")
                {
                    MessageBox.Show("El numero de cuenta no puede estar vacio");
                }

                else
                {
                if (this.objRecibo.VerificaCuenta(txtNumeroCuenta.Text))
                {
                     MessageBox.Show("El numero de cuenta ya fue usado anteriormente,debe digitar otro");
                          return;
                }
                  DialogResult result = MessageBox.Show("¿Está seguro que desea crear el recibo ?", "Confirmación", MessageBoxButtons.OKCancel);
                  this.objRecibo.FechaCreacion = Convert.ToDateTime(dtpFechaCreacion.Value);
                  this.objRecibo.ClienteId = Convert.ToInt32(cmbCliente.SelectedValue);
                  this.objRecibo.TotalLetras = txtTotalLetras.Text;
                  this.objRecibo.Total = Convert.ToDecimal(txtTotal.Text);
                  this.objRecibo.Concepto = txtConcepto.Text;
                  this.objRecibo.SaldoAnterior = Convert.ToDecimal(txtSaldoAnterior.Text);
                  this.objRecibo.Abono = Convert.ToDecimal(txtAbono.Text);
                  this.objRecibo.SaldoActual = Convert.ToDecimal(txtSaldoActual.Text);
                  this.objRecibo.Cuenta = txtNumeroCuenta.Text;

                  if (this.objRecibo.SaldoActual == 0)
                  {
                      this.objRecibo.Activo = false;
                      this.objRecibo.CancelaAbono();
                  }
                  else
                      this.objRecibo.Activo = true;

                  if (chkEfectivo.Checked)
                  {
                      this.objRecibo.TipoPago = 1;

                  }
                  else if (chkCheque.Checked)
                  {
                      this.objRecibo.TipoPago = 2;

                  }
                  else
                      this.objRecibo.TipoPago = 1;

                  if (result == DialogResult.OK)
                  {
                      if (this.objRecibo.AgregaRecibo())
                      {
                          
                          DialogResult result2 = MessageBox.Show("Recibo creado exitosamente,¿Desea imprimirlo?", "Confirmación", MessageBoxButtons.OKCancel);
                          if (result2 == DialogResult.OK)
                          {
                              //PrinterSettings ps = new PrinterSettings();
                              //foreach (string printer in PrinterSettings.InstalledPrinters)
                              //{
                              //    ps.PrinterName = printer;
                              //    if (ps.IsDefaultPrinter)
                              //    {
                              //        Impresora = printer;
                              //    }
                              //}

                              //RawPrinterHelper.SendStringToPrinter(Impresora, System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, 112, 48, 55, 121 }));//para abrir la caja


                              this.ConstruyeTicket();

                          }
                      }
                  }
              
            }
            }
            if (Accion == 2)
            {
                if (txtNumeroCuenta.Text == " ")
                {
                    MessageBox.Show("El numero de cuenta no puede estar vacio");
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el recibo?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        this.objRecibo.Id = Convert.ToInt32(this.txtRecibo.Text);
                        this.objRecibo.FechaCreacion = Convert.ToDateTime(dtpFechaCreacion.Value);
                        this.objRecibo.ClienteId = Convert.ToInt32(cmbCliente.SelectedValue);
                        this.objRecibo.TotalLetras = txtTotalLetras.Text;
                        this.objRecibo.Total = Convert.ToDecimal(txtTotal.Text);
                        this.objRecibo.Concepto = txtConcepto.Text;
                        this.objRecibo.SaldoAnterior = Convert.ToDecimal(txtSaldoAnterior.Text);
                        this.objRecibo.Abono = Convert.ToDecimal(txtAbono.Text);
                        this.objRecibo.SaldoActual = Convert.ToDecimal(txtSaldoActual.Text);
                        this.objRecibo.Cuenta = txtNumeroCuenta.Text;
                        if (chkEfectivo.Checked)
                        {
                            this.objRecibo.TipoPago = 1;

                        }
                        else if (chkCheque.Checked)
                        {
                            this.objRecibo.TipoPago = 2;

                        }
                        else
                            this.objRecibo.TipoPago = 1;

                        if (this.objRecibo.SaldoActual == 0)
                        {
                            this.objRecibo.Activo = false;
                            this.objRecibo.CancelaAbono();
                        }
                        else
                            this.objRecibo.Activo = true;

                        this.objRecibo.ModificaRecibo();

                        MessageBox.Show("Recibo modificado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            if (Accion == 3)
            {
                if (txtNumeroCuenta.Text == " ")
                {
                    MessageBox.Show("El numero de cuenta no puede estar vacio");
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea realizar el abono ?", "Confirmación", MessageBoxButtons.OKCancel);
                    this.objRecibo.FechaCreacion = Convert.ToDateTime(dtpFechaCreacion.Value);
                    this.objRecibo.ClienteId = Convert.ToInt32(cmbCliente.SelectedValue);
                    this.objRecibo.TotalLetras = txtTotalLetras.Text;
                    this.objRecibo.Total = Convert.ToDecimal(txtTotal.Text);
                    this.objRecibo.Concepto = txtConcepto.Text;
                    this.objRecibo.SaldoAnterior = Convert.ToDecimal(txtSaldoAnterior.Text);
                    this.objRecibo.Abono = Convert.ToDecimal(txtAbono.Text);
                    this.objRecibo.SaldoActual = Convert.ToDecimal(txtSaldoActual.Text);
                    this.objRecibo.Cuenta = txtNumeroCuenta.Text;
                    if (chkEfectivo.Checked)
                    {
                        this.objRecibo.TipoPago = 1;

                    }
                    else if (chkCheque.Checked)
                    {
                        this.objRecibo.TipoPago = 2;

                    }
                    else
                        this.objRecibo.TipoPago = 1;

                    if (this.objRecibo.SaldoActual == 0)
                    {
                        this.objRecibo.Activo = false;
                        this.objRecibo.CancelaAbono();
                    }
                    else
                        this.objRecibo.Activo = true;

                    if (result == DialogResult.OK)
                    {
                        if (this.objRecibo.AgregaRecibo())
                        {
                            DialogResult result2 = MessageBox.Show("Abono registrado exitosamente,¿Desea imprimir el recibo?", "Confirmación", MessageBoxButtons.OKCancel);
                            if (result2 == DialogResult.OK)
                            {
                                //PrinterSettings ps = new PrinterSettings();
                                //foreach (string printer in PrinterSettings.InstalledPrinters)
                                //{
                                //    ps.PrinterName = printer;
                                //    if (ps.IsDefaultPrinter)
                                //    {
                                //        Impresora = printer;
                                //    }
                                //}

                                //RawPrinterHelper.SendStringToPrinter(Impresora, System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, 112, 48, 55, 121 }));//para abrir la caja


                                this.ConstruyeTicket();

                            }
                        }
                    }
                }

            }
            this._owner.ReciboCliente_Load(sender, e);
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.objcliente.Id = Convert.ToInt32(cmbCliente.SelectedValue);
            this.objcliente.ObtieneClienteBusqueda();
            this.txtCedula.Text = objcliente.Cedula;
        }

        private void txtAbono_TextChanged(object sender, EventArgs e)
        {
            if (txtAbono.Text=="")
                txtAbono.Text="0.00";
            txtSaldoActual.Text =Convert.ToString(Convert.ToDecimal(txtSaldoAnterior.Text) - Convert.ToDecimal(txtAbono.Text));
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this._owner.ReciboCliente_Load(sender, e);
            this.Close();
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {

        }
    }
}
