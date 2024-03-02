using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUProveedor
{
    public class CUDeleteProveedor : ICUDeleteProveedor
    {
        public IRepositorio<Proveedor> RepositorioProveedor { get; set; }
        public CUDeleteProveedor(IRepositorio<Proveedor> repositorioProveedor)
        {
            RepositorioProveedor = repositorioProveedor;
        }

        public void DeleteProveedor(int id)
        {
            RepositorioProveedor.Delete(id);
        }
    }
}
