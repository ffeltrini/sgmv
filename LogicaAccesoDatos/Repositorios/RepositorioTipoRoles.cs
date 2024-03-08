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
    public class RepositorioTipoRoles:IRepositorio<TipoRol>
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioTipoRoles(SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(TipoRol item)
        {
            Contexto.TipoRoles.Add(item);
            Contexto.SaveChanges();
        }

        public void Update(TipoRol item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TipoRol? GetById(int id)
        {
            return Contexto.TipoRoles.FirstOrDefault(r => r.Id==id);
        }

        public IEnumerable<TipoRol> GetAll()
        {
            return Contexto.TipoRoles;
        }
    }
}
