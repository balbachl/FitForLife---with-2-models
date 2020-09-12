using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitForLife.Models;

namespace FitForLife.Controllers
{
    public class StatController : Controller
    {
        private readonly FitnessContext _context;

        public StatController(FitnessContext context)
        {
            _context = context;
        }

        // GET: Stat
        public async Task<IActionResult> Index()
        {
            var fitnessContext = _context.Statistics.Include(s => s.Members);
            return View(await fitnessContext.ToListAsync());
        }

        // GET: Stat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stats = await _context.Statistics
                .Include(s => s.Members)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stats == null)
            {
                return NotFound();
            }
            ViewBag.bmi = stats.CalcBMI();
            return View(stats);
        }

        // GET: Stat/Create
        public IActionResult Create()
        {
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "name");
            return View();
        }

        // POST: Stat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,statDate,age,weight,height,MembersID")] Stats stats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "name", stats.MembersID);
            return View(stats);
        }

        // GET: Stat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stats = await _context.Statistics.FindAsync(id);
            if (stats == null)
            {
                return NotFound();
            }
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "name", stats.MembersID);
            return View(stats);
        }

        // POST: Stat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,statDate,age,weight,height,MembersID")] Stats stats)
        {
            if (id != stats.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatsExists(stats.ID))
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
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "name", stats.MembersID);
            return View(stats);
        }

        // GET: Stat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stats = await _context.Statistics
                .Include(s => s.Members)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stats == null)
            {
                return NotFound();
            }

            return View(stats);
        }

        // POST: Stat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stats = await _context.Statistics.FindAsync(id);
            _context.Statistics.Remove(stats);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatsExists(int id)
        {
            return _context.Statistics.Any(e => e.ID == id);
        }
    }
}
