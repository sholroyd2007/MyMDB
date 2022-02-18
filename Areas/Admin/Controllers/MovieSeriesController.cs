using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using MyMDB.Services;

namespace MyMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieSeriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }

        public MovieSeriesController(ApplicationDbContext context,
            IMyMDBService myMDBService)
        {
            _context = context;
            MyMDBService = myMDBService;
        }

        // GET: Admin/MovieSeries
        public async Task<IActionResult> Index()
        {
            return View(await MyMDBService.GetAllMovieSeries());
        }

        // GET: Admin/MovieSeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieSeries = await MyMDBService.GetMovieStudioById(id.Value);
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
        public async Task<IActionResult> Create(MovieSeries movieSeries)
        {
            if (ModelState.IsValid)
            {
                movieSeries.Created = DateTime.Now.ToLocalTime();
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

            var movieSeries = await MyMDBService.GetMovieSeriesById(id.Value);
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
        public async Task<IActionResult> Edit(int id, MovieSeries movieSeries)
        {
            if (id != movieSeries.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    movieSeries.Edited = DateTime.Now.ToLocalTime();
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

            var movieSeries = await MyMDBService.GetMovieSeriesById(id.Value);
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
            var movieSeries = await MyMDBService.GetMovieSeriesById(id);
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
