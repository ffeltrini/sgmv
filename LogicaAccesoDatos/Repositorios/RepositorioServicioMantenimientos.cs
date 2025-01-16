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
    public class RepositorioServicioMantenimientos:IRepositorio<ServicioMantenimiento>
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioServicioMantenimientos(SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(ServicioMantenimiento item)
        {
            try
            {
                Contexto.ServicioMantenimientos.Add(item);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public void Update(ServicioMantenimiento item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServicioMantenimiento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServicioMantenimiento> GetAll()
        {
            return Contexto.ServicioMantenimientos.ToList();
        }
    }
}
