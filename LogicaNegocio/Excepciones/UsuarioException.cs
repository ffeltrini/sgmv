﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class UsuarioException:Exception
    {
        public UsuarioException() { }   
        public UsuarioException(string message):base(message) { }
        public UsuarioException(string message, Exception innerException):base(message, innerException) { }
    }
}
