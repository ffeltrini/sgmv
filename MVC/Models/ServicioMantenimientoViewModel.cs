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
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Observaciones { get; set; }
        //public int EtapaId { get; set; }
        //select
        //public IEnumerable<EtapaViewModel> Etapa { get; set; } = new List<EtapaViewModel>();
    }
}
