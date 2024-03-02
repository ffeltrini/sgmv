using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCompra
{
    public class CUGetByIdCompra:ICUGetByIdCompra
    {
        public IRepositorioCompras RepositorioCompras { get; set; }
        public CUGetByIdCompra(IRepositorioCompras repositorioCompras)
        {
            RepositorioCompras = repositorioCompras;
        }

        public Compra? GetByIdCompra(int id)
        {
            return RepositorioCompras.GetById(id);
        }
    }
}
