
using Homecoming.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Homecoming.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdminController : Controller
    {
        private readonly HomecomingContext _context;

        public AdminController(HomecomingContext context)
        {
            _context = context;
        }

        // Mostrar estudiantes registrados
        public IActionResult Index()
        {
            var estudiantes = _context.Estudiantes
                .OrderByDescending(e => e.FechaRegistro)
                .ToList();

            return View(estudiantes);
        }

        // Confirmar entrega de botellas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarEntrega(int id, int cantidad)
        {
            var estudiante = _context.Estudiantes.Find(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            if (cantidad <= 0)
            {
                return BadRequest("La cantidad debe ser mayor que cero.");
            }

            estudiante.CantidadBotellas = cantidad;
            estudiante.BotellasEntregadas = true;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Eliminar estudiante
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            var estudiante = _context.Estudiantes.Find(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Estudiantes.Remove(estudiante);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
