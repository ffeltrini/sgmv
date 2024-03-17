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
    public class RepositorioMantenimientos:IRepositorioMantenimientos
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioMantenimientos( SGMVContext contexto )
        {
            Contexto= contexto;
        }

        public void Add(Mantenimiento mantenimiento)
        {
            Contexto.Mantenimientos.Add(mantenimiento);
            Contexto.SaveChanges();
        }

        public void Update(Mantenimiento item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Mantenimiento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantenimiento> GetAll()
        {
            return Contexto.Mantenimientos;
        }
    }
}
