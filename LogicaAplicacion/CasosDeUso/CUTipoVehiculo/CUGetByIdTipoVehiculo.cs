using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUTipoVehiculo
{
    public class CUGetByIdTipoVehiculo: ICUGetByIdTipoVehiculo
    {
        public IRepositorio<TipoVehiculo> RepositorioTipoVehiculos { get; set; }
        public CUGetByIdTipoVehiculo(IRepositorio<TipoVehiculo> repositorioTipoVehiculos)
        {
            RepositorioTipoVehiculos = repositorioTipoVehiculos;
        }

        public TipoVehiculo? GetByIdVehiculo(int id)
        {
            return RepositorioTipoVehiculos.GetById(id);
        }
    }
}
