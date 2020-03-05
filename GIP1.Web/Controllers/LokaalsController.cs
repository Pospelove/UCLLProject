using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GIP1.Web.Entitiese;

namespace GIP1.Web.Controllers
{
    public class LokaalsController : Controller
    {
        private readonly GiP1Context _context;

        public LokaalsController(GiP1Context context)
        {
            _context = context;
        }

        // GET: Lokaals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lokaal.ToListAsync());
        }

        // GET: Lokaals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokaal = await _context.Lokaal
                .FirstOrDefaultAsync(m => m.Code == id);
            if (lokaal == null)
            {
                return NotFound();
            }

            return View(lokaal);
        }

        // GET: Lokaals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lokaals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Locatie,Opmerking")] Lokaal lokaal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lokaal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lokaal);
        }

        // GET: Lokaals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokaal = await _context.Lokaal.FindAsync(id);
            if (lokaal == null)
            {
                return NotFound();
            }
            return View(lokaal);
        }

        // POST: Lokaals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,Locatie,Opmerking")] Lokaal lokaal)
        {
            if (id != lokaal.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokaal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokaalExists(lokaal.Code))
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
            return View(lokaal);
        }

        // GET: Lokaals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokaal = await _context.Lokaal
                .FirstOrDefaultAsync(m => m.Code == id);
            if (lokaal == null)
            {
                return NotFound();
            }

            return View(lokaal);
        }

        // POST: Lokaals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lokaal = await _context.Lokaal.FindAsync(id);
            _context.Lokaal.Remove(lokaal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokaalExists(string id)
        {
            return _context.Lokaal.Any(e => e.Code == id);
        }
    }
}
