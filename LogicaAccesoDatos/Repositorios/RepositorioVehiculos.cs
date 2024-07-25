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
    public class RepositorioVehiculos:IRepositorioVehiculos
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioVehiculos(SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Vehiculo vehiculo)
        {
            Contexto.Vehiculos.Add(vehiculo);
            Contexto.SaveChanges();
        }

        public void Update(Vehiculo item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Vehiculo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehiculo> GetAll()
        {
            return Contexto.Vehiculos
                .Include(v=>v.Tipo)
                .Include(v=>v.Seguro)
                .Include(v=>v.Cliente)
                .ToList();
        }
    }
}
