using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaMisOfertas;

namespace webMisOfertasResponsive.vistas.administradorTienda
{
    public partial class reporte_valoracion_compra : System.Web.UI.Page
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
            ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            administracionValorizacionOferta oferta = new administracionValorizacionOferta();
            oferta.obtenerValoracionesPositivas(phValoracionesPositivas);
            oferta.obtenerValoracionesNegativas(phValoracionesNegativas);


        }

        protected void btnCerrarSesionAdministrador_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/vistas/login_administrador_tienda.aspx");
        }
    }
}