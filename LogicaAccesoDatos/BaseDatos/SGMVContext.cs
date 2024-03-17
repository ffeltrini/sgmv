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
        public DbSet<TipoMantenimiento> TipoMantenimientos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<RepuestoUtilizado> RepuestoUtilizados { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<TipoRol> TipoRoles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public SGMVContext(DbContextOptions<SGMVContext> options) : base(options) { }

        
    }
}
