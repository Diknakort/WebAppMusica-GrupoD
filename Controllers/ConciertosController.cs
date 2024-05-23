using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMUSICA.Models;

namespace WebAppMUSICA.Controllers
{
    public class ConciertosController : Controller
    {
        private readonly GrupoDContext _context;

        public ConciertosController(GrupoDContext context)
        {
            _context = context;
        }

        // GET: Conciertos
        public async Task<IActionResult> Index()
        {
            var grupoDContext = _context.Conciertos.Include(c => c.Giras).Include(c => c.Grupos);
            return View(await grupoDContext.ToListAsync());
        }

        // GET: Conciertos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conciertos = await _context.Conciertos
                .Include(c => c.Giras)
                .Include(c => c.Grupos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conciertos == null)
            {
                return NotFound();
            }

            return View(conciertos);
        }

        // GET: Conciertos/Create
        public IActionResult Create()
        {
            ViewData["GirasID"] = new SelectList(_context.Giras, "Id", "Nombre");
            ViewData["GruposID"] = new SelectList(_context.Grupos, "Id", "Nombre");
            return View();
        }

        // POST: Conciertos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Precio,FechaHora,Ciudad,GruposID,GirasID")] Conciertos conciertos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conciertos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GirasID"] = new SelectList(_context.Giras, "Id", "Nombre", conciertos.GirasID);
            ViewData["GruposID"] = new SelectList(_context.Grupos, "Id", "Nombre", conciertos.GruposID);
            return View(conciertos);
        }

        // GET: Conciertos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conciertos = await _context.Conciertos.FindAsync(id);
            if (conciertos == null)
            {
                return NotFound();
            }
            ViewData["GirasID"] = new SelectList(_context.Giras, "Id", "Nombre", conciertos.GirasID);
            ViewData["GruposID"] = new SelectList(_context.Grupos, "Id", "Nombre", conciertos.GruposID);
            return View(conciertos);
        }

        // POST: Conciertos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Precio,FechaHora,Ciudad,GruposID,GirasID")] Conciertos conciertos)
        {
            if (id != conciertos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conciertos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConciertosExists(conciertos.Id))
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
            ViewData["GirasID"] = new SelectList(_context.Giras, "Id", "Nombre", conciertos.GirasID);
            ViewData["GruposID"] = new SelectList(_context.Grupos, "Id", "Nombre", conciertos.GruposID);
            return View(conciertos);
        }

        // GET: Conciertos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conciertos = await _context.Conciertos
                .Include(c => c.Giras)
                .Include(c => c.Grupos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conciertos == null)
            {
                return NotFound();
            }

            return View(conciertos);
        }

        // POST: Conciertos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conciertos = await _context.Conciertos.FindAsync(id);
            if (conciertos != null)
            {
                _context.Conciertos.Remove(conciertos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConciertosExists(int id)
        {
            return _context.Conciertos.Any(e => e.Id == id);
        }
    }
}
