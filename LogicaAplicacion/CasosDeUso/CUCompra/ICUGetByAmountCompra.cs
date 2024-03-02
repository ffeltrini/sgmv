using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCompra
{
    public interface ICUGetByAmountCompra
    {
        IEnumerable<Compra> ComprasPorMonto(decimal monto1,decimal monto2);
    }
}
