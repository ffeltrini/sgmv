using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class CUGetAllUsuario:ICUGetAllUsuario
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; set; }
        public CUGetAllUsuario(IRepositorioUsuarios repositorioUsuarios)
        {
            RepositorioUsuarios = repositorioUsuarios;
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return RepositorioUsuarios.GetAll();
        }
    }
}
