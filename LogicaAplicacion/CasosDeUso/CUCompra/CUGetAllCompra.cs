using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCompra
{
    public class CUGetAllCompra:ICUGetAllCompra
    {
        public IRepositorioCompras RepositorioCompras { get; set; }
        public CUGetAllCompra(IRepositorioCompras repositorioCompras)
        {
            RepositorioCompras = repositorioCompras;
        }

        public IEnumerable<Compra> GetAllCompra()
        {
            return RepositorioCompras.GetAll();
        }
    }
}
