using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUTipoMantenimiento
{
    public interface ICUGetAllTipoMantenimiento
    {
        IEnumerable<TipoMantenimiento> GetAllTipoMantenimiento();
    }
}
