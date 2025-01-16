using LogicaAplicacion.CasosDeUso.CUAuditoria;
using LogicaAplicacion.CasosDeUso.CURepuesto;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class RepuestoController : Controller
    {
        public ICUGetAllRepuesto CUGetAllRepuesto { get; set; }
        public ICUCreateRepuesto CUCreateRepuesto { get; set; }
        public ICUGetByIdRepuesto CUGetByIdRepuesto { get; set; }
        public ICUUpdateRepuesto CUUpdateRepuesto { get; set; }
        public ICUCreateAuditoria CUCreateAuditoria { get; set; }
        
        public RepuestoController(ICUGetAllRepuesto cUGetAllRepuesto,
            ICUCreateRepuesto cUCreateRepuesto,
            ICUGetByIdRepuesto cUGetByIdRepuesto,
            ICUUpdateRepuesto cUUpdateRepuesto,
            ICUCreateAuditoria cUCreateAuditoria)
        {
            CUGetAllRepuesto = cUGetAllRepuesto;
            CUCreateRepuesto = cUCreateRepuesto;
            CUGetByIdRepuesto = cUGetByIdRepuesto;
            CUUpdateRepuesto = cUUpdateRepuesto; 
            CUCreateAuditoria = cUCreateAuditoria;
        }

        // GET: RepuestoController
        public ActionResult Index()
        {
            List<RepuestoViewModel> listaRepuestoViewModel = new List<RepuestoViewModel>();
            IEnumerable<Repuesto> listaRepuestos = CUGetAllRepuesto.GetAllRepuesto();
            foreach(var repuesto in listaRepuestos)
            {
                RepuestoViewModel repuestoViewModel = new RepuestoViewModel()
                {
                    Id = repuesto.Id,
                    Codigo = repuesto.Codigo,
                    Nombre = repuesto.Nombre,
                    Descripcion = repuesto.Descripcion,
                    Medida = repuesto.Medida,
                    Unidad = repuesto.Unidad,
                    StockMin = repuesto.StockMin,
                    Stock = repuesto.Stock
                };
                listaRepuestoViewModel.Add(repuestoViewModel);
            }
            return View(listaRepuestoViewModel);
        }

        // GET: RepuestoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RepuestoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepuestoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepuestoViewModel repuestoViewModel,string operacion)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    Repuesto repuesto = new Repuesto()
                    {
                        Codigo = repuestoViewModel.Codigo,
                        Nombre = repuestoViewModel.Nombre,
                        Descripcion = repuestoViewModel.Descripcion,
                        Medida = repuestoViewModel.Medida,
                        Unidad = repuestoViewModel.Unidad,
                        StockMin = repuestoViewModel.StockMin,
                        Stock = repuestoViewModel.Stock
                    };
                    CUCreateRepuesto.CreateRepuesto(repuesto);

                    Auditoria auditoria = new Auditoria()
                    {
                        Cedula = HttpContext.Session.GetString("cedula"),
                        NombreUsuario = HttpContext.Session.GetString("nombre"),
                        ApellidoUsuario = HttpContext.Session.GetString("apellido"),
                        FechaHora = DateTime.Now,
                        IdEntidad = repuesto.Id,
                        TipoEntidad = repuesto.GetType().Name.ToString(),
                        Operacion = operacion
                    };
                    CUCreateAuditoria.CreateAuditoria(auditoria);
                    return RedirectToAction(nameof(Index));
                }
                catch(RepuestoException ex)
                {
                    ViewBag.Error = ex.Message;
                    return View(repuestoViewModel);
                }
                catch(Exception ex)
                {
                    return View(repuestoViewModel);
                }
            }
            return View(repuestoViewModel);
        }

        // GET: RepuestoController/Edit/5
        public ActionResult Edit(int id)
        {
            RepuestoViewModel repuestoViewModel = new RepuestoViewModel();
            try
            {
                Repuesto repuesto = CUGetByIdRepuesto.GetByIdRepuesto(id);
                if(repuesto!= null)
                {
                    repuestoViewModel.Codigo = repuesto.Codigo;
                    repuestoViewModel.Nombre= repuesto.Nombre;
                    repuestoViewModel.Descripcion= repuesto.Descripcion;
                    repuestoViewModel.Medida= repuesto.Medida;
                    repuestoViewModel.Unidad= repuesto.Unidad;
                    repuestoViewModel.StockMin=repuesto.StockMin;
                    repuestoViewModel.Stock= repuesto.Stock;    

                }
            }
            catch (RepuestoException ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(repuestoViewModel);
            }
            catch(Exception ex)
            {
                return View(repuestoViewModel);
            }
            return View(repuestoViewModel);
        }

        // POST: RepuestoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RepuestoViewModel repuestoViewModel,string operacion)
        {
            try
            {
                Repuesto repuesto = new Repuesto()
                {
                    Id = repuestoViewModel.Id,
                    Codigo=repuestoViewModel.Codigo,
                    Nombre=repuestoViewModel.Nombre,
                    Descripcion=repuestoViewModel.Descripcion,
                    Medida=repuestoViewModel.Medida,
                    Unidad=repuestoViewModel.Unidad,
                    StockMin=repuestoViewModel.StockMin
                };
                CUUpdateRepuesto.UpdateRepuesto(repuesto);
                Auditoria auditoria = new Auditoria()
                {
                    NombreUsuario = HttpContext.Session.GetString("nombre"),
                    FechaHora = DateTime.Now,
                    IdEntidad = repuesto.Id,
                    TipoEntidad = repuesto.GetType().Name.ToString(),
                    Operacion = operacion
                };
                CUCreateAuditoria.CreateAuditoria(auditoria);
                return RedirectToAction(nameof(Index));
            }
            catch(RepuestoException ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(repuestoViewModel);
            }
            catch(Exception ex)
            {
                ViewData["ErrorMessage"] = "Se produjo un error";
            }
            return View(repuestoViewModel);
        }

        // GET: RepuestoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RepuestoController/Delete/5
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
