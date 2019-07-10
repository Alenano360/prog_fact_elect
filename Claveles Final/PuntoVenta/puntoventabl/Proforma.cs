using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Proforma
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades
        private string _Cajero;

        public string Cajero
        {
            get { return _Cajero; }
            set { _Cajero = value; }
        }
        
        private string _VigenciaOferta;

        public string VigenciaOferta
        {
            get { return _VigenciaOferta; }
            set { _VigenciaOferta = value; }
        }

        private string _AtencionA;

        public string AtencionA
        {
            get { return _AtencionA; }
            set { _AtencionA = value; }
        }

        private string _CondicionPago;

        public string CondicionPago
        {
            get { return _CondicionPago; }
            set { _CondicionPago = value; }
        }

        private string _TiempoEntrega;

        public string TiempoEntrega
        {
            get { return _TiempoEntrega; }
            set { _TiempoEntrega = value; }
        }

        private string _Comentarios;

        public string Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private decimal _Impuesto;

        public decimal Impuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
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
        

        private int  _CantidadLineas;

        public int CantidadLineas
        {
            get { return _CantidadLineas; }
            set { _CantidadLineas = value; }
        }

        private int _CantidadArticulos;

        public int CantidadArticulos
        {
            get { return _CantidadArticulos; }
            set { _CantidadArticulos = value; }
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

        public List<string> LArticulos = new List<string>();

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

        private bool _IV;

        public bool IV
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

        public void ObtieneProformas(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from pro in db.ProformaEncabezados
                           join c in db.Clientes on pro.ClienteId equals c.Id into ps from c in ps.DefaultIfEmpty()
                           join u in db.Usuarios on pro.UsuarioId equals u.Id into pu from u in pu.DefaultIfEmpty()
                           where pro.Activo == true
                           select new
                           {
                               pro.Id,
                               Cliente = c.Nombre + " " + (c.Apellidos == null ? "" : c.Apellidos),
                               Fecha=(pro.Fecha.ToShortDateString()),
                               Fecha1=pro.Fecha,
                               pro.Hora,
                               Total=(pro.Total.ToString()),
                               Usuario = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido),
                               userid=u.Id,
                               descuento=(pro.Descuento==null?Convert.ToDecimal("0.00"):pro.Descuento),
                               impuesto = (pro.Impuesto == null ? Convert.ToDecimal("0.00") : pro.Impuesto)
                           });

                if (_SBusqueda!=null)
                {
                    bus = from x in bus
                          where x.Id.ToString().Contains(_SBusqueda) || x.Cliente.Contains(_SBusqueda) || x.Total.ToString().Contains(_SBusqueda)
                          || x.Usuario.Contains(_SBusqueda)
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

                if (bus.Count()>0)
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

        public void ObtieneDetalleProforma(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from fd in db.ProformaDetalles
                           join a in db.Articulo on fd.CodigoArticulo equals a.Codigo
                           where fd.ProformaId == _ComprobanteId
                           select new { fd.CodigoArticulo, Articulo = a.Descripcion, fd.Cantidad, fd.Precio, fd.TotalIVA, Descuento = fd.PorcDescuento });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                var bus1 = (from fd in db.ProformaEncabezados
                            join u in db.Usuarios on fd.UsuarioId equals u.Id
                           where fd.Id == _ComprobanteId
                           select new { fd.Subtotal,nombre=u.Nombre+" "+(u.Apellido==null?"":u.Apellido) }).First();

                _Subtotal = Convert.ToDecimal(bus1.Subtotal);
                _Cajero = bus1.nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle de la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool MostrarProforma(DataGridView dgv, Int64 ProformaId)
        {
            try
            {
                this.OpenConn();

                var encabezado = (from pe in db.ProformaEncabezados
                               where pe.Id == ProformaId && pe.Activo == true
                               select new { pe.Total,
                                   pe.Descuento,
                               pe.ClienteId}).First();

                var detalles = from pe in db.ProformaEncabezados
                          join pd in db.ProformaDetalles on pe.Id equals pd.ProformaId
                          join a in db.Articulo on pd.CodigoArticulo equals a.Codigo
                          where pe.Id == ProformaId && pe.Activo == true
                               select new { Codigo = (pd.CodigoArticulo), a.Descripcion, pd.Precio, pd.Cantidad, pd.PorcDescuento, pd.Descuento, pd.TotalIVA,a.IV };

                
                _ClienteId = Convert.ToInt32(encabezado.ClienteId);
                _TotalFactura = Convert.ToDecimal(encabezado.Total.ToString("F"));
                _Descuento = Convert.ToDecimal(Convert.ToDecimal(encabezado.Descuento).ToString("F"));

                _CantidadLineas = 0;
                _CantidadArticulos = 0;
                _MontoIV = 0;
                //_PorcDesc = Convert.ToDecimal(Convert.ToDecimal(encabezado.PorcDesc).ToString("F"));

                dgv.AutoGenerateColumns = false;

                foreach (var item in detalles)
                {
                    var ar = (from art in db.Articulo
                              where art.Codigo == item.Codigo && art.Activo == true
                              select new { art.MontoIV }).First();


                    _MontoIV += Convert.ToDecimal(ar.MontoIV)*item.Cantidad;

                    _CantidadArticulos += Convert.ToInt32(item.Cantidad);
                    _CantidadLineas++;

                    dgv.Rows.Insert(0, item.Codigo,
                       item.Descripcion.ToString(),
                        item.Precio.ToString(),
                        item.Cantidad.ToString(),
                        item.PorcDescuento,
                        item.Descuento,
                        item.TotalIVA.ToString(),
                        1,
                        item.IV
                        );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        _IV = bus.First().IVPrecio2;
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
                        _IV = bus.First().IVPrecio2;
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
                               IV = (x.IV == true ? "SI" : "NO"),
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

        public void IngresaEncabezadoProforma(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.ProformaEncabezado _NewFacturaEncabezado = new PuntoVentaDAL.ProformaEncabezado();

                _NewFacturaEncabezado.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                _NewFacturaEncabezado.Hora = DateTime.Now.ToShortTimeString();
                _NewFacturaEncabezado.Total = _TotalFactura;
                _NewFacturaEncabezado.Descuento = _Descuento;
                _NewFacturaEncabezado.Recibido = _Recibido;
                _NewFacturaEncabezado.Cambio = _Cambio;
                _NewFacturaEncabezado.Impuesto = _Impuesto;
                _NewFacturaEncabezado.Subtotal = _Subtotal;

                _NewFacturaEncabezado.ClienteId = _ClienteId;

                _NewFacturaEncabezado.UsuarioId = LoginUsuario;
                _NewFacturaEncabezado.Activo = true;

                db.ProformaEncabezados.InsertOnSubmit(_NewFacturaEncabezado);

                db.SubmitChanges();

                var bus = (from f in db.ProformaEncabezados
                           orderby f.Id descending
                           select f).First();

                _FacturaId = bus.Id;

                this.IngresaDetalleProforma(LoginUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ModificaEncabezadoProforma()
        {
            try
            {
                this.OpenConn();

                var encabezado = (from x in db.ProformaEncabezados
                                  where x.Activo == true && x.Id == _Id
                                  select x).First();

                encabezado.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                encabezado.Hora = DateTime.Now.ToShortTimeString();
                encabezado.Total = _TotalFactura;
                encabezado.Descuento = _Descuento;
                encabezado.Recibido = _Recibido;
                encabezado.Cambio = _Cambio;
                encabezado.Impuesto = _Impuesto;
                encabezado.Subtotal = _Subtotal;

                encabezado.ClienteId = _ClienteId;

                encabezado.Activo = true;

                db.SubmitChanges();

                var bus = (from f in db.ProformaEncabezados
                           orderby f.Id descending
                           select f).First();

                _FacturaId = _Id;

                this.ModificaDetalleProforma();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaDetalleProforma(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                foreach (string item in LArticulos)
                {
                    string[] temp = item.Split(';');

                    PuntoVentaDAL.ProformaDetalle _NewFacturaDetalle = new PuntoVentaDAL.ProformaDetalle();
                    _NewFacturaDetalle.CodigoArticulo = temp[0];
                    _NewFacturaDetalle.Cantidad = Convert.ToDecimal(temp[1]);
                    _NewFacturaDetalle.Precio = Convert.ToDecimal(temp[2]);
                    _NewFacturaDetalle.PorcDescuento = Convert.ToDecimal(temp[3]);
                    _NewFacturaDetalle.Descuento = Convert.ToDecimal(temp[4]);
                    _NewFacturaDetalle.TotalIVA  = Convert.ToDecimal(temp[5]);
                    _NewFacturaDetalle.ProformaId = _FacturaId;

                    db.ProformaDetalles.InsertOnSubmit(_NewFacturaDetalle);

                    db.SubmitChanges();

                    var bus = (from x in db.Articulo
                               where x.Codigo == temp[0]
                               select x).First();

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ModificaDetalleProforma()
        {
            try
            {
                this.OpenConn();

                var del = (from x in db.ProformaDetalles
                           where x.ProformaId == _Id
                           select x);

                foreach (var item in del)
                {
                    db.ProformaDetalles.DeleteOnSubmit(item);
                }

                db.SubmitChanges();

                
                foreach (string item in LArticulos)
                {
                    string[] temp = item.Split(';');

                    PuntoVentaDAL.ProformaDetalle _NewFacturaDetalle = new PuntoVentaDAL.ProformaDetalle();
                    _NewFacturaDetalle.CodigoArticulo = temp[0];
                    _NewFacturaDetalle.Cantidad = Convert.ToDecimal(temp[1]);
                    _NewFacturaDetalle.Precio = Convert.ToDecimal(temp[2]);
                    _NewFacturaDetalle.PorcDescuento = Convert.ToDecimal(temp[3]);
                    _NewFacturaDetalle.Descuento = Convert.ToDecimal(temp[4]);
                    _NewFacturaDetalle.TotalIVA = Convert.ToDecimal(temp[5]);
                    _NewFacturaDetalle.ProformaId = _FacturaId;

                    db.ProformaDetalles.InsertOnSubmit(_NewFacturaDetalle);

                    db.SubmitChanges();

                    var bus = (from x in db.Articulo
                               where x.Codigo == temp[0]
                               select x).First();

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool EliminaProforma()
        {
            try
            {
                this.OpenConn();

                var detalle = from pe in db.ProformaDetalles
                              where pe.ProformaId == _Id
                              select pe;

                foreach (var item in detalle)
                {
                    db.ProformaDetalles.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }

                var bus = (from x in db.ProformaEncabezados
                           where x.Activo == true && x.Id == _Id
                           select x).First();

                db.ProformaEncabezados.DeleteOnSubmit(bus);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public void InsertaAnexo()
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.Proforma_Anexo _newProformaAnexo = new PuntoVentaDAL.Proforma_Anexo();
                _newProformaAnexo.ProformaId = Id;
                _newProformaAnexo.VigenciaOferta = _VigenciaOferta;
                _newProformaAnexo.AtencionA = _AtencionA;
                _newProformaAnexo.CondicionPago = _CondicionPago;
                _newProformaAnexo.TiempoEntrega = _TiempoEntrega;
                _newProformaAnexo.Comentarios = _Comentarios;

                db.Proforma_Anexos.InsertOnSubmit(_newProformaAnexo);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
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
