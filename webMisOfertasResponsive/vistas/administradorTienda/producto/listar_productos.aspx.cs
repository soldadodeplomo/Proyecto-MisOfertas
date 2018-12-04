using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using LibreriaMisOfertas;

namespace webMisOfertasResponsive.vistas.administradorTienda.producto
{
    public partial class listar_productos : System.Web.UI.Page
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
            administracionProducto producto = new administracionProducto();
            if(!IsPostBack)
            {
                producto.listarTodoProductos(phListarProducto);
            }
        }        
    }
}