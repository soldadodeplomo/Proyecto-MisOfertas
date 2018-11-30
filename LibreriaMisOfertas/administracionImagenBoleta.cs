using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.IO;
using DatosMisOfertas;
using System.Data;

namespace LibreriaMisOfertas
{
    public class administracionImagenBoleta
    {
        public bool agregarBoleta(Byte[] imagen)
        {
            //DateTime date = DateTime.Now;
            //string fecha = date.ToString("yyyy-MM-dd H:mm:ss");
            conexionOracle temp = new conexionOracle();
            OracleConnection conexion = new OracleConnection(temp.getConnectionString);
            conexion.Open();
            OracleCommand cmd = new OracleCommand("INSERT INTO misOfertasDB.imagenboleta (id_imagen_boleta, imagen_boleta, fecha_carga) VALUES (misOfertasDB.imagenboleta_seq.nextval,:imagenByte,(SELECT SYSDATE FROM DUAL))", conexion);
            cmd.Parameters.Add("imagenByte",OracleDbType.Blob).Value=imagen;
            //cmd.Parameters.Add("fecha",OracleDbType.Date).Value=DateTime.Now;
            cmd.ExecuteNonQuery();
            conexion.Close();            
            return true;
        }

        //public void agregarImagenBoleta(ImagenBoleta imagen)
        //{
        //    DateTime date = DateTime.Now;
        //    string fecha = date.ToString("yyyy-MM-dd H:mm:ss");
        //    conexionOracle oracle = new conexionOracle();
        //    OracleConnection conexion = new OracleConnection(oracle.getConnectionString);
        //    conexion.Open();
        //    OracleCommand cmd = new OracleCommand("misOfertasDB.insertarImagenBoleta", conexion);
        //    cmd.Parameters.Add("fechaCarga", OracleDbType.Date, fecha,ParameterDirection.Input);
        //    cmd.Parameters.Add("imagenBoleta", OracleDbType.Blob, imagen.imagenBoleta, ParameterDirection.Input);
        //    cmd.ExecuteNonQuery();
        //}

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

        public int obtenerMaxID()
        {
            conexionOracle temp = new conexionOracle();
            OracleConnection conexion = new OracleConnection(temp.getConnectionString);
            conexion.Open();
            OracleCommand cmd = new OracleCommand("SELECT MAX(id_imagen_boleta) FROM misOfertasDB.imagenBoleta", conexion);
            OracleDataReader reader= cmd.ExecuteReader();
            string t = reader["MAX(id_imagen_boleta)"].ToString();
            int max = Convert.ToInt32(t);
            return max;
        }
    }
}
