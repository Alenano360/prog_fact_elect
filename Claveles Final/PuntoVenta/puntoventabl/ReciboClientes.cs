using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
   public class ReciboClientes
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades

        private bool _Activo;

        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int _ClienteId;

        public int ClienteId
        {
            get { return _ClienteId; }
            set { _ClienteId = value; }
        }

        private string _TotalLetras;

        public string TotalLetras
        {
            get { return _TotalLetras; }
            set { _TotalLetras = value; }
        }

       
        public decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }

        }
        private string _Concepto;

        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private decimal _SaldoAnterior;

        public decimal SaldoAnterior
        {
            get { return _SaldoAnterior; }
            set { _SaldoAnterior = value; }
        }
        private decimal _Abono;

        public decimal Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }
        private decimal _SaldoActual;

        public decimal SaldoActual
        {
            get { return _SaldoActual; }
            set { _SaldoActual = value; }
        }

        private int _TipoPago;

        public int TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private DateTime _FechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }

        private string _Result;

        public string Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        private string _Cuenta;

        public string Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }
        #endregion

        #region Metodos

        public void ObtieneRecibos(TextBox cmb)
        {
            //try
            //{
                this.OpenConn();


                var bus = (from c in db.ReciboCliente                                                     
                           orderby c.Id descending
                           select new { c.Id});

                if (bus.Count() > 0)
                {
                    int Siguiente = Convert.ToInt32(cmb.Text = Convert.ToString(bus.First().Id))+1;
                    if (Siguiente < 10)
                    {
                        cmb.Text = "00" + Convert.ToString(Siguiente);
                    }
                    else
                    {
                        cmb.Text = "0" + Convert.ToString(Siguiente);
                    }
                  
                }
                else
                {
                    cmb.Text = "001";
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hubo un inconveniente al intentar obtener los recibos del cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    this.CloseConn();
            //}
        }
        public void obtenerultimo_abono()
        {
            try
            {
                this.OpenConn();

                var bus = (from c in db.ReciboCliente
                           join e in db.Clientes on c.ClienteId equals e.Id
                           where c.Activo == true && c.ClienteId == ClienteId && c.Cuenta==_Cuenta
                           orderby c.Id descending
                           select new { c.Id, c.ClienteId, Nombre = e.Nombre, c.Total, c.SaldoAnterior, c.Abono, c.SaldoActual, c.TotalLetras, c.Concepto, c.TipoPago, c.FechaCreacion,c.Cuenta });

                if (bus.Count() > 0)
                {
                    var bu = bus.First();

                    _Id = bu.Id;
                    _ClienteId = bu.ClienteId;
                    _Nombre = bu.Nombre;
                    _TotalLetras = bu.TotalLetras;
                    _Total = Convert.ToDecimal(bu.Total);
                    _Concepto = bu.Concepto;
                    _SaldoAnterior = Convert.ToDecimal(bu.SaldoAnterior);
                    _Abono = Convert.ToDecimal(bu.Abono);
                    _SaldoActual = Convert.ToDecimal(bu.SaldoActual);
                    _TipoPago = Convert.ToInt32(bu.TipoPago);
                    _FechaCreacion = Convert.ToDateTime(bu.FechaCreacion);
                    _Cuenta = bu.Cuenta;

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
        public void actualizar_abono(String Cliente,String SaldoAnterior, String Abono, String SaldoActual,String TotalLetras,String Total,String Concepto)
        {
            try
            {
                this.OpenConn();
                var bus = (from c in db.ReciboCliente
                           join e in db.Clientes on c.ClienteId equals e.Id
                           where (e.Nombre == Cliente) 
                           select c).First();
                bus.SaldoAnterior = Convert.ToDecimal(SaldoAnterior);
                bus.Abono = Convert.ToDecimal(Abono);
                bus.SaldoActual = Convert.ToDecimal(SaldoActual);
                bus.TotalLetras = Convert.ToString(TotalLetras);
                bus.Total = Convert.ToDecimal(Total);
                bus.Concepto = Convert.ToString(Concepto);
                bus.Cuenta = Cuenta;
                
                db.SubmitChanges();
                this.CloseConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void ObtieneReciboClientes(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus =( from c in db.ReciboCliente
                          join e in db.Clientes on c.ClienteId equals e.Id
                          where c.Activo == true
                          orderby e.Nombre ascending                       
                          select new { c.Id,Nombre = e.Nombre,c.Total,c.SaldoAnterior,c.Abono,c.SaldoActual,c.TotalLetras,c.Concepto,c.TipoPago,c.FechaCreacion,c.Cuenta,c.ClienteId});
                
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

        public void ObtieneReciboClientes2(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from c in db.ReciboCliente
                           join e in db.Clientes on c.ClienteId equals e.Id
                           where c.Activo == false
                           orderby e.Nombre ascending
                           select new { c.Id, Nombre = e.Nombre, c.Total, c.SaldoAnterior, c.Abono, c.SaldoActual, c.TotalLetras, c.Concepto, c.TipoPago, c.FechaCreacion, c.Cuenta,c.ClienteId });
                           
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

        public void ObtieneReciboBusqueda(DataGridView dgv)
        {
            try
            {
                this.OpenConn();


          

                var bus = (from c in db.ReciboCliente
                           join e in db.Clientes on c.ClienteId equals e.Id
                           where c.Id==_Id || c.Cuenta==_Cuenta
                           orderby e.Nombre ascending
                           select new { c.Id, Nombre = e.Nombre, c.Total, c.SaldoAnterior, c.Abono, c.SaldoActual, c.TotalLetras, c.Concepto, c.TipoPago,c.FechaCreacion,c.Cuenta,c.ClienteId });
                           

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los recibos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneReciboBusqueda2(DataGridView dgv)
        {
            try
            {
                this.OpenConn();




                var bus = (from c in db.ReciboCliente
                           join e in db.Clientes on c.ClienteId equals e.Id
                           where c.ClienteId==_ClienteId && c.Activo==_Activo
                           orderby e.Nombre ascending
                           select new { c.Id, Nombre = e.Nombre, c.Total, c.SaldoAnterior, c.Abono, c.SaldoActual, c.TotalLetras, c.Concepto, c.TipoPago, c.FechaCreacion,c.Cuenta,c.ClienteId });
                           
                           

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los recibos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneReciboBusqueda()
        {
            try
            {
                this.OpenConn();

                var bus = (from c in db.ReciboCliente
                           join e in db.Clientes on c.ClienteId equals e.Id
                           where c.Activo == true && c.Id==Id
                           orderby e.Nombre ascending
                           select new { c.Id,c.ClienteId, Nombre = e.Nombre, c.Total, c.SaldoAnterior, c.Abono, c.SaldoActual, c.TotalLetras, c.Concepto, c.TipoPago,c.FechaCreacion,c.Cuenta });
                         
                if (bus.Count() > 0)
                {
                    var bu = bus.First();

                    _Id = bu.Id;
                    _ClienteId = bu.ClienteId;
                    _Nombre = bu.Nombre;
                    _TotalLetras = bu.TotalLetras;
                    _Total = Convert.ToDecimal(bu.Total);
                    _Concepto = bu.Concepto;
                    _SaldoAnterior = Convert.ToDecimal(bu.SaldoAnterior);
                    _Abono = Convert.ToDecimal(bu.Abono);
                    _SaldoActual = Convert.ToDecimal(bu.SaldoActual);
                    _TipoPago = Convert.ToInt32(bu.TipoPago);
                    _FechaCreacion = Convert.ToDateTime(bu.FechaCreacion);
                    _Cuenta = bu.Cuenta;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el recibo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool VerificaCuenta(string numcuenta)
        {
            try
            {
                this.OpenConn();

                var bus = (from c in db.ReciboCliente
                           where (c.Cuenta == numcuenta && c.Activo==true)
                           select c).ToList();

                if (bus.Count() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar verificar cuenta: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool AgregaRecibo()
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.ReciboCliente _NewRecibo = new PuntoVentaDAL.ReciboCliente();

                _NewRecibo.ClienteId=_ClienteId;
                _NewRecibo.TotalLetras=_TotalLetras;
                _NewRecibo.Total = _Total;
                _NewRecibo.Concepto = _Concepto;
                _NewRecibo.SaldoAnterior = _SaldoAnterior;
                _NewRecibo.Abono=_Abono;
                _NewRecibo.SaldoActual = _SaldoActual;
                _NewRecibo.TipoPago = _TipoPago;
                _NewRecibo.Activo = _Activo;
                _NewRecibo.FechaCreacion = System.DateTime.Now;
                _NewRecibo.Cuenta = _Cuenta;
                

                db.ReciboCliente.InsertOnSubmit(_NewRecibo);

                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el recido de cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }



        public bool ModificaRecibo()
        {
            try
            {
                this.OpenConn();
                var bus = (from c in db.ReciboCliente
                           join e in db.Clientes on c.ClienteId equals e.Id
                           where (c.Activo == true && c.Id==Id)
                           select c).First();
                bus.SaldoAnterior = Convert.ToDecimal(_SaldoAnterior);
                bus.Abono = Convert.ToDecimal(_Abono);
                bus.SaldoActual = Convert.ToDecimal(_SaldoActual);
                bus.TotalLetras = Convert.ToString(_TotalLetras);
                bus.Total = Convert.ToDecimal(_Total);
                bus.Concepto = Convert.ToString(_Concepto);
                bus.ClienteId = Convert.ToInt32(_ClienteId);
                bus.FechaCreacion = Convert.ToDateTime(_FechaCreacion);
                bus.Cuenta = Cuenta;
                if (_SaldoActual == 0)
                {
                    bus.Activo = false;
                }
                else
                    bus.Activo = true;
              
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


        public bool CancelaAbono()
        {
            try
            {
                this.OpenConn();
                var bus = (from c in db.ReciboCliente    
                           where (c.Activo == true && c.Cuenta==_Cuenta)
                           select c).ToList();

                foreach (var item in bus)
                {
                    item.Activo = false;
                }
                //bus.First().Activo = false;
             

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cancelar  los abonos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }


        public bool EliminaRecibo()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.ReciboCliente
                           where x.Activo == true && x.Id == Id
                           orderby x.FechaCreacion ascending
                           select x).First();

                bus.Activo = false;
            

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
