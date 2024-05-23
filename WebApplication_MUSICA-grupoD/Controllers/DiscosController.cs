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
    public class DiscosController : Controller
    {
        private readonly GrupoDContext _context;

        public DiscosController(GrupoDContext context)
        {
            _context = context;
        }

        // GET: Discos
        public async Task<IActionResult> Index()
        {
            var grupoDContext = _context.Discos.Include(d => d.Genero).Include(d => d.Grupos);
            return View(await grupoDContext.ToListAsync());
        }

        // GET: Discos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discos = await _context.Discos
                .Include(d => d.Genero)
                .Include(d => d.Grupos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discos == null)
            {
                return NotFound();
            }

            return View(discos);
        }

        // GET: Discos/Create
        public IActionResult Create()
        {
            ViewData["GeneroID"] = new SelectList(_context.Generos, "Id", "Nombre");
            ViewData["GruposId"] = new SelectList(_context.Grupos, "Id", "Nombre");
            return View();
        }

        // POST: Discos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,GeneroID,GruposId")] Discos discos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroID"] = new SelectList(_context.Generos, "Id", "Nombre", discos.GeneroID);
            ViewData["GruposId"] = new SelectList(_context.Grupos, "Id", "Nombre", discos.GruposId);
            return View(discos);
        }

        // GET: Discos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discos = await _context.Discos.FindAsync(id);
            if (discos == null)
            {
                return NotFound();
            }
            ViewData["GeneroID"] = new SelectList(_context.Generos, "Id", "Nombre", discos.GeneroID);
            ViewData["GruposId"] = new SelectList(_context.Grupos, "Id", "Nombre", discos.GruposId);
            return View(discos);
        }

        // POST: Discos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,GeneroID,GruposId")] Discos discos)
        {
            if (id != discos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscosExists(discos.Id))
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
            ViewData["GeneroID"] = new SelectList(_context.Generos, "Id", "Nombre", discos.GeneroID);
            ViewData["GruposId"] = new SelectList(_context.Grupos, "Id", "Nombre", discos.GruposId);
            return View(discos);
        }

        // GET: Discos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discos = await _context.Discos
                .Include(d => d.Genero)
                .Include(d => d.Grupos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discos == null)
            {
                return NotFound();
            }

            return View(discos);
        }

        // POST: Discos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discos = await _context.Discos.FindAsync(id);
            if (discos != null)
            {
                _context.Discos.Remove(discos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscosExists(int id)
        {
            return _context.Discos.Any(e => e.Id == id);
        }
    }
}
