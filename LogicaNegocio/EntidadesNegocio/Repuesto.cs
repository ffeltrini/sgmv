using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Repuesto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Medida { get; set; }
        public string Unidad { get; set; }
        public int StockMin { get; set; }
        public int Stock { get; set; }

        public IEnumerable<CompraRepuesto> ListaCompraRepuesto { get; set; } = new List<CompraRepuesto>();
    }
}
