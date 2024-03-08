using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public string Confirmacion { get; set; }
        public int RolId { get; set; }
        public DateTime Fecha { get; set; }
        //public int[] TipoRolesId { get; set; }

        //select
        public IEnumerable<TipoRolViewModel> Roles { get; set; } = new List<TipoRolViewModel>();
    }
}
