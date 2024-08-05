using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioServicios:IRepositorioServicios
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioServicios(SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Servicio servicio)
        {
            try
            {
                Contexto.Servicios.Add(servicio);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }
        }

        public void Update(Servicio servicio)
        {
            Contexto.Servicios.Update(servicio);
            for(int i=0; i<servicio.ListaServicioMantenimiento.ToList().Count; i++)
            {
                Contexto.ServicioMantenimientos.Update(servicio.ListaServicioMantenimiento.ToList()[i]);
            }
            Contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Servicio? GetById(int id)
        {
            return Contexto.Servicios
                .Include(s=>s.Vehiculo)
                .Include(s=>s.ListaServicioMantenimiento)
                .FirstOrDefault(s=>s.Id== id);
        }

        public IEnumerable<Servicio> GetAll()
        {
            return Contexto.Servicios
                .Include(s => s.Vehiculo)
                .Include(s=>s.ListaServicioMantenimiento)
                .ThenInclude(sm=>sm.Mantenimiento)
                .ToList();
        }
    }
}
