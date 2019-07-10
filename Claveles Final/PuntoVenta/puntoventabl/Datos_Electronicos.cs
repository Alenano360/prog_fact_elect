using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Datos_Electronicos
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;


        #region Attributos
        public int id_Factura_Local { get; set; }
        public DateTime Fecha { get; set; }
        public String Factura { get; set; }
        public int Monto_Factura { get; set; }
        public bool Cancelada { get; set; }
        public bool Enviada { get; set; }
        #endregion

        public Datos_Electronicos()
        {

        }

        public int Get_Consecutivo_Factura()
        {
            OpenConn();
            int? total = 0;
            db.get_Consect_Factura(ref total);
            int consec = 0;
            if (total.HasValue) { consec = total.Value; }
            return consec+ 1 ;
        }

        public int Get_Consecutivo_Tiquete()
        {
            OpenConn();
            int? total = 0;
            db.get_Consect_Tiquete(ref total);
            int consec = 0;
            if (total.HasValue) { consec = total.Value; }
            return consec + 1;
        }

        public bool Guardar_Factura()
        {

            try
            {
                OpenConn();

                PuntoVentaDAL.Facturas_Electronicas Factura = new PuntoVentaDAL.Facturas_Electronicas();
                Factura.Fecha = this.Fecha;
                Factura.Numero_Factura_Local = this.id_Factura_Local;
                Factura.Monto_Factura = this.Monto_Factura;
                Factura.Enviada = this.Enviada;
                Factura.Cancelada = this.Cancelada;
                Factura.XML_Factura = this.Factura; 

                db.Facturas_Electronicas.InsertOnSubmit(Factura);
                db.SubmitChanges();

                CloseConn();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public List<PuntoVentaDAL.Tiquetes_Electronicos> Buscar_TicketXlocal(int numlocal)
        {
            OpenConn();
            return db.Tiquetes_Electronicos.Where(x => x.Numero_Factura_Local == numlocal).ToList();
        }

        public List<PuntoVentaDAL.Facturas_Electronicas> Buscar_FacturaXlocal(int numlocal)
        {
            OpenConn();
            return db.Facturas_Electronicas.Where(x => x.Numero_Factura_Local == numlocal).ToList();
        }

        public bool Guardar_Tiquete()
        {

            try
            {
                OpenConn();

                PuntoVentaDAL.Tiquetes_Electronicos Tiquete= new PuntoVentaDAL.Tiquetes_Electronicos();
                Tiquete.Fecha = this.Fecha;
                Tiquete.Numero_Factura_Local = this.id_Factura_Local;
                Tiquete.Monto_Factura = this.Monto_Factura;
                Tiquete.Enviada = this.Enviada;
                Tiquete.Cancelada = this.Cancelada;
                Tiquete.XML_Factura = this.Factura;

                db.Tiquetes_Electronicos.InsertOnSubmit(Tiquete);
                db.SubmitChanges();

                CloseConn();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool Editar_Envio_Factura(int id, bool estado )
        {

            try
            {
                OpenConn();

                var bus = (from x in db.Facturas_Electronicas where x.id_FacturaElectronica == id select x).First();
                bus.Enviada = estado;
                db.SubmitChanges(); 
                
                CloseConn();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool Editar_Envio_Tiquete(int id, bool estado )
        {

            try
            {
                OpenConn();

                var bus = (from x in db.Tiquetes_Electronicos where x.id_TiqueteElectronico == id select x).First();
                bus.Enviada = estado;
                db.SubmitChanges();

                CloseConn();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool Cancelar_Factura(int id)
        {

            try
            {
                OpenConn();

                var bus = (from x in db.Facturas_Electronicas where x.id_FacturaElectronica == id select x).First();
                bus.Cancelada = true;
                db.SubmitChanges();

                CloseConn();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }




        public bool Cancelar_Ticket(int id)
        {

            try
            {
                OpenConn();

                var bus = (from x in db.Tiquetes_Electronicos where x.id_TiqueteElectronico== id select x).First();
                bus.Cancelada = true;
                db.SubmitChanges();

                CloseConn();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }



        //Factutas 
        public List<PuntoVentaDAL.Facturas_Electronicas> Get_FacturasXFecha(DateTime desde,DateTime Hasta)
        {
            OpenConn();
            return db.Facturas_Electronicas.Where(x => desde <= x.Fecha && x.Fecha <= Hasta && x.Cancelada == false ).ToList(); 
        }
        public List<PuntoVentaDAL.Facturas_Electronicas> Get_Facturas_NoEnvidas()
        {
            OpenConn();
            return db.Facturas_Electronicas.Where(x => x.Enviada == false && x.Cancelada == false ).ToList();
        }

        public List<PuntoVentaDAL.Facturas_Electronicas> Get_Facturas_Cancelada(DateTime desde, DateTime Hasta)
        {
            OpenConn();
            return db.Facturas_Electronicas.Where(x => x.Cancelada == true && desde <= x.Fecha && x.Fecha <= Hasta ).ToList();
        }


        //Tiquetes 
        public List<PuntoVentaDAL.Tiquetes_Electronicos> Get_TiquetesXFecha(DateTime desde, DateTime Hasta)
        {
            OpenConn();
            return db.Tiquetes_Electronicos.Where(x => desde <= x.Fecha && x.Fecha <= Hasta && x.Cancelada == false).ToList();
        }
        public List<PuntoVentaDAL.Tiquetes_Electronicos> Get_Tiquetes_NoEnviados()
        {
            OpenConn();
            return db.Tiquetes_Electronicos.Where(x => x.Enviada == false && x.Cancelada == false).ToList();
        }

        public List<PuntoVentaDAL.Tiquetes_Electronicos> Get_Tiquetes_Cancelada(DateTime desde, DateTime Hasta)
        {
            OpenConn();
            return db.Tiquetes_Electronicos.Where(x => x.Cancelada == true && desde <= x.Fecha && x.Fecha <= Hasta).ToList();
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
    }
}
