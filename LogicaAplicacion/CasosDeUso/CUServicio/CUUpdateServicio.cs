using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUServicio
{
    public class CUUpdateServicio:ICUUpdateServicio
    {
        public IRepositorioServicios RepositorioServicios { get; set; }
        public CUUpdateServicio(IRepositorioServicios repositorioServicios)
        {
            RepositorioServicios = repositorioServicios;
        }

        public void UpdateServicio(Servicio servicio)
        {
            RepositorioServicios.Update(servicio);
        }
    }
}
