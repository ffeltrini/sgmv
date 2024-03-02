using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCompra
{
    public class CUGetByAmountCompra:ICUGetByAmountCompra
    {
        public IRepositorioCompras RepositorioCompras { get; set; }
        public CUGetByAmountCompra(IRepositorioCompras repositorioCompras)
        {
            RepositorioCompras = repositorioCompras;
        }

        public IEnumerable<Compra> ComprasPorMonto(decimal monto1, decimal monto2)
        {
            return RepositorioCompras.ComprasPorMonto(monto1, monto2);
        }
    }
}
