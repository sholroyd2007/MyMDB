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
    public class GenreLinksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }

        public GenreLinksController(ApplicationDbContext context,
            IMyMDBService myMDBService)
        {
            _context = context;
            MyMDBService = myMDBService;
        }

        // GET: Admin/GenreLinks
        public async Task<IActionResult> Index()
        {
            return View(await MyMDBService.GetAllGenreLinks());
        }

        // GET: Admin/GenreLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreLink = await MyMDBService.GetGenreLinkById(id.Value);
            if (genreLink == null)
            {
                return NotFound();
            }

            return View(genreLink);
        }

        // GET: Admin/GenreLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/GenreLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GenreLink genreLink)
        {
            if (ModelState.IsValid)
            {
                await MyMDBService.AddGenreLink(genreLink);
                return RedirectToAction(nameof(Index));
            }
            
            return View(genreLink);
        }

        // GET: Admin/GenreLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreLink = await MyMDBService.GetGenreLinkById(id.Value);
            if (genreLink == null)
            {
                return NotFound();
            }
            
            return View(genreLink);
        }

        // POST: Admin/GenreLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GenreLink genreLink)
        {
            if (id != genreLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await MyMDBService.EditGenreLink(genreLink);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreLinkExists(genreLink.Id))
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
            
            return View(genreLink);
        }

        // GET: Admin/GenreLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreLink = await MyMDBService.GetGenreLinkById(id.Value);
            if (genreLink == null)
            {
                return NotFound();
            }

            return View(genreLink);
        }

        // POST: Admin/GenreLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genreLink = await MyMDBService.GetGenreLinkById(id);
            await MyMDBService.DeleteGenreLink(genreLink.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool GenreLinkExists(int id)
        {
            return _context.GenreLink.Any(e => e.Id == id);
        }
    }
}
