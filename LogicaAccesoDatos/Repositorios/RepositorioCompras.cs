using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioCompras : IRepositorioCompras
    {
        public SGMVContext Contexto { get; set; }
        public RepositorioCompras(SGMVContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Compra compra)
        {
            try
            {
                Contexto.Compras.Add(compra);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Compra> GetAll()
        {
            return Contexto.Compras
                .Include(c => c.Proveedor)
                .Include(c => c.ListaCompraRepuesto)
                .ThenInclude(cr=>cr.Repuesto)
                .ToList();
        }

        public Compra? GetById(int id)
        {
            return Contexto.Compras
                .Include(c => c.Proveedor)
                .Include(c => c.ListaCompraRepuesto)
                .ThenInclude(cr => cr.Repuesto)
                .FirstOrDefault(c => c.Id == id);
        }

        public void Update(Compra compra)
        {
            Contexto.Compras.Update(compra);   
            for(int i=0; i<compra.ListaCompraRepuesto.ToList().Count; i++)
            {
                Contexto.CompraRepuestos.Update(compra.ListaCompraRepuesto.ToList()[i]);
            }
            Contexto.SaveChanges();
        }

        public IEnumerable<Compra> ComprasPorMonto(decimal monto1, decimal monto2)
        {
            var compras = Contexto.Compras
                .Include(p => p.Proveedor)
                .Include(cr=>cr.ListaCompraRepuesto)
                .ThenInclude(r=>r.Repuesto)
                .Where(c=>c.ListaCompraRepuesto.Sum(r=>r.Precio * r.Cantidad)>= monto1
                && c.ListaCompraRepuesto.Sum(r=>r.Precio * r.Cantidad)<= monto2)
                .ToList();
            return compras;
        }
    }
}
