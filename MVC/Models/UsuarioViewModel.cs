using LogicaNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now.Date;
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string Confirmacion { get; set; }
        public int RolId { get; set; }
        
        //select
        public IEnumerable<TipoRolViewModel> Roles { get; set; } = new List<TipoRolViewModel>();

        // Additional properties for Cliente
        public string LicenciaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public bool Frecuente { get; set; }
        public string Actividad { get; set; }
        public int Puntos { get; set; }

        // Additional properties for Empleado
        public Empleado.Cargo EmpleadoCargo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string? Foto { get; set; }
        public int? Bono { get; set; }

        // Dropdown items for EmpleadoCargo
        public IEnumerable<SelectListItem> EmpleadoCargos { get; set; } = new List<SelectListItem>();
    }
}
