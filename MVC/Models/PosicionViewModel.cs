using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models
{
    public class PosicionViewModel
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public bool Reservada { get; set; }
        public Servicio Servicio { get; set; }
        public int ServicioId { get; set; }
        public IEnumerable<ServicioViewModel>? Servicios { get; set; } = new List<ServicioViewModel>();
    }
}
