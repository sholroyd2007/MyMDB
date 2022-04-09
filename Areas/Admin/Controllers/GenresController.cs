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
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }

        public GenresController(ApplicationDbContext context,
            IMyMDBService myMDBService)
        {
            _context = context;
            MyMDBService = myMDBService;
        }

        // GET: Admin/Genres
        public async Task<IActionResult> Index()
        {
            return View(await MyMDBService.GetAllGenres());
        }

        // GET: Admin/Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await MyMDBService.GetGenreById(id.Value);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Admin/Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                await MyMDBService.AddGenre(genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Admin/Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await MyMDBService.GetGenreById(id.Value);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Admin/Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await MyMDBService.EditGenre(genre);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.Id))
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
            return View(genre);
        }

        // GET: Admin/Genres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await MyMDBService.GetGenreById(id.Value);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Admin/Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genre = await MyMDBService.GetGenreById(id);
            await MyMDBService.DeleteGenre(genre.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }
    }
}
