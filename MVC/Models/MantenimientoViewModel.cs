namespace MVC.Models
{
    public class MantenimientoViewModel
    {
        public int Id { get; set; }
        public string Tarea { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Duracion { get; set; }
        public int Frecuencia { get; set; }

        
    }
}
