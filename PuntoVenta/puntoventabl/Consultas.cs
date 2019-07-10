using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;

namespace PuntoVentaBL
{
   public class Consultas
    {
       PuntoVentaDAL.CONEXIONDataContext db = null;
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

       //Metodos
        public bool VerificarUsuario(int id)
        {
            bool respuesta = false;
            int rol=0;
            this.OpenConn();
            try
            {
                var bus = (from x in db.Usuarios
                           where x.Id == id
                        select x).First();
             

                
                //MessageBox.Show("el rol es " +" la consulta es "+bus.RolId);
                rol = bus.RolId;

                if (rol ==1 || rol==3)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }

                this.CloseConn();
               

                return respuesta;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }




        }

       //******************************************************************

        public void ObtieneInventarioMovimientos(DataGridView dgv)
        {
            try
            {
                this.OpenConn();
                 
                  var bus = (from x in db.BitacoraInventario
                             join us in db.Usuarios on x.idUsuario equals us.Id
                             join mo in db.MovimientosBitacora on x.id_MovimientoBitacora equals mo.id
                             select new { mo.Descripcion,
                                           x.id_producto,
                                            x.DescripcionProducto,
                                             x.cantidadUnidades,
                                              Nombre=us.Nombre+" "+us.Apellido,
                                              x.fecha
                                              });


                  if (bus.Count() > 0)
                  {
                      dgv.AutoGenerateColumns = false;
                      dgv.DataSource = bus;
                     
                  }
                  this.CloseConn();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CargarUsuarios(ComboBox cb)
        {
            this.OpenConn();
            try
            {
                var bus = (from x in db.Usuarios
                           select new
                           {
                              Nombre= x.Nombre+" "+x.Apellido
                           });
                if (bus.Count() > 0)
                {
                    cb.DataSource = bus;
                }
                else {
                    
                   
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void CargarReceptores(ComboBox cb)
        {
            this.OpenConn();
            try
            {
                var bus = (from x in db.Persona where x.Receptor
                           select new
                           {
                               Nombre = x.Nombre 
                           } );
                if (bus.Count() > 0)
                {
                    cb.DataSource = bus;
                }
                else
                {


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void CargarMovimientos(ComboBox cb)
        {
            this.OpenConn();
            try
            {
                var bus = (from x in db.MovimientosBitacora
                           select new
                           {
                               x.Descripcion
                           });
                if (bus.Count() > 0)
                {
                    cb.DataSource = bus;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void CargarFiltro(DataGridView dgv,String filtro)
        {
            try
            {
                this.OpenConn();
                var movi = (from x in db.MovimientosBitacora
                            where x.Descripcion == filtro
                            select x).First();

                int IdMovi = movi.id;

                var bus = (from x in db.BitacoraInventario
                           join us in db.Usuarios on x.idUsuario equals us.Id
                           join mo in db.MovimientosBitacora on x.id_MovimientoBitacora equals mo.id
                           where x.id_MovimientoBitacora==IdMovi
                           select new
                           {
                               mo.Descripcion,
                               x.id_producto,
                               x.DescripcionProducto,
                               x.cantidadUnidades,
                               Nombre = us.Nombre + " " + us.Apellido,
                               x.fecha
                           });


                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;

                }
                else
                {
                    MessageBox.Show("No hay movimientos de este tipo registrados ", "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.CloseConn();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void CargarFiltroUsuario(DataGridView dgv, String filtro,String user)
        {
            try
            {
                this.OpenConn();

                var userid = (from x in db.Usuarios
                            where x.Nombre + " " + x.Apellido == user
                            select x).First();
                int UsuarioId = userid.Id;

                var movi = (from x in db.MovimientosBitacora
                            where x.Descripcion == filtro
                            select x).First();

                int IdMovi = movi.id;

                var bus = (from x in db.BitacoraInventario
                           join us in db.Usuarios on x.idUsuario equals us.Id
                           join mo in db.MovimientosBitacora on x.id_MovimientoBitacora equals mo.id
                           where x.id_MovimientoBitacora == IdMovi && x.idUsuario==UsuarioId
                           select new
                           {
                               mo.Descripcion,
                               x.id_producto,
                               x.DescripcionProducto,
                               x.cantidadUnidades,
                               Nombre = us.Nombre + " " + us.Apellido,
                               x.fecha
                           });


                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;

                }
                else
                {
                    MessageBox.Show("Este usuario no tiene movimientos de la bitacora registrados ", "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.CloseConn();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void CargarFiltroUsuarioFecha(DataGridView dgv, String filtro, String user,String fecha)
        {
            try
            {
                this.OpenConn();

                var userid = (from x in db.Usuarios
                              where x.Nombre + " " + x.Apellido == user
                              select x).First();
                int UsuarioId = userid.Id;

                var movi = (from x in db.MovimientosBitacora
                            where x.Descripcion == filtro
                            select x).First();

                int IdMovi = movi.id;

                var bus = (from x in db.BitacoraInventario
                           join us in db.Usuarios on x.idUsuario equals us.Id
                           join mo in db.MovimientosBitacora on x.id_MovimientoBitacora equals mo.id
                           where x.id_MovimientoBitacora == IdMovi && x.idUsuario == UsuarioId
                           && x.fecha==Convert.ToDateTime(fecha)
                           select new
                           {
                               mo.Descripcion,
                               x.id_producto,
                               x.DescripcionProducto,
                               x.cantidadUnidades,
                               Nombre = us.Nombre + " " + us.Apellido,
                               x.fecha
                           });


                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;

                }
                else
                {
                    MessageBox.Show("Este usuario no tiene movimientos de la bitacora registrados ", "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv.DataSource = null;
                }
                this.CloseConn();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

