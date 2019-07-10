using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace Restaurante_BL
{
    public class Login
    {
        Restaurante_DAL.BaseDatosDataContext db = null;



        #region Propiedades

        //public static string RolDescripcion = string.Empty;

        private string _RolDescripcion;

        public string RolDescripcion
        {
            get { return _RolDescripcion; }
            set { _RolDescripcion = value; }
        }
        
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

                if (bus_login==null||bus_login.Count()==0)
                {
                    return false;
                }
                else
                {
                    var bus_ingreso =(from u in db.Usuarios
                                
                                 where u.Login == _Login_s && u.Password==_Contrasena
                                 select u);
 

                    if (bus_ingreso == null || bus_ingreso.Count() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        _RolId = bus_ingreso.First().RolId;
                        _UsuarioId = bus_ingreso.First().Id;
                        _Login_s = bus_ingreso.First().Nombre+" "+bus_ingreso.First().Apellido;                        

                        var rol = (from r in db.Roles
                                   where r.Id == _RolId
                                   select new { r.Descripcion }).First();

                        _RolDescripcion = rol.Descripcion.ToString();
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


        public void ObtieneUsuario(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from u in db.Usuarios 
                           where u.Activo == true
                           orderby u.Login ascending
                           select new { u.Id, u.Login });

                DataTable dt = new DataTable();

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Login");

                foreach (var item in bus)
                {
                    DataRow dre = dt.NewRow();
                    dre["Login"] = item.Login;
                    dre["Id"] = item.Id;
                    dt.Rows.InsertAt(dre, 0);
                }

                cmb.DisplayMember = "Login";
                cmb.ValueMember = "Id";


                DataRow dr = dt.NewRow();
                dr["Login"] = "--Seleccione--";
                dr["Id"] = 0;

                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
                cmb.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los Usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
