using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;


namespace PuntoVentaPresentacion
{
    public partial class Inventario_Mantenimiento : Form
    {
        Inventario_Mod _owner;

        PuntoVentaBL.InformacionGeneral objInformacionGeneral = new PuntoVentaBL.InformacionGeneral();

        #region propiedades

        public string Id = string.Empty;
        public string Codigo = string.Empty;
        public string Codigo2 = string.Empty;
        public string Descripcion = string.Empty;
        public string ProveedorIdS = string.Empty;
        public string FamiliaIdS = string.Empty;
        public string UbicacionIdS = string.Empty;
        public string Existencias = string.Empty;
        public string FechaUltimaCompra = string.Empty;
        public string PorcImpVentas = string.Empty;
        public string Precio = string.Empty;
        public string IV = string.Empty;
        public string UtilidadPrecio = string.Empty;
        public string PrecioIVU = string.Empty;
        public string Precio2 = string.Empty;
        public string IVPrecio2 = string.Empty;
        public string UtilidadPrecio2 = string.Empty;
        public string Precio2IVU = string.Empty;
        public string UnidadMedidaS = string.Empty;
        public string ConsignacionS = string.Empty;
        public string Observacion = string.Empty;
        public string gran = string.Empty;
        public string granxprecio = string.Empty;
        public string granprecio2 = string.Empty;
        public string Compra1 = string.Empty;
        public string Compra2 = string.Empty;

        #endregion

        public int Accion = 0;

        public int ProveedorId = 0;

        public int FamiliaId = 0;

        public int UbicacionId = 0;

        public int UnidadMedida = 0;

        int ModificaPrecios1 = 0;
        int ModificaPrecios2 = 0;

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        PuntoVentaBL.Ubicacion objUbicacion = new PuntoVentaBL.Ubicacion();

        public Inventario_Mantenimiento(Inventario_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Inventario_Agregar_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objInformacionGeneral.ObtengoInformacion();

                this.objInventario.ObtieneProveedores(this.cmbProveedor);

                this.objInventario.ObtieneFamilia(this.cmbFamilia);

                this.objUbicacion.ObtieneUbicaciones(this.cmbUbicacion);

                this.objInventario.ObtieneUnidadesMedida(this.cmbUnidadMedida);

                if (Accion == 0)//Agregar articulo
                {
                    this.txtExistencias.Text = "0.00";

                    this.txtIVPorc.Text = Convert.ToInt32(this.objInformacionGeneral.IVA).ToString();
                }
                if (Accion == 1)//Modifica Articulo
                {
                    this.txtCompra1.Text = Precio.ToString();
                    this.txtCompra2.Text = Precio2.ToString();
                    this.txtgram.Text = gran;
                    this.txtprecioxgram.Text = granxprecio;
                    this.txtprecioxgram2.Text = granprecio2;
                    this.txtCodigo.Text = Codigo;
                    this.txtCodigo.ReadOnly = true;
                    this.txtCodigo2.Text = Codigo2;
                    this.txtDescripcion.Text = Descripcion;
                    this.cmbProveedor.SelectedValue = Convert.ToInt32(ProveedorIdS);
                    this.cmbFamilia.SelectedValue = Convert.ToInt32(FamiliaIdS);
                    this.cmbUbicacion.SelectedValue = Convert.ToInt32(UbicacionIdS);
                    this.cmbUnidadMedida.SelectedValue = Convert.ToInt32(UnidadMedidaS);
                    this.txtExistencias.Text = Existencias;
                    this.dtpFechaCompra.Text = FechaUltimaCompra;//asignar las variables publicas a las cajas de texto
                    this.txtIVPorc.Text = PorcImpVentas.ToString();
                    this.txtPrecio1.Text = Precio.ToString();
                    this.txtObservacion.Text = Observacion.ToString();

                    if (Convert.ToBoolean(ConsignacionS) == true)
                    {
                        this.chkConsignacion.Checked = true;
                    }
                    if (Convert.ToBoolean(IV) == true)
                    {
                        this.chkGravado1.Checked = true;
                    }
                    this.txtUtilPorc1.Text = UtilidadPrecio.ToString();
                    this.txtPrecioFinal.Text = PrecioIVU.ToString();
                    if (txtPrecioFinal.Text != " " || txtPrecioFinal.Text != "0.00")
                        this.CalculaPrecioImpuesto();

                    //  this.CalculaPrecioFinal1();

                    this.txtPrecio2.Text = Precio2.ToString();
                    if (Convert.ToBoolean(IVPrecio2) == true)
                    {
                        this.chkGravado2.Checked = true;
                    }
                    this.txtUtilPorc2.Text = UtilidadPrecio2.ToString();
                    this.txtPrecioFinal2.Text = Precio2IVU.ToString();
                    if (txtPrecioFinal2.Text != " " || txtPrecioFinal2.Text != "0.00")
                        this.CalculaPrecioImpuesto2();
                    //   this.CalculaPrecioFinal2();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar mostrar la pantalla de ingresar articulos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo2.Text == "" || txtCodigo2.Text == null)
                    txtCodigo2.Text = " ";
                if (txtDescripcion.Text == "" || txtDescripcion.Text == null)
                    txtDescripcion.Text = " ";
                if (txtObservacion.Text == "" || txtObservacion.Text == null)
                    txtObservacion.Text = " ";


                if ((this.objInventario.Verificar_Articulo(txtCodigo.Text) == true) && (Accion == 0))
                {
                    MessageBox.Show("Error Codigo Existente ");
                    return;
                }


                if (!ValidacionAgregar())
                {
                    return;
                }

                decimal compra = Convert.ToDecimal(this.txtCompra1.Text);
                decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);


                decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;

                decimal tempiva = (precio * iv);

                decimal tempUtil = precio + ((precio + tempiva) * (Convert.ToDecimal(this.txtUtilPorc1.Text) / 100));



                // decimal preciofinal = Convert.ToDecimal(tempUtil + tempiva);

                decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal.Text);

                if (this.chkGravado1.Checked == false)
                {
                    preciofinal = precio + ((precio) * (Convert.ToDecimal(this.txtUtilPorc1.Text) / 100));
                }



                this.objInventario.Codigo = this.txtCodigo.Text;
                this.objInventario.Codigo2 = this.txtCodigo2.Text;
                this.objInventario.Descripcion = this.txtDescripcion.Text;
                this.objInventario.ProveedorId = Convert.ToInt32(this.cmbProveedor.SelectedValue);

