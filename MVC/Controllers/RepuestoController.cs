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
        public RepuestoController(ICUGetAllRepuesto cUGetAllRepuesto,ICUCreateRepuesto cUCreateRepuesto,
            ICUGetByIdRepuesto cUGetByIdRepuesto, ICUUpdateRepuesto cUUpdateRepuesto)
        {
            CUGetAllRepuesto = cUGetAllRepuesto;
            CUCreateRepuesto = cUCreateRepuesto;
            CUGetByIdRepuesto = cUGetByIdRepuesto;
            CUUpdateRepuesto = cUUpdateRepuesto;    
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
        public ActionResult Create(RepuestoViewModel repuestoViewModel)
        {
            if (ModelState.IsValid)
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
