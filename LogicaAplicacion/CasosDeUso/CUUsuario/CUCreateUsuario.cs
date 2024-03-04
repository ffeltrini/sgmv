using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class CUCreateUsuario:ICUCreateUsuario
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; set; }
        public CUCreateUsuario(IRepositorioUsuarios repositorioUsuarios)
        {
            RepositorioUsuarios = repositorioUsuarios;
        }

        public void CreateUsuario(Usuario usuario)
        {
            RepositorioUsuarios.Add(usuario);
        }
    }
}
