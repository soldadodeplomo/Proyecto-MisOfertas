using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosMisOfertas
{
    public class ImagenBoleta
    {
        public int idImagen { get; set; }
        public DateTime fechaCarga { get; set; }
        public Byte[] imagenBoleta { get; set; }

        public ImagenBoleta()
        {

        }

        public ImagenBoleta(int idImagen, DateTime fechaCarga, byte[] imagenBoleta)
        {
            this.idImagen = idImagen;
            this.fechaCarga = fechaCarga;
            this.imagenBoleta = imagenBoleta;
        }
    }
}
