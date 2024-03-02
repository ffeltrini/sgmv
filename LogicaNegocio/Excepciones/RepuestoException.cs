using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class RepuestoException:Exception
    {
        public RepuestoException() { }
        public RepuestoException(string message) : base(message) { }
        public RepuestoException(string message,Exception innerException) : base(message, innerException) { }
    }
}
