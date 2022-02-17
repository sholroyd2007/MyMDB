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
    public class MovieSeriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieSeriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/MovieSeries
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieSeries.ToListAsync());
        }

        // GET: Admin/MovieSeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieSeries = await _context.MovieSeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieSeries == null)
            {
                return NotFound();
            }

            return View(movieSeries);
        }

        // GET: Admin/MovieSeries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MovieSeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] MovieSeries movieSeries)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieSeries);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieSeries);
        }

        // GET: Admin/MovieSeries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieSeries = await _context.MovieSeries.FindAsync(id);
            if (movieSeries == null)
            {
                return NotFound();
            }
            return View(movieSeries);
        }

        // POST: Admin/MovieSeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] MovieSeries movieSeries)
        {
            if (id != movieSeries.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieSeries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieSeriesExists(movieSeries.Id))
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
            return View(movieSeries);
        }

        // GET: Admin/MovieSeries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieSeries = await _context.MovieSeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieSeries == null)
            {
                return NotFound();
            }

            return View(movieSeries);
        }

        // POST: Admin/MovieSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieSeries = await _context.MovieSeries.FindAsync(id);
            _context.MovieSeries.Remove(movieSeries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieSeriesExists(int id)
        {
            return _context.MovieSeries.Any(e => e.Id == id);
        }
    }
}
