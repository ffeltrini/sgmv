using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUTipoMantenimiento
{
    public class CUGetAllTipoMantenimiento:ICUGetAllTipoMantenimiento
    {
        public IRepositorio<TipoMantenimiento> RepositorioTipoMantenimientos { get; set; }
        public CUGetAllTipoMantenimiento(IRepositorio<TipoMantenimiento> repositorioTipoMantenimientos)
        {
            RepositorioTipoMantenimientos = repositorioTipoMantenimientos;
        }

        public IEnumerable<TipoMantenimiento> GetAllTipoMantenimiento()
        {
            return RepositorioTipoMantenimientos.GetAll();
        }
    }
}
