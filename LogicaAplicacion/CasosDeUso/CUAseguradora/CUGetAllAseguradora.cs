using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUAseguradora
{
    public class CUGetAllAseguradora : ICUGetAllAseguradora
    {
        public IRepositorio<Aseguradora> RepositorioAseguradoras { get; set; }
        public CUGetAllAseguradora(IRepositorio<Aseguradora> repositorioAseguradoras)
        {
            RepositorioAseguradoras = repositorioAseguradoras;
        }

        public IEnumerable<Aseguradora> GetAllAseguradora()
        {
            throw new NotImplementedException();
        }
    }
}
