using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models
{
    public class ServicioViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int VehiculoId { get; set; }
        public int Km { get; set; }
        public DateTime FechaFin { get; set; }
        public int[] MantenimientoId { get; set; }
        public IEnumerable<ServicioMantenimiento> ListaServicioMantenimiento { get; set; } = new List<ServicioMantenimiento>();
        //select
        public IEnumerable<VehiculoViewModel> Vehiculos { get; set; }=new List<VehiculoViewModel>();
        public IEnumerable<MantenimientoViewModel> Mantenimientos { get;set; }= new List<MantenimientoViewModel>();
    }
}
