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
    public partial class prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void btnIngresarSesionConsumidor_Click(object sender, EventArgs e)
        {
            administracionLoginRegistroConsumidor admConsumidor = new administracionLoginRegistroConsumidor();            
            Consumidor cons = new Consumidor();
            cons.correoConsumidor = txtCorreoConsumidor.Text;
            cons.contrasenaConsumidor = txtPasswordConsumidor.Text;
            if(admConsumidor.iniciarSesion(cons))
            {
                //Se crea una instancia de la clase Consumidor @temp, la cual estara dentro de una sesion interna @Session["consumidorTemporal"]
                Consumidor temp = new Consumidor();
                Session["usuarioTemporal"] = admConsumidor.consumidorExterno.nombreConsumidor.ToUpper();

                //Se asignan los datos traidos desde la bd a la instancia @temp de Consumidor
                temp.idConsumidor = admConsumidor.consumidorExterno.idConsumidor;
                temp.nombreConsumidor = admConsumidor.consumidorExterno.nombreConsumidor;
                temp.runConsumidor = admConsumidor.consumidorExterno.runConsumidor;
                temp.correoConsumidor = admConsumidor.consumidorExterno.correoConsumidor;
                temp.recibirOferta = admConsumidor.consumidorExterno.recibirOferta;
                //se guardan la instancia @temp en la variable de session interna
                Session["consumidorTemporal"] = temp;
                Response.Redirect("/vistas/consumidor/ofertas_consumidor.aspx");
            }
            else
            {
                Label1.Text = "Los datos ingresados no se encuentran en nuestros registros.";
            }
            //if (admConsumidor.iniciarSesion(cons))
            //{
            //    //Se crea una instancia de la clase Consumidor @temp, la cual estara dentro de una sesion interna @Session["consumidorTemporal"]
            //    Consumidor temp = new Consumidor();
            //    Session["usuarioTemporal"] = admConsumidor.consumidorExterno.nombreConsumidor.ToUpper();

            //    //Se asignan los datos traidos desde la bd a la instancia @temp de Consumidor
            //    temp.nombreConsumidor = admConsumidor.consumidorExterno.nombreConsumidor;
            //    temp.runConsumidor = admConsumidor.consumidorExterno.runConsumidor;
            //    temp.correoConsumidor = admConsumidor.consumidorExterno.correoConsumidor;

            //    //se guardan la instancia @temp en la variable de session interna
            //    Session["consumidorTemporal"]=temp;
            //    Response.Redirect("/vistas/consumidor/ofertas_consumidor.aspx");
            //}
            //else
            //{
            //    Label1.Text = "Los datos ingresados no se encuentran en nuestros registros.";
            //}

        }
    }
}