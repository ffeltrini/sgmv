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
    public class RepositorioClientes:IRepositorio<Cliente>
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioClientes(SGMVContext contexto) 
        {
            Contexto = contexto;
        }

        public void Add(Cliente item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            return Contexto.Clientes;
        }

        public Cliente? GetById(int id)
        {
            return Contexto.Clientes.Find(id);
        }

        public void Update(Cliente item)
        {
            throw new NotImplementedException();
        }
    }
}
