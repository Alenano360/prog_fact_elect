using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurante_BL
{
    public class Facturar
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades
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

        private Int64 _Codigo;

        public Int64 Codigo
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

        public bool ObtieneProducto(Int64 id)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           join f in db.Familias on x.FamiliaId equals f.Id
                           where x.Activo == true && x.Id == Convert.ToInt64(id)
                           select new
                           {
                               Codigo=x.Id,
                               Articulo = x.Descripcion,
                               Precio=x.Costo,
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
                    _Precio = Convert.ToDecimal(bus.First().Precio);
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
