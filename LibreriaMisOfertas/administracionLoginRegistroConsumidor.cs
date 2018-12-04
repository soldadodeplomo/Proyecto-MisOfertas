using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatosMisOfertas;
using Oracle.DataAccess.Client;
using System.Data;

namespace LibreriaMisOfertas
{
    public class administracionLoginRegistroConsumidor
    {
        public string mensajeError { get; set; }
        public Consumidor consumidorExterno = new Consumidor();
        public string nombreCons { get; set; }
        public bool existeConsumidor(string correoConsumidor, string contrasenaConsumidor)
        {
            conexionOracle con = new conexionOracle();
            OracleConnection conexionOracle = new OracleConnection(con.getConnectionString);
            conexionOracle.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM misOfertasDB.consumidor WHERE correo_consumidor =:consumidor AND contrasena_consumidor =:contrasena", conexionOracle);
            cmd.Parameters.Add(":consumidor", correoConsumidor);
            cmd.Parameters.Add(":contrasena", contrasenaConsumidor);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //mensajeError = "El usuario ya existe";
                reader.Close();
                conexionOracle.Close();
                return false;
            }
            else
            {
                //mensajeError = "No existe el usuario";
                reader.Close();
                conexionOracle.Close();
                return true;
            }
        }
        //public bool agregarConsumidor(string r, string n, string c, string p, char ro, int com)//insert directo
        //{
        //    conexionOracle temp = new conexionOracle();
        //    OracleConnection conexion = new OracleConnection(temp.getConnectionString);
        //    if (existeConsumidor(c,p))
        //    {
        //        conexion.Open();
        //        OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.consumidor(rut_consumidor, nombre_consumidor, correo_consumidor, contrasena_consumidor, recibir_oferta, id_comuna, id_tipo_usuario) VALUES (:rut,:nombre,:correo,:contrasena,:recibir,:comuna,:tipo)", conexion);
        //        cmd.Parameters.Add("run", OracleDbType.Varchar2).Value = r;
        //        cmd.Parameters.Add("nombre", OracleDbType.Varchar2).Value = n;
        //        cmd.Parameters.Add("correo", OracleDbType.Varchar2).Value = c;
        //        cmd.Parameters.Add("contrasena", OracleDbType.Varchar2).Value = p;
        //        cmd.Parameters.Add("recibir", OracleDbType.Char).Value = ro;
        //        cmd.Parameters.Add("comuna", OracleDbType.Int32).Value = com;
        //        cmd.Parameters.Add("tipoUsuario", OracleDbType.Int32).Value =3;
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    else
        //    {
        //        conexion.Close();
        //        return false;
        //    }
        //}

        public bool iniciarSesion(Consumidor cons)
        {
            conexionOracle con = new conexionOracle();
            OracleConnection conexionOracle = new OracleConnection(con.getConnectionString);
            conexionOracle.Open();
            OracleCommand cmd = new OracleCommand("SELECT id_consumidor, rut_consumidor, correo_consumidor, nombre_consumidor, recibir_oferta FROM misOfertasDB.consumidor WHERE correo_consumidor =:consumidor AND contrasena_consumidor =:contrasena", conexionOracle);
            cmd.Parameters.Add(":consumidor", cons.correoConsumidor);
            cmd.Parameters.Add(":contrasena", cons.contrasenaConsumidor);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //variables globales
                consumidorExterno.idConsumidor =Convert.ToInt32(reader["id_consumidor"]);
                consumidorExterno.nombreConsumidor = reader["nombre_consumidor"].ToString();
                consumidorExterno.correoConsumidor = reader["correo_consumidor"].ToString();
                consumidorExterno.runConsumidor = reader["rut_consumidor"].ToString();
                consumidorExterno.recibirOferta =Convert.ToChar(reader["recibir_oferta"]);

                reader.Close();
                conexionOracle.Close();
                //mensajeError = "El usuario ya existe";
                return true;
            }
            else
            {
                //mensajeError = "No existe el usuario";
                reader.Close();
                conexionOracle.Close();
                return false;
            }
        }
        string mensaje = "";
        public bool registroConsumidor(Consumidor cons)
        {
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            try
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("misOfertasDB.insertarConsumidor", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("rut", OracleDbType.Varchar2, cons.runConsumidor, ParameterDirection.Input);
                cmd.Parameters.Add("correo",OracleDbType.Varchar2,cons.correoConsumidor, ParameterDirection.Input);
                cmd.Parameters.Add("nombre", OracleDbType.Varchar2, cons.nombreConsumidor,ParameterDirection.Input);
                cmd.Parameters.Add("contrasena", OracleDbType.Varchar2, cons.contrasenaConsumidor, ParameterDirection.Input);
                cmd.Parameters.Add("recibiroferta", OracleDbType.Char,cons.recibirOferta, ParameterDirection.Input);
                cmd.Parameters.Add("comuna", OracleDbType.Int32, cons.idComunaConsumidor, ParameterDirection.Input);
                cmd.Parameters.Add("tipouser", OracleDbType.Int32, cons.idTipoConsumidor, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                connection.Close();
                return false;
            }
        } 

        //public bool inicioSesion(Consumidor cons)
        //{
        //    conexionOracle oracle = new conexionOracle();
        //    OracleConnection connection = new OracleConnection(oracle.getConnectionString);
        //    try
        //    {
        //        connection.Open();
        //        OracleCommand cmd = new OracleCommand("misOfertasDB.loginConsumidor", connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("correo_cons", OracleDbType.Varchar2, cons.correoConsumidor, ParameterDirection.Output);
        //        cmd.Parameters.Add("pass_cons", OracleDbType.Varchar2, cons.contrasenaConsumidor, ParameterDirection.Input);
        //        cmd.Parameters.Add("nombre_cons", OracleDbType.Varchar2, ParameterDirection.Output);
        //        cmd.ExecuteNonQuery();
        //        consumidorExterno.nombreConsumidor = cmd.Parameters["nombre_cons"].Value.ToString();
        //        connection.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        connection.Close();
        //        mensaje = ex.Message;
        //        return false;
        //    }
        //}
    }
}


