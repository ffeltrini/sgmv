using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUVehiculo
{
    public class CUGetAllVehiculo:ICUGetAllVehiculo
    {
        public IRepositorioVehiculos RepositorioVehiculos { get; set; }
        public CUGetAllVehiculo(IRepositorioVehiculos repositorioVehiculos)
        {
            RepositorioVehiculos = repositorioVehiculos;
        }

        public IEnumerable<Vehiculo> GetAllVehiculo()
        {
            return RepositorioVehiculos.GetAll();
        }
    }
}
