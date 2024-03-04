namespace MVC.Models
{
    public class AuditoriaViewModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdEntidad { get; set; }
        public string TipoEntidad { get; set; }
    }
}
