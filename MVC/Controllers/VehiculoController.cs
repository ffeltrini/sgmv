using Azure.Core;
using LogicaAccesoDatos.Interfaces;
using LogicaAplicacion.CasosDeUso.CUAseguradora;
using LogicaAplicacion.CasosDeUso.CUAuditoria;
using LogicaAplicacion.CasosDeUso.CUCliente;
using LogicaAplicacion.CasosDeUso.CUTipoVehiculo;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.CasosDeUso.CUVehiculo;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class VehiculoController : Controller
    {
        public IRepositorioVehiculos RepositorioVehiculos { get; set; }
        public ICUGetAllVehiculo CUGetAllVehiculo { get; set; }
        public ICUCreateVehiculo CUCreateVehiculo { get; set; }
        public ICUGetAllTipoVehiculo CUGetAllTipoVehiculo { get; set; }
        public ICUGetAllAseguradora CUGetAllAseguradora { get; set; }
        public ICUGetAllUsuario CUGetAllUsuario { get; set; }
        public ICUGetAllCliente CUGetAllCliente { get; set; }
        public ICUGetByIdTipoVehiculo CUGetByIdTipoVehiculo { get; set;}
        public ICUGetByIdAseguradora CUGetByIdAseguradora { get; set;}
        public ICUGetByIdCliente CUGetByIdCliente { get; set; }
        public ICUCreateAuditoria CUCreateAuditoria { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public VehiculoController(IRepositorioVehiculos repositorioVehiculos, 
            ICUGetAllVehiculo cUGetAllVehiculo,
            ICUGetAllTipoVehiculo cUGetAllTipoVehiculo,
            ICUGetAllAseguradora cUGetAllAseguradora,
            ICUGetAllUsuario cUGetAllUsuario,
            ICUGetAllCliente cUGetAllCliente,
            IWebHostEnvironment webHostEnvironment,
            ICUCreateVehiculo cUCreateVehiculo,
            ICUGetByIdTipoVehiculo cUGetByIdTipoVehiculo,
            ICUGetByIdAseguradora cUGetByIdAseguradora,
            ICUGetByIdCliente cUGetByIdCliente,
            ICUCreateAuditoria cUCreateAuditoria)
        {
            RepositorioVehiculos = repositorioVehiculos;
            CUGetAllVehiculo = cUGetAllVehiculo;
            CUGetAllTipoVehiculo = cUGetAllTipoVehiculo;
            CUGetAllAseguradora = cUGetAllAseguradora;
            CUGetAllUsuario = cUGetAllUsuario;
            CUGetAllCliente = cUGetAllCliente;
            WebHostEnvironment = webHostEnvironment;
            CUCreateVehiculo = cUCreateVehiculo;
            CUGetByIdTipoVehiculo = cUGetByIdTipoVehiculo;
            CUGetByIdAseguradora = cUGetByIdAseguradora;
            CUGetByIdCliente = cUGetByIdCliente;
            CUCreateAuditoria = cUCreateAuditoria;
        }

        // GET: VehiculoController
        public ActionResult Index()
        {
            IEnumerable<Vehiculo> listaVehiculos = CUGetAllVehiculo.GetAllVehiculo();
            List<VehiculoViewModel> listaVehiculoViewModel = new List<VehiculoViewModel>();
            foreach(var vehiculo in listaVehiculos)
            {
                VehiculoViewModel vehiculoViewModel = new VehiculoViewModel()
                {
                    Id = vehiculo.Id,
                    Matricula = vehiculo.Matricula,
                    IdMotor = vehiculo.IdMotor,
                    Anio = vehiculo.Anio,
                    Color = vehiculo.Color,
                    TipoVehiculoId = vehiculo.Tipo.Id,
                    TipoVehiculos = CUGetAllTipoVehiculo.GetAllTipoVehiculo().Select(x => new TipoVehiculoViewModel()
                    {
                        Id = x.Id,
                        Marca= x.Marca,
                        Modelo = x.Modelo,
                    }),
                    AseguradoraId = vehiculo.Seguro.Id,
                    Aseguradoras = CUGetAllAseguradora.GetAllAseguradora().Select(a=> new AseguradoraViewModel()
                    {
                        Id= a.Id,
                        Nombre= a.Nombre
                    }),
                    Imagen = vehiculo.Imagen,
                    UsuarioId = vehiculo.Cliente.Id,
                    Usuarios = CUGetAllUsuario.GetAllUsuarios().Select(c=>new UsuarioViewModel()
                    {
                        Id= c.Id,
                        Cedula= c.Cedula
                    })
                };
                listaVehiculoViewModel.Add(vehiculoViewModel);
            }
            return View(listaVehiculoViewModel);
        }

        // GET: VehiculoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehiculoController/Create
        public ActionResult Create()
        {
            VehiculoViewModel vehiculoViewModel = new VehiculoViewModel();
            vehiculoViewModel.TipoVehiculos = CUGetAllTipoVehiculo.GetAllTipoVehiculo().Select(t => new TipoVehiculoViewModel()
            {
                Id = t.Id,
                Marca = t.Marca
            }).ToList();
            vehiculoViewModel.Aseguradoras = CUGetAllAseguradora.GetAllAseguradora().Select(a => new AseguradoraViewModel()
            {
                Id = a.Id,
                Nombre = a.Nombre
            }).ToList();
            vehiculoViewModel.Usuarios = CUGetAllUsuario.GetAllUsuarios().Select(u => new UsuarioViewModel()
            {
                Id = u.Id,
                Cedula = u.Cedula,
                RolId = u.Rol.Id
            }).ToList();

            return View(vehiculoViewModel);
        }

        // POST: VehiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehiculoViewModel vehiculoViewModel, string operacion)
        {
            VehiculoViewModel vehiculoVM = new VehiculoViewModel();
            vehiculoVM.TipoVehiculos = CUGetAllTipoVehiculo.GetAllTipoVehiculo().Select(t => new TipoVehiculoViewModel()
            {
                Id = t.Id,
                Marca = t.Marca
            }).ToList();
            vehiculoVM.Aseguradoras = CUGetAllAseguradora.GetAllAseguradora().Select(a => new AseguradoraViewModel()
            {
                Id = a.Id,
                Nombre = a.Nombre
            }).ToList();
            vehiculoVM.Usuarios = CUGetAllUsuario.GetAllUsuarios().Select(u => new UsuarioViewModel()
            {
                Id = u.Id,
                Cedula = u.Cedula,
                RolId = u.Rol.Id
            }).ToList();
            if (vehiculoViewModel == null)
            {
                return View(vehiculoVM);
            }
            try
            {
                string archivo = vehiculoViewModel.ImagenFile.FileName;
                string ruta = WebHostEnvironment.WebRootPath;
                string rutaDirectorio = Path.Combine(ruta, "img/vehiculos");
                string rutaArchivo = Path.Combine(rutaDirectorio, archivo);
                FileStream stream = new FileStream(rutaArchivo, FileMode.Create);
                vehiculoViewModel.ImagenFile.CopyTo(stream);

                TipoVehiculo tipoVehiculo = new TipoVehiculo();
                tipoVehiculo = CUGetByIdTipoVehiculo.GetByIdVehiculo(vehiculoViewModel.TipoVehiculoId);
                Aseguradora aseguradora = new Aseguradora();
                aseguradora = CUGetByIdAseguradora.GetByIdAseguradora(vehiculoViewModel.AseguradoraId);
                Cliente cliente = new Cliente();
                cliente = CUGetByIdCliente.GetByIdCliente(vehiculoViewModel.UsuarioId);

                Vehiculo vehiculo = new Vehiculo()
                {
                    Matricula = vehiculoViewModel.Matricula,
                    IdMotor = vehiculoViewModel.IdMotor,
                    Anio = vehiculoViewModel.Anio,
                    Color = vehiculoViewModel.Color,
                    Tipo = tipoVehiculo,
                    Seguro = aseguradora,
                    Imagen = archivo,
                    Cliente = cliente
                };
                CUCreateVehiculo.CreateVehiculo(vehiculo);
                Auditoria auditoria = new Auditoria()
                {
                    Cedula = HttpContext.Session.GetString("cedula"),
                    NombreUsuario = HttpContext.Session.GetString("nombre"),
                    ApellidoUsuario = HttpContext.Session.GetString("apellido"),
                    FechaHora = DateTime.Now,
                    IdEntidad = vehiculo.Id,
                    TipoEntidad = vehiculo.GetType().Name.ToString(),
                    Operacion = operacion
                };
                CUCreateAuditoria.CreateAuditoria(auditoria);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
