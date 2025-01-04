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
    public class RepositorioRepuestosUtilizados:IRepositorio<RepuestoUtilizado>
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioRepuestosUtilizados( SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(RepuestoUtilizado repuestoUtilizado)
        {
            Contexto.RepuestoUtilizados.Add(repuestoUtilizado);
            Contexto.SaveChanges();
        }

        public void Update(RepuestoUtilizado item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RepuestoUtilizado GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RepuestoUtilizado> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
