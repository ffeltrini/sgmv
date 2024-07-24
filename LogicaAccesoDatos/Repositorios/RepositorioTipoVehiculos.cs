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
    public class RepositorioTipoVehiculos : IRepositorio<TipoVehiculo>
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioTipoVehiculos( SGMVContext contexto )
        {
            Contexto = contexto;
        }
        public void Add(TipoVehiculo item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoVehiculo> GetAll()
        {
            return Contexto.TipoVehiculos;
        }

        public TipoVehiculo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoVehiculo item)
        {
            throw new NotImplementedException();
        }
    }
}
