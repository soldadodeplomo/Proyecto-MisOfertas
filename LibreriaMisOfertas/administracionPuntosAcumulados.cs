using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosMisOfertas;
using Oracle.DataAccess.Client;
using LibreriaMisOfertas;
using System.Data;
using Oracle.DataAccess.Types;

namespace LibreriaMisOfertas
{
    public class administracionPuntosAcumulados
    {
        public string mensaje = "";

        public CertificadoDescuento descuento = new CertificadoDescuento();
        public Consumidor consumidor = new Consumidor();

        public string rubroDcto = "";
        public int obtenerPuntos(Consumidor cons)//obtiene los puntos actuales del consumidor y los datos para la generacion del archivo PDF
        {
            int puntosAcumulados = 0;
            conexionOracle temp = new conexionOracle();
            OracleConnection con = new OracleConnection(temp.getConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT puntos_acumulados, id_certificado_descuento FROM misOfertasDB.certificadoDescuento where rut_consumidor=:rut AND correo_consumidor=:correo AND id_consumidor=:id", con);
            //OracleCommand cmd = new OracleCommand("SELECT a.id_certificado_descuento, a.rut_consumidor, c.nombre_consumidor, a.correo_consumidor, a.id_tipo_descuento, a.puntos_acumulados, b.rubro_descuento, b.tope_dinero_compra, b.porcentaje_descuento FROM misOfertasDB.certificadodescuento a, misOfertasDB.tipodescuento b, misOfertasDB.consumidor c WHERE a.rut_consumidor=:rut AND a.correo_consumidor=:correo AND a.id_tipo_descuento=b.id_tipo_descuento", con);
            cmd.Parameters.Add(":rut", cons.runConsumidor);
            cmd.Parameters.Add(":correo", cons.correoConsumidor);
            cmd.Parameters.Add(":id", cons.idConsumidor);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                descuento.idCertificado = Convert.ToInt32(reader["id_certificado_descuento"].ToString());
                //consumidor.runConsumidor = reader["rut_consumidor"].ToString();
                //consumidor.nombreConsumidor = reader["nombre_consumidor"].ToString();
                //consumidor.correoConsumidor = reader["correo_consumidor"].ToString();
                //rubroDcto = reader["rubro_descuento"].ToString();
                puntosAcumulados = Convert.ToInt32(reader["puntos_acumulados"].ToString());
                //topeCompra = Convert.ToInt32(reader["tope_dinero_compra"].ToString());
                //porcentaje = Convert.ToInt32(reader["porcentaje_descuento"]);
                reader.Close();
                con.Close();
            }
            else
            {
                mensaje = "nada";
            }
            return puntosAcumulados;
        }
        public int total = 0;
        public int acumularPuntos(int puntosActuales)
        {
            int puntosUpdate = 10;
            total = puntosActuales + puntosUpdate;
            return total;
        }
        //suma los puntos de la db con el que se genera al momento de crear una valoracion de compra

