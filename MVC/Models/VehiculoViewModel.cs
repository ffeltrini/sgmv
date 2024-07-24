using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models
{
    public class VehiculoViewModel
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public int IdMotor { get; set; }
        public DateTime Anio { get; set; }
        public string Color { get; set; }
        public int TipoVehiculoId { get; set; }
        
        //public int Inspeccion { get; set; }
        
        public int AseguradoraId { get; set; }
        public string Imagen { get; set; }
        public int UsuarioId { get; set; }

        public IEnumerable<TipoVehiculoViewModel> TipoVehiculos { get; set; } = new List<TipoVehiculoViewModel>();

        public IEnumerable<AseguradoraViewModel> Aseguradoras { get; set; } = new List<AseguradoraViewModel>();
        public IEnumerable<UsuarioViewModel> Clientes { get; set; } = new List<UsuarioViewModel>();

    }
}
