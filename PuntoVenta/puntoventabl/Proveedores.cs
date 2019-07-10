using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Proveedores
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Contacto;

        public string Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }

        private string _Cedula;

        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }

        private string _Telefono1;

        public string Telefono1
        {
            get { return _Telefono1; }
            set { _Telefono1 = value; }
        }


        private string _Telefono2;

        public string Telefono2
        {
            get { return _Telefono2; }
            set { _Telefono2 = value; }
        }

        private DateTime _CreacionFecha;

        public DateTime CreacionFecha
        {
            get { return _CreacionFecha; }
            set { _CreacionFecha = value; }
        }

        private bool _Activo;

        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }
        

        #endregion

        #region Metodos

        public void ObtieneProveedores(DataGridView dgv)
        {
            try
            {
                this.OpenConn();                

                var bus = (from p in db.Proveedors
                           where p.Activo == true
                           orderby p.Nombre ascending
                           select p);

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
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

        public void ObtieneProveedoresBusqueda(DataGridView dgv)
        {
            try
            {
                this.OpenConn();                

                var bus = (from p in db.Proveedors
                           where p.Activo == true && (p.Nombre.Contains(_Nombre) || p.Contacto.Contains(_Nombre) || p.Cedula.Contains(_Nombre) || p.Telefono1.Contains(_Nombre) || p.Telefono2.Contains(_Nombre))
                           orderby p.Nombre ascending
                           select new {  p.Nombre,p.Id, p.Contacto, p.Cedula, p.Telefono1, p.Telefono2 });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
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

        public void ObtieneProveedoresOrdenado(DataGridView dgv, string Busqueda)
        {
            try
            {
                this.OpenConn();                

                switch (Busqueda)
                {
                    case "Nombre":
                        {
                            var bus = (from x in db.Proveedors
                                       where x.Activo == true
                                       orderby x.Nombre ascending
                                       select x);

                            if (bus.Count() > 0)
                            {
                                dgv.AutoGenerateColumns = false;
                                dgv.DataSource = bus;
                            }
                            break;
                        }
                    case "Contacto":
                        {
                            var bus = (from x in db.Proveedors
                                       where x.Activo == true
                                       orderby x.Contacto ascending
                                       select x);

                            if (bus.Count() > 0)
                            {
                                dgv.AutoGenerateColumns = false;
                                dgv.DataSource = bus;
                            }
                            break;
                        }
                    case "Inicio de relaciones":
                        {
                            var bus = (from x in db.Proveedors
                                       where x.Activo == true
                                       orderby x.CreacionFecha ascending
                                       select x);

                            if (bus.Count() > 0)
                            {
                                dgv.AutoGenerateColumns = false;
                                dgv.DataSource = bus;
                            }
                            break;
                        }                  
                    default:
                        break;
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

        public bool EliminaProveedor(int UserId)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Proveedors
                           where x.Activo == true && x.Id == Id
                           orderby x.Nombre ascending
                           select x).First();

                bus.Activo = false;
                bus.UsuarioId = UserId;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el proveedor: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public void ObtieneProveedorBusqueda()
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.Proveedors
                           where f.Activo == true && f.Id == _Id
                           orderby f.Nombre ascending
                           select new
                           {
                               f.Nombre,
                               Contacto = (f.Contacto == null ? "" : f.Contacto),
                               Cedula=(f.Cedula==null?"":f.Cedula),
                               Telefono1 = (f.Telefono1 == null ? "" : f.Telefono1),
                               Telefono2 = (f.Telefono2 == null ? "" : f.Telefono2),
                               f.CreacionFecha
                           });

                if (bus.Count() > 0)
                {
                    var bu = bus.First();

                    _Nombre = bu.Nombre;                    
                    _Contacto = bu.Contacto;
                    _Cedula = bu.Cedula;                    
                    _Telefono1 = bu.Telefono1;
                    _Telefono2 = bu.Telefono2;
                    _CreacionFecha = bu.CreacionFecha;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el proveedor: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool AgregaProveedor(int UserId)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.Proveedor _NewProveedor = new PuntoVentaDAL.Proveedor();

                _NewProveedor.Nombre = _Nombre;
                _NewProveedor.Contacto = _Contacto;
                _NewProveedor.Cedula = _Cedula;
                _NewProveedor.Telefono1 = _Telefono1;
                _NewProveedor.Telefono2 = _Telefono2;                
                _NewProveedor.Activo = true;
                _NewProveedor.UsuarioId = UserId;
                _NewProveedor.CreacionFecha = _CreacionFecha;

                db.Proveedors.InsertOnSubmit(_NewProveedor);

                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el proveedor: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool ModificaProveedor(int UserId)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Proveedors
                           where x.Activo == true && x.Id == Id
                           orderby x.Nombre ascending
                           select x).First();

                bus.Nombre = _Nombre;                
                bus.Contacto = _Contacto;
                bus.Cedula = _Cedula;
                bus.Telefono1 = _Telefono1;
                bus.Telefono2 = _Telefono2;
                bus.CreacionFecha = _CreacionFecha;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el proveedor: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
