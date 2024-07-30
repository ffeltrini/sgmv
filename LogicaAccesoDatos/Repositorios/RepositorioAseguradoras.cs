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
    public class RepositorioAseguradoras : IRepositorio<Aseguradora>
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioAseguradoras( SGMVContext contexto )
        {
            Contexto = contexto;
        }
        public void Add(Aseguradora item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aseguradora> GetAll()
        {
            return Contexto.Aseguradoras;
        }

        public Aseguradora? GetById(int id)
        {
            return Contexto.Aseguradoras.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Aseguradora item)
        {
            throw new NotImplementedException();
        }
    }
}
