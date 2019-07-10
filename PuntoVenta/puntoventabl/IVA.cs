using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class IVA
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;
        #region Propiedades

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _Valor;

        public int Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        #endregion

        #region Metodos

        public void LoadIVA(ComboBox cmb)
        {
            try
            {
                this.OpenConn();


                IQueryable<PuntoVentaDAL.IVA> get = db.IVA.Select(n => n);

                if (get.Count() > 0)
                {
                    //DataObject impuesto= new DataObject();
                    Dictionary<string, string> impuesto = new Dictionary<string, string>();
                    foreach (PuntoVentaDAL.IVA i in get)
                    {
                        //impuesto.SetData(i.Id.ToString(),i.Descripcion.ToString());
                        impuesto.Add(i.Id.ToString(), i.Descripcion.ToString());
                    }

                    cmb.DataSource = new BindingSource(impuesto, null);
                    cmb.ValueMember = "Key";
                    cmb.DisplayMember = "Value";
                    

             
        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los impuestos de  venta: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
