﻿using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUServicio
{
    public class CUGetAllServicio : ICUGetAllServicio
    {
        public IRepositorioServicios RepositorioServicios { get; set; }
        public CUGetAllServicio(IRepositorioServicios repositorioServicios)
        {
            RepositorioServicios = repositorioServicios;
        }

        public IEnumerable<Servicio> GetAllServicio()
        {
            return RepositorioServicios.GetAll();
        }
    }
}
