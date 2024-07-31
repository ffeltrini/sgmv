using LogicaAccesoDatos.Interfaces;
using LogicaAplicacion.CasosDeUso.CUAuditoria;
using LogicaAplicacion.CasosDeUso.CUCliente;
using LogicaAplicacion.CasosDeUso.CUEmpleado;
using LogicaAplicacion.CasosDeUso.CUTipoRol;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public ICUCreateCliente CUCreateCliente { get; set; }
        public ICUCreateEmpleado CUCreateEmpleado { get; set; }
        public ICUCreateAuditoria CUCreateAuditoria { get; set; }
        
        public UsuarioController(IRepositorioUsuarios repositorioUsuarios,
            ICUGetAllUsuario cUGetAllUsuario,
            ICUCreateUsuario cUCreateUsuario,
            ICULogin cULogin,
            ICUGetAllTipoRol cUGetAllTipoRol,
            ICUGetByIdTipoRol cUGetByIdTipoRol,
            ICUCreateCliente cUCreateCliente,
            ICUCreateEmpleado cUCreateEmpleado,
            ICUCreateAuditoria cUCreateAuditoria)
        {
            RepositorioUsuarios = repositorioUsuarios;
            CUGetAllUsuario = cUGetAllUsuario;
            CUCreateUsuario = cUCreateUsuario;
            CULogin = cULogin;
            CUGetAllTipoRol= cUGetAllTipoRol;
            CUGetByIdTipoRol = cUGetByIdTipoRol;
            CUCreateCliente= cUCreateCliente;
            CUCreateEmpleado= cUCreateEmpleado;
            CUCreateAuditoria= cUCreateAuditoria;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            IEnumerable<Usuario> listaUsuarios = CUGetAllUsuario.GetAllUsuarios().OrderBy(u=>u.Id).ToList();
            List<UsuarioViewModel> listaUsuarioViewModel  = new List<UsuarioViewModel>();
            foreach(var usuario in listaUsuarios)
            {
                UsuarioViewModel usuarioViewModel = new UsuarioViewModel()
                {
                    Id = usuario.Id,
                    Cedula= usuario.Cedula,
                    Nombre = usuario.Nombre,
                    Apellido= usuario.Apellido,
                    FechaNacimiento= usuario.FechaNacimiento,
                    Correo= usuario.Correo,
                    Contrasenia = usuario.Contrasenia,
                    RolId = usuario.Rol.Id,
                    Roles = CUGetAllTipoRol.GetAllTipoRol().Select(r => new TipoRolViewModel()
                    {
                        Id=r.Id,
                        Rol=r.Rol
                    }),
                };
                // Check if the user is Cliente or Empleado
                if (usuario is Cliente cliente)
                {
                    usuarioViewModel.LicenciaId = cliente.LicenciaId;
                    usuarioViewModel.FechaInicio = cliente.FechaInicio;
                    usuarioViewModel.Frecuente = cliente.Frecuente;
                    usuarioViewModel.Actividad = cliente.Actividad;
                    usuarioViewModel.Puntos = cliente.Puntos;
                }
                else if (usuario is Empleado empleado)
                {
                    usuarioViewModel.EmpleadoCargo = empleado.EmpleadoCargo;
                    usuarioViewModel.FechaIngreso = empleado.FechaIngreso;
                    usuarioViewModel.Foto = empleado.Foto;
                    usuarioViewModel.Bono = empleado.Bono;
                }
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
            usuarioViewModel.EmpleadoCargos = Enum.GetValues(typeof(Empleado.Cargo))
                                        .Cast<Empleado.Cargo>()
                                        .Select(c => new SelectListItem
                                        {
                                            Value = ((int)c).ToString(),
                                            Text = c.ToString()
                                        });

            return View(usuarioViewModel);
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioViewModel, string operacion)
        {
            UsuarioViewModel usuarioVM = new UsuarioViewModel();
            usuarioVM.Roles = CUGetAllTipoRol.GetAllTipoRol().Select(t => new TipoRolViewModel()
            {
                Id = t.Id,
                Rol = t.Rol
            });
            if (!ModelState.IsValid)
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
                    Usuario usuario;
                    
                    if (!string.IsNullOrEmpty(usuarioViewModel.LicenciaId)) // Assuming LicenciaId is a property of Cliente
                    {
                        Cliente cliente = new Cliente()
                        {
                            Cedula = usuarioViewModel.Cedula,
                            Nombre = usuarioViewModel.Nombre,
                            Apellido = usuarioViewModel.Apellido,
                            FechaNacimiento = usuarioViewModel.FechaNacimiento,
                            Correo = usuarioViewModel.Correo,
                            Contrasenia = usuarioViewModel.Contrasenia,
                            Confirmacion = usuarioViewModel.Confirmacion,
                            Rol = tipoRol,
                            LicenciaId = usuarioViewModel.LicenciaId,
                            FechaInicio=usuarioViewModel.FechaInicio,
                            Frecuente=usuarioViewModel.Frecuente,
                            Actividad=usuarioViewModel.Actividad,
                            Puntos=usuarioViewModel.Puntos
                        };

                        CUCreateCliente.CreateCliente(cliente);
                        usuario = cliente; // Set usuario to the created Cliente
                    }
                    else
                    {
                        Empleado empleado = new Empleado()
                        {
                            Cedula = usuarioViewModel.Cedula,
                            Nombre = usuarioViewModel.Nombre,
                            Apellido = usuarioViewModel.Apellido,
                            FechaNacimiento = usuarioViewModel.FechaNacimiento,
                            Correo = usuarioViewModel.Correo,
                            Contrasenia = usuarioViewModel.Contrasenia,
                            Confirmacion = usuarioViewModel.Confirmacion,
                            Rol = tipoRol,
                            EmpleadoCargo=usuarioViewModel.EmpleadoCargo,
                            FechaIngreso=usuarioViewModel.FechaIngreso,
                            Foto=usuarioViewModel.Foto,
                            Bono=usuarioViewModel.Bono
                        };

                        CUCreateEmpleado.CreateEmpleado(empleado);
                        usuario = empleado; // Set usuario to the created Empleado
                    }
                    Auditoria auditoria = new Auditoria()
                    {
                        Cedula = HttpContext.Session.GetString("cedula"),
                        NombreUsuario = HttpContext.Session.GetString("nombre"),
                        ApellidoUsuario = HttpContext.Session.GetString("apellido"),
                        FechaHora = DateTime.Now,
                        IdEntidad = usuario.Id,
                        TipoEntidad = usuario.GetType().Name.ToString(),
                        Operacion = operacion
                    };
                    CUCreateAuditoria.CreateAuditoria(auditoria);
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
        public ActionResult IniciarSesion(string cedula, string contrasenia)
        {
            try
            {
                if (cedula.Trim() != "" && contrasenia.Trim() != "")
                {
                    Usuario usuarioBuscado = CULogin.Login(cedula, contrasenia);
                    //TipoRol tipoRol = new TipoRol();
                    //tipoRol = CUGetByIdTipoRol.GetByIdTipoRol(usuarioBuscado.Rol.Id);
                    if (usuarioBuscado != null)
                    {
                        HttpContext.Session.SetString("rol", usuarioBuscado.Rol.Rol);
                        HttpContext.Session.SetString("cedula", usuarioBuscado.Cedula);
                        HttpContext.Session.SetString("nombre", usuarioBuscado.Nombre);
                        HttpContext.Session.SetString("apellido", usuarioBuscado.Apellido);
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
