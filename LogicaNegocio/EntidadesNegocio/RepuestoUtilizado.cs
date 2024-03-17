using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class RepuestoUtilizado
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ServicioMantenimientoId { get; set; }
        public int RepuestoId { get; set; }
        public int Cantidad { get; set; }
    }
}
