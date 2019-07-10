using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class CR_Ubicacion
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        public void LoadProvincia(ComboBox cmb)
        {
            try
            {
                this.OpenConn();


                IQueryable<PuntoVentaDAL.provincia> get = db.provincia.Select(n => n);

                if (get.Count() > 0)
                {
                    Dictionary<string, string> Provincias = new Dictionary<string, string>();
                    foreach (PuntoVentaDAL.provincia i in get)
                    {
                        Provincias.Add(i.id.ToString(), i.provincia1);
                    }
                    cmb.DataSource = new BindingSource(Provincias, null);
                    cmb.DisplayMember = "Value";
                    cmb.ValueMember = "Key";
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

        public void LoadCanton(ComboBox cmb, int Provincia)
        {
            try
            {
                this.OpenConn();


                IQueryable<PuntoVentaDAL.canton> get = db.canton.Where(n => n.codigoProvincia == Provincia).Select(n => n);

                if (get.Count() > 0)
                {
                    Dictionary<string, string> Cantones = new Dictionary<string, string>();
                    foreach (PuntoVentaDAL.canton i in get)
                    {
                        Cantones.Add(i.id.ToString(), i.canton1);
                    }
                    cmb.DataSource = new BindingSource(Cantones, null);
                    cmb.DisplayMember = "Value";
                    cmb.ValueMember = "Key";
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


        public void LoadDistrito(ComboBox cmb, int Canton, int Provincia)
        {
            try
            {
                this.OpenConn();


                IQueryable<PuntoVentaDAL.distrito> get = db.distrito.Where(n => n.codigoCanton == Canton && n.codigoProvincia == Provincia).Select(n => n);

                if (get.Count() > 0)
                {
                    Dictionary<string, string> Distritos = new Dictionary<string, string>();
                    foreach (PuntoVentaDAL.distrito i in get)
                    {
                        Distritos.Add(i.codigo.ToString(), i.distrito1);
                    }
                    cmb.DataSource = new BindingSource(Distritos, null);
                    cmb.DisplayMember = "Value";
                    cmb.ValueMember = "Key";
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
        public string getCantonId(int canton)
        {
            try
            {
                this.OpenConn();


                int? get = db.canton.Where(n => n.id == canton ).Select(n => n.codigo).FirstOrDefault();

                return get.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
                
            }
            return null;
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
