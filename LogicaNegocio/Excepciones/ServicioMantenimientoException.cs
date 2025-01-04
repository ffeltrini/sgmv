using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class ServicioMantenimientoException:Exception
    {
        public ServicioMantenimientoException() { }
        public ServicioMantenimientoException(string message) : base(message) { }
        public ServicioMantenimientoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
