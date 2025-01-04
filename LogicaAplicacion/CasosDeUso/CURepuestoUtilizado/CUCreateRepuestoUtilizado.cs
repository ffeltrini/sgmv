using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CURepuestoUtilizado
{
    public class CUCreateRepuestoUtilizado:ICUCreateRepuestoUtilizado
    {
        public IRepositorio<RepuestoUtilizado> RepositorioRepuestosUtilizados {  get; set; }
        public CUCreateRepuestoUtilizado(IRepositorio<RepuestoUtilizado> repositorioRepuestosUtilizados)
        {
            RepositorioRepuestosUtilizados = repositorioRepuestosUtilizados;
        }

        public void CreateRepuestoUtilizado(RepuestoUtilizado repuestoUtilizado)
        {
            RepositorioRepuestosUtilizados.Add(repuestoUtilizado);
        }
    }
}
