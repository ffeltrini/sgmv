using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUEtapa
{
    public class CUCreateEtapa:ICUCreateEtapa
    {
        public IRepositorio<Etapa> RepositorioEstapa { get; set; }
        public CUCreateEtapa(IRepositorio<Etapa> repositorioEstapa)
        {
            RepositorioEstapa = repositorioEstapa;
        }

        public void CreateEtapa(Etapa etapa)
        {
            RepositorioEstapa.Add(etapa);
        }
    }
}
