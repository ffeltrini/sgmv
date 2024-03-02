using LogicaNegocio.EntidadesNegocio;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class RepuestoViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Medida { get; set; }
        public string Unidad { get; set; }
        [Display(Name = "Stock Mínimo")]
        public int StockMin { get; set; }
        public int Stock { get; set; }
        public IEnumerable<CompraRepuesto> ListaCompraRepuestos { get; set; } = new List<CompraRepuesto>();
    }
}
