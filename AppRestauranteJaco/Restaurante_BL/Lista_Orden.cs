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
    public class Lista_Orden
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades
        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
        
        private DateTime _Hora;

        public DateTime Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }

        private decimal _Precio;
        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        private string _Detalle;

        public string Detalle
        {
            get { return _Detalle; }
            set { _Detalle = value; }
        }
        

        private int _CantidadLicores;

        public int CantidadLicores
        {
            get { return _CantidadLicores; }
            set { _CantidadLicores = value; }
        }

        public List<string> ListaLicor = new List<string>();

        private int _CantidadCoctel;

        public int CantidadCoctel
        {
            get { return _CantidadCoctel; }
            set { _CantidadCoctel = value; }
        }

        public List<string> ListaCoctel = new List<string>();

        private int _CantidadBocas;

        public int CantidadBocas
        {
            get { return _CantidadBocas; }
            set { _CantidadBocas = value; }
        }

        public List<string> ListaBocas = new List<string>();

        private int _CantidadPlatillos;

        public int CantidadPlatillos
        {
            get { return _CantidadPlatillos; }
            set { _CantidadPlatillos = value; }
        }

        public List<string> ListaPlatillos = new List<string>();

        private string _DescripcionSubfamilia;

	    public string DescripcionSubfamilia
	    {
		    get { return _DescripcionSubfamilia;}
		    set { _DescripcionSubfamilia = value;}
	    }

        private Int64 _CodigoArticulo;

        public Int64 CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
        }
        
        private int _MesaId;

        public int MesaId
        {
            get { return _MesaId; }
            set { _MesaId = value; }
        }

        private int _Cantidad;

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private Int64 _Factura;

        public Int64 Factura
        {
            get { return _Factura; }
            set { _Factura = value; }
        }
        
        #endregion

        public void ObtengoLicores()
        {            
            try
            {
                this.OpenConn();

                var bus = from cl in db.Articulo
                        join f in db.Familias on cl.FamiliaId equals f.Id
                        where f.Id==1
                        select cl;

                _CantidadLicores = bus.Count();

                ListaLicor.Clear();

                foreach (var item in bus)
                {
                    if (item.Id>=10)
                    {
                        if (item.Id>100)
                        {
                            //ListaLicor.Add(item.Id + item.Nombre + " - " + item.Costo.ToString()); 
                            ListaLicor.Add(item.Id + item.Nombre + " - " + item.Costo.ToString()); 
                        }
                        else
                        {
                            ListaLicor.Add("0" + item.Id + item.Nombre + " - " + item.Costo.ToString()); 
                        }
                    }
                    else
                    {
                        ListaLicor.Add("00" + item.Id + item.Nombre + " - " + item.Costo.ToString());
                    }                    
                }
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

        public void ObtengoCoctel()
        {
            try
            {
                this.OpenConn();

                var bus = from cl in db.Articulo
                          join f in db.Familias on cl.FamiliaId equals f.Id
                          where f.Id == 2
                          select cl;

                _CantidadCoctel = bus.Count();

                ListaCoctel.Clear();

                foreach (var item in bus)
                {
                    if (item.Id >= 10)
                    {
                        if (item.Id > 100)
                        {
                            ListaCoctel.Add(item.Id + item.Nombre + " - " + item.Costo.ToString());
                        }
                        else
                        {
                            ListaCoctel.Add("0" + item.Id + item.Nombre + " - " + item.Costo.ToString());
                        }
                    }
                    else
                    {
                        ListaCoctel.Add("00" + item.Id + item.Nombre + " - " + item.Costo.ToString());
                    }   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener los cocteles: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtengoBocas()
        {
            try
            {
                this.OpenConn();

                var bus = from cl in db.Articulo
                          join f in db.Familias on cl.FamiliaId equals f.Id
                          where f.Id == 3
                          select cl;

                _CantidadBocas = bus.Count();

                ListaBocas.Clear();

                foreach (var item in bus)
                {
                    if (item.Id >= 10)
                    {
                        if (item.Id > 100)
                        {
                            ListaBocas.Add(item.Id + item.Nombre + " - " + item.Costo.ToString());
                        }
                        else
                        {
                            ListaBocas.Add("0" + item.Id + item.Nombre + " - " + item.Costo.ToString());
                        }
                    }
                    else
                    {
                        ListaBocas.Add("00" + item.Id + item.Nombre + " - " + item.Costo.ToString());
                    }  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener las bocas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtengoPlatillos()
        {
            try
            {
                this.OpenConn();

                var bus = from cl in db.Articulo
                          join f in db.Familias on cl.FamiliaId equals f.Id
                          where f.Id == 4
                          select cl;

                _CantidadPlatillos = bus.Count();

                ListaPlatillos.Clear();

                foreach (var item in bus)
                {
                    if (item.Id >= 10)
                    {
                        if (item.Id > 100)
                        {
                            ListaPlatillos.Add(item.Id + item.Nombre + " - " + item.Costo.ToString());
                        }
                        else
                        {
                            ListaPlatillos.Add("0" + item.Id + item.Nombre + " - " + item.Costo.ToString());
                        }
                    }
                    else
                    {
                        ListaPlatillos.Add("00" + item.Id + item.Nombre + " - " + item.Costo.ToString());
                    }  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener los platillos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtengoDescripcionSubfamilia(int id)
        {
            try
            {
                this.OpenConn();

                var bus = from cl in db.Articulo
                          where cl.Id==id
                          select cl;

                _DescripcionSubfamilia = bus.First().Descripcion.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener la información del producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void IngresoTemporalConsumo()
        {
            try
            {
                this.OpenConn();

                Restaurante_DAL.TemporalConsumo _NewTemporal = new Restaurante_DAL.TemporalConsumo();
                _NewTemporal.CodigoArticulo = _CodigoArticulo;
                _NewTemporal.Mesa_Silla = _MesaId;
                _NewTemporal.Cantidad = _Cantidad;
                _NewTemporal.Detalle = _Detalle;
                _NewTemporal.Hora = System.DateTime.Now;
                _NewTemporal.Observaciones = _Observaciones;
                _NewTemporal.Activo = true;
                _NewTemporal.precio = _Precio;

                db.TemporalConsumo.InsertOnSubmit(_NewTemporal);

                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ordenar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtengoConsumoActualHora()
        {
            try
            {
                this.OpenConn();

                //var bus = from tc in db.TemporalConsumo
                //          join sf in db.Articulos on tc.CodigoArticulo equals sf.Id
                //          where tc.Mesa_Silla==_MesaId
                //          select new { tc.CodigoArticulo, tc.Cantidad, Descripcion = sf.Nombre, Precio = String.Format("{0:0.00}", (tc.Cantidad * sf.Costo)), Eliminar = "Eliminar" };

                var bus = from x in db.ObtieneConsumoMesaHoras
                          where x.Mesa_Silla == _MesaId
                          orderby x.Hora ascending
                          select x;
                        

                if (bus.Count()>0)
                {
                    _Hora = Convert.ToDateTime(bus.First().Hora);
                }
                else
                {
                    _Hora = Convert.ToDateTime("01/01/0001");
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

        public void ObtengoConsumoActual(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                //var bus = from tc in db.TemporalConsumo
                //          join sf in db.Articulos on tc.CodigoArticulo equals sf.Id
                //          where tc.Mesa_Silla==_MesaId
                //          select new { tc.CodigoArticulo, tc.Cantidad, Descripcion = sf.Nombre, Precio = String.Format("{0:0.00}", (tc.Cantidad * sf.Costo)), Eliminar = "Eliminar" };

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

        public void EliminoOrden()
        {
            try
            {
                this.OpenConn();

                //var bus = (from tc in db.TemporalConsumo
                //           where tc.CodigoArticulo == _CodigoArticulo && tc.Mesa_Silla == _MesaId
                //           select tc).First();

                //db.TemporalConsumo.DeleteOnSubmit(bus);

                //db.SubmitChanges();

                var bus = (from tc in db.TemporalConsumo
                           where tc.Mesa_Silla == _MesaId && tc.CodigoArticulo == _CodigoArticulo //&& tc.Cantidad == _Cantidad
                           select tc).First();

                        bus.Cantidad -= 1;


                        if (bus.Cantidad == 0)
                        {
                            db.TemporalConsumo.DeleteOnSubmit(bus);
                        }
                        db.SubmitChanges();
                }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener la información del producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
