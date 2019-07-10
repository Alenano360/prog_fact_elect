using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class CajaDiaria
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades
        private Int64 _Id;

        public Int64 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }


        private string _ComprobanteId;

        public string ComprobanteId
        {
            get { return _ComprobanteId; }
            set { _ComprobanteId = value; }
        }


        

        private int _MovimientoId;

        public int MovimientoId
        {
            get { return _MovimientoId; }
            set { _MovimientoId = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        
        private decimal _Monto;

        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        private decimal _Saldo;

        public decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private string _Hora;

        public string Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }
        #endregion

        #region Metodos

        public void ObtieneCajaDiaria(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus1 = (from x in db.CajaDiarias
                            join e in db.Equipos on x.EquipoId equals e.Id
                            where e.NombreEquipo == System.Environment.MachineName.ToString()
                            orderby x.Id descending
                            select x);

                var bus = (from cd in db.CajaDiarias
                           join e in db.Equipos on cd.EquipoId equals e.Id
                           join m in db.Movimientos on cd.MovimientoId equals m.Id
                           join u in db.Usuarios on cd.UsuarioId equals u.Id
                           where cd.Activo == true  && e.NombreEquipo == System.Environment.MachineName.ToString()&&cd.Visible==true //&& cd.Fecha == bus1.First().Fecha//obtengo la caja diaria del ultimo dia 
                           select new { cd.Id,Movimiento=m.Descripcion,cd.ComprobanteId,cd.Descripcion,cd.Monto,cd.Saldo,Nombre=u.Nombre+" "+(u.Apellido==null?"":u.Apellido),Fecha=cd.Fecha.ToShortDateString(),cd.Hora,cd.MovimientoId,cd.AutorizadoPor });

                if (bus.Count()==0)
                {
                    return;
                }
                           
                //var apertura = (from x in db.CajaDiarias
                  //              where x.Activo == true && x.Visible == true && x.MovimientoId == 1
                    //            select x).First();
                var apertura = (from x in db.CajaDiarias
                               join e in db.Equipos on x.EquipoId equals e.Id
                               where x.Activo== true && x.Visible==true && x.MovimientoId==1 && e.NombreEquipo== System.Environment.MachineName.ToString()
                               select x).First();
                decimal temp = 0;

                temp += apertura.Saldo;
                
                foreach (var item in bus)
                {
                    if (item.MovimientoId == 2 || item.MovimientoId == 5 || item.MovimientoId == 6 || item.MovimientoId == 10)
                    {
                        var elemento = (from cd in db.CajaDiarias
                                        where cd.Id == item.Id
                                        select cd).First();

                        temp += item.Monto;

                        elemento.Saldo = temp;

                        db.SubmitChanges();
                    }

                    if (item.MovimientoId == 3 || item.MovimientoId == 4 || item.MovimientoId == 7 || item.MovimientoId == 9)
                    {
                        var elemento = (from cd in db.CajaDiarias
                                        where cd.Id == item.Id
                                        select cd).First();

                        temp -= item.Monto;

                        elemento.Saldo = temp;

                        db.SubmitChanges();
                    }

                        //var suma = from x in db.CajaDiarias
                        //           where x.Activo == true && x.Visible == true && (x.MovimientoId == 2 || x.MovimientoId == 5 || x.MovimientoId == 6 || x.MovimientoId == 10)
                        //           select x.Monto;

                        //if (suma.Count()>0)
                        //{
                        //    sumas = suma.Sum();
                        //}

                        //var resta = from x in db.CajaDiarias
                        //            where x.Activo == true && x.Visible == true && (x.MovimientoId == 3 || x.MovimientoId == 4 || x.MovimientoId == 7 || x.MovimientoId == 9)
                        //            select x.Monto;

                        //if (resta.Count() > 0)
                        //{
                        //    restas = resta.Sum();
                        //}

                        //var apertura = (from x in db.CajaDiarias
                        //                where x.Activo == true && x.Visible == true && x.MovimientoId == 1
                        //                select x).First();


                        //decimal total = apertura.Saldo + sumas - restas;
                }

                bus = (from cd in db.CajaDiarias
                       join e in db.Equipos on cd.EquipoId equals e.Id
                       join m in db.Movimientos on cd.MovimientoId equals m.Id
                       join u in db.Usuarios on cd.UsuarioId equals u.Id
                       where cd.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && cd.Visible == true //&& cd.Fecha == bus1.First().Fecha//obtengo la caja diaria del ultimo dia 
                       select new { cd.Id, Movimiento = m.Descripcion, cd.ComprobanteId, cd.Descripcion, cd.Monto, cd.Saldo, Nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido), Fecha = cd.Fecha.ToShortDateString(), cd.Hora, cd.MovimientoId, cd.AutorizadoPor });

                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los movimientos de caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneCajaDiariaBusquedaComprobante(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus1 = (from x in db.CajaDiarias
                            join e in db.Equipos on x.EquipoId equals e.Id
                            where e.NombreEquipo == System.Environment.MachineName.ToString()
                            orderby x.Id descending
                            select x);

                var bus = (from cd in db.CajaDiarias
                           join e in db.Equipos on cd.EquipoId equals e.Id
                           join m in db.Movimientos on cd.MovimientoId equals m.Id
                           join u in db.Usuarios on cd.UsuarioId equals u.Id
                           where cd.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && (cd.ComprobanteId.ToString() == (_ComprobanteId) || cd.FacturaId == _ComprobanteId)&&cd.Visible==true// && cd.Fecha == bus1.First().Fecha//obtengo la caja diaria del ultimo dia 
                           select new { cd.Id, Movimiento = m.Descripcion, cd.ComprobanteId, cd.Descripcion, cd.Monto, cd.Saldo, Nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido), Fecha=cd.Fecha.ToShortDateString(), cd.Hora, cd.MovimientoId, cd.AutorizadoPor });

                //if (bus.Count() > 0)
                //{
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los movimientos de caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneCajaDiariaBusquedaMovimiento(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus1 = (from x in db.CajaDiarias
                            join e in db.Equipos on x.EquipoId equals e.Id
                            where e.NombreEquipo == System.Environment.MachineName.ToString()
                            orderby x.Id descending
                            select x);

                var bus = (from cd in db.CajaDiarias
                           join e in db.Equipos on cd.EquipoId equals e.Id
                           join m in db.Movimientos on cd.MovimientoId equals m.Id
                           join u in db.Usuarios on cd.UsuarioId equals u.Id
                           where cd.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && m.Id == _MovimientoId && cd.Visible == true// && cd.Fecha == bus1.First().Fecha//obtengo la caja diaria del ultimo dia 
                           select new { cd.Id, Movimiento = m.Descripcion, cd.ComprobanteId, cd.Descripcion, cd.Monto, cd.Saldo, Nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido), Fecha=cd.Fecha.ToShortDateString(), cd.Hora, cd.MovimientoId, cd.AutorizadoPor });

                //if (bus.Count() > 0)
                //{
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los movimientos de caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneCajaDiariaOrdenada(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus1 = (from x in db.CajaDiarias
                            join e in db.Equipos on x.EquipoId equals e.Id
                            where e.NombreEquipo == System.Environment.MachineName.ToString()
                            orderby x.Id descending
                            select x);

                var bus = (from cd in db.CajaDiarias
                           join e in db.Equipos on cd.EquipoId equals e.Id
                           join m in db.Movimientos on cd.MovimientoId equals m.Id
                           join u in db.Usuarios on cd.UsuarioId equals u.Id
                           where cd.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && cd.Visible == true //&& cd.Fecha == bus1.First().Fecha//obtengo la caja diaria del ultimo dia 
                           select new { cd.Id, Movimiento = m.Descripcion, cd.ComprobanteId, cd.Descripcion, cd.Monto, cd.Saldo, Nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido), Fecha=cd.Fecha.ToShortDateString(), cd.Hora, cd.MovimientoId, cd.AutorizadoPor });

                switch (_Descripcion)
                {
                    case "Movimiento":
                        {
                            bus = from x in bus
                                  orderby x.Movimiento ascending
                                  select x;
                            break;
                        }
                    case "Comprobante":
                        {
                            bus = from x in bus
                                  orderby x.ComprobanteId descending
                                  select x;
                            break;
                        }
                    case "Fecha":
                        {
                            bus = from x in bus
                                  orderby x.ComprobanteId descending
                                  select x;
                            break;
                        }
                    case "Monto":
                        {
                            bus = from x in bus
                                  orderby x.Monto descending
                                  select x;
                            break;
                        }

                    default:
                        break;
                }

                //if (bus.Count() > 0)
                //{
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los movimientos de caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void CierreCajaDiaria(int UserId)
        {
            try
            {
                this.OpenConn();

                var equipo = (from e in db.Equipos
                              where e.NombreEquipo == System.Environment.MachineName.ToString()
                              select e).First();

                //var bus1 = (from x in db.CajaDiarias
                //            join e in db.Equipos on x.EquipoId equals e.Id
                //            where e.NombreEquipo == System.Environment.MachineName.ToString()
                //            orderby x.Id descending
                //            select x);

                //var bus = (from cd in db.CajaDiarias
                //           join e in db.Equipos on cd.EquipoId equals e.Id
                //           join m in db.Movimientos on cd.MovimientoId equals m.Id
                //           join u in db.Usuarios on cd.UsuarioId equals u.Id
                //           where cd.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && cd.Visible == true && cd.Visible==true //&& cd.Fecha == bus1.First().Fecha//obtengo la caja diaria del ultimo dia 
                //           orderby cd.Id descending
                //           select new { Movimiento = m.Descripcion, cd.ComprobanteId, cd.Descripcion, cd.Monto, cd.Saldo, Nombre = u.Nombre + (u.Apellido == null ? "" : u.Apellido), Fecha=cd.Fecha.ToShortDateString(), cd.Hora }).First();

                //var saldoinicial = (from cd in db.CajaDiarias
                //                    join e in db.Equipos on cd.EquipoId equals e.Id
                //                    where cd.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && cd.Visible == true && cd.MovimientoId == 1 //&& cd.Fecha == bus1.First().Fecha 
                //                    orderby cd.Id descending
                //                    select new { cd.Saldo}).First();

                //var sumas= (from cd in db.CajaDiarias
                //                    join e in db.Equipos on cd.EquipoId equals e.Id
                //            where cd.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && cd.Visible == true && cd.Visible == true && (cd.MovimientoId == 2 || cd.MovimientoId == 6 || cd.MovimientoId == 10) //&& cd.Fecha == bus1.First().Fecha
                //                    select cd.Monto);

                //var restas = (from cd in db.CajaDiarias
                //              join e in db.Equipos on cd.EquipoId equals e.Id
                //              where cd.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && cd.Visible == true && (cd.MovimientoId == 3 || cd.MovimientoId == 4 || cd.MovimientoId == 7 || cd.MovimientoId == 9) //&& cd.Fecha == bus1.First().Fecha
                //              select cd.Monto);


                decimal sumas = 0;
                decimal restas = 0;

                //var apertura = (from x in db.CajaDiarias
                //                join e in db.Equipos on x.EquipoId equals e.Id
                //                where x.Activo == true && x.Visible == true && x.MovimientoId == 1 && e.NombreEquipo == System.Environment.MachineName.ToString()
                //                select x).First();

                var suma = from x in db.CajaDiarias
                           join e in db.Equipos on x.EquipoId equals e.Id
                           where x.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && x.Visible == true && (x.MovimientoId == 2 || x.MovimientoId == 5 || x.MovimientoId == 6 || x.MovimientoId == 10)
                           select x.Monto;

                if (suma.Count() > 0)
                {
                    sumas = suma.Sum();
                }

                var resta = from x in db.CajaDiarias
                            join e in db.Equipos on x.EquipoId equals e.Id
                            where x.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && x.Visible == true && (x.MovimientoId == 3 || x.MovimientoId == 4 || x.MovimientoId == 7 || x.MovimientoId == 9)
                            select x.Monto;

                if (resta.Count() > 0)
                {
                    restas = resta.Sum();
                }

                var apertura = (from x in db.CajaDiarias
                                join e in db.Equipos on x.EquipoId equals e.Id
                                where x.Activo == true && e.NombreEquipo == System.Environment.MachineName.ToString() && x.Visible == true && x.MovimientoId == 1
                                select x).First();


                decimal total = apertura.Saldo + sumas - restas;

                PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                _NewCajaDiaria.MovimientoId = 8;
                _NewCajaDiaria.ComprobanteId = 0;
                _NewCajaDiaria.Descripcion = "Cierre de caja";
                _NewCajaDiaria.Monto = 0;
                //if (sumas.Count()>0)
                //{
                //    if (restas.Count()==0)
                //    {
                //        _NewCajaDiaria.Saldo = saldoinicial.Saldo+ sumas.Sum();
                //    }
                //    else
                //    {
                //        _NewCajaDiaria.Saldo = saldoinicial.Saldo + sumas.Sum() - restas.Sum();  
                //    }                      
                //}
                //else
                //{
                //    if (restas.Count() == 0)
                //    {
                //        _NewCajaDiaria.Saldo = saldoinicial.Saldo;
                //    }
                //    else
                //    {
                //        _NewCajaDiaria.Saldo = saldoinicial.Saldo - restas.Sum();
                //    }                    
                //}
                _NewCajaDiaria.Saldo = total;




                _NewCajaDiaria.UsuarioId = UserId;
                _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                _NewCajaDiaria.EquipoId = equipo.Id;
                _NewCajaDiaria.Activo = true;
                _NewCajaDiaria.Visible = true;

                db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                db.SubmitChanges();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el cierre de la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void AperturaCajaDiaria(int UserId)
        {
            try
            {
                this.OpenConn();

                var equipo = (from e in db.Equipos
                              where e.NombreEquipo == System.Environment.MachineName.ToString()
                              select e).First();

                //var bus1 = (from cd in db.CajaDiarias
                //            join e in db.Equipos on cd.EquipoId equals e.Id
                //            where e.NombreEquipo == System.Environment.MachineName.ToString()
                //            && cd.Activo == true && cd.Visible == true
                //            orderby cd.Id descending
                //            select cd);

                //var bus = (from cd in db.CajaDiarias
                //           join e in db.Equipos on cd.EquipoId equals e.Id
                //           join m in db.Movimientos on cd.MovimientoId equals m.Id
                //           join u in db.Usuarios on cd.UsuarioId equals u.Id
                //           where cd.Activo == true &&cd.Visible==true && e.NombreEquipo == System.Environment.MachineName.ToString() && cd.Fecha == bus1.First().Fecha//obtengo la caja diaria del ultimo dia 
                //           orderby cd.Id descending
                //           select new { Movimiento = m.Descripcion, cd.ComprobanteId, cd.Descripcion, cd.Monto, cd.Saldo, Nombre = u.Nombre + (u.Apellido == null ? "" : u.Apellido), cd.Fecha, cd.Hora }).First();

                //var sumas = (from cd in db.CajaDiarias
                //             join e in db.Equipos on cd.EquipoId equals e.Id
                //             where cd.Activo == true &&cd.Visible==true&& e.NombreEquipo == System.Environment.MachineName.ToString() && cd.Fecha == bus1.First().Fecha && (cd.MovimientoId == 2 || cd.MovimientoId == 6 || cd.MovimientoId == 10)
                //             select cd.Monto);

                //var restas = (from cd in db.CajaDiarias
                //              join e in db.Equipos on cd.EquipoId equals e.Id
                //              where cd.Activo == true &&cd.Visible==true&& e.NombreEquipo == System.Environment.MachineName.ToString() && cd.Fecha == bus1.First().Fecha && (cd.MovimientoId == 3 || cd.MovimientoId == 4 || cd.MovimientoId == 7 || cd.MovimientoId == 9)
                //              select cd.Monto);

                PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                _NewCajaDiaria.MovimientoId = 1;
                _NewCajaDiaria.ComprobanteId = 0;
                _NewCajaDiaria.Descripcion = "Apertura de caja";
                _NewCajaDiaria.Monto = 0;
                //if (sumas.Count() > 0)
                //{
                //    if (restas.Count() == 0)
                //    {
                //        _NewCajaDiaria.Saldo = sumas.Sum();
                //    }
                //    else
                //    {
                //        _NewCajaDiaria.Saldo = sumas.Sum() - restas.Sum();
                //    }

                //}
                //else
                //{
                    //_NewCajaDiaria.Saldo = 0;
                    _NewCajaDiaria.Saldo = _Saldo;
                    
                //}
                _NewCajaDiaria.UsuarioId = UserId;
                _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                _NewCajaDiaria.EquipoId = equipo.Id;
                _NewCajaDiaria.Activo = true;
                _NewCajaDiaria.Visible = true;

                db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar la apertura de la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void AgregaMovimiento(int UserId)
        {
            try
            {
                this.OpenConn();

                var bus = (from e in db.Equipos
                           where e.NombreEquipo == System.Environment.MachineName.ToString()
                           select e).First();

                var cde = (from cd in db.CajaDiarias
                           join e in db.Equipos on cd.EquipoId equals e.Id
                           where e.NombreEquipo == System.Environment.MachineName.ToString()
                           && cd.Activo == true && cd.Visible == true
                           orderby cd.Id descending
                           select new { cd.Saldo });

                PuntoVentaDAL.CajaDiaria _NewMovimiento = new PuntoVentaDAL.CajaDiaria();

                _NewMovimiento.MovimientoId = _MovimientoId;
                _NewMovimiento.ComprobanteId = 0;
                _NewMovimiento.Monto = _Monto;
                if (_MovimientoId==4)//retiro
                {
                    _NewMovimiento.Descripcion = "Retiro de dinero por motivo: " + _Descripcion;
                    if (cde.Count() > 0)
                    {
                        _NewMovimiento.Saldo = cde.First().Saldo - _Monto;
                    }
                    else
                    {
                        _NewMovimiento.Saldo = _Monto;
                    }
                }

                if (_MovimientoId==6)//reintegro
                {
                    _NewMovimiento.Descripcion = "Reintegro de dinero por motivo: " + _Descripcion;
                    if (cde.Count() > 0)
                    {
                        _NewMovimiento.Saldo = cde.First().Saldo + _Monto;
                    }
                    else
                    {
                        _NewMovimiento.Saldo = _Monto;
                    }
                }
                _NewMovimiento.UsuarioId = UserId;
                
                _NewMovimiento.Fecha = _Fecha;

                _NewMovimiento.Hora = _Hora;                

                _NewMovimiento.EquipoId = bus.Id;

                _NewMovimiento.Activo = true;

                _NewMovimiento.Visible = true;

                db.CajaDiarias.InsertOnSubmit(_NewMovimiento);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el movimiento de la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUsuario(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Usuarios
                           where x.Activo == true
                           select new { x.Id, Nombre = x.Nombre + " " + (x.Apellido == null ? "" : x.Apellido) });

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

        public void ApagaCajaDiaria()
        {
            try
            {
                this.OpenConn();

                var bus = (from cd in db.CajaDiarias
                           where cd.Activo == true && cd.Visible == true && cd.Id == _Id
                           select cd).First();

                bus.Visible = false;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar hacer el cierre de la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void EliminaRegistroCajaDiara()
        {
            try
            {
                this.OpenConn();

                var bus = (from cd in db.CajaDiarias
                           where cd.Id == _Id
                           select cd).First();

                var bus2 = (from cd in db.FacturaEncabezado
                            where cd.Id == Convert.ToInt32(bus.ComprobanteId)
                            select cd).First();

                bus2.Activo = false;



                db.CajaDiarias.DeleteOnSubmit(bus);

              
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el registro de la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
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
