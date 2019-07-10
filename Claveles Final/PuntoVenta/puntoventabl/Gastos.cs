using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Gastos
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades
        private Int64 _Id;

        public Int64 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        
        private Int64 _ComprobanteId;

        public Int64 ComprobanteId
        {
            get { return _ComprobanteId; }
            set { _ComprobanteId = value; }
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

        private int _AutorizaId;

        public int AutorizaId
        {
            get { return _AutorizaId; }
            set { _AutorizaId = value; }
        }
        
        
        
        #endregion

        #region Metodos

        public void ObtieneGastos(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                //var bus = (from cd in db.CajaDiaria
                //           join u in db.Usuario on cd.AutorizadoPor equals u.Id
                //           where cd.Activo == true && cd.MovimientoId == 9
                //           orderby cd.Fecha descending
                //           select new { cd.Id, cd.Fecha, cd.Hora, cd.Descripcion, cd.ComprobanteId, Nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido), cd.Monto });

                var bus = from x in db.ObtieneGastos_Vws
                          join eq in db.Equipos on x.EquipoId equals eq.Id
                          where eq.NombreEquipo == System.Environment.MachineName.ToString() 
                          orderby x.Id descending
                          select x;

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los gastos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }
     
        public void ObtieneUsuarios(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Usuarios
                           where x.Activo == true && (x.RolId == 1 || x.RolId == 2)
                           select new { x.Id,Nombre=x.Nombre+" "+(x.Apellido==null?"":x.Apellido)});

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

        public void ObtieneUsuarios(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Usuarios
                           where x.Activo == true && (x.RolId == 1 || x.RolId == 2)
                           select new { x.Id,  x.Nombre ,Apellido=(x.Apellido == null ? "" : x.Apellido) });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
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

        public void ObtieneUsuarioBusqueda(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Usuarios
                           where x.Activo == true && (x.Nombre.Contains(_Descripcion)|| x.Apellido.Contains(_Descripcion))
                           select new { x.Id, x.Nombre, Apellido = (x.Apellido == null ? "" : x.Apellido) });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
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

        public void ObtieneGastoBusqueda()
        {
            try
            {
                this.OpenConn();

                var bus = (from cd in db.CajaDiarias
                               where cd.Activo==true && cd.Id==_Id
                               select cd).First();

                _Fecha = bus.Fecha;
                _Hora = bus.Hora;
                _Descripcion = bus.Descripcion;
                _Monto = bus.Monto;
                _ComprobanteId = Convert.ToInt64(bus.ComprobanteId);
                _AutorizaId = Convert.ToInt32(bus.AutorizadoPor);
   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los gastos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool AgregaGasto(int UserId)
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
                          && cd.Activo==true && cd.Visible==true
                          orderby cd.Id descending
                          select new {cd.Saldo });

                PuntoVentaDAL.CajaDiaria _NewGasto = new PuntoVentaDAL.CajaDiaria();

                _NewGasto.MovimientoId = 9;
                _NewGasto.Descripcion = "Gasto por "+ _Descripcion;
                _NewGasto.Fecha = _Fecha;
                _NewGasto.Hora = _Hora;
                _NewGasto.Descripcion = _Descripcion;
                _NewGasto.Monto = _Monto;

                if (cde.Count()>0)
	            {
                    _NewGasto.Saldo = cde.First().Saldo - _Monto;
	            }
                else
	            {
                    _NewGasto.Saldo=_Monto;
	            }

                //if (_ComprobanteId!=0)
                //{
                    _NewGasto.ComprobanteId = _ComprobanteId;
                //}
                
                _NewGasto.AutorizadoPor = _AutorizaId;
                _NewGasto.EquipoId = bus.Id;
                _NewGasto.UsuarioId = UserId;
                _NewGasto.Activo = true;
                _NewGasto.Visible = true;

                db.CajaDiarias.InsertOnSubmit(_NewGasto);

                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el gasto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool ModificaGasto(int UserId)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.CajaDiarias
                           where x.Activo == true && x.Id == _Id
                           select x).First();

                bus.Descripcion = _Descripcion;
                bus.Monto = _Monto;
                if (_ComprobanteId != 0)
                {
                    bus.ComprobanteId = _ComprobanteId;
                }
                bus.AutorizadoPor = _AutorizaId;
                bus.UsuarioId = UserId;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el gasto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool EliminaGasto(int UserId)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.CajaDiarias
                           where x.Activo == true && x.Id == _Id
                           select x).First();

                //bus.Activo = false;
                //bus.UsuarioId = UserId;
                //bus.Visible = false;

                db.CajaDiarias.DeleteOnSubmit(bus);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el gasto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
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
