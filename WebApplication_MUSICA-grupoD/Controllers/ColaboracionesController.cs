using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_MUSICA_grupoD.Models;

namespace WebApplication_MUSICA_grupoD.Controllers
{
    public class ColaboracionesController : Controller
    {
        private readonly GrupoDContext _context;

        public ColaboracionesController(GrupoDContext context)
        {
            _context = context;
        }

        // GET: Colaboraciones
        public async Task<IActionResult> Index()
        {
            var grupoDContext = _context.Colaboraciones.Include(c => c.Artistas).Include(c => c.Grupos);
            return View(await grupoDContext.ToListAsync());
        }

        // GET: Colaboraciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboraciones = await _context.Colaboraciones
                .Include(c => c.Artistas)
                .Include(c => c.Grupos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboraciones == null)
            {
                return NotFound();
            }

            return View(colaboraciones);
        }

        // GET: Colaboraciones/Create
        public IActionResult Create()
        {
            ViewData["ArtistasID"] = new SelectList(_context.Artistas, "Id", "Nombre");
            ViewData["GruposID"] = new SelectList(_context.Grupos, "Id", "Nombre");
            return View();
        }

        // POST: Colaboraciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GruposID,ArtistasID")] Colaboraciones colaboraciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboraciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistasID"] = new SelectList(_context.Artistas, "Id", "Nombre", colaboraciones.ArtistasID);
            ViewData["GruposID"] = new SelectList(_context.Grupos, "Id", "Nombre", colaboraciones.GruposID);
            return View(colaboraciones);
        }

        // GET: Colaboraciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboraciones = await _context.Colaboraciones.FindAsync(id);
            if (colaboraciones == null)
            {
                return NotFound();
            }
            ViewData["ArtistasID"] = new SelectList(_context.Artistas, "Id", "Nombre", colaboraciones.ArtistasID);
            ViewData["GruposID"] = new SelectList(_context.Grupos, "Id", "Nombre", colaboraciones.GruposID);
            return View(colaboraciones);
        }

        // POST: Colaboraciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GruposID,ArtistasID")] Colaboraciones colaboraciones)
        {
            if (id != colaboraciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboraciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboracionesExists(colaboraciones.Id))
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
            ViewData["ArtistasID"] = new SelectList(_context.Artistas, "Id", "Nombre", colaboraciones.ArtistasID);
            ViewData["GruposID"] = new SelectList(_context.Grupos, "Id", "Nombre", colaboraciones.GruposID);
            return View(colaboraciones);
        }

        // GET: Colaboraciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboraciones = await _context.Colaboraciones
                .Include(c => c.Artistas)
                .Include(c => c.Grupos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboraciones == null)
            {
                return NotFound();
            }

            return View(colaboraciones);
        }

        // POST: Colaboraciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaboraciones = await _context.Colaboraciones.FindAsync(id);
            if (colaboraciones != null)
            {
                _context.Colaboraciones.Remove(colaboraciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboracionesExists(int id)
        {
            return _context.Colaboraciones.Any(e => e.Id == id);
        }
    }
}
