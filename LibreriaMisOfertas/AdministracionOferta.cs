using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using DatosMisOfertas;
using LibreriaMisOfertas;
namespace LibreriaMisOfertas
{
    public class AdministracionOferta
    {
        public bool agregarOferta(int precioOferta, DateTime fechaInicio, DateTime fechaTermino, int rubro, int tipoOferta)//tabla oferta
        {
            conexionOracle temp = new conexionOracle();
            OracleConnection con = new OracleConnection(temp.getConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.oferta (id_oferta, precio_oferta, fecha_inicio, fecha_termino, id_rubro, id_tipo_oferta) VALUES (misOfertasDB.oferta_seq.nextval, :precio, :inicio, :termino, :rubro, :tipo)", con);
            cmd.Parameters.Add("precio", OracleDbType.Int32).Value=precioOferta;
            cmd.Parameters.Add("inicio", OracleDbType.Date).Value=fechaInicio;
            cmd.Parameters.Add("termino", OracleDbType.Date).Value=fechaTermino;
            cmd.Parameters.Add("rubro", OracleDbType.Int32).Value=rubro;
            cmd.Parameters.Add("tipo", OracleDbType.Int32).Value=tipoOferta;
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public bool agregarDetalleOferta(int sku)//tabla detalle oferta producto
        {
            conexionOracle temp = new conexionOracle();
            OracleConnection con = new OracleConnection(temp.getConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.detofertaproducto (sku, id_oferta) VALUES (:sku, misOfertasDB.oferta_seq.currval)");
            cmd.Parameters.Add("sku", OracleDbType.Int32).Value=sku;
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        //public bool listarOfertas()// primero agregar producto
        //{
        //    conexionOracle temp = new conexionOracle();
        //    OracleConnection con = new OracleConnection(temp.getConnectionString);
        //    con.Open();
        //    OracleCommand cmd = new OracleCommand("SELECT a.id_oferta, a.precio_oferta, a.fecha_inicio, a.fecha_termino, a.id_rubro, a.id_tipo_oferta, b.sku, c.");
        //}
    }
}
