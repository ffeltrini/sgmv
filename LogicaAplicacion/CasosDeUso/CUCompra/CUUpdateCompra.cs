using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCompra
{
    public class CUUpdateCompra:ICUUpdateCompra
    {
        public IRepositorioCompras RepositorioCompras { get; set; }
        public CUUpdateCompra(IRepositorioCompras repositorioCompras)
        {
            RepositorioCompras = repositorioCompras;
        }

        public void UpdateCompra(Compra compra)
        {
            RepositorioCompras.Update(compra);
        }
    }
}
