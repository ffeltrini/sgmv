using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUVehiculo
{
    public class CUCreateVehiculo:ICUCreateVehiculo
    {
        public IRepositorioVehiculos RepositorioVehiculos { get; set; }
        public CUCreateVehiculo(IRepositorioVehiculos repositorioVehiculos)
        {
            RepositorioVehiculos = repositorioVehiculos;
        }

        public void CreateVehiculo(Vehiculo vehiculo)
        {
            RepositorioVehiculos.Add(vehiculo);
        }
    }
}
