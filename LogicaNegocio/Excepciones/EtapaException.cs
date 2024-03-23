using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class EtapaException:Exception
    {
        public EtapaException() { }
        public EtapaException(string message) : base(message) { }
        public EtapaException(string message,Exception innerException) : base(message, innerException) { }
    }
}
