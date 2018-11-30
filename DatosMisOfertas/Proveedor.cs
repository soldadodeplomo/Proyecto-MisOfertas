using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosMisOfertas
{
    public class Proveedor
    {
        public int rut_proveedor { get; set; }
        public string nombre_proveedor { get; set; }
        public int telefono { get; set; }
        public int id_comuna { get; set; }

        public Proveedor()
        {

        }

        public Proveedor(int rut_proveedor, string nombre_proveedor, int telefono, int id_comuna)
        {
            this.rut_proveedor = rut_proveedor;
            this.nombre_proveedor = nombre_proveedor;
            this.telefono = telefono;
            this.id_comuna = id_comuna;
        }

       
    }
}
