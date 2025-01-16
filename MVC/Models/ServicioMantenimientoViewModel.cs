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
        public int EtapaId { get; set; }
        public int[] RepuestosId { get; set; }
        public DateTime[] Fecha { get; set; }
        public int[] Cantidad { get; set; }
        
        public IEnumerable<EtapaViewModel> Etapas { get; set; } = new List<EtapaViewModel>();
        public IEnumerable<RepuestoViewModel> Repuestos { get; set; } = new List<RepuestoViewModel>();
        public List<RepuestoUtilizadoViewModel> ListaRepuestosUtilizados { get; set; } = new List<RepuestoUtilizadoViewModel>();

    }
}
