using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class InformacionGeneral
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades

        private decimal _TipoCambio;

        public decimal TipoCambio
        {
            get { return _TipoCambio; }
            set { _TipoCambio = value; }
        }


        private decimal _IVA;

        public decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }


        private string _Fax;

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }


        private string _Encabezado1;

        public string Encabezado1
        {
            get { return _Encabezado1; }
            set { _Encabezado1 = value; }
        }

        private string _Encabezado2;

        public string Encabezado2
        {
            get { return _Encabezado2; }
            set { _Encabezado2 = value; }
        }

        private string _Encabezado3;

        public string Encabezado3
        {
            get { return _Encabezado3; }
            set { _Encabezado3 = value; }
        }

        private string _Encabezado4;

        public string Encabezado4
        {
            get { return _Encabezado4; }
            set { _Encabezado4 = value; }
        }

        private decimal _ImpuestoServicio;

        public decimal ImpuestoServicio
        {
            get { return _ImpuestoServicio; }
            set { _ImpuestoServicio = value; }
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

        private string _PiePagina5;

        public string PiePagina5
        {
            get { return _PiePagina5; }
            set { _PiePagina5 = value; }
        }

        private string _PiePagina6;

        public string PiePagina6
        {
            get { return _PiePagina6; }
            set { _PiePagina6 = value; }
        }

        private string _PiePagina7;

        public string PiePagina7
        {
            get { return _PiePagina7; }
            set { _PiePagina7 = value; }
        }

        private string _PiePagina8;

        public string PiePagina8
        {
            get { return _PiePagina8; }
            set { _PiePagina8 = value; }
        }

        public string _Numero_Sucursal { get; set; }

        public string _Numero_Cedula { get; set; }

        public string _Llave_Criptografica { get; set; }

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

        #endregion

        #region Metodos
        public void ObtengoInformacion()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.InformacionGeneral
                           select x);

                if (bus.Count() > 0)
                {
                    var bu = bus.First();

                    _Nombre = bu.Nombre;
                    _Dueno = bu.Dueno;
                    _Cedula = bu.Cedula;
                    _Telefono = bu.Telefono;
                    _Fax = bu.Fax;
                    _Encabezado1 = bu.Encabezado1;
                    _Encabezado2 = bu.Encabezado2;
                    _Encabezado3 = bu.Encabezado3;
                    _Encabezado4 = bu.Encabezado4;
                    _PiePagina1 = bu.PiePagina1;
                    _PiePagina2 = bu.PiePagina2;
                    _PiePagina3 = bu.PiePagina3;
                    _PiePagina4 = bu.PiePagina4;
                    _PiePagina5 = bu.PiePagina5;
                    _PiePagina6 = bu.PiePagina6;
                    _PiePagina7 = bu.PiePagina7;
                    _PiePagina8 = bu.PiePagina8;

                    _IVA = Convert.ToDecimal(Convert.ToDecimal(bu.IVA).ToString("F"));
                    _TipoCambio = Convert.ToDecimal(Convert.ToDecimal(bu.TipoCambio).ToString("F"));
                    _Numero_Sucursal = bu.Numero_Sucursal.ToString();
                    _Numero_Cedula = bu.Numero_Cedula.ToString();
                    _Llave_Criptografica = bu.Llave_Criptografica.ToString();

                }
                else
                {
                    _Nombre = "";
                    _Dueno = "";
                    _Cedula = "";
                    _Telefono = "";
                    _Fax = "";
                    _Encabezado1 = "";
                    _Encabezado2 = "";
                    _Encabezado3 = "";
                    _Encabezado4 = "";
                    _PiePagina1 = "";
                    _PiePagina2 = "";
                    _PiePagina3 = "";
                    _PiePagina4 = "";
                    _PiePagina5 = "";
                    _PiePagina6 = "";
                    _PiePagina7 = "";
                    _PiePagina8 = "";
                    _Web = "";
                    _IVA = 0;
                    _ImpuestoServicio = 0;
                    _TipoCambio = 0;
                    _Llave_Criptografica = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información de la empresa: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ActualizaInformacion()
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
                    bu.Encabezado1 = _Encabezado1;
                    bu.Encabezado2 = _Encabezado2;
                    bu.Encabezado3 = _Encabezado3;
                    bu.Encabezado4 = _Encabezado4;
                    bu.PiePagina1 = _PiePagina1;
                    bu.PiePagina2 = _PiePagina2;
                    bu.PiePagina3 = _PiePagina3;
                    bu.PiePagina4 = _PiePagina4;
                    bu.PiePagina5 = _PiePagina5;
                    bu.PiePagina6 = _PiePagina6;
                    bu.PiePagina7 = _PiePagina7;
                    bu.PiePagina8 = _PiePagina8;
                    bu.IVA = _IVA;
                    bu.TipoCambio = _TipoCambio;
                    bu.Numero_Cedula = Int64.Parse(_Numero_Cedula); 
                    bu.Numero_Sucursal = Int64.Parse(_Numero_Sucursal);
                    bu.Llave_Criptografica = Int32.Parse(_Llave_Criptografica);
                }
                else
                {
                    PuntoVentaDAL.InformacionGeneral _NewInformacionGeneral = new PuntoVentaDAL.InformacionGeneral();
                    _NewInformacionGeneral.Nombre = _Nombre;
                    _NewInformacionGeneral.Dueno = _Dueno;
                    _NewInformacionGeneral.Cedula = _Cedula;
                    _NewInformacionGeneral.Telefono = _Telefono;
                    _NewInformacionGeneral.Fax = _Fax;
                    _NewInformacionGeneral.Encabezado1 = _Encabezado1;
                    _NewInformacionGeneral.Encabezado2 = _Encabezado2;
                    _NewInformacionGeneral.Encabezado3 = _Encabezado3;
                    _NewInformacionGeneral.Encabezado4 = _Encabezado4;
                    _NewInformacionGeneral.PiePagina1 = _PiePagina1;
                    _NewInformacionGeneral.PiePagina2 = _PiePagina2;
                    _NewInformacionGeneral.PiePagina3 = _PiePagina3;
                    _NewInformacionGeneral.PiePagina4 = _PiePagina4;
                    _NewInformacionGeneral.PiePagina5 = _PiePagina5;
                    _NewInformacionGeneral.PiePagina6 = _PiePagina6;
                    _NewInformacionGeneral.PiePagina7 = _PiePagina7;
                    _NewInformacionGeneral.PiePagina8 = _PiePagina8;
                    _NewInformacionGeneral.IVA = _IVA;
                    _NewInformacionGeneral.TipoCambio = _TipoCambio;
                    _NewInformacionGeneral.Numero_Cedula = Int64.Parse(_Numero_Cedula);
                    _NewInformacionGeneral.Numero_Sucursal = Int64.Parse(_Numero_Sucursal);
                    _NewInformacionGeneral.Llave_Criptografica = Int32.Parse(_Llave_Criptografica);

                    db.InformacionGeneral.InsertOnSubmit(_NewInformacionGeneral);
                }

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar la información de la empresa: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
