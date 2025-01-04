using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models
{
    public class RepuestoUtilizadoViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ServicioMantenimientoId { get; set; }  // Enlace con ServicioMantenimiento
        public ServicioMantenimiento ServicioMantenimiento { get; set; }  // Relación con ServicioMantenimiento
        public Repuesto Repuesto { get; set; }
        public int RepuestoId { get; set; }
        public int Cantidad { get; set; }

        //public IEnumerable<RepuestoUtilizadoViewModel> Repuestos { get; set; } = new List<RepuestoUtilizadoViewModel>();
    }
}
