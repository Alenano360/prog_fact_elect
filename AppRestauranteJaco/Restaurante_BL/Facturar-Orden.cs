using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.Drawing;

namespace Restaurante_BL
{
    public class Facturar_Orden
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades

        private decimal _Propina;

        public decimal Propina
        {
            get { return _Propina; }
            set { _Propina = value; }
        }
        

        private int _MesaId;

        public int MesaId
        {
            get { return _MesaId; }
            set { _MesaId = value; }
        }

        private Int64 _Factura;

        public Int64 Factura
        {
            get { return _Factura; }
            set { _Factura = value; }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private Int64 _CodigoArticulo;

        public Int64 CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
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

        private decimal _Recibido2;

        public decimal Recibido2
        {
            get { return _Recibido2; }
            set { _Recibido2 = value; }
        }
        private decimal _Cambio;

        public decimal Cambio
        {
            get { return _Cambio; }
            set { _Cambio = value; }
        }

        private int _ClienteId;

        public int ClienteId
        {
            get { return _ClienteId; }
            set { _ClienteId = value; }
        }

        private int _ProveedorId;

        public int ProveedorId
        {
            get { return _ProveedorId; }
            set { _ProveedorId = value; }
        }

        private int _TipoPago;

        public int TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }

        private int _TipoPago2;

        public int TipoPago2
        {
            get { return _TipoPago2; }
            set { _TipoPago2 = value; }
        }

        private int _UsuarioId;

        public int UsuarioId
        {
            get { return _UsuarioId; }
            set { _UsuarioId = value; }
        }

        public List<string> Articulos = new List<string>();
        
        #endregion

        #region Metodos

