using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaVence { get; set; }
        public decimal Total { get; set; }
    }
}
