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
using MyMDd;

namespace MyMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }
        public IMovieService MovieService { get; }

        public MoviesController(ApplicationDbContext context,
            IMyMDBService myMDBService,
            IMovieService movieService)
        {
            _context = context;
            MyMDBService = myMDBService;
            MovieService = movieService;
        }

        // GET: Admin/Movies
        public async Task<IActionResult> Index()
        {
            return View(await MovieService.GetAllMovies());
        }

        // GET: Admin/Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await MovieService.GetMovieById(id.Value);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Admin/Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Created = DateTime.Now.ToLocalTime();
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Admin/Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await MovieService.GetMovieById(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Admin/Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    movie.Edited = DateTime.Now.ToLocalTime();
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Admin/Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await MovieService.GetMovieById(id.Value);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Admin/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await MovieService.GetMovieById(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieToSeries(int id)
        {
            var movie = await MovieService.GetMovieById(id);
            var seriesId = Int32.Parse(Request.Form["movieSeriesId"]);
            var movieSeries = await MovieService.GetMovieSeriesById(seriesId);
            movieSeries.Movies.Add(movie);
            _context.MovieSeries.Update(movieSeries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { controller = "Movies", id = id });
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(int id)
        {
            var movie = await MovieService.GetMovieById(id);
            var genreId = Int32.Parse(Request.Form["genreId"]);
            var genre = await MyMDBService.GetGenreById(genreId);
            movie.Genres.Add(genre);
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { controller = "Movies", id = id });
        }

        public async Task<IActionResult> DeleteGenreFromMovie(int movieId, int genreId)
        {
            var movie = await MovieService.GetMovieById(movieId);
            var genre = await MyMDBService.GetGenreById(genreId);

            movie.Genres.Remove(genre);
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { controller = "Movies", id = movieId });
        }

        [HttpPost]
        public async Task<IActionResult> AddMediaFiles()
        {
            var movieId = int.Parse(HttpContext.Request.Form["movieId"]);
            var movie = await MovieService.GetMovieById(movieId);
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                if (file != null)
                {
                    var mediaFile = new MediaFile();

                    mediaFile.Data = file.OpenReadStream().ReadFully();
                    mediaFile.ContentType = file.ContentType;
                    mediaFile.Created = DateTime.Now.ToLocalTime();
                    mediaFile.MovieId = movie.Id;

                    _context.Add(mediaFile);
                    movie.MediaFiles.Add(mediaFile);
                    await _context.SaveChangesAsync();
                }

            }

            return RedirectToAction(nameof(Details), new { controller = "Movies", id = movieId });
        }
    }
}
