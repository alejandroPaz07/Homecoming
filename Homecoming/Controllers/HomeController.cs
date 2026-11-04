using Homecoming.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homecoming.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Presencial()
        {
            return View();
        }

        public IActionResult Online()
        {
            var estudiante = new Estudiante
            {
                Modalidad = "Online",
                Jornada = "No aplica"
            };

            return View("~/Views/Estudiantes/Create.cshtml", estudiante);
        }
        public IActionResult Inscripcion(string jornada)
        {
            var estudiante = new Estudiante
            {
                Modalidad = "Presencial",
                Jornada = jornada
            };

            return View("~/Views/Estudiantes/Create.cshtml", estudiante);
        }
    }
}
