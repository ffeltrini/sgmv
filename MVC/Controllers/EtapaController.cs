using LogicaAplicacion.CasosDeUso.CUAuditoria;
using LogicaAplicacion.CasosDeUso.CUEtapa;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class EtapaController : Controller
    {
        public ICUCreateEtapa CUCreateEtapa { get; set; }
        public ICUGetAllEtapa CUGetAllEtapa { get; set; }
        public ICUCreateAuditoria CUCreateAuditoria { get; set; }
        public EtapaController(ICUCreateEtapa cUCreateEtapa,
            ICUGetAllEtapa cUGetAllEtapa,
            ICUCreateAuditoria cUCreateAuditoria)
        {
            CUCreateEtapa = cUCreateEtapa;
            CUGetAllEtapa = cUGetAllEtapa;
            CUCreateAuditoria= cUCreateAuditoria;
        }

        // GET: EtapaController
        public ActionResult Index()
        {
            IEnumerable<Etapa> listaEtapas = CUGetAllEtapa.GetAllEtapa();
            List<EtapaViewModel> listaEtapaViewModel = new List<EtapaViewModel>();
            foreach(var etapa in listaEtapas)
            {
                EtapaViewModel etapaViewModel = new EtapaViewModel()
                {
                    Id = etapa.Id,
                    EtapaNombre = etapa.EtapaNombre
                };
                listaEtapaViewModel.Add(etapaViewModel);
            }
            return View(listaEtapaViewModel);
        }

        // GET: EtapaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EtapaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtapaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EtapaViewModel etapaViewModel, string operacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Etapa etapa = new Etapa()
                    {
                        EtapaNombre = etapaViewModel.EtapaNombre
                    };
                    CUCreateEtapa.CreateEtapa(etapa);
                    Auditoria auditoria = new Auditoria()
                    {
                        Cedula = HttpContext.Session.GetString("cedula"),
                        NombreUsuario = HttpContext.Session.GetString("nombre"),
                        ApellidoUsuario = HttpContext.Session.GetString("apellido"),
                        FechaHora = DateTime.Now,
                        IdEntidad = etapa.Id,
                        TipoEntidad = etapa.GetType().Name.ToString(),
                        Operacion = operacion
                    };
                    CUCreateAuditoria.CreateAuditoria(auditoria);
                    return RedirectToAction(nameof(Index));
                }
                catch(EtapaException ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(etapaViewModel);
                }
                catch(Exception ex)
                {
                    return View(etapaViewModel);
                }
            }
            return View(etapaViewModel);
        }

        // GET: EtapaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EtapaController/Edit/5
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

        // GET: EtapaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EtapaController/Delete/5
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
