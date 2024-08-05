using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Interfaces;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosDeUso.CUAseguradora;
using LogicaAplicacion.CasosDeUso.CUAuditoria;
using LogicaAplicacion.CasosDeUso.CUCliente;
using LogicaAplicacion.CasosDeUso.CUCompra;
using LogicaAplicacion.CasosDeUso.CUEmpleado;
using LogicaAplicacion.CasosDeUso.CUEtapa;
using LogicaAplicacion.CasosDeUso.CUMantenimiento;
using LogicaAplicacion.CasosDeUso.CUProveedor;
using LogicaAplicacion.CasosDeUso.CURepuesto;
using LogicaAplicacion.CasosDeUso.CUServicio;
using LogicaAplicacion.CasosDeUso.CUTipoMantenimiento;
using LogicaAplicacion.CasosDeUso.CUTipoRol;
using LogicaAplicacion.CasosDeUso.CUTipoVehiculo;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.CasosDeUso.CUVehiculo;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigurationBuilder configuration = new ConfigurationBuilder();
            configuration.AddJsonFile("appsettings.json");
            string cadenaConexion = configuration.Build().GetConnectionString("CadenaConexion");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IRepositorio<Proveedor>, RepositorioProveedores>();
            builder.Services.AddScoped<ICUGetAllProveedor, CUGetAllProveedor>();
            builder.Services.AddScoped<ICUCreateProveedor, CUCreateProveedor>();
            builder.Services.AddScoped<ICUGetByIdProveedor, CUGetByIdProveedor>();
            builder.Services.AddScoped<ICUDeleteProveedor, CUDeleteProveedor>();
            builder.Services.AddScoped<ICUUpdateProveedor, CUUpdateProveedor>();

            builder.Services.AddScoped<IRepositorioCompras, RepositorioCompras>();
            builder.Services.AddScoped<ICUCreateCompra, CUCreateCompra>();
            builder.Services.AddScoped<ICUGetAllCompra, CUGetAllCompra>();
            builder.Services.AddScoped<ICUUpdateCompra, CUUpdateCompra>();
            builder.Services.AddScoped<ICUGetByAmountCompra, CUGetByAmountCompra>();
            builder.Services.AddScoped<ICUGetByIdCompra, CUGetByIdCompra>();

            builder.Services.AddScoped<IRepositorio<TipoMantenimiento>, RepositorioTipoMantenimientos>();
            builder.Services.AddScoped<ICUCreateTipoMantenimiento, CUCreateTipoMantenimiento>();
            builder.Services.AddScoped<ICUGetAllTipoMantenimiento, CUGetAllTipoMantenimiento>();

            builder.Services.AddScoped<IRepositorio<Etapa>, RepositorioEtapas>();
            builder.Services.AddScoped<ICUCreateEtapa, CUCreateEtapa>();
            builder.Services.AddScoped<ICUGetAllEtapa, CUGetAllEtapa>();

            builder.Services.AddScoped<IRepositorioRepuestos, RepositorioRepuestos>();
            builder.Services.AddScoped<ICUGetAllRepuesto,CUGetAllRepuesto>();
            builder.Services.AddScoped<ICUCreateRepuesto, CUCreateRepuesto>();
            builder.Services.AddScoped<ICUGetByIdRepuesto, CUGetByIdRepuesto>();
            builder.Services.AddScoped<ICUUpdateRepuesto, CUUpdateRepuesto>();

            builder.Services.AddScoped<IRepositorioServicios, RepositorioServicios>();
            builder.Services.AddScoped<ICUGetAllServicio, CUGetAllServicio>();
            builder.Services.AddScoped<ICUCreateServicio, CUCreateServicio>();
            builder.Services.AddScoped<ICUUpdateServicio, CUUpdateServicio>();
            builder.Services.AddScoped<ICUGetByIdServicio, CUGetByIdServicio>();    

            builder.Services.AddScoped<IRepositorioMantenimientos, RepositorioMantenimientos>();
            builder.Services.AddScoped<ICUGetAllMantenimiento , CUGetAllMantenimiento>();
            builder.Services.AddScoped<ICUCreateMantenimiento, CUCreateMantenimiento>();

            builder.Services.AddScoped<IRepositorio<Auditoria>, RepositorioAuditorias>();
            builder.Services.AddScoped<ICUCreateAuditoria, CUCreateAuditoria>();
            builder.Services.AddScoped<ICUGetAllAuditoria, CUGetAllAuditoria>();

            builder.Services.AddScoped<IRepositorio<TipoRol>,RepositorioTipoRoles>();
            builder.Services.AddScoped<ICUGetAllTipoRol, CUGetAllTipoRol>();
            builder.Services.AddScoped<ICUGetByIdTipoRol, CUGetByIdTipoRol>();
            builder.Services.AddScoped<ICUCreateTipoRol, CUCreateTipoRol>();

            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            builder.Services.AddScoped<ICUCreateUsuario, CUCreateUsuario>();
            builder.Services.AddScoped<ICUGetAllUsuario, CUGetAllUsuario>();
            

            builder.Services.AddScoped<IRepositorio<Cliente>, RepositorioClientes>();
            builder.Services.AddScoped<ICUGetAllCliente, CUGetAllCliente>();
            builder.Services.AddScoped<ICUGetByIdCliente, CUGetByIdCliente>();
            builder.Services.AddScoped<ICUCreateCliente, CUCreateCliente>();

            builder.Services.AddScoped<ICUCreateEmpleado, CUCreateEmpleado>();

            builder.Services.AddScoped<IRepositorio<TipoVehiculo>, RepositorioTipoVehiculos>();
            builder.Services.AddScoped<ICUGetAllTipoVehiculo, CUGetAllTipoVehiculo>();
            builder.Services.AddScoped<ICUGetByIdTipoVehiculo, CUGetByIdTipoVehiculo>();
            
            builder.Services.AddScoped<IRepositorio<Aseguradora>,RepositorioAseguradoras>();
            builder.Services.AddScoped<ICUGetAllAseguradora, CUGetAllAseguradora>();
            builder.Services.AddScoped<ICUGetByIdAseguradora,CUGetByIdAseguradora>();

            builder.Services.AddScoped<IRepositorioVehiculos, RepositorioVehiculos>();
            builder.Services.AddScoped<ICUGetAllVehiculo, CUGetAllVehiculo>();
            builder.Services.AddScoped<ICUCreateVehiculo,CUCreateVehiculo>();
            builder.Services.AddScoped<ICUGetByIdVehiculo, CUGetByIdVehiculo>();

            builder.Services.AddScoped<ICULogin, CULogin>();

            builder.Services.AddDbContext<SGMVContext>(Options=>Options.UseSqlServer(cadenaConexion));

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Login}/{id?}");

            app.Run();
        }
    }
}