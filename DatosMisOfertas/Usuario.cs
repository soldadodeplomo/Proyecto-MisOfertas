using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosMisOfertas
{
    public class Usuario
    {
        public string rut_usuario { get; set; }
        public string contrasena_usuario { get; set; }
        public int id_tipo_usuario { get; set; }

        public Usuario()
        {

        }

        public Usuario(string rut_usuario, string contrasena_usuario, int id_tipo_usuario)
        {  
            this.rut_usuario = rut_usuario;
            this.contrasena_usuario = contrasena_usuario;
            this.id_tipo_usuario = id_tipo_usuario;
        }


    }
}
