using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUServicioMantenimiento
{
    public class CUUpdateServicioMantenimiento:ICUUpdateServicioMantenimiento
    {
        public IRepositorio<ServicioMantenimiento> RepositorioServicioMantenimientos { get; set; }
        public CUUpdateServicioMantenimiento(IRepositorio<ServicioMantenimiento> repositorioServicioMantenimientos)
        {
            RepositorioServicioMantenimientos = repositorioServicioMantenimientos;
        }

        public void UpdateServicioMantenimiento(ServicioMantenimiento servicioMantenimiento)
        {
            RepositorioServicioMantenimientos.Update(servicioMantenimiento);
        }
    }
}
