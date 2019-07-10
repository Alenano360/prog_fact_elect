using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Restaurante_BL
{
    public class CAdministrador
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades

        private int _UsuarioId;

        public int UsuarioId
        {
            get { return _UsuarioId; }
            set { _UsuarioId = value; }
        }

        private string _Login;

        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }

        private string _Contrasena;

        public string Contrasena
        {
            get { return _Contrasena; }
            set { _Contrasena = value; }
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

        private int _Accion;

        public int Accion
        {
            get { return _Accion; }
            set { _Accion = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellidos;

        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }
        

        #endregion

        #region Metodos

        public void ObtieneTiposUsuario(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from tp in db.Roles
                           select tp);

                if (bus!=null||bus.Count()>0)
                {
                    cmb.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los tipos de usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUsuariosXTipo(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from u in db.Usuarios
                           where u.RolId == _RolId
                           select new {u.Id,u.Login,Modificar="Modificar" ,Eliminar="Eliminar"});

                if (bus!=null||bus.Count()>0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los tipos de usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUsuario()
        {
            try
            {
                this.OpenConn();

                var bus = (from u in db.Usuarios
                           where u.Id==_UsuarioId
                           select u);

                if (bus != null || bus.Count() > 0)
                {
                    _Login = bus.First().Login;
                    _Contrasena = bus.First().Password;
                    _Activo = bus.First().Activo;
                    _RolId = bus.First().RolId;
                    _Nombre = bus.First().Nombre;
                    _Apellidos = bus.First().Apellido;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool VerificoLogin()
        {
            try
            {
                this.OpenConn();

                var bus = (from u in db.Usuarios
                           where u.Login==_Login
                           select u);

                int b = bus.Count();

                if (b>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public void EliminaUsuario()
        {
            try
            {
                this.OpenConn();
                var bus2 = (from u in db.Marcas_Personal
                            where u.Id_Usuario == _UsuarioId
                            select u);
                foreach (var item in bus2)
                {
                    db.Marcas_Personal.DeleteOnSubmit(item);
                    db.SubmitChanges();

                }


                var bus = (from u in db.Usuarios
                           where u.Id == _UsuarioId
                           select u).First();
             
                db.Usuarios.DeleteOnSubmit(bus);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void MantenimientoUsuario()
        {
            try
            {
                this.OpenConn();

                if (_Accion==0)//modificacion
                {
                    var bus = (from u in db.Usuarios
                               where u.Id == _UsuarioId
                               select u);

                    if (bus != null || bus.Count() > 0)
                    {
                        bus.First().Login = _Login;
                        bus.First().Password = _Contrasena;
                        bus.First().Activo = _Activo;
                        bus.First().RolId = _RolId;
                        bus.First().Nombre = _Nombre;
                        bus.First().Apellido = _Apellidos;
                    }
                }
                else
                {
                    Restaurante_DAL.Usuario _NewUsuario = new Restaurante_DAL.Usuario();
                    _NewUsuario.Login = _Login;
                    _NewUsuario.Password = _Contrasena;
                    _NewUsuario.Activo = _Activo;
                    _NewUsuario.RolId = _RolId;
                    _NewUsuario.Nombre = _Nombre;
                    _NewUsuario.Apellido = _Apellidos;

                    db.Usuarios.InsertOnSubmit(_NewUsuario);
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar hacer el mantenimiento del usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
