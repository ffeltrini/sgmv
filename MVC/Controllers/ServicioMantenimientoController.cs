using LogicaAplicacion.CasosDeUso.CUServicioMantenimiento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ServicioMantenimientoController : Controller
    {
        public ICUGetAllServicioMantenimiento CUGetAllServicioMantenimiento { get; set; }
        public ServicioMantenimientoController(ICUGetAllServicioMantenimiento cUGetAllServicioMantenimiento)
        {
            CUGetAllServicioMantenimiento = cUGetAllServicioMantenimiento;
        }
        // GET: ServicioMantenimientoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServicioMantenimientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicioMantenimientoController/Create
        public ActionResult Create()
        {
            ServicioMantenimientoViewModel servicioMantenimientoViewModel = new ServicioMantenimientoViewModel();

            return View();
        }

        // POST: ServicioMantenimientoController/Create
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

        // GET: ServicioMantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicioMantenimientoController/Edit/5
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

        // GET: ServicioMantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicioMantenimientoController/Delete/5
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
