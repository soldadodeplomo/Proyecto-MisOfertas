using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosMisOfertas
{
    public class CertificadoDescuento
    {
        public decimal idCertificado { get; set; }
        public decimal puntosDescuentos { get; set; }
        public string rubro { get; set; }
        public decimal porcentaje { get; set; }
        public decimal topeDinero { get; set; }
        public decimal idTipo { get; set; }

        public CertificadoDescuento()
        {

        }

        public CertificadoDescuento(decimal idCertificado, decimal puntosDescuentos, string rubro, decimal porcentaje, decimal topeDinero, decimal idTipo)
        {
            this.idCertificado = idCertificado;
            this.puntosDescuentos = puntosDescuentos;
            this.rubro = rubro;
            this.porcentaje = porcentaje;
            this.topeDinero = topeDinero;
            this.idTipo = idTipo;
        }
    }
}
