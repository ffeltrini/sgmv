﻿using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class AuditoriaViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }
        [Display(Name = "Nombre")]
        public string NombreUsuario { get; set; }
        [Display(Name = "Apellido")]
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