                if (this.cmbFamilia.Text.Length != 0)
                {
                    this.objInventario.FamiliaId = Convert.ToInt32(this.cmbFamilia.SelectedValue);
                }
                if (this.cmbUbicacion.Text.Length != 0)
                {
                    this.objInventario.UbicacionId = Convert.ToInt32(this.cmbUbicacion.SelectedValue);
                }

                if (Login.RolId.ToString() == "1")//solo admin puede verif (this.cmbUnidadMedida.Text != "Unidad(es)")
                {
                    if (this.cmbUnidadMedida.Text != "Unidad(es)")
                    {
                        this.objInventario.Existencias = Convert.ToDecimal(this.txtExistencias.Text) + Convert.ToDecimal(this.txtAgregaExistencias.Text);
                    }
                    else
                    {
                        //if (System.Text.RegularExpressions.Regex.IsMatch(this.txtAgregaExistencias.Text, "[^0-9]"))
                        //{
                        //    MessageBox.Show("Para la existencias ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        try
                        {
                            decimal x = Convert.ToDecimal(this.txtAgregaExistencias.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Para la existencias ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        this.objInventario.Existencias = Convert.ToDecimal(this.txtExistencias.Text) + Convert.ToInt32(this.txtAgregaExistencias.Text);
                    }
                }




                else
                    if (this.cmbUnidadMedida.Text != "Unidad(es)")
                    {
                        this.objInventario.Existencias = Convert.ToDecimal(this.txtExistencias.Text) + 0;
                    }
                    else
                    {

                        this.objInventario.Existencias = Convert.ToDecimal(this.txtExistencias.Text) + 0;
                    }




                this.objInventario.FechaUltimaCompra = Convert.ToDateTime(this.dtpFechaCompra.Text);
                this.objInventario.PorcImpVentas = Convert.ToDecimal(this.txtIVPorc.Text);
                this.objInventario.Compra = Convert.ToDecimal(this.txtCompra1.Text);
                this.objInventario.Precio = Convert.ToDecimal(this.txtPrecio1.Text);
                this.objInventario.Consignacion = Convert.ToBoolean(this.chkConsignacion.CheckState);
                this.objInventario.IV = Convert.ToBoolean(this.chkGravado1.CheckState);
                this.objInventario.Gram = Convert.ToDecimal(txtgram.Text);

                if (this.chkGravado1.Checked)
                {
                    //this.objInventario.MontoIV = Convert.ToDecimal(tempiva);
                    string s = "1." + Convert.ToInt32(this.txtIVPorc.Text.Substring(0, this.txtIVPorc.Text.Length - 3)).ToString();
                    this.objInventario.MontoIV = (Convert.ToDecimal(Convert.ToDecimal(preciofinal) / Convert.ToDecimal(s)) * iv);
                    //this.objInventario.MontoIV = (Convert.ToDecimal(Convert.ToDecimal(tempUtil + tempiva) / Convert.ToDecimal(s)) * iv);
                    this.objInventario.MontoIV = decimal.Round(this.objInventario.MontoIV, 2);
                }
                else
                {
                    this.objInventario.MontoIV = Convert.ToDecimal("0.00");
                }

                this.objInventario.UtilidadPrecio = Convert.ToDecimal(this.txtUtilPorc1.Text);

                preciofinal = Convert.ToDecimal(this.txtPrecioFinal.Text);

                this.objInventario.PrecioIVU = decimal.Round(Convert.ToDecimal(preciofinal), 2);
                // this.objInventario.precioxGram = Convert.ToDecimal(txtprecioxgram.Text);


                /////
                decimal precio2 = Convert.ToDecimal(this.txtPrecio2.Text);

                decimal iv2 = Convert.ToDecimal(this.txtIVPorc.Text) / 100;

                decimal tempiva2 = (precio2 * iv);

                decimal tempUtil2 = precio2 + ((precio2 + tempiva2) * (Convert.ToDecimal(this.txtUtilPorc2.Text) / 100));

                //decimal preciofinal2 = Convert.ToDecimal(tempUtil2 + tempiva2);
                decimal preciofinal2 = Convert.ToDecimal(this.txtPrecioFinal2.Text);

                if ((Convert.ToDecimal(txtgram.Text) != 0) && (Convert.ToDecimal(txtPrecioImpuesto2.Text) > 0))
                {
                    this.objInventario.precioxGram2 = Convert.ToDecimal(txtprecioxgram2.Text);
                }
                //  this.objInventario.precioxGram2 = Convert.ToDecimal(txtprecioxgram2.Text);
                if (this.chkGravado2.Checked == false)
                {
                    preciofinal2 = precio2 + ((precio2) * (Convert.ToDecimal(this.txtUtilPorc2.Text) / 100));
                }


                this.objInventario.Precio2 = Convert.ToDecimal(this.txtPrecio2.Text);
                this.objInventario.IVPrecio2 = Convert.ToBoolean(this.chkGravado2.CheckState);
                if (this.chkGravado2.Checked)
                {
                    //this.objInventario.MontoIV = Convert.ToDecimal(tempiva);
                    string s = "1." + Convert.ToInt32(this.txtIVPorc.Text.Substring(0, this.txtIVPorc.Text.Length - 3)).ToString();
                    this.objInventario.MontoIV2 = (Convert.ToDecimal(Convert.ToDecimal(preciofinal2) / Convert.ToDecimal(s)) * iv2);
                    //this.objInventario.MontoIV2 = (Convert.ToDecimal(Convert.ToDecimal(tempUtil2 + tempiva2) / Convert.ToDecimal(s)) * iv2);
                    this.objInventario.MontoIV2 = decimal.Round(this.objInventario.MontoIV2, 2);
                }
                else
                {
                    this.objInventario.MontoIV2 = Convert.ToDecimal("0.00");
                }


                this.objInventario.UtilidadPrecio2 = Convert.ToDecimal(this.txtUtilPorc2.Text);

                preciofinal2 = Convert.ToDecimal(this.txtPrecioFinal2.Text);

                this.objInventario.Precio2IVU = decimal.Round(Convert.ToDecimal(preciofinal2), 2);

                this.objInventario.UnidadMedidaId = Convert.ToInt32(this.cmbUnidadMedida.SelectedValue.ToString());

                this.objInventario.Observacion = this.txtObservacion.Text;

                if (Accion == 0)
                {
                    //aqui se agregan productos
                    DialogResult result = MessageBox.Show("¿Está seguro que desea agregar el artículo?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (this.objInventario.AgregaArticulo(Login.UserId))
                        {
                            MessageBox.Show("Artículo agregado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        this.objInventario.GuardaBitacoraPrecios(Login.UserId);

                        _owner.Inventario_Mod_Load(sender, e);

                        this.Close();
                    }
                }
                if (Accion == 1)
                {
                    //AQUI AGREGO UNIDADES 

                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el artículo?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        this.objInventario.Id = Convert.ToInt32(Id);

                        if (this.objInventario.ObtieneProductoInventarioBitacora(Codigo, Convert.ToDecimal(this.txtPrecioFinal.Text), Convert.ToDecimal(this.txtPrecioFinal2.Text)
                            , Convert.ToInt32(this.cmbProveedor.SelectedValue.ToString())) == false)
                        {
                            this.objInventario.GuardaBitacoraPrecios(Login.UserId);
                        }

                        if (this.objInventario.ModificaArticulo(txtAgregaExistencias.Text, Login.UserId))
                        {
                            MessageBox.Show("Artículo modificado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Inventario_Mod_Load(sender, e);

                        this.Close();
                    }
                }
            }






            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto al inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //fin
        private bool ValidacionAgregar()
        {
            if (this.txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese el código del articulo!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCodigo.Focus();
                return false;
            }
            if (this.cmbProveedor.Text.Length == 0)
            {
                MessageBox.Show("Por favor seleccione el proveedor del articulo!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //if (this.cmbFamilia.Text.Length == 0)
            //{
            //    MessageBox.Show("Por favor seleccione la familia del articulo!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //if (this.cmbUbicacion.Text.Length == 0)
            //{
            //    MessageBox.Show("Por favor seleccione la ubicación del articulo!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            if (this.cmbUnidadMedida.Text.Length == 0)
            {
                MessageBox.Show("Por favor seleccione la unidad de medida del articulo!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.txtDescripcion.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese la descripción del articulo!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCodigo.Focus();
                return false;
            }
            return true;
        }

        private void txtExistencias_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(txtExistencias.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Para la existencias ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.txtExistencias.Text = string.Empty;
            //}
        }

        private void txtIVPorc_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(txtIVPorc.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Para el porcentaje de impuesto de venta ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.txtIVPorc.Text = string.Empty;
            //}

            try
            {
                //if (this.txtIVPorc.Text == string.Empty || this.txtIVPorc.Text == "")
                //{
                //    MessageBox.Show("Para el porcentaje de impuesto de venta ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                try
                {
                    decimal x = Convert.ToDecimal(this.txtIVPorc.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el porcentaje de impuesto de venta ingrese solo números!!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtIVPorc.Text = "13.00";
                }
                this.txtIVPorc.Text = Convert.ToDecimal(this.txtIVPorc.Text).ToString("F");
                this.CalculaPrecioImpuesto();
                this.CalculaPrecioImpuesto2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculaPrecioImpuesto()
        {
            try
            {
                if (Convert.ToDecimal(this.txtPrecio1.Text) == 0)
                {
                    this.txtPrecioImpuesto.Text = "0.00";
                    return;
                }

                if (this.txtIVPorc.Text.Length > 0)
                {
                    if (this.chkGravado1.Checked)//tiene iv por agregarse
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);
                        decimal precioimpuesto = Convert.ToDecimal(this.txtPrecioImpuesto.Text);
                        decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
                        decimal temp = precio + Convert.ToDecimal(precio * iv);
                        
                        //  decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

                        //   decimal fin = (temp + (temp * utilidad));
                        decimal fin = temp;
                        
                        this.txtPrecioImpuesto.Text = fin.ToString("F");

                    }
                    else
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);
                        decimal temp = precio;
                        //  decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

                        //   decimal fin = (temp + (temp * utilidad));
                        decimal fin = temp;

                        this.txtPrecioImpuesto.Text = fin.ToString("F");

                    }

                }

                /*
                if (this.txtIVPorc.Text.Length > 0)
                {
                    if (this.chkGravado1.Checked)//tiene iv por agregarse
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);
                        decimal preciofinal = Convert.ToDecimal(this.txtPrecioImpuesto.Text);
                        decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
                        decimal tempiva = precio + (precio * Convert.ToDecimal(iv));
                        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);
                        //   decimal temputil = (tempiva * Convert.ToDecimal(utilidad));
                        //   decimal fin = (tempiva + temputil);
                        decimal fin = (tempiva);

                        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();
    
                        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioImpuesto.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                            this.txtPrecioImpuesto.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
                        }
                        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioImpuesto.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                            this.txtPrecioImpuesto.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
                        }
                        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioImpuesto.Text = Convert.ToDecimal("10").ToString("F");
                                return;
                            }

                            decimal tempn = Convert.ToDecimal(stemp);
                            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                            this.txtPrecioImpuesto.Text = tempn2.ToString("F");

                        }
                    }
                    else
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);
                        decimal temp = precio;
                        //   decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

                        //    decimal fin = (temp + (temp * utilidad));
                        decimal fin = temp;
                        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

                        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioImpuesto.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                            this.txtPrecioImpuesto.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
                        }
                        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioImpuesto.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                           // this.txtPrecioImpuesto.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
                        }
                        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioImpuesto.Text = Convert.ToDecimal("10").ToString("F");
                                return;
                            }
                            decimal tempn = Convert.ToDecimal(stemp);
                            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                            this.txtPrecioImpuesto.Text = tempn2.ToString("F");
                        }
                    }
                }*/
            }


            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculaPrecioFinal1()
        {
            try
            {
                if (Convert.ToDecimal(this.txtPrecio1.Text) == 0)
                {
                    this.txtPrecioFinal.Text = "0.00";
                    return;
                }

                if (this.txtIVPorc.Text.Length > 0)
                {
                    if (this.chkGravado1.Checked)//tiene iv por agregarse
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);
                        decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal.Text);
                        decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
                        decimal temp = precio + (precio * Convert.ToDecimal(iv));
                        Console.WriteLine(temp);
                        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

                        decimal fin = (temp + (temp * utilidad));
                        fin = Math.Round(fin, 0);
                        this.txtPrecioFinal.Text = fin.ToString("F");
                    }
                    else
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);
                        decimal temp = precio;
                        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

                        decimal fin = (temp + (temp * utilidad));
                        fin = Math.Round(fin, 0);

                        this.txtPrecioFinal.Text = fin.ToString("F");
                    }

                }
                /*
                if (this.txtIVPorc.Text.Length > 0)
                {
                    if (this.chkGravado1.Checked)//tiene iv por agregarse
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);
                        decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal.Text);
                        decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
                        decimal tempiva = precio + (precio * Convert.ToDecimal(iv));
                        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);
                        decimal temputil = (tempiva * Convert.ToDecimal(utilidad));
                        decimal fin = (tempiva + temputil);

                        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

                        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                            this.txtPrecioFinal.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
                        }
                        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                            this.txtPrecioFinal.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
                        }
                        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal.Text = Convert.ToDecimal("10").ToString("F");
                                return;
                            }

                            decimal tempn = Convert.ToDecimal(stemp);
                            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                            this.txtPrecioFinal.Text = tempn2.ToString("F");

                        }
                    }
                    else
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);
                        decimal temp = precio;
                        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

                        decimal fin = (temp + (temp * utilidad));

                        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

                        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                            this.txtPrecioFinal.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
                        }
                        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                         //   this.txtPrecioFinal.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
                        }
                        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal.Text = Convert.ToDecimal("10").ToString("F");
                                return;
                            }
                            decimal tempn = Convert.ToDecimal(stemp);
                            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                            this.txtPrecioFinal.Text = tempn2.ToString("F");
                        }
                    }
                }*/
            }


            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void CalculaPorcUtilidad1()
        //{
        //    try
        //    {


        //        if (this.txtIVPorc.Text.Length > 0)
        //        {
        //            if (this.chkGravado1.Checked)//tiene iv por agregarse
        //            {
        //                decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal.Text);
        //                decimal precioimpuesto = Convert.ToDecimal(this.txtPrecioImpuesto.Text);
        //                decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
        //               // decimal temp = precio + (precio * Convert.ToDecimal(iv));
        //       //         decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

        //       //         decimal fin = (temp + (temp * utilidad));
        //       //         this.txtPrecioFinal1.Text = fin.ToString("F");
        //                decimal fin=(preciofinal-precioimpuesto)/precioimpuesto;
        //                fin = fin * 100;
        //                Math.Round(fin,2);
        //                this.txtUtilPorc1.Text = fin.ToString("F");
        //            }
        //            else
        //            {
        //                decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal.Text);
        //                decimal precioimpuesto = Convert.ToDecimal(this.txtPrecioImpuesto.Text);

        //                decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

        //                decimal fin = (preciofinal - precioimpuesto) /precioimpuesto;
        //                fin = fin * 100;
        //                Math.Round(fin, 2);
        //                this.txtUtilPorc1.Text = fin.ToString("F");
        //                //decimal fin = (temp + (temp * utilidad));

        //                //this.txtPrecioFinal1.Text = fin.ToString("F");
        //            }

        //        }
        //        #region Codigo anterior
        //        //if (this.txtIVPorc.Text.Length > 0)
        //        //{
        //        //    if (this.chkGravado1.Checked)//tiene iv por agregarse
        //        //    {
        //        //        decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);
        //        //        decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal1.Text);
        //        //        decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
        //        //        decimal tempiva = precio + (precio * Convert.ToDecimal(iv));
        //        //       // decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);
        //        //      //  decimal temputil = (tempiva * Convert.ToDecimal(utilidad));
        //        //      //  decimal fin = (tempiva + temputil);
        //        //        decimal fin = (preciofinal - tempiva) / tempiva;
        //        //        fin = fin * 100;
        //        //        Math.Round(fin, 2);
        //        //        this.txtUtilPorc1.Text = fin.ToString("F");

        //        //        //string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

        //        //        //if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
        //        //        //{
        //        //        //    if (stemp.Length < 2)
        //        //        //    {
        //        //        //        this.txtPrecioFinal1.Text = Convert.ToDecimal("5").ToString("F");
        //        //        //        return;
        //        //        //    }
        //        //        //    this.txtPrecioFinal1.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
        //        //        //}
        //        //        //if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
        //        //        //{
        //        //        //    if (stemp.Length < 2)
        //        //        //    {
        //        //        //        this.txtPrecioFinal1.Text = Convert.ToDecimal("5").ToString("F");
        //        //        //        return;
        //        //        //    }
        //        //        //    this.txtPrecioFinal1.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
        //        //        //}
        //        //        //if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
        //        //        //{
        //        //        //    if (stemp.Length < 2)
        //        //        //    {
        //        //        //        this.txtPrecioFinal1.Text = Convert.ToDecimal("10").ToString("F");
        //        //        //        return;
        //        //        //    }

        //        //        //    decimal tempn = Convert.ToDecimal(stemp);
        //        //        //    decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
        //        //        //    this.txtPrecioFinal1.Text = tempn2.ToString("F");

        //        //        //}
        //        //    }
        //        //    else
        //        //    {
        //        //        decimal precio = Convert.ToDecimal(this.txtPrecio1.Text);
        //        //        decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal1.Text);
        //        //        decimal temp = precio;
        //        //        //decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

        //        //        //decimal fin = (temp + (temp * utilidad));
        //        //        decimal fin = (preciofinal - temp) / temp;
        //        //        fin = fin * 100;
        //        //        Math.Round(fin, 2);
        //        //        this.txtUtilPorc1.Text = fin.ToString("F");

        //        //        //string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

        //        //        //if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
        //        //        //{
        //        //        //    if (stemp.Length < 2)
        //        //        //    {
        //        //        //        this.txtPrecioFinal1.Text = Convert.ToDecimal("5").ToString("F");
        //        //        //        return;
        //        //        //    }
        //        //        //    this.txtPrecioFinal1.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
        //        //        //}
        //        //        //if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
        //        //        //{
        //        //        //    if (stemp.Length < 2)
        //        //        //    {
        //        //        //        this.txtPrecioFinal1.Text = Convert.ToDecimal("5").ToString("F");
        //        //        //        return;
        //        //        //    }
        //        //        //    this.txtPrecioFinal1.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
        //        //        //}
        //        //        //if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
        //        //        //{
        //        //        //    if (stemp.Length < 2)
        //        //        //    {
        //        //        //        this.txtPrecioFinal1.Text = Convert.ToDecimal("10").ToString("F");
        //        //        //        return;
        //        //        //    }
        //        //        //    decimal tempn = Convert.ToDecimal(stemp);
        //        //        //    decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
        //        //        //    this.txtPrecioFinal1.Text = tempn2.ToString("F");
        //        //        //}
        //        //    }
        //        //}
        //        #endregion
        //    }


        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void txtUtilPorc1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtUtilPorc1.Text == string.Empty || this.txtUtilPorc1.Text == "")
                {
                    this.txtUtilPorc1.Text = "0";
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtUtilPorc1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el porcentaje de utilidad ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtUtilPorc1.Text = "0";
                }
                this.CalculaPrecioFinal1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioFinal_TextChanged(object sender, EventArgs e)
        {
            ModificaPrecios1++;

            if (txtPrecioFinal.Text == "")
            {
                txtPrecioFinal.Text = "0.00";
            }
            if (Convert.ToDecimal(txtPrecioFinal.Text) > 0)
            {
                //CalculaPorcUtilidad1();
            }


            if ((Convert.ToDecimal(txtPrecioFinal.Text) > 0) && (Convert.ToDecimal(txtgram.Text) > 0))
            {
                txtprecioxgram.Text = (Convert.ToDecimal(txtPrecioFinal.Text) / Convert.ToDecimal(txtgram.Text)).ToString();
            }
        }



        private void CalculaPrecioFinal2()
        {
            try
            {
                if (Convert.ToDecimal(this.txtPrecio2.Text) == 0)
                {
                    this.txtPrecioFinal2.Text = "0.00";
                    return;
                }
                if (this.txtIVPorc.Text.Length > 0)
                {
                    if (this.chkGravado2.Checked)//tiene iv por agregarse
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
                        decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
                        decimal tempiva = precio + (precio * Convert.ToDecimal(iv));
                        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc2.Text) / 100);
                        decimal temputil = (tempiva * Convert.ToDecimal(utilidad));
                        decimal fin = (tempiva + temputil);
                        fin = Math.Round(fin, 0);
                        this.txtPrecioFinal2.Text = fin.ToString("F");

                        
                        //string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();
                        /*
                        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
                        }
                        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
                        }
                        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal2.Text = Convert.ToDecimal("10").ToString("F");
                                return;
                            }
                            decimal tempn = Convert.ToDecimal(stemp);
                            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                            this.txtPrecioFinal2.Text = tempn2.ToString("F");
                        }*/
                    }
                    else
                    {
                        
                        decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
                        decimal temp = precio;
                        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc2.Text) / 100);

                        decimal fin = (temp + (temp * utilidad));
                        this.txtPrecioFinal2.Text = fin.ToString("F");

                        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();
                        this.txtPrecioFinal2.Text = stemp;
                        /*
                        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
                        }
                        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                                return;
                            }
                            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
                        }
                        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                        {
                            if (stemp.Length < 2)
                            {
                                this.txtPrecioFinal2.Text = Convert.ToDecimal("10").ToString("F");
                                return;
                            }
                            decimal tempn = Convert.ToDecimal(stemp);
                            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                            this.txtPrecioFinal2.Text = tempn2.ToString("F");
                        }*/

                    }

