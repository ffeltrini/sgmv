﻿using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUAuditoria
{
    public class CUGetAllAuditoria:ICUGetAllAuditoria
    {
        public IRepositorio<Auditoria> RepositorioAuditorias { get; set; }
        public CUGetAllAuditoria(IRepositorio<Auditoria> repositorioAuditorias)
        {
            RepositorioAuditorias = repositorioAuditorias;
        }

        public IEnumerable<Auditoria> GetAllAuditoria()
        {
            return RepositorioAuditorias.GetAll();
        }
    }
}
