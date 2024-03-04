namespace MVC.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public string Confirmacion { get; set; }
        public string Rol { get; set; }
        public DateTime Fecha { get; set; }
    }
}
