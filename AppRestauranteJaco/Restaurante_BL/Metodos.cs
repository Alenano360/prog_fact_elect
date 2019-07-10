using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Restaurante_BL
{
   public class Metodos
    {
       Restaurante_DAL.Conexionn cone=new Restaurante_DAL.Conexionn();
       SqlDataAdapter da;
       SqlCommand cmd;
       SqlDataReader dr;

       public String ingresar_articlos(String query){
           return cone.EjecutarSql(query);
       }

       public String eliminar_usuario(String query)
       {
           return cone.EjecutarSql2(query);
       }

       public String obtener_precio_genericos(String precio,int codigo)
       {
           String respuesta="1"; 
           try
           {
               String query = "update Articulo set costo="+precio+" where ID="+codigo+"";
               cone.EjecutarSql(query);
               return respuesta;
           }
           catch (Exception error)
           {
               return "Hubo un error " + error.Message;
           }

           

       }

       public String validar_tipo(int codigo)
       {
           String respuesta = "1";
           try
           {
               String query = "select *from Articulo where tipo=2 and ID="+codigo+"";
               cone.conectar();
               cmd = new SqlCommand(query, cone.MiConexion);
               dr = cmd.ExecuteReader();

               while (dr.Read())
               {
                   respuesta = "2";
               }
               dr.Close();
               cone.desconectar();
               return respuesta;
           }
           catch (Exception error)
           {
               return "Hubo un error "+error.Message;

           }

          
       }

       public String estado_normal(int codigo)
       {
           String respesta = "1";
           try
           {
               String query = "update Articulo set costo=0.00 where id="+codigo+"";
               cone.EjecutarSql(query);
               return respesta;
           }
           catch (Exception error)
           {
               return "Hubo un error " + error.Message;
           }

       }


       public String    sacar_precio(int codigo)
       {
           String respuesta = "0";
           try
           {
               String query = "select costo from Articulo where ID="+codigo+"";
               cone.conectar();
               cmd = new SqlCommand(query, cone.MiConexion);
               dr = cmd.ExecuteReader();

               while (dr.Read())
               {
                   respuesta = dr[0].ToString();
               }
               dr.Close();
               cone.desconectar();
               return respuesta;
           }
           catch (Exception error)
           {
               return "Hubo un error " + error.Message;

           }


       }
    }
}
