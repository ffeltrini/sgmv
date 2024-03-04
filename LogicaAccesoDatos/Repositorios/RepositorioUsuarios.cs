using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuarios:IRepositorioUsuarios
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioUsuarios(SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Usuario usuario)
        {
            Contexto.Usuarios.Add(usuario);
            Contexto.SaveChanges();
        }

        public void Update(Usuario item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return Contexto.Usuarios;
        }

        public Usuario? Login(string nombre, string contrasenia)
        {
            return Contexto.Usuarios
                .Where(u => u.Nombre == nombre && u.Contrasenia == contrasenia)
                .SingleOrDefault();
        }
    }
}