                    //    if (this.txtIVPorc.Text.Length > 0)
                    //{
                    //    if (this.chkGravado2.Checked)//tiene iv por agregarse
                    //    {
                    //        decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
                    //        decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
                    //        decimal temp = precio + (precio * Convert.ToDecimal(iv));
                    //        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc2.Text) / 100);

                    //        decimal fin = (temp + (temp * utilidad));

                    //        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

                    //        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                    //        {
                    //            if (stemp.Length < 2)
                    //            {
                    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                    //                return;
                    //            }
                    //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
                    //        }
                    //        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                    //        {
                    //            if (stemp.Length < 2)
                    //            {
                    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                    //                return;
                    //            }
                    //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
                    //        }
                    //        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                    //        {
                    //            if (stemp.Length < 2)
                    //            {
                    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("10").ToString("F");
                    //                return;
                    //            }
                    //            decimal tempn = Convert.ToDecimal(stemp);
                    //            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                    //            this.txtPrecioFinal2.Text = tempn2.ToString("F");
                    //        }
                    //    }
                    //    else
                    //    {
                    //        decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
                    //        decimal temp = precio;
                    //        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc2.Text) / 100);

                    //        decimal fin = (temp + (temp * utilidad));

                    //        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

                    //        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                    //        {
                    //            if (stemp.Length < 2)
                    //            {
                    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                    //                return;
                    //            }
                    //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
                    //        }
                    //        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                    //        {
                    //            if (stemp.Length < 2)
                    //            {
                    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                    //                return;
                    //            }
                    //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
                    //        }
                    //        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                    //        {
                    //            if (stemp.Length < 2)
                    //            {
                    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("10").ToString("F");
                    //                return;
                    //            }
                    //            decimal tempn = Convert.ToDecimal(stemp);
                    //            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                    //            this.txtPrecioFinal2.Text = tempn2.ToString("F");
                    //        }
                    //    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void CalculaPorcUtilidad2()
        //{
        //    try
        //    {


