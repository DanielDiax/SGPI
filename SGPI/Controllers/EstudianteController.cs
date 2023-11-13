using System.Data.Common;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        private SgpiContext context;
        public int idUser;

        public EstudianteController(SgpiContext sgpiContext)
        {
            context = sgpiContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Carga la vista al iniciar la página
        /// </summary>
        /// <returns></returns>
        public IActionResult BuscarEstudiante()
        {
            return View();
        }

        /// <summary>
        /// Carga la vista al iniciar la página
        /// </summary>
        /// <returns></returns>
        /// 
        //[HttpPost]
        //public IActionResult BuscarEstudiante(Usuario user)
        //{
        //    var us = context.Usuarios
        //        .Where(u => u.NumeroDoc.ToString()
        //        .Equals(user.NumeroDoc.ToString())
        //        && u.IdRol == 2);

        //    if (us != null)
        //    {
        //        return View(us.FirstOrDefault());
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        /// <summary>
        /// Edita el usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public ActionResult EditarEstudiante(int idUsuario)
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
                    user.Password = usuario.Password;
                    user.Activo = usuario.Activo;

                    context.Update(user);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("BuscarEstudiante", "Estudiante");
        }

        [HttpPost]
        public IActionResult BuscarEstudiante(int Documento)
        {
            try
            {
                if (Documento == 0)
                {
                    // El número de documento es nulo, puedes manejarlo como desees (por ejemplo, mostrar un mensaje de error).
                    //return View("Error");
                }

                var usuarios = context.ObtenerEstudiantePorDoc(Documento);

                // Haz algo con los usuarios obtenidos, como pasarlos a la vista
                return View(usuarios);
            }
            catch (Exception ex)
            {

                // Registra o maneja la excepción según sea necesario
                Console.WriteLine($"Error: {ex.Message}");
                return View("Error");
            }
        }
    }
}
