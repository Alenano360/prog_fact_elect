using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Globalization;
namespace Restaurante_BL
{
   public  class MarcasPersonal
    {
       Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades

       private int _UsuarioId;

       public int UsuarioId
       {
           get { return _UsuarioId; }
           set { _UsuarioId = value; }
       }

       private DateTime _Fecha;
       public DateTime Fecha
       {
           get { return _Fecha; }
           set { _Fecha = value; }
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

       private TimeSpan? _HoraEntrada;
       public TimeSpan? HoraEntrada
       {
           get { return _HoraEntrada; }
           set { _HoraEntrada = value; }
       }

       private TimeSpan? _HoraSalida;
       public TimeSpan? HoraSalida
       {
           get { return _HoraSalida; }
           set { _HoraSalida = value; }
       }
        #endregion

        #region Metodos

       /// <summary>
       /// Método encargado de ingresar la Entrada del Usuario
       /// </summary>
       public void AgregaEntrada()
       {
           try
           {
               if (ObtengoEntrada() == 1)
               {
                   MessageBox.Show("La Hora de Entrada Ha Sido Registrada Anteriormente", "Registro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
               else
               {
                   this.OpenConn();
                   Restaurante_DAL.Marcas_Personal _newMarca = new Restaurante_DAL.Marcas_Personal();
                   _newMarca.Id_Usuario = _UsuarioId;
                   _newMarca.Fecha = DateTime.Now;

                   db.Marcas_Personal.InsertOnSubmit(_newMarca);

                   db.SubmitChanges();

                   MessageBox.Show("Hora de Entrada Registrada Correctamente", "Registro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Hubo un inconveniente al intentar Registrar la Hora de Entrada: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               this.CloseConn();
           }
       }

       /// <summary>
       /// Método encargado de ingresar la Salida del Usuario
       /// </summary>
       public void AgregaSalida()
       {
           try
           {
               if (ObtengoEntrada() == 0)
               {
                   MessageBox.Show("¡Se Debe Registrar Primero la Hora de Entrada!", "Registro de Salida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }
               else
               {
                   this.OpenConn();
                   var bus = (from a in db.Marcas_Personal
                              where a.Id_Usuario == _UsuarioId
                              && a.Hora_Salida == null
                              && a.Fecha.Year == DateTime.Today.Year
                              && a.Fecha.Month == DateTime.Today.Month
                              && a.Fecha.Day == DateTime.Today.Day
                              select a).Count();

                   if (bus > 0)
                   {
                       var _newMarca = (from a in db.Marcas_Personal
                                        where a.Id_Usuario == _UsuarioId
                                        && a.Hora_Salida == null
                                        && a.Fecha.Year == DateTime.Today.Year
                                        && a.Fecha.Month == DateTime.Today.Month
                                        && a.Fecha.Day == DateTime.Today.Day
                                        select a).First();

                       _newMarca.Hora_Salida = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));

                       db.SubmitChanges();

                       MessageBox.Show("Hora de Salida Registrada Correctamente", "Registro de Salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                   else
                   {
                       MessageBox.Show("Hora de Salida Registrada Anteriormente", "Registro de Salida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Hubo un inconveniente al intentar Registrar la Hora de Salida: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               this.CloseConn();
           }
       }

       /// <summary>
       /// Método Encargado de Obtener las Marcas de los Usuarios
       /// </summary>
       /// <param name="dgv">Obligatorio.Desglosa Información</param>
       /// <param name="intIdUsuario">Opcional.Indica el Id del Usuario a Consultar</param>
       /// <param name="Criterio">Opcional. Indica el Orden de la Consulta</param>
       public void ObtengoMarcas(DataGridView dgv, int intIdUsuario = 0, string Criterio = "")
       {
           try
           {

               this.OpenConn();

               var bus = (from a in db.Marcas_Personal
                          join u in db.Usuarios on a.Id_Usuario equals u.Id
                          where a.Hora_Salida != null &&
                                FechaInicio <= Convert.ToDateTime(a.Fecha) && Convert.ToDateTime(a.Fecha) <= FechaFinal
                          select new { 
                                       a.Fecha,a.Id_Usuario,
                                       LoginUsuario= u.Login,
                                       NombreEmpleado = (u.Nombre +" "+u.Apellido),
                                       Hora_Entrada = new TimeSpan(a.Hora_Entrada.Hours, a.Hora_Entrada.Minutes, a.Hora_Entrada.Seconds),
                                       Hora_Salida = a.Hora_Salida,
                                       Total_Horas = DateTime.Parse (a.Hora_Salida.ToString()).Subtract (DateTime .Parse (a.Hora_Entrada.ToString ())) });

               if (intIdUsuario !=0)
               {
                   bus = from x in bus
                         where x.Id_Usuario == intIdUsuario
                         select x;
               }
               if (Criterio != "--Seleccione--")
               {
                   switch (Criterio)
                   {
                       case "Fecha":
                           {
                               bus = from a in bus
                                     orderby a.Fecha ascending
                                     select a;
                               break;
                           }
                       case "Usuario":
                           {
                               bus = from u in bus
                                     orderby u.LoginUsuario ascending
                                     select u;
                               break;
                           }

                       default:
                           break;
                   }
               }
               else
               {
                   bus = from a in bus
                         orderby a.Fecha ascending
                         select a;
               }

               if (bus.Count() > 0)
               {
                   dgv.AutoGenerateColumns = false;
                   dgv.DataSource = bus;
               }
               return;
           }
           catch (Exception ex)
           {
               MessageBox.Show("Hubo un inconveniente al intentar obtener las famlias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               this.CloseConn();
           }

       }

       /// <summary>
       /// Método encargado de Mostrar los Datos de la Marca más Actual por medio del Usuario
       /// </summary>
       public void ObtengoDatosMarca()
       {
           try
           {
               this.OpenConn();

               var bus = (from a in db.Marcas_Personal
                          where a.Id_Usuario ==_UsuarioId
                          && a.Fecha.Year == DateTime.Today.Year
                          && a.Fecha.Month == DateTime.Today.Month
                          && a.Fecha.Day == DateTime.Today.Day
                          select a).First();

                   _UsuarioId = bus.Id_Usuario;
                   _Fecha     = bus.Fecha;
                   _HoraEntrada = new TimeSpan(bus.Hora_Entrada.Hours, bus.Hora_Entrada.Minutes, bus.Hora_Entrada.Seconds);
                   _HoraSalida =  bus.Hora_Salida;

               
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

       /// <summary>
       /// Función Encargada de Mostrar la cantidad de Entradas por Medio del Usuario
       /// </summary>
       /// <returns>Cantidad de Registros Marca </returns>
       public int ObtengoEntrada()
       {
           int intRegistrosMarca = 0;
           try
           {
               this.OpenConn();

               var bus = (from a in db.Marcas_Personal
                          where a.Id_Usuario == _UsuarioId
                          && a.Fecha.Year == DateTime.Today.Year
                          && a.Fecha.Month == DateTime.Today.Month
                          && a.Fecha.Day == DateTime.Today.Day
                          select a).Count() ;

               intRegistrosMarca = bus;


           }
           catch (Exception ex)
           {
               MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               this.CloseConn();
           }
         return intRegistrosMarca;
       }

       /// <summary>
       /// Función Encargada de Mostrar la cantidad de Salidas por Medio del Usuario
       /// </summary>
       /// <returns>Cantidad de Registros Marca </returns>
       public int ObtengoSalida()
       {
           int intRegistrosMarca = 0;
           try
           {
               this.OpenConn();

               var bus = (from a in db.Marcas_Personal
                          where a.Id_Usuario == _UsuarioId
                          && a.Hora_Salida != null
                          && a.Fecha.Year == DateTime.Today.Year
                          && a.Fecha.Month == DateTime.Today.Month
                          && a.Fecha.Day == DateTime.Today.Day
                          select a).Count();

               intRegistrosMarca = bus;


           }
           catch (Exception ex)
           {
               MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           finally
           {
               this.CloseConn();
           }
           return intRegistrosMarca;
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
