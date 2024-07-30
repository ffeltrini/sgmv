using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCliente
{
    public class CUGetAllCliente : ICUGetAllCliente
    {
        public IRepositorio<Cliente> RepositorioClientes { get; set; }
        public CUGetAllCliente(IRepositorio<Cliente> repositorioClientes)
        {
            RepositorioClientes = repositorioClientes;
        }

        public IEnumerable<Cliente> GetAllCliente()
        {
            return RepositorioClientes.GetAll();
        }
    }
}
