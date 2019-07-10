using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
namespace PuntoVentaBL
{
    public class Compras
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region propiedades
        private Int64 _CID;

        public Int64 CID
        {
            get { return _CID; }
            set { _CID = value; }
        }

        private string _ComprobanteIdString;

        public string ComprobanteIdString
        {
            get { return _ComprobanteIdString; }
            set { _ComprobanteIdString = value; }
        }


        public List<string> Articulos = new List<string>();


        private bool _PagoCheque;

        public bool PagoCheque
        {
            get { return _PagoCheque; }
            set { _PagoCheque = value; }
        }

        private string _CodigoId;

        public string CodigoId
        {
            get { return _CodigoId; }
            set { _CodigoId = value; }
        }

        private decimal _Impuesto;

        public decimal Impuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
        }


        private int _TipoPrecio;

        public int TipoPrecio
        {
            get { return _TipoPrecio; }
            set { _TipoPrecio = value; }
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


        private int _ProveedorId;

        public int ProveedorId
        {
            get { return _ProveedorId; }
            set { _ProveedorId = value; }
        }

        private decimal _Cantidad;

        public decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }


        private string _ComprobanteId;

        public string ComprobanteId
        {
            get { return _ComprobanteId; }
            set { _ComprobanteId = value; }
        }
        private string _ProveedorNombre;

        public string ProveedorNombre
        {
            get { return _ProveedorNombre; }
            set { _ProveedorNombre = value; }
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

        private string _Fecha;

        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private string _Hora;

        public string Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }

        private decimal _Descuento;

        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
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

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
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

        private decimal _TotalFactura;

        public decimal TotalFactura
        {
            get { return _TotalFactura; }
            set { _TotalFactura = value; }
        }

        private decimal _Subtotal;

        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private bool _CompraCheque;

        public bool CompraCheque
        {
            get { return _CompraCheque; }
            set { _CompraCheque = value; }
        }


        private int _TipoPago;

        public int TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }

        private int _ClienteId;

        public int ClienteId
        {
            get { return _ClienteId; }
            set { _ClienteId = value; }
        }

        private Int64 _CompraId;

        public Int64 CompraId
        {
            get { return _CompraId; }
            set { _CompraId = value; }
        }

        #endregion

        #region metodos

        public void ObtieneFacturaBusqueda(DataGridView dgv)
        {
            try
            {
                this.OpenConn();


                //var bus = from x in db.ObtieneCompras_Vws
                //          join e in db.Equipos on x.EquipoId equals e.Id
                //          join m in db.Movimientos on x.MovimientoId equals m.Id
                //          where x.MovimientoId == 3 && e.NombreEquipo == System.Environment.MachineName.ToString() && x.FacturaId == _ComprobanteId.ToString()
                //          orderby x.Id descending
                //          select x;
                var bus = from x in db.ObtieneCompras_Vws
                          join e in db.Equipos on x.EquipoId equals e.Id
                          join m in db.Movimientos on x.MovimientoId equals m.Id
                          where x.MovimientoId == 3 &&  x.FacturaId == _ComprobanteId.ToString()
                          orderby x.Id descending
                          select x;


                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las compras: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneFacturasCompra(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = from x in db.ObtieneCompras_Vws
                          //join e in db.Equipos on x.EquipoId equals e.Id
                          //join m in db.Movimientos on x.MovimientoId equals m.Id
                          where x.MovimientoId == 3 //&& e.NombreEquipo == System.Environment.MachineName.ToString()
                          orderby x.Id descending
                          select x;
                //var bus = from fe in db.FacturaEncabezado
                //          join p in db.Proveedor on fe.ProveedorId equals p.Id
                //          join cd in db.CajaDiaria on fe.Id equals cd.ComprobanteId
                //          join e in db.Equipo on cd.EquipoId equals e.Id
                //          where fe.Activo == true && fe.ProveedorId != null && e.NombreEquipo==System.Environment.MachineName.ToString() && cd.MovimientoId=='3'
                //          orderby fe.Id descending
                //          select new { fe.Id, Nombre = p.Nombre, Descuento = fe.Descuento == null ? Convert.ToDecimal("0.00") : fe.Descuento, fe.Total, fe.Fecha, fe.Hora };

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las facturas de compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneDetalleFactura(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from fd in db.CompraDetalles
                           join a in db.Articulo on fd.CodigoArticulo equals a.Codigo
                           where fd.FacturaId == Convert.ToInt64(_ComprobanteId)
                           select new { fd.CodigoArticulo, Articulo = a.Descripcion, fd.Cantidad, fd.Precio, fd.TotalIVA, Descuento = fd.PorcDescuento });

                var bus1 = (from fe in db.CompraEncabezados
                            where fe.Id == Convert.ToInt64(_ComprobanteId)
                            select fe).First();

                var caja = (from cd in db.CajaDiarias
                            where cd.ComprobanteId == Convert.ToInt64(_ComprobanteId)
                            select cd).First();

                var proveedor = (from x in db.Proveedors
                                 where x.Id == Convert.ToInt32(bus1.ProveedorId)
                                 select new { x.Nombre }).First();

                var usuario = (from x in db.Usuarios
                               where x.Id == Convert.ToInt32(bus1.UsuarioId)
                               select new { x.Nombre, Apellido = (x.Apellido == null ? "" : x.Apellido) }).First();

                _Fecha = bus1.Fecha.ToShortDateString();
                _Hora = bus1.Hora.ToString();
                _Descuento = Convert.ToDecimal(bus1.Descuento);
                _Total = bus1.Total;
                _Recibido = Convert.ToDecimal(bus1.Recibido);
                _Cambio = Convert.ToDecimal(bus1.Cambio);
                _ProveedorNombre = proveedor.Nombre;
                _CajeroNombre = usuario.Nombre + " " + usuario.Apellido;
                _Impuesto = Convert.ToDecimal(bus1.Impuesto.ToString());

                if (caja.Monto == 0)
                {
                    _PagoCheque = true;
                }
                else
                {
                    _PagoCheque = false;
                }

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle de la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool EliminaFactura(Int64 ComprobanteId, int UserId)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.CompraEncabezados
                           where x.Id == ComprobanteId
                           select x).First();

                bus.Activo = false;
                bus.UsuarioId = UserId;

                db.SubmitChanges();

                var caja = (from x in db.CajaDiarias
                            where x.Id == _CID
                            select x).First();

                caja.Activo = false;
                caja.Visible = false;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public bool AgregoDetalleArticulo(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                if (_TipoPrecio == 1)
                {
                    var bus = (from a in db.Articulo
                               join p in db.Proveedors on a.ProveedorId equals p.Id
                               where a.Activo == true && a.Codigo == _CodigoId ///&& a.ProveedorId==_ProveedorId
                               select new { a.Codigo, a.Descripcion, a.Precio, a.UnidadMedidaId, a.MontoIV });

                    if (bus.Count() > 0)
                    {
                        dgv.Rows.Add(bus.First().Codigo, bus.First().Descripcion, _Cantidad, Math.Round(Convert.ToDecimal(_Cantidad * bus.First().Precio), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0"), bus.First().UnidadMedidaId, bus.First().Precio.ToString("#0,#.#0"), Convert.ToDecimal(_Cantidad * bus.First().MontoIV).ToString("#0,#.#0"), bus.First().MontoIV.ToString("#0,#.#0"));
                        _Descripcion = bus.First().Descripcion;
                        _Precio = bus.First().Precio;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (_TipoPrecio == 2)
                {
                    var bus = (from a in db.Articulo
                               join p in db.Proveedors on a.ProveedorId equals p.Id
                               where a.Activo == true && a.Codigo == _CodigoId //&& a.ProveedorId == _ProveedorId
                               select new { a.Codigo, a.Descripcion, a.Precio2, a.UnidadMedidaId, a.MontoIV2 });

                    if (bus.Count() > 0)
                    {
                        dgv.Rows.Add(bus.First().Codigo, bus.First().Descripcion, _Cantidad, Math.Round(Convert.ToDecimal(_Cantidad * bus.First().Precio2), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0"), bus.First().UnidadMedidaId, bus.First().Precio2.ToString("#0,#.#0"), Convert.ToDecimal(_Cantidad * bus.First().MontoIV2).ToString("#0,#.#0"), bus.First().MontoIV2.ToString("#0,#.#0"));
                        _Descripcion = bus.First().Descripcion;
                        _Precio = bus.First().Precio2;
                    }
                    else
                    {
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public void ModificaUltimaCompra()
        {
            try
            {
                this.OpenConn();

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    var bus = (from a in db.Articulo
                               where a.Codigo == temp[0] && a.Activo == true
                               select a).First();

                    if (Convert.ToDateTime(bus.FechaUltimaCompra) < Convert.ToDateTime(_Fecha))
                    {
                        bus.FechaUltimaCompra = Convert.ToDateTime(_Fecha);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaEncabezadoFactura(int LoginUsuario)
        {
            try
            {
                this.OpenConn();
                PuntoVentaDAL.CompraEncabezado _NewFacturaEncabezado = new PuntoVentaDAL.CompraEncabezado();


                _NewFacturaEncabezado.Fecha = Convert.ToDateTime(Convert.ToDateTime(_Fecha).ToShortDateString());
                _NewFacturaEncabezado.Hora = Convert.ToDateTime(_Fecha).ToShortTimeString();

                _NewFacturaEncabezado.Total = _TotalFactura;
                _NewFacturaEncabezado.Descuento = _Descuento;
                _NewFacturaEncabezado.Recibido = _Recibido;
                _NewFacturaEncabezado.Cambio = _Cambio;
                _NewFacturaEncabezado.TipoPago = _TipoPago;
                _NewFacturaEncabezado.Impuesto = _Impuesto;
                _NewFacturaEncabezado.Subtotal = _Subtotal;

                _NewFacturaEncabezado.ProveedorId = _ProveedorId;//compra


                _NewFacturaEncabezado.UsuarioId = LoginUsuario;
                _NewFacturaEncabezado.Activo = true;

                db.CompraEncabezados.InsertOnSubmit(_NewFacturaEncabezado);

                db.SubmitChanges();

                var bus = (from f in db.CompraEncabezados
                           orderby f.Id descending
                           select f).First();

                _CompraId = bus.Id;

                this.IngresaDetalleFactura(LoginUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaDetalleFactura(int LoginUsuario)
        {
            decimal pf = 0, mi = 0, pg = 0;


            try
            {
                this.OpenConn();

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    PuntoVentaDAL.CompraDetalle _NewFacturaDetalle = new PuntoVentaDAL.CompraDetalle();
                    _NewFacturaDetalle.CodigoArticulo = temp[0];
                    _NewFacturaDetalle.Precio = Convert.ToDecimal(temp[1]);
                    _NewFacturaDetalle.Cantidad = Convert.ToDecimal(temp[2]);
                    _NewFacturaDetalle.PorcDescuento = Convert.ToDecimal(temp[3]);
                    _NewFacturaDetalle.Descuento = Convert.ToDecimal(temp[4]);
                    _NewFacturaDetalle.TotalIVA = Convert.ToDecimal(temp[5]);
                    _NewFacturaDetalle.FacturaId = _CompraId;

                    db.CompraDetalles.InsertOnSubmit(_NewFacturaDetalle);

                    db.SubmitChanges();

                    var bus = (from x in db.Articulo
                               where x.Codigo == temp[0]
                               select x).First();

                    bus.Existencias += Convert.ToDecimal(temp[2]);
                    bus.Precio = Convert.ToDecimal(temp[1]);
                 //   bus.PrecioIVU = Convert.ToDecimal(temp[5]);
                    #region ACTUALIZAPRECIOIVU
                    /*
                    if (bus.IV == true)//tiene iv por agregarse
                    {
                      //  pg = ((Convert.ToDecimal(temp[1]) * bus.UtilidadPrecio) / 100) + (Convert.ToDecimal(temp[1]));
                        pg = Convert.ToDecimal(temp[5]);
                        mi = (pg * bus.PorcIV) / 100;
                        pf = pg + mi;
                        bus.MontoIV = mi;
                        string stemp = Math.Round(pf, 0, MidpointRounding.AwayFromZero).ToString();

                        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                        {
                            if (stemp.Length < 2)
                            {
                                bus.PrecioIVU = Convert.ToDecimal(Convert.ToDecimal("5").ToString("F"));
                                return;
                            }
                            bus.PrecioIVU = Convert.ToDecimal(Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F"));
                        }
                        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                        {
                            if (stemp.Length < 2)
                            {
                                bus.PrecioIVU = Convert.ToDecimal(Convert.ToDecimal("5").ToString("F"));
                                return;
                            }
                            bus.PrecioIVU = Convert.ToDecimal(Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F"));
                        }
                        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                        {
                            if (stemp.Length < 2)
                            {
                                bus.PrecioIVU = Convert.ToDecimal(Convert.ToDecimal("10").ToString("F"));
                                return;
                            }
                            decimal tempn = Convert.ToDecimal(stemp);
                            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                            bus.PrecioIVU = Convert.ToDecimal(tempn2.ToString("F"));
                        }
                    }
                    else
                    {
                        pg = ((Convert.ToDecimal(temp[1]) * bus.UtilidadPrecio) / 100) + (Convert.ToDecimal(temp[1]));
                     
                        bus.PrecioIVU = Convert.ToDecimal(pg.ToString("F"));

                        string stemp = Math.Round(pg, 0, MidpointRounding.AwayFromZero).ToString();

                        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                        {
                            if (stemp.Length < 2)
                            {
                                bus.PrecioIVU = Convert.ToDecimal(Convert.ToDecimal("5").ToString("F"));
                                return;
                            }
                            bus.PrecioIVU = Convert.ToDecimal(Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F"));
                        }
                        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                        {
                            if (stemp.Length < 2)
                            {
                                bus.PrecioIVU = Convert.ToDecimal(Convert.ToDecimal("5").ToString("F"));
                                return;
                            }
                            bus.PrecioIVU = Convert.ToDecimal(Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F"));
                        }
                        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                        {
                            if (stemp.Length < 2)
                            {
                                bus.PrecioIVU = Convert.ToDecimal(Convert.ToDecimal("10").ToString("F"));
                                return;
                            }
                            decimal tempn = Convert.ToDecimal(stemp);
                            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                            bus.PrecioIVU = Convert.ToDecimal(tempn2.ToString("F"));
                        }

                    }
                    */


#endregion




                    db.SubmitChanges();
                }

                this.IngresaCajaDiaria(LoginUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaCajaDiaria(int LoginUsuario)
        {
            try
            {
                this.OpenConn();


                var equipo = (from x in db.Equipos
                              where x.NombreEquipo == System.Environment.MachineName.ToString()
                              select x).First();

                var bus = (from cd in db.CajaDiarias
                           join e in db.Equipos on cd.EquipoId equals e.Id
                           //x.Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()) &&
                           where e.NombreEquipo == System.Environment.MachineName.ToString()
                           && cd.Activo == true && cd.Visible == true
                           orderby cd.Id descending
                           select new { cd.Saldo, e.Id, cd.Hora }).First();


                PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();

                _NewCajaDiaria.MovimientoId = 3;//compra
                _NewCajaDiaria.Descripcion = "Compra Factura Nº:" + _ComprobanteId;
                _NewCajaDiaria.ComprobanteId = _CompraId;
                _NewCajaDiaria.FacturaId = _ComprobanteId;

                if (_CompraCheque == true)
                {
                    _NewCajaDiaria.Monto = 0;
                    _NewCajaDiaria.Saldo = bus.Saldo;
                }
                else
                {
                    _NewCajaDiaria.Monto = Convert.ToDecimal(_TotalFactura);
                    _NewCajaDiaria.Saldo = bus.Saldo - _TotalFactura;
                }


                _NewCajaDiaria.UsuarioId = LoginUsuario;
                _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                _NewCajaDiaria.EquipoId = bus.Id;

                if (_CompraCheque == true)
                {
                    _NewCajaDiaria.Activo = false;
                    _NewCajaDiaria.Visible = false;
                }
                else
                {
                    _NewCajaDiaria.Activo = true;
                    _NewCajaDiaria.Visible = true;
                }

                db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);
                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaCajaDiariaTemp(int LoginUsuario)
        {
            try
            {
                this.OpenConn();


                var equipo = (from x in db.Equipos
                              where x.NombreEquipo == System.Environment.MachineName.ToString()
                              select x).First();

                var bus = (from cd in db.CajaDiarias
                           join e in db.Equipos on cd.EquipoId equals e.Id
                           //x.Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()) &&
                           where e.NombreEquipo == System.Environment.MachineName.ToString()
                           && cd.Activo == true && cd.Visible == true
                           orderby cd.Id descending
                           select new { cd.Saldo, e.Id, cd.Hora }).First();


                PuntoVentaDAL.CajaDiariaTemp _NewCajaDiaria = new PuntoVentaDAL.CajaDiariaTemp();

                _NewCajaDiaria.MovimientoId = 3;//compra
                _NewCajaDiaria.Descripcion = "Compra Temporal Factura Nº:" + _ComprobanteId;
                _NewCajaDiaria.ComprobanteId = _CompraId;
                _NewCajaDiaria.FacturaId = _ComprobanteId;

                if (_CompraCheque == true)
                {
                    _NewCajaDiaria.Monto = 0;
                    _NewCajaDiaria.Saldo = bus.Saldo;
                }
                else
                {
                    _NewCajaDiaria.Monto = Convert.ToDecimal(_TotalFactura);
                    _NewCajaDiaria.Saldo = bus.Saldo - _TotalFactura;
                }


                _NewCajaDiaria.UsuarioId = LoginUsuario;
                _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                _NewCajaDiaria.EquipoId = bus.Id;

                if (_CompraCheque == true)
                {
                    _NewCajaDiaria.Activo = false;
                    _NewCajaDiaria.Visible = false;
                }
                else
                {
                    _NewCajaDiaria.Activo = true;
                    _NewCajaDiaria.Visible = true;
                }

                db.CajaDiariaTemp.InsertOnSubmit(_NewCajaDiaria);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaEncabezadoFacturaTemp(int LoginUsuario)
        {
            try
            {
                this.OpenConn();
                PuntoVentaDAL.CompraEncabezadoTemp _NewFacturaEncabezado = new PuntoVentaDAL.CompraEncabezadoTemp();

                _NewFacturaEncabezado.Fecha = Convert.ToDateTime(Convert.ToDateTime(_Fecha).ToShortDateString());
                _NewFacturaEncabezado.Hora = Convert.ToDateTime(_Fecha).ToShortTimeString();
                _NewFacturaEncabezado.Total = _TotalFactura;
                _NewFacturaEncabezado.Descuento = _Descuento;
                _NewFacturaEncabezado.Recibido = _Recibido;
                _NewFacturaEncabezado.Cambio = _Cambio;
                _NewFacturaEncabezado.TipoPago = _TipoPago;
                _NewFacturaEncabezado.Impuesto = _Impuesto;
                _NewFacturaEncabezado.Subtotal = _Subtotal;
                _NewFacturaEncabezado.ProveedorId = _ProveedorId;//compra
                _NewFacturaEncabezado.UsuarioId = LoginUsuario;
                _NewFacturaEncabezado.Activo = true;

                db.CompraEncabezadoTemp.InsertOnSubmit(_NewFacturaEncabezado);

                db.SubmitChanges();

                var bus = (from f in db.CompraEncabezadoTemp
                           orderby f.Id descending
                           select f).First();

                _CompraId = bus.Id;

                this.IngresaDetalleFacturaTemp(LoginUsuario);

                MessageBox.Show("Factura Temporal Ingresada Con Éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaDetalleFacturaTemp(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    PuntoVentaDAL.CompraDetalleTemp _NewFacturaDetalle = new PuntoVentaDAL.CompraDetalleTemp();
                    _NewFacturaDetalle.CodigoArticulo = temp[0];
                    _NewFacturaDetalle.Precio = Convert.ToDecimal(temp[1]);
                    _NewFacturaDetalle.Cantidad = Convert.ToDecimal(temp[2]);
                    _NewFacturaDetalle.PorcDescuento = Convert.ToDecimal(temp[3]);
                    _NewFacturaDetalle.Descuento = Convert.ToDecimal(temp[4]);
                    _NewFacturaDetalle.TotalIVA = Convert.ToDecimal(temp[5]);
                    _NewFacturaDetalle.FacturaId = _CompraId;

                    db.CompraDetalleTemp.InsertOnSubmit(_NewFacturaDetalle);

                    db.SubmitChanges();

                }
                this.IngresaCajaDiariaTemp(LoginUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool ObtieneFacturaTemp()
        {
            try
            {
                this.OpenConn();

                var bus = (from fe in db.CompraEncabezadoTemp
                           join p in db.Proveedors on fe.ProveedorId equals p.Id
                           join cd in db.CajaDiariaTemp on fe.Id equals cd.ComprobanteId
                           where fe.Activo == true
                           orderby fe.Id descending
                           select new
                           {
                               cd.Id,
                               cd.FacturaId,
                               p.Nombre,
                               fe.Descuento,
                               fe.Impuesto,
                               fe.Total,
                               fe.Subtotal,
                               fe.Recibido,
                               fe.Cambio,
                               fe.ClienteId,
                               fe.Fecha,
                               fe.Hora,
                               cd.EquipoId,
                               cd.MovimientoId,
                               fe.ProveedorId,
                               fe.Activo,
                               fe.TipoPago,
                               cd.ComprobanteId
                           });

                if (bus.Count() > 0)
                {
                    _CompraId = Convert.ToInt64(bus.First().FacturaId);
                    _Fecha = bus.First().Fecha.ToShortDateString();
                    _Hora = bus.First().Hora.ToString();
                    _TotalFactura = bus.First().Total;
                    _Descuento = Convert.ToDecimal(bus.First().Descuento);
                    _Impuesto = Convert.ToDecimal(bus.First().Impuesto);
                    _Subtotal = Convert.ToDecimal(bus.First().Subtotal);
                    _Recibido = Convert.ToDecimal(bus.First().Recibido);
                    _Cambio = Convert.ToDecimal(bus.First().Cambio);
                    _ClienteId = Convert.ToInt32(bus.First().ClienteId);
                    _ProveedorId = Convert.ToInt32(bus.First().ProveedorId);
                    _TipoPago = Convert.ToInt32(bus.First().TipoPago);
                    _Cambio = Convert.ToDecimal(bus.First().Cambio);
                    _ComprobanteId = bus.First().ComprobanteId.ToString();

                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un inconveniente al intentar obtener las facturas temporal de compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {

                this.CloseConn();
            }
        }

        public void ObtieneDetalleFacturaTemp(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from fd in db.CompraDetalleTemp
                           join a in db.Articulo on fd.CodigoArticulo equals a.Codigo
                           where fd.FacturaId == Convert.ToInt64(_ComprobanteId)
                           select new
                           {
                               Codigo = fd.CodigoArticulo,
                               Descripcion = a.Descripcion,
                               Precio = fd.Precio.ToString(),
                               Cantidad = fd.Cantidad.ToString(),
                               PorcDescuento = fd.PorcDescuento.ToString(),
                               Descuento = fd.Descuento.ToString(),
                               TotalIVA = fd.TotalIVA.ToString()
                           });

                var bus1 = (from fe in db.CompraEncabezadoTemp
                            where fe.Id == Convert.ToInt64(_ComprobanteId)
                            select fe).First();

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle de la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ActualizaFacturaTemp(Int64 ComprobanteId, int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.CompraEncabezadoTemp
                           where f.Id == ComprobanteId &&
                                  f.Activo == true
                           select f).First();

                bus.Fecha = Convert.ToDateTime(Convert.ToDateTime(_Fecha).ToShortDateString());
                bus.Hora = Convert.ToDateTime(_Fecha).ToShortTimeString();
                bus.Total = _TotalFactura;
                bus.Descuento = _Descuento;
                bus.Recibido = _Recibido;
                bus.Cambio = _Cambio;
                bus.TipoPago = _TipoPago;
                bus.Impuesto = _Impuesto;
                bus.Subtotal = _Subtotal;
                bus.ProveedorId = _ProveedorId;
                bus.UsuarioId = LoginUsuario;

                db.SubmitChanges();

                var bus1 = (from f in db.CompraEncabezadoTemp
                            orderby f.Id descending
                            select f).First();

                _CompraId = bus1.Id;

                EliminaDetalleFacturaTemp();

                this.IngresaDetalleFacturaTemp(LoginUsuario);

                MessageBox.Show("Factura Temporal Actualizada Con Éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la factura temporal: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void EliminaDetalleFacturaTemp()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.CompraDetalleTemp
                           where x.FacturaId == _CompraId
                           select x).First();

                db.CompraDetalleTemp.DeleteOnSubmit(bus);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la factura temporal: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void EliminaFacturaTemp(Int64 ComprobanteId)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.CompraEncabezadoTemp
                           where x.Id == ComprobanteId
                           select x).First();

                db.CompraEncabezadoTemp.DeleteOnSubmit(bus);

                //elimina caja temporal:
                var bus1 = (from x in db.CajaDiariaTemp
                            where x.ComprobanteId == ComprobanteId
                            select x).First();

                db.CajaDiariaTemp.DeleteOnSubmit(bus1);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la factura temporal: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public DataTable CreaFacturaDetalleTemp()
        {
            using (DataTable dt = new DataTable())
            {
                //Crea columnas de ComprasDetalleTemp:
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Precio");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("PorcDescuento");
                dt.Columns.Add("Descuento");
                dt.Columns.Add("TotalIVA");
                dt.Columns.Add("TipoPrecio");
                dt.Columns.Add("Impuesto");
                dt.Columns.Add("PrecioFinal");
                return dt;
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
        #endregion
    }
}

