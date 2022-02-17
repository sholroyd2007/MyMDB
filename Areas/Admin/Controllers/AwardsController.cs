using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;

namespace MyMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AwardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AwardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Awards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Awards.ToListAsync());
        }

        // GET: Admin/Awards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _context.Awards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // GET: Admin/Awards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Awards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] Award award)
        {
            if (ModelState.IsValid)
            {
                _context.Add(award);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(award);
        }

        // GET: Admin/Awards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _context.Awards.FindAsync(id);
            if (award == null)
            {
                return NotFound();
            }
            return View(award);
        }

        // POST: Admin/Awards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] Award award)
        {
            if (id != award.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(award);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardExists(award.Id))
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
            return View(award);
        }

        // GET: Admin/Awards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _context.Awards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // POST: Admin/Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var award = await _context.Awards.FindAsync(id);
            _context.Awards.Remove(award);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardExists(int id)
        {
            return _context.Awards.Any(e => e.Id == id);
        }
    }
}
