using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PuntoVentaDAL;

namespace PuntoVentaBL
{
    public class Facturar
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades
        private bool _TipoPago2;

        public bool TipoPago2
        {
            get { return _TipoPago2; }
            set { _TipoPago2 = value; }
        }

        private decimal _RecibidoTipoPago1;

        public decimal RecibidoTipoPago1
        {
            get { return _RecibidoTipoPago1; }
            set { _RecibidoTipoPago1 = value; }
        }

        private decimal _RecibidoTipoPago2;

        public decimal RecibidoTipoPago2
        {
            get { return _RecibidoTipoPago2; }
            set { _RecibidoTipoPago2 = value; }
        }

        private bool _TipoPago3;

        public bool TipoPago3
        {
            get { return _TipoPago3; }
            set { _TipoPago3 = value; }
        }

        private decimal _RecibidoTipoPago3;

        public decimal RecibidoTipoPago3
        {
            get { return _RecibidoTipoPago3; }
            set { _RecibidoTipoPago3 = value; }
        }

        private bool _TipoPago4;

        public bool TipoPago4
        {
            get { return _TipoPago4; }
            set { _TipoPago4 = value; }
        }

        private decimal _RecibidoTipoPago4;

        public decimal RecibidoTipoPago4
        {
            get { return _RecibidoTipoPago4; }
            set { _RecibidoTipoPago4 = value; }
        }

//        TipoPago2 bit;//tarjetacredito
//RecibidoTipoPago2 decimal (18,2)

//TipoPago3 bit;//notascredito
//RecibidoTipoPago3 decimal (18,2)

//TipoPago4 bit;//credito
//RecibidoTipoPago4 decimal (18,2)

        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
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
        
        public List<string> Articulos = new List<string>();

        private string _Codigo;

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        private string _Codigo2;

