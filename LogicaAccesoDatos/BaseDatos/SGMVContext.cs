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
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<ServicioMantenimiento> ServicioMantenimientos { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<RepuestoUtilizado> RepuestoUtilizados { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<TipoRol> TipoRoles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public DbSet<Aseguradora> Aseguradoras { get; set; }

        public SGMVContext(DbContextOptions<SGMVContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Usuario>().UseTpcMappingStrategy();
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Empleado>().ToTable("Empleados");
        }

    }
}
