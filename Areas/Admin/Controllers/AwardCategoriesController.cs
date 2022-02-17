using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;

namespace MyMDB.Areas.Admin
{
    [Area("Admin")]
    public class AwardCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AwardCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AwardCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.AwardCategories.ToListAsync());
        }

        // GET: Admin/AwardCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardCategory = await _context.AwardCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awardCategory == null)
            {
                return NotFound();
            }

            return View(awardCategory);
        }

        // GET: Admin/AwardCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AwardCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] AwardCategory awardCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(awardCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(awardCategory);
        }

        // GET: Admin/AwardCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardCategory = await _context.AwardCategories.FindAsync(id);
            if (awardCategory == null)
            {
                return NotFound();
            }
            return View(awardCategory);
        }

        // POST: Admin/AwardCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] AwardCategory awardCategory)
        {
            if (id != awardCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(awardCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardCategoryExists(awardCategory.Id))
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
            return View(awardCategory);
        }

        // GET: Admin/AwardCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardCategory = await _context.AwardCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awardCategory == null)
            {
                return NotFound();
            }

            return View(awardCategory);
        }

        // POST: Admin/AwardCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var awardCategory = await _context.AwardCategories.FindAsync(id);
            _context.AwardCategories.Remove(awardCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardCategoryExists(int id)
        {
            return _context.AwardCategories.Any(e => e.Id == id);
        }
    }
}
