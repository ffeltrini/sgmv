using Azure.Core;
using LogicaAplicacion.CasosDeUso.CUAuditoria;
using LogicaAplicacion.CasosDeUso.CUProveedor;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.ValueObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProveedorController : Controller
    {
        public ICUGetAllProveedor CUGetAllProveedor { get; set; }
        public ICUCreateProveedor CUCreateProveedor { get; set; }
        public ICUDeleteProveedor CUDeleteProveedor { get; set; }
        public ICUGetByIdProveedor CUGetByIdProveedor { get; set; }
        public ICUUpdateProveedor CUUpdateProveedor { set; get; }
        public ICUCreateAuditoria CUCreateAuditoria { get; set; }
        public ProveedorController(ICUGetAllProveedor cUGetAllProveedor, 
                                    ICUCreateProveedor cUCreateProveedor,
                                    ICUDeleteProveedor cUDeleteProveedor,
                                    ICUGetByIdProveedor cUGetByIdProveedor,
                                    ICUUpdateProveedor cUUpdateProveedor,
                                    ICUCreateAuditoria cUCreateAuditoria) 
        {
            CUGetAllProveedor= cUGetAllProveedor;
            CUCreateProveedor= cUCreateProveedor;
            CUDeleteProveedor = cUDeleteProveedor;
            CUGetByIdProveedor = cUGetByIdProveedor;
            CUUpdateProveedor = cUUpdateProveedor;
            CUCreateAuditoria= cUCreateAuditoria;
        }
        // GET: ProveedorController
        public ActionResult Index()
        {
            IEnumerable<Proveedor> listaProveedores = CUGetAllProveedor.GetAllProveedor();
            List<ProveedorViewModel> listaProveedoresViewModel = new List<ProveedorViewModel>();
            foreach(var proveedor in listaProveedores)
            {
                ProveedorViewModel proveedorViewModel = new ProveedorViewModel()
                {
                    Id = proveedor.Id,
                    Nombre = proveedor.Nombre.Valor,
                    FechaInicio = proveedor.FechaInicio,
                    Nacional = proveedor.Nacional
                };
                listaProveedoresViewModel.Add(proveedorViewModel);
            }
            return View(listaProveedoresViewModel);
        }

        // GET: ProveedorController/Details/5
        public ActionResult Details(int id)
        {
            var proveedor = CUGetByIdProveedor.GetByIdProveedor(id);
            ProveedorViewModel proveedorViewModel = new ProveedorViewModel()
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre.Valor,
                FechaInicio = proveedor.FechaInicio,
                Nacional = proveedor.Nacional
            };
            return View(proveedorViewModel);
        }

        // GET: ProveedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProveedorViewModel proveedorViewModel,string operacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    NombreProveedor nombreProveedor = new NombreProveedor(proveedorViewModel.Nombre);
                    Proveedor proveedor = new Proveedor()
                    {
                        Nombre = nombreProveedor,
                        FechaInicio = proveedorViewModel.FechaInicio,
                        Nacional = proveedorViewModel.Nacional
                    };
                    CUCreateProveedor.CreateProveedor(proveedor);
                    Auditoria auditoria = new Auditoria()
                    {
                        NombreUsuario = HttpContext.Session.GetString("nombre"),
                        FechaHora = DateTime.Now,
                        IdEntidad = proveedor.Id,
                        TipoEntidad = proveedor.GetType().Name.ToString(),
                        Operacion = operacion
                    };
                    CUCreateAuditoria.CreateAuditoria(auditoria);
                    return RedirectToAction(nameof(Index));
                }
                catch (ProveedorException ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(proveedorViewModel);
                }
                catch (Exception ex)
                {
                    return View(proveedorViewModel);
                }
            }
            return View(proveedorViewModel);
        }

        // GET: ProveedorController/Edit/5
        public ActionResult Edit(int id)
        {
            ProveedorViewModel proveedorViewModel = new ProveedorViewModel();
            try
            {
                ValidarDatosEntrada(id);
                Proveedor proveedor = CUGetByIdProveedor.GetByIdProveedor(id);
                if(proveedor != null)
                {
                    proveedorViewModel.Nombre = proveedor.Nombre.Valor;
                    proveedorViewModel.FechaInicio=proveedor.FechaInicio;
                    proveedorViewModel.Nacional = proveedor.Nacional;
                }
            }
            catch (ProveedorException ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(proveedorViewModel);
            }
            catch(Exception ex)
            {
                return View(proveedorViewModel);
            }
            return View(proveedorViewModel);
        }

        // POST: ProveedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProveedorViewModel proveedorViewModel)
        {
            try
            {
                ValidarDatosEntrada(id);
                NombreProveedor nombreProveedor = new NombreProveedor(proveedorViewModel.Nombre);
                Proveedor proveedor = new Proveedor()
                {
                    Id = proveedorViewModel.Id,
                    Nombre = nombreProveedor,
                    FechaInicio = proveedorViewModel.FechaInicio,
                    Nacional = proveedorViewModel.Nacional
                };
                CUUpdateProveedor.UpdateProveedor(proveedor);
                return RedirectToAction(nameof(Index));
            }
            catch(ProveedorException ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(proveedorViewModel);
            }
            catch(Exception ex)
            {
                ViewData["ErrorMessage"] = "Se produjo un error";
            }
            return View(proveedorViewModel);
        }

        // GET: ProveedorController/Delete/5
        public ActionResult Delete(int id)
        {
            ValidarDatosEntrada(id);
            ProveedorViewModel proveedorViewModel = new ProveedorViewModel();
            try
            {
                Proveedor? proveedor = CUGetByIdProveedor.GetByIdProveedor(id);
                if(proveedor != null)
                {
                    proveedorViewModel.Id= proveedor.Id;
                    proveedorViewModel.Nombre = proveedor.Nombre.Valor;
                    proveedorViewModel.FechaInicio = proveedor.FechaInicio;
                    proveedorViewModel.Nacional = proveedor.Nacional;
                }
            }
            catch (ProveedorException ex)
            {
                ViewData["ErrorMessage"]=ex.Message;
            }
            catch(Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return View(proveedorViewModel);
        }

        // POST: ProveedorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProveedorViewModel proveedorViewModel)
        {
            ValidarDatosEntrada(id);
            try
            {
                CUDeleteProveedor.DeleteProveedor(id);
                return RedirectToAction(nameof(Index));
            }
            catch(ProveedorException ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            catch(Exception ex)
            {
                ViewData["ErrorMesssage"] = "Los datos no son correctos";
            }
            return View(proveedorViewModel);
        }

        private void ValidarDatosEntrada(int id)
        {
            if (id <= 0)
            {
                throw new ProveedorException("El id no es correcto");
            }
        }
    }
}
