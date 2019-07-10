using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Usuario
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades
        private int _Id;

	    public int Id
	    {
		    get { return _Id;}
		    set { _Id = value;}
	    }
	
        private string _Login;

        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellido;

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private bool _Activo;

        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        private int _RolId;

        public int RolId
        {
            get { return _RolId; }
            set { _RolId = value; }
        }
        
        
        #endregion

        #region Metodos

        public void ObtieneUsuarios(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = from x in db.Usuarios
                          select new {x.Id,Nombre=x.Nombre+" "+(x.Apellido==null?"":x.Apellido) };

                if (bus.Count()>0)
                {
                    cmb.DataSource = bus;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneRoles(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Rols                           
                           select new { x.Id, x.Descripcion });

                if (bus.Count() > 0)
                {
                    cmb.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los roles de usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUsuarios(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Usuarios
                           join r in db.Rols on x.RolId equals r.Id
                           where x.Activo==true
                           select new { x.Id,x.Nombre,Apellidos=x.Apellido,r.Descripcion,x.Login });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUsuarioId()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Usuarios
                           where x.Id==_Id && x.Activo==true
                           select new { x.Id, x.Nombre, Apellidos = x.Apellido,x.Login,x.Password,x.RolId });

                if (bus.Count() > 0)
                {
                    _Nombre = bus.First().Nombre;
                    _Apellido = bus.First().Apellidos;
                    _Login = bus.First().Login;
                    _Password = bus.First().Password;
                    _RolId = bus.First().RolId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool AgregaUsuario(int UserId)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.Usuario _newUsuario = new PuntoVentaDAL.Usuario();

                _newUsuario.Nombre = _Nombre;
                _newUsuario.Apellido = _Apellido;
                _newUsuario.Login = _Login;
                _newUsuario.Password = _Password;
                _newUsuario.Activo = true;
                _newUsuario.RolId = _RolId;

                db.Usuarios.InsertOnSubmit(_newUsuario);

                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool ModificaUsuario(int UserId)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Usuarios
                           where x.Activo == true && x.Id == _Id
                           select x).First();

                bus.Nombre = _Nombre;
                bus.Apellido = _Apellido;
                bus.Login = _Login;
                bus.Password = _Password;
                bus.Activo = true;
                bus.RolId = _RolId;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool EliminaUsuario(int UserId)
        {
            try
            {
                this.OpenConn();

                if (UserId==_Id)
                {
                    MessageBox.Show("No puede eliminar su usuario!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                var bus = (from x in db.Usuarios
                           where x.Activo == true && x.Id == _Id
                           select x).First();

                bus.Activo = false;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
