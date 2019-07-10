using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurante_BL
{
    public class InformacionRestaurante
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades
        private decimal _TipoCambio;

        public decimal TipoCambio
        {
            get { return _TipoCambio; }
            set { _TipoCambio = value; }
        }
        
        private decimal _ImpuestoServicio;

        public decimal ImpuestoServicio
        {
            get { return _ImpuestoServicio; }
            set { _ImpuestoServicio = value; }
        }

        private decimal _IVA;

        public decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }
        
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Dueno;

        public string Dueno
        {
            get { return _Dueno; }
            set { _Dueno = value; }
        }

        private string _Cedula;

        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }

        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private string _Fax;

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        private string _PiePagina1;

        public string PiePagina1
        {
            get { return _PiePagina1; }
            set { _PiePagina1 = value; }
        }

        private string _PiePagina2;

        public string PiePagina2
        {
            get { return _PiePagina2; }
            set { _PiePagina2 = value; }
        }

        private string _PiePagina3;

        public string PiePagina3
        {
            get { return _PiePagina3; }
            set { _PiePagina3 = value; }
        }

        private string _PiePagina4;

        public string PiePagina4
        {
            get { return _PiePagina4; }
            set { _PiePagina4 = value; }
        }

        private string _FinalPagina;

        public string FinalPagina
        {
            get { return _FinalPagina; }
            set { _FinalPagina = value; }
        }

        private string _Impresora;

        public string Impresora
        {
            get { return _Impresora; }
            set { _Impresora = value; }
        }

        private string _Web;

        public string Web
        {
            get { return _Web; }
            set { _Web = value; }
        }

        public string _Numero_Sucursal { get; set; }

        public string _Numero_Cedula { get; set; }

        #endregion

        #region Metodos
        public void ObtengoInformacionRestaurante()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.InformacionGeneral
                               select x);

                if (bus.Count()>0)
                {
                    var bu=bus.First();

                    _Nombre = bu.Nombre;
                    _Dueno = bu.Dueno;
                    _Cedula = bu.Cedula;
                    _Telefono = bu.Telefono;
                    _Fax = bu.Fax;
                    _PiePagina1 = bu.PiePagina1;
                    _PiePagina2 = bu.PiePagina2;
                    _PiePagina3 = bu.PiePagina3;
                    _PiePagina4 = bu.PiePagina4;
                    _FinalPagina = bu.FinalPagina;
                    _Impresora = bu.Impresora;
                    _Web = bu.Web;
                    _IVA = Convert.ToDecimal(Convert.ToDecimal(bu.IVA).ToString("F"));
                    _ImpuestoServicio=Convert.ToDecimal(Convert.ToDecimal(bu.ImpuestoServicio).ToString("F"));
                    _TipoCambio = Convert.ToDecimal(Convert.ToDecimal(bu.TipoCambio).ToString("F"));
                    _Numero_Sucursal = bu.Numero_Sucursal.ToString();
                    _Numero_Cedula = bu.Numero_Cedula.ToString();
                }
                else
                {
                    _Nombre ="";
                    _Dueno = "";
                    _Cedula = "";
                    _Telefono = "";
                    _Fax = "";
                    _PiePagina1 = "";
                    _PiePagina2 = "";
                    _PiePagina3 = "";
                    _PiePagina4 = "";
                    _FinalPagina = "";
                    _Web = "";
                    _IVA = 0;
                    _ImpuestoServicio = 0;
                    _TipoCambio = 0;
                    _Numero_Sucursal = "";
                    _Numero_Cedula = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ActualizaInformacionRestaurantes()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.InformacionGeneral
                           select x);

                if (bus.Count() > 0)
                {
                    var bu = bus.First();

                    bu.Nombre = _Nombre;
                    bu.Dueno = _Dueno;
                    bu.Cedula = _Cedula;
                    bu.Telefono = _Telefono;
                    bu.Fax = _Fax;
                    bu.PiePagina1 = _PiePagina1;
                    bu.PiePagina2 = _PiePagina2;
                    bu.PiePagina3 = _PiePagina3;
                    bu.PiePagina4 = _PiePagina4;
                    bu.FinalPagina = _FinalPagina;
                    bu.Impresora = _Impresora;
                    bu.Web = _Web;
                    bu.IVA = _IVA;
                    bu.ImpuestoServicio = _ImpuestoServicio;
                    bu.TipoCambio = _TipoCambio;


                    bu.Numero_Cedula = Int64.Parse(_Numero_Cedula);
                    bu.Numero_Sucursal = Int32.Parse(_Numero_Sucursal);

                }
                else
                {
                    Restaurante_DAL.InformacionGeneral _NewInformacionGeneral = new Restaurante_DAL.InformacionGeneral();
                    _NewInformacionGeneral.Nombre = _Nombre;
                    _NewInformacionGeneral.Dueno = _Dueno;
                    _NewInformacionGeneral.Cedula = _Cedula;
                    _NewInformacionGeneral.Telefono = _Telefono;
                    _NewInformacionGeneral.Fax = _Fax;
                    _NewInformacionGeneral.PiePagina1 = _PiePagina1;
                    _NewInformacionGeneral.PiePagina2 = _PiePagina2;
                    _NewInformacionGeneral.PiePagina3 = _PiePagina3;
                    _NewInformacionGeneral.PiePagina4 = _PiePagina4;
                    _NewInformacionGeneral.FinalPagina = _FinalPagina;
                    _NewInformacionGeneral.Impresora = _Impresora;
                    _NewInformacionGeneral.Web = _Web;
                    _NewInformacionGeneral.IVA = _IVA;
                    _NewInformacionGeneral.ImpuestoServicio = _ImpuestoServicio;
                    _NewInformacionGeneral.TipoCambio = _TipoCambio;

                    _NewInformacionGeneral.Numero_Cedula = Int64.Parse(_Numero_Cedula);
                    _NewInformacionGeneral.Numero_Sucursal = Int32.Parse(_Numero_Sucursal);

                    db.InformacionGeneral.InsertOnSubmit(_NewInformacionGeneral);
                }

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                           where x.Activo == true && (x.RolId != 3 && x.RolId != 4)
                           select new {x.Id,Nombre=x.Nombre + " " + (x.Apellido==null?"":x.Apellido) });

                cmb.DataSource = bus;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los saloneros: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
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
