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
    public class RepositorioRepuestos:IRepositorioRepuestos
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioRepuestos(SGMVContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Repuesto repuesto)
        {
            try
            {
                Contexto.Repuestos.Add(repuesto);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }
        }

        public void Update(Repuesto repuesto)
        {
            if (repuesto != null)
            {
                try
                {
                    Repuesto? repuestoNuevo = Contexto.Repuestos.SingleOrDefault(r => r.Id == repuesto.Id);
                    if(repuestoNuevo!= null)
                    {
                        repuestoNuevo.Codigo = repuesto.Codigo;
                        repuestoNuevo.Nombre = repuesto.Nombre;
                        repuestoNuevo.Descripcion= repuesto.Descripcion;
                        repuestoNuevo.Medida = repuesto.Medida;
                        repuestoNuevo.Unidad = repuesto.Unidad;
                        repuestoNuevo.StockMin=repuesto.StockMin;
                        repuestoNuevo.Stock=repuesto.Stock;
                        Contexto.Repuestos.Update(repuestoNuevo);
                        Contexto.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw new Exception("Error");
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Repuesto? GetById(int id)
        {
            return Contexto.Repuestos.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Repuesto> GetAll()
        {
            return Contexto.Repuestos;
        }
    }
}
