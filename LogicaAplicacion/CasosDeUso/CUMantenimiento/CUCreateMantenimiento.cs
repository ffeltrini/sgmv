using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUMantenimiento
{
    public class CUCreateMantenimiento:ICUCreateMantenimiento
    {
        public IRepositorioMantenimientos RepositorioMantenimientos { get; set; }
        public CUCreateMantenimiento(IRepositorioMantenimientos repositorioMantenimientos)
        {
            RepositorioMantenimientos = repositorioMantenimientos;
        }

        public void CreateMantenimiento(Mantenimiento mantenimiento)
        {
            RepositorioMantenimientos.Add(mantenimiento);
        }
    }
}