        public string Codigo2
        {
            get { return _Codigo2; }
            set { _Codigo2 = value; }
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

        private  bool _Activo2;
        public bool Activo2
        {
            get { return _Activo2; }
            set { _Activo2 = value; }
        }

        private string _NumTarjeta;
        public string NumTarjeta
        {
            get { return _NumTarjeta; }
            set { _NumTarjeta = value; }
        }
        #endregion

        #region Metodos

        public bool ObtieneProductoCodigo(string id)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           where x.Activo == true && x.Codigo == id || x.Codigo2==id
                           orderby x.Descripcion ascending
                           select new
                           {
                               x.Codigo,
                               x.Codigo2,
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
                    _Codigo2 = bus.First().Codigo2;
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

        public bool ObtieneProducto(string id)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           //where x.Activo == true && x.Codigo.Contains(id)
                           where x.Activo == true && x.Codigo == id || x.Codigo2==id
                           orderby x.Descripcion ascending
                           select new
                           {
                               x.Codigo,
                               x.Codigo2,
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
                    _Codigo2 = bus.First().Codigo2;
                    _Descripcion = bus.First().Articulo;
                    _UnidadMedidaId = bus.First().UnidadMedidaId;
                    _Existencias = bus.First().Existencias;

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

        public bool ObtieneProducto(string id, DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           where x.Activo == true && x.Codigo.Contains(id)||x.Codigo2.Contains(id)
                           orderby x.Descripcion ascending
                           select new
                           {
                               x.Codigo,
                               x.Codigo2,
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
                    //MessageBox.Show(_Existencias.ToString(), "ob2", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    _Codigo2 = bus.First().Codigo2;
                    _Descripcion = bus.First().Articulo;
                    _UnidadMedidaId = bus.First().UnidadMedidaId;







                    if (_TipoPrecio == 1)
                    {
                        _Precio = bus.First().Precio;
                        _IV = bus.First().IV;
                        _PrecioIVA = bus.First().PrecioIVU;
                        _MontoIV = bus.First().MontoIV;


                        foreach (var item in bus)
                        {
                            double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(item.PrecioIVU) * 1), 0, MidpointRounding.AwayFromZero);

                            totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                            dgv.Rows.Add(item.Codigo.ToString(),
                  item.Articulo.ToString(),
                  item.PrecioIVU.ToString(),
                  item.Existencias.ToString(),

                 totaliva,
                  _TipoPrecio.ToString()
                  );
                        }
                    }
                    if (_TipoPrecio == 2)
                    {
                        _Precio = bus.First().Precio2;
                        _IV = bus.First().IVPrecio2;
                        _PrecioIVA = bus.First().Precio2IVU;
                        _MontoIV = bus.First().MontoIV2;

                        foreach (var item in bus)
                        {
                            double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(item.Precio2IVU) * 1), 0, MidpointRounding.AwayFromZero);

                            totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                            dgv.Rows.Add(item.Codigo.ToString(),
                  item.Articulo.ToString(),
                  item.Precio2IVU.ToString(),
                  item.Existencias.ToString(),
                  totaliva,
                  _TipoPrecio.ToString()
                  );
                        }
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
                           where x.Activo == true && x.Codigo == id||x.Codigo2==id
                           orderby x.Descripcion ascending
                           select new
                           {
                               x.Codigo,
                               x.Codigo2,
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
                    MessageBox.Show(_Existencias.ToString(), "Actual", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool ObtieneProductoId(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           where x.Activo == true && x.Codigo.Contains(_Descripcion) || x.Codigo2.Contains(_Descripcion)
                           orderby x.Descripcion ascending
                           select new
                           {
                               x.Codigo,
                               x.Codigo2,
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
                               x.Id,
                               x.Ubicacion.Ubicacion1,
                               Observacion = (x.Observacion == null ? "" : x.Observacion)
                           });




                if (bus.Count() > 0)
                {
                    dgv.DataSource = null;

                    //dgv.Columns[0].Visible = true;
                    //dgv.Columns[4].Visible = true;
                    //dgv.Columns[6].Visible = true;


                    foreach (var item in bus)
                    {
                        if (_TipoPrecio == 1)
                        {
                            dgv.Rows.Add(item.Codigo.ToString(),
                                         
                                    item.Articulo.ToString(),
                                    item.PrecioIVU,
                                    item.Existencias.ToString(),
                                 //   Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.PrecioIVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                                  Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.PrecioIVU.ToString())),2),
                                   _TipoPrecio.ToString(), item.Observacion,item.Codigo2.ToString()
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
                                 //   Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.Precio2IVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                                  Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.Precio2IVU.ToString())), 2),
                                   _TipoPrecio.ToString(), item.Observacion, item.Codigo2.ToString()
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
                                    item.Ubicacion1,
                                    1,
                                    item.Existencias,
                                    item.FechaUltimaCompra,
                                    item.Precio,
                                    item.IV,
                                    item.UtilidadPrecio,
                                      item.PrecioIVU, item.Observacion, item.Codigo2.ToString()
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

                    //dgv.Columns[0].Visible = false;
                    //dgv.Columns[4].Visible = false;
                    //dgv.Columns[6].Visible = false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("000Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                           where x.Activo == true && (x.Descripcion.Contains(_Descripcion) || x.Codigo == (_Descripcion)|| x.Codigo2 == (_Descripcion))
                           orderby x.Descripcion ascending
                           select new
                           {
                               x.Codigo,
                               x.Codigo2,
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
                               x.Id,
                               x.Ubicacion.Ubicacion1,
                               Observacion = (x.Observacion == null ? "" : x.Observacion)
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
                                  //  Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.PrecioIVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                                  Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.PrecioIVU.ToString())), 2),
                                   _TipoPrecio.ToString(), item.Observacion,item.Codigo2.ToString()
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
                                   // Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.Precio2IVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                                  Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.Precio2IVU.ToString())), 2),
                                    _TipoPrecio.ToString(), item.Observacion,item.Codigo2.ToString()
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
                                    item.Ubicacion1,
                                    1,
                                    item.Existencias,
                                    item.FechaUltimaCompra,
                                    item.Precio,
                                    item.IV,
                                    item.UtilidadPrecio,
                                      item.PrecioIVU, item.Observacion,item.Codigo2
                                    );
                            //_Precio = bus.First().Precio2;
                            //_IV = bus.First().IVPrecio2;
                            //_PrecioIVA = bus.First().Precio2IVU;
                            //_MontoIV = bus.First().MontoIV2;
                        }
                    }
                    _Codigo = bus.First().Codigo;
                    _Codigo2 = bus.First().Codigo2;
                    _Descripcion = bus.First().Articulo;
                    _UnidadMedidaId = bus.First().UnidadMedidaId;

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
                           where x.Activo == true && x.Descripcion.Contains(_Descripcion)
                           orderby x.Descripcion ascending
                           select new
                           {
                               x.Codigo,
                               x.Codigo2,
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
                                //    Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.PrecioIVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                                   Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.PrecioIVU.ToString())), 2),
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
                                //    Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.Precio2IVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                                   Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.Precio2IVU.ToString())), 2),
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

        public void IngresaEncabezadoFacturaParcial(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.FacturaEncabezado _NewFacturaEncabezado = new PuntoVentaDAL.FacturaEncabezado();

                _NewFacturaEncabezado.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                _NewFacturaEncabezado.Hora = DateTime.Now.ToShortTimeString();
                _NewFacturaEncabezado.Total = _TotalFactura;
                _NewFacturaEncabezado.Descuento = _Descuento;
                _NewFacturaEncabezado.Recibido = _Recibido;
                _NewFacturaEncabezado.Cambio = _Cambio;
                _NewFacturaEncabezado.TipoPago = _TipoPago;
                _NewFacturaEncabezado.Impuesto = _Impuesto;
                _NewFacturaEncabezado.Subtotal = _Subtotal;

                if (_ProveedorId != 0)
                {
                    _NewFacturaEncabezado.ProveedorId = _ProveedorId;
                }
                else
                {
                    _NewFacturaEncabezado.ClienteId = _ClienteId;
                }

                _NewFacturaEncabezado.UsuarioId = LoginUsuario;
                _NewFacturaEncabezado.Activo = true;
                _NewFacturaEncabezado.Activo2 = true;

                db.FacturaEncabezado.InsertOnSubmit(_NewFacturaEncabezado);


                db.SubmitChanges();

                var bus = (from f in db.FacturaEncabezado
                           orderby f.Id descending
                           select f).First();

                _FacturaId = bus.Id;

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

        public void IngresaEncabezadoFactura(int LoginUsuario)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.FacturaEncabezado _NewFacturaEncabezado = new PuntoVentaDAL.FacturaEncabezado();

                if (_ProveedorId != 0)//compra
                {
                    _NewFacturaEncabezado.Fecha = Convert.ToDateTime(_Fecha.ToShortDateString());
                    _NewFacturaEncabezado.Hora = _Fecha.ToShortTimeString();
                }
                else
                {
                    _NewFacturaEncabezado.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    _NewFacturaEncabezado.Hora = DateTime.Now.ToShortTimeString();
                }

                _NewFacturaEncabezado.Total = _TotalFactura;
                _NewFacturaEncabezado.Descuento = _Descuento;
                _NewFacturaEncabezado.Recibido = _Recibido;
                _NewFacturaEncabezado.Cambio = _Cambio;
                //_NewFacturaEncabezado.TipoPago = _TipoPago;
                _NewFacturaEncabezado.TipoPago = _TipoPago;
                //efectivo

                //        TipoPago2 bit;//tarjetacredito
                //RecibidoTipoPago2 decimal (18,2)

                //TipoPago3 bit;//notascredito
                //RecibidoTipoPago3 decimal (18,2)

                //TipoPago4 bit;//credito
                //RecibidoTipoPago4 decimal (18,2)

                _NewFacturaEncabezado.TipoPago2 = _TipoPago2;
                _NewFacturaEncabezado.TipoPago3 = _TipoPago3;
                _NewFacturaEncabezado.TipoPago4 = _TipoPago4;

                _NewFacturaEncabezado.RecibidoTipoPago2 = _RecibidoTipoPago2;
                _NewFacturaEncabezado.RecibidoTipoPago3 = _RecibidoTipoPago3;
                _NewFacturaEncabezado.RecibidoTipoPago4 = _RecibidoTipoPago4;



                _NewFacturaEncabezado.Impuesto = _Impuesto;
                _NewFacturaEncabezado.Subtotal = _Subtotal;

                if (_ProveedorId != 0)
                {
                    _NewFacturaEncabezado.ProveedorId = _ProveedorId;//compra
                }
                else
                {
                    _NewFacturaEncabezado.ClienteId = _ClienteId;
                }

                _NewFacturaEncabezado.UsuarioId = LoginUsuario;
                _NewFacturaEncabezado.Activo = true;
                _NewFacturaEncabezado.Activo2 = true;
                _NewFacturaEncabezado.NumTarjeta=_NumTarjeta;
                db.FacturaEncabezado.InsertOnSubmit(_NewFacturaEncabezado);

                db.SubmitChanges();

                var bus = (from f in db.FacturaEncabezado
                           orderby f.Id descending
                           select f).First();

                _FacturaId = bus.Id;

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
            try
            {
                this.OpenConn();

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    PuntoVentaDAL.FacturaDetalle _NewFacturaDetalle = new PuntoVentaDAL.FacturaDetalle();
                    _NewFacturaDetalle.CodigoArticulo = temp[0];
                    _NewFacturaDetalle.Precio = Convert.ToDecimal(temp[1]);
                    _NewFacturaDetalle.Cantidad = Convert.ToDecimal(temp[2]);
                    _NewFacturaDetalle.PorcDescuento = Convert.ToDecimal(temp[3]);
                    _NewFacturaDetalle.Descuento = Convert.ToDecimal(temp[4]);
                    _NewFacturaDetalle.TotalIVA = Convert.ToDecimal(temp[5]);
                    _NewFacturaDetalle.FacturaId = _FacturaId;

                    db.FacturaDetalles.InsertOnSubmit(_NewFacturaDetalle);

                    db.SubmitChanges();

                    var bus = (from x in db.Articulo
                               where x.Codigo == temp[0]
                               select x).First();

                    // if (_TipoPago==0)
                    //{
                    //  bus.Existencias += Convert.ToDecimal(temp[2]);
                    //}
                    //else
                    //{
                    bus.Existencias -= Convert.ToDecimal(temp[2]);
                    //}


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

                //        TipoPago2 bit;//tarjetacredito
                //RecibidoTipoPago2 decimal (18,2)

                //TipoPago3 bit;//notascredito
                //RecibidoTipoPago3 decimal (18,2)

                //TipoPago4 bit;//credito
                //RecibidoTipoPago4 decimal (18,2)

                //_NewFacturaEncabezado.TipoPago2 = _TipoPago2;
                //_NewFacturaEncabezado.TipoPago3 = _TipoPago3;
                //_NewFacturaEncabezado.TipoPago4 = _TipoPago4;

                //_NewFacturaEncabezado.RecibidoTipoPago2 = _RecibidoTipoPago2;
                //_NewFacturaEncabezado.RecibidoTipoPago3 = _RecibidoTipoPago3;
                //_NewFacturaEncabezado.RecibidoTipoPago4 = _RecibidoTipoPago4;
                //_Recibido
                if (_RecibidoTipoPago1 > 0)//efectivo
                {
                    PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();

                    _NewCajaDiaria.MovimientoId = 2;//
                    _NewCajaDiaria.Descripcion = "Venta efectivo Factura Nº: " + _FacturaId;
                    _NewCajaDiaria.ComprobanteId = _FacturaId;
                    _NewCajaDiaria.FacturaId = _ComprobanteId.ToString();

                    _NewCajaDiaria.Monto = _RecibidoTipoPago1 - _Cambio;
                    _NewCajaDiaria.Saldo = bus.Saldo + (_RecibidoTipoPago1 - _Cambio);

                    _NewCajaDiaria.UsuarioId = LoginUsuario;
                    _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                    _NewCajaDiaria.EquipoId = bus.Id;
                    _NewCajaDiaria.Activo = true;
                    _NewCajaDiaria.Visible = true;

                    db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                    db.SubmitChanges();
                }
                bus = (from cd in db.CajaDiarias
                       join e in db.Equipos on cd.EquipoId equals e.Id
                       //x.Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()) &&
                       where e.NombreEquipo == System.Environment.MachineName.ToString()
                       && cd.Activo == true && cd.Visible == true
                       orderby cd.Id descending
                       select new { cd.Saldo, e.Id, cd.Hora }).First();

                if (_RecibidoTipoPago2 > 0)//tarjetacredito
                {
                    PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();

                    _NewCajaDiaria.MovimientoId = 2;//
                    _NewCajaDiaria.Descripcion = "Venta tarjeta de crédito Factura Nº: " + _FacturaId+" "+"tarjeta #"+_NumTarjeta.ToString();
                    
                    _NewCajaDiaria.ComprobanteId = _FacturaId;
                    _NewCajaDiaria.FacturaId = _ComprobanteId.ToString();

                    _NewCajaDiaria.Monto = _RecibidoTipoPago2;
                    _NewCajaDiaria.Saldo = bus.Saldo + _RecibidoTipoPago2;

                    _NewCajaDiaria.UsuarioId = LoginUsuario;
                    _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                    _NewCajaDiaria.EquipoId = bus.Id;
                    _NewCajaDiaria.Activo = true;
                    _NewCajaDiaria.Visible = true;

                    db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                    db.SubmitChanges();
                }
                bus = (from cd in db.CajaDiarias
                       join e in db.Equipos on cd.EquipoId equals e.Id
                       //x.Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()) &&
                       where e.NombreEquipo == System.Environment.MachineName.ToString()
                       && cd.Activo == true && cd.Visible == true
                       orderby cd.Id descending
                       select new { cd.Saldo, e.Id, cd.Hora }).First();

                if (_RecibidoTipoPago3 > 0)//nota de credito
                {
                    PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();

                    _NewCajaDiaria.MovimientoId = 2;//
                    _NewCajaDiaria.Descripcion = "Venta en notas de crédito Factura Nº: " + _FacturaId;
                    _NewCajaDiaria.ComprobanteId = _FacturaId;
                    _NewCajaDiaria.FacturaId = _ComprobanteId.ToString();

                    _NewCajaDiaria.Monto = _RecibidoTipoPago3 - _RecibidoTipoPago3;
                    _NewCajaDiaria.Saldo = bus.Saldo + _RecibidoTipoPago3;

                    _NewCajaDiaria.UsuarioId = LoginUsuario;
                    _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                    _NewCajaDiaria.EquipoId = bus.Id;
                    _NewCajaDiaria.Activo = true;
                    _NewCajaDiaria.Visible = true;

                    db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                    db.SubmitChanges();
                }

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

        //public void IngresaCajaDiaria(int LoginUsuario)
        //{
        //    try
        //    {
        //        this.OpenConn();


        //        var equipo = (from x in db.Equipos
        //                      where x.NombreEquipo == System.Environment.MachineName.ToString()
        //                      select x).First();

        //        var bus = (from cd in db.CajaDiarias
        //                   join e in db.Equipos on cd.EquipoId equals e.Id
        //                   //x.Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()) &&
        //                   where  e.NombreEquipo == System.Environment.MachineName.ToString()
        //                   && cd.Activo == true && cd.Visible == true
        //                   orderby cd.Id descending
        //                   select new { cd.Saldo,e.Id,cd.Hora}).First();


        //        //_TipoPago==3//pago a credito // no hay caja diaria

        //        if (_TipoPago==1||_TipoPago==2)//tarjeta credito
        //        {
        //            PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();

        //            _NewCajaDiaria.MovimientoId = 2;//venta
        //            _NewCajaDiaria.Descripcion = "Venta efectivo Factura Nº: "+_FacturaId;
        //            _NewCajaDiaria.ComprobanteId = _FacturaId;

        //            if (_TipoPago==2)//efectivo
        //            {
        //                if (_Recibido < _TotalFactura)//quedo debiendo
        //                {
        //                    _NewCajaDiaria.Monto = _Recibido;
        //                    _NewCajaDiaria.Saldo = bus.Saldo + _Recibido;
        //                }
        //                else
        //                {
        //                    _NewCajaDiaria.Monto = _TotalFactura;
        //                    _NewCajaDiaria.Saldo = bus.Saldo + _TotalFactura;
        //                }   
        //            }
        //            if (_TipoPago==1)//tarjeta credito
        //            {
        //                _NewCajaDiaria.Monto = _TotalFactura;
        //                _NewCajaDiaria.Saldo = bus.Saldo + _TotalFactura;
        //                _NewCajaDiaria.Descripcion = "Venta tarjeta de crédito Factura Nº: " + _FacturaId;

        //            }


        //            _NewCajaDiaria.UsuarioId = LoginUsuario;
        //            _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
        //            _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
        //            _NewCajaDiaria.EquipoId = bus.Id;
        //            _NewCajaDiaria.Activo = true;
        //            _NewCajaDiaria.Visible = true;

        //            db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

        //            db.SubmitChanges();
        //        }
        //        if (_TipoPago == 3)//credito credito
        //        {
        //            //PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();

        //            //_NewCajaDiaria.MovimientoId = 2;//
        //            //_NewCajaDiaria.Descripcion = "Venta a crédito al cliente Factura Nº: " + _FacturaId;
        //            //_NewCajaDiaria.ComprobanteId = _FacturaId;
        //            //_NewCajaDiaria.FacturaId = _ComprobanteId.ToString();

        //            //_NewCajaDiaria.Monto = 0;
        //            //_NewCajaDiaria.Saldo = bus.Saldo;

        //            //_NewCajaDiaria.UsuarioId = LoginUsuario;
        //            //_NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
        //            //_NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
        //            //_NewCajaDiaria.EquipoId = bus.Id;
        //            //_NewCajaDiaria.Activo = true;
        //            //_NewCajaDiaria.Visible = true;

        //            //db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

        //            //db.SubmitChanges();
        //        }
        //        if (_TipoPago == 0)//compra
        //        {
        //            PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();

        //            _NewCajaDiaria.MovimientoId = 3;//compra
        //            _NewCajaDiaria.Descripcion = "Compra Factura Nº:" +_ComprobanteId;
        //            _NewCajaDiaria.ComprobanteId =_FacturaId;
        //            _NewCajaDiaria.FacturaId = _ComprobanteId.ToString();

        //            if (_CompraCheque==true)
        //            {
        //                _NewCajaDiaria.Monto = 0;
        //                _NewCajaDiaria.Saldo = bus.Saldo;
        //            }
        //            else
        //            {
        //                _NewCajaDiaria.Monto = Convert.ToDecimal(_TotalFactura);
        //                _NewCajaDiaria.Saldo = bus.Saldo - _TotalFactura;
        //            }


        //            _NewCajaDiaria.UsuarioId = LoginUsuario;
        //            _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
        //            _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
        //            _NewCajaDiaria.EquipoId = bus.Id;

        //            if (_CompraCheque == true)
        //            {
        //                _NewCajaDiaria.Activo = false;
        //                _NewCajaDiaria.Visible = false;
        //            }
        //            else
        //            {
        //                _NewCajaDiaria.Activo = true;
        //                _NewCajaDiaria.Visible = true;
        //            }

        //            db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);
        //            db.SubmitChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al intentar ingresar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        this.CloseConn();
        //    }
        //}

        public bool ObtieneProductoCompras(string id)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           where x.Activo == true && x.Codigo.Contains(id) && x.ProveedorId == _ProveedorId ||x.Codigo2.Contains(id)
                           orderby x.Descripcion ascending
                           select new
                           {
                               x.Codigo,
                               x.Codigo2,
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
                    _Codigo2 = bus.First().Codigo2;
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

        public bool ObtieneProductoCompras(string id, DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           where x.Activo == true && x.Codigo.Contains(id)||x.Codigo2.Contains(id)
                           
                           orderby x.Descripcion ascending
                           select new
                           {
                               x.Codigo,
                               x.Codigo2,
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
                    _Codigo2 = bus.First().Codigo2;
                    _Descripcion = bus.First().Articulo;
                    _UnidadMedidaId = bus.First().UnidadMedidaId;

                    if (_TipoPrecio == 1)
                    {
                        _Precio = bus.First().Precio;
                        _IV = bus.First().IV;
                        _PrecioIVA = bus.First().PrecioIVU;
                        _MontoIV = bus.First().MontoIV;

                        foreach (var item in bus)
                        {
                            dgv.Rows.Add(item.Codigo.ToString(),
                  item.Articulo.ToString(),
                  item.PrecioIVU.ToString(),
                  item.Existencias.ToString(),
                  Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.PrecioIVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                  _TipoPrecio.ToString()
                  );
                        }
                    }
                    if (_TipoPrecio == 2)
                    {
                        _Precio = bus.First().Precio2;
                        _IV = bus.First().IVPrecio2;
                        _PrecioIVA = bus.First().Precio2IVU;
                        _MontoIV = bus.First().MontoIV2;


                        foreach (var item in bus)
                        {
                            dgv.Rows.Add(item.Codigo.ToString(),
                  item.Articulo.ToString(),
                  item.Precio2IVU.ToString(),
                  item.Existencias.ToString(),
                  Math.Round(Convert.ToDecimal(Convert.ToDecimal(item.Precio2IVU.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                  _TipoPrecio.ToString()
                  );
                        }
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
        public void ObtieneHistoricoPagos(String Nombre, String apellidos, DataGridView dgv)
        {
            int filas=0;
            try
            {
                this.OpenConn();
                int id;
                long id_apartado;

                var bus= (from c in db.Clientes
                          where (c.Nombre == Nombre) && (c.Apellidos == apellidos)
                          select c).First();
                id = bus.Id;
               

                var bus2 = (from z in db.ApartadoEncabezados
                            where z.ClienteId == id
                            select z).First();
                id_apartado = bus2.Id;
              

               var  historial = (from r in db.ApartadoHistoricoAbonos
                                 where r.ApartadoId == id_apartado
                                 select new
                                 {
                                        r.Fecha,
                                        r.Monto
                                    
                                  
                                 }
                                   );


               filas = historial.Count();
               
                if (historial.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = historial;
                }

                this.CloseConn();

            }
            catch (Exception x) {
                if (filas > 0)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar obtener el historial: " + x.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Este usuario no tiene ni un pago registrado en el historial");
                
                }
        
        }
        public void ObtieneFacturaCliente(int id, DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.FacturaEncabezado
                           orderby f.Fecha
                           where f.ClienteId == id &&
                                 f.TipoPago == 3 &&
                                 f.Activo == true &&
                                 (f.Activo2 == true || f.Activo2 == null)
                           select new
                           {
                               f.Id,
                               f.Fecha,
                               f.Total
                           });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las facturas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool ActualizaEstadoFactura(Int64 Id, int IdCliente)
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.FacturaEncabezado
                           where f.Id == Id &&
                                 f.ClienteId == IdCliente &&
                                 f.TipoPago == 3 &&
                                 f.Activo == true &&
                                 (f.Activo2 == true || f.Activo2 == null)
                           select f).First();
                bus.Activo2 = false;
                bus.Activo = true;
                bus.NumTarjeta = "";
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool AnulaFactura(int IdCliente)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.FacturasAnuladas _Anular = new PuntoVentaDAL.FacturasAnuladas();

                _Anular.FacturaEncabezado = _FacturaId;
                _Anular.FechaAnulacion = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                _Anular.Hora = Convert.ToString(DateTime.Now.ToString("hh:mm:ss"));
               
                

                db.FacturasAnuladas.InsertOnSubmit(_Anular);
               

                db.SubmitChanges();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
