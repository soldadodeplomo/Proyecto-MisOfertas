using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace LibreriaMisOfertas
{
    public class administracionValorizacionOferta
    {
        public bool agregarValoracionOferta(int clasificacion, string rutCons, string correoCons, int idRubro)
        {
            administracionImagenBoleta tempImage = new administracionImagenBoleta();
            conexionOracle temp = new conexionOracle();
            OracleConnection conexion = new OracleConnection(temp.getConnectionString);
            conexion.Open();
            OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.experienciaconsumidor (id_experiencia_usuario, clasificacion, rut_consumidor, correo_consumidor, id_rubro, id_imagen_boleta) VALUES (misOfertasDB.expconsumidor_seq.nextval,:clas, :rut, :correo, :rubro, (SELECT MAX(id_imagen_boleta) FROM misOfertasDB.imagenBoleta))", conexion);
            //OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.experienciaconsumidor (id_experiencia_usuario, clasificacion, rut_consumidor, correo_consumidor, idRubro, idImagenBoleta) VALUES (misOfertasDB.expconsumidor_seq,:clas, :rut, :correo, :rubro, misOfertasDB.imagenboleta_seq.currval )", conexion);
            cmd.Parameters.Add("clas",OracleDbType.Int32).Value=clasificacion;
            cmd.Parameters.Add("rut",OracleDbType.Varchar2).Value=rutCons;
            cmd.Parameters.Add("correo",OracleDbType.Varchar2).Value=correoCons;
            cmd.Parameters.Add("rubro",OracleDbType.Int32).Value=idRubro;
            //cmd.Parameters.Add("max",OracleDbType.In6t32).Value=tempImage.obtenerMaxID();
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
