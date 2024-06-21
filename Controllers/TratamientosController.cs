using Microsoft.AspNetCore.Mvc;
using GestionCitasMedicas.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionCitasMedicas.Controllers
{
    public class TratamientosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TratamientosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tratamientos
        public async Task<IActionResult> Index()
        {
            var tratamientos = _context.Tratamientos.Include(t => t.Paciente);
            return View(await tratamientos.ToListAsync());
        }

        // GET: Tratamientos/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre");
            return View();
        }

        // POST: Tratamientos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,Descripcion,Instrucciones,EfectosSecundarios")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tratamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", tratamiento.PacienteId);
            return View(tratamiento);
        }
    }
}
