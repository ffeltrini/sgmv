using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUProveedor
{
    public interface ICUGetAllProveedor
    {
        IEnumerable<Proveedor> GetAllProveedor();
    }
}