        //        if (this.txtIVPorc.Text.Length > 0)
        //        {
        //            if (this.chkGravado2.Checked)//tiene iv por agregarse
        //            {
        //                decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal2.Text);
        //                decimal precioimpuesto = Convert.ToDecimal(this.txtPrecioImpuesto2.Text);
        //                decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
        //                decimal temp = precioimpuesto + (precioimpuesto * Convert.ToDecimal(iv));
        //                //         decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

        //                //         decimal fin = (temp + (temp * utilidad));
        //                //         this.txtPrecioFinal1.Text = fin.ToString("F");
        //                decimal fin = (preciofinal - precioimpuesto) / precioimpuesto;
        //                fin = fin * 100;
        //                Math.Round(fin, 2);
        //                this.txtUtilPorc2.Text = fin.ToString("F");
        //            }
        //            else
        //            {
        //                decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal2.Text);
        //                decimal precioimpuesto = Convert.ToDecimal(this.txtPrecioImpuesto2.Text);
        //                decimal temp = preciofinal;
        //                decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc2.Text) / 100);

        //                decimal fin = (preciofinal - precioimpuesto) / precioimpuesto;
        //                fin = fin * 100;
        //                Math.Round(fin, 2);
        //                this.txtUtilPorc2.Text = fin.ToString("F");
        //                //decimal fin = (temp + (temp * utilidad));

