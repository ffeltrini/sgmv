using LogicaAccesoDatos.Interfaces;
using LogicaAplicacion.CasosDeUso.CUAseguradora;
using LogicaAplicacion.CasosDeUso.CUTipoVehiculo;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.CasosDeUso.CUVehiculo;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class VehiculoController : Controller
    {
        public IRepositorioVehiculos RepositorioVehiculos { get; set; }
        public ICUGetAllVehiculo CUGetAllVehiculo { get; set; }
        public ICUGetAllTipoVehiculo CUGetAllTipoVehiculo { get; set; }
        public ICUGetAllAseguradora CUGetAllAseguradora { get; set; }
        public ICUGetAllUsuario CUGetAllUsuario { get; set; }
        public VehiculoController(IRepositorioVehiculos repositorioVehiculos, 
            ICUGetAllVehiculo cUGetAllVehiculo,
            ICUGetAllTipoVehiculo cUGetAllTipoVehiculo,
            ICUGetAllAseguradora cUGetAllAseguradora,
            ICUGetAllUsuario cUGetAllUsuario)
        {
            RepositorioVehiculos = repositorioVehiculos;
            CUGetAllVehiculo = cUGetAllVehiculo;
            CUGetAllTipoVehiculo = cUGetAllTipoVehiculo;
            CUGetAllAseguradora= cUGetAllAseguradora;
            CUGetAllUsuario=cUGetAllUsuario;
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
                    Aseguradoras = CUGetAllAseguradora.GetAllAseguradora().Select(a=> new AseguradoraViewModel()
                    {
                        Id= a.Id,
                        Nombre= a.Nombre
                    }),
                    Clientes = CUGetAllUsuario.GetAllUsuarios().Select(c=>new UsuarioViewModel()
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
            return View();
        }

        // POST: VehiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
