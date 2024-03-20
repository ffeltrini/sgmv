using LogicaAplicacion.CasosDeUso.CUTipoMantenimiento;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class TipoMantenimientoController : Controller
    {
        public ICUCreateTipoMantenimiento CUCreateTipoMantenimiento { get; set; }
        public ICUGetAllTipoMantenimiento CUGetAllTipoMantenimiento { get; set; }
        public TipoMantenimientoController(ICUCreateTipoMantenimiento cUCreateTipoMantenimiento,
            ICUGetAllTipoMantenimiento cUGetAllTipoMantenimiento)
        {
            CUCreateTipoMantenimiento = cUCreateTipoMantenimiento;
            CUGetAllTipoMantenimiento = cUGetAllTipoMantenimiento;
        }

        // GET: TipoMantenimientoController
        public ActionResult Index()
        {
            IEnumerable<TipoMantenimiento> listaTipoMantenimientos = CUGetAllTipoMantenimiento.GetAllTipoMantenimiento();
            List<TipoMantenimientoViewModel> listaTipoMantenimientoViewModel = new List<TipoMantenimientoViewModel>();
            foreach(var tipoMantenimiento in listaTipoMantenimientos)
            {
                TipoMantenimientoViewModel tipoMantenimientoViewModel = new TipoMantenimientoViewModel()
                {
                    Id = tipoMantenimiento.Id,
                    Tipo = tipoMantenimiento.Tipo
                };
                listaTipoMantenimientoViewModel.Add(tipoMantenimientoViewModel);
            }
            return View(listaTipoMantenimientoViewModel);
        }

        // GET: TipoMantenimientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoMantenimientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoMantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoMantenimientoViewModel tipoMantenimientoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TipoMantenimiento tipoMantenimiento = new TipoMantenimiento()
                    {
                        Tipo=tipoMantenimientoViewModel.Tipo
                    };
                    CUCreateTipoMantenimiento.CreateTipoMantenimiento(tipoMantenimiento);
                    return RedirectToAction(nameof(Index));
                }
                catch(TipoMantenimientoException ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(tipoMantenimientoViewModel);
                }
                catch(Exception ex)
                {
                    return View(tipoMantenimientoViewModel);
                }
            }
            return View(tipoMantenimientoViewModel);
        }

        // GET: TipoMantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoMantenimientoController/Edit/5
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

        // GET: TipoMantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoMantenimientoController/Delete/5
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
