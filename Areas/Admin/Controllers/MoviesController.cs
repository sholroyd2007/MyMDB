﻿using System;
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
        public ApplicationDbContext DatabaseContext { get; }
        public IMyMDBService MyMDBService { get; }
        public IMovieService MovieService { get; }

        public MoviesController(ApplicationDbContext databaseContext,
            IMyMDBService myMDBService,
            IMovieService movieService)
        {
            DatabaseContext = databaseContext;
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
                await MovieService.AddMovie(movie);
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
                    await MovieService.EditMovie(movie);
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
            await MovieService.DeleteMovie(movie.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return DatabaseContext.Movies.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieToSeries(int id)
        {
            var movie = await MovieService.GetMovieById(id);
            var seriesId = Int32.Parse(Request.Form["movieSeriesId"]);
            var movieSeries = await MovieService.GetMovieSeriesById(seriesId);
            movieSeries.Movies.Add(movie);
            DatabaseContext.MovieSeries.Update(movieSeries);
            await DatabaseContext.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { controller = "Movies", id = id });
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(int id, [FromForm]int genreId)
        {
            var movie = await MovieService.GetMovieById(id);
            var genre = await MyMDBService.GetGenreById(genreId);
            movie.Genres.Add(genre);
            DatabaseContext.Movies.Update(movie);
            await DatabaseContext.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { controller = "Movies", id = id });
        }

        public async Task<IActionResult> DeleteGenreFromMovie(int movieId, int genreId)
        {
            var movie = await MovieService.GetMovieById(movieId);
            var genre = await MyMDBService.GetGenreById(genreId);

            movie.Genres.Remove(genre);
            DatabaseContext.Movies.Update(movie);
            await DatabaseContext.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { controller = "Movies", id = movieId });
        }

        
        
    }
}
