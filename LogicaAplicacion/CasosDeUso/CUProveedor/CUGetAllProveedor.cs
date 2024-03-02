using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUProveedor
{
    public class CUGetAllProveedor:ICUGetAllProveedor
    {
        public IRepositorio<Proveedor> RepositorioProveedores { get; set; }
        public CUGetAllProveedor(IRepositorio<Proveedor> repositorioProveedores)
        {
            RepositorioProveedores = repositorioProveedores;
        }

        public IEnumerable<Proveedor> GetAllProveedor()
        {
            return RepositorioProveedores.GetAll();
        }
    }
}
