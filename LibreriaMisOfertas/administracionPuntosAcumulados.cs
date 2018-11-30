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
            OracleCommand cmd = new OracleCommand("SELECT puntos_acumulados, id_certificado_descuento FROM misOfertasDB.certificadoDescuento where rut_consumidor=:rut AND correo_consumidor=:correo", con);
            //OracleCommand cmd = new OracleCommand("SELECT a.id_certificado_descuento, a.rut_consumidor, c.nombre_consumidor, a.correo_consumidor, a.id_tipo_descuento, a.puntos_acumulados, b.rubro_descuento, b.tope_dinero_compra, b.porcentaje_descuento FROM misOfertasDB.certificadodescuento a, misOfertasDB.tipodescuento b, misOfertasDB.consumidor c WHERE a.rut_consumidor=:rut AND a.correo_consumidor=:correo AND a.id_tipo_descuento=b.id_tipo_descuento", con);
            cmd.Parameters.Add(":rut", cons.runConsumidor);
            cmd.Parameters.Add(":correo", cons.correoConsumidor);
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
                    OracleCommand cmdUpd = new OracleCommand("UPDATE misOfertasDB.certificadodescuento SET puntos_acumulados=:puntos WHERE rut_consumidor=:rut AND correo_consumidor=:correo", con);
                    cmdUpd.Parameters.Add("puntos", acumularPuntos(obtenerPuntos(cons)));
                    cmdUpd.Parameters.Add("rut", cons.runConsumidor);
                    cmdUpd.Parameters.Add("correo", cons.correoConsumidor);
                    cmdUpd.ExecuteNonQuery();
                    //return true;
                }
                if (obtenerPuntos(cons) > 101 && obtenerPuntos(cons) < 500)
                {
                    OracleCommand cmdUpd = new OracleCommand("UPDATE misOfertasDB.certificadodescuento SET id_tipo_descuento=2, puntos_acumulados=:puntos WHERE rut_consumidor=:rut AND correo_consumidor=:correo", con);
                    cmdUpd.Parameters.Add("puntos", acumularPuntos(obtenerPuntos(cons)));
                    cmdUpd.Parameters.Add("rut", cons.runConsumidor);
                    cmdUpd.Parameters.Add("correo", cons.correoConsumidor);
                    cmdUpd.ExecuteNonQuery();
                    //return true;
                }
                if (obtenerPuntos(cons) > 501)
                {
                    OracleCommand cmdUpd = new OracleCommand("UPDATE misOfertasDB.certificadodescuento SET id_tipo_descuento=3, puntos_acumulados=:puntos WHERE rut_consumidor=:rut AND correo_consumidor=:correo", con);
                    cmdUpd.Parameters.Add("puntos", acumularPuntos(obtenerPuntos(cons)));
                    cmdUpd.Parameters.Add("rut", cons.correoConsumidor);
                    cmdUpd.Parameters.Add("correo", cons.correoConsumidor);
                    cmdUpd.ExecuteNonQuery();
                    //return true;
                }
                con.Close();
                return true;
            }
            else
            {
                OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.certificadodescuento (id_certificado_descuento,rut_consumidor, correo_consumidor, id_tipo_descuento, puntos_acumulados) VALUES (misOfertasDB.certdescuento_seq.nextval, :rut, :correo, 1, 10)", con);
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
            OracleCommand cmd = new OracleCommand("SELECT * FROM misOfertasDB.certificadodescuento WHERE rut_consumidor=:rut AND correo_consumidor=:correo", con);
            cmd.Parameters.Add(":rut", cons.runConsumidor);
            cmd.Parameters.Add(":correo", cons.correoConsumidor);
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

        //public CertificadoDescuento obtenerTodoPDF(CertificadoDescuento certificado, Consumidor cons)
        //{
        //    conexionOracle temp = new conexionOracle();
        //    OracleConnection connection = new OracleConnection(temp.getConnectionString);
        //    connection.Open();
        //    OracleCommand cmd = new OracleCommand("misOfertasDB.buscarCertificado", connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    //OracleParameter id = cmd.Parameters.Add("idCertificado", OracleDbType.Int32, ParameterDirection.Output);
        //    //OracleParameter puntos = cmd.Parameters.Add("puntosAcumulados", OracleDbType.Int32, ParameterDirection.Output);
        //    //OracleParameter correo = cmd.Parameters.Add("correoCons", OracleDbType.Varchar2, cons.correoConsumidor, ParameterDirection.InputOutput);
        //    //OracleParameter rut = cmd.Parameters.Add("rutCons", OracleDbType.Varchar2, cons.runConsumidor, ParameterDirection.InputOutput);
        //    //OracleParameter nombre = cmd.Parameters.Add("nombreCons", OracleDbType.Varchar2, ParameterDirection.Output);
        //    //OracleParameter rubro = cmd.Parameters.Add("rubroDcto", OracleDbType.Varchar2, ParameterDirection.Output);
        //    //OracleParameter porc = cmd.Parameters.Add("porcentajeDcto", OracleDbType.Int32, ParameterDirection.Output);
        //    //OracleParameter tope = cmd.Parameters.Add("topeDinero", OracleDbType.Int32, ParameterDirection.Output);

        //    cmd.Parameters.Add("idCertificado", OracleDbType.Int16, ParameterDirection.Output);
        //    cmd.Parameters.Add("puntosAcumulados", OracleDbType.Int16, ParameterDirection.Output);
        //    cmd.Parameters.Add("correoCons", OracleDbType.Varchar2, cons.correoConsumidor, ParameterDirection.Input);
        //    cmd.Parameters.Add("rutCons", OracleDbType.Varchar2, cons.runConsumidor, ParameterDirection.Input);
        //    cmd.Parameters.Add("rubroDcto", OracleDbType.Varchar2, ParameterDirection.Output);
        //    cmd.Parameters.Add("porcentajeDcto", OracleDbType.Int16, ParameterDirection.Output);
        //    cmd.Parameters.Add("topeDinero", OracleDbType.Int16, ParameterDirection.Output);

        //    cmd.ExecuteReader();

        //    //descuento.idCertificado = Convert.ToInt32(id.Value.ToString());
        //    //descuento.puntosDescuentos = Convert.ToInt32(puntos.Value.ToString());
        //    //consumidor.correoConsumidor = correo..Value.ToString();
        //    //consumidor.runConsumidor = rut.Value.ToString();
        //    //consumidor.nombreConsumidor = nombre.Value.ToString();
        //    //rubroDcto = rubro.Value.ToString();
        //    //porcentaje = Convert.ToInt32(porc.Value.ToString());
        //    //topeCompra = Convert.ToInt32(tope.Value.ToString());
        //    Oracle.DataAccess.Types.OracleDecimal id= (Oracle.DataAccess.Types.OracleDecimal)cmd.Parameters["idCertificado"].Value;
        //    Oracle.DataAccess.Types.OracleDecimal pun = (Oracle.DataAccess.Types.OracleDecimal)cmd.Parameters["puntosAcumulados"].Value;
        //    certificado.rubro = cmd.Parameters["rubroDcto"].Value.ToString();
        //    Oracle.DataAccess.Types.OracleDecimal porc = (Oracle.DataAccess.Types.OracleDecimal)cmd.Parameters["porcentajeDcto"].Value;
        //    Oracle.DataAccess.Types.OracleDecimal tope = (Oracle.DataAccess.Types.OracleDecimal)cmd.Parameters["topeDinero"].Value;

        //    id =certificado.idCertificado;
        //    pun = certificado.puntosDescuentos;
        //    porc = certificado.porcentaje;
        //    tope = certificado.topeDinero;

        //    //certificado.puntosDescuentos = Convert.ToDecimal(cmd.Parameters["puntosAcumulados"].Value);
        //    //certificado.porcentaje = Convert.ToDecimal(cmd.Parameters["porcentajeDcto"].Value);
        //    //certificado.topeDinero = Convert.ToDecimal(cmd.Parameters["topeDinero"].Value);
        //    connection.Close();
        //    return certificado;
        //}

        public CertificadoDescuento obtenerTodoPDF(CertificadoDescuento certificado, Consumidor cons)
        {
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            connection.Open();
            OracleCommand cmdCert = new OracleCommand("SELECT id_certificado_descuento, id_tipo_descuento, puntos_acumulados FROM misOfertasDB.certificadodescuento WHERE rut_consumidor=:rut AND correo_consumidor=:correo", connection);
            cmdCert.Parameters.Add(":rut", cons.runConsumidor);
            cmdCert.Parameters.Add(":correo", cons.correoConsumidor);            
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

    //public bool crearCertificado(CertificadoDescuento certificadoTemporal)
    //{
    //    conexionOracle oracle = new conexionOracle();
    //    OracleConnection connection = new OracleConnection(oracle.getConnectionString);
    //    try
    //    {
    //        connection.Open();
    //        OracleCommand cmd = new OracleCommand("misOfertasDB.buscarCertificado", connection);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("rutCons", OracleDbType.Varchar2, certificadoTemporal.rutConsumidor, ParameterDirection.Input);
    //        cmd.Parameters.Add("correoCons", OracleDbType.Varchar2, certificadoTemporal.correoConsumidor, ParameterDirection.Input);
    //        cmd.Parameters.Add("puntosAcumulados", OracleDbType.Varchar2, certificadoTemporal.correoConsumidor, ParameterDirection.Input);
    //        cmd.ExecuteNonQuery();
    //        connection.Close();
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        mensaje = ex.Message;
    //        connection.Close();
    //        return false;
    //    }
    //}

    //public int obtenerPuntos(CertificadoDescuento certificadoTemporal)
    //{
    //    int puntosActuales = 0;
    //    conexionOracle oracle = new conexionOracle();
    //    OracleConnection connection = new OracleConnection(oracle.getConnectionString);
    //    try
    //    {
    //        connection.Open();
    //        OracleCommand cmd = new OracleCommand("misOfertasDB.obtenerPuntos", connection);
    //        cmd.Parameters.Add("correo_cons", OracleDbType.Varchar2, certificadoTemporal.correoConsumidor, ParameterDirection.Input);
    //        cmd.Parameters.Add("rut_cons", OracleDbType.Varchar2, certificadoTemporal.rutConsumidor, ParameterDirection.Input);
    //        cmd.Parameters.Add("puntos", OracleDbType.Int32, ParameterDirection.Output);
    //        cmd.ExecuteNonQuery();
    //        puntosActuales = Convert.ToInt32(cmd.Parameters["puntos"].Value.ToString());
    //        connection.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        mensaje = ex.Message;
    //    }
    //    return puntosActuales;
    //}

    //public bool existeCertificado(Consumidor consumidorTemporal)
    //{
    //    conexionOracle oracle = new conexionOracle();
    //    OracleConnection connection = new OracleConnection(oracle.getConnectionString);
    //    connection.Open();
    //    OracleCommand cmd = new OracleCommand("misOfertasDB.existeCertificado", connection);
    //    cmd.Parameters.Add("rut_cons", OracleDbType.Varchar2, consumidorTemporal.runConsumidor, ParameterDirection.Input);
    //    cmd.Parameters.Add("correo_cons", OracleDbType.Varchar2, consumidorTemporal.correoConsumidor, ParameterDirection.Input);
    //    //OracleDataReader reader = cmd.ExecuteReader();
    //    //if (reader.Read())
    //    //{
    //    //    reader.Close();
    //    //    connection.Close();
    //    //    return true;
    //    //}
    //    //else
    //    //{
    //    //    reader.Close();
    //    //    connection.Close();
    //    //    return false;
    //    //}
    //    cmd.ExecuteNonQuery();
    //    return true;

    //}
    //public bool actualizarPuntos(Consumidor consumidorTemporal)
    //{
    //    conexionOracle oracle = new conexionOracle();
    //    OracleConnection connection = new OracleConnection(oracle.getConnectionString);
    //    try
    //    {
    //        connection.Open();
    //        OracleCommand cmd = new OracleCommand("misOfertasDB.actualizarPuntos", connection);
    //        cmd.Parameters.Add("rutCons", OracleDbType.Varchar2, consumidorTemporal.runConsumidor, ParameterDirection.Input);
    //        cmd.Parameters.Add("correoCons", OracleDbType.Varchar2, consumidorTemporal.correoConsumidor, ParameterDirection.Input);
    //        cmd.ExecuteNonQuery();
    //        connection.Close();
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        mensaje = ex.Message;
    //        connection.Close();
    //        return false;
    //    }
    //}
}



