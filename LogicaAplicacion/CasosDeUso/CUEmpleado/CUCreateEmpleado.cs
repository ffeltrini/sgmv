using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUEmpleado
{
    public class CUCreateEmpleado:ICUCreateEmpleado
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; set; }
        public CUCreateEmpleado(IRepositorioUsuarios repositorioUsuarios)
        {
            RepositorioUsuarios = repositorioUsuarios;
        }

        public void CreateEmpleado(Empleado empleado)
        {
            RepositorioUsuarios.Add(empleado);
        }
    }
}