        public bool actualizarCupon(Consumidor cons)
        {
            //este metodo actualizara los puntos, el rubro del descuento, segun la cantidad de puntos acumulados
            conexionOracle temp = new conexionOracle();
            OracleConnection con = new OracleConnection(temp.getConnectionString);
            con.Open();
            if (existeCupon(cons))
            {
                //si existe se actualizan los datos
                if (obtenerPuntos(cons) > 0 && obtenerPuntos(cons) <= 100)
                {
                    OracleCommand cmdUpd = new OracleCommand("UPDATE misOfertasDB.certificadodescuento SET puntos_acumulados=:puntos WHERE rut_consumidor=:rut AND correo_consumidor=:correo AND id_consumidor=:id", con);
                    cmdUpd.Parameters.Add("puntos", acumularPuntos(obtenerPuntos(cons)));
                    cmdUpd.Parameters.Add("rut", cons.runConsumidor);
                    cmdUpd.Parameters.Add("correo", cons.correoConsumidor);
                    cmdUpd.Parameters.Add("id", cons.idConsumidor);
                    cmdUpd.ExecuteNonQuery();
                    //return true;
                }
                if (obtenerPuntos(cons) > 101 && obtenerPuntos(cons) < 500)
                {
                    OracleCommand cmdUpd = new OracleCommand("UPDATE misOfertasDB.certificadodescuento SET id_tipo_descuento=2, puntos_acumulados=:puntos WHERE rut_consumidor=:rut AND correo_consumidor=:correo AND id_consumidor=:id", con);
                    cmdUpd.Parameters.Add("puntos", acumularPuntos(obtenerPuntos(cons)));
                    cmdUpd.Parameters.Add("rut", cons.runConsumidor);
                    cmdUpd.Parameters.Add("correo", cons.correoConsumidor);
                    cmdUpd.Parameters.Add("id", cons.idConsumidor);
                    cmdUpd.ExecuteNonQuery();
                    //return true;
                }
                if (obtenerPuntos(cons) >= 501)
                {
                    OracleCommand cmdUpd = new OracleCommand("UPDATE misOfertasDB.certificadodescuento SET id_tipo_descuento=3, puntos_acumulados=:puntos WHERE rut_consumidor=:rut AND correo_consumidor=:correo and id_consumidor=:id", con);
                    cmdUpd.Parameters.Add("puntos", acumularPuntos(obtenerPuntos(cons)));
                    cmdUpd.Parameters.Add("rut", cons.correoConsumidor);
                    cmdUpd.Parameters.Add("correo", cons.correoConsumidor);
                    cmdUpd.Parameters.Add("id", cons.idConsumidor);
                    cmdUpd.ExecuteNonQuery();
                    //return true;
                }
                con.Close();
                return true;
            }
            else
            {
                OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.certificadodescuento (id_certificado_descuento,id_consumidor,rut_consumidor, correo_consumidor, id_tipo_descuento, puntos_acumulados) VALUES (misOfertasDB.certdescuento_seq.nextval,:id, :rut, :correo, 1, 10)", con);
                cmd.Parameters.Add("id", OracleDbType.Int32).Value=cons.idConsumidor;
                cmd.Parameters.Add("rut", OracleDbType.Varchar2).Value = cons.runConsumidor;
                cmd.Parameters.Add("correo", OracleDbType.Varchar2).Value = cons.correoConsumidor;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
        }

        public bool existeCupon(Consumidor cons)
        {
            conexionOracle temp = new conexionOracle();
            OracleConnection con = new OracleConnection(temp.getConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM misOfertasDB.certificadodescuento WHERE rut_consumidor=:rut AND correo_consumidor=:correo and id_consumidor=:id", con);
            cmd.Parameters.Add(":rut", cons.runConsumidor);
            cmd.Parameters.Add(":correo", cons.correoConsumidor);
            cmd.Parameters.Add(":id", cons.idConsumidor);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                con.Close();
                return true;
            }
            else
            {
                reader.Close();
                con.Close();
                return false;
            }
        }
        
        public CertificadoDescuento obtenerTodoPDF(CertificadoDescuento certificado, Consumidor cons)
        {
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            connection.Open();
            OracleCommand cmdCert = new OracleCommand("SELECT id_certificado_descuento, id_tipo_descuento, puntos_acumulados FROM misOfertasDB.certificadodescuento WHERE rut_consumidor=:rut AND correo_consumidor=:correo AND id_consumidor=:id", connection);
            cmdCert.Parameters.Add(":rut", cons.runConsumidor);
            cmdCert.Parameters.Add(":correo", cons.correoConsumidor);
            cmdCert.Parameters.Add(":id", cons.idConsumidor);
            OracleDataReader reader = cmdCert.ExecuteReader();
            if(reader.Read())
            {
                certificado.idCertificado =Convert.ToInt32(reader["id_certificado_descuento"]);
                certificado.idTipo = Convert.ToInt32(reader["id_tipo_descuento"]);
                certificado.puntosDescuentos = Convert.ToInt32(reader["puntos_acumulados"]);
                reader.Close();
                connection.Close();                
            }
            else
            {
                reader.Close();
                connection.Close();
            }
            connection.Open();

            OracleCommand cmdTipo = new OracleCommand("SELECT porcentaje_descuento, tope_dinero_compra, rubro_descuento FROM misOfertasDB.tipoDescuento WHERE id_tipo_descuento=:id", connection);
            cmdTipo.Parameters.Add(":id", certificado.idTipo);
            OracleDataReader read = cmdTipo.ExecuteReader();
            if (read.Read())
            {
                certificado.porcentaje = Convert.ToInt32(read["porcentaje_descuento"]);
                certificado.topeDinero = Convert.ToInt32(read["tope_dinero_compra"]);
                certificado.rubro = read["rubro_descuento"].ToString();
                read.Close();
                connection.Close();
                return certificado;
            }
            else
            {
                reader.Close();
                connection.Close();
            }
            return certificado;
        }       
    }
}



