using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosMisOfertas
{
    public class AdministradorTienda
    {
        public AdministradorTienda()
        {

        }

        public AdministradorTienda(string rutAdm, string contrasena, int id)
        {
            this.rutAdm = rutAdm;
            this.contrasena = contrasena;
            this.id = id;
        }

        public string rutAdm { get; set; }
        public string contrasena { get; set; }
        public int id { get; set; }
    }
}
