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
    public class RepositorioTipoMantenimientos:IRepositorio<TipoMantenimiento>
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioTipoMantenimientos(SGMVContext contexto)
        {
            this.Contexto = contexto;
        }

        public void Add(TipoMantenimiento item)
        {
            Contexto.TipoMantenimientos.Add(item);
            Contexto.SaveChanges();
        }

        public void Update(TipoMantenimiento item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TipoMantenimiento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoMantenimiento> GetAll()
        {
            return Contexto.TipoMantenimientos;
        }
    }
}