        public void ObtengoMesasDisponibles(Button btn)
        {
            try
            {
                this.OpenConn();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener los licores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtengoConsumoActualXPagar(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                //var bus = from tc in db.TemporalConsumo
                //          join sf in db.Articulos on tc.CodigoArticulo equals sf.Id
                //          where tc.Mesa_Silla == _MesaId
                //          select new { tc.CodigoArticulo, tc.Cantidad, Descripcion = sf.Nombre, Precio = String.Format("{0:0.00}", (tc.Cantidad * sf.Costo)), Pagar = "Pagar" };

                var bus = from x in db.ObtieneConsumoMesas
                          where x.Mesa_Silla == _MesaId
                          select x;

                dgv.Columns[0].Visible = true;

                dgv.AutoGenerateColumns = false;
                dgv.DataSource = bus;

                dgv.Columns[0].Visible = false;

                var fact = (from f in db.FacturaEncabezado
                            orderby f.Id descending
                            select new { Id = (f.Id + 1) });

                if (fact.Count() == 0)
                {
                    _Factura = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["FacturaInicioDefault"].ToString());
                }
                else
                {
                    _Factura = fact.First().Id;
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener el consumo actual: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresoFacturaEncabezado()
        {
            try
            {
                this.OpenConn();

                Restaurante_DAL.FacturaEncabezado _NewFacturaEncabezado = new Restaurante_DAL.FacturaEncabezado();
                _NewFacturaEncabezado.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                _NewFacturaEncabezado.Hora = System.DateTime.Now.ToShortTimeString();
                _NewFacturaEncabezado.Total = Convert.ToDecimal(this._Total);
                _NewFacturaEncabezado.Descuento = Convert.ToDecimal(this._Descuento);
                _NewFacturaEncabezado.Recibido = Convert.ToDecimal(this._Recibido);
                _NewFacturaEncabezado.Cambio = Convert.ToDecimal(this._Cambio);
                _NewFacturaEncabezado.ClienteId = Convert.ToInt32(this._ClienteId);
                _NewFacturaEncabezado.TipoPago = Convert.ToInt32(this._TipoPago);
                _NewFacturaEncabezado.Activo = true;
                _NewFacturaEncabezado.UsuarioId = Convert.ToInt32(this._UsuarioId);
                _NewFacturaEncabezado.MesaId = Convert.ToInt32(this._MesaId);
                _NewFacturaEncabezado.Propina = Convert.ToDecimal(this._Propina);

                db.FacturaEncabezado.InsertOnSubmit(_NewFacturaEncabezado);

                db.SubmitChanges();

                var bus = (from f in db.FacturaEncabezado
                           orderby f.Id descending
                           select f).First();

                _Factura = bus.Id;

                this.IngresaDetalleFactura();


                //Restaurante_DAL.FacturaEncabezado _NewFacturaEncabezado = new Restaurante_DAL.Factura_Encabezado();
                //_NewFacturaEncabezado.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                //_NewFacturaEncabezado.Hora = System.DateTime.Now.ToShortTimeString();
                //_NewFacturaEncabezado.MesaId = _MesaId;
                //_NewFacturaEncabezado.Total = _Total;
                //_NewFacturaEncabezado.UsuarioId = _UsuarioId;


                //Restaurante_DAL.FacturaDetalle _NewFacturaDetalle = new Restaurante_DAL.Factura_Detalle();
                //_NewFacturaDetalle.FacturaId = _Factura;
                //_NewFacturaDetalle.CodigoArticulo = _SubFamiliaId;
                //_NewFacturaDetalle.Precio = _Precio;


                //db.FacturaEncabezado.InsertOnSubmit(_NewFacturaEncabezado);

                //db.SubmitChanges();

                //var bus = (from f in db.FacturaEncabezado
                //           orderby f.Id descending
                //           select f).First();

                //_Factura = bus.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar registrar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaDetalleFactura()
        {
            try
            {
                this.OpenConn();

                foreach (string item in Articulos)
                {
                    string[] temp = item.Split(';');

                    Restaurante_DAL.FacturaDetalle _NewFacturaDetalle = new Restaurante_DAL.FacturaDetalle();
                    _NewFacturaDetalle.CodigoArticulo = Convert.ToInt64(temp[0]);
                    _NewFacturaDetalle.Cantidad = Convert.ToDecimal(temp[1]);
                    _NewFacturaDetalle.Precio = Convert.ToDecimal(temp[2]);
                    _NewFacturaDetalle.FacturaId = _Factura;

                    db.FacturaDetalle.InsertOnSubmit(_NewFacturaDetalle);

                    db.SubmitChanges();

                    var bus = (from x in db.Articulo
                               where x.Id == Convert.ToInt64(temp[0])
                               select x).First();

                    if (bus.Inventariado==true)//licores o platillos(carnes, pescados)
                    {
                        bus.Existencias -= Convert.ToInt32(temp[1]);
                    }

                    db.SubmitChanges();
                }

                this.IngresaCajaDiaria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar registrar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresaCajaDiaria()
        {
            try
            {
                this.OpenConn();


                var equipo = (from x in db.Equipos
                              where x.NombreEquipo == System.Environment.MachineName.ToString()
                              select x).First();

                var bus = (from x in db.CajaDiarias
                           join e in db.Equipos on x.EquipoId equals e.Id
                           where e.NombreEquipo == System.Environment.MachineName.ToString()
                           orderby x.Id descending
                           select new { x.Saldo, e.Id, x.Hora }).First();


                //_TipoPago==3//pago a credito // no hay caja diaria

               // MessageBox.Show("Comprobar con que vamos a pagar");
                if (TipoPago == 2)//efectivo
                {
                 //   MessageBox.Show("Con efectivo");
                    Restaurante_DAL.CajaDiaria _NewCajaDiaria = new Restaurante_DAL.CajaDiaria();

                    _NewCajaDiaria.MovimientoId = 2;//venta
                    _NewCajaDiaria.Descripcion = "Venta efectivo Factura Nº: " + _Factura;
                    _NewCajaDiaria.ComprobanteId = _Factura;

                //    _NewCajaDiaria.Monto = _Recibido;

                    _NewCajaDiaria.Monto = _Recibido-_Cambio;
                //    MessageBox.Show("recibido " + Recibido+" y recibido dos "+_Recibido2);
                 //   MessageBox.Show("el monto es " + _NewCajaDiaria.Monto);
                //    _NewCajaDiaria.Saldo = bus.Saldo + _Recibido;
                    _NewCajaDiaria.Saldo = (bus.Saldo + _NewCajaDiaria.Monto);
                 //   MessageBox.Show("El nuevo saldo es de " + (_NewCajaDiaria.Saldo-_Cambio).ToString());
                    _NewCajaDiaria.UsuarioId = _UsuarioId;
                    _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                    _NewCajaDiaria.EquipoId = bus.Id;
                    _NewCajaDiaria.Activo = true;
                    _NewCajaDiaria.Visible = true;

                    db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                    db.SubmitChanges();

                }

                bus = (from x in db.CajaDiarias
                           join e in db.Equipos on x.EquipoId equals e.Id
                           where e.NombreEquipo == System.Environment.MachineName.ToString()
                           orderby x.Id descending
                           select new { x.Saldo, e.Id, x.Hora }).First();

                if (TipoPago2 == 1)//tarjeta crédito
                {
                  //  MessageBox.Show("Con tarjeta de credito");
                    Restaurante_DAL.CajaDiaria _NewCajaDiaria = new Restaurante_DAL.CajaDiaria();

                    _NewCajaDiaria.MovimientoId = 2;//venta
                    _NewCajaDiaria.Descripcion = "Venta tarjeta de crédito Factura Nº: " + _Factura;
                    _NewCajaDiaria.ComprobanteId = _Factura;
                    _NewCajaDiaria.Monto = _Recibido2;
                    _NewCajaDiaria.Saldo = bus.Saldo + _Recibido2;
                    _NewCajaDiaria.UsuarioId = _UsuarioId;
                    _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                    _NewCajaDiaria.EquipoId = bus.Id;
                    _NewCajaDiaria.Activo = true;
                    _NewCajaDiaria.Visible = true;

                    db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                    db.SubmitChanges();

                }

                 bus = (from x in db.CajaDiarias
                           join e in db.Equipos on x.EquipoId equals e.Id
                           where e.NombreEquipo == System.Environment.MachineName.ToString()
                           orderby x.Id descending
                           select new { x.Saldo, e.Id, x.Hora }).First();

                if (_TipoPago == 3)//credito credito
                {
                  //  MessageBox.Show("Con creditoooo");
                    Restaurante_DAL.CajaDiaria _NewCajaDiaria = new Restaurante_DAL.CajaDiaria();

                    _NewCajaDiaria.MovimientoId = 2;//
                    _NewCajaDiaria.Descripcion = "Venta a crédito al cliente Factura Nº: " + _Factura;
                    _NewCajaDiaria.ComprobanteId = _Factura;
                    //_NewCajaDiaria.FacturaId = _Factura;

                    _NewCajaDiaria.Monto = 0;
                    _NewCajaDiaria.Saldo = bus.Saldo;

                    _NewCajaDiaria.UsuarioId = _UsuarioId;
                    _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                    _NewCajaDiaria.EquipoId = bus.Id;
                    _NewCajaDiaria.Activo = true;
                    _NewCajaDiaria.Visible = true;


                 //   MessageBox.Show("El nuevo saldo es de " + _NewCajaDiaria.Saldo);
                 //   MessageBox.Show("el monto es " + _NewCajaDiaria.Monto);

                    db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                    db.SubmitChanges();
                }

                 bus = (from x in db.CajaDiarias
                           join e in db.Equipos on x.EquipoId equals e.Id
                           where e.NombreEquipo == System.Environment.MachineName.ToString()
                           orderby x.Id descending
                           select new { x.Saldo, e.Id, x.Hora }).First();

                if (_TipoPago == 0)//compra
                {
                  //  MessageBox.Show("Con compra");
                    Restaurante_DAL.CajaDiaria _NewCajaDiaria = new Restaurante_DAL.CajaDiaria();

                    _NewCajaDiaria.MovimientoId = 3;//compra
                    //_NewCajaDiaria.Descripcion = "Compra Factura Nº:" + _ComprobanteId;
                    //_NewCajaDiaria.ComprobanteId = _FacturaId;
                    //_NewCajaDiaria.FacturaId = _ComprobanteId;

                    //if (_CompraCheque == true)
                    //{
                    //    _NewCajaDiaria.Monto = 0;
                    //    _NewCajaDiaria.Saldo = bus.Saldo;
                    //}
                    //else
                    //{
                    //    _NewCajaDiaria.Monto = Convert.ToDecimal(_Total);
                    //    _NewCajaDiaria.Saldo = bus.Saldo - _Total;
                    //}


                    _NewCajaDiaria.UsuarioId = _UsuarioId;
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

        public void EliminoTemporalConsumo()
        {
            try
            {
                this.OpenConn();

                var bus = (from tc in db.TemporalConsumo
                           where tc.Mesa_Silla == _MesaId && tc.CodigoArticulo == _CodigoArticulo //&& tc.Cantidad == _Cantidad
                           select tc).First();

                int control=0;

                while (_Cantidad>0)//mientras el valor de cantidad no sea cero
                {
                    if (bus.Cantidad<_Cantidad)
                    {
                        _Cantidad -= bus.Cantidad;
                        db.TemporalConsumo.DeleteOnSubmit(bus);
                        db.SubmitChanges();

                        bus = (from tc in db.TemporalConsumo
                                   where tc.Mesa_Silla == _MesaId && tc.CodigoArticulo == _CodigoArticulo //&& tc.Cantidad == _Cantidad
                                   select tc).First();
                    }

                    if (bus.Cantidad>=_Cantidad)
                    {
                        bus.Cantidad -= _Cantidad;
                        _Cantidad = 0;

                        if (bus.Cantidad==0)
                        {
                            db.TemporalConsumo.DeleteOnSubmit(bus);                         
                        }
                        db.SubmitChanges();   
                    }
                }

                //var bus = (from x in db.ObtieneConsumoMesas
                //           where x.Mesa_Silla == _MesaId && x.CodigoArticulo == _CodigoArticulo
                //           select new { x.Cantidad }).First();

                //bus.Cantidad -= _Cantidad;
                
                //db.TemporalConsumo.DeleteOnSubmit(bus);

                //db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el consumo temporal: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
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

        #endregion
    }
}
