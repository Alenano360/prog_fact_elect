using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Cliente
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellido;

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private string _Contacto;

        public string Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }
        public decimal _limite_credito;

        public decimal limite_credito
        {
            get { return _limite_credito; }
            set { _limite_credito = value; }

        }
        private string _Cedula;

        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }

        private string _Telefono1;

        public string Telefono1
        {
            get { return _Telefono1; }
            set { _Telefono1 = value; }
        }

        private string _Telefono2;

        public string Telefono2
        {
            get { return _Telefono2; }
            set { _Telefono2 = value; }
        }

        private decimal _Saldo;

        public decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private decimal _Saldo2;

        public decimal Saldo2
        {
            get { return _Saldo2; }
            set { _Saldo2 = value; }
        }

        private Int64 _FacturaId;

        public Int64 FacturaId
        {
            get { return _FacturaId; }
            set { _FacturaId = value; }
        }

        private decimal _MontoFactura;

        public decimal MontoFactura
        {
            get { return _MontoFactura; }
            set { _MontoFactura = value; }
        }
        
        #endregion

        #region Metodos

        public void ObtieneClientes(ComboBox cmb)
        {
            try
            {
                this.OpenConn();
              

                var bus = (from c in db.Clientes
                          where c.Activo == true
                          orderby c.Id ascending
                          select new {c.Id,Nombre=c.Nombre+" "+(c.Apellidos==null?"":c.Apellidos) });

                if (bus.Count() > 0)
                {
                    cmb.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void actualizar_limite_credito(String Nombre,String apellidos,String limite) {
            try
            {
                this.OpenConn();
                var bus = (from c in db.Clientes
                          where (c.Nombre == Nombre) && (c.Apellidos == apellidos)
                          select c).First();
                bus.Limite_credito = Convert.ToDecimal(limite);
               
              //  MessageBox.Show("el nombre es " + bus.Nombre);
                db.SubmitChanges();
                this.CloseConn();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
       
        }
        public void ObtieneClientes(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = from c in db.Clientes
                          where c.Activo == true
                          orderby c.Nombre ascending
                          select c;

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneClienteBusqueda(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                dgv.Columns[0].Visible = true;

                var bus = (from f in db.Clientes
                           where f.Activo == true && (f.Nombre.Contains(_Nombre) || f.Apellidos.Contains(_Nombre) || f.Cedula.Contains(_Nombre) || f.Contacto.Contains(_Nombre) || f.Telefono1.Contains(_Nombre))
                           orderby f.Nombre ascending
                           select f);

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                dgv.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneProductoClienteOrdenada(DataGridView dgv, string Busqueda)
        {
            try
            {
                this.OpenConn();

                dgv.Columns[0].Visible = true;

                switch (Busqueda)
                {
                    case "Nombre":
                        {
                            var bus = (from x in db.Clientes
                                       where x.Activo == true
                                       orderby x.Nombre ascending
                                       select x);

                            

                            if (bus.Count() > 0)
                            {
                                dgv.AutoGenerateColumns = false;
                                dgv.DataSource = bus;
                            }
                            break;
                        }
                    case "Apellido":
                        {
                            var bus = (from x in db.Clientes
                                       where x.Activo == true
                                       orderby x.Apellidos ascending
                                       select x);

                            if (bus.Count() > 0)
                            {
                                dgv.AutoGenerateColumns = false;
                                dgv.DataSource = bus;
                            }
                            break;
                        }
                    case "Cédula":
                        {
                            var bus = (from x in db.Clientes
                                       where x.Activo == true
                                       orderby x.Cedula ascending
                                       select x); 
                            
                            if (bus.Count() > 0)
                            {
                                dgv.AutoGenerateColumns = false;
                                dgv.DataSource = bus;
                            }
                            break;
                        }
                    case "Saldo":
                        {
                            var bus = (from x in db.Clientes
                                       where x.Activo == true
                                       orderby x.Saldo descending
                                       select x);

                            if (bus.Count() > 0)
                            {
                                dgv.AutoGenerateColumns = false;
                                dgv.DataSource = bus;
                            }
                            break;
                        }
                    default:
                        break;
                }

                dgv.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneClienteBusqueda()
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.Clientes
                           where f.Activo == true && f.Id == _Id
                           orderby f.Id ascending
                           select new { f.Nombre,
                               Apellidos=(f.Apellidos==null?"":f.Apellidos),
                               Contacto=(f.Contacto==null?"":f.Contacto),
                               f.Cedula,
                               Telefono1=(f.Telefono1==null?"":f.Telefono1),
                               Telefono2=(f.Telefono2==null?"":f.Telefono2),
                               f.Saldo,
                               f.FechaCreacion,
                               f.Limite_credito
                           });

                if (bus.Count() > 0)
                {
                    var bu=bus.First();

                    _Nombre = bu.Nombre;
                    _Apellido = bu.Apellidos;
                    _Contacto = bu.Contacto;
                    _Cedula = bu.Cedula;
                    _Saldo = bu.Saldo;
                    _Telefono1 = bu.Telefono1;
                    _Telefono2 = bu.Telefono2;
                    _limite_credito =Convert.ToDecimal(bu.Limite_credito);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool AgregaCliente(int UserId)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.Clientes _NewCliente = new PuntoVentaDAL.Clientes();

                _NewCliente.Nombre = _Nombre;
                _NewCliente.Apellidos = _Apellido;
                _NewCliente.Contacto = _Contacto;
                _NewCliente.Cedula = _Cedula;
                _NewCliente.Telefono1 = _Telefono1;
                _NewCliente.Telefono2 = _Telefono2;
                _NewCliente.Saldo = _Saldo;
                _NewCliente.Activo = true;
                _NewCliente.UsuarioId = UserId;
                _NewCliente.FechaCreacion = System.DateTime.Now;
                
                if (_Saldo>0)
                {
                    PuntoVentaDAL.BitacoraCreditoCliente _Newbit = new PuntoVentaDAL.BitacoraCreditoCliente();
                    

                    _Newbit.UsuarioId = UserId;
                    _Newbit.Monto = _Saldo;
                    _Newbit.FechaCreacion = System.DateTime.Now;

                    _NewCliente.BitacoraCreditoCliente.Add(_Newbit);

                    var equipo = (from e in db.Equipos
                                  where e.NombreEquipo == System.Environment.MachineName.ToString()
                                  select e).First();

                    var cajadiaria = (from cd in db.CajaDiarias
                                      where cd.EquipoId == equipo.Id
                                      && cd.Activo == true && cd.Visible == true
                                      orderby cd.Id ascending
                                      select cd).First();

                    PuntoVentaDAL.CajaDiaria _newCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                    _newCajaDiaria.MovimientoId = 10;
                    _newCajaDiaria.Descripcion = "Déposito de dinero del usuario: "+_Nombre +" "+_Apellido;
                    _newCajaDiaria.ComprobanteId = 0;
                    _newCajaDiaria.Monto = _Saldo;
                    _newCajaDiaria.Saldo = _Saldo + cajadiaria.Saldo;                   
                    _newCajaDiaria.UsuarioId = UserId;
                    _newCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    _newCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                    _newCajaDiaria.EquipoId = equipo.Id;
                    _newCajaDiaria.Activo = true;
                    _newCajaDiaria.Visible = true;

                    db.CajaDiarias.InsertOnSubmit(_newCajaDiaria);
                }
                
                db.Clientes.InsertOnSubmit(_NewCliente);

                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool GuardaBitacoraCreditoCliente(int UserId)
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.BitacoraCreditoCliente _NewCliente = new PuntoVentaDAL.BitacoraCreditoCliente();

                _NewCliente.UsuarioId = UserId;
                _NewCliente.Monto = _Saldo;
                _NewCliente.FechaCreacion = System.DateTime.Now;
                
                db.BitacoraCreditoClientes.InsertOnSubmit(_NewCliente);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el artículo al inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool ModificaCliente(int UserId)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Clientes
                           where x.Activo == true && x.Id == Id
                           orderby x.Nombre ascending
                           select x).First();
                
                bus.Nombre = _Nombre;
                bus.Apellidos = _Apellido;
                bus.Contacto = _Contacto;
                bus.Cedula = _Cedula;
                bus.Telefono1 = _Telefono1;
                bus.Telefono2 = _Telefono2;
                bus.Saldo = _Saldo;

                if (_Saldo2 > 0)
                {
                    PuntoVentaDAL.BitacoraCreditoCliente _Newbit = new PuntoVentaDAL.BitacoraCreditoCliente();

                    _Newbit.UsuarioId = UserId;
                    _Newbit.Monto = _Saldo2;
                    _Newbit.FechaCreacion = System.DateTime.Now;

                    bus.BitacoraCreditoCliente.Add(_Newbit);

                    var equipo = (from e in db.Equipos
                                  where e.NombreEquipo == System.Environment.MachineName.ToString()
                                  select e).First();

                    var cajadiaria = (from cd in db.CajaDiarias
                                      where cd.Activo == true  && cd.Visible==true&& cd.EquipoId == equipo.Id
                                      orderby cd.Id descending
                                      select cd).First();

                    PuntoVentaDAL.CajaDiaria _newCajaDiaria = new PuntoVentaDAL.CajaDiaria();
                    _newCajaDiaria.MovimientoId = 10;
                    _newCajaDiaria.Descripcion = "Déposito de dinero del usuario: " + _Nombre + " " + _Apellido;
                    _newCajaDiaria.ComprobanteId = 0;
                    _newCajaDiaria.Monto = _Saldo2;
                    _newCajaDiaria.Saldo = _Saldo2+cajadiaria.Saldo;
                    _newCajaDiaria.UsuarioId = UserId;
                    _newCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    _newCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                    _newCajaDiaria.EquipoId = equipo.Id;
                    _newCajaDiaria.Activo = true;
                    _newCajaDiaria.Visible = true;

                    db.CajaDiarias.InsertOnSubmit(_newCajaDiaria);
                    
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool EliminaCliente(int UserId)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Clientes
                           where x.Activo == true && x.Id == Id
                           orderby x.Nombre ascending
                           select x).First();

                bus.Activo = false;
                bus.UsuarioId = UserId;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public void AgregaCreditoCliente(int UserId)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Clientes
                           where x.Activo == true && x.Id == _Id
                           orderby x.Nombre ascending
                           select x).First();

                bus.Saldo -= _MontoFactura;

                PuntoVentaDAL.BitacoraCreditoCliente _NewBitacora = new PuntoVentaDAL.BitacoraCreditoCliente();
                _NewBitacora.UsuarioId = UserId;
                _NewBitacora.ClienteId = _Id;
                _NewBitacora.FacturaId = _FacturaId;
                _NewBitacora.Monto = -_MontoFactura;
                _NewBitacora.FechaCreacion = System.DateTime.Now;

                db.BitacoraCreditoClientes.InsertOnSubmit(_NewBitacora);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el crédito al cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
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
