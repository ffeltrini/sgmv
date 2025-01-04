using LogicaAplicacion.CasosDeUso.CUEtapa;
using LogicaAplicacion.CasosDeUso.CUMantenimiento;
using LogicaAplicacion.CasosDeUso.CURepuesto;
using LogicaAplicacion.CasosDeUso.CUServicio;
using LogicaAplicacion.CasosDeUso.CUServicioMantenimiento;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVC.Models;

namespace MVC.Controllers
{
    public class ServicioMantenimientoController : Controller
    {
        public ICUGetAllServicioMantenimiento CUGetAllServicioMantenimiento { get; set; }
        public ICUGetAllRepuesto CUGetAllRepuesto { get; set; }
        public ICUGetAllEtapa CUGetAllEtapa { get; set; }
        public ICUGetByIdEtapa CUGetByIdEtapa { get; set; }
        public ICUCreateServicioMantenimiento CUCreateServicioMantenimiento { get; set; }
        public ICUUpdateServicioMantenimiento CUUpdateServicioMantenimiento { get; set; }

        public ServicioMantenimientoController(ICUGetAllServicioMantenimiento cUGetAllServicioMantenimiento,
            ICUGetAllRepuesto cUGetAllRepuesto,
            ICUGetAllEtapa cUGetAllEtapa,
            ICUGetByIdEtapa cUGetByIdEtapa,
            ICUCreateServicioMantenimiento cUCreateServicioMantenimiento,
            ICUUpdateServicioMantenimiento cUUpdateServicioMantenimiento)
        {
            CUGetAllServicioMantenimiento = cUGetAllServicioMantenimiento;
            CUGetAllRepuesto = cUGetAllRepuesto;
            CUGetAllEtapa = cUGetAllEtapa;
            CUGetByIdEtapa = cUGetByIdEtapa;
            CUCreateServicioMantenimiento = cUCreateServicioMantenimiento;  
            CUUpdateServicioMantenimiento = cUUpdateServicioMantenimiento ;
        }
        // GET: ServicioMantenimientoController
        public ActionResult Index()
        {
            List<ServicioMantenimientoViewModel> listaServicioMantenimientoViewModel = new List<ServicioMantenimientoViewModel>();
            IEnumerable<ServicioMantenimiento> listaServicioMantenimientos = CUGetAllServicioMantenimiento.GetAllServicioMantenimiento();
            foreach(var servicioMantenimiento in listaServicioMantenimientos)
            {
                ServicioMantenimientoViewModel servicioMantenimientoViewModel = new ServicioMantenimientoViewModel()
                {
                    Id =servicioMantenimiento.Id,
                    ServicioId=servicioMantenimiento.ServicioId,


                };
            }
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
            servicioMantenimientoViewModel.Repuestos = CUGetAllRepuesto.GetAllRepuesto().Select(r => new RepuestoViewModel()
            {
                Id = r.Id,
                Codigo = r.Codigo,
                Nombre = r.Nombre
            });
            servicioMantenimientoViewModel.Etapas = CUGetAllEtapa.GetAllEtapa().Select(e => new EtapaViewModel()
            {
                Id = e.Id,
                EtapaNombre = e.EtapaNombre
            }).ToList();


            return View(servicioMantenimientoViewModel);
        }

        // POST: ServicioMantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicioMantenimientoViewModel servicioMantenimientoViewModel)
        {
            if (servicioMantenimientoViewModel.RepuestosId != null)
            {
                var distintosRepuestos = servicioMantenimientoViewModel.RepuestosId.Distinct();
                if (distintosRepuestos.Count() != servicioMantenimientoViewModel.RepuestosId.Length)
                {
                    ViewBag.Error = "No se pueden seleccionar repuestos duplicados.";
                    return View(servicioMantenimientoViewModel);
                }
                ServicioMantenimientoViewModel servicioMantenimientoVM = new ServicioMantenimientoViewModel();
                servicioMantenimientoVM.Etapas = CUGetAllEtapa.GetAllEtapa().Select(e => new EtapaViewModel()
                {
                    Id = e.Id,
                    EtapaNombre = e.EtapaNombre
                });

                if (ModelState.IsValid)
                {
                    try
                    {
                        Etapa etapa = CUGetByIdEtapa.GetByIdEtapa(servicioMantenimientoViewModel.EtapaId);
                        if(etapa == null)
                        {
                            ViewBag.Error = "Etapa no encontrado.";
                            return View(servicioMantenimientoViewModel);
                        }

                        ServicioMantenimiento servicioMantenimiento = new ServicioMantenimiento()
                        {
                            Inicio = servicioMantenimientoViewModel.Inicio,
                            Fin = servicioMantenimientoViewModel.Fin,
                            Etapa = etapa,
                            Observaciones = servicioMantenimientoViewModel.Observaciones,

                        };
                        CUCreateServicioMantenimiento.CreateServicioMantenimiento(servicioMantenimiento);

                        List<RepuestoUtilizado> listaRepuestoUtilizado = new List<RepuestoUtilizado>();
                        for (int i = 0; i < servicioMantenimientoViewModel.RepuestosId.Length; i++)
                        {
                            RepuestoUtilizado repuestoUtilizado = new RepuestoUtilizado
                            {
                                //ServicioMantenimientoId = servicioMantenimiento.Id,
                                RepuestoId = servicioMantenimientoViewModel.RepuestosId[i],
                                Fecha = servicioMantenimientoViewModel.Fecha[i],
                                Cantidad = servicioMantenimientoViewModel.Cantidad[i]
                            };
                            listaRepuestoUtilizado.Add(repuestoUtilizado);
                        }

                        servicioMantenimiento.ListaRepuestosUtilizados = listaRepuestoUtilizado;
                        CUUpdateServicioMantenimiento.UpdateServicioMantenimiento(servicioMantenimiento);

                        return RedirectToAction(nameof(Index));
                    }
                    catch (ServicioMantenimientoException ex)
                    {
                        ViewBag.Error = ex.Message;
                        return View(servicioMantenimientoViewModel);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = ex.Message;
                        return View(servicioMantenimientoViewModel);
                    }
                }
            }
            else
            {
                ViewBag.Error = "Cada servicio/Mantenimiento debe tener asociados al menos un repuesto";
            }
            return View(servicioMantenimientoViewModel);
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
