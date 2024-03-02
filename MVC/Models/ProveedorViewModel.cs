using LogicaNegocio.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ProveedorViewModel
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Largo del nombre: entre 2 y 50 caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }
        public bool Nacional { get; set; }
    }
}
