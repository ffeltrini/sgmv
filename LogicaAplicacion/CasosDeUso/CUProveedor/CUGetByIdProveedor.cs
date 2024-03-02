using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUProveedor
{
    public class CUGetByIdProveedor : ICUGetByIdProveedor
    {
        public IRepositorio<Proveedor> RepositorioProveedor { get; set; }
        public CUGetByIdProveedor(IRepositorio<Proveedor> repositorioProveedor)
        {
            RepositorioProveedor = repositorioProveedor;
        }

        public Proveedor? GetByIdProveedor(int id)
        {
            return RepositorioProveedor.GetById(id);
        }
    }
}
