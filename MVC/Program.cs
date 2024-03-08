using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Interfaces;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosDeUso.CUCompra;
using LogicaAplicacion.CasosDeUso.CUProveedor;
using LogicaAplicacion.CasosDeUso.CURepuesto;
using LogicaAplicacion.CasosDeUso.CUTipoRol;
using LogicaAplicacion.CasosDeUso.CUUsuario;
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

            builder.Services.AddScoped<IRepositorioRepuestos, RepositorioRepuestos>();
            builder.Services.AddScoped<ICUGetAllRepuesto,CUGetAllRepuesto>();
            builder.Services.AddScoped<ICUCreateRepuesto, CUCreateRepuesto>();
            builder.Services.AddScoped<ICUGetByIdRepuesto, CUGetByIdRepuesto>();
            builder.Services.AddScoped<ICUUpdateRepuesto, CUUpdateRepuesto>();

            builder.Services.AddScoped<IRepositorioUsuarios,RepositorioUsuarios>();
            builder.Services.AddScoped<ICUCreateUsuario, CUCreateUsuario>();
            builder.Services.AddScoped<ICUGetAllUsuario,CUGetAllUsuario>();
            builder.Services.AddScoped<ICULogin, CULogin>();    

            builder.Services.AddScoped<IRepositorio<TipoRol>,RepositorioTipoRoles>();
            builder.Services.AddScoped<ICUGetAllTipoRol, CUGetAllTipoRol>();
            builder.Services.AddScoped<ICUGetByIdTipoRol, CUGetByIdTipoRol>();
            builder.Services.AddScoped<ICUCreateTipoRol, CUCreateTipoRol>();

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