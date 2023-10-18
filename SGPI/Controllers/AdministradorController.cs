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

        public IActionResult CrearUsuario()
        {
            ViewBag.genero = context.Generos.ToList();

            ViewBag.rol = context.Rols.ToList();

            return View();
        }
    }
}
