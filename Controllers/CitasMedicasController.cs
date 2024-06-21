using Microsoft.AspNetCore.Mvc;
using GestionCitasMedicas.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionCitasMedicas.Controllers
{
    public class CitasMedicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitasMedicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CitasMedicas
        public async Task<IActionResult> Index()
        {
            var citasMedicas = _context.CitasMedicas.Include(c => c.Paciente);
            return View(await citasMedicas.ToListAsync());
        }

        // GET: CitasMedicas/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre");
            return View();
        }

        // POST: CitasMedicas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,FechaHora,Especialista,Motivo")] CitaMedica citaMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citaMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nombre", citaMedica.PacienteId);
            return View(citaMedica);
        }
    }


}

