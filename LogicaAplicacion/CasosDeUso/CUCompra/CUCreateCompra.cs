using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCompra
{
    public class CUCreateCompra:ICUCreateCompra
    {
        public IRepositorioCompras RepositorioCompras { get; set; }
        public CUCreateCompra(IRepositorioCompras repositorioCompras)
        {
            RepositorioCompras = repositorioCompras;
        }

        public void CreateCompra(Compra compra)
        {
            RepositorioCompras.Add(compra);
        }
    }
}
