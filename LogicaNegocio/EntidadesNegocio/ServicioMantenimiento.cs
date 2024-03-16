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
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public TipoMantenimiento TipoMantenimiento { get; set; }
        public bool Siniestro { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaProxMant { get; set; }
        public Etapa Etapa { get; set; }
    }
}
