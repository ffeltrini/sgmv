using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Interfaces
{
    public interface IRepositorioCompras:IRepositorio<Compra>
    {
        IEnumerable<Compra> ComprasPorMonto(decimal monto1, decimal monto2);
    }
}
