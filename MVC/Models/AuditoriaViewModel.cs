using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class AuditoriaViewModel
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        [Display(Name = "Fecha/Hora")]
        public DateTime FechaHora { get; set; }
        [Display(Name = "Id Entidad")]
        public int IdEntidad { get; set; }
        [Display(Name = "Tipo")]
        public string TipoEntidad { get; set; }
        [Display(Name = "Operación")]
        public string Operacion { get; set; }
    }
}
