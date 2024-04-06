using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            // Depending on the type of Usuario, add to the respective DbSet
            if (usuario is Cliente cliente)
            {
                Contexto.Clientes.Add(cliente);
            }
            else if (usuario is Empleado empleado)
            {
                Contexto.Empleados.Add(empleado);
            }
            else
            {
                throw new InvalidOperationException("Unknown type of Usuario");
            }

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
            //return Contexto.Usuarios.Include(t => t.Rol);
            // Combine results from both Clientes and Empleados
            var usuarios = new List<Usuario>();

            usuarios.AddRange(Contexto.Clientes.Include(c => c.Rol));
            usuarios.AddRange(Contexto.Empleados.Include(e => e.Rol));

            return usuarios;
        }

        public Usuario? Login(string cedula, string contrasenia)
        {
            //return Contexto.Usuarios
            //    .Include(t=>t.Rol)
            //    .Where(u => u.Cedula == cedula && u.Contrasenia == contrasenia)
            //    .SingleOrDefault();
            // Depending on the type of Usuario, check in the respective DbSet
            var cliente = Contexto.Clientes.Include(c => c.Rol).FirstOrDefault(c => c.Cedula == cedula && c.Contrasenia == contrasenia);
            if (cliente != null)
            {
                return cliente;
            }

            var empleado = Contexto.Empleados.Include(e => e.Rol).FirstOrDefault(e => e.Cedula == cedula && e.Contrasenia == contrasenia);
            if (empleado != null)
            {
                return empleado;
            }

            return null;
        }
    }
}
