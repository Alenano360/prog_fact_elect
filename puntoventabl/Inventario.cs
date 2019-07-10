using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Inventario
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades

        private Int64 _Id;

        public Int64 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private Boolean _Consignacion;

        public Boolean Consignacion
        {
            get { return _Consignacion; }
            set { _Consignacion = value; }
        }
        
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

        private decimal _Gram;

        public decimal Gram
        {
            get { return _Gram; }
            set { _Gram = value; }
        }

        private decimal _precioxGram;

        public decimal precioxGram
        {
            get { return _precioxGram; }
            set { _precioxGram = value; }
        }


        private decimal _precioxGram2;

        public decimal precioxGram2
        {
            get { return _precioxGram2; }
            set { _precioxGram2 = value; }
        }


        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _ProveedorId;

        public int ProveedorId
        {
            get { return _ProveedorId; }
            set { _ProveedorId = value; }
        }

        private int _UbicacionId;

        public int UbicacionId
        {
            get { return _UbicacionId; }
            set { _UbicacionId = value; }
        }
        

        private int _FamiliaId;

        public int FamiliaId
        {
            get { return _FamiliaId; }
            set { _FamiliaId = value; }
        }

        private decimal _Existencias;

        public decimal Existencias
        {
            get { return _Existencias; }
            set { _Existencias = value; }
        }

        private DateTime _FechaUltimaCompra;

        public DateTime FechaUltimaCompra
        {
            get { return _FechaUltimaCompra; }
            set { _FechaUltimaCompra = value; }
        }

        private decimal _PorcImpVentas;

        public decimal PorcImpVentas
        {
            get { return _PorcImpVentas; }
            set { _PorcImpVentas = value; }
        }


        private decimal _Compra;

        public decimal Compra
        {
            get { return _Compra; }
            set { _Compra = value; }
        }

        private decimal _Precio;

        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
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


        private decimal _UtilidadPrecio;

        public decimal UtilidadPrecio
        {
            get { return _UtilidadPrecio; }
            set { _UtilidadPrecio = value; }
        }        

        private decimal _PrecioIVU;

        public decimal PrecioIVU
        {
            get { return _PrecioIVU; }
            set { _PrecioIVU = value; }
        }

        private decimal _Precio2;

        public decimal Precio2
        {
            get { return _Precio2; }
            set { _Precio2 = value; }
        }

        private bool _IVPrecio2;

        public bool IVPrecio2
        {
            get { return _IVPrecio2; }
            set { _IVPrecio2 = value; }
        }


        private decimal _MontoIV2;

        public decimal MontoIV2
        {
            get { return _MontoIV2; }
            set { _MontoIV2 = value; }
        }

        private decimal _UtilidadPrecio2;

        public decimal UtilidadPrecio2
        {
            get { return _UtilidadPrecio2; }
            set { _UtilidadPrecio2 = value; }
        }        

        private decimal _Precio2IVU;

        public decimal Precio2IVU
        {
            get { return _Precio2IVU; }
            set { _Precio2IVU = value; }
        }

        private int _UnidadMedidaId;

        public int UnidadMedidaId
        {
            get { return _UnidadMedidaId; }
            set { _UnidadMedidaId = value; }
        }

        private string _Observacion;

        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }

        #endregion

        #region Metodos

        public void ObtieneInventario(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                dgv.Columns[0].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[6].Visible = false;

                var bus = (from x in db.Articulo
                           join i in db.IVA on x.IV equals i.Id
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           join u in db.Ubicacions on x.UbicacionId equals u.Id into ps from u in ps.DefaultIfEmpty()
                           where x.Activo == true
                           select new {u.Ubicacion1,
                                       x.UbicacionId,
                                       x.Id, 
                                       x.Codigo,
                                       x.Codigo2,
                                       Articulo=x.Descripcion,
                                       x.ProveedorId,
                                       Proveedor=p.Nombre,
                                       x.FamiliaId,
                                       Familia=f.Descripcion,
                                       x.Existencias,
                                       x.FechaUltimaCompra,
                                       x.Precio,
                                       x.UtilidadPrecio,
                                       IV=x.PorcIV,
                                       x.PrecioIVU,
                                       Observacion = (x.Observacion == null ? "" : x.Observacion) });

                if (bus.Count()>0)
                {
                    dgv.AutoGenerateColumns = false;   
                    dgv.DataSource = bus;                                     
                }

                dgv.Columns[0].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneProductoInventario(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                dgv.Rows.Clear();

                dgv.Columns[0].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[6].Visible = false;

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           join u in db.Ubicacions on x.UbicacionId equals u.Id into ps
                           from u in ps.DefaultIfEmpty()
                           where x.Activo == true && x.Codigo ==_Descripcion
                           select new
                           {
                               u.Ubicacion1,
                               x.UbicacionId,
                               x.Id,
                               x.Codigo,
                               x.Codigo2,
                               x.PorcIV,
                               Articulo = x.Descripcion,
                               x.ProveedorId,
                               Proveedor = p.Nombre,
                               x.FamiliaId,
                               Familia = f.Descripcion,
                               x.Existencias,
                               x.FechaUltimaCompra, 
                                x.Precio, x.UtilidadPrecio, x.IV , x.PrecioIVU ,
                               x.Precio2,
                               x.UtilidadPrecio2,
                               IV2 = x.IVPrecio2,
                               x.Precio2IVU,
                               Observacion = (x.Observacion == null ? "" : x.Observacion)
                           });

                dgv.AutoGenerateColumns = false;
                dgv.DataSource = bus;
                if (bus.Count() > 0)
                {

                    _Id = bus.First().Id;
                    _Codigo = bus.First().Codigo;
                    _Codigo2 = bus.First().Codigo2;
                    _Descripcion = bus.First().Articulo;
                    _ProveedorId = Convert.ToInt32(bus.First().ProveedorId);
                    _FamiliaId = Convert.ToInt32(bus.First().FamiliaId);
                    _UbicacionId = Convert.ToInt32(bus.First().UbicacionId);
                    _Existencias = bus.First().Existencias;
                    _FechaUltimaCompra = Convert.ToDateTime(bus.First().FechaUltimaCompra);
                    _PorcImpVentas = bus.First().PorcIV;
                    _Precio = bus.First().Precio;
                    _IV = bus.First().IV;
                    _UtilidadPrecio = bus.First().UtilidadPrecio;
                    _PrecioIVU = bus.First().PrecioIVU;

                    _Precio2 = bus.First().Precio2;
                    _IVPrecio2 = bus.First().IV2;
                    _UtilidadPrecio2 = bus.First().UtilidadPrecio2;
                    _Precio2IVU = bus.First().Precio2IVU;

                    _Observacion = bus.First().Observacion;
                }
                dgv.Columns[0].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneProductoInventarioOrdenada(DataGridView dgv, string Busqueda)
        {
            try
            {
                this.OpenConn();

                dgv.Rows.Clear();

                dgv.Columns[0].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[6].Visible = false;

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           join u in db.Ubicacions on x.UbicacionId equals u.Id into ps
                           from u in ps.DefaultIfEmpty()
                           where x.Activo == true
                           orderby x.Codigo descending
                           select new
                           {
                               u.Ubicacion1,
                               x.UbicacionId,
                               x.Id,
                               x.Codigo,
                               x.Codigo2,
                               Articulo = x.Descripcion,
                               x.ProveedorId,
                               Proveedor = p.Nombre,
                               x.FamiliaId,
                               Familia = f.Descripcion,
                               x.Existencias,
                               x.FechaUltimaCompra,
                               x.Precio,
                               x.UtilidadPrecio,
                               x.IV,
                               x.PrecioIVU,
                               Observacion = (x.Observacion == null ? "" : x.Observacion)
                           });

                switch (Busqueda)
                {
                    case "Codigo":
                        {
                            bus = from x in bus
                                  orderby x.Codigo descending
                                  select x;

                            break;
                        }
                    case "Codigo2":
                        {
                            bus = from x in bus
                                  orderby x.Codigo2 descending
                                  select x;

                            break;
                        }
                    case "Descripcion":
                        {
                            bus = from x in bus
                                  orderby x.Articulo ascending
                                  select x;

                            break;
                        }
                    case "Proveedor":
                        {

                            bus = from x in bus
                                  orderby x.ProveedorId descending
                                  select x;
                            break;
                        }
                    case "Familia":
                        {
                            bus = from x in bus
                                  orderby x.FamiliaId descending
                                  select x;
 
                            break;
                        }
                    case "Existencia":
                        {
                            bus = from x in bus
                                  orderby x.Existencias descending
                                  select x;

                            break;
                        }
                    case "Ultima Compra":
                        {
                            bus = from x in bus
                                  orderby x.FechaUltimaCompra descending
                                  select x;

   
                            break;
                        }

                    
                    case "Precio Final":
                        {
                            bus = from x in bus
                                  orderby x.PrecioIVU descending
                                  select x;
   

                            break;
                        }

                    default:
                        break;
                }

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                dgv.Columns[0].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneProductoModificar(int id)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           where x.Activo == true && x.Id == id
                           select new
                           {
                               x.Id,
                               x.Codigo,
                               x.Codigo2,
                               x.ArtConsignacion,
                               x.PorcIV,
                               Articulo = x.Descripcion,
                               x.ProveedorId,
                               x.UbicacionId,
                               x.FamiliaId,
                               x.Existencias,
                               x.FechaUltimaCompra,
                               x.Precio,
                               x.UtilidadPrecio,
                               x.PrecioIVU,
                               poseeiv = x.IV,
                               x.Precio2,
                               x.UtilidadPrecio2,
                               IV2 = x.IVPrecio2,
                               x.Precio2IVU,
                               x.UnidadMedidaId,
                               x.gram,
                               x.gran_x_precio,
                               x.gran_x_precio2,
                               Observacion = (x.Observacion == null ? "" : x.Observacion)
                               
                           });

                _Id = bus.First().Id;
                _Codigo = bus.First().Codigo;
                _Codigo2 = bus.First().Codigo2;
                _Descripcion = bus.First().Articulo;
                _ProveedorId = bus.First().ProveedorId;
                _FamiliaId = Convert.ToInt32(bus.First().FamiliaId);
                _UbicacionId = Convert.ToInt32(bus.First().UbicacionId);
                _Existencias = bus.First().Existencias;
                _FechaUltimaCompra = Convert.ToDateTime(bus.First().FechaUltimaCompra);
                _PorcImpVentas = bus.First().PorcIV;
                _Precio = bus.First().Precio;
                _Consignacion = Convert.ToBoolean(bus.First().ArtConsignacion);
                _IV = bus.First().poseeiv;
                _UtilidadPrecio = bus.First().UtilidadPrecio;
                _PrecioIVU = bus.First().PrecioIVU;

                _Precio2 = bus.First().Precio2;
                _IVPrecio2 = bus.First().IV2;
                _UtilidadPrecio2 = bus.First().UtilidadPrecio2;
                _Precio2IVU = bus.First().Precio2IVU;
                _UnidadMedidaId = bus.First().UnidadMedidaId;
                _Gram = Convert.ToDecimal(bus.First().gram);
                _precioxGram = Convert.ToDecimal(bus.First().gran_x_precio);
                _precioxGram2 = Convert.ToDecimal(bus.First().gran_x_precio2);

                
                _Observacion = bus.First().Observacion;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool EliminaProducto(DataGridView dgv, int id,int idusuario)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           where x.Id==id
                           select x).First();

                //bus.Activo=false;
                String codigo = bus.Codigo;
                String descripcion = bus.Descripcion;
                db.Articulo.DeleteOnSubmit(bus);

                db.SubmitChanges();
               
                this.ObtieneInventario(dgv);
                this.OpenConn();
                PuntoVentaDAL.BitacoraInventario _NewRegistro = new PuntoVentaDAL.BitacoraInventario();
               // _NewRegistro.cantidadUnidades = Convert.ToInt32(NuevasUnidades);
                _NewRegistro.DescripcionProducto = descripcion;
                _NewRegistro.fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString()); ;
                _NewRegistro.id_MovimientoBitacora = 2;
                _NewRegistro.id_producto = codigo;
                _NewRegistro.idUsuario = idusuario;

                db.BitacoraInventario.InsertOnSubmit(_NewRegistro);
                db.SubmitChanges();
                this.CloseConn();
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

        public bool AgregaArticulo(int IdUsuario)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.Articulo _NewArticulo = new PuntoVentaDAL.Articulo();

                _NewArticulo.Codigo = this._Codigo;
                _NewArticulo.Codigo2 = this._Codigo2;
                _NewArticulo.Descripcion = this._Descripcion;
                _NewArticulo.ProveedorId = this._ProveedorId;
                _NewArticulo.gram = this._Gram;
                _NewArticulo.gran_x_precio = _precioxGram;
                _NewArticulo.gran_x_precio2 = _precioxGram2;
                
                if (this._FamiliaId!=0)
                {
                    _NewArticulo.FamiliaId = this._FamiliaId;
                }

                if (this._UbicacionId!=0)
                {
                    _NewArticulo.UbicacionId = this._UbicacionId;
                }
                
                _NewArticulo.Existencias = this._Existencias;
                _NewArticulo.FechaUltimaCompra = this._FechaUltimaCompra;
                _NewArticulo.PorcIV = this._PorcImpVentas;
                if (_Compra > 0)
                {
                    _NewArticulo.Precio = this._Compra;
                }
                else
                {
                    _NewArticulo.Precio = this._Precio;
                }
                _NewArticulo.ArtConsignacion = this._Consignacion;
                _NewArticulo.IV = this._IV;
                _NewArticulo.MontoIV = this._MontoIV;
                _NewArticulo.UtilidadPrecio = this._UtilidadPrecio;
                _NewArticulo.PrecioIVU = this._PrecioIVU;
                _NewArticulo.Precio2 = this._Precio2;
                _NewArticulo.IVPrecio2 = this._IVPrecio2;
                _NewArticulo.MontoIV2= this._MontoIV2;
                _NewArticulo.UtilidadPrecio2 = this._UtilidadPrecio2;
                _NewArticulo.Precio2IVU = this._Precio2IVU;
                _NewArticulo.UnidadMedidaId = this._UnidadMedidaId;
                _NewArticulo.Activo = true;
                _NewArticulo.Observacion = this._Observacion;

                db.Articulo.InsertOnSubmit(_NewArticulo);

                db.SubmitChanges();

                PuntoVentaDAL.BitacoraInventario _NewRegistro = new PuntoVentaDAL.BitacoraInventario();
            //    _NewRegistro.cantidadUnidades = Convert.ToInt32(NuevasUnidades);
                _NewRegistro.DescripcionProducto = _NewArticulo.Descripcion;
                _NewRegistro.fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString()); ;
                _NewRegistro.id_MovimientoBitacora = 1;
                _NewRegistro.id_producto = _NewArticulo.Codigo;
                _NewRegistro.idUsuario = IdUsuario;

                db.BitacoraInventario.InsertOnSubmit(_NewRegistro);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el artículo al inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool Verificar_Articulo(String id)
        {

            bool respuesta = false;
            try
            {
                this.OpenConn();
               // MessageBox.Show("ANTES DEL QUERY");

                var bus = (from x in db.Articulo
                           where x.Codigo == id
                           select x).First();

             

             //   MessageBox.Show("Despues del query y antes del if");
                if (bus.Codigo == id && bus!=null)
                {
                   // MessageBox.Show("Dentro del if");
                    respuesta = true;

                }
            }
            catch (Exception error)
            {

              //  MessageBox.Show("Hubo un problema " + error.Message);
                this.CloseConn();
                return false;
              //  this.CloseConn();
            }

            this.CloseConn();
            return respuesta;
            
        }

        public bool ModificaArticulo(String NuevasUnidades,int idusuario)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           where x.Activo == true && x.Id == _Id
                           select x).First();

                //bus.Codigo = this._Codigo;
                bus.Codigo2 = this._Codigo2;
                bus.Descripcion = this._Descripcion;
                bus.ProveedorId = this._ProveedorId;

                if (this._FamiliaId != 0)
                {
                    bus.FamiliaId = this._FamiliaId;
                }

                if (this._UbicacionId != 0)
                {
                    bus.UbicacionId = this._UbicacionId;
                }
                               
                bus.Existencias = this._Existencias;
                bus.FechaUltimaCompra = this._FechaUltimaCompra;
                bus.PorcIV = this._PorcImpVentas;
                if (_Compra > 0)
                {
                    bus.Precio = this._Precio;
                }
                else
                {
                    bus.Precio = this._Precio;
                }
               
                bus.ArtConsignacion = this._Consignacion;
                bus.IV = this._IV;
                bus.MontoIV = this._MontoIV;
                bus.UtilidadPrecio = this._UtilidadPrecio;
                bus.PrecioIVU = this._PrecioIVU;
                bus.Precio2 = this._Precio2;
                bus.IVPrecio2 = this._IVPrecio2;
                bus.MontoIV2 = this._MontoIV2;
                bus.UtilidadPrecio2 = this._UtilidadPrecio2;
                bus.Precio2IVU = this._Precio2IVU;
                bus.UnidadMedidaId = this._UnidadMedidaId; 
                bus.Activo = true;
                bus.Observacion = this._Observacion;
                bus.gram = this.Gram;
                bus.gran_x_precio = this.precioxGram;
                bus.gran_x_precio2 = this.precioxGram2;
                db.SubmitChanges();
                if (NuevasUnidades == "")
                {
                    NuevasUnidades = "0";
                }
                PuntoVentaDAL.BitacoraInventario _NewRegistro = new PuntoVentaDAL.BitacoraInventario();
                _NewRegistro.cantidadUnidades = Convert.ToInt32(NuevasUnidades);
                _NewRegistro.DescripcionProducto = bus.Descripcion;
                _NewRegistro.fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());;
                _NewRegistro.id_MovimientoBitacora = 3;
                _NewRegistro.id_producto = bus.Codigo.ToString();
                _NewRegistro.idUsuario = idusuario;

                db.BitacoraInventario.InsertOnSubmit(_NewRegistro);
                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el artículo al inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public void GuardaBitacoraPrecios(int UserId)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.BitacoraPrecio _NewBitacora = new PuntoVentaDAL.BitacoraPrecio();
               
                _NewBitacora.Precio1 = _PrecioIVU;
                _NewBitacora.Precio2 = _Precio2IVU;
                _NewBitacora.UsuarioId = UserId;
                _NewBitacora.CodigoArticulo = _Codigo;
                _NewBitacora.FechaCreacion = System.DateTime.Now;
                _NewBitacora.ProveedorId = _ProveedorId;
                
                db.BitacoraPrecios.InsertOnSubmit(_NewBitacora);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar guarda en la bitácora de precios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool ObtieneProductoInventarioBitacora(string id,decimal precio1,decimal precio2,int pid)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           where x.Codigo == id
                           select new { x.PrecioIVU, x.Precio2IVU, x.ProveedorId });

                if (bus!=null||bus.Count()>0)
                {
                    if (bus.First().PrecioIVU!=precio1||bus.First().Precio2IVU!=precio2||bus.First().ProveedorId!=pid)
                    {
                        return false;
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public void ObtieneProveedores(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from p in db.Proveedors
                           where p.Activo == true
                           select new { p.Id,p.Nombre });

                if (bus.Count() > 0)
                {
                    cmb.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneFamilia(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.Familias
                           where f.Activo == true
                           select new { f.Id, f.Descripcion });

                if (bus.Count() > 0)
                {
                    cmb.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las famlias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void GeneraInventarioReporte(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join p in db.Proveedors on x.ProveedorId equals p.Id
                           join f in db.Familias on x.FamiliaId equals f.Id
                           where x.Activo == true
                           select new { x.Codigo,x.Codigo2, Articulo = x.Descripcion, Proveedor = p.Nombre,  Familia = f.Descripcion, x.Existencias,  x.Precio,
                                        x.PrecioIVU,
                                        x.Precio2,
                                        x.Precio2IVU,
                                        Observacion = (x.Observacion == null ? "" : x.Observacion)
                                       });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUnidadesMedida(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.UnidadMedidas
                           select new { x.Id,x.Descripcion});

                if (bus.Count() > 0)
                {
                    cmb.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las unidades de medida: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUnidadesMedida(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.UnidadMedidas
                           select new { x.Id, x.Descripcion });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las unidades de medida: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUnidadMedidaBusqueda(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                dgv.Columns[0].Visible = true;

                var bus = (from f in db.UnidadMedidas
                           where (f.Descripcion.Contains(_Descripcion))
                           select new { f.Id, f.Descripcion});

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                dgv.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las unidades de medida: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneClienteBusqueda(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                dgv.Columns[0].Visible = true;

                var bus = (from f in db.Clientes
                           where f.Activo==true&&(f.Nombre.Contains(_Descripcion)||f.Apellidos.Contains(_Descripcion)||f.Cedula.Contains(_Descripcion)||f.Contacto.Contains(_Descripcion)||f.Telefono1.Contains(_Descripcion))
                           select f);

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                dgv.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

