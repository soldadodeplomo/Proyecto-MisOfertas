using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using DatosMisOfertas;

namespace LibreriaMisOfertas
{
    public class loginAdministrador
    {
        public AdministradorTienda admTienda = new AdministradorTienda();        
        public bool iniciarSesionAdm(string rut, string contrasena)
        {
            conexionOracle temp = new conexionOracle();
            OracleConnection con = new OracleConnection(temp.getConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT rut_usuario, contrasena_usuario, id_tipo_usuario FROM misOfertasDB.usuario WHERE rut_usuario=:rut AND contrasena_usuario=:contrasena", con);
            cmd.Parameters.Add(":rut", rut);
            cmd.Parameters.Add(":contrasena", contrasena);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                admTienda.id = Convert.ToInt32(reader["id_tipo_usuario"].ToString());
                if (admTienda.id==1)
                {
                    admTienda.rutAdm = reader["rut_usuario"].ToString();
                    admTienda.contrasena = reader["contrasena_usuario"].ToString();
                    reader.Close();
                    con.Close();
                }
                else
                {
                    return false;
                }
                return true;
            }
            else
            {
                reader.Close();
                con.Close();
                return false;
            }
            //pedir registro social de hogares
        }
    }
}
