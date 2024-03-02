using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CURepuesto
{
    public class CUGetAllRepuesto:ICUGetAllRepuesto
    {
        public IRepositorioRepuestos RepositorioRepuestos { get; set; }
        public CUGetAllRepuesto(IRepositorioRepuestos repositorioRepuestos)
        {
            RepositorioRepuestos= repositorioRepuestos;
        }
        public IEnumerable<Repuesto> GetAllRepuesto()
        {
            return RepositorioRepuestos.GetAll();
        }
    }
}
