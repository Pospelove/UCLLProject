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
    public class LesController : Controller
    {
        private readonly GiP1Context _context;

        public LesController(GiP1Context context)
        {
            _context = context;
        }

        // GET: Les
        public async Task<IActionResult> Index()
        {
            var giP1Context = _context.Les.Include(l => l.LokaalcodeNavigation).Include(l => l.PlanningcodeNavigation).Include(l => l.VakcodeNavigation);
            return View(await giP1Context.ToListAsync());
        }

        // GET: Les/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var les = await _context.Les
                .Include(l => l.LokaalcodeNavigation)
                .Include(l => l.PlanningcodeNavigation)
                .Include(l => l.VakcodeNavigation)
                .FirstOrDefaultAsync(m => m.LesId == id);
            if (les == null)
            {
                return NotFound();
            }

            return View(les);
        }

        // GET: Les/Create
        public IActionResult Create()
        {
            ViewData["Lokaalcode"] = new SelectList(_context.Lokaal, "Lokaalcode", "Lokaalcode");
            ViewData["Planningcode"] = new SelectList(_context.Planning, "Planningcode", "Planningcode");
            ViewData["Vakcode"] = new SelectList(_context.Vak, "Vakcode", "Vakcode");
            return View();
        }

        // POST: Les/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LesId,Vakcode,Lokaalcode,Planningcode,Lesnaam")] Les les)
        {
            if (ModelState.IsValid)
            {
                _context.Add(les);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Lokaalcode"] = new SelectList(_context.Lokaal, "Lokaalcode", "Lokaalcode", les.Lokaalcode);
            ViewData["Planningcode"] = new SelectList(_context.Planning, "Planningcode", "Planningcode", les.Planningcode);
            ViewData["Vakcode"] = new SelectList(_context.Vak, "Vakcode", "Vakcode", les.Vakcode);
            return View(les);
        }

        // GET: Les/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var les = await _context.Les.FindAsync(id);
            if (les == null)
            {
                return NotFound();
            }
            ViewData["Lokaalcode"] = new SelectList(_context.Lokaal, "Lokaalcode", "Lokaalcode", les.Lokaalcode);
            ViewData["Planningcode"] = new SelectList(_context.Planning, "Planningcode", "Planningcode", les.Planningcode);
            ViewData["Vakcode"] = new SelectList(_context.Vak, "Vakcode", "Vakcode", les.Vakcode);
            return View(les);
        }

        // POST: Les/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LesId,Vakcode,Lokaalcode,Planningcode,Lesnaam")] Les les)
        {
            if (id != les.LesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(les);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LesExists(les.LesId))
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
            ViewData["Lokaalcode"] = new SelectList(_context.Lokaal, "Lokaalcode", "Lokaalcode", les.Lokaalcode);
            ViewData["Planningcode"] = new SelectList(_context.Planning, "Planningcode", "Planningcode", les.Planningcode);
            ViewData["Vakcode"] = new SelectList(_context.Vak, "Vakcode", "Vakcode", les.Vakcode);
            return View(les);
        }

        // GET: Les/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var les = await _context.Les
                .Include(l => l.LokaalcodeNavigation)
                .Include(l => l.PlanningcodeNavigation)
                .Include(l => l.VakcodeNavigation)
                .FirstOrDefaultAsync(m => m.LesId == id);
            if (les == null)
            {
                return NotFound();
            }

            return View(les);
        }

        // POST: Les/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var les = await _context.Les.FindAsync(id);
            _context.Les.Remove(les);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LesExists(int id)
        {
            return _context.Les.Any(e => e.LesId == id);
        }
    }
}
