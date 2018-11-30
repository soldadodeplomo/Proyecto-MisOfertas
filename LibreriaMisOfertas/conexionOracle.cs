using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMisOfertas
{
    public class conexionOracle
    {
        private string conexion = "Data Source=XE;User Id=SYSTEM;Password=hods6bf8";
        public string getConnectionString
        {
            get {return conexion; }
        }
    }
}
