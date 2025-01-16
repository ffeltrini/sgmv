using LogicaAplicacion.CasosDeUso.CUCompra;
using LogicaAplicacion.CasosDeUso.CUEtapa;
using LogicaAplicacion.CasosDeUso.CUMantenimiento;
using LogicaAplicacion.CasosDeUso.CURepuesto;
using LogicaAplicacion.CasosDeUso.CURepuestoUtilizado;
using LogicaAplicacion.CasosDeUso.CUServicio;
using LogicaAplicacion.CasosDeUso.CUServicioMantenimiento;
using LogicaAplicacion.CasosDeUso.CUTipoVehiculo;
using LogicaAplicacion.CasosDeUso.CUVehiculo;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class ServicioController : Controller
    {
        public ICUGetAllServicio CUGetAllServicio { get; set; }
        public ICUGetAllVehiculo CUGetAllVehiculo { get; set; }
        public ICUGetAllTipoVehiculo CUGetAllTipoVehiculo { get; set; }
        public ICUGetAllMantenimiento CUGetAllMantenimiento { get; set; }
        public ICUGetByIdVehiculo CUGetByIdVehiculo { get; set;}
        public ICUCreateServicio CUCreateServicio { get; set; }
        public ICUUpdateServicio CUUpdateServicio { get; set; }
        public ICUGetByIdServicio CUGetByIdServicio { get; set; }
        public ICUGetAllEtapa CUGetAllEtapa { get; set; }
        public ICUGetAllRepuesto CUGetAllRepuesto { get; set; }
        public ICUGetByIdRepuesto CUGetByIdRepuesto { get; set; }
        public ICUCreateRepuestoUtilizado CUCreateRepuestoUtilizado { get; set; }
        public ICUCreateServicioMantenimiento CUCreateServicioMantenimiento { get; set;}

        public ServicioController(ICUGetAllServicio cUGetAllServicio,
            ICUGetAllVehiculo cUGetAllVehiculo,
            ICUGetAllTipoVehiculo cUGetAllTipoVehiculo,
            ICUGetAllMantenimiento cUGetAllMantenimiento,
            ICUGetByIdVehiculo cUGetByIdVehiculo,
            ICUCreateServicio cUCreateServicio,
            ICUUpdateServicio cUUpdateServicio,
            ICUGetByIdServicio cUGetByIdServicio,
            ICUGetAllEtapa cUGetAllEtapa,
            ICUGetAllRepuesto cUGetAllRepuesto,
            ICUGetByIdRepuesto cUGetByIdRepuesto,
            ICUCreateRepuestoUtilizado cUCreateRepuestoUtilizado,
            ICUCreateServicioMantenimiento cUCreateServicioMantenimiento)
        {
            CUGetAllServicio = cUGetAllServicio;
            CUGetAllVehiculo = cUGetAllVehiculo;
            CUGetAllTipoVehiculo = cUGetAllTipoVehiculo;
            CUGetAllMantenimiento = cUGetAllMantenimiento;
            CUGetByIdVehiculo = cUGetByIdVehiculo;
            CUCreateServicio = cUCreateServicio;
            CUUpdateServicio = cUUpdateServicio;
            CUGetByIdServicio = cUGetByIdServicio;
            CUGetAllEtapa = cUGetAllEtapa;
            CUGetAllRepuesto = cUGetAllRepuesto;
            CUGetByIdRepuesto = cUGetByIdRepuesto;  
            CUCreateRepuestoUtilizado= cUCreateRepuestoUtilizado;
            CUCreateServicioMantenimiento = cUCreateServicioMantenimiento;
        }

        // GET: ServicioController
        public ActionResult Index()
        {
            List<ServicioViewModel> listaServicioViewModel = new List<ServicioViewModel>();
            IEnumerable<Servicio> listaServicios = CUGetAllServicio.GetAllServicio();
            foreach(var servicio in listaServicios)
            {
                ServicioViewModel servicioViewModel = new ServicioViewModel()
                {
                    Id = servicio.Id,
                    Fecha = servicio.Fecha,
                    VehiculoId = servicio.Vehiculo.Id,
                    Vehiculos = CUGetAllVehiculo.GetAllVehiculo().Select(v => new VehiculoViewModel()
                    {
                        Id = v.Id,
                        Matricula = v.Matricula,
                        IdMotor = v.IdMotor,
                        TipoVehiculoId = v.Tipo.Id,
                        TipoVehiculos = CUGetAllTipoVehiculo.GetAllTipoVehiculo().Select(t => new TipoVehiculoViewModel()
                        {
                            Id = t.Id,
                            Marca = t.Marca,
                            Modelo = t.Modelo
                        }),
                        Anio = v.Anio,
                        Color = v.Color
                    }),
                    Km = servicio.Km,
                    Siniestro = servicio.Siniestro,
                    ProximoServicio = servicio.ProximoServicio
                };
                servicioViewModel.Mantenimientos = servicio.ListaServicioMantenimiento
                    .Select(sm => new MantenimientoViewModel
                    {
                        Id = sm.Id,
                        Tarea = sm.Mantenimiento.Tarea
                    }).ToList();
                
                servicioViewModel.ListaServicioMantenimiento = servicio.ListaServicioMantenimiento
                    .Select(sm => new ServicioMantenimientoViewModel
                    {
                        Id = sm.Id,
                        Mantenimiento = sm.Mantenimiento,
                        Inicio = sm.Inicio, 
                        Fin = sm.Fin,
                        Observaciones = sm.Observaciones
                    }).ToList();
                servicioViewModel.ListaRepuestosUtilizados = servicio.ListaRepuestosUtilizados.
                    Select(ru => new RepuestoUtilizadoViewModel
                    {
                        Id=ru.Id,
                        Fecha=ru.Fecha,
                        Repuesto=ru.Repuesto,
                        Cantidad=ru.Cantidad
                    }).ToList();
                listaServicioViewModel.Add(servicioViewModel);
            }
            return View(listaServicioViewModel);
        }

        // GET: ServicioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: ServicioController/Create
        public ActionResult Create()
        {
            ServicioViewModel servicioViewModel = new ServicioViewModel();
            servicioViewModel.Vehiculos = CUGetAllVehiculo.GetAllVehiculo().Select(v => new VehiculoViewModel()
            {
                Id = v.Id,
                Matricula = v.Matricula,
                IdMotor = v.IdMotor,
                TipoVehiculoId = v.Tipo.Id,
                TipoVehiculos = CUGetAllTipoVehiculo.GetAllTipoVehiculo().Select(t => new TipoVehiculoViewModel()
                {
                    Id = t.Id,
                    Marca = t.Marca,
                    Modelo = t.Modelo
                }),
                Anio = v.Anio,
                Color = v.Color

            });
            servicioViewModel.Mantenimientos = CUGetAllMantenimiento.GetAllMantenimiento().Select(m => new MantenimientoViewModel()
            {
                Id = m.Id,
                Tarea = m.Tarea
            });
            servicioViewModel.Etapas = CUGetAllEtapa.GetAllEtapa().Select(e => new EtapaViewModel()
            {
                Id = e.Id,
                EtapaNombre = e.EtapaNombre
            }).ToList();
            servicioViewModel.Repuestos = CUGetAllRepuesto.GetAllRepuesto().Select(r => new RepuestoViewModel
            {
                Id = r.Id,
                Codigo = r.Codigo,
                Nombre = r.Nombre
            }).ToList();

            return View(servicioViewModel);
        }

        // POST: ServicioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicioViewModel servicioViewModel)
        {
            if (servicioViewModel.MantenimientosId != null)
            {
                var distintosMantenimientos = servicioViewModel.MantenimientosId.Distinct();
                if (distintosMantenimientos.Count() != servicioViewModel.MantenimientosId.Length)
                {
                    ViewBag.Error = "No se pueden seleccionar mantenimientos duplicados.";
                    return View(servicioViewModel);
                }

                ServicioViewModel servicioVM = new ServicioViewModel();
                servicioVM.Vehiculos = CUGetAllVehiculo.GetAllVehiculo().Select(v => new VehiculoViewModel()
                {
                    Id = v.Id,
                    Matricula = v.Matricula,
                    IdMotor = v.IdMotor,
                    TipoVehiculoId = v.Tipo.Id,
                    TipoVehiculos = CUGetAllTipoVehiculo.GetAllTipoVehiculo().Select(t => new TipoVehiculoViewModel()
                    {
                        Id = t.Id,
                        Marca = t.Marca,
                        Modelo = t.Modelo
                    }),
                    Anio = v.Anio,
                    Color = v.Color

                });
                servicioVM.Mantenimientos = CUGetAllMantenimiento.GetAllMantenimiento().Select(m => new MantenimientoViewModel()
                {
                    Id = m.Id,
                    Tarea = m.Tarea
                });

                servicioVM.Repuestos = CUGetAllRepuesto.GetAllRepuesto().Select(r => new RepuestoViewModel()
                {
                    Id = r.Id,
                    Nombre = r.Nombre
                });

                if (!ModelState.IsValid)
                {
                    try
                    {
                        Vehiculo vehiculo = CUGetByIdVehiculo.GetByIdVehiculo(servicioViewModel.VehiculoId);
                        if (vehiculo == null)
                        {
                            ViewBag.Error = "Vehiculo no encontrado.";
                            return View(servicioViewModel);
                        }

                        Servicio servicio = new Servicio()
                        {
                            Fecha = servicioViewModel.Fecha,
                            Vehiculo = vehiculo,
                            Km = servicioViewModel.Km,
                            Siniestro = servicioViewModel.Siniestro,
                            ProximoServicio = servicioViewModel.ProximoServicio
                        };
                        CUCreateServicio.CreateServicio(servicio);
                        //ServicioMantenimiento servicioMantenimiento = new ServicioMantenimiento();
                        List<ServicioMantenimiento> listaServicioMantenimiento = new List<ServicioMantenimiento>();

                        for (int i = 0; i < servicioViewModel.MantenimientosId.Length; i++)
                        {
                            ServicioMantenimiento servicioMantenimiento = new ServicioMantenimiento
                            {
                                ServicioId = servicio.Id,
                                MantenimientoId = servicioViewModel.MantenimientosId[i],
                                Inicio = servicioViewModel.Inicio[i],
                                Fin = servicioViewModel.Fin[i],
                                EtapaId = servicioViewModel.EtapaId[i],
                                Observaciones = servicioViewModel.Observaciones[i]
                            };
                            CUCreateServicioMantenimiento.CreateServicioMantenimiento(servicioMantenimiento);

                            // Filtrar los repuestos utilizados para este mantenimiento específico
                            if (servicioViewModel.ListaRepuestosUtilizados != null)
                            {
                                List<RepuestoUtilizado> listaRepuestosUtilizados = new List<RepuestoUtilizado>();

                                // Filtrar solo los repuestos que pertenecen al mantenimiento actual
                                var repuestosParaEsteMantenimiento = servicioViewModel.ListaRepuestosUtilizados
                                    .Where(ru => ru.ServicioMantenimientoId == servicioMantenimiento.Id).ToList();




                                foreach (var repuestoUtilizadoVM in repuestosParaEsteMantenimiento)
                                {
                                    RepuestoUtilizado repuestoUtilizado = new RepuestoUtilizado()
                                    {
                                        RepuestoId = repuestoUtilizadoVM.RepuestoId,
                                        ServicioMantenimientoId = servicioMantenimiento.Id,  // Aquí se asigna al mantenimiento actual
                                        Cantidad = repuestoUtilizadoVM.Cantidad,
                                        Fecha = DateTime.Now,
                                    };

                                    listaRepuestosUtilizados.Add(repuestoUtilizado);
                                }

                                servicioMantenimiento.ListaRepuestosUtilizados = listaRepuestosUtilizados;
                            }
                            else
                            {
                                // Si no hay repuestos utilizados, asignar una lista vacía
                                servicioMantenimiento.ListaRepuestosUtilizados = new List<RepuestoUtilizado>();
                            }

                            listaServicioMantenimiento.Add(servicioMantenimiento);
                        }




                        servicio.ListaServicioMantenimiento = listaServicioMantenimiento;
                        CUUpdateServicio.UpdateServicio(servicio);

                        return RedirectToAction(nameof(Index));
                    }
                    catch (ServicioException ex)
                    {
                        ViewBag.Error = ex.Message;
                        return View(servicioViewModel);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = ex.Message;
                        return View(servicioViewModel);
                    }
                }
            }
            else
            {
                ViewBag.Error = "Cada servicio debe tener asociados al menos un mantenimiento";
            }
            servicioViewModel.Etapas = CUGetAllEtapa.GetAllEtapa().Select(e => new EtapaViewModel
            {
                Id = e.Id,
                EtapaNombre = e.EtapaNombre
            }).ToList();

            return View(servicioViewModel);
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
