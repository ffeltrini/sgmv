using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUServicioMantenimiento
{
    public class CUGetAllServicioMantenimiento:ICUGetAllServicioMantenimiento
    {
        public IRepositorio<ServicioMantenimiento> RepositorioServicioMantenimientos { get; set; }

        public CUGetAllServicioMantenimiento(IRepositorio<ServicioMantenimiento> repositorioServicioMantenimientos)
        {
            RepositorioServicioMantenimientos = repositorioServicioMantenimientos;
        }

        public IEnumerable<ServicioMantenimiento> GetAllServicioMantenimiento()
        {
            return RepositorioServicioMantenimientos.GetAll();
        }
    }
}
