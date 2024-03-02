using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CURepuesto
{
    public class CUGetByIdRepuesto:ICUGetByIdRepuesto
    {
        public IRepositorioRepuestos RepositorioRepuestos { get; set; }
        public CUGetByIdRepuesto(IRepositorioRepuestos repositorioRepuestos)
        {
            RepositorioRepuestos = repositorioRepuestos;
        }

        public Repuesto? GetByIdRepuesto(int id)
        {
            return RepositorioRepuestos.GetById(id);
        }
    }
}
