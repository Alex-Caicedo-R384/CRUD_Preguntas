using CRUD_Preguntas.Datos;
using CRUD_Preguntas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace CRUD_Preguntas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public HomeController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Preguntas.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Preguntas pregunta)
        {
            if (ModelState.IsValid)
            {
                _contexto.Preguntas.Add(pregunta);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = _contexto.Preguntas.Find(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Preguntas pregunta)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(pregunta);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = _contexto.Preguntas.Find(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = _contexto.Preguntas.Find(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var pregunta = await _contexto.Preguntas.FindAsync(id);
            if (pregunta == null)
            {
                return View();
            }

            _contexto.Preguntas.Remove(pregunta);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
    }
}