        //                //this.txtPrecioFinal1.Text = fin.ToString("F");
        //            }

        //        }
        //        if (this.txtIVPorc.Text.Length > 0)
        //        {
        //            if (this.chkGravado2.Checked)//tiene iv por agregarse
        //            {
        //                decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal2.Text);
        //                decimal precioimpuesto = Convert.ToDecimal(this.txtPrecioImpuesto2.Text);
        //                decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
        //                decimal tempiva = precioimpuesto + (precioimpuesto * Convert.ToDecimal(iv));
        //                // decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);
        //                //  decimal temputil = (tempiva * Convert.ToDecimal(utilidad));
        //                //  decimal fin = (tempiva + temputil);
        //                decimal fin = (preciofinal - precioimpuesto) / precioimpuesto;
        //                fin = fin * 100;
        //                Math.Round(fin, 2);
        //                this.txtUtilPorc2.Text = fin.ToString("F");

        //                //string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

        //                //if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
        //                //{
        //                //    if (stemp.Length < 2)
        //                //    {
        //                //        this.txtPrecioFinal1.Text = Convert.ToDecimal("5").ToString("F");
        //                //        return;
        //                //    }
        //                //    this.txtPrecioFinal1.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
        //                //}
        //                //if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
        //                //{
        //                //    if (stemp.Length < 2)
        //                //    {
        //                //        this.txtPrecioFinal1.Text = Convert.ToDecimal("5").ToString("F");
        //                //        return;
        //                //    }
        //                //    this.txtPrecioFinal1.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
        //                //}
        //                //if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
        //                //{
        //                //    if (stemp.Length < 2)
        //                //    {
        //                //        this.txtPrecioFinal1.Text = Convert.ToDecimal("10").ToString("F");
        //                //        return;
        //                //    }

