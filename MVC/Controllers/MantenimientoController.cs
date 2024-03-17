using LogicaAplicacion.CasosDeUso.CUAuditoria;
using LogicaAplicacion.CasosDeUso.CUMantenimiento;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class MantenimientoController : Controller
    {
        public ICUGetAllMantenimiento CUGetAllMantenimiento { get; set; }
        public ICUCreateMantenimiento CUCreateMantenimiento { get; set; }
        public ICUCreateAuditoria CUCreateAuditoria { get; set; }
        public MantenimientoController(ICUGetAllMantenimiento cUGetAllMantenimiento,
            ICUCreateMantenimiento cUCreateMantenimiento,
            ICUCreateAuditoria cUCreateAuditoria)
        {
            CUGetAllMantenimiento = cUGetAllMantenimiento;
            CUCreateMantenimiento = cUCreateMantenimiento;
            CUCreateAuditoria= cUCreateAuditoria;
        }
        // GET: MantenimientoController
        public ActionResult Index()
        {
            List<MantenimientoViewModel> listaMantenimientosViewModel = new List<MantenimientoViewModel>();
            IEnumerable<Mantenimiento> listaMantenimientos = CUGetAllMantenimiento.GetAllMantenimiento();
            foreach(var mantenimiento in listaMantenimientos)
            {
                MantenimientoViewModel mantenimientoViewModel = new MantenimientoViewModel()
                {
                    Id = mantenimiento.Id,
                    Tarea = mantenimiento.Tarea,
                    Descripcion = mantenimiento.Descripcion,
                    Duracion = mantenimiento.Duracion,
                    Frecuencia = mantenimiento.Frecuencia
                };
                listaMantenimientosViewModel.Add(mantenimientoViewModel);
            }
            return View(listaMantenimientosViewModel);
        }

        // GET: MantenimientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MantenimientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MantenimientoViewModel mantenimientoViewModel, string operacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Mantenimiento mantenimiento = new Mantenimiento()
                    {
                        Tarea = mantenimientoViewModel.Tarea,
                        Descripcion = mantenimientoViewModel.Descripcion,
                        Duracion = mantenimientoViewModel.Duracion,
                        Frecuencia = mantenimientoViewModel.Frecuencia
                    };
                    CUCreateMantenimiento.CreateMantenimiento(mantenimiento);
                    Auditoria auditoria = new Auditoria()
                    {
                        NombreUsuario = HttpContext.Session.GetString("nombre"),
                        FechaHora = DateTime.Now,
                        IdEntidad = mantenimiento.Id,
                        TipoEntidad = mantenimiento.GetType().Name.ToString(),
                        Operacion = operacion
                    };
                    CUCreateAuditoria.CreateAuditoria(auditoria);
                    return RedirectToAction(nameof(Index));
                }
                catch(MantenimientoException ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(mantenimientoViewModel);
                }
                catch(Exception ex)
                {
                    return View(mantenimientoViewModel);
                }
            }
            return View(mantenimientoViewModel);
        }

        // GET: MantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Edit/5
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

        // GET: MantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Delete/5
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
