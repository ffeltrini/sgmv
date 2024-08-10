using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Posicion
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public bool Reservada { get; set; }
        public Servicio Servicio { get; set; }
    }
}
