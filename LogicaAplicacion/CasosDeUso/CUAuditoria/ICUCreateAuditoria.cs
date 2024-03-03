using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUAuditoria
{
    public interface ICUCreateAuditoria
    {
        void CreateAuditoria(Auditoria auditoria);
    }
}
