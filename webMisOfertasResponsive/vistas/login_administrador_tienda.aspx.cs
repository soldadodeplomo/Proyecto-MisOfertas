using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaMisOfertas;
using DatosMisOfertas;

namespace webMisOfertasResponsive.vistas
{
    public partial class login_administrador_tienda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void btnIngresarSesionAdminitrador_Click(object sender, EventArgs e)
        {
            loginAdministrador log = new loginAdministrador();
            if(log.iniciarSesionAdm(txtRunAdmTienda.Text, txtPasswordAdmTienda.Text))
            {
                AdministradorTienda adm = new AdministradorTienda();
                adm.rutAdm = log.admTienda.rutAdm;
                Session["administrador"] = adm.rutAdm;                
                Response.Redirect("/vistas/administradorTienda/consultar_ofertas.aspx");
            }
            else
            {
                lblMensajeError.Text = "No existe el usuario o no tienes los permisos necesarios";
            }
        }
    }
}