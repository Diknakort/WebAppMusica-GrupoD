using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication_MUSICA_grupoD.Models;


namespace WebApplication_MUSICA_grupoD.Controllers
{
    public class ArtistasController : Controller
    {
        private readonly GrupoDContext _context;

        public ArtistasController(GrupoDContext context)
        {
            _context = context;
        }

        // GET: Artistas
        public async Task<IActionResult> Index()
        {
            var grupoDContext = _context.Artistas.Include(a => a.RolPrincipalNavigation);
            return View(await grupoDContext.ToListAsync());

        }

        // GET: Artistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistas = await _context.Artistas
                .Include(a => a.RolPrincipalNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artistas == null)
            {
                return NotFound();
            }

            return View(artistas);
        }

        // GET: Artistas/Create
        public IActionResult Create()
        {
            ViewData["RolPrincipal"] = new SelectList(_context.Roles, "Id", "Nombre");
            return View();
        }

        // POST: Artistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre_Real,Nombre_Artistico,Fecha_Nacimiento,RolPrincipal")] Artistas artistas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artistas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolPrincipal"] = new SelectList(_context.Roles, "Id", "Nombre", artistas.RolPrincipal);
            return View(artistas);
        }

        // GET: Artistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistas = await _context.Artistas.FindAsync(id);
            if (artistas == null)
            {
                return NotFound();
            }
            ViewData["RolPrincipal"] = new SelectList(_context.Roles, "Id", "Nombre", artistas.RolPrincipal);
            return View(artistas);
        }

        // POST: Artistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre_Real,Nombre_Artistico,Fecha_Nacimiento,RolPrincipal")] Artistas artistas)
        {
            if (id != artistas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artistas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistasExists(artistas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolPrincipal"] = new SelectList(_context.Roles, "Id", "Nombre", artistas.RolPrincipal);
            return View(artistas);
        }

        // GET: Artistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistas = await _context.Artistas
                .Include(a => a.RolPrincipalNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artistas == null)
            {
                return NotFound();
            }

            return View(artistas);
        }

        // POST: Artistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artistas = await _context.Artistas.FindAsync(id);
            if (artistas != null)
            {
                _context.Artistas.Remove(artistas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistasExists(int id)
        {
            return _context.Artistas.Any(e => e.Id == id);
        }
    }
}
