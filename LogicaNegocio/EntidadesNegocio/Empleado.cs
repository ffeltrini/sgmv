using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Empleado:Usuario
    {
        public Cargo EmpleadoCargo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string? Foto { get; set; }
        public int? Bono { get; set; }

        public enum Cargo
        {
            Gerente,
            Supervisor,
            Oficial,
            Asistente,
            Administrativo
        }
    }
}
