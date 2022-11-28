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
    public class FeaturedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeaturedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Featured
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Featured.Include(f => f.Movie).Include(f => f.TVShow);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Featured/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featured = await _context.Featured
                .Include(f => f.Movie)
                .Include(f => f.TVShow)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (featured == null)
            {
                return NotFound();
            }

            return View(featured);
        }

        // GET: Admin/Featured/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            ViewData["TVShowId"] = new SelectList(_context.TVShows, "Id", "Id");
            return View();
        }

        // POST: Admin/Featured/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,TVShowId,Banner,Recommended,EditorPick,Id,Name,Description,Created,Edited,Deleted")] Featured featured)
        {
            if (ModelState.IsValid)
            {
                _context.Add(featured);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", featured.MovieId);
            ViewData["TVShowId"] = new SelectList(_context.TVShows, "Id", "Id", featured.TVShowId);
            return View(featured);
        }

        // GET: Admin/Featured/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featured = await _context.Featured.FindAsync(id);
            if (featured == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", featured.MovieId);
            ViewData["TVShowId"] = new SelectList(_context.TVShows, "Id", "Id", featured.TVShowId);
            return View(featured);
        }

        // POST: Admin/Featured/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,TVShowId,Banner,Recommended,EditorPick,Id,Name,Description,Created,Edited,Deleted")] Featured featured)
        {
            if (id != featured.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featured);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturedExists(featured.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", featured.MovieId);
            ViewData["TVShowId"] = new SelectList(_context.TVShows, "Id", "Id", featured.TVShowId);
            return View(featured);
        }

        // GET: Admin/Featured/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featured = await _context.Featured
                .Include(f => f.Movie)
                .Include(f => f.TVShow)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (featured == null)
            {
                return NotFound();
            }

            return View(featured);
        }

        // POST: Admin/Featured/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var featured = await _context.Featured.FindAsync(id);
            _context.Featured.Remove(featured);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeaturedExists(int id)
        {
            return _context.Featured.Any(e => e.Id == id);
        }
    }
}
