using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCliente
{
    public class CUCreateCliente:ICUCreateCliente
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; set; }
        public CUCreateCliente(IRepositorioUsuarios repositorioUsuarios)
        {
            RepositorioUsuarios = repositorioUsuarios;
        }

        public void CreateCliente(Cliente cliente)
        {
            RepositorioUsuarios.Add(cliente);
        }
    }
}
