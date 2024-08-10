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
    public class RepositorioPosiciones:IRepositorio<Posicion>
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioPosiciones(SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Posicion item)
        {
            throw new NotImplementedException();
        }

        public void Update(Posicion item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Posicion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Posicion> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
