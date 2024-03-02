using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class CompraRepuesto
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public Compra Compra { get; set; }  
        public int RepuestoId { get; set; }
        public Repuesto Repuesto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
