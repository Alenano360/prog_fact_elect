using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class ModuloPrincipal
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region propiedades
        #endregion

        #region metodos
     
        public void RegistraMaquina(int id)
        {
            try
            {
                this.OpenConn();
                Console.Out.WriteLine(System.Environment.MachineName.ToString());
                var bus = (from x in db.Equipos
                           where x.NombreEquipo == System.Environment.MachineName.ToString()
                           select x);
                
                if (bus.Count()==0)
                {
                    PuntoVentaDAL.Equipo _NewEquipo = new PuntoVentaDAL.Equipo();

                    _NewEquipo.NombreEquipo = System.Environment.MachineName.ToString();                    

                    db.Equipos.InsertOnSubmit(_NewEquipo);
                    
                    db.SubmitChanges();

                    var equipo = (from e in db.Equipos
                                  where e.NombreEquipo == System.Environment.MachineName.ToString()
                                  select e).First();

                    PuntoVentaDAL.CajaDiaria _newCajaDiaria = new PuntoVentaDAL.CajaDiaria();

                    _newCajaDiaria.MovimientoId = 1;
                    _newCajaDiaria.ComprobanteId = 0;
                    _newCajaDiaria.Descripcion = "Apertura de la caja";
                    _newCajaDiaria.Monto = 0;
                    _newCajaDiaria.Saldo = 0;
                    _newCajaDiaria.UsuarioId = id;
                    _newCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    _newCajaDiaria.Hora = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute;
                    _newCajaDiaria.EquipoId = equipo.Id;
                    _newCajaDiaria.Activo = true;
                    _newCajaDiaria.Visible = true;

                    db.CajaDiarias.InsertOnSubmit(_newCajaDiaria);

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la informacion del equipo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool ObtieneCajaDiaria()
        {
            try
            {
                this.OpenConn();

                var bus1 = (from x in db.CajaDiarias//obtengo caja diaria mas reciente 
                            join e in db.Equipos on x.EquipoId equals e.Id
                            where e.NombreEquipo == System.Environment.MachineName.ToString() 
                            orderby x.Id descending
                            select x);

                if (bus1.Count() > 0)//tiene caja 
                {
                    if (bus1.First().MovimientoId == 8)//&& bus1.First().Fecha < Convert.ToDateTime(System.DateTime.Now.ToShortDateString()))//si la fecha de la caja es menor a la actual y esta cerrada
                    {
                        MessageBox.Show("Antes de facturar necesita hacer la apertura de la caja!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    //if ((bus1.First().MovimientoId == 1||bus1.First().MovimientoId != 8) && bus1.First().Fecha < Convert.ToDateTime(System.DateTime.Now.ToShortDateString()))//si la fecha de la caja es menor a la actual y esta abierta
                    //{
                    //    MessageBox.Show("Antes de facturar necesita hacer el cierre de la caja previa!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return false;
                    //}
                }

                var bus = (from x in db.CajaDiarias
                           join e in db.Equipos on x.EquipoId equals e.Id
                           where e.NombreEquipo == System.Environment.MachineName.ToString()
                           orderby x.Id descending
                           select x);//obtengo la caja del dia de hoy mas reciente

                if (bus.Count() > 0)//si hoy no tiene caja
                {
                    if (bus.First().MovimientoId == 8)//&& bus.First().Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()))
                    {
                        MessageBox.Show("Antes de facturar necesita hacer la apertura de la caja!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la informacion del equipo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public bool ObtieneCajaDiariaBotonesAperturaCierre(Button btnApertura,Button btnCierre)
        {
            try
            {
                this.OpenConn();

                var bus1 = (from x in db.CajaDiarias//obtengo caja diaria mas reciente 
                            join e in db.Equipos on x.EquipoId equals e.Id
                            where e.NombreEquipo == System.Environment.MachineName.ToString()
                            orderby x.Id descending
                            select x);

                //if (bus1.Count() > 0)//tiene caja 
                //{
                //    if (bus1.First().MovimientoId == 8 && bus1.First().Fecha < Convert.ToDateTime(System.DateTime.Now.ToShortDateString()))//si la fecha de la caja es menor a la actual y esta cerrada
                //    {
                //        //MessageBox.Show("Antes de facturar necesita hacer la apertura de la caja!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        btnCierre.Enabled = false;
                //        btnApertura.Enabled = true;
                //        return false;
                //    }
                //    if ((bus1.First().MovimientoId == 1 || bus1.First().MovimientoId != 8) && bus1.First().Fecha < Convert.ToDateTime(System.DateTime.Now.ToShortDateString()))//si la fecha de la caja es menor a la actual y esta abierta
                //    {
                //        //MessageBox.Show("Antes de facturar necesita hacer el cierre de la caja previa!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        btnCierre.Enabled = true;
                //        btnApertura.Enabled = false;
                //        return false;
                //    }
                //}

                //var bus = (from x in db.CajaDiarias
                //           join e in db.Equipos on x.EquipoId equals e.Id
                //           where e.NombreEquipo == System.Environment.MachineName.ToString()
                //           orderby x.Id descending
                //           select x);//obtengo la caja del dia de hoy mas reciente

                //if (bus.Count() > 0)//si hoy no tiene caja
                //{
                //    if (bus.First().MovimientoId == 8 && bus.First().Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()))
                //    {
                //        //MessageBox.Show("Antes de facturar necesita hacer la apertura de la caja!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        btnCierre.Enabled = false;
                //        btnApertura.Enabled = true;
                //        return false;
                //    }
                //}
                if (bus1.Count() > 0)
                {
                    if (bus1.First().MovimientoId == 8)//esta cerrada
                    {
                        //MessageBox.Show("Antes de facturar necesita hacer la apertura de la caja!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnCierre.Enabled = false;
                        btnApertura.Enabled = true;
                        return false;
                    }
                    else
                    {
                        btnCierre.Enabled = true;
                        btnApertura.Enabled = false;
                    }
                }
                else
                {
                    btnCierre.Enabled = false;
                    btnApertura.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la informacion del equipo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
            //btnCierre.Enabled = true;
            //btnApertura.Enabled = false;
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
