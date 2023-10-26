using Microsoft.AspNetCore.Mvc;

using SGPI.Models;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        private SgpiContext context;

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

            return View();

        }

        /// <summary>
        /// Consulta los Drop down para la vista de creación de usuarios
        /// </summary>
        /// <returns></returns>
        public IActionResult ModificarUsuario()
        {
            ViewBag.genero = context.Generos.ToList();

            ViewBag.rol = context.Rols.ToList();

            ViewBag.tipoDocumento = context.TipoDocumentos.ToList();

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
                .Where(u => u.NumeroDoc
                .Contains(user.NumeroDoc));

            return View();
        }
    }
}
