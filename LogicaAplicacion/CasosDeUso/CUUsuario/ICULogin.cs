using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public interface ICULogin
    {
        Usuario Login(string nombre, string contrasenia);
    }
}
