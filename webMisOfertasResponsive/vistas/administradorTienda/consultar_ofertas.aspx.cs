using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webMisOfertasResponsive.vistas.administradorTienda
{
    public partial class consultar_ofertas : System.Web.UI.Page
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
        }

        protected void btnCerrarSesionAdministrador_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/vistas/login_administrador_tienda.aspx");
        }
    }
}