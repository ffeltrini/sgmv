using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Auditoria
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdEntidad { get; set; }
        public string TipoEntidad { get; set; }
    }
}
