using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUProveedor
{
    public class CUUpdateProveedor:ICUUpdateProveedor
    {
        public IRepositorio<Proveedor> RepositorioProveedor { get; set; }
        public CUUpdateProveedor(IRepositorio<Proveedor> repositorioProveedor)
        {
            RepositorioProveedor = repositorioProveedor;
        }

        public void UpdateProveedor(Proveedor proveedor)
        {
            RepositorioProveedor.Update(proveedor);
        }
    }
}
