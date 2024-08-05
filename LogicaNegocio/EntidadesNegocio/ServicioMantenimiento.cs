using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class ServicioMantenimiento
    {
        public int Id { get; set; }
        public int ServicioId { get; set; }
        public int MantenimientoId { get; set; }
        public Mantenimiento Mantenimiento { get; set; }
        public bool Siniestro { get; set; }
        
    }
}
