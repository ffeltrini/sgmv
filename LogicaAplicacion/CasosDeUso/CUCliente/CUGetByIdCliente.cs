using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCliente
{
    public class CUGetByIdCliente : ICUGetByIdCliente
    {
        public IRepositorio<Cliente> RepositorioClientes { get; set; }
        public CUGetByIdCliente(IRepositorio<Cliente> repositorioClientes)
        {
            RepositorioClientes = repositorioClientes;
        }

        public Cliente? GetByIdCliente(int id)
        {
            return RepositorioClientes.GetById(id);
        }
    }
}
