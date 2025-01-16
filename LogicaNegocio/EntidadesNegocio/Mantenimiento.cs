using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        public string Tarea { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Duracion { get; set; }
        public int Frecuencia { get; set; }

        
    }
}
