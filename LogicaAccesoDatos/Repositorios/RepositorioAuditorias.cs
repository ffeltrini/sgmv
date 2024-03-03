using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditorias:IRepositorioAuditorias
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioAuditorias(SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Auditoria item)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Auditoria GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auditoria> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
