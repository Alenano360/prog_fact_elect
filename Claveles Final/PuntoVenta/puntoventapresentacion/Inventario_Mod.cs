using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using PuntoVentaBL;

namespace PuntoVentaPresentacion
{
    public partial class Inventario_Mod : Form
    {
        PuntoVentaBL.Reporte MyDataGridViewPrinter;

        PuntoVentaBL.Facturar objFacturar = new PuntoVentaBL.Facturar();

        Sel_Mod _owner;

        string temp = string.Empty;

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        public Inventario_Mod(Sel_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();            
        }

        public void Inventario_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();
                this.ActiveControl = this.txtBuscarCodigo;

                this.objInventario.ObtieneInventario(this.dgvDatos);
                

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)        
        {
            //try
            //{
            //    if (e.KeyChar == (char)13)
            //    {
            //        //try
            //        //{
            //        //    Int64 x = Convert.ToInt64(this.txtBuscar.Text);
            //        //}
            //        //catch (Exception)
            //        //{
            //        //    MessageBox.Show("Para la búsqueda ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //    this.txtBuscar.Text = string.Empty;
            //        //    this.objInventario.ObtieneInventario(this.dgvDatos);
            //        //}

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hubo un inconveniente al intentar obtener el producto del inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario_Mantenimiento InventarioAgregar= new Inventario_Mantenimiento(this);
                InventarioAgregar.TopLevel = false;
                InventarioAgregar.Parent = this;
                InventarioAgregar.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto al inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                //validar que el usuario sea administrador
                PuntoVentaBL.Consultas Consultas = new PuntoVentaBL.Consultas();
               // MessageBox.Show("login.userid es " + Login.UserId);
                bool EstadoRol = Consultas.VerificarUsuario(Login.UserId);
                if (!EstadoRol)
                {
                    MessageBox.Show("Este usuario no tiene permisos para modificar inventario");
                    return;
                }
               
                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione el articulo a modificar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el articulo?", "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    
                        this.dgvDatos.Columns[0].Visible = true;
                        this.objInventario.ObtieneProductoModificar(Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value));

                        Inventario_Mantenimiento InventarioAgregar = new Inventario_Mantenimiento(this);
                        InventarioAgregar.TopLevel = false;
                        InventarioAgregar.Parent = this;
                        InventarioAgregar.Accion = 1;
                        InventarioAgregar.gran = this.objInventario.Gram.ToString();
                        InventarioAgregar.granxprecio = this.objInventario.precioxGram.ToString();
                        InventarioAgregar.granprecio2 = this.objInventario.precioxGram2.ToString();
                        

                        InventarioAgregar.Id = this.objInventario.Id.ToString();
                        InventarioAgregar.Codigo = this.objInventario.Codigo.ToString();
                        InventarioAgregar.Codigo2 = this.objInventario.Codigo2.ToString();
                        InventarioAgregar.ConsignacionS = this.objInventario.Consignacion.ToString();
                        InventarioAgregar.Descripcion = this.objInventario.Descripcion.ToString();
                        InventarioAgregar.ProveedorIdS = this.objInventario.ProveedorId.ToString();
                        InventarioAgregar.FamiliaIdS = this.objInventario.FamiliaId.ToString();
                        InventarioAgregar.UbicacionIdS = this.objInventario.UbicacionId.ToString();
                        InventarioAgregar.Existencias = this.objInventario.Existencias.ToString();
                        InventarioAgregar.FechaUltimaCompra = this.objInventario.FechaUltimaCompra.ToString();
                        InventarioAgregar.PorcImpVentas = this.objInventario.PorcImpVentas.ToString();
                        InventarioAgregar.Precio = this.objInventario.Precio.ToString();
                        InventarioAgregar.IV = this.objInventario.IV.ToString();
                        InventarioAgregar.UtilidadPrecio = this.objInventario.UtilidadPrecio.ToString();
                        InventarioAgregar.PrecioIVU = this.objInventario.PrecioIVU.ToString();
                        InventarioAgregar.Precio2 = this.objInventario.Precio2.ToString();
                        InventarioAgregar.IVPrecio2 = this.objInventario.IVPrecio2.ToString();
                        InventarioAgregar.UtilidadPrecio2 = this.objInventario.UtilidadPrecio2.ToString();
                        InventarioAgregar.Precio2IVU = this.objInventario.Precio2IVU.ToString();
                        InventarioAgregar.UnidadMedidaS = this.objInventario.UnidadMedidaId.ToString();

                        InventarioAgregar.Observacion = this.objInventario.Observacion.ToString();
                        
