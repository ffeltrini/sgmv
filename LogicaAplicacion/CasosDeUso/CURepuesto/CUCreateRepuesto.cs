using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CURepuesto
{
    public class CUCreateRepuesto:ICUCreateRepuesto
    {
        public IRepositorioRepuestos RepositorioRepuestos { get; set; }
        public CUCreateRepuesto(IRepositorioRepuestos repositorioRepuestos)
        {
            RepositorioRepuestos = repositorioRepuestos;
        }

        public void CreateRepuesto(Repuesto repuesto)
        {
            RepositorioRepuestos.Add(repuesto);
        }
    }
}
