using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class CULogin:ICULogin
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; set; }
        public CULogin(IRepositorioUsuarios repositorioUsuarios)
        {
            RepositorioUsuarios = repositorioUsuarios;
        }

        public Usuario Login(string nombre, string contrasenia)
        {
            return RepositorioUsuarios.Login(nombre, contrasenia);
        }
    }
}
