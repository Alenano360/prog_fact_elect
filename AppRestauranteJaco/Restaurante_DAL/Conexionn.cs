using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace Restaurante_DAL
{
   public  class Conexionn
    {
       public SqlConnection MiConexion;
       public void conectar()
       {
           try
           {
      
            //***************conexion administrador************
            MiConexion = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RestauranteApp;User ID=saputazo;Password=saputazo");

            //********************************Mi conexion********************************************************
            //        MiConexion = new SqlConnection(@"Data Source=EQUIPO-RICARDO\SQLEXPRESSR2;Initial Catalog=RestauranteApp;User ID=sa;Password=123");

            //Nueva conexion ariel duran
            //   MiConexion = new SqlConnection(@"Data Source=DESKTOP-NQV25SV;Initial Catalog=RestauranteApp;User ID=sa;Password=sa2015");
              
            MiConexion.Open();

           }
           catch (Exception ex)
           {

           }
       }

       public void desconectar()
       {
           MiConexion.Close();
       }

       public string EjecutarSql(String query)
       {
           String respuesta = "";

           try
           {
               conectar();
               SqlCommand comando = new SqlCommand(query, MiConexion);
               int filas_afectadas = comando.ExecuteNonQuery();
               if (filas_afectadas > 0)
               {
                   respuesta = "Artículo agregado con éxito";
               }
               else
               {
                   respuesta = "No se pudo realizar la modificación de la base de datos  Error del sistema";
               }
           }
           catch (Exception ex)
           {
               respuesta = ex.ToString();
           }
           return respuesta;

       }

       public string EjecutarSql2(String query)
       {
           String respuesta = "";

           try
           {
               conectar();
               SqlCommand comando = new SqlCommand(query, MiConexion);
               int filas_afectadas = comando.ExecuteNonQuery();
               if (filas_afectadas > 0)
               {
                   respuesta = "Usuario eliminado con exito";
               }
               else
               {
                   respuesta = "No se pudo realizar la modificación de la base de datos  Error del sistema";
               }
           }
           catch (Exception ex)
           {
               respuesta = ex.ToString();
           }
           return respuesta;

       }

    }
}
