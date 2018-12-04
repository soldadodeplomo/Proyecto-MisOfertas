using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using DatosMisOfertas;
using LibreriaMisOfertas;
using System.Data;

namespace LibreriaMisOfertas
{
    public class AdministracionOferta
    {
        public string error = "";
        public bool agregarOferta(Oferta ofertaTemporal)//tabla oferta
        {
            try
            {
                conexionOracle temp = new conexionOracle();
                OracleConnection con = new OracleConnection(temp.getConnectionString);
                con.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.oferta (id_oferta, precio_oferta, fecha_inicio, fecha_termino, id_rubro, id_tipo_oferta) VALUES (misOfertasDB.oferta_seq.nextval, :precio, :inicio, :termino, :rubro, :tipo)", con);
                cmd.Parameters.Add("precio", OracleDbType.Int32).Value = ofertaTemporal.precioOferta;
                cmd.Parameters.Add("inicio", OracleDbType.Date).Value = ofertaTemporal.fechaInicio;
                cmd.Parameters.Add("termino", OracleDbType.Date).Value = ofertaTemporal.fechaTermino;
                cmd.Parameters.Add("rubro", OracleDbType.Int32).Value = ofertaTemporal.idRubro;
                cmd.Parameters.Add("tipo", OracleDbType.Int32).Value = ofertaTemporal.idTipoOferta;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return true;
                //OracleDataReader reader = cmd.ExecuteReader();
                //if(reader.Read())
                //{
                //    reader.Close();
                //    con.Close();
                //    return true;
                //}
                //else
                //{
                //    reader.Close();
                //    con.Close();
                //    return true;
                //}
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }

        public bool agregarDetOferta(int sku)
        {
            try
            {
                conexionOracle temp = new conexionOracle();
                OracleConnection connection = new OracleConnection(temp.getConnectionString);
                connection.Open();
                OracleCommand cmd2 = new OracleCommand("INSERT INTO misOfertasDB.detOfertaProducto (sku, id_oferta) VALUES (:sku, misOfertasDB.oferta_seq.currval)", connection);
                cmd2.Parameters.Add(":sku", OracleDbType.Int32).Value=sku;
                cmd2.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }        
    }
}
