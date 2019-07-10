using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Login
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades

        private string _Login_s;

        public string Login_s
        {
            get { return _Login_s; }
            set { _Login_s = value; }
        }

        private string _Contrasena;

        public string Contrasena
        {
            get { return _Contrasena; }
            set { _Contrasena = value; }
        }

        private int _RolId;

        public int RolId
        {
            get { return _RolId; }
            set { _RolId = value; }
        }

        private int _UsuarioId;

        public int UsuarioId
        {
            get { return _UsuarioId; }
            set { _UsuarioId = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        

        #endregion

        #region Metodos

        public bool IngresaUsuario()
        {
            try
            {
                this.OpenConn();

                var bus_login = (from u in db.Usuarios
                                 where u.Login == _Login_s
                                 select u);

                if (bus_login == null || bus_login.Count() == 0)
                {
                    return false;
                }
                else
                {
                    var bus_ingreso = (from u in db.Usuarios
                                       where u.Login == _Login_s && u.Password == _Contrasena
                                       select u);

                    if (bus_ingreso == null || bus_ingreso.Count() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        _RolId = bus_ingreso.First().RolId;
                        _UsuarioId = bus_ingreso.First().Id;
                        _Login_s = bus_ingreso.First().Login;
                        _Nombre = bus_ingreso.First().Nombre + " " + bus_ingreso.First().Apellido;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al sistema: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public bool IngresaUsuarioPermiso()
        {
            try
            {
                this.OpenConn();
                
                var bus_login = (from u in db.Usuarios
                                 where u.Login == _Login_s
                                 select u);

                if (bus_login == null || bus_login.Count() == 0)
                {
                    return false;
                }
                else
                {
                    var bus_ingreso = (from u in db.Usuarios
                                       where u.Login == _Login_s && u.Password == _Contrasena
                                       select u);

                    if (bus_ingreso == null || bus_ingreso.Count() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (bus_ingreso.First().RolId.ToString()=="1")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al sistema: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
