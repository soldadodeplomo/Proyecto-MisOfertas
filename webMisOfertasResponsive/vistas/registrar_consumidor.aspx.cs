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
    public partial class registrar_consumidor : System.Web.UI.Page
    {
        LibreriaMisOfertas.llenarDDL ddl = new llenarDDL();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if(!IsPostBack)
            {
                ddl.llenarComuna(ddlComunaConsumidor);
            }
        }

        protected void btnIngresarSesionAdminitrador_Click(object sender, EventArgs e)
        {
            char recOferta = 's';
            if (cbRecibirOferta.Checked)
            {
                recOferta = 's';
            }
            else
            {
                recOferta = 'n';
            }
            administracionLoginRegistroConsumidor admConsumidor = new administracionLoginRegistroConsumidor();
            Consumidor cons = new Consumidor();
            cons.nombreConsumidor = txtNombreConsumidor.Text;
            cons.runConsumidor = txtRutConsumidor.Text;
            cons.correoConsumidor = txtCorreoConsumidor.Text;
            cons.contrasenaConsumidor = txtPasswordConsumidor.Text;
            cons.idComunaConsumidor = Convert.ToInt32(ddlComunaConsumidor.SelectedValue);
            cons.recibirOferta = recOferta;
            cons.idTipoConsumidor = 3;
            if(admConsumidor.registroConsumidor(cons))
            {
                string url = "<a href='/vistas/login_consumidor.aspx'>aquí</a>";
                Label1.Text = "¡Registro exitoso!. Por favor da click " + url + " para iniciar sesión";
            }
            else
            {
                Label1.Text = "No se ha podido generar el registro. Por favor intentelo más tarde.";
            }
            //if (admConsumidor.agregarConsumidor(txtRutConsumidor.Text, txtNombreConsumidor.Text, txtCorreoConsumidor.Text, txtPasswordConsumidor.Text, recOferta,Convert.ToInt32(ddlComunaConsumidor.SelectedValue)))
            //{
            //    string url = "<a href='/vistas/login_consumidor.aspx'>aquí</a>";
            //    Label1.Text = "¡Registro exitoso!. Por favor da click "+url+" para iniciar sesión";
            //}
            //else
            //{
            //    Label1.Text = "No se ha podido generar el registro. Por favor intentelo más tarde.";
            //}
            
        }
    }
}