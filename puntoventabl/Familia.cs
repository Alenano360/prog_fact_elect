using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Familia
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

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Observacion;

        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }        

        #endregion

        #region Metodos

        public void ObtieneFamilia(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                dgv.Columns[0].Visible = true;

                var bus = (from f in db.Familias
                           where f.Activo == true
                           select new { f.Id,f.Descripcion,f.Observacion});

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                dgv.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las familias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneFamiliaBusqueda(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                dgv.Columns[0].Visible = true;

                var bus = (from f in db.Familias
                           where f.Activo == true && (f.Descripcion.Contains(_Nombre)||f.Observacion.Contains(_Nombre))
                           select new { f.Id, f.Descripcion, f.Observacion });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                dgv.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las familias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneFamiliaBusqueda()
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.Familias
                           where f.Activo == true && f.Id==_Id
                           select new { f.Id, f.Descripcion, f.Observacion });

                if (bus.Count() > 0)
                {
                    _Descripcion= bus.First().Descripcion;
                    _Observacion = bus.First().Observacion;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las familias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool AgregaFamilia()
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.Familia _NewFamilia = new PuntoVentaDAL.Familia();

                _NewFamilia.Descripcion = _Descripcion;
                if (_Observacion!=null)
                {
                    _NewFamilia.Observacion = _Observacion;
                }                
                _NewFamilia.Activo = true;

                db.Familias.InsertOnSubmit(_NewFamilia);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool ModificaFamilia()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Familias
                           where x.Activo == true && x.Id == _Id
                           select x).First();

                bus.Descripcion = _Descripcion;
                if (_Observacion != null)
                {
                    bus.Observacion = _Observacion;                    
                }                

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool EliminaFamilia()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Familias
                           where x.Activo == true && x.Id == _Id
                           select x).First();

                bus.Activo = false;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
