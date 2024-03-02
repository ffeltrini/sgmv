using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CURepuesto
{
    public class CUUpdateRepuesto:ICUUpdateRepuesto
    {
        public IRepositorioRepuestos RepositorioRepuestos { get; set; }
        public CUUpdateRepuesto(IRepositorioRepuestos repositorioRepuestos)
        {
            RepositorioRepuestos = repositorioRepuestos;
        }

        public void UpdateRepuesto(Repuesto repuesto)
        {
            RepositorioRepuestos.Update(repuesto);
        }
    }
}
