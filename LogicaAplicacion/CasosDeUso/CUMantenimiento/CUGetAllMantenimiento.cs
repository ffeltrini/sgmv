using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUMantenimiento
{
    public class CUGetAllMantenimiento:ICUGetAllMantenimiento
    {
        public IRepositorioMantenimientos RepositorioMantenimientos { get; set; }
        public CUGetAllMantenimiento(IRepositorioMantenimientos repositorioMantenimientos)
        {
            RepositorioMantenimientos = repositorioMantenimientos;
        }

        public IEnumerable<Mantenimiento> GetAllMantenimiento()
        {
            return RepositorioMantenimientos.GetAll();
        }
    }
}
