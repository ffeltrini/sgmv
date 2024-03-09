using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUTipoRol
{
    public class CUGetAllTipoRol:ICUGetAllTipoRol
    {
        public IRepositorio<TipoRol> RepositorioTipoRoles { get; set; }
        public CUGetAllTipoRol(IRepositorio<TipoRol> repositorioTipoRoles)
        {
            RepositorioTipoRoles = repositorioTipoRoles;
        }

        public IEnumerable<TipoRol> GetAllTipoRol()
        {
            return RepositorioTipoRoles.GetAll();
        }
    }
}
