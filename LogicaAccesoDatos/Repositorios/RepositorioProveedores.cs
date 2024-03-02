using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioProveedores : IRepositorio<Proveedor>
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioProveedores(SGMVContext contexto )
        {
            Contexto = contexto;
        }

        public void Add(Proveedor proveedor)
        {
            proveedor.ValidarDatos();
            Contexto.Proveedores.Add(proveedor);
            Contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ProveedorException("El id de Proveedor no es correcto");
            }
            Proveedor? proveedor = Contexto.Proveedores.Find(id);
            if (proveedor != null)
            {
                Contexto.Proveedores.Remove(proveedor);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ProveedorException("No hay un Proveedor para eliminar");
            }
        }

        public IEnumerable<Proveedor> GetAll()
        {
            return Contexto.Proveedores;
        }

        public Proveedor? GetById(int id)
        {
            return Contexto.Proveedores.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Proveedor proveedor)
        {
            if (proveedor != null)
            {
                proveedor.ValidarDatos();
                try
                {
                    Proveedor? proveedorNuevo = Contexto.Proveedores.SingleOrDefault(p => p.Id == proveedor.Id);
                    if(proveedorNuevo!=null)
                    {
                        proveedorNuevo.Nombre = proveedor.Nombre;
                        proveedorNuevo.FechaInicio = proveedor.FechaInicio;
                        proveedorNuevo.Nacional = proveedor.Nacional;
                        Contexto.Proveedores.Update(proveedorNuevo);
                        Contexto.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw new Exception("No puede haber más de un proveedor con igual id");
                }
            }
        }
    }
}
