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
    public class MediaFilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MediaFilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/MediaFiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediaFiles.ToListAsync());
        }

        // GET: Admin/MediaFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFile = await _context.MediaFiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediaFile == null)
            {
                return NotFound();
            }

            return View(mediaFile);
        }

        // GET: Admin/MediaFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MediaFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Data,ContentType,MovieId,ActorId,TVShowId,EpisodeId,AwardId,GenreId,MovieSeriesId,MovieStudioId,Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] MediaFile mediaFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediaFile);
        }

        // GET: Admin/MediaFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFile = await _context.MediaFiles.FindAsync(id);
            if (mediaFile == null)
            {
                return NotFound();
            }
            return View(mediaFile);
        }

        // POST: Admin/MediaFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Data,ContentType,MovieId,ActorId,TVShowId,EpisodeId,AwardId,GenreId,MovieSeriesId,MovieStudioId,Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] MediaFile mediaFile)
        {
            if (id != mediaFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaFileExists(mediaFile.Id))
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
            return View(mediaFile);
        }

        // GET: Admin/MediaFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFile = await _context.MediaFiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediaFile == null)
            {
                return NotFound();
            }

            return View(mediaFile);
        }

        // POST: Admin/MediaFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaFile = await _context.MediaFiles.FindAsync(id);
            _context.MediaFiles.Remove(mediaFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaFileExists(int id)
        {
            return _context.MediaFiles.Any(e => e.Id == id);
        }
    }
}
