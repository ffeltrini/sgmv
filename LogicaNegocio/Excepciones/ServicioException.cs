using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class ServicioException:Exception
    {
        public ServicioException() { }
        public ServicioException(string message) : base(message) { }
        public ServicioException(string message, Exception innerException) : base(message, innerException) { }
    }
}
