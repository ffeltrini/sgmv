using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class PosicionController : Controller
    {
        // GET: PosicionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PosicionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PosicionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PosicionController/Create
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

        // GET: PosicionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PosicionController/Edit/5
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

        // GET: PosicionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PosicionController/Delete/5
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
