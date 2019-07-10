using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Restaurante_BL
{
    public class Ticket
    {
        Restaurante_DAL.BaseDatosDataContext db = null;
        public string Impresora = string.Empty;

        Restaurante_BL.CComandaCocina objComandaCocina = new Restaurante_BL.CComandaCocina();
        Restaurante_BL.CComandaBar objComandaBar = new CComandaBar();

        public int Accion = 0;//1 prefactura 2 factura

        #region propiedades
        private string _Salonero;

        public string Salonero
        {
            get { return _Salonero; }
            set { _Salonero = value; }
        }

        private string _RolDescripcion;

        public string RolDescripcion
        {
            get { return _RolDescripcion; }
            set { _RolDescripcion = value; }
        }




        private Int64 _OrdenId;

        public Int64 OrdenId
        {
            get { return _OrdenId; }
            set { _OrdenId = value; }
        }

        public List<string> ListaComanda = new List<string>();

        public List<string> ListaComandaImprimir = new List<string>();

        public List<string> ListaComandaBar = new List<string>();

        public List<string> ListaComandaBarImprimir = new List<string>();

        private string _LineaImpresion;

        public string LineaImpresion
        {
            get { return _LineaImpresion; }
            set { _LineaImpresion = value; }
        }

        private decimal _Propina;

        public decimal Propina
        {
            get { return _Propina; }
            set { _Propina = value; }
        }

        private int _UserId;

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private decimal _Desc_Aplicado;

        public decimal Desc_Aplicado
        {
            get { return _Desc_Aplicado; }
            set { _Desc_Aplicado = value; }
        }


        private string _Hora;

        public string Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }

        private int _AltoPapel;

        public int AltoPapel
        {
            get { return _AltoPapel; }
            set { _AltoPapel = value; }
        }

        public decimal _Impuesto;

        public decimal Impuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
        }

        public decimal _ImpServicio;
        public decimal ImpServicio
        {
            get { return _ImpServicio; }
            set { _ImpServicio = value; }
        }


        public decimal _Subtotal;
        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }


        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Dueno;

        public string Dueno
        {
            get { return _Dueno; }
            set { _Dueno = value; }
        }

        private string _Cedula;

        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }

        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private string _Fax;

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        private string _PiePagina;

        public string PiePagina
        {
            get { return _PiePagina; }
            set { _PiePagina = value; }
        }
        private string _PiePagina2;

        public string PiePagina2
        {
            get { return _PiePagina2; }
            set { _PiePagina2 = value; }
        }
        private string _PiePagina3;

        public string PiePagina3
        {
            get { return _PiePagina3; }
            set { _PiePagina3 = value; }
        }
        private string _PiePagina4;

        public string PiePagina4
        {
            get { return _PiePagina4; }
            set { _PiePagina4 = value; }
        }

        private string _FinalPagina;

        public string FinalPagina
        {
            get { return _FinalPagina; }
            set { _FinalPagina = value; }
        }


        private Int64 _FacturaId;

        public Int64 FacturaId
        {
            get { return _FacturaId; }
            set { _FacturaId = value; }
        }

        private string _ClienteNombre;

        public string ClienteNombre
        {
            get { return _ClienteNombre; }
            set { _ClienteNombre = value; }
        }

        private string _CajeroNombre;

        public string CajeroNombre
        {
            get { return _CajeroNombre; }
            set { _CajeroNombre = value; }
        }

        private string _TipoFactura;

        public string TipoFactura
        {
            get { return _TipoFactura; }
            set { _TipoFactura = value; }
        }


        private decimal _TotalFactura;

        public decimal TotalFactura
        {
            get { return _TotalFactura; }
            set { _TotalFactura = value; }
        }

        private decimal _Recibido;

        public decimal Recibido
        {
            get { return _Recibido; }
            set { _Recibido = value; }
        }

        private decimal _Cambio;

        public decimal Cambio
        {
            get { return _Cambio; }
            set { _Cambio = value; }
        }

        private int _MesaId;

        public int MesaId
        {
            get { return _MesaId; }
            set { _MesaId = value; }
        }


        public List<string> Articulos = new List<string>();

        public List<string> Marcas = new List<string>();

        public List<string> Facturas = new List<string>();

        public string _TipoDocumento { get; set; }
        public string _Clave { get; set; }

        public int Offset = 0;
        #endregion

        #region metodos

        [DllImport("winspool.drv",
              CharSet = CharSet.Auto,
              SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean SetDefaultPrinter(String name);

        public void ObtieneInformacionGeneral()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.InformacionGeneral
                           select x);


                if (bus.Count() > 0)
                {
                    _Nombre = bus.First().Nombre;
                    _Dueno = bus.First().Dueno;
                    _Cedula = bus.First().Cedula;
                    _Telefono = bus.First().Telefono;
                    _Fax = bus.First().Fax;
                    _PiePagina = bus.First().PiePagina1;
                    _PiePagina2 = bus.First().PiePagina2;
                    _PiePagina3 = bus.First().PiePagina3;
                    _PiePagina4 = bus.First().PiePagina4;
                    _FinalPagina = bus.First().FinalPagina;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información general de la empresa: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        decimal publicwidth = 0;

        //        public void print()
        //        {
        //            //SetDefaultPrinter(Impresora);

        //            PrintDialog pd = new PrintDialog();
        //            PrintDocument pdoc = new PrintDocument();
        //            PrinterSettings ps = new PrinterSettings();
        //            ////tablet
        //            //if (Accion != 3)
        //            //{
        //            //    foreach (string printer in PrinterSettings.InstalledPrinters)
        //            //    {
        //            //        ps.PrinterName = printer;
        //            //        if (ps.IsDefaultPrinter)
        //            //        {
        //            //            Impresora = printer;
        //            //        }
        //            //    }
        //            //    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

        //            //    pdoc.PrinterSettings.PrinterName = Impresora;

        //            //    pd.Document = pdoc;

        //            //    pdoc.Print();
        //            //}
        //            //else
        //            //{
        //            //    Impresora = @"\" + @"\" + "ELVIEJOSERVER";
        //            //    //Impresora += "'\'";
        //            //    Impresora += @"\" + "impresoracomandacocina";


        //            //    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

        //            //    pdoc.PrinterSettings.PrinterName = Impresora;

        //            //    pd.Document = pdoc;

        //            //    //DialogResult result = pd.ShowDialog();//
        //            //    //if (result == DialogResult.OK)//
        //            //    //{//
        //            //    //    PrintPreviewDialog pp = new PrintPreviewDialog();//
        //            //    //    pp.Document = pdoc;//
        //            //    //    result = pp.ShowDialog();//
        //            //    //    if (result == DialogResult.OK)//
        //            //    //    {//
        //            //    //        pdoc.Print();//
        //            //    //    }//
        //            //    //}//

        //            //    pdoc.Print();
        //            //}

        //            //Server
        //            //se comenta de la linea 366 a 426/**/
        ///*            if (Accion != 3)
        //            {
        //                foreach (string printer in PrinterSettings.InstalledPrinters)
        //                {
        //                    ps.PrinterName = printer;
        //                    if (ps.IsDefaultPrinter)
        //                    {
        //                        Impresora = printer;
        //                    }
        //                }
        //                pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

        //                //pdoc.PrinterSettings.PrinterName = @"\\ELVIEJOSERVER\impresoracomandacocina";
        //                pdoc.PrinterSettings.PrinterName = Impresora;

        //                pd.Document = pdoc;


        //                //DialogResult result = pd.ShowDialog();//
        //                //if (result == DialogResult.OK)//
        //                //{//
        //                //    PrintPreviewDialog pp = new PrintPreviewDialog();//
        //                //    pp.Document = pdoc;//
        //                //    result = pp.ShowDialog();//
        //                //    if (result == DialogResult.OK)//
        //                //    {//
        //                //        pdoc.Print();//
        //                //    }//
        //                //}//

        //                pdoc.Print();
        //            }
        //            else
        //            {
        //                Impresora = "impresoracomandacocina";

        //                //foreach (string printer in PrinterSettings.InstalledPrinters)
        //                //{
        //                //    ps.PrinterName = printer;
        //                //    if (ps.IsDefaultPrinter)
        //                //    {
        //                //        Impresora = printer;
        //                //    }
        //                //}







        //                pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

        //                pdoc.PrinterSettings.PrinterName = Impresora;

        //                pd.Document = pdoc;

        //                pdoc.Print();
        //            }

        //            */

        //            //pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

        //            //pdoc.PrinterSettings.PrinterName = Impresora;

        //            //pd.Document = pdoc;

        //            //DialogResult result = pd.ShowDialog();//
        //            //if (result == DialogResult.OK)//
        //            //{//
        //            //    PrintPreviewDialog pp = new PrintPreviewDialog();//
        //            //    pp.Document = pdoc;//
        //            //    result = pp.ShowDialog();//
        //            //    if (result == DialogResult.OK)//
        //            //    {//
        //            //        pdoc.Print();//
        //            //    }//
        //            //}//

        //            //pdoc.Print();

        //            switch (Accion)
        //            {
        //                case 1://prefactura:
        //                case 2://factura:
        //                case 5://marcas empleado:
        //                case 6://reportes de ventas de facturas:
        //                    foreach (string printer in PrinterSettings.InstalledPrinters)
        //                    {
        //                        ps.PrinterName = printer;
        //                        if (ps.IsDefaultPrinter)
        //                        {
        //                            Impresora = printer;
        //                        }
        //                    }
        //                break;
        //                case 3://comanda cocina:
        //                    Impresora = "impresoracomandacocina";
        //                break;
        //                case 4://comanda bar:
        //                    Impresora = "impresoracomandabar";
        //                break;
        //            }

        //            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

        //            pdoc.PrinterSettings.PrinterName = Impresora;

        //            pd.Document = pdoc;

        //            pdoc.Print();
        //        }
        public void print()
        {
            //SetDefaultPrinter(Impresora);

            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            //tablet
            if (Accion != 3)
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    ps.PrinterName = printer;
                    if (ps.IsDefaultPrinter)
                    {
                        Impresora = printer;
                    }
                }
                pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

                pdoc.PrinterSettings.PrinterName = Impresora;

                pd.Document = pdoc;

                pdoc.Print();
            }
            else
            {
                // Impresora = @"\" + @"\" + "ELVIEJOSERVER";

                //   Impresora = @"\" + @"\" + "DESKTOP-I163RLC";

                Impresora += "'\'";

                Impresora += @"\" + "impresoracomandacocina";


                pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

                pdoc.PrinterSettings.PrinterName = Impresora;

                pd.Document = pdoc;

                //DialogResult result = pd.ShowDialog();//
                //if (result == DialogResult.OK)//
                //{//
                //    PrintPreviewDialog pp = new PrintPreviewDialog();//
                //    pp.Document = pdoc;//
                //    result = pp.ShowDialog();//
                //    if (result == DialogResult.OK)//
                //    {//
                //        pdoc.Print();//
                //    }//
                //}//

                pdoc.Print();
            }

            ////Server
            //if (Accion != 3)
            //{
            //    foreach (string printer in PrinterSettings.InstalledPrinters)
            //    {
            //        ps.PrinterName = printer;
            //        if (ps.IsDefaultPrinter)
            //        {
            //            Impresora = printer;
            //        }
            //    }
            //    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            //    //pdoc.PrinterSettings.PrinterName = @"\\Admin-pc\epson";
            //    pdoc.PrinterSettings.PrinterName = Impresora;

            //    pd.Document = pdoc;


            //    //DialogResult result = pd.ShowDialog();//
            //    //if (result == DialogResult.OK)//
            //    //{//
            //    //    PrintPreviewDialog pp = new PrintPreviewDialog();//
            //    //    pp.Document = pdoc;//
            //    //    result = pp.ShowDialog();//
            //    //    if (result == DialogResult.OK)//
            //    //    {//
            //    //        pdoc.Print();//
            //    //    }//
            //    //}//

            //    pdoc.Print();
            //}
            //else
            //{
            //    //Impresora = "impresoracomandacocina";

            //    foreach (string printer in PrinterSettings.InstalledPrinters)
            //    {
            //        ps.PrinterName = printer;
            //        if (ps.IsDefaultPrinter)
            //        {
            //            Impresora = printer;
            //        }
            ////    }

            //    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            //    pdoc.PrinterSettings.PrinterName = Impresora;

            //    pd.Document = pdoc;

            //    pdoc.Print();
            //}





            //pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            //pdoc.PrinterSettings.PrinterName = Impresora;

            //pd.Document = pdoc;

            //DialogResult result = pd.ShowDialog();//
            //if (result == DialogResult.OK)//
            //{//
            //    PrintPreviewDialog pp = new PrintPreviewDialog();//
            //    pp.Document = pdoc;//
            //    result = pp.ShowDialog();//
            //    if (result == DialogResult.OK)//
            //    {//
            //        pdoc.Print();//
            //    }//
            //}//

            //pdoc.Print();
        }
        public void Prefactura(object sender, PrintPageEventArgs e)
        {
            string Impresora = string.Empty;

            Graphics graphics = e.Graphics;
            Font font = new Font("Merchant Copy Doublesize", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;
            //int startY = -400;
            int startY = 0;


            this.OpenConn();

            var bus = from x in db.InformacionGeneral
                      select x;

            if (bus.Count() > 0)
            {
                Impresora = bus.First().Impresora.ToString();
            }

            if (Impresora == "TM-T20II")
            {
                startY = 0;

                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                    new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 105, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("PreFactura", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);
                Offset = Offset + 17;

                //graphics.DrawString("Factura: " + _FacturaId + "   ." + _TipoFactura, new Font("Merchant Copy Doublesize", 8),
                //        new SolidBrush(Color.Black), startX, startY + Offset);
                //Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Tipo Servicio      : Restaurante", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;


                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Caja       : " + Equipo.Id.ToString() + "  Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Salonero   : " + _CajeroNombre, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (this._ClienteNombre.Length > 0)
                {
                    graphics.DrawString("Cliente   : " + _ClienteNombre, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                graphics.DrawString("Cuenta     : Mesa " + _MesaId, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                string x = "-----------------------------------------";

                graphics.DrawString("CANT.", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString("DESCRIPCION.", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 35, startY + Offset);

                graphics.DrawString("TOTAL.", new Font("Merchant Copy Doublesize", 7),
                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal tempsubtotal = 0;

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    graphics.DrawString(temp[0].ToUpper(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    if (temp[1].Length > 16)
                    {
                        graphics.DrawString(temp[1].Substring(0, 15).ToUpper(), new Font("Merchant Copy Doublesize", 7),
                                new SolidBrush(Color.Black), startX + 32, startY + Offset);
                    }
                    else
                    {
                        graphics.DrawString(temp[1].ToUpper(), new Font("Merchant Copy Doublesize", 7),
                                new SolidBrush(Color.Black), startX + 32, startY + Offset);
                    }

                    decimal val = Convert.ToDecimal((temp[2]));
                    decimal tempval = Convert.ToDecimal(val / (Convert.ToDecimal(bus.First().IVA)));

                    tempsubtotal += tempval;
                    temp[2] = tempval.ToString("F");

                    switch (temp[2].Length)
                    {
                        case 5:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 245, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 240, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 235, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 230, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 225, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }

                    Offset = Offset + 16;
                }

                graphics.DrawString(x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal porIVA = 0;

                decimal subtotal = 0;

                porIVA = Convert.ToDecimal((bus.First().IVA) / 100);

                //decimal impventas = (_TotalFactura * porIVA);
                //decimal impserv = (_TotalFactura * porImpServicio);

                decimal impventas = (tempsubtotal * porIVA);

                if (_Desc_Aplicado > 0)
                {
                    //subtotal = _TotalFactura - impventas - impserv - _Desc_Aplicado;
                    //subtotal = _TotalFactura - impventas - impserv;

                    tempsubtotal -= _Desc_Aplicado;
                }
                else
                {
                    //subtotal = _TotalFactura - impventas - impserv;

                }
                string underline = "---------";

                graphics.DrawString("SUBTOTAL : ", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 130, startY + Offset);

                string temp1 = Convert.ToDecimal(tempsubtotal).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }

                //Offset = Offset + 17;

                //if (_Desc_Aplicado > 0)
                //{
                //    graphics.DrawString("DESCUENTO : ", new Font("Merchant Copy Doublesize", 8),
                //            new SolidBrush(Color.Black), startX + 122, startY + Offset);

                //    temp1 = Convert.ToDecimal(_Desc_Aplicado).ToString("F");
                //    switch (temp1.Length)
                //    {
                //        case 4:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 260, startY + Offset);
                //                break;
                //            }
                //        case 5:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                //                break;
                //            }
                //        case 6:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 245, startY + Offset);
                //                break;
                //            }
                //        case 7:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 240, startY + Offset);
                //                break;
                //            }
                //        case 8:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 235, startY + Offset);
                //                break;
                //            }
                //        case 9:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 230, startY + Offset);
                //                break;
                //            }
                //        case 10:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 225, startY + Offset);
                //                break;
                //            }
                //        default:
                //            break;
                //    }
                //    Offset = Offset + 17;
                //}

                //graphics.DrawString("IMP.VTAS : ", new Font("Merchant Copy Doublesize", 8),
                //        new SolidBrush(Color.Black), startX + 130, startY + Offset);

                //temp1 = Convert.ToDecimal(impventas).ToString("F");
                //switch (temp1.Length)
                //{
                //    case 5:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 250, startY + Offset);
                //            break;
                //        }
                //    case 6:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 245, startY + Offset);
                //            break;
                //        }
                //    case 7:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 240, startY + Offset);
                //            break;
                //        }
                //    case 8:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 235, startY + Offset);
                //            break;
                //        }
                //    case 9:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 230, startY + Offset);
                //            break;
                //        }
                //    case 10:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 225, startY + Offset);
                //            break;
                //        }
                //    default:
                //        break;
                //}
                //Offset = Offset + 17;
                //if (_MesaId < 17)
                //{
                //graphics.DrawString("IMP.SERV : ", new Font("Merchant Copy Doublesize", 8),
                //        new SolidBrush(Color.Black), startX + 130, startY + Offset);

                //temp1 = Convert.ToDecimal(0).ToString("F");
                //switch (temp1.Length)
                //{
                //    case 5:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 250, startY + Offset);
                //            break;
                //        }
                //    case 6:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 245, startY + Offset);
                //            break;
                //        }
                //    case 7:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 240, startY + Offset);
                //            break;
                //        }
                //    case 8:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 235, startY + Offset);
                //            break;
                //        }
                //    case 9:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 230, startY + Offset);
                //            break;
                //        }
                //    case 10:
                //        {
                //            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                   new SolidBrush(Color.Black), startX + 225, startY + Offset);
                //            break;
                //        }
                //    default:
                //        break;
                //}
                //}
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L : ", new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX + 122, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L  $ : ", new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX + 98, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura / Convert.ToDecimal(bus.First().TipoCambio)).ToString("F");
                switch (temp1.Length)
                {
                    case 4:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 260, startY + Offset);
                            break;
                        }
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Propina : ", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 6;

                graphics.DrawString("------------------------------", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 65, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_PiePagina.Length > 0)
                {
                    graphics.DrawString(_PiePagina, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina2.Length > 0)
                {
                    graphics.DrawString(_PiePagina2, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina3.Length > 0)
                {
                    graphics.DrawString(_PiePagina3, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina4.Length > 0)
                {
                    graphics.DrawString(_PiePagina4, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
                if (_FinalPagina.Length > 0)
                {
                    graphics.DrawString(_FinalPagina, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
            }







            if (Impresora == "TM-U220")
            {
                //startY = -450;
                startY = 0;

                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 8),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 90, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Factura : " + _FacturaId, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 80, startY + Offset);
                Offset = Offset + 17;

                //graphics.DrawString("Factura: " + _FacturaId + "   ." + _TipoFactura, new Font("Merchant Copy Doublesize", 8),
                //        new SolidBrush(Color.Black), startX, startY + Offset);
                //Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Tipo Servicio      : Restaurante", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;


                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Caja        : " + Equipo.Id.ToString() + "  Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Salonero  : " + _CajeroNombre, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                if (this._ClienteNombre.Length > 0)
                {
                    graphics.DrawString("Cliente   : " + _ClienteNombre, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("Cuenta      : Mesa " + _MesaId, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                string x = "-----------------------------------------";

                graphics.DrawString("CANT.", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString("DESCRIPCION.", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 40, startY + Offset);

                graphics.DrawString("TOTAL.", new Font("Merchant Copy Doublesize", 9),
                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal tempsubtotal = 0;

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    graphics.DrawString(temp[0].ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    if (temp[1].Length > 16)
                    {
                        graphics.DrawString(temp[1].Substring(0, 15).ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 40, startY + Offset);
                    }
                    else
                    {
                        graphics.DrawString(temp[1].ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 40, startY + Offset);
                    }

                    decimal val = Convert.ToDecimal((temp[2]));
                    string xy = "1." + Convert.ToDecimal(bus.First().IVA).ToString("#");
                    decimal tempval = Convert.ToDecimal(val / Convert.ToDecimal(xy));

                    tempsubtotal += tempval;
                    temp[2] = tempval.ToString("F");

                    switch (temp[2].Length)
                    {
                        case 5:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }


                    Offset = Offset + 17;
                }

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal porIVA = 0;

                decimal subtotal = 0;

                porIVA = Convert.ToDecimal((bus.First().IVA) / 100);

                //decimal impventas = (_TotalFactura * porIVA);
                //decimal impserv = (_TotalFactura * porImpServicio);

                decimal impventas = (tempsubtotal * porIVA);

                if (_Desc_Aplicado > 0)
                {
                    //subtotal = _TotalFactura - impventas - impserv - _Desc_Aplicado;
                    //subtotal = _TotalFactura - impventas - impserv;

                    tempsubtotal -= _Desc_Aplicado;
                }
                else
                {
                    //subtotal = _TotalFactura - impventas - impserv;

                }
                string underline = "---------";

                graphics.DrawString("SUBTOTAL : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);

                string temp1 = Convert.ToDecimal(tempsubtotal).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }

                Offset = Offset + 17;

                if (_Desc_Aplicado > 0)
                {
                    graphics.DrawString("DESCUENTO : ", new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 100, startY + Offset);

                    temp1 = Convert.ToDecimal(_Desc_Aplicado).ToString("F");
                    switch (temp1.Length)
                    {
                        case 4:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 205, startY + Offset);
                                break;
                            }
                        case 5:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 195, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 185, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 180, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 175, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }
                    Offset = Offset + 17;
                }

                graphics.DrawString("IMP.VTAS : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(impventas).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                //Offset = Offset + 17;

                //graphics.DrawString("IMP.SERV : ", new Font("Merchant Copy Doublesize", 9),
                //        new SolidBrush(Color.Black), startX + 100, startY + Offset);
                //if (_MesaId < 17)
                //{
                //    temp1 = Convert.ToDecimal(0).ToString("F");
                //    switch (temp1.Length)
                //    {
                //        case 5:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 200, startY + Offset);
                //                break;
                //            }
                //        case 6:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 195, startY + Offset);
                //                break;
                //            }
                //        case 7:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                //                break;
                //            }
                //        case 8:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 185, startY + Offset);
                //                break;
                //            }
                //        case 9:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 180, startY + Offset);
                //                break;
                //            }
                //        case 10:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 175, startY + Offset);
                //                break;
                //            }
                //        default:
                //            break;
                //    }
                //}
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L : ", new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L  $ : ", new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura / Convert.ToDecimal(bus.First().TipoCambio)).ToString("F");
                switch (temp1.Length)
                {
                    case 4:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 205, startY + Offset);
                            break;
                        }
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Recibido  : " + Convert.ToDecimal(_Recibido).ToString("F"), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Su cambio : " + _Cambio, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Propina : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString(underline.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 35, startY + Offset);
                Offset = Offset + 7;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_PiePagina.Length > 0)
                {
                    graphics.DrawString(_PiePagina, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina2.Length > 0)
                {
                    graphics.DrawString(_PiePagina2, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina3.Length > 0)
                {
                    graphics.DrawString(_PiePagina3, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina4.Length > 0)
                {
                    graphics.DrawString(_PiePagina4, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                if (_FinalPagina.Length > 0)
                {
                    graphics.DrawString(_FinalPagina, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
            }
            this.CloseConn();
        }

        public void Prefactura1(object sender, PrintPageEventArgs e)
        {
            string Impresora = string.Empty;

            Graphics graphics = e.Graphics;
            Font font = new Font("Merchant Copy Doublesize", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;
            //int startY = -400;
            int startY = 0;


            this.OpenConn();

            var bus = from x in db.InformacionGeneral
                      select x;

            if (bus.Count() > 0)
            {
                Impresora = bus.First().Impresora.ToString();
            }

            if (Impresora == "TM-T20II")
            {
                startY = 0;

                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                    new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 105, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("PreFactura", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);
                Offset = Offset + 17;

                //graphics.DrawString("Factura: " + _FacturaId + "   ." + _TipoFactura, new Font("Merchant Copy Doublesize", 8),
                //        new SolidBrush(Color.Black), startX, startY + Offset);
                //Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Tipo Servicio      : Restaurante", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;


                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Caja       : " + Equipo.Id.ToString() + "  Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Salonero   : " + _CajeroNombre, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (this._ClienteNombre.Length > 0)
                {
                    graphics.DrawString("Cliente   : " + _ClienteNombre, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                graphics.DrawString("Cuenta     : Mesa " + _MesaId, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                string x = "-----------------------------------------";

                graphics.DrawString("CANT.", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString("DESCRIPCION.", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 35, startY + Offset);

                graphics.DrawString("TOTAL.", new Font("Merchant Copy Doublesize", 7),
                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal tempsubtotal = 0;

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    graphics.DrawString(temp[0].ToUpper(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    if (temp[1].Length > 16)
                    {
                        graphics.DrawString(temp[1].Substring(0, 15).ToUpper(), new Font("Merchant Copy Doublesize", 7),
                                new SolidBrush(Color.Black), startX + 32, startY + Offset);
                    }
                    else
                    {
                        graphics.DrawString(temp[1].ToUpper(), new Font("Merchant Copy Doublesize", 7),
                                new SolidBrush(Color.Black), startX + 32, startY + Offset);
                    }

                    decimal val = Convert.ToDecimal((temp[2]));
                    decimal tempval = Convert.ToDecimal(val / (Convert.ToDecimal(bus.First().IVA)));

                    tempsubtotal += tempval;
                    temp[2] = tempval.ToString("F");

                    switch (temp[2].Length)
                    {
                        case 5:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 245, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 240, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 235, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 230, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 225, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }

                    Offset = Offset + 16;
                }

                graphics.DrawString(x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal porIVA = 0;
                decimal porImpServicio = 0;
                decimal subtotal = 0;

                porImpServicio = Convert.ToDecimal((bus.First().ImpuestoServicio) / 100);
                porIVA = Convert.ToDecimal((bus.First().IVA) / 100);

                //decimal impventas = (_TotalFactura * porIVA);
                //decimal impserv = (_TotalFactura * porImpServicio);

                decimal impventas = (tempsubtotal * porIVA);
                decimal impserv = (tempsubtotal * porImpServicio);

                if (_Desc_Aplicado > 0)
                {
                    //subtotal = _TotalFactura - impventas - impserv - _Desc_Aplicado;
                    //subtotal = _TotalFactura - impventas - impserv;

                    tempsubtotal -= _Desc_Aplicado;
                }
                else
                {
                    //subtotal = _TotalFactura - impventas - impserv;

                }
                string underline = "---------";

                graphics.DrawString("SUBTOTAL : ", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 130, startY + Offset);

                string temp1 = Convert.ToDecimal(tempsubtotal).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }

                Offset = Offset + 17;

                if (_Desc_Aplicado > 0)
                {
                    graphics.DrawString("DESCUENTO : ", new Font("Merchant Copy Doublesize", 8),
                            new SolidBrush(Color.Black), startX + 122, startY + Offset);

                    temp1 = Convert.ToDecimal(_Desc_Aplicado).ToString("F");
                    switch (temp1.Length)
                    {
                        case 4:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 260, startY + Offset);
                                break;
                            }
                        case 5:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 245, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 240, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 235, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 230, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 225, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }
                    Offset = Offset + 17;
                }

                graphics.DrawString("IMP.VTAS : ", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 130, startY + Offset);

                temp1 = Convert.ToDecimal(impventas).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                //Offset = Offset + 17;
                //if (_MesaId < 17)
                //{
                //    graphics.DrawString("IMP.SERV : ", new Font("Merchant Copy Doublesize", 8),
                //            new SolidBrush(Color.Black), startX + 130, startY + Offset);

                //    temp1 = Convert.ToDecimal(impserv).ToString("F");
                //    switch (temp1.Length)
                //    {
                //        case 5:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                //                break;
                //            }
                //        case 6:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 245, startY + Offset);
                //                break;
                //            }
                //        case 7:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 240, startY + Offset);
                //                break;
                //            }
                //        case 8:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 235, startY + Offset);
                //                break;
                //            }
                //        case 9:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 230, startY + Offset);
                //                break;
                //            }
                //        case 10:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                //                       new SolidBrush(Color.Black), startX + 225, startY + Offset);
                //                break;
                //            }
                //        default:
                //            break;
                //    }
                //}
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L : ", new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX + 122, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L  $ : ", new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX + 98, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura / Convert.ToDecimal(bus.First().TipoCambio)).ToString("F");
                switch (temp1.Length)
                {
                    case 4:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 260, startY + Offset);
                            break;
                        }
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                   new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Propina : ", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 6;

                graphics.DrawString("------------------------------", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 65, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_PiePagina.Length > 0)
                {
                    graphics.DrawString(_PiePagina, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina2.Length > 0)
                {
                    graphics.DrawString(_PiePagina2, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina3.Length > 0)
                {
                    graphics.DrawString(_PiePagina3, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina4.Length > 0)
                {
                    graphics.DrawString(_PiePagina4, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
                if (_FinalPagina.Length > 0)
                {
                    graphics.DrawString(_FinalPagina, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
            }







            if (Impresora == "TM-U220")
            {
                //startY = -450;
                startY = 0;

                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 8),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 90, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Prefactura : " + _FacturaId, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 80, startY + Offset);
                Offset = Offset + 17;

                //graphics.DrawString("Factura: " + _FacturaId + "   ." + _TipoFactura, new Font("Merchant Copy Doublesize", 8),
                //        new SolidBrush(Color.Black), startX, startY + Offset);
                //Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Tipo Servicio      : Restaurante", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;


                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Caja        : " + Equipo.Id.ToString() + "  Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Salonero  : " + _CajeroNombre, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                if (this._ClienteNombre.Length > 0)
                {
                    graphics.DrawString("Cliente   : " + _ClienteNombre, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("Cuenta      : Mesa " + _MesaId, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                string x = "-----------------------------------------";

                graphics.DrawString("CANT.", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString("DESCRIPCION.", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 40, startY + Offset);

                graphics.DrawString("TOTAL.", new Font("Merchant Copy Doublesize", 9),
                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal tempsubtotal = 0;

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    graphics.DrawString(temp[0].ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    if (temp[1].Length > 16)
                    {
                        graphics.DrawString(temp[1].Substring(0, 15).ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 40, startY + Offset);
                    }
                    else
                    {
                        graphics.DrawString(temp[1].ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 40, startY + Offset);
                    }

                    decimal val = Convert.ToDecimal((temp[2]));
                    string xy = "1." + Convert.ToDecimal(bus.First().IVA).ToString("#");
                    decimal tempval = Convert.ToDecimal(val / Convert.ToDecimal(xy));

                    tempsubtotal += tempval;
                    temp[2] = tempval.ToString("F");

                    switch (temp[2].Length)
                    {
                        case 5:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }


                    Offset = Offset + 17;
                }

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal porIVA = 0;
                decimal porImpServicio = 0;
                decimal subtotal = 0;

                porImpServicio = Convert.ToDecimal((bus.First().ImpuestoServicio) / 100);
                porIVA = Convert.ToDecimal((bus.First().IVA) / 100);

                //decimal impventas = (_TotalFactura * porIVA);
                //decimal impserv = (_TotalFactura * porImpServicio);

                decimal impventas = (tempsubtotal * porIVA);
                decimal impserv = (tempsubtotal * porImpServicio);

                if (_Desc_Aplicado > 0)
                {
                    //subtotal = _TotalFactura - impventas - impserv - _Desc_Aplicado;
                    //subtotal = _TotalFactura - impventas - impserv;

                    tempsubtotal -= _Desc_Aplicado;
                }
                else
                {
                    //subtotal = _TotalFactura - impventas - impserv;

                }
                string underline = "---------";

                graphics.DrawString("SUBTOTAL : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);

                string temp1 = Convert.ToDecimal(tempsubtotal).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }

                Offset = Offset + 17;

                if (_Desc_Aplicado > 0)
                {
                    graphics.DrawString("DESCUENTO : ", new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 100, startY + Offset);

                    temp1 = Convert.ToDecimal(_Desc_Aplicado).ToString("F");
                    switch (temp1.Length)
                    {
                        case 4:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 205, startY + Offset);
                                break;
                            }
                        case 5:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 195, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 185, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 180, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 175, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }
                    Offset = Offset + 17;
                }

                graphics.DrawString("IMP.VTAS : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(impventas).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                //Offset = Offset + 17;
                //if (_MesaId < 17)
                //{
                //    graphics.DrawString("IMP.SERV : ", new Font("Merchant Copy Doublesize", 9),
                //            new SolidBrush(Color.Black), startX + 100, startY + Offset);

                //    temp1 = Convert.ToDecimal(impserv).ToString("F");
                //    switch (temp1.Length)
                //    {
                //        case 5:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 200, startY + Offset);
                //                break;
                //            }
                //        case 6:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 195, startY + Offset);
                //                break;
                //            }
                //        case 7:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                //                break;
                //            }
                //        case 8:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 185, startY + Offset);
                //                break;
                //            }
                //        case 9:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 180, startY + Offset);
                //                break;
                //            }
                //        case 10:
                //            {
                //                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                //                        new SolidBrush(Color.Black), startX + 175, startY + Offset);
                //                break;
                //            }
                //        default:
                //            break;
                //    }
                //}
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L : ", new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L  $ : ", new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura / Convert.ToDecimal(bus.First().TipoCambio)).ToString("F");
                switch (temp1.Length)
                {
                    case 4:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 205, startY + Offset);
                            break;
                        }
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Recibido  : " + Convert.ToDecimal(_Recibido).ToString("F"), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Su cambio : " + _Cambio, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Propina : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString(underline.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 35, startY + Offset);
                Offset = Offset + 7;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_PiePagina.Length > 0)
                {
                    graphics.DrawString(_PiePagina, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina2.Length > 0)
                {
                    graphics.DrawString(_PiePagina2, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina3.Length > 0)
                {
                    graphics.DrawString(_PiePagina3, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina4.Length > 0)
                {
                    graphics.DrawString(_PiePagina4, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                if (_FinalPagina.Length > 0)
                {
                    graphics.DrawString(_FinalPagina, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
            }
            this.CloseConn();
        }

        public void Factura1(object sender, PrintPageEventArgs e)
        {
            string Impresora = string.Empty;

            Graphics graphics = e.Graphics;
            Font font = new Font("Merchant Copy Doublesize", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;

            int startY = 0;

            this.OpenConn();

            var bus = from x in db.InformacionGeneral
                      select x;

            if (bus.Count() > 0)
            {
                Impresora = bus.First().Impresora.ToString();
            }

            #region TM-T20II
            if (Impresora == "TM-T20II")
            {
                startY = 0;
                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 105, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Factura : " + _FacturaId, new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 92, startY + Offset);
                Offset = Offset + 17;

                //graphics.DrawString("Factura: " + _FacturaId + "   ." + _TipoFactura, new Font("Merchant Copy Doublesize", 8),
                //        new SolidBrush(Color.Black), startX, startY + Offset);
                //Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Tipo Servicio      : Restaurante", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }


                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Caja       : " + Equipo.Id.ToString() + "  Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Salonero   : " + _CajeroNombre, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (this._ClienteNombre.Length > 0)
                {
                    graphics.DrawString("Cliente   : " + _ClienteNombre, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                graphics.DrawString("Cuenta     : Mesa " + _MesaId, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                string x = "-----------------------------------------";

                graphics.DrawString("CANT.", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString("DESCRIPCION.", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 35, startY + Offset);

                graphics.DrawString("TOTAL.", new Font("Merchant Copy Doublesize", 7),
                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal tempsubtotal = 0;

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    graphics.DrawString(temp[0].ToUpper(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    if (temp[1].Length > 16)
                    {
                        graphics.DrawString(temp[1].Substring(0, 15).ToUpper(), new Font("Merchant Copy Doublesize", 7),
                                new SolidBrush(Color.Black), startX + 32, startY + Offset);
                    }
                    else
                    {
                        graphics.DrawString(temp[1].ToUpper(), new Font("Merchant Copy Doublesize", 7),
                                new SolidBrush(Color.Black), startX + 32, startY + Offset);
                    }

                    decimal val = Convert.ToDecimal((temp[2]));
                    // decimal tempval = Convert.ToDecimal(val / (Convert.ToDecimal(bus.First().IVA)));
                    decimal tempval = val;
                    tempsubtotal += tempval;
                    temp[2] = tempval.ToString("F");

                    switch (val.ToString().Length)
                    {
                        case 5:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 245, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 240, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 235, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 230, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 225, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }

                    Offset = Offset + 16;
                }

                graphics.DrawString(x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal porIVA = 0;
                decimal porImpServicio = 0;
                decimal subtotal = 0;

                porImpServicio = Convert.ToDecimal((bus.First().ImpuestoServicio) / 100);
                porIVA = Convert.ToDecimal((bus.First().IVA) / 100);

                //decimal impventas = (_TotalFactura * porIVA);
                //decimal impserv = (_TotalFactura * porImpServicio);

                decimal impventas = (tempsubtotal * porIVA);
                decimal impserv = (tempsubtotal * porImpServicio);

                if (_Desc_Aplicado > 0)
                {
                    //subtotal = _TotalFactura - impventas - impserv - _Desc_Aplicado;
                    //subtotal = _TotalFactura - impventas - impserv;

                    tempsubtotal -= _Desc_Aplicado;
                }
                else
                {
                    //subtotal = _TotalFactura - impventas - impserv;

                }
                string underline = "---------";

                graphics.DrawString("SUBTOTAL : ", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 130, startY + Offset);

                string temp1 = Convert.ToDecimal(Subtotal).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }

                Offset = Offset + 17;

                if (_Desc_Aplicado > 0)
                {
                    graphics.DrawString("DESCUENTO : ", new Font("Merchant Copy Doublesize", 8),
                            new SolidBrush(Color.Black), startX + 122, startY + Offset);

                    temp1 = Convert.ToDecimal(_Desc_Aplicado).ToString("F");
                    switch (temp1.Length)
                    {
                        case 4:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 260, startY + Offset);
                                break;
                            }
                        case 5:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                         new SolidBrush(Color.Black), startX + 250, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 245, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 240, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 235, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 230, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }
                    Offset = Offset + 17;
                }

                graphics.DrawString("IMP.VTAS : ", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 130, startY + Offset);

                temp1 = Convert.ToDecimal(Impuesto).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 17;
                //if (_MesaId < 17)
                //{
                graphics.DrawString("IMP.SERV : ", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 130, startY + Offset);

                temp1 = Convert.ToDecimal(ImpServicio).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                //}
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L : ", new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX + 122, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L  $ : ", new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX + 98, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura / Convert.ToDecimal(bus.First().TipoCambio)).ToString("F");
                switch (temp1.Length)
                {
                    case 4:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 260, startY + Offset);
                            break;
                        }
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Recibido  : " + Convert.ToDecimal(_Recibido).ToString("F"), new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Su cambio : " + _Cambio, new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Propina : " + _Propina.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_PiePagina.Length > 0)
                {
                    graphics.DrawString(_PiePagina, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina2.Length > 0)
                {
                    graphics.DrawString(_PiePagina2, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina3.Length > 0)
                {
                    graphics.DrawString(_PiePagina3, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina4.Length > 0)
                {
                    graphics.DrawString(_PiePagina4, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
                if (_FinalPagina.Length > 0)
                {
                    graphics.DrawString(_FinalPagina, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                Offset = 0;
            }





            #endregion


            if (Impresora == "TM-U220")
            {
                //startY = -450;

                Offset = 0;

                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 8),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 90, startY + Offset);
                Offset = Offset + 17;


                if (_TipoDocumento.Length > 0)
                {
                    graphics.DrawString("Número de Factura: " + _Clave + "   " + _TipoFactura, new Font("Merchant Copy Doublesize", 7),
                             new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                else
                {
                    graphics.DrawString("Factura : " + _FacturaId, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 80, startY + Offset);
                    Offset = Offset + 17;
                }


                //graphics.DrawString("Factura: " + _FacturaId + "   ." + _TipoFactura, new Font("Merchant Copy Doublesize", 8),
                //        new SolidBrush(Color.Black), startX, startY + Offset);
                //Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Tipo Servicio      : Restaurante", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                if (_TipoDocumento.Length > 0)
                {
                    graphics.DrawString(_TipoDocumento, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;

                    // Es una factura electronica o un tiquete por lo tanto 
                }

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;


                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Caja        : " + Equipo.Id.ToString() + "  Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Salonero  : " + _CajeroNombre, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                if (this._ClienteNombre.Length > 0)
                {
                    graphics.DrawString("Cliente   : " + _ClienteNombre, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                graphics.DrawString("Cuenta      : Mesa " + _MesaId, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                string x = "-----------------------------------------";

                graphics.DrawString("CANT.", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString("DESCRIPCION.", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 40, startY + Offset);

                graphics.DrawString("TOTAL.", new Font("Merchant Copy Doublesize", 9),
                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal tempsubtotal = 0;

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    graphics.DrawString(temp[0].ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    if (temp[1].Length > 16)
                    {
                        graphics.DrawString(temp[1].Substring(0, 15).ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 40, startY + Offset);
                    }
                    else
                    {
                        graphics.DrawString(temp[1].ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 40, startY + Offset);
                    }

                    decimal val = Convert.ToDecimal((temp[2]));
                    string xy = "1." + Convert.ToDecimal(bus.First().IVA).ToString("#");
                    //   decimal tempval = Convert.ToDecimal(val / Convert.ToDecimal(xy));
                    decimal tempval = val;
                    tempsubtotal += tempval;
                    tempsubtotal = Math.Round(tempsubtotal, 2);
                    temp[2] = tempval.ToString("F");

                    switch (val.ToString().Length)
                    {
                        case 5:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }


                    Offset = Offset + 17;
                }

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal porIVA = 0;
                decimal porImpServicio = 0;
                decimal subtotal = 0;

                porImpServicio = Convert.ToDecimal((bus.First().ImpuestoServicio) / 100);
                porIVA = Convert.ToDecimal((bus.First().IVA) / 100);

                //  decimal impventas = (_TotalFactura * porIVA);
                //decimal impserv = (_TotalFactura * porImpServicio);

                // decimal impventas = (tempsubtotal * porIVA);
                decimal impventas = (((Convert.ToDecimal(tempsubtotal))) / 1.13m) * porIVA;
                impventas = Math.Round(impventas, 2);
                //decimal impserv = (tempsubtotal * porImpServicio);   
                decimal impserv = (Subtotal * 10) / 100;
                impserv = Math.Round(impserv, 2);



                if (_Desc_Aplicado > 0)
                {
                    //subtotal = _TotalFactura - impventas - impserv - _Desc_Aplicado;
                    //subtotal = _TotalFactura - impventas - impserv;

                    tempsubtotal -= _Desc_Aplicado;
                }
                else
                {
                    //subtotal = _TotalFactura - impventas - impserv;

                }
                string underline = "---------";

                graphics.DrawString("SUBTOTAL : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);

                string temp1 = Convert.ToDecimal(Subtotal).ToString("F");
                //    string temp1 = (Convert.ToDecimal(tempsubtotal)/ 1.13m).ToString("F");

                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }

                Offset = Offset + 17;

                if (_Desc_Aplicado > 0)
                {
                    graphics.DrawString("DESCUENTO : ", new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 100, startY + Offset);

                    temp1 = Convert.ToDecimal(_Desc_Aplicado).ToString("F");
                    switch (temp1.Length)
                    {
                        case 4:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 205, startY + Offset);
                                break;
                            }
                        case 5:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 195, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 185, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 180, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 175, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }
                    Offset = Offset + 17;
                }

                graphics.DrawString("IMP.VTAS : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);

                // temp1 = Convert.ToDecimal(Impuesto).ToString("F");
                temp1 = Convert.ToDecimal(impventas).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 17;

                graphics.DrawString("IMP.SERV : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);

                // temp1 = Convert.ToDecimal(ImpServicio).ToString("F");
                temp1 = Convert.ToDecimal(impserv).ToString("F");

                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }

                Offset = Offset + 10;
                _TotalFactura = (_Subtotal + impventas + impserv);
                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L : ", new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L  $ : ", new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura / Convert.ToDecimal(bus.First().TipoCambio)).ToString("F");
                switch (temp1.Length)
                {
                    case 4:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 205, startY + Offset);
                            break;
                        }
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Recibido  : " + Convert.ToDecimal(_Recibido).ToString("F"), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Su cambio : " + _Cambio, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Propina : " + _Propina.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_PiePagina.Length > 0)
                {
                    graphics.DrawString(_PiePagina, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina2.Length > 0)
                {
                    graphics.DrawString(_PiePagina2, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina3.Length > 0)
                {
                    graphics.DrawString(_PiePagina3, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina4.Length > 0)
                {
                    graphics.DrawString(_PiePagina4, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                if (_FinalPagina.Length > 0)
                {
                    graphics.DrawString(_FinalPagina, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
            }
        }

        public void Factura(object sender, PrintPageEventArgs e)
        {
            string Impresora = string.Empty;

            Graphics graphics = e.Graphics;
            Font font = new Font("Merchant Copy Doublesize", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;

            int startY = 0;

            this.OpenConn();

            var bus = from x in db.InformacionGeneral
                      select x;

            if (bus.Count() > 0)
            {
                Impresora = bus.First().Impresora.ToString();
            }

            if (Impresora == "TM-T20II")
            {
                startY = 0;
                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 105, startY + Offset);
                Offset = Offset + 16;

                if (_TipoDocumento.Length > 0)
                {
                    graphics.DrawString("Número de Factura: " + _Clave + "   " + _TipoFactura, new Font("Merchant Copy Doublesize", 7),
                             new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                else
                {
                    graphics.DrawString("Factura : " + _FacturaId, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 80, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("Factura : " + _FacturaId, new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 92, startY + Offset);
                Offset = Offset + 17;

                //graphics.DrawString("Factura: " + _FacturaId + "   ." + _TipoFactura, new Font("Merchant Copy Doublesize", 8),
                //        new SolidBrush(Color.Black), startX, startY + Offset);
                //Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Tipo Servicio      : Restaurante", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_TipoDocumento.Length > 0)
                {
                    graphics.DrawString(_TipoDocumento, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;

                    // Es una factura electronica o un tiquete por lo tanto 
                }

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }


                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Caja       : " + Equipo.Id.ToString() + "  Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Salonero   : " + _CajeroNombre, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (this._ClienteNombre.Length > 0)
                {
                    graphics.DrawString("Cliente   : " + _ClienteNombre, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                graphics.DrawString("Cuenta     : Mesa " + _MesaId, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                string x = "-----------------------------------------";

                graphics.DrawString("CANT.", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString("DESCRIPCION.", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 35, startY + Offset);

                graphics.DrawString("TOTAL.", new Font("Merchant Copy Doublesize", 7),
                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal tempsubtotal = 0;

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    graphics.DrawString(temp[0].ToUpper(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    if (temp[1].Length > 16)
                    {
                        graphics.DrawString(temp[1].Substring(0, 15).ToUpper(), new Font("Merchant Copy Doublesize", 7),
                                new SolidBrush(Color.Black), startX + 32, startY + Offset);
                    }
                    else
                    {
                        graphics.DrawString(temp[1].ToUpper(), new Font("Merchant Copy Doublesize", 7),
                                new SolidBrush(Color.Black), startX + 32, startY + Offset);
                    }

                    decimal val = Convert.ToDecimal((temp[2]));
                    decimal tempval = Convert.ToDecimal(val / (Convert.ToDecimal(bus.First().IVA)));

                    tempsubtotal += tempval;
                    temp[2] = tempval.ToString("F");

                    switch (val.ToString().Length)
                    {
                        case 5:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 250, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 245, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 240, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 235, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 230, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                                       new SolidBrush(Color.Black), startX + 225, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }

                    Offset = Offset + 16;
                }

                graphics.DrawString(x, new Font("Merchant Copy Doublesize", 7),   //------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal porIVA = 0;
                decimal subtotal = 0;

                porIVA = Convert.ToDecimal((bus.First().IVA) / 100);

                //decimal impventas = (_TotalFactura * porIVA);
                //decimal impserv = (_TotalFactura * porImpServicio);

                decimal impventas = (tempsubtotal * porIVA);

                if (_Desc_Aplicado > 0)
                {
                    //subtotal = _TotalFactura - impventas - impserv - _Desc_Aplicado;
                    //subtotal = _TotalFactura - impventas - impserv;

                    tempsubtotal -= _Desc_Aplicado;
                }
                else
                {
                    //subtotal = _TotalFactura - impventas - impserv;

                }
                string underline = "---------";

                graphics.DrawString("SUBTOTAL : ", new Font("Merchant Copy Doublesize", 8),
                new SolidBrush(Color.Black), startX + 130, startY + Offset);

                string temp1 = Convert.ToDecimal(Subtotal).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }

                Offset = Offset + 17;

                if (_Desc_Aplicado > 0)
                {
                    graphics.DrawString("DESCUENTO : ", new Font("Merchant Copy Doublesize", 8),
                            new SolidBrush(Color.Black), startX + 122, startY + Offset);

                    temp1 = Convert.ToDecimal(_Desc_Aplicado).ToString("F");
                    switch (temp1.Length)
                    {
                        case 4:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 260, startY + Offset);
                                break;
                            }
                        case 5:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                         new SolidBrush(Color.Black), startX + 250, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 245, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 240, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 235, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 230, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }
                    Offset = Offset + 17;
                }

                graphics.DrawString("IMP.VTAS : ", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 130, startY + Offset);

                temp1 = Convert.ToDecimal(Impuesto).ToString("F");

                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 17;
                //if (_MesaId < 17)
                //{
                graphics.DrawString("IMP.SERV : ", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 130, startY + Offset);

                temp1 = Convert.ToDecimal(ImpServicio).ToString("F");

                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                //}
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L : ", new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX + 122, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L  $ : ", new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX + 98, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura / Convert.ToDecimal(bus.First().TipoCambio)).ToString("F");
                switch (temp1.Length)
                {
                    case 4:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 260, startY + Offset);
                            break;
                        }
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 250, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 240, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 235, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 230, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 7),
                                    new SolidBrush(Color.Black), startX + 225, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 225, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Recibido  : " + Convert.ToDecimal(_Recibido).ToString("F"), new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Su cambio : " + _Cambio, new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Propina : " + _Propina.ToString("F"), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_PiePagina.Length > 0)
                {
                    graphics.DrawString(_PiePagina, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina2.Length > 0)
                {
                    graphics.DrawString(_PiePagina2, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina3.Length > 0)
                {
                    graphics.DrawString(_PiePagina3, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina4.Length > 0)
                {
                    graphics.DrawString(_PiePagina4, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
                if (_FinalPagina.Length > 0)
                {
                    graphics.DrawString(_FinalPagina, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                Offset = 0;
            }





            if (Impresora == "TM-U220")
            {
                //startY = -450;

                Offset = 0;

                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 8),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 90, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Factura : " + _FacturaId, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 80, startY + Offset);
                Offset = Offset + 17;

                //graphics.DrawString("Factura: " + _FacturaId + "   ." + _TipoFactura, new Font("Merchant Copy Doublesize", 8),
                //        new SolidBrush(Color.Black), startX, startY + Offset);
                //Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Tipo Servicio      : Restaurante", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;


                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Caja        : " + Equipo.Id.ToString() + "  Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Salonero  : " + _CajeroNombre, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                if (this._ClienteNombre.Length > 0)
                {
                    graphics.DrawString("Cliente   : " + _ClienteNombre, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                graphics.DrawString("Cuenta      : Mesa " + _MesaId, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                string x = "-----------------------------------------";

                graphics.DrawString("CANT.", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString("DESCRIPCION.", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 40, startY + Offset);

                graphics.DrawString("TOTAL.", new Font("Merchant Copy Doublesize", 9),
                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal tempsubtotal = 0;

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    graphics.DrawString(temp[0].ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    if (temp[1].Length > 16)
                    {
                        graphics.DrawString(temp[1].Substring(0, 15).ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 40, startY + Offset);
                    }
                    else
                    {
                        graphics.DrawString(temp[1].ToUpper(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 40, startY + Offset);
                    }

                    decimal val = Convert.ToDecimal((temp[2]));
                    string xy = "1." + Convert.ToDecimal(bus.First().IVA).ToString("#");
                    decimal tempval = Convert.ToDecimal(val / Convert.ToDecimal(xy));

                    tempsubtotal += tempval;
                    temp[2] = tempval.ToString("F");

                    switch (val.ToString().Length)
                    {
                        case 5:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(tempval.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                                       new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }


                    Offset = Offset + 17;
                }

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal porIVA = 0;
                decimal porImpServicio = 0;
                decimal subtotal = 0;

                porImpServicio = Convert.ToDecimal((bus.First().ImpuestoServicio) / 100);
                porIVA = Convert.ToDecimal((bus.First().IVA) / 100);

                //decimal impventas = (_TotalFactura * porIVA);
                //decimal impserv = (_TotalFactura * porImpServicio);

                decimal impventas = (tempsubtotal * porIVA);
                decimal impserv = (tempsubtotal * porImpServicio);

                if (_Desc_Aplicado > 0)
                {
                    //subtotal = _TotalFactura - impventas - impserv - _Desc_Aplicado;
                    //subtotal = _TotalFactura - impventas - impserv;

                    tempsubtotal -= _Desc_Aplicado;
                }
                else
                {
                    //subtotal = _TotalFactura - impventas - impserv;

                }
                string underline = "---------";

                graphics.DrawString("SUBTOTAL : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);

                string temp1 = Convert.ToDecimal(Subtotal).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }

                Offset = Offset + 17;

                if (_Desc_Aplicado > 0)
                {
                    graphics.DrawString("DESCUENTO : ", new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX + 100, startY + Offset);

                    temp1 = Convert.ToDecimal(_Desc_Aplicado).ToString("F");
                    switch (temp1.Length)
                    {
                        case 4:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 205, startY + Offset);
                                break;
                            }
                        case 5:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 200, startY + Offset);
                                break;
                            }
                        case 6:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 195, startY + Offset);
                                break;
                            }
                        case 7:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                                break;
                            }
                        case 8:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 185, startY + Offset);
                                break;
                            }
                        case 9:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 180, startY + Offset);
                                break;
                            }
                        case 10:
                            {
                                graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                        new SolidBrush(Color.Black), startX + 175, startY + Offset);
                                break;
                            }
                        default:
                            break;
                    }
                    Offset = Offset + 17;
                }

                graphics.DrawString("IMP.VTAS : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(Impuesto).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 17;
                //if (_MesaId < 17)
                //{
                graphics.DrawString("IMP.SERV : ", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(ImpServicio).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                //}
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L : ", new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura).ToString("F");
                switch (temp1.Length)
                {
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("T O T A L  $ : ", new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX + 100, startY + Offset);

                temp1 = Convert.ToDecimal(_TotalFactura / Convert.ToDecimal(bus.First().TipoCambio)).ToString("F");
                switch (temp1.Length)
                {
                    case 4:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 205, startY + Offset);
                            break;
                        }
                    case 5:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 200, startY + Offset);
                            break;
                        }
                    case 6:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 195, startY + Offset);
                            break;
                        }
                    case 7:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 190, startY + Offset);
                            break;
                        }
                    case 8:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 185, startY + Offset);
                            break;
                        }
                    case 9:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 180, startY + Offset);
                            break;
                        }
                    case 10:
                        {
                            graphics.DrawString(temp1, new Font("Merchant Copy Doublesize", 9),
                                    new SolidBrush(Color.Black), startX + 175, startY + Offset);
                            break;
                        }
                    default:
                        break;
                }
                Offset = Offset + 10;

                graphics.DrawString(underline + underline, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX + 190, startY + Offset);
                Offset = Offset + 10;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Recibido  : " + Convert.ToDecimal(_Recibido).ToString("F"), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Su cambio : " + _Cambio, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Propina : " + _Propina.ToString("F"), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_PiePagina.Length > 0)
                {
                    graphics.DrawString(_PiePagina, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina2.Length > 0)
                {
                    graphics.DrawString(_PiePagina2, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina3.Length > 0)
                {
                    graphics.DrawString(_PiePagina3, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                if (_PiePagina4.Length > 0)
                {
                    graphics.DrawString(_PiePagina4, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                if (_FinalPagina.Length > 0)
                {
                    graphics.DrawString(_FinalPagina, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
            }
        }

        public void ComandaCocina(object sender, PrintPageEventArgs e)
        {
            string Impresora = string.Empty;

            Graphics graphics = e.Graphics;
            Font font = new Font("Merchant Copy Doublesize", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;
            //int startY = -400;
            int startY = 0;
            Offset = startY;

            this.OpenConn();

            var bus = (from x in db.Equipos
                       where x.NombreEquipo == System.Environment.MachineName.ToString()
                       select x).First();

            graphics.DrawString("ORDEN NUEVA", new Font("Merchant Copy Doublesize", 12),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 21;

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 12),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            //graphics.DrawString("# ORDEN: " + _OrdenId.ToString(), new Font("Merchant Copy Doublesize", 10),
            //        new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + 18;

            //graphics.DrawString("CAJA: " + bus.Id.ToString(), new Font("Merchant Copy Doublesize", 10),
            //        new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + 18;

            graphics.DrawString("CUENTA: MESA " + _MesaId.ToString(), new Font("Merchant Copy Doublesize", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 18;

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 12),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Usuario: " + _RolDescripcion.ToString() + "  Fecha: " + System.DateTime.Now.ToShortDateString(), new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 17;

            graphics.DrawString("Salonero: " + _Salonero, new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 17;

            graphics.DrawString("Comanda: Cocina" + "     Hora: " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 17;

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 12),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Descripción", new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX, startY + Offset);

            graphics.DrawString("Cant.", new Font("Merchant Copy Doublesize", 9),//-35
                    new SolidBrush(Color.Black), startX + 210, startY + Offset);

            graphics.DrawString("Serv.", new Font("Merchant Copy Doublesize", 9),//-35
                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
            Offset = Offset + 17;

            string linea = "---------------------------------------";

            graphics.DrawString(linea + linea, new Font("Merchant Copy Doublesize", 7),//------------------
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;


            foreach (string item in ListaComanda)
            {
                string[] temp = item.Split('|');

                this.objComandaCocina.TemporalConsumoId = Convert.ToInt32(temp[0].ToString());//0-->id

                this.objComandaCocina.DesactivaOrden();
            }

            foreach (string item in ListaComandaImprimir)
            {
                // 0                       1                           2                           3                   4
                // item.Nombre +  "|" + item.Cantidad.ToString() + "|" + item.Mesa_Silla + "|" + item.Detalle + "|" + item.Observaciones);
                string[] temp = item.Split('|');

                if (temp[3].Split(';').Count() == 1)
                {
                    temp[3] = temp[3] + ";;;";
                }
                if (temp[3].Split(';').Count() == 2)
                {
                    temp[3] = temp[3] + ";;";
                }
                if (temp[3].Split(';').Count() == 3)
                {
                    temp[3] = temp[3] + ";";
                }

                LineaImpresion = temp[0] + ";" + temp[3];

                string[] LineaImpresiontemp = this._LineaImpresion.Split(';');

                //nombre
                graphics.DrawString(temp[0].ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString(temp[1].ToUpper().ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 220, startY + Offset);//cantidad

                graphics.DrawString("R", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 250, startY + Offset);

                Offset = Offset + 17;

                //observaciones
                string ggg = temp[4];

                if (ggg.Length != 0)
                {
                    graphics.DrawString(temp[4].ToUpper().ToString(), new Font("Merchant Copy Doublesize", 9),
                         new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }



                //termino
                if (LineaImpresiontemp[1] != "")
                {
                    graphics.DrawString(LineaImpresiontemp[1].ToUpper().ToString(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);//1pruebaroojo
                    Offset = Offset + 17;
                }


                //guarnicion1
                if (LineaImpresiontemp[2] != "")
                {
                    graphics.DrawString(LineaImpresiontemp[2].ToUpper().ToString(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                //guarnicion2
                if (LineaImpresiontemp[3] != "")
                {
                    graphics.DrawString(LineaImpresiontemp[3].ToUpper().ToString(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;
            }

            this.CloseConn();

            string GS = Convert.ToString((char)29);
            string ESC = Convert.ToString((char)27);

            string COMMAND = "";
            COMMAND = ESC + "@";
            COMMAND += GS + "V" + (char)1;

            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();

            //RawPrinterHelper.SendStringToPrinter("impresoracomandacocina", COMMAND);            

            RawPrinterHelper.SendStringToPrinter("impresoracomandacocina", COMMAND);


        }

        public void ComandaBar(object sender, PrintPageEventArgs e)
        {
            string Impresora = string.Empty;

            Graphics graphics = e.Graphics;
            Font font = new Font("Merchant Copy Doublesize", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;
            //int startY = -400;
            int startY = 0;
            Offset = startY;

            this.OpenConn();

            var bus = (from x in db.Equipos
                       where x.NombreEquipo == System.Environment.MachineName.ToString()
                       select x).First();

            graphics.DrawString("ORDEN NUEVA", new Font("Merchant Copy Doublesize", 12),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 21;

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 12),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            //graphics.DrawString("# ORDEN: " + _OrdenId.ToString(), new Font("Merchant Copy Doublesize", 10),
            //        new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + 18;

            //graphics.DrawString("CAJA: " + bus.Id.ToString(), new Font("Merchant Copy Doublesize", 10),
            //        new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + 18;

            graphics.DrawString("CUENTA: MESA " + _MesaId.ToString(), new Font("Merchant Copy Doublesize", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 18;

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 12),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Usuario: " + _RolDescripcion.ToString() + "  Fecha: " + System.DateTime.Now.ToShortDateString(), new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 17;

            graphics.DrawString("Salonero: " + _Salonero, new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 17;

            graphics.DrawString("Comanda: Bar" + "     Hora: " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 17;

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 12),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Descripción", new Font("Merchant Copy Doublesize", 9),
                    new SolidBrush(Color.Black), startX, startY + Offset);

            graphics.DrawString("Cant.", new Font("Merchant Copy Doublesize", 9),//-35
                    new SolidBrush(Color.Black), startX + 210, startY + Offset);

            graphics.DrawString("Serv.", new Font("Merchant Copy Doublesize", 9),//-35
                    new SolidBrush(Color.Black), startX + 245, startY + Offset);
            Offset = Offset + 17;

            string linea = "---------------------------------------";

            graphics.DrawString(linea + linea, new Font("Merchant Copy Doublesize", 7),//------------------
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;


            foreach (string item in ListaComandaBar)
            {
                string[] temp = item.Split('|');

                this.objComandaBar.TemporalConsumoId = Convert.ToInt32(temp[0].ToString());//0-->id

                this.objComandaBar.DesactivaOrden();
            }

            foreach (string item in ListaComandaBarImprimir)
            {
                // 0                       1                           2                           3                   4
                // item.Nombre +  "|" + item.Cantidad.ToString() + "|" + item.Mesa_Silla + "|" + item.Detalle + "|" + item.Observaciones);
                string[] temp = item.Split('|');

                if (temp[3].Split(';').Count() == 1)
                {
                    temp[3] = temp[3] + ";;;";
                }
                if (temp[3].Split(';').Count() == 2)
                {
                    temp[3] = temp[3] + ";;";
                }
                if (temp[3].Split(';').Count() == 3)
                {
                    temp[3] = temp[3] + ";";
                }

                LineaImpresion = temp[0] + ";" + temp[3];

                string[] LineaImpresiontemp = this._LineaImpresion.Split(';');

                //nombre
                graphics.DrawString(temp[0].ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString(temp[1].ToUpper().ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 220, startY + Offset);//cantidad

                graphics.DrawString("R", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 250, startY + Offset);

                Offset = Offset + 17;

                //observaciones
                string ggg = temp[4];

                if (ggg.Length != 0)
                {
                    graphics.DrawString(temp[4].ToUpper().ToString(), new Font("Merchant Copy Doublesize", 9),
                         new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }


                graphics.DrawString("", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;
            }

            this.CloseConn();

            string GS = Convert.ToString((char)29);
            string ESC = Convert.ToString((char)27);

            string COMMAND = "";
            COMMAND = ESC + "@";
            COMMAND += GS + "V" + (char)1;

            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();

            // RawPrinterHelper.SendStringToPrinter("impresoracomandabar", COMMAND);
            RawPrinterHelper.SendStringToPrinter("impresoracomandacocina", COMMAND);

        }

        public void MarcasEmpleado(object sender, PrintPageEventArgs e)
        {
            string Impresora = string.Empty;

            Graphics graphics = e.Graphics;
            Font font = new Font("Merchant Copy Doublesize", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;

            int startY = 0;

            this.OpenConn();

            var bus = from x in db.InformacionGeneral
                      select x;

            if (bus.Count() > 0)
            {
                Impresora = bus.First().Impresora.ToString();
            }
            #region IMPRESORA TM-T20II
            if (Impresora == "TM-T20II")
            {
                startY = 0;
                string x = "-----------------------------------------";
                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 105, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("ENTRADA Y SALIDA DEL PERSONAL", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 50, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }

                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Caja       : " + Equipo.Id.ToString() + "  Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("FECHA", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                /* graphics.DrawString("USUARIO", new Font("Merchant Copy Doublesize",8),
                         new SolidBrush(Color.Black), startX + 50, startY + Offset);*/

                graphics.DrawString("EMPLEADO", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 52, startY + Offset);

                graphics.DrawString("ENTRADA", new Font("Merchant Copy Doublesize", 8),
                       new SolidBrush(Color.Black), startX + 119, startY + Offset);

                graphics.DrawString("SALIDA", new Font("Merchant Copy Doublesize", 8),
                       new SolidBrush(Color.Black), startX + 176, startY + Offset);

                graphics.DrawString("TOTAL", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 222, startY + Offset);

                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);

                Offset = Offset + 16;
                foreach (string item in Marcas)
                {
                    string[] temp = item.Split(';');

                    //Fecha
                    graphics.DrawString(temp[0].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    //Login Usuario:
                    /*    graphics.DrawString(temp[1].Substring(0, temp[1].Length > 8 ? 8 : temp[1].Length).ToUpper(), new Font("Merchant Copy Doublesize", 7),
                                new SolidBrush(Color.Black), startX + 50, startY + Offset);*/

                    //Nombre Empleado:
                    graphics.DrawString(temp[2].Substring(0, temp[2].Length > 10 ? 10 : temp[2].Length).ToUpper(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 52, startY + Offset);

                    //Hora de Entrada:
                    graphics.DrawString(temp[3].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 121, startY + Offset);

                    //Hora de Salida:
                    graphics.DrawString(temp[4].ToString(), new Font("Merchant Copy Doublesize", 7),
                             new SolidBrush(Color.Black), startX + 176, startY + Offset);

                    //Total de Horas:
                    graphics.DrawString(temp[5].ToString(), new Font("Merchant Copy Doublesize", 7),
                             new SolidBrush(Color.Black), startX + 222, startY + Offset);

                    Offset = Offset + 17;
                    graphics.DrawString("***", new Font("Merchant Copy Doublesize", 7),//------------------
                               new SolidBrush(Color.Black), startX + 120, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("***ÚLTIMA LÍNEA***", new Font("Merchant Copy Doublesize", 8),//------------------
                        new SolidBrush(Color.Black), startX + 90, startY + Offset);


                Offset = Offset + 17;
            }

            #endregion

            #region IMPRESORA TM-U220
            if (Impresora == "TM-U220")
            {
                //startY = -450;

                Offset = 0;

                string x = "-----------------------------------------";

                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 8),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("ENTRADA Y SALIDA DEL PERSONAL", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 50, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Caja        : " + Equipo.Id.ToString() + "  Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("FECHA", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                /* graphics.DrawString("USUARIO", new Font("Merchant Copy Doublesize",8),
                         new SolidBrush(Color.Black), startX + 50, startY + Offset);*/

                graphics.DrawString("EMPLEADO", new Font("Merchant Copy Doublesize", 8),
                       new SolidBrush(Color.Black), startX + 52, startY + Offset);

                graphics.DrawString("ENTRADA", new Font("Merchant Copy Doublesize", 8),
                       new SolidBrush(Color.Black), startX + 119, startY + Offset);

                graphics.DrawString("SALIDA", new Font("Merchant Copy Doublesize", 8),
                       new SolidBrush(Color.Black), startX + 176, startY + Offset);

                graphics.DrawString("TOTAL", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 222, startY + Offset);

                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);

                Offset = Offset + 16;


                foreach (string item in Marcas)
                {
                    string[] temp = item.Split(';');

                    //Fecha
                    graphics.DrawString(temp[0].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    //Login Usuario:
                    /*    graphics.DrawString(temp[1].Substring(0, temp[1].Length > 8 ? 8 : temp[1].Length).ToUpper(), new Font("Merchant Copy Doublesize", 7),
                                new SolidBrush(Color.Black), startX + 50, startY + Offset);*/

                    //Nombre Empleado:
                    graphics.DrawString(temp[2].Substring(0, temp[2].Length > 10 ? 10 : temp[2].Length).ToUpper(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 52, startY + Offset);

                    //Hora de Entrada:
                    graphics.DrawString(temp[3].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 121, startY + Offset);

                    //Hora de Salida:
                    graphics.DrawString(temp[4].ToString(), new Font("Merchant Copy Doublesize", 7),
                             new SolidBrush(Color.Black), startX + 176, startY + Offset);

                    //Total de Horas:
                    graphics.DrawString(temp[5].ToString(), new Font("Merchant Copy Doublesize", 7),
                             new SolidBrush(Color.Black), startX + 222, startY + Offset);

                    Offset = Offset + 17;
                    graphics.DrawString("***", new Font("Merchant Copy Doublesize", 7),//------------------
                               new SolidBrush(Color.Black), startX + 120, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("***ÚLTIMA LÍNEA***", new Font("Merchant Copy Doublesize", 8),//------------------
                        new SolidBrush(Color.Black), startX + 90, startY + Offset);


                Offset = Offset + 17;

            }
            #endregion
        }

        public void FacturasReporte(object sender, PrintPageEventArgs e)
        {
            string Impresora = string.Empty;

            Graphics graphics = e.Graphics;
            Font font = new Font("Merchant Copy Doublesize", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;

            int startY = 0;

            this.OpenConn();

            var bus = from x in db.InformacionGeneral
                      select x;

            if (bus.Count() > 0)
            {
                Impresora = bus.First().Impresora.ToString();
            }

            #region IMPRESORA TM-T20II
            if (Impresora == "TM-T20II")
            {
                startY = 0;
                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 25, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX + 105, startY + Offset);
                Offset = Offset + 16;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 16;
                }


                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                string x = "-----------------------------------------";

                graphics.DrawString("COMPR.", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString("CLIENTE", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 48, startY + Offset);

                graphics.DrawString("FECHA", new Font("Merchant Copy Doublesize", 8),
                       new SolidBrush(Color.Black), startX + 121, startY + Offset);

                graphics.DrawString("HORA", new Font("Merchant Copy Doublesize", 8),
                       new SolidBrush(Color.Black), startX + 176, startY + Offset);

                graphics.DrawString("DESC.", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 223, startY + Offset);

                graphics.DrawString("TOTAL", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 254, startY + Offset);

                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal tempsubtotal = 0;

                foreach (string item in Facturas)
                {
                    string[] temp = item.Split(';');

                    //Comprobante
                    graphics.DrawString(temp[0].ToUpper(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    //Cliente
                    graphics.DrawString(temp[1].Substring(0, temp[1].Length > 12 ? 12 : temp[1].Length).ToUpper(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 48, startY + Offset);

                    //Fecha
                    graphics.DrawString(temp[2].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 121, startY + Offset);

                    //Hora:
                    graphics.DrawString(temp[3].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 176, startY + Offset);

                    //Descuento:
                    graphics.DrawString(temp[4].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 223, startY + Offset);

                    //Total:
                    graphics.DrawString(temp[5].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 255, startY + Offset);


                    Offset = Offset + 17;
                }

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;


                string temp1 = Convert.ToDecimal(tempsubtotal).ToString("F");


                Offset = Offset + 17;
            }

            #endregion

            #region IMPRESORA TM-U220
            if (Impresora == "TM-U220")
            {

                Offset = 0;

                graphics.DrawString(_Nombre.ToUpper(), new Font("Merchant Copy Doublesize", 12),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 18;

                graphics.DrawString(bus.First().Web.ToLower(), new Font("Merchant Copy Doublesize", 8),
                                        new SolidBrush(Color.Black), startX + 20, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString(_Cedula, new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX + 90, startY + Offset);
                Offset = Offset + 17;

                graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                if (_Fecha != Convert.ToDateTime("01/01/001"))
                {
                    graphics.DrawString("Fecha      : " + _Fecha.ToShortDateString() + " " + _Hora, new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }
                else
                {
                    graphics.DrawString("Fecha      : " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 9),
                            new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 17;
                }

                graphics.DrawString("Teléfono : " + bus.First().Telefono.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;


                this.OpenConn();

                var Equipo = (from et in db.Equipos
                              where et.NombreEquipo == System.Environment.MachineName.ToString()
                              select new { et.Id }).First();

                var Rol = (from u in db.Usuarios
                           join rl in db.Roles on u.RolId equals rl.Id
                           where u.Id == _UserId
                           select new { rl.Descripcion }).First();

                graphics.DrawString("Cajero  : " + Rol.Descripcion.ToString(), new Font("Merchant Copy Doublesize", 9),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 17;

                string x = "-----------------------------------------";

                graphics.DrawString("COMPR.", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                graphics.DrawString("CLIENTE", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 48, startY + Offset);

                graphics.DrawString("FECHA", new Font("Merchant Copy Doublesize", 8),
                       new SolidBrush(Color.Black), startX + 121, startY + Offset);

                graphics.DrawString("HORA", new Font("Merchant Copy Doublesize", 8),
                       new SolidBrush(Color.Black), startX + 176, startY + Offset);

                graphics.DrawString("DESC.", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 223, startY + Offset);

                graphics.DrawString("TOTAL", new Font("Merchant Copy Doublesize", 8),
                        new SolidBrush(Color.Black), startX + 255, startY + Offset);

                Offset = Offset + 17;

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;

                decimal tempsubtotal = 0;

                foreach (string item in Facturas)
                {
                    string[] temp = item.Split(';');

                    //Comprobante
                    graphics.DrawString(temp[0].ToUpper(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX, startY + Offset);

                    //Cliente
                    graphics.DrawString(temp[1].Substring(0, temp[1].Length > 12 ? 12 : temp[1].Length).ToUpper(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 48, startY + Offset);

                    //Fecha
                    graphics.DrawString(temp[2].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 121, startY + Offset);

                    //Hora:
                    graphics.DrawString(temp[3].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 176, startY + Offset);

                    //Descuento:
                    graphics.DrawString(temp[4].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 223, startY + Offset);

                    //Total:
                    graphics.DrawString(temp[5].ToString(), new Font("Merchant Copy Doublesize", 7),
                            new SolidBrush(Color.Black), startX + 255, startY + Offset);


                    Offset = Offset + 17;
                }

                graphics.DrawString(x + x, new Font("Merchant Copy Doublesize", 7),//------------------
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;


                string temp1 = Convert.ToDecimal(tempsubtotal).ToString("F");


                Offset = Offset + 17;
            }
            #endregion
        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {

            if (Accion == 1)
            {
                this.Prefactura(sender, e);
            }
            if (Accion == 2)
            {
                this.Factura(sender, e);
            }
            if (Accion == 3)
            {
                this.ComandaCocina(sender, e);
            }
            if (Accion == 4)
            {
                this.ComandaBar(sender, e);
            }
            if (Accion == 5)
            {
                this.MarcasEmpleado(sender, e);
            }
            if (Accion == 6)
            {
                this.FacturasReporte(sender, e);
            }
            if (Accion == 7)
            {
                this.Prefactura1(sender, e);
            }
            if (Accion == 8)
            {
                this.Factura1(sender, e);
            }
        }

        public void OpenConn()
        {
            if (db == null) db = new Restaurante_DAL.BaseDatosDataContext();
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
        #endregion

    }
}
