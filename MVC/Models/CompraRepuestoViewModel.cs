using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models
{
    public class CompraRepuestoViewModel
    {
        public int Id { get; set; }
        public Compra Compra { get; set; }
        public int CompraId { get; set; }
        public Repuesto Repuesto { get; set; }
        public int RepuestoId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