                        InventarioAgregar.Show();


                        this.dgvDatos.Columns[0].Visible = false;
                        this.ActiveControl = this.txtBuscarCodigo;
                        this.txtBuscarCodigo.Text = string.Empty;
                    }
                
                    
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el producto del inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PuntoVentaBL.Consultas Consultas = new PuntoVentaBL.Consultas();
            // MessageBox.Show("login.userid es " + Login.UserId);
            bool EstadoRol = Consultas.VerificarUsuario(Login.UserId);
            if (!EstadoRol)
            {
                MessageBox.Show("Este usuario no tiene permisos para eliminar inventario");
                return;
            }


            if (Login.RolId.ToString() == "1")//solo admin puede ver
            {
                try
                {
                    if (this.dgvDatos.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione el articulo a eliminar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el articulo?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        this.dgvDatos.Columns[0].Visible = true;
                        //eliminar articulo
                        if (this.objInventario.EliminaProducto(this.dgvDatos, Convert.ToInt32(this.dgvDatos.Rows[this.dgvDatos.CurrentCell.RowIndex].Cells[0].Value), Login.UserId))
                        {
                            MessageBox.Show("Artículo eliminado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.dgvDatos.Columns[0].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar el producto del inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.objInventario.ObtieneInventario(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario_Reportes InventarioReportes = new Inventario_Reportes(this);
                InventarioReportes.TopLevel = false;
                InventarioReportes.Parent = this;
                InventarioReportes.Show();

                //MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos, pd_reporte, true, true, "Reporte", new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

                //PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();                

                //printPrvDlg.Document = pd_reporte;

                //printPrvDlg.ShowDialog();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el reporte del inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  

        private bool instaladorImpresora()
        {
            PrintDialog dialogo_impresion = new PrintDialog();
            dialogo_impresion.AllowCurrentPage = false;
            dialogo_impresion.AllowPrintToFile = false;
            dialogo_impresion.AllowSelection = false;
            dialogo_impresion.AllowSomePages = false;
            dialogo_impresion.PrintToFile = false;
            dialogo_impresion.ShowHelp = false;
            dialogo_impresion.ShowNetwork = false;
            

            if (dialogo_impresion.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            pd_reporte.DocumentName = "REPORTE";
            pd_reporte.PrinterSettings = dialogo_impresion.PrinterSettings;
            pd_reporte.DefaultPageSettings = dialogo_impresion.PrinterSettings.DefaultPageSettings;
            pd_reporte.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
            pd_reporte.DefaultPageSettings.Landscape = true;

            MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos, pd_reporte, true, true, "Reporte", new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

            
            return true;
        }

        private void pd_reporte_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool mas_paginas = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (mas_paginas == true)
            {
                e.HasMorePages = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbOrdenar.Text != "--Seleccione--")
                {
                    //MessageBox.Show("Seleccione un método de ordenamiento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                    this.objInventario.ObtieneProductoInventarioOrdenada(this.dgvDatos, this.cmbOrdenar.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void Inventario_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);                     
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.btnModificar.PerformClick();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el producto del inventario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvDatos.Columns[e.ColumnIndex].Name == "Existencias")
            {
                if (Convert.ToDecimal(e.Value) < 3)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == (Keys.Enter))
                {
                    if (this.txtNombre.Text.Length == 0)
                    {
                        this.dgvDatos.Rows.Clear();
                        return;
                    }

                    this.dgvDatos.Rows.Clear();

                    this.objFacturar.Descripcion = this.txtNombre.Text;

                    this.objFacturar.TipoPrecio = 3;

                        if (this.objFacturar.ObtieneProducto(this.dgvDatos) == false)
                        {
                            return;
                        }
                }

 

                    e.Handled = true;

                    //e.SuppressKeyPress = true;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar consultar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string hhh = string.Empty;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBuscarCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == (Keys.Enter))
                {
                    if (this.txtBuscarCodigo.Text.Length == 0)
                    {
                        this.dgvDatos.Rows.Clear();
                        return;
                    }

                    this.dgvDatos.Rows.Clear();

                    this.objFacturar.Descripcion = this.txtBuscarCodigo.Text;

                    this.objFacturar.TipoPrecio = 3;

                    if (this.objFacturar.ObtieneProductoId(this.dgvDatos) == false)
                    {
                        return;
                    }
                }



                e.Handled = true;

                //e.SuppressKeyPress = true;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar consultar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BitacoraInventario cs = new BitacoraInventario();
            //cs.TopLevel = false;
            //cs.Parent = this;
            cs.Show();
            
        }








    }
}
