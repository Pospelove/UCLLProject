﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GIP1.Web.Entities;

namespace GIP1.Web.Controllers
{
    public class VaksController : Controller
    {
        private readonly GiP1Context _context;

        public VaksController(GiP1Context context)
        {
            _context = context;
        }

        // GET: Vaks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vak.ToListAsync());
        }

        // GET: Vaks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vak = await _context.Vak
                .FirstOrDefaultAsync(m => m.Vakcode == id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // GET: Vaks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vakcode,Vaknaam,Studiepunten")] Vak vak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vak);
        }

        // GET: Vaks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vak = await _context.Vak.FindAsync(id);
            if (vak == null)
            {
                return NotFound();
            }
            return View(vak);
        }

        // POST: Vaks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Vakcode,Vaknaam,Studiepunten")] Vak vak)
        {
            if (id != vak.Vakcode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VakExists(vak.Vakcode))
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
            return View(vak);
        }

        // GET: Vaks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vak = await _context.Vak
                .FirstOrDefaultAsync(m => m.Vakcode == id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // POST: Vaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vak = await _context.Vak.FindAsync(id);
            _context.Vak.Remove(vak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VakExists(string id)
        {
            return _context.Vak.Any(e => e.Vakcode == id);
        }
    }
}
