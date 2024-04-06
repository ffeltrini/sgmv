using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Cliente:Usuario
    {
        public string LicenciaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public bool Frecuente { get; set; }
        public string Actividad { get; set; }
        public int Puntos { get; set; }
    }
}
