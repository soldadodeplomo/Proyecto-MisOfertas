using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibreriaMisOfertas;
using System.IO;
using DatosMisOfertas;

namespace webMisOfertasResponsive.vistas.consumidor
{
    public partial class valorizar_oferta : System.Web.UI.Page
    {
        LibreriaMisOfertas.llenarDDL ddl= new LibreriaMisOfertas.llenarDDL();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (Session["usuarioTemporal"] != null && Session["consumidorTemporal"] != null)
            {
                lblConsumidor.Text = Session["usuarioTemporal"].ToString();
            }
            else
            {
                Response.Redirect("/vistas/login_consumidor.aspx");
            }
            if(!IsPostBack)
            {
                ddl.llenarDDLRubro(ddlRubroCompra);
                ddl.llenarDDLValoracion(ddlPuntajeValoracion);
                ddl.llenarLocalVenta(ddlLocalVenta);
            }
        }
        protected void btnValorizarOferta_Click(object sender, EventArgs e)
        {
            CertificadoDescuento certificado = new CertificadoDescuento();
            Consumidor t = new Consumidor();
            t= (Consumidor)Session["consumidorTemporal"];

            administracionImagenBoleta boleta = new administracionImagenBoleta();
            administracionValorizacionOferta valoracion = new administracionValorizacionOferta();
            administracionLoginRegistroConsumidor datosSession = new administracionLoginRegistroConsumidor();
            administracionPuntosAcumulados puntos = new administracionPuntosAcumulados();

            boleta.agregarBoleta(boleta.imageToByte(fuImagenBoleta.FileName));
            puntos.actualizarCupon(t);
            valoracion.agregarValoracionOferta(ddlPuntajeValoracion.SelectedIndex, t.idConsumidor, t.runConsumidor, t.correoConsumidor, Convert.ToInt32(ddlLocalVenta.SelectedValue), Convert.ToInt32(ddlRubroCompra.SelectedValue));
            lblMensajeError.Text = "¡Haz acumulado 10 puntos!. En total tienes: "+puntos.total;// agregar total de puntos
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/vistas/login_consumidor.aspx");
        }
    }

    //t.runConsumidor = certificado.rutConsumidor;
    //t.correoConsumidor = certificado.correoConsumidor;
    //valoracion.agregarValoracionOferta(ddlPuntajeValoracion.SelectedIndex, datosSession.cons.runConsumidor, datosSession.cons.correoConsumidor,Convert.ToInt32(ddlRubroCompra.SelectedValue));
}