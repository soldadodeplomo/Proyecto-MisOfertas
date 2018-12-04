using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatosMisOfertas;
using LibreriaMisOfertas;


namespace webMisOfertasResponsive.vistas.administradorTienda.producto
{
    public partial class insertar_producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (Session["administrador"]!=null)
            {
                //Label2.Text = Session["usuarioTemporal"].ToString();
                AdministradorTienda adm = new AdministradorTienda();
                Session["consumidorTemporal"] = adm.rutAdm;
            }
            else
            {
                Response.Redirect("/vistas/login_administrador_tienda.aspx");
            }
            llenarDDL ddl = new llenarDDL();
            if (!IsPostBack)
            {
                ddl.llenarDDLRubro(ddlRubro);
                //ddl.llenarLote(ddLote);
                ddl.llenarSubFamilia(ddlSubFamilia);
                ddl.llenarMarca(ddlMarca);
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(txtVentaMaxima.Text) < Convert.ToInt32(txtVentaMinima.Text))
                {
                    lblMensaje.Text = "La venta mínima debe ser menor a la venta máxima";
                }
                else
                {
                    Producto prodTemporal = new Producto();
                    administracionProducto admProducto = new administracionProducto();
                    prodTemporal.nombreProducto = txtNombreProducto.Text;
                    prodTemporal.precioProducto = Convert.ToInt32(txtPrecioProducto.Text);
                    prodTemporal.marca = ddlMarca.SelectedValue;
                    prodTemporal.imagenProducto = admProducto.imageToByte(inputImagenProducto.FileName);
                    prodTemporal.ventaMin = Convert.ToInt32(txtVentaMinima.Text);
                    prodTemporal.ventaMax = Convert.ToInt32(txtVentaMaxima.Text);
                    prodTemporal.idRubro = Convert.ToInt32(ddlRubro.SelectedValue);
                    //prodTemporal.idLote = Convert.ToInt32(ddLote.SelectedValue);
                    prodTemporal.idSubFamilia = Convert.ToInt32(ddlSubFamilia.SelectedValue);
                    admProducto.agregarProducto(prodTemporal, ddlMarca);
                    limpiarCampos();
                    lblMensaje.Text = "Producto " + txtNombreProducto.Text + " agregado con éxito.\n Revisa los productos existentes <a href='~/vistas/administradorTienda/producto/listar_productos.aspx'>aquí</a>" + ".";
                }                
            } 
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
            
        }

        public void limpiarCampos()
        {
            txtNombreProducto.Text = string.Empty;
            txtPrecioProducto.Text = string.Empty;
            txtVentaMinima.Text = string.Empty;
            txtVentaMaxima.Text = string.Empty;
        }
    }
}