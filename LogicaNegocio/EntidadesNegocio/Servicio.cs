using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Servicio
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int Km { get; set; }
        public TipoEstado Estado { get; set; }
        public IEnumerable<ServicioRepuesto> ListaRepuestos { get; set; }
    }
}