        //                //    decimal tempn = Convert.ToDecimal(stemp);
        //                //    decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
        //                //    this.txtPrecioFinal1.Text = tempn2.ToString("F");

        //                //}
        //            }
        //            else
        //            {
        //                decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal2.Text);
        //                decimal precioimpuesto = Convert.ToDecimal(this.txtPrecioImpuesto2.Text);
        //                decimal temp = precioimpuesto;
        //                //decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

        //                //decimal fin = (temp + (temp * utilidad));
        //                decimal fin = (preciofinal - precioimpuesto) / precioimpuesto;
        //                fin = fin * 100;
        //                Math.Round(fin, 2);
        //                this.txtUtilPorc2.Text = fin.ToString("F");

        //                //string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

        //                //if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
        //                //{
        //                //    if (stemp.Length < 2)
        //                //    {
        //                //        this.txtPrecioFinal1.Text = Convert.ToDecimal("5").ToString("F");
        //                //        return;
        //                //    }
        //                //    this.txtPrecioFinal1.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
        //                //}
        //                //if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
        //                //{
        //                //    if (stemp.Length < 2)
        //                //    {
        //                //        this.txtPrecioFinal1.Text = Convert.ToDecimal("5").ToString("F");
        //                //        return;
        //                //    }
        //                //    this.txtPrecioFinal1.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
        //                //}
        //                //if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
        //                //{
        //                //    if (stemp.Length < 2)
        //                //    {
        //                //        this.txtPrecioFinal1.Text = Convert.ToDecimal("10").ToString("F");
        //                //        return;
        //                //    }
        //                //    decimal tempn = Convert.ToDecimal(stemp);
        //                //    decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
        //                //    this.txtPrecioFinal1.Text = tempn2.ToString("F");
        //                //}
        //            }
        //        }
        //    }


        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void txtUtilPorc2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtUtilPorc2.Text == string.Empty || this.txtUtilPorc2.Text == "")
                {
                    this.txtUtilPorc2.Text = "0";
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtUtilPorc2.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el porcentaje de utilidad ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtUtilPorc2.Text = "0";
                }
                this.CalculaPrecioFinal2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioFinal2_TextChanged_1(object sender, EventArgs e)
        {
            ModificaPrecios2++;
            if (txtPrecioFinal2.Text == "")
            {
                txtPrecioFinal2.Text = "0.00";
            }
            if (Convert.ToDecimal(txtPrecioFinal2.Text) > 0)
            {
                //CalculaPorcUtilidad2();
            }

            if ((Convert.ToDecimal(txtPrecioFinal2.Text) > 0) && (Convert.ToDecimal(txtgram.Text) > 0))
            {
                txtprecioxgram2.Text = (Convert.ToDecimal(txtPrecioFinal2.Text) / Convert.ToDecimal(txtgram.Text)).ToString();
            }
        }




