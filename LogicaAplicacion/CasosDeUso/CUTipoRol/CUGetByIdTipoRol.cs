using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUTipoRol
{
    public class CUGetByIdTipoRol:ICUGetByIdTipoRol
    {
        public IRepositorio<TipoRol> RepositorioRoles { get; set; }
        public CUGetByIdTipoRol(IRepositorio<TipoRol> repositorioRoles)
        {
            RepositorioRoles = repositorioRoles;
        }

        public TipoRol? GetByIdTipoRol(int id)
        {
            return RepositorioRoles.GetById(id);
        }
    }
}
