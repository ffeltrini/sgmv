using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUTipoMantenimiento
{
    public class CUCreateTipoMantenimiento:ICUCreateTipoMantenimiento
    {
        public IRepositorio<TipoMantenimiento> RepositorioTipoMantenimientos { get; set; }
        public CUCreateTipoMantenimiento(IRepositorio<TipoMantenimiento> repositorioTipoMantenimientos)
        {
            RepositorioTipoMantenimientos = repositorioTipoMantenimientos;
        }

        public void CreateTipoMantenimiento(TipoMantenimiento tipoMantenimiento)
        {
            RepositorioTipoMantenimientos.Add(tipoMantenimiento);
        }
    }
}
