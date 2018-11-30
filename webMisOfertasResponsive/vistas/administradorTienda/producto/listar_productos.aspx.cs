using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using LibreriaMisOfertas;

namespace webMisOfertasResponsive.vistas.administradorTienda.producto
{
    public partial class listar_productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            administracionProducto producto = new administracionProducto();
            DataTable dt = new DataTable();
            dt = producto.listaProductos();
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(dr[dc.ColumnName].ToString());
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            string tabla = sb.ToString();
        }        
    }
}