using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWebService;
using Newtonsoft.Json;

namespace webMisOfertasResponsive.WebService
{
    public partial class WebService : System.Web.UI.Page
    {
        //CONSIDERACIONES
        //----------------------------------------------------------------------------------------------------------------------------------------
        //1) Los datos enviados de vuelta a la aplicación desktop deben ser de tipo string, en formato JSON y cargados en la variable "renderThis".
        //2) Los datos recibidos aquí por la aplicación web deben ser enviados por la aplicación desktop a través del protocolo POST.
        //3) Todas las transacciones deben incluir los datos de login del usuario registrado que este usando la aplicación (i.e. username y password)
        //y se validará que el usuario sea valido en cada transacción, para así evitar ataques por suplantación.
        //de lo anterior se desprende que la aplicación cliente deberá de algún modo almacenar los datos, quizás en algun archivo de texto con algún
        //tipo de encriptación reversible, de ser necesario, Cota, Avisame y te ayudo con eso -Jose- ;)
        //-----------------------------------------------------------------------------------------------------------------------------------------

        //A través de esta propiedad, renderizaremos los JSON que necesitemos al frente para el consumo de datos de la aplicación
        public string renderThis { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Aquí un ejemplo de como usaremos los métodos de la InterfazWebService
            //en este caso lo use para evaluar, pero pueden usarlos para lo que sea necesario, siempre y cuando sea en este .CS
            if (new InterfazWebService.InterfazWebService().isConnected())
            {
                Prueba newObj = new Prueba();
                //A través de esta variable renderizamos los objetos JSON que necesitemos para así enviar datos de vuelta a la aplicación desktop,
                //El modo de hacerlo es tal como aparece en este ejemplo.
                renderThis = JsonConvert.SerializeObject(newObj);
            }
        }
    }

    public class Prueba
    {
        public string prueba = "Trololololord";
    }
}