using Microsoft.AspNetCore.Mvc;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
