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
    public class RepositorioServicios:IRepositorioServicios
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioServicios(SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Servicio item)
        {
            throw new NotImplementedException();
        }

        public void Update(Servicio item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Servicio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Servicio> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
