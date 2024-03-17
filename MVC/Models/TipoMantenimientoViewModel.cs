using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class TipoMantenimientoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tipo")]
        public string NombreMantenimiento { get; set; }
    }
}
