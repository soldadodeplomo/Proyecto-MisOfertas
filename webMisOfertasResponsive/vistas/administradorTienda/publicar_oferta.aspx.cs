using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaMisOfertas;
using DatosMisOfertas;

namespace webMisOfertasResponsive.vistas.administradorTienda
{
    public partial class publicar_oferta : System.Web.UI.Page
    {
        AdministradorTienda administracion = new AdministradorTienda();
        AdministracionOferta oferta = new AdministracionOferta();
        llenarDDL ddl = new llenarDDL();
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
            if(!IsPostBack)
            {
                ddl.llenarDDLRubro(ddlRubroOferta);
                ddl.llenarTipoOferta(ddlTipoOferta);
                ddl.llenarProducto(ddlProducto1);
                //ddl.llenarProducto(ddlProducto2);
            }         
        }

        protected void btnPublicarOferta_Click(object sender, EventArgs e)
        {
            try
            {
                Oferta ofertaTemporal = new Oferta();
                ofertaTemporal.precioOferta = Convert.ToInt32(txtPrecioOferta.Text);
                ofertaTemporal.fechaInicio = Convert.ToDateTime(list[0].ToShortDateString());
                ofertaTemporal.fechaTermino = Convert.ToDateTime(list[1].ToShortDateString());
                ofertaTemporal.idRubro = Convert.ToInt32(ddlRubroOferta.SelectedValue);
                ofertaTemporal.idTipoOferta = Convert.ToInt32(ddlTipoOferta.SelectedValue);
                int sku1 = Convert.ToInt32(ddlProducto1.SelectedValue);
                //int sku2 = Convert.ToInt32(ddlProducto2.SelectedValue);
                if(oferta.agregarOferta(ofertaTemporal) && oferta.agregarDetOferta(sku1))
                {
                    lblError.Text = "";
                } 
                else
                {
                    lblError.Text = oferta.error;
                }
                //if (oferta.agregarDetOferta(sku1))
                //{
                //    lblError.Text = "";
                //}
                //else
                //{
                //    lblError.Text = oferta.error;
                //}
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        public static List<DateTime> list = new List<DateTime>();

        protected void calInicio_DayRender(object sender, DayRenderEventArgs e)
        {
            if(e.Day.IsSelected==true)
            {
                list.Add(e.Day.Date);
                
            }
            Session["selectedDates"] = list;
        }

        protected void calInicio_SelectionChanged(object sender, EventArgs e)
        {
            if(Session["selectedDates"]!=null)
            {
                List<DateTime> newList = (List<DateTime>)Session["selectedDates"];
                foreach (DateTime item in newList)
                {
                    calInicio.SelectedDates.Add(item);
                }
                list.Clear();
            }
            else
            {
                lblError.Text = "Seleccionar 2 fechas";
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