using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models
{
    public class ServicioMantenimientoViewModel
    {
        public int Id { get; set; }
        public Servicio Servicio { get; set; }
        public int ServicioId { get; set; }
        public Mantenimiento Mantenimiento { get; set; }
        public int MantenimientoId { get; set; }
        public bool Siniestro { get; set; }
        
    }
}
