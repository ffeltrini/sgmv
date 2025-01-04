using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUEtapa
{
    public class CUGetByIdEtapa:ICUGetByIdEtapa
    {
        public IRepositorio<Etapa> RepositorioEtapas { get; set; }
        public CUGetByIdEtapa(IRepositorio<Etapa> repositorioEtapas)
        {
            RepositorioEtapas = repositorioEtapas;
        }

        public Etapa? GetByIdEtapa(int id)
        {
            return RepositorioEtapas.GetById(id);
        }
    }
}
