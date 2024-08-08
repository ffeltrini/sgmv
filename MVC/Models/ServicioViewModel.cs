using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models
{
    public class ServicioViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int VehiculoId { get; set; }
        public int Km { get; set; }
        public bool Siniestro { get; set; }
        public DateTime ProximoServicio { get; set; }
        public int[] MantenimientosId { get; set; }
        public DateTime[] Inicio { get; set; }
        public DateTime[] Fin { get; set; }
        public string[] Observaciones { get; set; }
        public IEnumerable<ServicioMantenimientoViewModel> ListaServicioMantenimiento { get; set; } = new List<ServicioMantenimientoViewModel>();
        //select
        public IEnumerable<VehiculoViewModel> Vehiculos { get; set; }=new List<VehiculoViewModel>();
        public IEnumerable<MantenimientoViewModel> Mantenimientos { get;set; }= new List<MantenimientoViewModel>();
    }
}
