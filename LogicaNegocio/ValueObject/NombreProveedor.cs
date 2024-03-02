using LogicaNegocio.Excepciones;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    [Owned]
    [Index(nameof(Valor),IsUnique =true)]
    public class NombreProveedor : IValidate
    {
        public string Valor { get;}
        public NombreProveedor(string valor)
        {
            Valor= valor;
            ValidarDatos();
        }
        public void ValidarDatos()
        {
            if(Valor.Trim().Length<2 || Valor.Trim().Length > 50)
            {
                throw new ProveedorException("El nombre del proveedor debe tener entre 2 y 50 caracteres");
            }
        }
    }
}
