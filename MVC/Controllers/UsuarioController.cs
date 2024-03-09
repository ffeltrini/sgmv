using LogicaAccesoDatos.Interfaces;
using LogicaAplicacion.CasosDeUso.CUTipoRol;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; set; }
        public ICUGetAllUsuario CUGetAllUsuario { get; set; }
        public ICUCreateUsuario CUCreateUsuario { get; set; }
        public ICULogin CULogin { get; set; }
        public ICUGetAllTipoRol CUGetAllTipoRol { get; set; }
        public ICUGetByIdTipoRol CUGetByIdTipoRol { get; set; }
        public UsuarioController(IRepositorioUsuarios repositorioUsuarios,
            ICUGetAllUsuario cUGetAllUsuario,
            ICUCreateUsuario cUCreateUsuario,
            ICULogin cULogin,
            ICUGetAllTipoRol cUGetAllTipoRol,
            ICUGetByIdTipoRol cUGetByIdTipoRol)
        {
            RepositorioUsuarios = repositorioUsuarios;
            CUGetAllUsuario = cUGetAllUsuario;
            CUCreateUsuario = cUCreateUsuario;
            CULogin = cULogin;
            CUGetAllTipoRol= cUGetAllTipoRol;
            CUGetByIdTipoRol = cUGetByIdTipoRol;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            IEnumerable<Usuario> listaUsuarios = CUGetAllUsuario.GetAllUsuarios();
            List<UsuarioViewModel> listaUsuarioViewModel  = new List<UsuarioViewModel>();
            foreach(var usuario in listaUsuarios)
            {
                UsuarioViewModel usuarioViewModel = new UsuarioViewModel()
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Contrasenia = usuario.Contrasenia,
                    RolId = usuario.Rol.Id,
                    Roles = CUGetAllTipoRol.GetAllTipoRol().Select(r => new TipoRolViewModel()
                    {
                        Id=r.Id,
                        Rol=r.Rol
                    }),
                    Fecha = usuario.Fecha
                };
                listaUsuarioViewModel.Add(usuarioViewModel);
            }
            return View(listaUsuarioViewModel);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.Roles = CUGetAllTipoRol.GetAllTipoRol().Select(t => new TipoRolViewModel()
            {
                Id= t.Id,
                Rol= t.Rol
            });
            return View(usuarioViewModel);
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            UsuarioViewModel usuarioVM = new UsuarioViewModel();
            usuarioVM.Roles = CUGetAllTipoRol.GetAllTipoRol().Select(t => new TipoRolViewModel()
            {
                Id = t.Id,
                Rol = t.Rol
            });
            if (ModelState.IsValid)
            {
                if (usuarioViewModel.Contrasenia != usuarioViewModel.Confirmacion)
                {
                    ViewData["ErrorMessage"] = "Contraseña y confirmación no coinciden";
                    return View(usuarioViewModel);
                }
                
                try
                {
                    TipoRol tipoRol = new TipoRol();
                    tipoRol = CUGetByIdTipoRol.GetByIdTipoRol(usuarioViewModel.RolId);
                    Usuario usuario = new Usuario()
                    {
                        Nombre = usuarioViewModel.Nombre,
                        Contrasenia = usuarioViewModel.Contrasenia,
                        Confirmacion = usuarioViewModel.Confirmacion,
                        Rol = tipoRol,
                        Fecha = DateTime.Now
                    };
                    CUCreateUsuario.CreateUsuario(usuario);
                    return RedirectToAction(nameof(Index));
                }
                catch(UsuarioException ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(usuarioViewModel);
                }
                catch(Exception ex)
                {
                    return View(usuarioViewModel);
                }
            }
            return View(usuarioViewModel);
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IniciarSesion(string nombre, string contrasenia)
        {
            try
            {
                if (nombre.Trim() != "" && contrasenia.Trim() != "")
                {
                    Usuario usuarioBuscado = CULogin.Login(nombre, contrasenia);
                    //TipoRol tipoRol = new TipoRol();
                    //tipoRol = CUGetByIdTipoRol.GetByIdTipoRol(usuarioBuscado.Rol.Id);
                    if (usuarioBuscado != null)
                    {
                        HttpContext.Session.SetString("rol", usuarioBuscado.Rol.Rol);
                        HttpContext.Session.SetString("nombre", usuarioBuscado.Nombre);
                        return RedirectToAction("Index", "Compra");
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "Los datos nos son correctos";
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("Login");
            }
            return View("Login");
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
