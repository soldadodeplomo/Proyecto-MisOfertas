using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaMisOfertas;
using DatosMisOfertas;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using System.Diagnostics;
using System.Net;
using System.Data;
using BarcodeLib;
using System.Drawing;


namespace webMisOfertasResponsive.vistas.consumidor
{
    public partial class descargar_cupon : System.Web.UI.Page
    {
        Consumidor consumidorTemporal = new Consumidor();
        CertificadoDescuento certificadoTemp = new CertificadoDescuento();
        administrarOfertasPorCorreo correo = new administrarOfertasPorCorreo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioTemporal"] != null && Session["consumidorTemporal"] != null)
            {
                Session["usuarioTemporal"].ToString();
                consumidorTemporal = (Consumidor)Session["consumidorTemporal"];
            }
            else
            {
                Response.Redirect("/vistas/login_consumidor.aspx");
            }
            correo.generarCodigoBarras(consumidorTemporal);
            correo.generarPDF(consumidorTemporal);
            correo.enviarCorreoOferta(consumidorTemporal);
            correo.insertarBitacora(consumidorTemporal);
            mostrarPDF();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/vistas/login_consumidor.aspx");
        }     
        
        public void mostrarPDF()
        {
            Response.Clear();
            string filePath = @"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsiveWork\webMisOfertasResponsive\webMisOfertasResponsive\tempDocs\cupon_descuento_1_" + consumidorTemporal.runConsumidor+".pdf";
            Response.ContentType = "application/pdf";
            Response.WriteFile(filePath);
        }                 
    }
}