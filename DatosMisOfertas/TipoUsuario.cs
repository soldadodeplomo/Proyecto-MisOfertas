using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosMisOfertas
{
    public class TipoUsuario
    {
        public int id_tipo_usuario { get; set; }
        public string nombre_tipo_usuario { get; set; }
        public int descripcion_tipo_usuario { get; set; }

        public TipoUsuario()
        {

        }

        public TipoUsuario(int id_tipo_usuario, string nombre_tipo_usuario, int descripcion_tipo_usuario)
        {
            this.id_tipo_usuario = id_tipo_usuario;
            this.nombre_tipo_usuario = nombre_tipo_usuario;
            this.descripcion_tipo_usuario = descripcion_tipo_usuario;
        }
    }
}
