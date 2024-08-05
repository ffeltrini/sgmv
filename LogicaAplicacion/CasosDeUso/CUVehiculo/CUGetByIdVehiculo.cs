using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUVehiculo
{
    public class CUGetByIdVehiculo : ICUGetByIdVehiculo
    {
        public IRepositorioVehiculos RepositorioVehiculos { get; set; }
        public CUGetByIdVehiculo(IRepositorioVehiculos repositorioVehiculos)
        {
            RepositorioVehiculos = repositorioVehiculos;
        }

        public Vehiculo? GetByIdVehiculo(int id)
        {
            return RepositorioVehiculos.GetById(id);
        }
    }
}
