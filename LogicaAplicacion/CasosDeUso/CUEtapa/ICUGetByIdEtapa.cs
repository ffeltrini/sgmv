using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUEtapa
{
    public interface ICUGetByIdEtapa
    {
        Etapa? GetByIdEtapa(int id);
    }
}
