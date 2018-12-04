using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using System.Web.UI.WebControls;

namespace LibreriaMisOfertas
{
    public class llenarDDL
    {
        conexionOracle conexion = new conexionOracle();
        public void llenarDDLValoracion(DropDownList ddlValor)
        {
            string mala, buena, excelente;
            int a, b, c;
            ddlValor.Items.Clear();
            mala = "Mala";
            buena = "Buena";
            excelente = "Excelente";

            List<string> lista = new List<string>();
            lista.Add(excelente);
            lista.Add(buena);
            lista.Add(mala);
            ddlValor.Items.Insert(0, mala);
            ddlValor.Items.Insert(1, buena);
            ddlValor.Items.Insert(2, excelente);
        }
        public void llenarDDLRubro(DropDownList ddlRubro)
        {
            OracleConnection con = new OracleConnection(conexion.getConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("select * from misOfertasDB.rubro order by 1 asc", con);
            cmd.CommandType = CommandType.Text;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlRubro.DataSource = dt;
            ddlRubro.DataTextField = "nombre_rubro";
            ddlRubro.DataValueField = "id_rubro";
            ddlRubro.DataBind();
            con.Close();
        }

        public void llenarComuna(DropDownList ddlComuna)
        {
            OracleConnection con = new OracleConnection(conexion.getConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("select * from misOfertasDB.comuna order by 2 asc", con);
            cmd.CommandType = CommandType.Text;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlComuna.DataSource = dt;
            ddlComuna.DataTextField = "nombre_comuna";
            ddlComuna.DataValueField = "id_comuna";
            ddlComuna.DataBind();
            con.Close();
        }

        public void llenarSubFamilia(DropDownList ddlSubFamilia)
        {
            OracleConnection temp = new OracleConnection(conexion.getConnectionString);
            temp.Open();
            OracleCommand cmd = new OracleCommand("SELECT * from misOfertasDB.subfamiliaproducto order by 1 asc", temp);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlSubFamilia.DataSource = dt;
            ddlSubFamilia.DataTextField = "nombre_sub_categoria_prod";
            ddlSubFamilia.DataValueField = "id_sub_categoria_prod";
            ddlSubFamilia.DataBind();
            temp.Close();
        }

        public void llenarLote(DropDownList ddlLote)
        {
            OracleConnection temp = new OracleConnection(conexion.getConnectionString);
            temp.Open();
            OracleCommand cmd = new OracleCommand("SELECT * from misOfertasDB.lote order by 1 asc", temp);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlLote.DataSource = dt;
            ddlLote.DataTextField = "rut_proveedor";
            ddlLote.DataValueField = "id_lote";
            ddlLote.DataBind();
            temp.Close();

        }

        public void llenarMarca(DropDownList ddlMarca)
        {
            OracleConnection temp = new OracleConnection(conexion.getConnectionString);
            temp.Open();
            OracleCommand cmd = new OracleCommand("SELECT * from misofertasdb.proveedor order by nombre_proveedor asc", temp);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlMarca.DataSource = dt;
            ddlMarca.DataTextField = "nombre_proveedor";
            ddlMarca.DataValueField = "nombre_proveedor";            
            ddlMarca.DataBind();
            temp.Close();
        }

        public void llenarTipoOferta(DropDownList ddlTipoOferta)
        {
            OracleConnection temp = new OracleConnection(conexion.getConnectionString);
            temp.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM misOfertasDB.tipooferta", temp);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlTipoOferta.DataSource = dt;
            ddlTipoOferta.DataTextField = "descripcion_tipo_oferta";
            ddlTipoOferta.DataValueField = "id_tipo_oferta";
            ddlTipoOferta.DataBind();
            temp.Close();
        }

        public void llenarProducto(DropDownList ddlProducto)
        {
            OracleConnection temp = new OracleConnection(conexion.getConnectionString);
            temp.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM misOfertasDB.producto", temp);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlProducto.DataSource=dt;
            ddlProducto.DataTextField = "nombre_producto";
            ddlProducto.DataValueField = "sku";
            ddlProducto.DataBind();
            temp.Close();
        }

        public void llenarLocalVenta(DropDownList ddlLocalVenta)
        {
            OracleConnection temp = new OracleConnection(conexion.getConnectionString);
            temp.Open();
            OracleCommand cmd = new OracleCommand("SELECT a.id_local_venta, b.nombre_comuna FROM misOfertasDB.localventa a, misofertasdb.comuna b where a.id_comuna=b.id_comuna", temp);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlLocalVenta.DataSource = dt;
            ddlLocalVenta.DataTextField = "nombre_comuna";
            ddlLocalVenta.DataValueField = "id_local_venta";
            ddlLocalVenta.DataBind();
            temp.Clone();
        }
    }
}
