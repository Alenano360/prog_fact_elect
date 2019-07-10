using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_BL
{
    public class CComandaBar
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades

        private int _TemporalConsumoId;

        public int TemporalConsumoId
        {
            get { return _TemporalConsumoId; }
            set { _TemporalConsumoId = value; }
        }

        private int _MesaId;

        public int MesaId
        {
            get { return _MesaId; }
            set { _MesaId = value; }
        }

        private Int64 _OrdenId;

        public Int64 OrdenId
        {
            get { return _OrdenId; }
            set { _OrdenId = value; }
        }
        public List<string> ListaComandaBar = new List<string>();

        public List<string> ListaComandaBarImprimir = new List<string>();

        #endregion  

        #region Metodos

        public void ObtieneComandaBar()
        {
            try
            {
                this.OpenConn();

                var bus = (from tc in db.TemporalConsumo
                           join sf in db.Articulo on tc.CodigoArticulo equals sf.Id                           
                           where (sf.FamiliaId == 1 || sf.FamiliaId == 2) && tc.Activo==true
                           select new { tc.Id, sf.Nombre, tc.Cantidad, tc.Mesa_Silla });

                ListaComandaBar.Clear();

                if (bus.Count()>0)
                {
                    foreach (var item in bus)
                    {
                        if (item.Id >= 10)
                        {
                            if (item.Id > 100)
                            {
                                ListaComandaBar.Add(item.Id + "|" + item.Nombre + "|" + item.Cantidad.ToString() + "|" + item.Mesa_Silla);
                            }
                            else
                            {
                                ListaComandaBar.Add("0" + item.Id + "|" + item.Nombre + "|" + item.Cantidad.ToString()+ "|" +item.Mesa_Silla);
                            }
                        }
                        else
                        {
                            ListaComandaBar.Add("00" + item.Id + "|" + item.Nombre + "|" + item.Cantidad.ToString() + "|" + item.Mesa_Silla);
                        }    
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la comanda del bar: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneComandaBarXMesa()
        {
            try
            {
                this.OpenConn();

                var bus = (from tc in db.TemporalConsumo
                           join sf in db.Articulo on tc.CodigoArticulo equals sf.Id
                           where sf.Comanda == 1 && tc.Activo == true && tc.Mesa_Silla == _MesaId
                           select new { tc.Id, sf.Nombre, tc.Detalle, tc.Cantidad, tc.Mesa_Silla, tc.Observaciones });

                int conteoorden = (from fe in db.FacturaEncabezado
                                   where fe.Activo == true && fe.Fecha == System.DateTime.Now
                                   select new { fe.Id }).Count();

                if (conteoorden == 0)
                {
                    OrdenId = 1;
                }
                else
                {
                    OrdenId = conteoorden;
                }


                ListaComandaBar.Clear();

                if (bus.Count() > 0)
                {


                    foreach (var item in bus)
                    {
                        if (item.Id >= 10)
                        {
                            if (item.Id > 100)
                            {
                                ListaComandaBar.Add(item.Id + "|" + item.Nombre + "|" + item.Cantidad.ToString() + "|" + item.Mesa_Silla + "|" + item.Detalle + "|" + item.Observaciones);
                            }
                            else
                            {
                                ListaComandaBar.Add("0" + item.Id + "|" + item.Nombre + "|" + item.Cantidad.ToString() + "|" + item.Mesa_Silla + "|" + item.Detalle + "|" + item.Observaciones);
                            }
                        }
                        else
                        {
                            ListaComandaBar.Add("00" + item.Id + "|" + item.Nombre + "|" + item.Cantidad.ToString() + "|" + item.Mesa_Silla + "|" + item.Detalle + "|" + item.Observaciones);
                        }
                    }
                }

                var bus1 = (from tc in db.ImpresionComandaBar

                            where tc.Mesa_Silla == _MesaId
                            select new { tc.Descripcion, tc.Detalle, tc.Cantidad, tc.Mesa_Silla, tc.Observaciones });

                if (bus.Count() > 0)
                {
                    foreach (var item in bus1)
                    {
                        ListaComandaBarImprimir.Add(item.Descripcion + "|" + item.Cantidad + "|" + item.Mesa_Silla.ToString() + "|" + item.Detalle + "|" + item.Observaciones);
                    }
                }
                else
                {
                    ListaComandaBarImprimir.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la comanda de bar: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void DesactivaOrden()
        {
            try
            {
                this.OpenConn();

                var bus = (from tc in db.TemporalConsumo
                           where tc.Id==_TemporalConsumoId
                           select tc).First();

                bus.Activo = false;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar desactivar la comanda del bar: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
