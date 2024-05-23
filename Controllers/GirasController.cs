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
    public class GirasController : Controller
    {
        private readonly GrupoDContext _context;

        public GirasController(GrupoDContext context)
        {
            _context = context;
        }

        // GET: Giras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Giras.ToListAsync());
        }

        // GET: Giras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giras = await _context.Giras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giras == null)
            {
                return NotFound();
            }

            return View(giras);
        }

        // GET: Giras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Giras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha_Inicio,Fecha_Final")] Giras giras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giras);
        }

        // GET: Giras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giras = await _context.Giras.FindAsync(id);
            if (giras == null)
            {
                return NotFound();
            }
            return View(giras);
        }

        // POST: Giras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha_Inicio,Fecha_Final,Nombre")] Giras giras)
        {
            if (id != giras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GirasExists(giras.Id))
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
            return View(giras);
        }

        // GET: Giras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giras = await _context.Giras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giras == null)
            {
                return NotFound();
            }

            return View(giras);
        }

        // POST: Giras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giras = await _context.Giras.FindAsync(id);
            if (giras != null)
            {
                _context.Giras.Remove(giras);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GirasExists(int id)
        {
            return _context.Giras.Any(e => e.Id == id);
        }
    }
}
