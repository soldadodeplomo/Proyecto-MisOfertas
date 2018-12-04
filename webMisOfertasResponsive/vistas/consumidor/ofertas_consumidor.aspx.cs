using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaMisOfertas;
using DatosMisOfertas;

namespace webMisOfertasResponsive.vistas.consumidor
{
    public partial class ofertas_consumidor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Consumidor c = new Consumidor();   
            if(Session["usuarioTemporal"]!=null && Session["consumidorTemporal"]!=null)
            {
                lblNombreUsuario.Text = Session["usuarioTemporal"].ToString();
                c = (Consumidor)Session["consumidorTemporal"];
            }
            else
            {
                Response.Redirect("/vistas/login_consumidor.aspx");
            }
            administrarOfertasPorCorreo oferta = new administrarOfertasPorCorreo();
            if(oferta.ifValoraciones(c))
            {
                oferta.listarOfertasPorRubro(phOfertaConsumidor);
            }
            else
            {
                lblMensajito.Text = oferta.mensajeConsumidor;
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/vistas/login_consumidor.aspx");
        }
    }
}