using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUServicio
{
    public class CUCreateServicio:ICUCreateServicio
    {
        public IRepositorioServicios RepositorioServicios { get; set; }
        public CUCreateServicio(IRepositorioServicios repositorioServicios)
        {
            RepositorioServicios = repositorioServicios;
        }

        public void CreateServicio(Servicio servicio)
        {
            RepositorioServicios.Add(servicio);
        }
    }
}
