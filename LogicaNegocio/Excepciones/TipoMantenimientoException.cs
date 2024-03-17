using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class TipoMantenimientoException:Exception
    {
        public TipoMantenimientoException() { }
        public TipoMantenimientoException(string message):base(message) { }
        public TipoMantenimientoException(string message, Exception innerException):base(message, innerException) { }
    }
}
