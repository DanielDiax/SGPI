using Microsoft.AspNetCore.Mvc;

using SGPI.Models;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        private SgpiContext context;
        public int idUser;

        public AdministradorController(SgpiContext sgpiContext) 
        {
            context = sgpiContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Consulta los Drop down para la vista de creación de usuarios
        /// </summary>
        /// <returns></returns>
        public IActionResult CrearUsuario()
        {
            ViewBag.genero = context.Generos.ToList();

            ViewBag.rol = context.Rols.ToList();

            ViewBag.tipoDocumento = context.TipoDocumentos.ToList();

            ViewBag.programa = context.Programas.ToList();

            return View();
        }

        /// <summary>
        /// Guarda el nuevo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            context.Add(usuario);
            context.SaveChanges();

            ViewBag.genero = context.Generos.ToList();

            ViewBag.rol = context.Rols.ToList();

            ViewBag.tipoDocumento = context.TipoDocumentos.ToList();

            ViewBag.programa = context.Programas.ToList();

            return View();

        }

        /// <summary>
        /// Carga la vista al iniciar la página
        /// </summary>
        /// <returns></returns>
        public IActionResult BuscarUsuario()
        {
            ViewBag.genero = context.Generos.ToList();

            ViewBag.rol = context.Rols.ToList();

            ViewBag.tipoDocumento = context.TipoDocumentos.ToList();

            ViewBag.programa = context.Programas.ToList();

            return View();
        }

        /// <summary>
        /// Guarda el nuevo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BuscarUsuario(Usuario user)
        {
            var us = context.Usuarios
                .Where(u => u.NumeroDoc.ToString()
                .Equals(user.NumeroDoc.ToString()));
              
            if (us != null)
            {
                return View(us.FirstOrDefault());
            }
            else
            {
                return View();
            }
        }


        /// <summary>
        /// Edita el usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public ActionResult EditarUsuario(int idUsuario)
        {
            Usuario usuario = context.Usuarios.Find(idUsuario);

            if (usuario == null)
            {
                return ViewBag.mensaje = "Error al editar el Usuario";
            }

            ViewBag.genero = context.Generos.ToList();

            ViewBag.rol = context.Rols.ToList();

            ViewBag.tipoDocumento = context.TipoDocumentos.ToList();

            ViewBag.programa = context.Programas.ToList();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (usuario == null)
            {
                return ViewBag.mensaje = "Error al editar el Usuario";
            }
            else
            {
                Usuario user = context.Usuarios.Find(usuario.IdUsuario);

                int idUser = usuario.IdUsuario;

                if (user != null)
                {
                    user.Nombre = usuario.Nombre;
                    user.PrimerApellido = usuario.PrimerApellido;
                    user.SegundoApellido = usuario.SegundoApellido;
                    user.IdGenero = usuario.IdGenero;
                    user.Email = usuario.Email;
                    user.IdPrograma = usuario.IdPrograma;
                    user.Activo = usuario.Activo;

                    context.Update(user);
                    context.SaveChanges();
                }

                // Actualiza las listas ViewBag, si es necesario
                //ViewBag.genero = context.Generos.ToList();
                //ViewBag.rol = context.Rols.ToList();
                //ViewBag.tipoDocumento = context.TipoDocumentos.ToList();
                //ViewBag.programa = context.Programas.ToList();
            }
            return RedirectToAction("BuscarUsuario", "Administrador");
        }

        public ActionResult Delete(Usuario user)
        {
            Usuario usuario = context.Usuarios.Find(user.IdUsuario);

            if (usuario == null)
            {
                return ViewBag.mensaje = "Error al eliminar el Usuario";
            }
            else
            {
                context.Remove(usuario);
                context.SaveChanges();
            }
            return RedirectToAction("BuscarUsuario", "Administrador");
        }
    }
}
