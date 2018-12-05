using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosMisOfertas
{
    public class Producto
    {
        public int sku { get; set; }
        public string nombreProducto { get; set; }
        public int precioProducto { get; set; }
        public string marca { get; set; }
        public Byte[] imagenProducto { get; set; }
        public int ventaMin { get; set; }
        public int ventaMax { get; set; }
        public int idRubro { get; set; }
        public int idLote { get; set; }
        public int idSubFamilia { get; set; }

        public string rubro { get; set; }
        public string subFamilia { get; set; }
        public Producto()
        {

        }

        public Producto(int sku, string nombreProducto, int precioProducto, string marca, byte[] imagenProducto, int ventaMin, int ventaMax, int idRubro, int idLote, int idSubFamilia, string rubro, string subFamilia)
        {
            this.sku = sku;
            this.nombreProducto = nombreProducto;
            this.precioProducto = precioProducto;
            this.marca = marca;
            this.imagenProducto = imagenProducto;
            this.ventaMin = ventaMin;
            this.ventaMax = ventaMax;
            this.idRubro = idRubro;
            this.idLote = idLote;
            this.idSubFamilia = idSubFamilia;
            this.rubro = rubro;
            this.subFamilia = subFamilia;
        }
    }
}
