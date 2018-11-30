using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosMisOfertas
{
    public class Consumidor
    {
        public string runConsumidor { get; set; }
        public string nombreConsumidor { get; set; }
        public string correoConsumidor { get; set; }
        public string contrasenaConsumidor { get; set; }
        public char recibirOferta { get; set; }
        public int idComunaConsumidor { get; set; }
        public int idTipoConsumidor { get; set; }

        public Consumidor(string correo, string contrasena)
        {
            this.correoConsumidor = correo;
            this.contrasenaConsumidor = contrasena;
        }

        public Consumidor(string runConsumidor, string nombreConsumidor, string correoConsumidor, string contrasenaConsumidor, char recibirOferta, int idComunaConsumidor, int idTipoConsumidor)
        {
            this.runConsumidor = runConsumidor;
            this.nombreConsumidor = nombreConsumidor;
            this.correoConsumidor = correoConsumidor;
            this.contrasenaConsumidor = contrasenaConsumidor;
            this.recibirOferta = recibirOferta;
            this.idComunaConsumidor = idComunaConsumidor;
            this.idTipoConsumidor = idTipoConsumidor;
        }

        public Consumidor()
        {

        }
    }
}
