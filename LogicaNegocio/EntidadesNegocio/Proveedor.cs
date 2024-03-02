using LogicaNegocio.Excepciones;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Proveedor:IValidate
    {
        public int Id { get; set; }
        public NombreProveedor Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public bool Nacional { get; set; }

        public void ValidarDatos()
        {
            if (FechaInicio > DateTime.Now)
            {
                throw new ProveedorException("La fecha de inicio debe ser menor o igual a la fecha actual");
            }
        }
    }
}
