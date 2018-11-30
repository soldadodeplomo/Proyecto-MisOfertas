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
namespace LibreriaMisOfertas
{
    public class administracionProducto
    {
        public bool agregarProducto(Producto prod)
        {
            conexionOracle temp = new conexionOracle();
            OracleConnection con = new OracleConnection(temp.getConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.producto(sku, nombre_producto, precio_producto, marca, imagen_producto, venta_maxima, venta_minima, id_rubro, id_lote, id_sub_familia_prod) VALUES (misOfertasDB.pruducto_seq.nextval, :nombre, :precio, :marca, :imagen, :minima, :maxima, :rubro, :lote, :subfamilia)", con);
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
        public Image byteToImage(Byte[] imgBytes)
        {
            Bitmap imagen = null;
            Byte[] bytes = (Byte[])(imgBytes);
            MemoryStream ms = new MemoryStream(bytes);
            imagen = new Bitmap(ms);
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
    }
}
