using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using LibreriaMisOfertas;
using DatosMisOfertas;
using Oracle.DataAccess.Client;
using System.Data;

namespace InterfazWebService
{
    public class InterfazWebService
    {
        //Aquí se agregarán todos los métodos que deban connectar con la base de datos que sean usados por la aplicación cliente,
        //vean en el proyecto "webMisOfertasResponsive" en la carpeta "WebService" en donde guardaré la WebForm que recibirá las instrucciones
        //de la aplicación cliente y en donde utilizaremos esta librería.
        public bool isConnected(Consumidor c)
        {
            conexionOracle conexion = new conexionOracle();
            OracleConnection con = new OracleConnection(conexion.getConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("select * from misofertasdb.libro where id_libro=:libro", con);
            cmd.CommandType = CommandType.Text;
            //este es un select (revisa el code mio si tienes dudas)
            cmd.Parameters.Add(":libro", c.correoConsumidor);
            //este es para insert (revisa el code mio si tienes dudas)
            cmd.Parameters.Add("libro", OracleDbType.Varchar2).Value = c.correoConsumidor;

            //obtener datos desde el select con execute reader
            OracleDataReader reader = cmd.ExecuteReader();
            c.contrasenaConsumidor = reader["contrasena_usuario"].ToString();


            //esto es solo para que te dija que existe o no existe
            cmd.ExecuteNonQuery();
            return true;
        }

        //---------------- INICIO USUARIO ----------------
        public Usuario user = new Usuario();
        public bool existeUsuario(string rut_usuario, string contasena_usuario)
        {
            conexionOracle con = new conexionOracle();
            OracleConnection conexionOracle = new OracleConnection(con.getConnectionString);
            conexionOracle.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM misOfertasDB.usuario WHERE rut_usuario =:usuario AND contrasena_usuario =:contrasena", conexionOracle);
            cmd.Parameters.Add(":usuario", rut_usuario);
            cmd.Parameters.Add(":contrasena", contasena_usuario);
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

        public bool iniciarSesion(Usuario usuario)
        {
            conexionOracle con = new conexionOracle();
            OracleConnection conexionOracle = new OracleConnection(con.getConnectionString);
            conexionOracle.Open();
            OracleCommand cmd = new OracleCommand("SELECT rut_usuario, contrasena_usuario, id_tipo_usuario FROM misOfertasDB.usuario WHERE rut_usuario =:usuario AND contrasena_usuario =:contrasena", conexionOracle);
            cmd.Parameters.Add(":usuario", usuario.rut_usuario);
            cmd.Parameters.Add(":contrasena", usuario.contrasena_usuario);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //variables globales
                user.rut_usuario = reader["rut_usuario"].ToString();
                user.contrasena_usuario = reader["contrasena_usuario"].ToString();
                

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

        public bool registroUsuario(Usuario usuario)
        {
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            try
            {
                connection.Open();
                // NOTA MENTAL: PROCEDIMIENTOS ALMACENADOS para la inserción de usuarios?
                OracleCommand cmd = new OracleCommand("misOfertasDB.insertarUsuario", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("rut_usuario", OracleDbType.Varchar2, usuario.rut_usuario, ParameterDirection.Input);
                cmd.Parameters.Add("contrasena", OracleDbType.Varchar2, usuario.contrasena_usuario, ParameterDirection.Input);
                cmd.Parameters.Add("id_tipo_usuario", OracleDbType.Int32, usuario.id_tipo_usuario, ParameterDirection.Input);
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

        //---------------- REGISTRO PROVEEDOR ----------------

        public Proveedor distribuidor = new Proveedor();

        public bool existeProveedor(string rut_proveedor, string nombre_proveedor)
        {
            conexionOracle con = new conexionOracle();
            OracleConnection conexionOracle = new OracleConnection(con.getConnectionString);
            conexionOracle.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM misOfertasDB.proveedor WHERE rut_proveedor =:rut AND nombre_proveedor =:nombre", conexionOracle);
            cmd.Parameters.Add(":rut", rut_proveedor);
            cmd.Parameters.Add(":nombre", nombre_proveedor);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //mensajeError = "El proveedor ya existe";
                reader.Close();
                conexionOracle.Close();
                return false;
            }
            else
            {
                //mensajeError = "No existe el proveedor";
                reader.Close();
                conexionOracle.Close();
                return true;
            }
        }

        public bool registroProveedor(Proveedor proveedor)
        {
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            try
            {
                connection.Open();
                // NOTA MENTAL: PROCEDIMIENTOS ALMACENADOS para la inserción de proveedores?
                OracleCommand cmd = new OracleCommand("misOfertasDB.insertarProveedor", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("rut_proveedor", OracleDbType.Varchar2, distribuidor.rut_proveedor, ParameterDirection.Input);
                cmd.Parameters.Add("nombre_proveedor", OracleDbType.Varchar2, distribuidor.nombre_proveedor, ParameterDirection.Input);
                cmd.Parameters.Add("telefono", OracleDbType.Int32, distribuidor.telefono, ParameterDirection.Input);
                cmd.Parameters.Add("id_comuna", OracleDbType.Int32, distribuidor.id_comuna, ParameterDirection.Input);
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

        public bool modificarProveedor(Proveedor proveedor)
        {
            conexionOracle con = new conexionOracle();
            OracleConnection conexionOracle = new OracleConnection(con.getConnectionString);
            conexionOracle.Open();
            OracleCommand cmd = new OracleCommand("UPDATE * FROM misOfertasDB.proveedor WHERE rut_proveedor =:rut", conexionOracle);
            cmd.Parameters.Add("rut_proveedor", OracleDbType.Int32, proveedor.rut_proveedor, ParameterDirection.Input);
            cmd.Parameters.Add("nombre_proveedor", OracleDbType.Varchar2, proveedor.nombre_proveedor, ParameterDirection.Input);
            cmd.Parameters.Add("telefono", OracleDbType.Int32, proveedor.telefono, ParameterDirection.Input);
            cmd.Parameters.Add("id_comuna", OracleDbType.Int32, proveedor.id_comuna, ParameterDirection.Input);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //mensajeError = "El proveedor no se pudo actualizar";
                reader.Close();
                conexionOracle.Close();
                return false;
            }
            else
            {
                //mensajeError = "Se ha modificado el proveedor";
                reader.Close();
                conexionOracle.Close();
                return true;
            }
        }

        //---------------- REGISTRO TIPO USUARIO ----------------

        public TipoUsuario tipo = new TipoUsuario();

        public bool existeTipoUsuario(string nombre_tipo_usuario, string descripcion_tipo_usuario)
        {
            conexionOracle con = new conexionOracle();
            OracleConnection conexionOracle = new OracleConnection(con.getConnectionString);
            conexionOracle.Open();
            OracleCommand cmd = new OracleCommand("SELECT * FROM misOfertasDB.tipoUsuario WHERE id_tipo_usuario =:id AND nombre_tipo_usuario =:nombre", conexionOracle);
            cmd.Parameters.Add(":rut", nombre_tipo_usuario);
            cmd.Parameters.Add(":nombre", descripcion_tipo_usuario);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //mensajeError = "El proveedor ya existe";
                reader.Close();
                conexionOracle.Close();
                return false;
            }
            else
            {
                //mensajeError = "No existe el proveedor";
                reader.Close();
                conexionOracle.Close();
                return true;
            }
        }

        public bool registroTipoUsuario(TipoUsuario tipo)
        {
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            try
            {
                connection.Open();
                // NOTA MENTAL: PROCEDIMIENTOS ALMACENADOS para la inserción de Tipo Usuarios?
                OracleCommand cmd = new OracleCommand("misOfertasDB.insertarTipoUsuario", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("id_tipo_usuario", OracleDbType.Int32, tipo.id_tipo_usuario, ParameterDirection.Input);
                cmd.Parameters.Add("nombre_tipo_usuario", OracleDbType.Varchar2, tipo.nombre_tipo_usuario, ParameterDirection.Input);
                cmd.Parameters.Add("descripcion_tipo_usuario", OracleDbType.Varchar2, tipo.descripcion_tipo_usuario, ParameterDirection.Input);
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
    }

}

