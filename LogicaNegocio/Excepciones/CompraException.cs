using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class CompraException:Exception
    {
        public CompraException() { }
        public CompraException(string message):base(message) { }
        public CompraException(string message, Exception innerException):base(message, innerException) { }
    }
}
