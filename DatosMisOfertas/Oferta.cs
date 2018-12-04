using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosMisOfertas
{
    public class Oferta
    {
        public Oferta(int idOferta, int precioOferta, DateTime fechaInicio, DateTime fechaTermino, int idRubro, int idTipoOferta)
        {
            this.idOferta = idOferta;
            this.precioOferta = precioOferta;
            this.fechaInicio = fechaInicio;
            this.fechaTermino = fechaTermino;
            this.idRubro = idRubro;
            this.idTipoOferta = idTipoOferta;
        }

        public Oferta()
        {

        }

        public int idOferta { get; set; }
        public int precioOferta { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public int idRubro { get; set; }
        public int idTipoOferta { get; set; }
    }
}
