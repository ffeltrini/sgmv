using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUTipoRol
{
    public class CUCreateTipoRol:ICUCreateTipoRol
    {
        public IRepositorio<TipoRol> RepositorioTipoRoles { get; set; }
        public CUCreateTipoRol(IRepositorio<TipoRol> repositorioTipoRoles)
        {
            RepositorioTipoRoles = repositorioTipoRoles;
        }

        public void CreateTipoRol(TipoRol tipoRol)
        {
            RepositorioTipoRoles.Add(tipoRol);
        }
    }
}
