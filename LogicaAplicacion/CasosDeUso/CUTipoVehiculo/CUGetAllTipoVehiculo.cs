using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUTipoVehiculo
{
    public class CUGetAllTipoVehiculo : ICUGetAllTipoVehiculo
    {
        public IRepositorio<TipoVehiculo> RepositorioTipoVehiculos { get; set; }
        public CUGetAllTipoVehiculo(IRepositorio<TipoVehiculo> repositorioTipoVehiculos)
        {
            RepositorioTipoVehiculos = repositorioTipoVehiculos;
        }

        public IEnumerable<TipoVehiculo> GetAllTipoVehiculo()
        {
            return RepositorioTipoVehiculos.GetAll();
        }
    }
}
