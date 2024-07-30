using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCliente
{
    public interface ICUGetByIdCliente
    {
        Cliente? GetByIdCliente(int id);
    }
}
