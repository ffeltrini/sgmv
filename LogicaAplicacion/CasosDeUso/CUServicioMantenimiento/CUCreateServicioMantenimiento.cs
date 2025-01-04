using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUServicioMantenimiento
{
    public class CUCreateServicioMantenimiento:ICUCreateServicioMantenimiento
    {
        public IRepositorio<ServicioMantenimiento> RepositorioServicioMantenimientos { get; set; }  
        public CUCreateServicioMantenimiento(IRepositorio<ServicioMantenimiento> repositorioServicioMantenimientos)
        {
            RepositorioServicioMantenimientos = repositorioServicioMantenimientos;
        }

        public void CreateServicioMantenimiento(ServicioMantenimiento servicioMantenimiento)
        {
            RepositorioServicioMantenimientos.Add(servicioMantenimiento);
        }
    }
}
