using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUEtapa
{
    public class CUGetAllEtapa:ICUGetAllEtapa
    {
        public IRepositorio<Etapa> RepositorioEtapas { get; set; }
        public CUGetAllEtapa(IRepositorio<Etapa> repositorioEtapas)
        {
            RepositorioEtapas = repositorioEtapas;
        }

        public IEnumerable<Etapa> GetAllEtapa()
        {
            return RepositorioEtapas.GetAll();
        }
    }
}