        private void txtPrecio1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPrecio1.Text == string.Empty || this.txtPrecio1.Text == "")
                {
                    this.txtPrecio1.Text = "0.00";
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtPrecio1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el precio ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPrecio1.Text = "0.00";
                }
                this.CalculaPrecioImpuesto();
                this.CalculaPrecioFinal1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkGravado1_CheckedChanged(object sender, EventArgs e)
        {
            this.CalculaPrecioImpuesto();
            this.CalculaPrecioFinal1();
        }



        private void txtPrecio2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPrecio2.Text == string.Empty || this.txtPrecio2.Text == "")
                {
                    this.txtPrecio2.Text = "0.00";
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtPrecio2.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el precio ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPrecio2.Text = "0.00";
                }
                this.CalculaPrecioImpuesto2();
                this.CalculaPrecioFinal2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculaPrecioImpuesto2()
        {
            #region Codigo anterior
            //try
            //{
            //    if (Convert.ToDecimal(this.txtPrecio2.Text)==0)
            //    {
            //        this.txtPrecioFinal2.Text = "0.00";
            //        return;
            //    }
            //    if (this.txtIVPorc.Text.Length > 0)
            //    {
            //        if (this.chkGravado2.Checked)//tiene iv por agregarse
            //        {
            //            decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
            //            decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
            //            decimal tempiva =precio+(precio * Convert.ToDecimal(iv));
            //            decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc2.Text) / 100);
            //            decimal temputil = (tempiva * Convert.ToDecimal(utilidad));
            //            decimal fin = (tempiva + temputil);
            //            this.txtPrecioFinal2.Text = fin.ToString("F");

            //            string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

            //            if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
            //            {
            //                if (stemp.Length < 2)
            //                {
            //                    this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
            //                    return;
            //                }
            //                this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
            //            }
            //            if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
            //            {
            //                if (stemp.Length < 2)
            //                {
            //                    this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
            //                    return;
            //                }
            //                this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
            //            }
            //            if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
            //            {
            //                if (stemp.Length < 2)
            //                {
            //                    this.txtPrecioFinal2.Text = Convert.ToDecimal("10").ToString("F");
            //                    return;
            //                }
            //                decimal tempn = Convert.ToDecimal(stemp);
            //                decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
            //                this.txtPrecioFinal2.Text = tempn2.ToString("F");
            //            }
            //        }
            //        else
            //        {
            //            decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
            //            decimal temp = precio;
            //            decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc2.Text) / 100);

            //            decimal fin = (temp + (temp * utilidad));
            //            this.txtPrecioFinal2.Text = fin.ToString("F");

            //            string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

            //            if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
            //            {
            //                if (stemp.Length < 2)
            //                {
            //                    this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
            //                    return;
            //                }
            //                this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
            //            }
            //            if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
            //            {
            //                if (stemp.Length < 2)
            //                {
            //                    this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
            //                    return;
            //                }
            //                this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
            //            }
            //            if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
            //            {
            //                if (stemp.Length < 2)
            //                {
            //                    this.txtPrecioFinal2.Text = Convert.ToDecimal("10").ToString("F");
            //                    return;
            //                }
            //                decimal tempn = Convert.ToDecimal(stemp);
            //                decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
            //                this.txtPrecioFinal2.Text = tempn2.ToString("F");
            //            }

            //        }                

            //    //    if (this.txtIVPorc.Text.Length > 0)
            //    //{
            //    //    if (this.chkGravado2.Checked)//tiene iv por agregarse
            //    //    {
            //    //        decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
            //    //        decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
            //    //        decimal temp = precio + (precio * Convert.ToDecimal(iv));
            //    //        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc2.Text) / 100);

            //    //        decimal fin = (temp + (temp * utilidad));

            //    //        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

            //    //        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
            //    //        {
            //    //            if (stemp.Length < 2)
            //    //            {
            //    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
            //    //                return;
            //    //            }
            //    //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
            //    //        }
            //    //        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
            //    //        {
            //    //            if (stemp.Length < 2)
            //    //            {
            //    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
            //    //                return;
            //    //            }
            //    //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
            //    //        }
            //    //        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
            //    //        {
            //    //            if (stemp.Length < 2)
            //    //            {
            //    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("10").ToString("F");
            //    //                return;
            //    //            }
            //    //            decimal tempn = Convert.ToDecimal(stemp);
            //    //            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
            //    //            this.txtPrecioFinal2.Text = tempn2.ToString("F");
            //    //        }
            //    //    }
            //    //    else
            //    //    {
            //    //        decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
            //    //        decimal temp = precio;
            //    //        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc2.Text) / 100);

            //    //        decimal fin = (temp + (temp * utilidad));

            //    //        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

            //    //        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
            //    //        {
            //    //            if (stemp.Length < 2)
            //    //            {
            //    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
            //    //                return;
            //    //            }
            //    //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
            //    //        }
            //    //        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
            //    //        {
            //    //            if (stemp.Length < 2)
            //    //            {
            //    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
            //    //                return;
            //    //            }
            //    //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
            //    //        }
            //    //        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
            //    //        {
            //    //            if (stemp.Length < 2)
            //    //            {
            //    //                this.txtPrecioFinal2.Text = Convert.ToDecimal("10").ToString("F");
            //    //                return;
            //    //            }
            //    //            decimal tempn = Convert.ToDecimal(stemp);
            //    //            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
            //    //            this.txtPrecioFinal2.Text = tempn2.ToString("F");
            //    //        }
            //    //    }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion
            try
            {
                if (Convert.ToDecimal(this.txtPrecio2.Text) == 0)
                {
                    this.txtPrecioImpuesto2.Text = "0.00";
                    return;
                }

                if (this.txtIVPorc.Text.Length > 0)
                {
                    if (this.chkGravado2.Checked)//tiene iv por agregarse
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
                        decimal preciofinal = Convert.ToDecimal(this.txtPrecioImpuesto2.Text);
                        decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
                        decimal temp = precio + (precio * Convert.ToDecimal(iv));
                        //  decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);
                        
                        //   decimal fin = (temp + (temp * utilidad));
                        decimal fin = temp;


                        ///AQUI TENGO QUE CAMBIAR

                        this.txtPrecioImpuesto2.Text = fin.ToString("F");


                    }
                    else
                    {
                        decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
                        decimal temp = precio;
                        //  decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

                        //   decimal fin = (temp + (temp * utilidad));
                        decimal fin = temp;

                        this.txtPrecioImpuesto2.Text = fin.ToString("F");
                    }
                    CalculaPrecioFinal2();

                }
                #region codigo anterior
                //if (this.txtIVPorc.Text.Length > 0)
                //{
                //    if (this.chkGravado2.Checked)//tiene iv por agregarse
                //    {
                //        decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
                //        decimal preciofinal = Convert.ToDecimal(this.txtPrecioFinal2.Text);
                //        decimal iv = Convert.ToDecimal(this.txtIVPorc.Text) / 100;
                //        decimal tempiva = precio + (precio * Convert.ToDecimal(iv));
                //        decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc2.Text) / 100);
                //        //   decimal temputil = (tempiva * Convert.ToDecimal(utilidad));
                //        //   decimal fin = (tempiva + temputil);
                //        decimal fin = (tempiva);

                //        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

                //        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                //        {
                //            if (stemp.Length < 2)
                //            {
                //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                //                return;
                //            }
                //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
                //        }
                //        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                //        {
                //            if (stemp.Length < 2)
                //            {
                //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                //                return;
                //            }
                //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
                //        }
                //        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                //        {
                //            if (stemp.Length < 2)
                //            {
                //                this.txtPrecioFinal2.Text = Convert.ToDecimal("10").ToString("F");
                //                return;
                //            }

                //            decimal tempn = Convert.ToDecimal(stemp);
                //            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                //            this.txtPrecioFinal2.Text = tempn2.ToString("F");

                //        }
                //    }
                //    else
                //    {
                //        decimal precio = Convert.ToDecimal(this.txtPrecio2.Text);
                //        decimal temp = precio;
                //        //   decimal utilidad = Convert.ToDecimal(Convert.ToDecimal(this.txtUtilPorc1.Text) / 100);

                //        //    decimal fin = (temp + (temp * utilidad));
                //        decimal fin = temp;
                //        string stemp = Math.Round(fin, 0, MidpointRounding.AwayFromZero).ToString();

                //        if (0 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 3)
                //        {
                //            if (stemp.Length < 2)
                //            {
                //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                //                return;
                //            }
                //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "0")).ToString("F");
                //        }
                //        if (3 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) < 8)
                //        {
                //            if (stemp.Length < 2)
                //            {
                //                this.txtPrecioFinal2.Text = Convert.ToDecimal("5").ToString("F");
                //                return;
                //            }
                //            this.txtPrecioFinal2.Text = Convert.ToDecimal((stemp.Substring(0, stemp.Length - 1) + "5")).ToString("F");
                //        }
                //        if (8 <= Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) && Convert.ToInt32(stemp.Substring(stemp.Length - 1, 1)) <= 9)
                //        {
                //            if (stemp.Length < 2)
                //            {
                //                this.txtPrecioFinal2.Text = Convert.ToDecimal("10").ToString("F");
                //                return;
                //            }
                //            decimal tempn = Convert.ToDecimal(stemp);
                //            decimal tempn2 = ((decimal)Math.Round(tempn / Convert.ToDecimal(10.0))) * 10;
                //            this.txtPrecioFinal2.Text = tempn2.ToString("F");
                //        }
                //    }

                // }
                #endregion
            }


            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar calcular el precio del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkGravado2_CheckedChanged(object sender, EventArgs e)
        {
            this.CalculaPrecioImpuesto2();
        }



        private void Inventario_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void btnBuscaProveedor_Click(object sender, EventArgs e)
        {
            Sel_Proveedor ProveedorAsignar = new Sel_Proveedor(this);
            ProveedorAsignar.tipo = 0;
            ProveedorAsignar.TopLevel = false;
            ProveedorAsignar.Parent = this;
            ProveedorAsignar.Show();
        }

        public void CambiaProveedor()
        {
            try
            {
                this.cmbProveedor.SelectedValue = ProveedorId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el proveedor: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CambiaUbicacion()
        {
            try
            {
                this.cmbUbicacion.SelectedValue = UbicacionId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la ubicación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CambiaFamilia()
        {
            try
            {
                this.cmbFamilia.SelectedValue = FamiliaId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CambiaUnidadMedida()
        {
            try
            {
                this.cmbUnidadMedida.SelectedValue = UnidadMedida;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la unidad de medida: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaFamilia_Click(object sender, EventArgs e)
        {
            Sel_Familia FamiliaAsignar = new Sel_Familia(this);
            FamiliaAsignar.TopLevel = false;
            FamiliaAsignar.Parent = this;
            FamiliaAsignar.Show();
        }



        private void txtPrecioImpuesto_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtPrecioImpuesto2_TextChanged(object sender, EventArgs e)
        {


        }


        private void cmbProveedor_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscaUnidadMedida_Click(object sender, EventArgs e)
        {
            Sel_UnidadMedida UnidadMedidaAsignar = new Sel_UnidadMedida(this);
            UnidadMedidaAsignar.TopLevel = false;
            UnidadMedidaAsignar.Parent = this;
            UnidadMedidaAsignar.Show();
        }

        private void btnBuscaUbicacion_Click(object sender, EventArgs e)
        {
            Sel_Ubicacion ubicacionasignar = new Sel_Ubicacion(this);
            ubicacionasignar.TopLevel = false;
            ubicacionasignar.Parent = this;
            ubicacionasignar.Show();
        }

        private void txtCompra2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String compra;
                String descuento;

                decimal monto_descuento;
                decimal monto_precio;

                try
                {
                    decimal x = Convert.ToDecimal(this.txtCompra2.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el monto de compra ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtCompra2.Text = "0.00";
                }
                if (txtdescuento_2.Text != "0")
                {


                    compra = txtCompra2.Text;
                    descuento = txtdescuento_2.Text;
                    monto_descuento = Convert.ToDecimal(compra) * (Convert.ToDecimal(descuento) / 100);
                    monto_precio = Convert.ToDecimal(compra) - monto_descuento;
                    this.txtPrecio2.Text = monto_precio.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtCompra1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String compra;
                String descuento;

                decimal monto_descuento;
                decimal monto_precio;

                try
                {
                    decimal x = Convert.ToDecimal(this.txtCompra1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el monto de compra ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtCompra1.Text = "0.00";
                }
                if (txtdescuento_1.Text != "0")
                {


                    compra = txtCompra1.Text;
                    descuento = txtdescuento_1.Text;
                    monto_descuento = Convert.ToDecimal(compra) * (Convert.ToDecimal(descuento) / 100);
                    monto_precio = Convert.ToDecimal(compra) - monto_descuento;
                    this.txtPrecio1.Text = monto_precio.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtdescuento_1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    decimal x = Convert.ToDecimal(this.txtdescuento_1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el descuento ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtdescuento_1.Text = "0.00";
                }
                String compra;
                String descuento;

                decimal monto_descuento;
                decimal monto_precio;
                //  MessageBox.Show("la compra es de " + Convert.ToDecimal(txtCompra1.Text.ToString()));
                if (txtCompra1.Text != "0.00")
                {

                    compra = txtCompra1.Text;
                    descuento = txtdescuento_1.Text;
                    decimal porcentaje_descuento = (Convert.ToDecimal(descuento) / 100);
                    monto_descuento = Convert.ToDecimal(compra) * porcentaje_descuento;

                    monto_precio = Convert.ToDecimal(compra) - monto_descuento;

                    this.txtPrecio1.Text = monto_precio.ToString();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtdescuento_2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    decimal x = Convert.ToDecimal(this.txtdescuento_2.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para el descuento ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtdescuento_2.Text = "0.00";
                }
                String compra;
                String descuento;

                decimal monto_descuento;
                decimal monto_precio;
                //  MessageBox.Show("la compra es de " + Convert.ToDecimal(txtCompra1.Text.ToString()));
                if (txtCompra2.Text != "0.00")
                {

                    compra = txtCompra2.Text;
                    descuento = txtdescuento_2.Text;
                    decimal porcentaje_descuento = (Convert.ToDecimal(descuento) / 100);
                    monto_descuento = Convert.ToDecimal(compra) * porcentaje_descuento;

                    monto_precio = Convert.ToDecimal(compra) - monto_descuento;

                    this.txtPrecio2.Text = monto_precio.ToString();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtgram_TextChanged(object sender, EventArgs e)
        {
            decimal gram;
            try
            {
                gram = Convert.ToDecimal(this.txtgram.Text);
                if ((Convert.ToDecimal(txtPrecioFinal.Text) > 0) && (Convert.ToDecimal(txtgram.Text) > 0))
                {
                    txtprecioxgram.Text = (Convert.ToDecimal(txtPrecioFinal.Text) / Convert.ToDecimal(txtgram.Text)).ToString();
                }

                if ((Convert.ToDecimal(txtPrecioFinal2.Text) > 0) && (Convert.ToDecimal(txtgram.Text) > 0))
                {
                    txtprecioxgram2.Text = (Convert.ToDecimal(txtPrecioFinal2.Text) / Convert.ToDecimal(txtgram.Text)).ToString();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Para el gran de  ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtgram.Text = "0";
            }

        }

        private void txtprecioxgram_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtprecioxgram2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}



