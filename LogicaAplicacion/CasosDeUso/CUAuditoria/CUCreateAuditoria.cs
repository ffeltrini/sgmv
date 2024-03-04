using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUAuditoria
{
    public class CUCreateAuditoria : ICUCreateAuditoria
    {
        public IRepositorio<Auditoria> RepositoriaAuditoria { get; set; }
        public CUCreateAuditoria(IRepositorio<Auditoria> repositoriaAuditoria)
        {
            RepositoriaAuditoria = repositoriaAuditoria;
        }

        public void CreateAuditoria(Auditoria auditoria)
        {
            RepositoriaAuditoria.Add(auditoria);
        }
    }
}
