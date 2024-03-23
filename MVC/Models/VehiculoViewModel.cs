using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models
{
    public class VehiculoViewModel
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public int IdMotor { get; set; }
        public TipoVehiculo Tipo { get; set; }
        public DateTime Anio { get; set; }
        public string Color { get; set; }
        //public int Inspeccion { get; set; }
        public Aseguradora Seguro { get; set; }
        public string Imagen { get; set; }
    }
}
