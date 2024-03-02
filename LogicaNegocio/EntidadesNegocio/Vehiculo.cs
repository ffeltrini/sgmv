using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public int IdMotor { get; set; }
        public TipoVehiculo Tipo { get; set; }
        public DateTime Anio { get; set; }
        public string Color { get; set; }
        public string Inspeccion { get; set; }
        public string Imagen { get; set; }

    }
}
