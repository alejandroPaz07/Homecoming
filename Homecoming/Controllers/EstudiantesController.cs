
using Homecoming.Data;
using Homecoming.Models;
using Microsoft.AspNetCore.Mvc;


namespace Homecoming.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly HomecomingContext _context;

        public EstudiantesController(HomecomingContext context)
        {
            _context = context;       
        }

        public IActionResult Index()
        {
            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);
        }
        [HttpGet]
        public IActionResult Create()
            {
                return View();
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Estudiante estudiante)
        {
            bool cedulaExiste = _context.Estudiantes
                .Any(e => e.Cedula == estudiante.Cedula);

            if (cedulaExiste)
            {
                ModelState.AddModelError("Cedula",
                    "Esta cédula ya se encuentra registrada.");
            }

            if (ModelState.IsValid)
            {
                estudiante.FechaRegistro = DateTime.Now;

                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(estudiante);
        }




    }
}
