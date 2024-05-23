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
    public class GruposController : Controller
    {
        private readonly GrupoDContext _context;

        public GruposController(GrupoDContext context)
        {
            _context = context;
        }

        // GET: Grupos
        public async Task<IActionResult> Index()
        {
            var grupoDContext = _context.Grupos.Include(g => g.Managers);
            return View(await grupoDContext.ToListAsync());
        }

        // GET: Grupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupos = await _context.Grupos
                .Include(g => g.Managers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupos == null)
            {
                return NotFound();
            }

            return View(grupos);
        }

        // GET: Grupos/Create
        public IActionResult Create()
        {
            ViewData["ManagersID"] = new SelectList(_context.Managers, "Id", "Nombre");
            return View();
        }

        // POST: Grupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaCreaccion,ManagersID")] Grupos grupos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManagersID"] = new SelectList(_context.Managers, "Id", "Nombre", grupos.ManagersID);
            return View(grupos);
        }

        // GET: Grupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupos = await _context.Grupos.FindAsync(id);
            if (grupos == null)
            {
                return NotFound();
            }
            ViewData["ManagersID"] = new SelectList(_context.Managers, "Id", "Nombre", grupos.ManagersID);
            return View(grupos);
        }

        // POST: Grupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaCreaccion,ManagersID")] Grupos grupos)
        {
            if (id != grupos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GruposExists(grupos.Id))
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
            ViewData["ManagersID"] = new SelectList(_context.Managers, "Id", "Nombre", grupos.ManagersID);
            return View(grupos);
        }

        // GET: Grupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupos = await _context.Grupos
                .Include(g => g.Managers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupos == null)
            {
                return NotFound();
            }

            return View(grupos);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupos = await _context.Grupos.FindAsync(id);
            if (grupos != null)
            {
                _context.Grupos.Remove(grupos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GruposExists(int id)
        {
            return _context.Grupos.Any(e => e.Id == id);
        }
    }
}
