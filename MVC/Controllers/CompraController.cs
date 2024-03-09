using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosDeUso.CUCompra;
using LogicaAplicacion.CasosDeUso.CUProveedor;
using LogicaAplicacion.CasosDeUso.CURepuesto;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVC.Models;

namespace MVC.Controllers
{
    public class CompraController : Controller
    {
        public ICUGetAllCompra CUGetAllCompra { get; set; }
        public ICUCreateCompra CUCreateCompra { get; set; }
        public ICUUpdateRepuesto CUUpdateRepuesto { get; set; }
        public ICUGetAllProveedor CUGetAllProveedor { get; set; }
        public ICUGetAllRepuesto CUGetAllRepuesto { get; set; }
        public ICUGetByIdRepuesto CUGetByIdRepuesto { get; set; }
        public ICUGetByIdProveedor CUGetByIdProveedor { get; set; }
        public ICUUpdateCompra CUUpdateCompra { get; set; }
        public ICUGetByAmountCompra CUGetByAmountCompra { get; set; }
        public ICUGetByIdCompra CUGetByIdCompra { get; set; }
        public CompraController(ICUGetAllCompra cUGetAllCompra, 
            ICUCreateCompra cUCreateCompra,
            ICUGetAllProveedor cUGetAllProveedor,
            ICUGetAllRepuesto cUGetAllRepuesto,
            ICUGetByIdProveedor cUGetByIdProveedor,
            ICUUpdateCompra cUUpdateCompra,
            ICUGetByAmountCompra cUGetByAmountCompra,
            ICUGetByIdRepuesto cUGetByIdRepuesto,
            ICUUpdateRepuesto cUUpdateRepuesto,
            ICUGetByIdCompra cUGetByIdCompra)
        {
            CUGetAllCompra = cUGetAllCompra;
            CUCreateCompra = cUCreateCompra;
            CUGetAllProveedor = cUGetAllProveedor;
            CUGetAllRepuesto = cUGetAllRepuesto;
            CUGetByIdProveedor = cUGetByIdProveedor;
            CUUpdateCompra = cUUpdateCompra;
            CUGetByAmountCompra = cUGetByAmountCompra;
            CUGetByIdRepuesto = cUGetByIdRepuesto;
            CUUpdateRepuesto = cUUpdateRepuesto;
            CUGetByIdCompra = cUGetByIdCompra;
        }

        // GET: CompraController
        public ActionResult Index()
        {
            List<CompraViewModel> listaComprasViewModel= new List<CompraViewModel>();
            IEnumerable<Compra> listaCompras = CUGetAllCompra.GetAllCompra();
            foreach(var compra in listaCompras)
            {
                CompraViewModel compraViewModel = new CompraViewModel()
                {
                    Id = compra.Id,
                    Fecha = compra.Fecha,
                    ProveedorId = compra.Proveedor.Id,
                    Proveedores = CUGetAllProveedor.GetAllProveedor().Select(p => new ProveedorViewModel()
                    {
                        Id = p.Id,
                        Nombre = p.Nombre.Valor,
                        FechaInicio = p.FechaInicio,
                        Nacional = p.Nacional
                    }),
                    Responsable = compra.Responsable,
                    Recibida = compra.Recibida,
                    FechaRecepcion=compra.FechaRecepcion
                };
                if (!compraViewModel.Recibida)
                {
                    TimeSpan difDias = DateTime.Now - compraViewModel.Fecha;
                    int dias = difDias.Days;
                    compraViewModel.DiasDemora = dias;
                }
                else
                {
                    compraViewModel.DiasDemora = compra.DiasDemora;
                }


                //
                compraViewModel.Repuestos = compra.ListaCompraRepuesto
                .Select(cr => new RepuestoViewModel
                {
                    Id = cr.Repuesto.Id,
                    Nombre = cr.Repuesto.Nombre
                }).ToList();
                //
                // Populate ListaCompraRepuesto
                compraViewModel.ListaCompraRepuesto = compra.ListaCompraRepuesto
                    .Select(cr => new CompraRepuestoViewModel
                    {
                        Id = cr.Id,
                        Repuesto = cr.Repuesto,
                        Precio = cr.Precio,
                        Cantidad = cr.Cantidad
                        // Add any additional properties from CompraRepuesto if needed
                    }).ToList();

                listaComprasViewModel.Add(compraViewModel);
            }
            return View(listaComprasViewModel);
        }

        // GET: CompraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompraController/Create
        public ActionResult Create()
        {
            CompraViewModel compraViewModel = new CompraViewModel();
            compraViewModel.Proveedores = CUGetAllProveedor.GetAllProveedor().Select(p => new ProveedorViewModel()
            {
                Id= p.Id,
                Nombre=p.Nombre.Valor,
                FechaInicio=p.FechaInicio,
                Nacional=p.Nacional
            });
            compraViewModel.Repuestos = CUGetAllRepuesto.GetAllRepuesto().Select(r => new RepuestoViewModel()
            {
                Id = r.Id,
                Nombre = r.Nombre
            });
            return View(compraViewModel);
        }

