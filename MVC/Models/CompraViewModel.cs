using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class CompraViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ProveedorId { get; set; }
        [Display(Name = "Compra Recibida")]
        public bool Recibida { get; set; }
        [Display(Name = "Fecha de Recepción")]
        public DateTime FechaRecepcion { get; set; }
        [Display(Name ="Demora (días)")]
        public int DiasDemora { get; set; }
        public int[] RepuestosId { get; set; }
        public decimal[] Precio { get; set; }
        public int[] Cantidad { get; set; }

        public IEnumerable<CompraRepuestoViewModel> ListaCompraRepuesto { get; set; } = new List<CompraRepuestoViewModel>();

        //select
        public IEnumerable<ProveedorViewModel> Proveedores { get; set;} = new List<ProveedorViewModel>();
        public IEnumerable<RepuestoViewModel> Repuestos { get; set; } = new List<RepuestoViewModel>();
    }
}
