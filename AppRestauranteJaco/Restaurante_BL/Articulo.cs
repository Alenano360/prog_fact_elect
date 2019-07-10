using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurante_BL
{
    public class Articulo
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _FamiliaId;

        public int FamiliaId
        {
            get { return _FamiliaId; }
            set { _FamiliaId = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private decimal _Costo;

        public decimal Costo
        {
            get { return _Costo; }
            set { _Costo = value; }
        }


        private int _Existencias;

        public int Existencias
        {
            get { return _Existencias; }
            set { _Existencias = value; }
        }

        private int _Tipo;

        public int Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private bool _Inventariado;

        public bool Inventariado
        {
            get { return _Inventariado; }
            set { _Inventariado = value; }
        }

        private int _Comanda;

        public int Comanda
        {
            get { return _Comanda; }
            set { _Comanda = value; }
        }

        private string _Orden;

        public string Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }
        
        #endregion

        #region Metodos
        public void ObtengoArticulos(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from a in db.Articulo
                           join f in db.Familias on a.FamiliaId equals f.Id
                           where a.Activo == true
                           select new { a.Id,a.FamiliaId,Familia=f.Descripcion,a.Nombre,a.Descripcion,a.Costo,
                                        a.Existencias,Inventariado=(a.Inventariado==true?"SI":"NO"),
                                        Comanda=(a.Comanda==1?"BAR":"COCINA") });

                if (_Nombre!=null)
                {
                    bus = from x in bus
                          where x.Nombre.Contains(_Nombre) || x.Descripcion.Contains(_Nombre)
                          select x;
                }

                if (_Orden != "--Seleccione--")
                {
                    switch (_Orden)
                    {
                        case "Nombre":
                            {
                                bus = from x in bus
                                      orderby x.Nombre ascending
                                      select x;
                                break;
                            }

                        case "Familia":
                            {
                                bus = from x in bus
                                      orderby x.Familia ascending
                                      select x;
                                break;
                            }

                        case "Costo":
                            {
                                bus = from x in bus
                                      orderby x.Costo descending
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtengoArticulosXFamilia(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from a in db.Articulo
                           join f in db.Familias on a.FamiliaId equals f.Id
                           where f.Id==_FamiliaId
                           select new { a.Id, a.FamiliaId, Familia = f.Descripcion, a.Nombre, a.Descripcion, a.Costo, a.Existencias, Inventariado = (a.Inventariado == true ? "SI" : "NO"), Comanda = (a.Comanda == 1 ? "BAR" : "COCINA") });

                if (_Nombre != null)
                {
                    bus = from x in bus
                          where x.Nombre.Contains(_Nombre) || x.Descripcion.Contains(_Nombre)
                          select x;
                }

                if (_Orden!="--Seleccione--")
                {
                    switch (_Orden)
                    {
                        case "Nombre": 
                        {
                            bus = from x in bus
                                  orderby x.Nombre ascending
                                  select x;
                            break;
                        }

                        case "Familia":
                        {
                            bus = from x in bus
                                  orderby x.Familia ascending
                                  select x;
                            break;
                        }

                        case "Costo":
                        {
                            bus = from x in bus
                                  orderby x.Costo descending
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool EliminaArticulo()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Articulo
                           where x.Id == _Id
                           select x).First();

                bus.Activo = false;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public void AgregaArticulo()
        {
            try
            {
                this.OpenConn();

                Restaurante_DAL.Articulo _newArticulo = new Restaurante_DAL.Articulo();
                _newArticulo.Nombre = _Nombre;
                _newArticulo.Descripcion = _Descripcion;
                _newArticulo.FamiliaId = _FamiliaId;
                _newArticulo.Costo = _Costo;
                _newArticulo.Existencias = _Existencias;
                _newArticulo.Inventariado = _Inventariado;
                _newArticulo.Comanda = _Comanda;
                _newArticulo.Activo = true;
                _newArticulo.tipo = _Tipo;

                db.Articulo.InsertOnSubmit(_newArticulo);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ModificaArticulo()
        {
            try
            {

                this.OpenConn();

                var _newArticulo = (from a in db.Articulo
                                   where a.Id == _Id
                                   select a).First();

                _newArticulo.Nombre = _Nombre;
                _newArticulo.Descripcion = _Descripcion;
                _newArticulo.FamiliaId = _FamiliaId;
                _newArticulo.Costo = _Costo;
                _newArticulo.Existencias = _Existencias;
                _newArticulo.Inventariado = _Inventariado;
                _newArticulo.Comanda = _Comanda;
                _newArticulo.tipo = _Tipo;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtengoDatosArticulos()
        {
            try
            {
                this.OpenConn();

                var bus = (from a in db.Articulo
                           where a.Activo == true && a.Id == _Id
                           select a).First();

                _FamiliaId = bus.FamiliaId;
                _Nombre = bus.Nombre;
                _Descripcion = bus.Descripcion;
                _Costo = Convert.ToDecimal(bus.Costo);
                _Existencias = bus.Existencias;
                _Inventariado = bus.Inventariado;
                _Comanda = bus.Comanda;
                _Tipo = Convert.ToInt32(bus.tipo);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
