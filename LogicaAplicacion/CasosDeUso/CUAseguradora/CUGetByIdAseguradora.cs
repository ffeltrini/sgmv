using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUAseguradora
{
    public class CUGetByIdAseguradora : ICUGetByIdAseguradora
    {
        public IRepositorio<Aseguradora> RepositorioAseguradoras { get; set; }
        public CUGetByIdAseguradora(IRepositorio<Aseguradora> repositorioAseguradoras)
        {
            RepositorioAseguradoras = repositorioAseguradoras;
        }

        public Aseguradora? GetByIdAseguradora(int id)
        {
            return RepositorioAseguradoras.GetById(id);
        }
    }
}
