using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosMisOfertas;
using Oracle.DataAccess.Client;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibreriaMisOfertas
{
    public class administracionProducto
    {
        public bool agregarProducto(Producto prod, DropDownList ddlProveedor)
        {
            conexionOracle temp = new conexionOracle();
            OracleConnection con = new OracleConnection(temp.getConnectionString);
            con.Open();
            OracleCommand llamada = new OracleCommand("select a.id_lote from misofertasdb.lote a, misofertasdb.producto b, misofertasdb.proveedor c WHERE a.rut_proveedor = c.rut_proveedor AND c.nombre_proveedor=:nombre",con);
            llamada.Parameters.Add("nombre",ddlProveedor.SelectedValue);
            OracleDataReader reader = llamada.ExecuteReader();
            if(reader.Read())
            {
                prod.idLote = Convert.ToInt32(reader[0]);
                reader.Close();
                con.Close();
            }
            OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.producto(sku, nombre_producto, precio_producto, marca, imagen_producto, venta_maxima, venta_minima, id_rubro, id_lote, id_sub_familia_prod) VALUES (misOfertasDB.pruducto_seq.nextval, :nombre, :precio, :marca, :imagen, :minima, :maxima, :rubro, :lote, :subfamilia)", con);
            con.Open();
            cmd.Parameters.Add("nombre", OracleDbType.Varchar2).Value=prod.nombreProducto;
            cmd.Parameters.Add("precio", OracleDbType.Int32).Value=prod.precioProducto;
            cmd.Parameters.Add("marca", OracleDbType.Varchar2).Value=prod.marca;
            cmd.Parameters.Add("imagen", OracleDbType.Blob).Value=prod.imagenProducto;
            cmd.Parameters.Add("minima", OracleDbType.Int32).Value=prod.ventaMin;
            cmd.Parameters.Add("maxima", OracleDbType.Int32).Value=prod.ventaMax;
            cmd.Parameters.Add("rubro", OracleDbType.Int32).Value=prod.idRubro;
            cmd.Parameters.Add("lote", OracleDbType.Int32).Value=prod.idLote;
            cmd.Parameters.Add("subfamilia", OracleDbType.Int32).Value=prod.idSubFamilia;
            cmd.ExecuteNonQuery();
            return true;
        }
        public byte[] imageToByte(string ruta)
        {
            FileStream foto = new FileStream(ruta, FileMode.Open, FileAccess.Read);

            Byte[] arregloBytes = new Byte[foto.Length];
            BinaryReader reader = new BinaryReader(foto);
            arregloBytes = reader.ReadBytes(Convert.ToInt32(foto.Length));
            foto.Dispose();
            reader.Dispose();
            return arregloBytes;
        }
        public System.Drawing.Image byteToImage(Byte[] imgBytes)
        {
            Bitmap imagen = null;
            Byte[] bytes = (Byte[])(imgBytes);
            MemoryStream ms = new MemoryStream(bytes);
            imagen = new Bitmap(ms);
            imagen.Dispose();
            ms.Dispose();
            return imagen;
        }

        public DataTable listaProductos()
        {
            conexionOracle temp = new conexionOracle();
            OracleConnection con = new OracleConnection(temp.getConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT a.sku, a.nombre_producto, a.precio_producto, a.marca, a.imagen_producto, b.nombre_rubro, c.nombre_sub_categoria_prod FROM misOfertasDB.producto a, misOfertasDB.rubro b, misOfertasDB.subfamiliaproducto c WHERE a.id_rubro = b.id_rubro and a.id_sub_familia_prod = c.id_sub_categoria_prod",con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public StringBuilder listarTodoProductos(PlaceHolder holder)
        {
            StringBuilder consulta = new StringBuilder();
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            connection.Open();

            //OracleCommand cmd = new OracleCommand("SELECT sku, nombre_producto, precio_producto, marca, imagen_producto, venta_minima, venta_maxima, id_rubro, id_sub_familia_prod FROM misOfertasDB.producto", connection);
            OracleCommand cmd = new OracleCommand("SELECT a.sku, a.nombre_producto, a.precio_producto, a.marca, a.imagen_producto, a.venta_minima, a.venta_maxima, b.nombre_rubro, c.nombre_sub_categoria_prod FROM misOfertasDB.producto a,misofertasdb.rubro b, misofertasdb.subfamiliaproducto c where a.id_rubro=b.id_rubro and a.id_sub_familia_prod=c.id_sub_categoria_prod", connection);
            OracleDataReader reader = cmd.ExecuteReader();

            consulta.Append("<div class='table-responsive'><table border='1' class='table table-striped'>");
            consulta.Append("<tr><th>SKU</th><th>Nombre producto</th><th>Precio producto</th><th>Marca producto</th><th>Imagen producto</th><th>Venta mínima</th><th>Venta máxima</th><th>Rubro producto</th><th>Sub familia producto</th></tr>");
            consulta.Append("</tr>");
            if(reader.Read())
            {
                while (reader.Read())
                {                    
                    consulta.Append("<tr>");
                    consulta.Append("<td>" + " " + reader[0] + " " + "</td>");
                    consulta.Append("<td>" + " " + reader[1] + " " + "</td>");
                    consulta.Append("<td>" + " $"+ reader[2] + " CLP" + "</td>");
                    consulta.Append("<td>" + " " + reader[3] + " " + "</td>");
                    byte[] toByte = (byte[])reader[4];
                    consulta.Append("<td><img src='" + byteToImage(toByte) + "' width='50px' height='50px'/></td>");
                    consulta.Append("<td>" + " " + reader[5] + " unidades " + "</td>");
                    consulta.Append("<td>" + " " + reader[6] + " unidades " + "</td>");
                    consulta.Append("<td>" + " " + reader[7] + " " + "</td>");
                    consulta.Append("<td>" + " " + reader[8] + " " + "</td>");
                    consulta.Append("</tr>");
                }
            }
            consulta.Append("</table></div>");
            holder.Controls.Add(new Literal { Text=consulta.ToString()});
            reader.Close();
            return consulta;
        }
        public string nombreRubro;
        public string nombreSubCategoria;
        public string error;
        public Producto salida = new Producto();
        public Producto buscarProducto(Producto prod)
        {
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            connection.Open();
            OracleCommand cmd = new OracleCommand("SELECT a.sku, a.nombre_producto, a.precio_producto, a.venta_minima, a.venta_maxima, a.id_lote, b.nombre_rubro, c.nombre_sub_categoria_prod FROM misOfertasDB.producto a, misofertasdb.rubro b, misofertasdb.subfamiliaproducto c WHERE sku=:sku AND a.id_rubro=b.id_rubro AND a.id_sub_familia_prod=c.id_sub_categoria_prod",connection);
            cmd.Parameters.Add(":sku", prod.sku);
            //cmd.Parameters.Add(":nombre", prod.nombreProducto);
            OracleDataReader reader= cmd.ExecuteReader();
            if(reader.Read())
            {
                salida.sku = Convert.ToInt32(reader[0]);
                salida.nombreProducto = reader[1].ToString();
                salida.precioProducto = Convert.ToInt32(reader[2]);
                salida.ventaMin = Convert.ToInt32(reader[3]);
                salida.ventaMax = Convert.ToInt32(reader[4]);
                salida.idLote = Convert.ToInt32(reader[5]);
                salida.rubro = reader[6].ToString();
                salida.subFamilia = reader[7].ToString();
                reader.Close();
                connection.Close();
            }
            else
            {
                error = "El producto no existe";
            }
            return salida;
        }

        public bool actualizarProducto(Producto prod)
        {
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            try
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("UPDATE misOfertasDB.producto set nombre_producto=:producto, precio_producto=:precio, marca=:marca, venta_minima=:ventamin, venta_maxima=:ventamax, id_rubro=:rubro, id_sub_familia_prod=:subfamilia WHERE sku=:sku", connection);
                cmd.Parameters.Add("producto", prod.nombreProducto);
                cmd.Parameters.Add("precio", prod.precioProducto);
                cmd.Parameters.Add("marca", prod.marca);
                cmd.Parameters.Add("ventamin", prod.ventaMin);
                cmd.Parameters.Add("ventamax", prod.ventaMax);
                cmd.Parameters.Add("rubro", prod.idRubro);
                cmd.Parameters.Add("subfamilia", prod.idSubFamilia);
                cmd.Parameters.Add("sku", prod.sku);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                error = ex.Message;
                return false;
            }

        }
    }
}
