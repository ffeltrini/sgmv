using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ServicioController : Controller
    {
        // GET: ServicioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServicioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicioController/Create
        public ActionResult Create()
        {
            //ServicioViewModel servicioViewModel = new ServicioViewModel();
            //servicioViewModel.Vehiculos
            return View();
        }

        // POST: ServicioController/Create
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

        // GET: ServicioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicioController/Edit/5
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

        // GET: ServicioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicioController/Delete/5
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
