using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EtapaViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Etapa")]
        public string EtapaNombre { get; set; }
    }
}
