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
    public class MovieStudiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieStudiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/MovieStudios
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieStudios.ToListAsync());
        }

        // GET: Admin/MovieStudios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieStudio = await _context.MovieStudios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieStudio == null)
            {
                return NotFound();
            }

            return View(movieStudio);
        }

        // GET: Admin/MovieStudios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MovieStudios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] MovieStudio movieStudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieStudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieStudio);
        }

        // GET: Admin/MovieStudios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieStudio = await _context.MovieStudios.FindAsync(id);
            if (movieStudio == null)
            {
                return NotFound();
            }
            return View(movieStudio);
        }

        // POST: Admin/MovieStudios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] MovieStudio movieStudio)
        {
            if (id != movieStudio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieStudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieStudioExists(movieStudio.Id))
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
            return View(movieStudio);
        }

        // GET: Admin/MovieStudios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieStudio = await _context.MovieStudios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieStudio == null)
            {
                return NotFound();
            }

            return View(movieStudio);
        }

        // POST: Admin/MovieStudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieStudio = await _context.MovieStudios.FindAsync(id);
            _context.MovieStudios.Remove(movieStudio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieStudioExists(int id)
        {
            return _context.MovieStudios.Any(e => e.Id == id);
        }
    }
}
