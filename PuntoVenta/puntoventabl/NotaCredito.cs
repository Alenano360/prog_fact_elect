using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class NotaCredito
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades
        private string _Cajero;

        public string Cajero
        {
            get { return _Cajero; }
            set { _Cajero = value; }
        }
        
        private decimal _Subtotal;

        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private decimal _Impuesto;

        public decimal Impuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
        }
        
        
        private string _Orden;

        public string Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }

        private string _SBusqueda;

        public string Sbusqueda
        {
            get { return _SBusqueda; }
            set { _SBusqueda = value; }
        }


        private Int64 _Id;

        public Int64 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }


        private int _CantidadLineas;

        public int CantidadLineas
        {
            get { return _CantidadLineas; }
            set { _CantidadLineas = value; }
        }

        private int _CantidadArticulo;

        public int CantidadArticulo
        {
            get { return _CantidadArticulo; }
            set { _CantidadArticulo = value; }
        }


        private bool _CompraCheque;

        public bool CompraCheque
        {
            get { return _CompraCheque; }
            set { _CompraCheque = value; }
        }

        private Int64 _ComprobanteId;

        public Int64 ComprobanteId
        {
            get { return _ComprobanteId; }
            set { _ComprobanteId = value; }
        }

        private int _TipoPago;

        public int TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }


        private int _ProveedorId;

        public int ProveedorId
        {
            get { return _ProveedorId; }
            set { _ProveedorId = value; }
        }

        public List<string> LArticulo = new List<string>();

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

        private int _TipoPrecio;

        public int TipoPrecio
        {
            get { return _TipoPrecio; }
            set { _TipoPrecio = value; }
        }

        private decimal _Existencias;

        public decimal Existencias
        {
            get { return _Existencias; }
            set { _Existencias = value; }
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


        private decimal _TotalFactura;

        public decimal TotalFactura
        {
            get { return _TotalFactura; }
            set { _TotalFactura = value; }
        }

        private int _ClienteId;

        public int ClienteId
        {
            get { return _ClienteId; }
            set { _ClienteId = value; }
        }

        private Int64 _FacturaId;

        public Int64 FacturaId
        {
            get { return _FacturaId; }
            set { _FacturaId = value; }
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

        #endregion

        #region Metodos

        public void ObtieneNotasCredito(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from pro in db.NotaEncabezados
                           join c in db.Clientes on pro.ClienteId equals c.Id into ps
                           from c in ps.DefaultIfEmpty()
                           join u in db.Usuarios on pro.UsuarioId equals u.Id into pu
                           from u in pu.DefaultIfEmpty()
                           //where pro.Activo == true
                           orderby pro.Id descending
                           select new
                           {
                               pro.Id,
                               Cliente = c.Nombre + " " + (c.Apellidos == null ? "" : c.Apellidos),
                               Fecha = (pro.Fecha.ToShortDateString()),
                               Fecha1 = pro.Fecha,
                               pro.Hora,
                               Total = (pro.Total.ToString()),
                               Usuario = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido),
                               userid=u.Id,
                               descuento = (pro.Descuento == null ? Convert.ToDecimal("0.00") : pro.Descuento),
                               impuesto = (pro.Impuesto == null ? Convert.ToDecimal("0.00") : pro.Impuesto),
                               FacturaId=pro.FacturaId==null?0:pro.FacturaId
                           });

                if (_SBusqueda != null)
                {
                    bus = from x in bus
                          where x.Id.ToString().Contains(_SBusqueda) || x.Cliente.Contains(_SBusqueda) || x.Total.ToString().Contains(_SBusqueda)
                          || x.Usuario.Contains(_SBusqueda) || x.FacturaId.ToString().Contains(_SBusqueda)
                          select x;
                }

                if (_Orden != null)
                {
                    switch (_Orden)
                    {
                        case "Fecha":
                            {
                                bus = from x in bus
                                      orderby x.Fecha1, x.Hora descending
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
                MessageBox.Show("Hubo un inconveniente al intentar obtener las notas de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneNotasCreditoActivas(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from pro in db.NotaEncabezados
                           join c in db.Clientes on pro.ClienteId equals c.Id into ps
                           from c in ps.DefaultIfEmpty()
                           join u in db.Usuarios on pro.UsuarioId equals u.Id into pu
                           from u in pu.DefaultIfEmpty()
                           where pro.Activo == true
                           orderby pro.Id descending
                           select new
                           {
                               pro.Id,
                               Cliente = c.Nombre + " " + (c.Apellidos == null ? "" : c.Apellidos),
                               Fecha = (pro.Fecha.ToShortDateString()),
                               Fecha1 = pro.Fecha,
                               pro.Hora,
                               Total = (pro.Total.ToString()),
                               Usuario = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido),
                               userid = u.Id,
                               descuento = (pro.Descuento == null ? Convert.ToDecimal("0.00") : pro.Descuento),
                               impuesto = (pro.Impuesto == null ? Convert.ToDecimal("0.00") : pro.Impuesto),
                               FacturaId = pro.FacturaId == null ? 0 : pro.FacturaId
                           });

                
                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las notas de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneDetalleNota(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from fd in db.NotaDetalles
                           join a in db.Articulo on fd.CodigoArticulo equals a.Codigo
                           where fd.NotaId == _ComprobanteId
                           select new { fd.CodigoArticulo, Articulo = a.Descripcion, fd.Cantidad, fd.Precio, fd.TotalIVA, Descuento = fd.PorcDescuento });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                var bus1 = (from fd in db.NotaEncabezados
                            join u in db.Usuarios on fd.UsuarioId equals u.Id
                            where fd.Id == _ComprobanteId
                            select new { fd.Subtotal, nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido) }).First();

                _Subtotal = Convert.ToDecimal(bus1.Subtotal);
                _Cajero = bus1.nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle de la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool MostrarNotasCredito(DataGridView dgv, Int64 NotaId)
        {
            try
            {
                this.OpenConn();

                var encabezado = (from pe in db.NotaEncabezados
                                  where pe.Id == NotaId 
                                  && pe.Activo == true
                                  select new
                                  {
                                      pe.Total,
                                      pe.Descuento,
                                      pe.ClienteId
                                  }).First();

                var detalles = from pe in db.NotaEncabezados
                               join pd in db.NotaDetalles on pe.Id equals pd.NotaId
                               join a in db.Articulo on pd.CodigoArticulo equals a.Codigo
                               where pe.Id == NotaId && pe.Activo == true
                               select new { Codigo = (pd.CodigoArticulo), a.Descripcion, pd.Precio, pd.Cantidad, pd.PorcDescuento, pd.Descuento, TotalIVA = pd.TotalIVA };


                _ClienteId = Convert.ToInt32(encabezado.ClienteId);
                _TotalFactura = Convert.ToDecimal(encabezado.Total.ToString("F"));
                _Descuento = Convert.ToDecimal(Convert.ToDecimal(encabezado.Descuento).ToString("F"));

                _CantidadLineas = 0;
                _CantidadArticulo = 0;
                _MontoIV = 0;

                dgv.AutoGenerateColumns = false;

                foreach (var item in detalles)
                {
                    var ar = (from art in db.Articulo
                              where art.Codigo == item.Codigo && art.Activo == true
                              select new { art.MontoIV }).First();


                    _MontoIV += Convert.ToDecimal(ar.MontoIV) * item.Cantidad;

                    _CantidadArticulo += Convert.ToInt32(item.Cantidad);
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
                MessageBox.Show("Hubo un inconveniente al intentar obtener la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //if (bus.First().Existencias==0)
                    //{
                    //    _Existencias++;
                    //}
                    //if (bus.First().Existencias<_Existencias)
                    //{
                    //    MessageBox.Show("No hay suficientes existencias sobre este articulo!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return false;
                    //}
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

        public bool ObtieneProductoActualizar(string id)
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

        public bool ObtieneProducto(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           where x.Activo == true && x.Descripcion.Contains(_Descripcion)
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
                               x.UnidadMedidaId,
                               p.Nombre,
                               f.Descripcion,
                               x.FechaUltimaCompra,
                               x.UtilidadPrecio,
                               x.Id
                           });




                if (bus.Count() > 0)
                {
                    dgv.DataSource = null;

                    foreach (var item in bus)
                    {
                        if (_TipoPrecio == 1)
                        {
                            dgv.Rows.Add(item.Codigo.ToString(),
                                    item.Articulo.ToString(),
                                    item.PrecioIVU,
                                    item.Existencias.ToString(),
                                    Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.PrecioIVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                                   _TipoPrecio.ToString()
                                    );
                            //_Precio = bus.First().Precio;
                            //_IV = bus.First().IV;
                            //_PrecioIVA = bus.First().PrecioIVU;
                            //_MontoIV = bus.First().MontoIV;

                        }
                        if (_TipoPrecio == 2)
                        {

                            dgv.Rows.Add(item.Codigo.ToString(),
                                    item.Articulo.ToString(),
                                    item.Precio2IVU.ToString(),
                                    item.Existencias.ToString(),
                                    Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.Precio2IVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                                   _TipoPrecio.ToString()
                                    );
                            //_Precio = bus.First().Precio2;
                            //_IV = bus.First().IVPrecio2;
                            //_PrecioIVA = bus.First().Precio2IVU;
                            //_MontoIV = bus.First().MontoIV2;
                        }

                        if (_TipoPrecio == 3)//consulta desde inventario
                        {

                            dgv.Rows.Add(item.Id,
                            item.Codigo,
                                    item.Articulo.ToString(),
                                    item.Nombre,
                                    1,
                                    item.Descripcion,
                                    1,
                                    item.Existencias,
                                    item.FechaUltimaCompra,
                                    item.Precio,
                                    item.IV,
                                    item.UtilidadPrecio,
                                      item.PrecioIVU
                                    );
                            //_Precio = bus.First().Precio2;
                            //_IV = bus.First().IVPrecio2;
                            //_PrecioIVA = bus.First().Precio2IVU;
                            //_MontoIV = bus.First().MontoIV2;
                        }
                    }
                    //_Codigo = bus.First().Codigo;
                    //_Descripcion = bus.First().Articulo;
                    //_UnidadMedidaId = bus.First().UnidadMedidaId;

                    //if (_TipoPrecio == 1)
                    //{
                    //    _Precio = bus.First().Precio;
                    //    _IV = bus.First().IV;
                    //    _PrecioIVA = bus.First().PrecioIVU;
                    //    _MontoIV = bus.First().MontoIV;

                    //}
                    //if (_TipoPrecio == 2)
                    //{
                    //    _Precio = bus.First().Precio2;
                    //    _IV = bus.First().IVPrecio2;
                    //    _PrecioIVA = bus.First().Precio2IVU;
                    //    _MontoIV = bus.First().MontoIV2;
                    //}
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public bool ObtieneProductoCompras(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           where x.Activo == true && x.Descripcion.Contains(_Descripcion) && x.ProveedorId == _ProveedorId
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
                    foreach (var item in bus)
                    {
                        if (_TipoPrecio == 1)
                        {
                            dgv.Rows.Add(item.Codigo.ToString(),
                                    item.Articulo.ToString(),
                                    item.PrecioIVU.ToString(),
                                    item.Existencias.ToString(),
                                    Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.PrecioIVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                                   _TipoPrecio.ToString()
                                    );
                            //_Precio = bus.First().Precio;
                            //_IV = bus.First().IV;
                            //_PrecioIVA = bus.First().PrecioIVU;
                            //_MontoIV = bus.First().MontoIV;

                        }
                        if (_TipoPrecio == 2)
                        {

                            dgv.Rows.Add(item.Codigo.ToString(),
                                    item.Articulo.ToString(),
                                    item.Precio2IVU.ToString(),
                                    item.Existencias.ToString(),
                                    Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.Precio2IVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                                   _TipoPrecio.ToString()
                                    );
                            //_Precio = bus.First().Precio2;
                            //_IV = bus.First().IVPrecio2;
                            //_PrecioIVA = bus.First().Precio2IVU;
                            //_MontoIV = bus.First().MontoIV2;
                        }


                    }
                }
                else
                {
                    return false;
                }
                //if (bus.Count() > 0)
                //{
                //    _Codigo = bus.First().Codigo;
                //    _Descripcion = bus.First().Articulo;
                //    _UnidadMedidaId = bus.First().UnidadMedidaId;

                //    if (_TipoPrecio == 1)
                //    {
                //        _Precio = bus.First().Precio;
                //        _IV = bus.First().IV;
                //        _PrecioIVA = bus.First().PrecioIVU;
                //        _MontoIV = bus.First().MontoIV;

                //    }
                //    if (_TipoPrecio == 2)
                //    {
                //        _Precio = bus.First().Precio2;
                //        _IV = bus.First().IVPrecio2;
                //        _PrecioIVA = bus.First().Precio2IVU;
                //        _MontoIV = bus.First().MontoIV2;
                //    }
                //}
                //else
                //{
                //    return false;
                //}
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

        public void IngresaNotaCredito(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.NotaEncabezado _NewNotaEncabezado = new PuntoVentaDAL.NotaEncabezado();

                _NewNotaEncabezado.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                _NewNotaEncabezado.Hora = DateTime.Now.ToShortTimeString();
                _NewNotaEncabezado.Total = _TotalFactura;
                _NewNotaEncabezado.Descuento = _Descuento;
                _NewNotaEncabezado.Impuesto = _Impuesto;
                _NewNotaEncabezado.Subtotal = _Subtotal;

                _NewNotaEncabezado.ClienteId = _ClienteId;

                _NewNotaEncabezado.UsuarioId = LoginUsuario;
                _NewNotaEncabezado.Activo = true;

                _NewNotaEncabezado.FacturaId = _FacturaId;

                db.NotaEncabezados.InsertOnSubmit(_NewNotaEncabezado);

                db.SubmitChanges();

                var bus = (from f in db.NotaEncabezados
                           orderby f.Id descending
                           select f).First();

                _FacturaId = bus.Id;

                this.IngresaDetalleNotaCredito(LoginUsuario);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaEncabezadoNotaCredito(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                foreach (string item in LArticulo)
                {
                    string[] temp = item.Split(';');

                    var detalle = (from x in db.FacturaEncabezado
                                   join fd in db.FacturaDetalles on x.Id equals fd.FacturaId
                                   where x.Id == _FacturaId && fd.CodigoArticulo == temp[0]
                                   select fd);

                    if (detalle.Count()==0)
                    {
                        MessageBox.Show("Los Articulo no coinciden con los de la factura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                PuntoVentaDAL.NotaEncabezado _NewNotaEncabezado = new PuntoVentaDAL.NotaEncabezado();

                _NewNotaEncabezado.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                _NewNotaEncabezado.Hora = DateTime.Now.ToShortTimeString();
                _NewNotaEncabezado.Total = _TotalFactura;
                _NewNotaEncabezado.Descuento = _Descuento;
                _NewNotaEncabezado.Impuesto = _Impuesto;
                _NewNotaEncabezado.Subtotal = _Subtotal;

                _NewNotaEncabezado.ClienteId = _ClienteId;

                _NewNotaEncabezado.UsuarioId = LoginUsuario;
                _NewNotaEncabezado.Activo = true;

                _NewNotaEncabezado.FacturaId = _FacturaId;

                db.NotaEncabezados.InsertOnSubmit(_NewNotaEncabezado);

                db.SubmitChanges();


                //elimino el monto del total de la factura
                var factura = (from x in db.FacturaEncabezado
                               where x.Id == _FacturaId
                               select x).First();

                factura.Total -= _TotalFactura;

                factura.Descuento -= _Descuento;
                factura.Impuesto -= _Impuesto;
                factura.Subtotal -= _Subtotal;

                db.SubmitChanges();

                
                foreach (string item in LArticulo)
                {
                    string[] temp = item.Split(';');

                    var detalle = (from x in db.FacturaEncabezado
                                   join fd in db.FacturaDetalles on x.Id equals fd.FacturaId
                                   where x.Id == _FacturaId && fd.CodigoArticulo == temp[0]
                                   select fd).First();

                    db.FacturaDetalles.DeleteOnSubmit(detalle);

                    db.SubmitChanges();
                }

                var bus = (from f in db.NotaEncabezados
                           orderby f.Id descending
                           select f).First();

                _FacturaId = bus.Id;

                this.IngresaDetalleNotaCredito(LoginUsuario);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaDetalleNotaCredito(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                foreach (string item in LArticulo)
                {
                    string[] temp = item.Split(';');

                    PuntoVentaDAL.NotaDetalle _NewNotaDetalle = new PuntoVentaDAL.NotaDetalle();
                    _NewNotaDetalle.CodigoArticulo = temp[0];
                    _NewNotaDetalle.Cantidad = Convert.ToDecimal(temp[1]);
                    _NewNotaDetalle.Precio = Convert.ToDecimal(temp[2]);
                    _NewNotaDetalle.PorcDescuento = Convert.ToDecimal(temp[3]);
                    _NewNotaDetalle.Descuento = Convert.ToDecimal(temp[4]);
                    _NewNotaDetalle.TotalIVA = Convert.ToDecimal(temp[5]);
                    _NewNotaDetalle.NotaId = _FacturaId;

                    db.NotaDetalles.InsertOnSubmit(_NewNotaDetalle);

                    db.SubmitChanges();

                    var bus = (from x in db.Articulo
                               where x.Codigo == temp[0]
                               select x).First();

                    bus.Existencias += Convert.ToDecimal(temp[1]);

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void AumentoSaldoCliente()
        {
            try
            {
                this.OpenConn();

                var cliente = (from c in db.Clientes
                               where c.Activo == true && c.Id == _ClienteId
                               select c);

                cliente.First().Saldo += _TotalFactura;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void PagoEnEfectivoNotaCredito(int LoginUsuario)
        {
            try
            {
                this.OpenConn();


                var equipo = (from x in db.Equipos
                              where x.NombreEquipo == System.Environment.MachineName.ToString()
                              select x).First();

                var bus = (from x in db.CajaDiarias
                           //join e in db.Equipos on x.EquipoId equals e.Id
                           //where x.Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()) && e.NombreEquipo == System.Environment.MachineName.ToString()
                           where x.EquipoId==equipo.Id
                           orderby x.Id descending
                           select new { x.Saldo, x.Hora }).First();


                PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                _NewCajaDiaria.MovimientoId = 7;
                _NewCajaDiaria.ComprobanteId = Convert.ToInt64(_FacturaId);
                _NewCajaDiaria.Descripcion = "Devolución en efectivo de nota de crédito: "+_FacturaId.ToString();
                _NewCajaDiaria.Monto = _TotalFactura;
                _NewCajaDiaria.Saldo = bus.Saldo - _TotalFactura;
                _NewCajaDiaria.UsuarioId = LoginUsuario;
                _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                _NewCajaDiaria.Hora = (System.DateTime.Now.ToShortTimeString());
                _NewCajaDiaria.EquipoId = equipo.Id;
                _NewCajaDiaria.Activo = true;
                _NewCajaDiaria.Visible = true;

                db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                db.SubmitChanges();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ElminaNotaCredito2()
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.NotaEncabezados
                           orderby f.Id descending
                           select f).First();

                //_FacturaId = bus.Id;

                //var notadetalle = from pe in db.NotaDetalles
                //                  where pe.NotaId == _FacturaId
                //                  select pe;

                //foreach (var item in notadetalle)
                //{
                //    db.NotaDetalles.DeleteOnSubmit(item);

                //    db.SubmitChanges();
                //}

                //var notabus = (from x in db.NotaEncabezados
                //               where x.Id == _FacturaId
                //               select x).First();


                //db.NotaEncabezados.DeleteOnSubmit(notabus);

                bus.Activo = false;

                db.SubmitChanges();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                this.CloseConn();
            }

        }

        public bool EliminaNotaCredito()
        {
            try
            {
                this.OpenConn();

                var detalle = from pe in db.NotaDetalles
                              where pe.NotaId == _Id
                              select pe;                

                foreach (var item in detalle)
                {
                    var art = (from a in db.Articulo
                               where a.Activo == true && a.Codigo == item.CodigoArticulo
                               select a).First();

                    art.Existencias -= item.Cantidad;

                    db.SubmitChanges();



                    PuntoVentaDAL.FacturaDetalle _newFacturaDetalle = new PuntoVentaDAL.FacturaDetalle();
                    _newFacturaDetalle.CodigoArticulo = item.CodigoArticulo;
                    _newFacturaDetalle.Cantidad = item.Cantidad;
                    _newFacturaDetalle.Precio = item.Precio;
                    _newFacturaDetalle.PorcDescuento = item.PorcDescuento;
                    _newFacturaDetalle.Descuento = item.Descuento;
                    _newFacturaDetalle.TotalIVA = item.TotalIVA;
                    _newFacturaDetalle.FacturaId = _FacturaId;

                    db.FacturaDetalles.InsertOnSubmit(_newFacturaDetalle);

                    db.SubmitChanges();

                }

                foreach (var item in detalle)
                {

                    db.NotaDetalles.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }

                var bus = (from x in db.NotaEncabezados
                           where // x.Activo == true &&
                           x.FacturaId == _FacturaId
                           select x).First();






                //sumo el monto del total de la factura de nota a la factura original
                var factura = (from x in db.FacturaEncabezado
                               where x.Id == _FacturaId
                               select x).First();

                factura.Total += bus.Total;

                factura.Descuento += bus.Descuento;
                factura.Impuesto += bus.Impuesto;
                factura.Subtotal += bus.Subtotal;

                db.SubmitChanges();





                //verifico si en caja diaria esta nota de credito fue a contado o credito para rebajar el monto de credito
                var cajaDiariaefectivo = (from cd in db.CajaDiarias
                                          where  cd.ComprobanteId == _Id && cd.MovimientoId == 7 && cd.FacturaId==null //cd.Activo == true &&
                                          select cd);

                if (cajaDiariaefectivo.Count()>0)//hay elementos de devolucion en efectivo
                {
                    db.CajaDiarias.DeleteOnSubmit(cajaDiariaefectivo.First());
                }
                else//devolucion de nota de credito fue a credito por lo que rebajo el credito del cliente
                {
                    var cliente = (from c in db.Clientes
                                   where c.Activo == true && c.Id == bus.ClienteId
                                   select c).First();

                    cliente.Saldo -= bus.Total;
                    
                    db.SubmitChanges();
                }
                db.NotaEncabezados.DeleteOnSubmit(bus);

                db.SubmitChanges();





            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
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
