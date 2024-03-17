﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class MantenimientoException:Exception
    {
        public MantenimientoException() { }
        public MantenimientoException(string message) : base(message) { }
        public MantenimientoException(string message,Exception innerException) : base(message, innerException) { }
    }
}
