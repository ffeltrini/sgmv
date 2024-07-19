﻿using LogicaAplicacion.CasosDeUso.CUAuditoria;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AuditoriaController : Controller
    {
        public ICUGetAllAuditoria CUGetAllAuditoria { get; set; }
        public ICUCreateAuditoria CUCreateAuditoria { get; set; }
        public AuditoriaController(ICUGetAllAuditoria cUGetAllAuditoria, ICUCreateAuditoria cUCreateAuditoria)
        {
            CUGetAllAuditoria = cUGetAllAuditoria;
            CUCreateAuditoria = cUCreateAuditoria;
        }

        // GET: AuditoriaController
        public ActionResult Index()
        {
            IEnumerable<Auditoria> listaAuditorias = CUGetAllAuditoria.GetAllAuditoria();
            List<AuditoriaViewModel> listaAuditoriaViewModel = new List<AuditoriaViewModel>();
            foreach(var auditoria in listaAuditorias)
            {
                AuditoriaViewModel auditoriaViewModel = new AuditoriaViewModel()
                {
                    Id = auditoria.Id,
                    Cedula= auditoria.Cedula,
                    NombreUsuario = auditoria.NombreUsuario,
                    ApellidoUsuario= auditoria.ApellidoUsuario,
                    FechaHora = auditoria.FechaHora,
                    IdEntidad = auditoria.IdEntidad,
                    TipoEntidad = auditoria.TipoEntidad,
                    Operacion = auditoria.Operacion
                };
                listaAuditoriaViewModel.Add(auditoriaViewModel);
            }
            return View(listaAuditoriaViewModel);
        }

        // GET: AuditoriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuditoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuditoriaController/Create
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

        // GET: AuditoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuditoriaController/Edit/5
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

        // GET: AuditoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuditoriaController/Delete/5
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
