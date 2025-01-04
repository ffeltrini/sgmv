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
        public int[] EtapaId { get; set; }
        public string[] Observaciones { get; set; }

        public int[] RepuestosId { get; set; }

        // Nueva propiedad que usa un diccionario para los repuestos utilizados
        //public Dictionary<int, List<RepuestoViewModel>> RepuestosUtilizados { get; set; }
        public IEnumerable<ServicioMantenimientoViewModel> ListaServicioMantenimiento { get; set; } = new List<ServicioMantenimientoViewModel>();
        //select
        public IEnumerable<VehiculoViewModel> Vehiculos { get; set; }=new List<VehiculoViewModel>();
        public IEnumerable<MantenimientoViewModel> Mantenimientos { get;set; }= new List<MantenimientoViewModel>();

        public IEnumerable<EtapaViewModel> Etapas { get; set; } = new List<EtapaViewModel>();

        public IEnumerable<RepuestoViewModel> Repuestos { get; set; } = new List<RepuestoViewModel>();
        public IEnumerable<RepuestoUtilizadoViewModel> ListaRepuestosUtilizados { get; set; } = new List<RepuestoUtilizadoViewModel>();
        

    }
}
