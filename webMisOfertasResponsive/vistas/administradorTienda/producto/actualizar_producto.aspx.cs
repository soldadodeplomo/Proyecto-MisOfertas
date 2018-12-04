using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaMisOfertas;
using DatosMisOfertas;

namespace webMisOfertasResponsive.vistas.administradorTienda.producto
{
    public partial class actualizar_producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["administrador"] != null)
            {
                lblUsuario.Text = Session["administrador"].ToString();
            }
            else
            {
                Response.Redirect("/vistas/login_administrador_tienda.aspx");
            }
            llenarDDL llenar = new llenarDDL();
            if(!IsPostBack)
            {
                llenar.llenarDDLRubro(ddlRubroProducto);
                llenar.llenarMarca(ddlMarcaProducto);
                llenar.llenarSubFamilia(ddlSubFamiliaProducto);
            }
        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            Producto prodTemporal = new Producto();
            administracionProducto producto = new administracionProducto();
            try
            {
                prodTemporal.sku = Convert.ToInt32(txtSkuProducto.Text);
                //prodTemporal.nombreProducto = txtNombreProd.Text;
                producto.buscarProducto(prodTemporal);

                //Cargar datos   
                lblSku.Text = producto.salida.sku.ToString();
                txtNombreProducto.Text = producto.salida.nombreProducto.ToString();
                txtPrecioProducto.Text = producto.salida.precioProducto.ToString();
                lblMarcaActual.Text = producto.salida.marca;
                txtVentaMinima.Text = producto.salida.ventaMin.ToString();
                txtVentaMaxima.Text = producto.salida.ventaMax.ToString();
                lblLoteProveedor.Text = producto.salida.idLote.ToString();
            }
            catch (Exception ex)
            {
                lblError.Text = producto.error;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Producto productoTemporal = new Producto();
            administracionProducto producto = new administracionProducto();
            try
            {
                productoTemporal.sku = Convert.ToInt32(lblSku.Text);
                productoTemporal.nombreProducto = txtNombreProducto.Text;
                productoTemporal.precioProducto = Convert.ToInt32(txtPrecioProducto.Text);
                productoTemporal.marca = ddlMarcaProducto.SelectedValue;
                productoTemporal.ventaMin = Convert.ToInt32(txtVentaMinima.Text);
                productoTemporal.ventaMax = Convert.ToInt32(txtVentaMaxima.Text);
                productoTemporal.idRubro = Convert.ToInt32(ddlRubroProducto.SelectedValue);
                productoTemporal.idSubFamilia = Convert.ToInt32(ddlSubFamiliaProducto.SelectedValue);
                producto.actualizarProducto(productoTemporal);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}