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
    public class SeriesMoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMovieService MovieService { get; }

        public SeriesMoviesController(ApplicationDbContext context,
            IMovieService movieService)
        {
            _context = context;
            MovieService = movieService;
        }

        // GET: Admin/SeriesMovies
        public async Task<IActionResult> Index()
        {
            return View(await MovieService.GetAllSeriesMovies());
        }

        // GET: Admin/SeriesMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesMovie = await MovieService.GetSeriesMovieById(id.Value);
            if (seriesMovie == null)
            {
                return NotFound();
            }

            return View(seriesMovie);
        }

        // GET: Admin/SeriesMovies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SeriesMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SeriesMovie seriesMovie)
        {
            if (ModelState.IsValid)
            {
                await MovieService.AddSeriesMovie(seriesMovie);
                return RedirectToAction(nameof(Index));
            }
            
            return View(seriesMovie);
        }

        // GET: Admin/SeriesMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesMovie = await MovieService.GetSeriesMovieById(id.Value);
            if (seriesMovie == null)
            {
                return NotFound();
            }
            
            return View(seriesMovie);
        }

        // POST: Admin/SeriesMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeriesId,MovieId,Id,Name,Description,Created,Edited,Deleted")] SeriesMovie seriesMovie)
        {
            if (id != seriesMovie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await MovieService.EditSeriesMovie(seriesMovie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesMovieExists(seriesMovie.Id))
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
            
            return View(seriesMovie);
        }

        // GET: Admin/SeriesMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesMovie = await MovieService.GetSeriesMovieById(id.Value);
            if (seriesMovie == null)
            {
                return NotFound();
            }

            return View(seriesMovie);
        }

        // POST: Admin/SeriesMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seriesMovie = await MovieService.GetSeriesMovieById(id);
            await MovieService.DeleteSeriesMovie(seriesMovie.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool SeriesMovieExists(int id)
        {
            return _context.SeriesMovie.Any(e => e.Id == id);
        }
    }
}
