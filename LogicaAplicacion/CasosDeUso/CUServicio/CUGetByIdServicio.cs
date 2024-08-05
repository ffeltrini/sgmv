using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUServicio
{
    public class CUGetByIdServicio:ICUGetByIdServicio
    {
        public IRepositorioServicios RepositorioServicios { get; set; }
        public CUGetByIdServicio(IRepositorioServicios repositorioServicios)
        {
            RepositorioServicios = repositorioServicios;
        }

        public Servicio? GetByIdServicio(int id)
        {
            return RepositorioServicios.GetById(id);
        }
    }
}
