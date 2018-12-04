using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using LibreriaMisOfertas;
using Oracle.DataAccess.Client;

namespace webMisOfertasResponsive.vistas.administradorTienda
{
    public partial class consultar_ofertas : System.Web.UI.Page
    {
        AdministracionOferta ofertas = new AdministracionOferta();
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
            obtenerOfertas();           
        }

        protected void btnCerrarSesionAdministrador_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/vistas/login_administrador_tienda.aspx");
        }
        public StringBuilder obtenerOfertas()
        {
            StringBuilder consulta = new StringBuilder();
            try
            {
                conexionOracle oracle = new conexionOracle();
                OracleConnection connection = new OracleConnection(oracle.getConnectionString);
                connection.Open();

                OracleCommand cmdOferta = new OracleCommand("SELECT a.id_oferta, a.precio_oferta, d.nombre_producto, d.precio_producto, a.fecha_inicio, a.fecha_termino, b.nombre_rubro, c.descripcion_tipo_oferta FROM misOfertasDB.oferta a, misofertasdb.rubro b, misofertasdb.tipooferta c, misofertasdb.producto d, misofertasdb.detofertaproducto e where a.id_rubro=b.id_rubro and a.id_tipo_oferta=c.id_tipo_oferta and a.id_oferta=e.id_oferta and d.sku=e.sku", connection);
                OracleDataReader readerOferta = cmdOferta.ExecuteReader();

                consulta.Append("<div class='table-responsive'><table border='1' class='table table-striped'>");
                consulta.Append("<tr><th>ID Oferta</th><th>Precio oferta</th><th>Nombre producto</th><th>Precio referencia</th><th>Fecha inicio oferta</th><th>Fecha termino oferta</th><th>Rubro oferta</th><th>Tipo oferta</th></tr>");
                consulta.Append("</tr>");

                if (readerOferta.Read())
                {
                    while (readerOferta.Read())
                    {
                        consulta.Append("<tr>");
                        consulta.Append("<td>" + readerOferta[0] + "</td>");
                        consulta.Append("<td>" + " $" + readerOferta[1] + "CLP" + "</td>");
                        consulta.Append("<td>" + readerOferta[2] + "</td>");
                        consulta.Append("<td>" + " $" + readerOferta[3] + "CLP " + "</td>");
                        consulta.Append("<td>" + readerOferta[4] + "</td>");
                        consulta.Append("<td>" + readerOferta[5] + "</td>");
                        consulta.Append("<td>" + readerOferta[6] + "</td>");
                        consulta.Append("<td>" + readerOferta[7] + "</td>");
                        consulta.Append("</tr>");
                    }
                }
                consulta.Append("</table></div>");
                phListarOfertas.Controls.Add(new Literal { Text = consulta.ToString() });
                readerOferta.Close();
            }
            catch (Exception ex)
            {
                string e = ex.Message;                
            }
            return consulta;
        }
    }
}