using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurante_BL
{
    public class Ventas
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades

        private int _TipoPago;

        public int TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }
        
        private Int64 _ComprobanteId;

        public Int64 ComprobanteId
        {
            get { return _ComprobanteId; }
            set { _ComprobanteId = value; }
        }

        private int _ClienteId;

        public int ClienteId
        {
            get { return _ClienteId; }
            set { _ClienteId = value; }
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

        private string _Descuento;

        public string Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        private string _Recibido;

        public string Recibido
        {
            get { return _Recibido; }
            set { _Recibido = value; }
        }

        private string _Cambio;

        public string Cambio
        {
            get { return _Cambio; }
            set { _Cambio = value; }
        }

        private string _Total;

        public string Total
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

        private int _UsuarioId;

        public int UsuarioId
        {
            get { return _UsuarioId; }
            set { _UsuarioId = value; }
        }

        private int _MesaId;

        public int MesaId
        {
            get { return _MesaId; }
            set { _MesaId = value; }
        }
        

        #endregion

        #region Metodos

        public void ObtieneFacturasVenta(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = from x in db.ObtieneVentas_Vw
                          //join e in db.Equipos on x.EquipoId equals e.Id
                          //join m in db.Movimientos on x.MovimientoId equals m.Id
                          //where x.MovimientoId == 2 && e.NombreEquipo == System.Environment.MachineName.ToString()
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
                MessageBox.Show("Hubo un inconveniente al intentar obtener las facturas de venta: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var bus = (from x in db.FacturaEncabezado
                           where x.Id == ComprobanteId
                           select x).First();

                bus.Activo = false;
                bus.UsuarioId = UserId;

                var caja = (from x in db.CajaDiarias
                            where x.ComprobanteId == ComprobanteId
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

        public void ObtieneFacturaBusqueda(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                //var bus = (from fe in db.FacturaEncabezado
                //           where fe.Activo == true && fe.Id == _ComprobanteId
                //           orderby fe.Id descending
                //           select new { fe.TipoPago, fe.Id, Descuento = fe.Descuento == null ? Convert.ToDecimal("0.00") : fe.Descuento, fe.Total, fe.Fecha, fe.Hora });


                var bus = from x in db.ObtieneVentas_Vw
                          join e in db.Equipos on x.EquipoId equals e.Id
                          join m in db.Movimientos on x.MovimientoId equals m.Id
                          where x.MovimientoId == 2 && e.NombreEquipo == System.Environment.MachineName.ToString() && x.Id == _ComprobanteId
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
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneFacturaCliente(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from fe in db.FacturaEncabezado
                           join c in db.Clientes on fe.ClienteId equals c.Id
                           where fe.Activo == true && fe.ClienteId == _ClienteId
                           orderby fe.Fecha descending
                           select new { fe.TipoPago, fe.Id, Nombre = c.Nombre + " " + (c.Apellidos == null ? "" : c.Apellidos), Descuento = fe.Descuento == null ? Convert.ToDecimal("0.00") : fe.Descuento, fe.Total, fe.Fecha, fe.Hora });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneFacturaFechas(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from fe in db.FacturaEncabezado
                           join c in db.Clientes on fe.ClienteId equals c.Id
                           where fe.Activo == true && _FechaInicio <= fe.Fecha && fe.Fecha <= _FechaFinal
                           orderby fe.Fecha descending
                           select new { fe.TipoPago, fe.Id, Nombre = c.Nombre + " " + (c.Apellidos == null ? "" : c.Apellidos), Descuento = fe.Descuento == null ? Convert.ToDecimal("0.00") : fe.Descuento, fe.Total, fe.Fecha, fe.Hora });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var bus = (from fd in db.FacturaDetalle
                           join a in db.Articulo on fd.CodigoArticulo equals a.Id
                           where fd.FacturaId == _ComprobanteId
                           select new { fd.CodigoArticulo, Articulo = a.Nombre, fd.Cantidad, fd.Precio });

                var bus1 = (from fe in db.FacturaEncabezado
                            where fe.Id == _ComprobanteId
                            select fe).First();

                //var cliente = (from x in db.Clientes
                //               where x.Id == Convert.ToInt32(bus1.ClienteId)
                //               select new { x.Nombre, Apellido = (x.Apellidos == null ? "" : x.Apellidos) }).First();

                var usuario = (from x in db.Usuarios
                               where x.Id == Convert.ToInt32(bus1.UsuarioId)
                               select new { x.Nombre, Apellido = (x.Apellido == null ? "" : x.Apellido) }).First();

                _Fecha = bus1.Fecha.ToShortDateString();
                _Hora = bus1.Hora.ToString();
                _Descuento = bus1.Descuento.ToString();
                _Total = bus1.Total.ToString();
                _Recibido = bus1.Recibido.ToString();
                _Cambio = bus1.Cambio.ToString();

                if (_TipoPago==1)
                {
                    _ClienteNombre = "CLIENTE TARJETA DE CRÉDITO";
                }
                if (_TipoPago == 2)
                {
                    _ClienteNombre = "CLIENTE CONTADO";
                }
                //_ClienteNombre = cliente.Nombre + " " + cliente.Apellido;

                _CajeroNombre = usuario.Nombre + " " + usuario.Apellido;
                _UsuarioId = bus1.UsuarioId;
                _MesaId = Convert.ToInt32(bus1.MesaId);

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
