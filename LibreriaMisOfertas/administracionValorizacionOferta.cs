using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibreriaMisOfertas;

namespace LibreriaMisOfertas
{
    public class administracionValorizacionOferta
    {
        public bool agregarValoracionOferta(int clasificacion, int idCons, string rutCons, string correoCons,int idLocalVenta, int idRubro)
        {
            administracionImagenBoleta tempImage = new administracionImagenBoleta();
            conexionOracle temp = new conexionOracle();
            OracleConnection conexion = new OracleConnection(temp.getConnectionString);
            conexion.Open();
            if(clasificacion==0)
            {
                OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.experienciaconsumidor (id_experiencia_usuario, clasificacion,id_consumidor, rut_consumidor, correo_consumidor,id_local_venta, id_rubro, id_imagen_boleta) VALUES (misOfertasDB.expconsumidor_seq.nextval,:clas,:id, :rut, :correo,:local, :rubro, (SELECT MAX(id_imagen_boleta) FROM misOfertasDB.imagenBoleta))", conexion);
                //OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.experienciaconsumidor (id_experiencia_usuario, clasificacion, rut_consumidor, correo_consumidor, idRubro, idImagenBoleta) VALUES (misOfertasDB.expconsumidor_seq,:clas, :rut, :correo, :rubro, misOfertasDB.imagenboleta_seq.currval )", conexion);
                cmd.Parameters.Add("clas", OracleDbType.Int32).Value = 1;
                cmd.Parameters.Add("id", OracleDbType.Int32).Value=idCons;
                cmd.Parameters.Add("rut", OracleDbType.Varchar2).Value = rutCons;
                cmd.Parameters.Add("correo", OracleDbType.Varchar2).Value = correoCons;
                cmd.Parameters.Add("local",OracleDbType.Int32).Value=idLocalVenta;
                cmd.Parameters.Add("rubro", OracleDbType.Int32).Value = idRubro;
                //cmd.Parameters.Add("max",OracleDbType.Int32).Value=tempImage.obtenerMaxID();
                cmd.ExecuteNonQuery();
            }
            else if(clasificacion==1)
            {
                OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.experienciaconsumidor (id_experiencia_usuario, clasificacion,id_consumidor, rut_consumidor, correo_consumidor,id_local_venta, id_rubro, id_imagen_boleta) VALUES (misOfertasDB.expconsumidor_seq.nextval,:clas,:id, :rut, :correo,:local, :rubro, (SELECT MAX(id_imagen_boleta) FROM misOfertasDB.imagenBoleta))", conexion);
                //OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.experienciaconsumidor (id_experiencia_usuario, clasificacion, rut_consumidor, correo_consumidor, idRubro, idImagenBoleta) VALUES (misOfertasDB.expconsumidor_seq,:clas, :rut, :correo, :rubro, misOfertasDB.imagenboleta_seq.currval )", conexion);
                cmd.Parameters.Add("clas", OracleDbType.Int32).Value = 2;
                cmd.Parameters.Add("id", OracleDbType.Int32).Value = idCons;
                cmd.Parameters.Add("rut", OracleDbType.Varchar2).Value = rutCons;
                cmd.Parameters.Add("correo", OracleDbType.Varchar2).Value = correoCons;
                cmd.Parameters.Add("local", OracleDbType.Int32).Value = idLocalVenta;
                cmd.Parameters.Add("rubro", OracleDbType.Int32).Value = idRubro;
                //cmd.Parameters.Add("max",OracleDbType.Int32).Value=tempImage.obtenerMaxID();
                cmd.ExecuteNonQuery();
            }
            else if(clasificacion==2)
            {
                OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.experienciaconsumidor (id_experiencia_usuario, clasificacion,id_consumidor, rut_consumidor, correo_consumidor,id_local_venta, id_rubro, id_imagen_boleta) VALUES (misOfertasDB.expconsumidor_seq.nextval,:clas,:id, :rut, :correo,:local, :rubro, (SELECT MAX(id_imagen_boleta) FROM misOfertasDB.imagenBoleta))", conexion);
                //OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.experienciaconsumidor (id_experiencia_usuario, clasificacion, rut_consumidor, correo_consumidor, idRubro, idImagenBoleta) VALUES (misOfertasDB.expconsumidor_seq,:clas, :rut, :correo, :rubro, misOfertasDB.imagenboleta_seq.currval )", conexion);
                cmd.Parameters.Add("clas", OracleDbType.Int32).Value = 3;
                cmd.Parameters.Add("id", OracleDbType.Int32).Value = idCons;
                cmd.Parameters.Add("rut", OracleDbType.Varchar2).Value = rutCons;
                cmd.Parameters.Add("correo", OracleDbType.Varchar2).Value = correoCons;
                cmd.Parameters.Add("local", OracleDbType.Int32).Value = idLocalVenta;
                cmd.Parameters.Add("rubro", OracleDbType.Int32).Value = idRubro;
                //cmd.Parameters.Add("max",OracleDbType.Int32).Value=tempImage.obtenerMaxID();
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public StringBuilder obtenerValoracionesPositivas(PlaceHolder holder)
        {
            StringBuilder consulta = new StringBuilder();
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            connection.Open();

            OracleCommand cmd = new OracleCommand("select a.id_experiencia_usuario, a.clasificacion,a.id_consumidor, a.rut_consumidor, a.correo_consumidor, c.nombre_rubro from misofertasdb.experienciaconsumidor a, misofertasdb.rubro c where clasificacion=3 and a.id_rubro=c.id_rubro", connection);
            OracleDataReader reader = cmd.ExecuteReader();

            consulta.Append("<div class='table-responsive'><table border='1'  class='table table-striped'>");
            consulta.Append("<tr><th>ID Experiencia usuario</th><th>Clasificación</th><th>ID consumidor</th><th>R.U.N consumidor</th><th>Correo consumidor</th><th>Rubro oferta valorizada</th></tr>");
            consulta.Append("</tr>");
            if (reader.Read())
            {
                while (reader.Read())
                {
                    consulta.Append("<tr>");
                    consulta.Append("<td>" + " " + reader[0] + " " + "</td>");
                    consulta.Append("<td>" + " " + reader[1] + " (Excelente) " + "</td>");
                    consulta.Append("<td>" + " " + reader[2] + " " + "</td>");
                    consulta.Append("<td>" + " " + reader[3] + " " + "</td>");
                    consulta.Append("<td>" + " " + reader[4] + " " + "</td>");
                    consulta.Append("<td>" + " " + reader[5] + " " + "</td>");
                    consulta.Append("</tr>");
                }
            }
            consulta.Append("</table>");
            holder.Controls.Add(new Literal { Text = consulta.ToString() });
            reader.Close();
            return consulta;
        }

        public StringBuilder obtenerValoracionesNegativas(PlaceHolder holder)
        {
            StringBuilder consulta = new StringBuilder();
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            connection.Open();

            OracleCommand cmd = new OracleCommand("select a.id_experiencia_usuario, a.clasificacion,a.id_consumidor, a.rut_consumidor, a.correo_consumidor, c.nombre_rubro from misofertasdb.experienciaconsumidor a, misofertasdb.rubro c where clasificacion=1 and a.id_rubro=c.id_rubro", connection);
            OracleDataReader reader = cmd.ExecuteReader();

            consulta.Append("<div class='table-responsive'><table border='1'  class='table table-striped'>");
            consulta.Append("<tr><th>ID Experiencia usuario</th><th>Clasificación</th><th>R.U.N consumidor</th><th>Correo consumidor</th><th>Rubro oferta valorizada</th></tr>");
            consulta.Append("</tr>");
            if (reader.Read())
            {
                while (reader.Read())
                {
                    consulta.Append("<tr>");
                    consulta.Append("<td>" + reader[0] + "</td>");
                    consulta.Append("<td>" + reader[1] +" (Mala) "+ "</td>");
                    consulta.Append("<td>" + reader[2] + "</td>");
                    consulta.Append("<td>" + reader[3] + "</td>");
                    consulta.Append("<td>" + reader[4] + "</td>");
                    consulta.Append("<td>" + reader[5] + "</td>");
                    consulta.Append("</tr>");
                }
            }
            consulta.Append("</table>");
            holder.Controls.Add(new Literal { Text = consulta.ToString() });
            reader.Close();
            return consulta;
        }

    }
}
