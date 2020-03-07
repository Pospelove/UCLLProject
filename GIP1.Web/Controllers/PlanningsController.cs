using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GIP1.Web.Entities;

namespace GIP1.Web.Controllers
{
    public class PlanningsController : Controller
    {
        private readonly GiP1Context _context;

        public PlanningsController(GiP1Context context)
        {
            _context = context;
        }

        // GET: Plannings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planning.ToListAsync());
        }

        // GET: Plannings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planning = await _context.Planning
                .FirstOrDefaultAsync(m => m.Planningcode == id);
            if (planning == null)
            {
                return NotFound();
            }

            return View(planning);
        }

        // GET: Plannings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plannings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Planningcode,Datumtijd")] Planning planning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planning);
        }

        // GET: Plannings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planning = await _context.Planning.FindAsync(id);
            if (planning == null)
            {
                return NotFound();
            }
            return View(planning);
        }

        // POST: Plannings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Planningcode,Datumtijd")] Planning planning)
        {
            if (id != planning.Planningcode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanningExists(planning.Planningcode))
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
            return View(planning);
        }

        // GET: Plannings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planning = await _context.Planning
                .FirstOrDefaultAsync(m => m.Planningcode == id);
            if (planning == null)
            {
                return NotFound();
            }

            return View(planning);
        }

        // POST: Plannings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var planning = await _context.Planning.FindAsync(id);
            _context.Planning.Remove(planning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanningExists(string id)
        {
            return _context.Planning.Any(e => e.Planningcode == id);
        }
    }
}
