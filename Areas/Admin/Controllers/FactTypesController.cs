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
    public class FactTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FactTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/FactTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FactTypes.ToListAsync());
        }

        // GET: Admin/FactTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factType = await _context.FactTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factType == null)
            {
                return NotFound();
            }

            return View(factType);
        }

        // GET: Admin/FactTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FactTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FactType factType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factType);
        }

        // GET: Admin/FactTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factType = await _context.FactTypes.FindAsync(id);
            if (factType == null)
            {
                return NotFound();
            }
            return View(factType);
        }

        // POST: Admin/FactTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FactType factType)
        {
            if (id != factType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactTypeExists(factType.Id))
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
            return View(factType);
        }

        // GET: Admin/FactTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factType = await _context.FactTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factType == null)
            {
                return NotFound();
            }

            return View(factType);
        }

        // POST: Admin/FactTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factType = await _context.FactTypes.FindAsync(id);
            _context.FactTypes.Remove(factType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactTypeExists(int id)
        {
            return _context.FactTypes.Any(e => e.Id == id);
        }
    }
}