        // POST: CompraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompraViewModel compraViewModel)
        {
            if (compraViewModel.RepuestosId != null)
            {
                var distintosRepuestos = compraViewModel.RepuestosId.Distinct();
                if (distintosRepuestos.Count() != compraViewModel.RepuestosId.Count())
                {
                    ViewBag.Error = "No se pueden seleccionar repuestos duplicados.";
                    return View(compraViewModel);
                }
                CompraViewModel compraVM = new CompraViewModel();
                compraVM.Proveedores = CUGetAllProveedor.GetAllProveedor().Select(p => new ProveedorViewModel()
                {
                    Id = p.Id,
                    Nombre = p.Nombre.Valor,
                    FechaInicio = p.FechaInicio,
                    Nacional = p.Nacional
                });
                compraVM.Repuestos = CUGetAllRepuesto.GetAllRepuesto().Select(r => new RepuestoViewModel()
                {
                    Id = r.Id,
                    Nombre = r.Nombre
                });
                if (ModelState.IsValid)
                {
                    try
                    {
                        Proveedor proveedor = new Proveedor();
                        proveedor = CUGetByIdProveedor.GetByIdProveedor(compraViewModel.ProveedorId);

                        Compra compra = new Compra()
                        {
                            Fecha = compraViewModel.Fecha,
                            Proveedor = proveedor,
                            Responsable = HttpContext.Session.GetString("nombre")
                        };
                        CUCreateCompra.CreateCompra(compra);


                        List<CompraRepuesto> listaCompraRepuesto = new List<CompraRepuesto>();
                        for (int i = 0; i < compraViewModel.RepuestosId.Length; i++)
                        {
                            CompraRepuesto compraRepuesto = new CompraRepuesto
                            {
                                CompraId = compra.Id,
                                RepuestoId = compraViewModel.RepuestosId[i],
                                Precio = compraViewModel.Precio[i],
                                Cantidad = compraViewModel.Cantidad[i]
                            };
                            listaCompraRepuesto.Add(compraRepuesto);
                        }
                        compra.ListaCompraRepuesto = listaCompraRepuesto;

                        CUUpdateCompra.UpdateCompra(compra);

                        return RedirectToAction(nameof(Index));
                    }
                    catch (CompraException ex)
                    {
                        ViewBag.Error = ex.Message;
                        return View(compraViewModel);
                    }
                    catch (Exception ex)
                    {
                        return View(compraViewModel);
                    }
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Cada compra debe tener asociados al menos un repuesto";
            }
            
            return View(compraViewModel);
        }

        // GET: CompraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompraController/Edit/5
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

        // GET: CompraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompraController/Delete/5
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

        public ActionResult FiltrarComprasPorMonto()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FiltrarComprasPorMonto(decimal monto1,decimal monto2)
        {
    
            if(monto1<0 || monto2 < 0)
            {
                ViewBag.Error = "monto1 y monto2 deben ser mayor o igual a cero";
                return View();
            }
            if (monto1 >= monto2)
            {
                ViewBag.Error = "monto1 debe ser menor que monto2";
                return View();
            }

            IEnumerable<Compra> listaCompras = CUGetByAmountCompra.ComprasPorMonto(monto1,monto2);
            List<CompraViewModel> listaComprasViewModel = new List<CompraViewModel>();
            foreach (var compra in listaCompras)
            {
                CompraViewModel compraViewModel = new CompraViewModel()
                {
                    Id = compra.Id,
                    Fecha = compra.Fecha,
                    ProveedorId = compra.Proveedor.Id,
                    Proveedores = CUGetAllProveedor.GetAllProveedor().Select(p => new ProveedorViewModel()
                    {
                        Id = p.Id,
                        Nombre = p.Nombre.Valor,
                        FechaInicio = p.FechaInicio,
                        Nacional = p.Nacional
                    }),
                    Responsable = compra.Responsable,
                    Recibida = compra.Recibida,
                    FechaRecepcion=compra.FechaRecepcion
                };

                //
                compraViewModel.Repuestos = compra.ListaCompraRepuesto
                .Select(cr => new RepuestoViewModel
                {
                    Id = cr.Repuesto.Id,
                    Nombre = cr.Repuesto.Nombre
                }).ToList();
                //
                // Populate ListaCompraRepuesto
                compraViewModel.ListaCompraRepuesto = compra.ListaCompraRepuesto
                    .Select(cr => new CompraRepuestoViewModel
                    {
                        Id = cr.Id,
                        Repuesto = cr.Repuesto,
                        Precio = cr.Precio,
                        Cantidad = cr.Cantidad
                    }).ToList();

                listaComprasViewModel.Add(compraViewModel);
            }
            return View("Index",listaComprasViewModel);
        }

        [HttpPost]
        public ActionResult CompraRecibida(int id)
        {
            try
            {
                var compra = CUGetByIdCompra.GetByIdCompra(id);
                if (compra != null && !compra.Recibida)
                {
                    compra.Recibida = true;
                    compra.FechaRecepcion = DateTime.Now;
                    TimeSpan difDias = compra.FechaRecepcion - compra.Fecha;
                    int dias = difDias.Days;
                    compra.DiasDemora = dias;
                    CUUpdateCompra.UpdateCompra(compra);
                    foreach (var repuesto in compra.ListaCompraRepuesto)
                    {
                        repuesto.Repuesto.Stock += repuesto.Cantidad;
                        CUUpdateRepuesto.UpdateRepuesto(repuesto.Repuesto);
                    }
                }
                return Json(new { success = true, message = "Compra recibida successfully.", data = compra });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while processing compra.", error = ex.Message });
            }
        }
    }
}
