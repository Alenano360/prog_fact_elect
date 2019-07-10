using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace PuntoVentaBL
{
    public class Apartados
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        public string Impresora = string.Empty;

        #region propiedades

        private decimal _MontoTarjeta;

        public decimal MontoTarjeta
        {
            get { return _MontoTarjeta; }
            set { _MontoTarjeta = value; }
        }

        private decimal _MontoEfectivo;

        public decimal MontoEfectivo
        {
            get { return _MontoEfectivo; }
            set { _MontoEfectivo = value; }
        }
        
        

        private decimal _IVA;

        public decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }
        

        private string _Fax;

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }


        private string _Encabezado1;

        public string Encabezado1
        {
            get { return _Encabezado1; }
            set { _Encabezado1 = value; }
        }

        private string _Encabezado2;

        public string Encabezado2
        {
            get { return _Encabezado2; }
            set { _Encabezado2 = value; }
        }

        private string _Encabezado3;

        public string Encabezado3
        {
            get { return _Encabezado3; }
            set { _Encabezado3 = value; }
        }

        private string _Encabezado4;

        public string Encabezado4
        {
            get { return _Encabezado4; }
            set { _Encabezado4 = value; }
        }
        
        private decimal _CantidadLineas;

        public decimal CantidadLineas
        {
            get { return _CantidadLineas; }
            set { _CantidadLineas = value; }
        }

        private decimal _CantidadArticulos;

        public decimal CantidadArticulos
        {
            get { return _CantidadArticulos; }
            set { _CantidadArticulos = value; }
        }
        
        
        private Int64 _HistoricoId;

        public Int64 HistoricoId
        {
            get { return _HistoricoId; }
            set { _HistoricoId = value; }
        }
        
        private string _Cajero;

        public string Cajero
        {
            get { return _Cajero; }
            set { _Cajero = value; }
        }
        
        private string _SBusqueda;

        public string SBusqueda
        {
            get { return _SBusqueda; }
            set { _SBusqueda = value; }
        }
        private string _Orden;

        public string Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }
        
        public int DescCajaDiaria = 0;
        private decimal _Saldo;

        public decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
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

        private decimal _MontoAbono;

        public decimal MontoAbono
        {
            get { return _MontoAbono; }
            set { _MontoAbono = value; }
        }
        
        private string _Codigo;

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private decimal _Precio;

        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private int _Cantidad;

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private decimal _PrecioIVA;

        public decimal PrecioIVA
        {
            get { return _PrecioIVA; }
            set { _PrecioIVA = value; }
        }


        private decimal _Subtotal;

        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private decimal _PorcDesc;

        public decimal PorcDesc
        {
            get { return _PorcDesc; }
            set { _PorcDesc = value; }
        }

        private int _ClienteId;

        public int ClienteId
        {
            get { return _ClienteId; }
            set { _ClienteId = value; }
        }

        private int _TipoPrecio;

        public int TipoPrecio
        {
            get { return _TipoPrecio; }
            set { _TipoPrecio = value; }
        }

        private int _UnidadMedidaId;

        public int UnidadMedidaId
        {
            get { return _UnidadMedidaId; }
            set { _UnidadMedidaId = value; }
        }

        private int _IV;

        public int IV
        {
            get { return _IV; }
            set { _IV = value; }
        }

        private decimal _MontoIV;

        public decimal MontoIV
        {
            get { return _MontoIV; }
            set { _MontoIV = value; }
        }

        private decimal _Descuento;

        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        private decimal _TotalFactura;

        public decimal TotalFactura
        {
            get { return _TotalFactura; }
            set { _TotalFactura = value; }
        }

        private decimal _Impuesto;

        public decimal Impuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
        }

        private DateTime _FechaInicio;

        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        private DateTime _FechaFinal;

        public DateTime FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }
        

        private decimal _Desc_Aplicado;

        public decimal Desc_Aplicado
        {
            get { return _Desc_Aplicado; }
            set { _Desc_Aplicado = value; }
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
        private string _PiePagina5;

        public string PiePagina5
        {
            get { return _PiePagina5; }
            set { _PiePagina5 = value; }
        }

        private string _PiePagina6;
        public string PiePagina6
        {
            get { return _PiePagina6; }
            set { _PiePagina6 = value; }
        }
        private string _PiePagina7;
        public string PiePagina7
        {
            get { return _PiePagina7; }
            set { _PiePagina7 = value; }
        }
        private string _PiePagina8;
        public string PiePagina8
        {
            get { return _PiePagina8; }
            set { _PiePagina8 = value; }
        }

        private Int64 _AbonoId;

        public Int64 AbonoId
        {
            get { return _AbonoId; }
            set { _AbonoId = value; }
        }

        public List<string> Articulos = new List<string>();

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
                           where x.Id == 1
                           select x).First();

                _Nombre = bus.Nombre;
                _Dueno = bus.Dueno;
                _Cedula = bus.Cedula;
                _Telefono = bus.Telefono;
                _Fax = bus.Fax;
                _IVA = Convert.ToDecimal(bus.IVA);
                _Encabezado1 = bus.Encabezado1;
                _Encabezado2 = bus.Encabezado2;
                _Encabezado3 = bus.Encabezado3;
                _Encabezado4 = bus.Encabezado4;
                _PiePagina = bus.PiePagina1;
                _PiePagina2 = bus.PiePagina2;
                _PiePagina3 = bus.PiePagina3;
                _PiePagina4 = bus.PiePagina4;
                _PiePagina5 = bus.PiePagina5;
                _PiePagina6 = bus.PiePagina6;
                _PiePagina7 = bus.PiePagina7;
                _PiePagina8 = bus.PiePagina8;

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

        public bool MostrarApartado(DataGridView dgv,Int64 id)
        {
            try
            {
                this.OpenConn();

                var encabezado = (from pe in db.ApartadoEncabezados
                                  where pe.Id == id && pe.Activo == true
                                  select new
                                  {
                                      pe.Total,
                                      pe.Descuento,
                                      pe.ClienteId
                                  }).First();

                var detalles = from pe in db.ApartadoEncabezados
                               join pd in db.ApartadoDetalles on pe.Id equals pd.ApartadoId
                               join a in db.Articulo on pd.CodigoArticulo equals a.Codigo
                               where pe.Id == id && pe.Activo == true
                               select new { Codigo = (pd.CodigoArticulo), a.Descripcion, pd.Precio, pd.Cantidad, pd.PorcDescuento, pd.Descuento, TotalIVA = pd.TotalIVA };


                _ClienteId = Convert.ToInt32(encabezado.ClienteId);
                _TotalFactura = Convert.ToDecimal(encabezado.Total.ToString("F"));
                _Descuento = Convert.ToDecimal(Convert.ToDecimal(encabezado.Descuento).ToString("F"));

                _CantidadLineas = 0;
                _CantidadArticulos = 0;
                _MontoIV = 0;

                dgv.AutoGenerateColumns = false;

                foreach (var item in detalles)
                {
                    var ar = (from art in db.Articulo
                              where art.Codigo == item.Codigo && art.Activo == true
                              select new { art.MontoIV }).First();


                    _MontoIV += Convert.ToDecimal(ar.MontoIV) * item.Cantidad;

                    _CantidadArticulos += Convert.ToInt32(item.Cantidad);
                    _CantidadLineas++;

                    dgv.Rows.Insert(0, item.Codigo,
                       item.Descripcion.ToString(),
                        item.Precio.ToString(),
                        item.Cantidad.ToString(),
                        item.PorcDescuento,
                        item.Descuento,
                        item.TotalIVA.ToString(),
                        1
                        );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public void ObtieneApartados(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from pro in db.Apartados_Vws
                           orderby pro.Id descending
                           select pro);                          

                if (_SBusqueda != null)
                {
                    bus = from x in bus
                          where x.Id.ToString().Contains(_SBusqueda) || x.Cliente.Contains(_SBusqueda) || x.Total.ToString().Contains(_SBusqueda)
                          || x.Usuario.Contains(_SBusqueda)
                          orderby x.Id descending
                          select x;
                }

  

                if (_Orden != null)
                {
                    switch (_Orden)
                    {
                        case "Fecha":
                            {
                                bus = from x in bus
                                      orderby x.Fecha1 descending
                                      select x;
                                break;
                            }

                        case "Cliente":
                            {
                                bus = from x in bus
                                      orderby x.Cliente descending
                                      select x;
                                break;
                            }

                        default:
                            break;
                    }

                }


                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                _SBusqueda = null;
                _Orden = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las proformas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneApartadosXCliente(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from pro in db.Apartados_Vws
                           where pro.ClienteId==_ClienteId
                           orderby pro.Id descending
                           select pro);


                if (_Orden != null)
                {
                    switch (_Orden)
                    {
                        case "Fecha":
                            {
                                bus = from x in bus
                                      orderby x.Fecha1 descending
                                      select x;
                                break;
                            }

                        case "Cliente":
                            {
                                bus = from x in bus
                                      orderby x.Cliente descending
                                      select x;
                                break;
                            }

                        default:
                            break;
                    }

                }

  
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;


                _SBusqueda = null;
                _Orden = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las proformas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneDetalleApartado(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from fd in db.ApartadoDetalles
                           join a in db.Articulo on fd.CodigoArticulo equals a.Codigo
                           where fd.ApartadoId == _AbonoId
                           select new { fd.CodigoArticulo, Articulo = a.Descripcion, fd.Cantidad, fd.Precio, fd.TotalIVA, Descuento = fd.PorcDescuento });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                var bus1 = (from fd in db.ApartadoEncabezados
                            join u in db.Usuarios on fd.UsuarioId equals u.Id
                            where fd.Id == _AbonoId
                            select new { fd.Subtotal, nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido) }).First();

                _Subtotal = Convert.ToDecimal(bus1.Subtotal);
                _Cajero = bus1.nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle del apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool EliminaApartado()
        {
            try
            {
                this.OpenConn();


                try
                {
                    var historico = (from pe in db.ApartadoHistoricoAbonos
                                     where pe.ApartadoId == _AbonoId
                                     select pe);

                    if (historico.Count() > 0)
                    {
                        foreach (var item in historico)
                        {
                            db.ApartadoHistoricoAbonos.DeleteOnSubmit(item);

                            db.SubmitChanges();
                        }
                    }


                    var cajas = (from x in db.CajaDiarias
                                 where x.ComprobanteId == _AbonoId && x.MovimientoId == 5 //&& x.Monto == _MontoAbono //&& x.Activo==true && x.Visible==true
                                 select x);

                    if (cajas.Count() > 0)
                    {
                        foreach (var item in cajas)
                        {
                            db.CajaDiarias.DeleteOnSubmit(item);

                            db.SubmitChanges();
                        }
                    }
                }
                catch (Exception)
                {
                }







                var detalle = from pe in db.ApartadoDetalles
                              where pe.ApartadoId == _AbonoId
                              select pe;

                foreach (var item in detalle)
                {
                    var busArt = (from x in db.Articulo
                                  where x.Codigo == item.CodigoArticulo
                                  select x).First();

                    busArt.Existencias += Convert.ToDecimal(item.Cantidad);

                    db.ApartadoDetalles.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }

                var bus = (from x in db.ApartadoEncabezados
                           where x.Activo == true && x.Id == _AbonoId
                           select x).First();

                db.ApartadoEncabezados.DeleteOnSubmit(bus);

                db.SubmitChanges();








            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool ObtieneProducto(string id)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           where x.Activo == true && x.Codigo == id
                           select new
                           {
                               x.Codigo,
                               Articulo = x.Descripcion,
                               x.Existencias,
                               x.Precio,
                               x.IV,
                               x.IVPrecio2,
                               x.MontoIV,
                               x.PrecioIVU,
                               x.Precio2,
                               x.MontoIV2,
                               x.Precio2IVU,
                               x.UnidadMedidaId
                           });

                if (bus.Count() > 0)
                {

                    _Codigo = bus.First().Codigo;
                    _Descripcion = bus.First().Articulo;
                    _UnidadMedidaId = bus.First().UnidadMedidaId;

                    if (_TipoPrecio == 1)
                    {
                        _Precio = bus.First().Precio;
                        _IV = bus.First().IV;
                        _PrecioIVA = bus.First().PrecioIVU;
                        _MontoIV = bus.First().MontoIV;

                    }
                    if (_TipoPrecio == 2)
                    {
                        _Precio = bus.First().Precio2;
                        _IV = bus.First().IV;
                        _PrecioIVA = bus.First().Precio2IVU;
                        _MontoIV = bus.First().MontoIV2;
                    }
                }
                else
                {
                    MessageBox.Show("El articulo buscado no existe!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public void IngresaEncabezadoApartado(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.ApartadoEncabezado _NewFacturaEncabezado = new PuntoVentaDAL.ApartadoEncabezado();

                _NewFacturaEncabezado.FechaInicio = _FechaInicio;
                _NewFacturaEncabezado.FechaFinal = _FechaFinal;
                _NewFacturaEncabezado.Total = _TotalFactura;
                _NewFacturaEncabezado.Descuento = _Descuento;
                _NewFacturaEncabezado.Impuesto = _Impuesto;
                _NewFacturaEncabezado.Subtotal = _Subtotal;

                _NewFacturaEncabezado.ClienteId = _ClienteId;

                _NewFacturaEncabezado.UsuarioId = LoginUsuario;
                _NewFacturaEncabezado.Activo = true;

                db.ApartadoEncabezados.InsertOnSubmit(_NewFacturaEncabezado);

                db.SubmitChanges();

                var bus = (from f in db.ApartadoEncabezados
                           orderby f.Id descending
                           select f).First();

                _AbonoId = bus.Id;

                this.IngresaDetalleApartado(LoginUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaDetalleApartado(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    PuntoVentaDAL.ApartadoDetalle _NewFacturaDetalle = new PuntoVentaDAL.ApartadoDetalle();
                    _NewFacturaDetalle.CodigoArticulo = temp[0];
                    _NewFacturaDetalle.Cantidad = Convert.ToDecimal(temp[1]);
                    _NewFacturaDetalle.Precio = Convert.ToDecimal(temp[2]);
                    _NewFacturaDetalle.PorcDescuento = Convert.ToDecimal(temp[3]);
                    _NewFacturaDetalle.Descuento = Convert.ToDecimal(temp[4]);
                    _NewFacturaDetalle.TotalIVA = Convert.ToDecimal(temp[5]);
                    _NewFacturaDetalle.ApartadoId = _AbonoId;

                    db.ApartadoDetalles.InsertOnSubmit(_NewFacturaDetalle);

                    db.SubmitChanges();

                    var bus = (from x in db.Articulo
                               where x.Codigo == temp[0]
                               select x).First();

                    bus.Existencias -= Convert.ToDecimal(temp[1]);

                    db.SubmitChanges();


                }

                this.IngresaAbonoApartado(LoginUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaAbonoApartado(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.ApartadoHistoricoAbono _NewFacturaDetalle = new PuntoVentaDAL.ApartadoHistoricoAbono();
                _NewFacturaDetalle.ApartadoId = _AbonoId;
                _NewFacturaDetalle.Fecha = System.DateTime.Now;
                _NewFacturaDetalle.Monto = _MontoAbono;
                _NewFacturaDetalle.Saldo = _TotalFactura - _MontoAbono;

                db.ApartadoHistoricoAbonos.InsertOnSubmit(_NewFacturaDetalle);

                db.SubmitChanges();

                //var SALDO = (from x in db.ApartadoHistoricoAbonos
                //             where x.Id == _AbonoId
                //             orderby x.Id descending
                //             select x).First();

                //_Saldo = SALDO.Saldo;


                //var equipo = (from x in db.Equipos
                //              where x.NombreEquipo == System.Environment.MachineName.ToString()
                //              select x).First();

                //var bus = (from x in db.CajaDiarias
                //           join e in db.Equipos on x.EquipoId equals e.Id
                //           //where x.Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()) && e.NombreEquipo == System.Environment.MachineName.ToString()
                //           orderby x.Id descending
                //           select new { x.Saldo, e.Id, x.Hora }).First();

                //PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                //_NewCajaDiaria.MovimientoId = 5;
                //_NewCajaDiaria.ComprobanteId = Convert.ToInt64(_AbonoId);

                //if (DescCajaDiaria == 1)//efectivo
                //{
                //    _NewCajaDiaria.Descripcion = "Cobranza de apartado en efectivo: " + _AbonoId.ToString();
                //    _NewCajaDiaria.Monto = _MontoAbono;
                //    _NewCajaDiaria.Saldo = bus.Saldo + _MontoAbono;
                //}
                //if (DescCajaDiaria == 2)//tarjeta credito
                //{
                //    _NewCajaDiaria.Descripcion = "Cobranza de apartado tarjeta de crédito: " + _AbonoId.ToString()+"-";
                //    _NewCajaDiaria.Monto = _MontoAbono;
                //    _NewCajaDiaria.Saldo = bus.Saldo + _MontoAbono;
                //}
                                
                //_NewCajaDiaria.UsuarioId = LoginUsuario;
                //_NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                //_NewCajaDiaria.Hora = (System.DateTime.Now.ToShortTimeString());
                //_NewCajaDiaria.EquipoId = equipo.Id;
                //_NewCajaDiaria.Activo = true;
                //_NewCajaDiaria.Visible = true;

                //db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                //db.SubmitChanges(); 


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaAbonoIndividual(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.ApartadoHistoricoAbono _NewFacturaDetalle = new PuntoVentaDAL.ApartadoHistoricoAbono();
                _NewFacturaDetalle.ApartadoId = _AbonoId;
                _NewFacturaDetalle.Fecha = System.DateTime.Now;
                _NewFacturaDetalle.Monto = _MontoAbono;
                _NewFacturaDetalle.Saldo = _Saldo;

                db.ApartadoHistoricoAbonos.InsertOnSubmit(_NewFacturaDetalle);

                db.SubmitChanges();


                //var equipo = (from x in db.Equipos
                //              where x.NombreEquipo == System.Environment.MachineName.ToString()
                //              select x).First();

                //var bus = (from x in db.CajaDiarias
                //           join e in db.Equipos on x.EquipoId equals e.Id
                //           //where x.Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()) && e.NombreEquipo == System.Environment.MachineName.ToString()
                //           orderby x.Id descending
                //           select new { x.Saldo, e.Id, x.Hora }).First();

                //PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                //_NewCajaDiaria.MovimientoId = 5;
                //_NewCajaDiaria.ComprobanteId = Convert.ToInt64(_AbonoId);

                //if (DescCajaDiaria == 1)//efectivo
                //{
                //    _NewCajaDiaria.Descripcion = "Cobranza de apartado en efectivo: " + _AbonoId.ToString();
                //    _NewCajaDiaria.Monto = _MontoAbono;
                //    _NewCajaDiaria.Saldo = bus.Saldo + _MontoAbono;
                //}
                //if (DescCajaDiaria == 2)//tarjeta credito
                //{
                //    _NewCajaDiaria.Descripcion = "Cobranza de apartado tarjeta de crédito: " + _AbonoId.ToString() + "-";
                //    _NewCajaDiaria.Monto = _MontoAbono;
                //    _NewCajaDiaria.Saldo = bus.Saldo + _MontoAbono;
                //}

                //_NewCajaDiaria.UsuarioId = LoginUsuario;
                //_NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                //_NewCajaDiaria.Hora = (System.DateTime.Now.ToShortTimeString());
                //_NewCajaDiaria.EquipoId = equipo.Id;
                //_NewCajaDiaria.Activo = true;
                //_NewCajaDiaria.Visible = true;

                //db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                //db.SubmitChanges();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtengoHistorico(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = from x in db.ApartadoHistoricoAbonos
                          where x.ApartadoId == _AbonoId
                          select new { x.Fecha,Comprobante=x.Id,x.Monto};

                //if (bus.Count()>0)
                //{
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el historico del apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool EliminaAbono()
        {
            try
            {
                this.OpenConn();

                var detalle = (from pe in db.ApartadoHistoricoAbonos
                              where pe.ApartadoId == _AbonoId && pe.Id==_HistoricoId
                              select pe).First();

                db.ApartadoHistoricoAbonos.DeleteOnSubmit(detalle);

                db.SubmitChanges();

                try
                {
                    var bus = (from x in db.CajaDiarias
                               where x.ComprobanteId == _AbonoId && x.Monto == _MontoAbono //&& x.Activo==true && x.Visible==true
                               select x).First();

                    db.CajaDiarias.DeleteOnSubmit(bus);

                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el abono del apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public void EliminaApartadoTotal()
        {
            try
            {
                this.OpenConn();

                var Historicos = from f in db.ApartadoHistoricoAbonos
                                 where f.ApartadoId == _AbonoId
                                 select f;

                foreach (var item in Historicos)
                {

                    db.ApartadoHistoricoAbonos.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }

                var detalle = from pe in db.ApartadoDetalles
                              where pe.ApartadoId == _AbonoId
                              select pe;

                foreach (var item in detalle)
                {
                    var busArt = (from x in db.Articulo
                                  where x.Codigo == item.CodigoArticulo
                                  select x).First();

                    busArt.Existencias += Convert.ToDecimal(item.Cantidad);

                    db.ApartadoDetalles.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }

                var bus = (from x in db.ApartadoEncabezados
                           where x.Activo == true && x.Id == _AbonoId
                           select x).First();

                db.ApartadoEncabezados.DeleteOnSubmit(bus);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            finally
            {
                this.CloseConn();
            }
        
        }

        public void EliminaApartadoCancelado()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.ApartadoEncabezados
                           where x.Activo == true && x.Id == _AbonoId
                           select x).First();

                bus.Activo = false;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void print()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                ps.PrinterName = printer;
                if (ps.IsDefaultPrinter)
                {
                    Impresora = printer;
                    SetDefaultPrinter("PDFCreator");
                    break;
                }
            }

            PaperSize pkCustomSize1 = new PaperSize("8.5x11", 1100, 850);
            ps.DefaultPageSettings.PaperSize = pkCustomSize1;
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            pd.Document = pdoc;

            DialogResult result = pd.ShowDialog();//
            if (result == DialogResult.OK)//
            {//
                PrintPreviewDialog pp = new PrintPreviewDialog();//
                pp.Document = pdoc;//
                result = pp.ShowDialog();//
                if (result == DialogResult.OK)//
                {//
                    pdoc.Print();//
                }//
            }//
            SetDefaultPrinter(Impresora);
            //pdoc.Print();
        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Offset = 0;

            Graphics graphics = e.Graphics;

            int startX = 12;

            int startY = 25;

            this.ObtieneInformacionGeneral();

            Font stringFont = new Font("Times New Roman", 8, FontStyle.Bold);
            string measureString = string.Empty;
            stringFont = new Font("Times New Roman", 7);
            SizeF stringSize = new SizeF();
            SolidBrush sb = new SolidBrush(Color.Black);

            if (_Nombre.Length > 0)
            {
                graphics.DrawString(_Nombre.ToUpper(), new Font("Times New Roman", 13, FontStyle.Bold),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
            }

            if (_Dueno.Length > 0)
            {
                graphics.DrawString(_Dueno, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }

            if (_Cedula.Length > 0)
            {
                graphics.DrawString(_Cedula, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }

            if (_Telefono.Length > 0)
            {
                graphics.DrawString(_Telefono, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX , startY + Offset);
                Offset = Offset + 16;
            }

            if (_Fax.Length > 0)
            {
                graphics.DrawString(_Fax, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX , startY + Offset);
                Offset = Offset + 16;
            }

            if (_Encabezado1.Length > 0)
            {
                graphics.DrawString(_Encabezado1, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }
            if (_Encabezado2.Length > 0)
            {
                graphics.DrawString(_Encabezado2, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }
            if (_Encabezado3.Length > 0)
            {
                graphics.DrawString(_Encabezado3, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }
            if (_Encabezado4.Length > 0)
            {
                graphics.DrawString(_Encabezado4, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }

            graphics.DrawString("", new Font("Times New Roman", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            string x = "-----------------------------------";

            graphics.DrawString("Recibo número: " + _AbonoId, new Font("Times New Roman", 10, FontStyle.Bold),
                    new SolidBrush(Color.Black), startX, startY + Offset);

            measureString = string.Empty;
            stringFont = new Font("Times New Roman", 8);

            measureString = "Fecha: " + _FechaInicio.ToShortDateString();
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, 820 - stringSize.Width, startY + Offset);//entre menos mas a la izquierda
            Offset = Offset + 16;

            graphics.DrawString(x + x + x + x + x + x, new Font("Times New Roman", 8),//------------------
                    new SolidBrush(Color.Black), startX + 5, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Cliente: " + _ClienteNombre, new Font("Times New Roman", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Total cancelado por el cliente: " + toText(Convert.ToDouble(this._MontoAbono)).ToUpper()+" COLONES", new Font("Times New Roman", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("En concepto de abonos por el apartado número: " + _AbonoId.ToString(), new Font("Times New Roman", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Saldo: " + (_TotalFactura - _MontoAbono).ToString("##,#0.#0"), new Font("Times New Roman", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString(x + x + x + x + x + x, new Font("Times New Roman", 8),//------------------
                    new SolidBrush(Color.Black), startX + 5, startY + Offset);
            Offset = Offset + 16;

            stringFont = new Font("Times New Roman", 8);

            measureString = "IMPORTE TOTAL:";
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, 700 - stringSize.Width, startY + Offset);

            measureString = (Convert.ToDecimal(_MontoAbono)).ToString("#,##.#0");
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, 830 - stringSize.Width - startX, startY + Offset);
            Offset = Offset + 30;

            measureString = "_______________________________";
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, startX, startY + Offset);
            Offset = Offset + 20;

            measureString = "VENDEDOR:";
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, 70, startY + Offset);
            Offset = Offset + 20;

            measureString = _CajeroNombre.ToUpper();
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, ((225 - stringSize.Width) / 2), startY + Offset);
            Offset = Offset + 20;
         
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
        
        public string enletras(string num)


       {


           string res, dec = "";


           Int64 entero;


           int decimales;


           double nro;


           try


           {


               nro = Convert.ToDouble(num);


           }


           catch


           {


               return "";


           }


           entero = Convert.ToInt64(Math.Truncate(nro));


           decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));


           if (decimales > 0)


           {


               dec = " CON " + decimales.ToString() + "/100";


           }


           res = toText(Convert.ToDouble(entero)) + dec;


           return res;


       }

        private string toText(double value)
       {


           string Num2Text = "";


           value = Math.Truncate(value);


           if (value == 0) Num2Text = "CERO";


           else if (value == 1) Num2Text = "UNO";


           else if (value == 2) Num2Text = "DOS";


           else if (value == 3) Num2Text = "TRES";


           else if (value == 4) Num2Text = "CUATRO";


           else if (value == 5) Num2Text = "CINCO";


           else if (value == 6) Num2Text = "SEIS";


           else if (value == 7) Num2Text = "SIETE";


           else if (value == 8) Num2Text = "OCHO";


           else if (value == 9) Num2Text = "NUEVE";


           else if (value == 10) Num2Text = "DIEZ";


           else if (value == 11) Num2Text = "ONCE";


           else if (value == 12) Num2Text = "DOCE";


           else if (value == 13) Num2Text = "TRECE";


           else if (value == 14) Num2Text = "CATORCE";


           else if (value == 15) Num2Text = "QUINCE";


           else if (value < 20) Num2Text = "DIECI" + toText(value - 10);


           else if (value == 20) Num2Text = "VEINTE";


           else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);


           else if (value == 30) Num2Text = "TREINTA";


           else if (value == 40) Num2Text = "CUARENTA";


           else if (value == 50) Num2Text = "CINCUENTA";


           else if (value == 60) Num2Text = "SESENTA";


           else if (value == 70) Num2Text = "SETENTA";


           else if (value == 80) Num2Text = "OCHENTA";


           else if (value == 90) Num2Text = "NOVENTA";


           else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);


           else if (value == 100) Num2Text = "CIEN";


           else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);


           else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";


           else if (value == 500) Num2Text = "QUINIENTOS";


           else if (value == 700) Num2Text = "SETECIENTOS";


           else if (value == 900) Num2Text = "NOVECIENTOS";


           else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);


           else if (value == 1000) Num2Text = "MIL";


           else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);


           else if (value < 1000000)


           {


               Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";


               if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);


           }


           else if (value == 1000000) Num2Text = "UN MILLON";


           else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);


           else if (value < 1000000000000)


           {


               Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";


               if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);


           }


           else if (value == 1000000000000) Num2Text = "UN BILLON";


           else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);


           else


           {


               Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";


               if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
           }
           return Num2Text;
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
