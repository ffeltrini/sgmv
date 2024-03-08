using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.BaseDatos
{
    public class SGMVContext:DbContext
    {
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Repuesto> Repuestos { get; set; }  
        public DbSet<CompraRepuesto> CompraRepuestos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoRol> TipoRoles { get; set; }

        public SGMVContext(DbContextOptions<SGMVContext> options) : base(options) { }

        
    }
}
