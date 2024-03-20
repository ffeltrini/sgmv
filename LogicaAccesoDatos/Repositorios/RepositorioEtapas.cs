using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEtapas:IRepositorio<Etapa>
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioEtapas(SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Etapa item)
        {
            Contexto.Add(item);
            Contexto.SaveChanges();
        }

        public void Update(Etapa item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Etapa GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Etapa> GetAll()
        {
            return Contexto.Etapas;
        }
    }
}
