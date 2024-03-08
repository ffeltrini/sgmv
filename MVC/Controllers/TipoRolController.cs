using LogicaAplicacion.CasosDeUso.CUTipoRol;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class TipoRolController : Controller
    {
        public ICUGetAllTipoRol CUGetAllTipoRol { get; set; }
        public ICUCreateTipoRol CUCreateTipoRol { get; set; }
        public TipoRolController(ICUGetAllTipoRol cUGetAllTipoRol,ICUCreateTipoRol cUCreateTipoRol) 
        {
            CUGetAllTipoRol= cUGetAllTipoRol;
            CUCreateTipoRol= cUCreateTipoRol;
        }        
        public ActionResult Index()
        {
            IEnumerable<TipoRol> listaTipoRoles = CUGetAllTipoRol.GetAllTipoRol();
            List<TipoRolViewModel> listaTipoRolViewModel = new List<TipoRolViewModel>();
            foreach(var tipoRol in listaTipoRoles)
            {
                TipoRolViewModel tipoRolViewModel = new TipoRolViewModel()
                {
                    Id = tipoRol.Id,
                    Rol = tipoRol.Rol
                };
                listaTipoRolViewModel.Add(tipoRolViewModel);
            }
            return View(listaTipoRolViewModel);
        }

        // GET: TipoRolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoRolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoRolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoRolViewModel tipoRolViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TipoRol tipoRol = new TipoRol()
                    {
                        Rol = tipoRolViewModel.Rol
                    };
                    CUCreateTipoRol.CreateTipoRol(tipoRol);
                    return RedirectToAction(nameof(Index));
                }
                catch(TipoRolException ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(tipoRolViewModel);
                }
                catch(Exception ex)
                {
                    return View(tipoRolViewModel);
                }
            }
            return View(tipoRolViewModel);
        }

        // GET: TipoRolController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoRolController/Edit/5
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

        // GET: TipoRolController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoRolController/Delete/5
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
