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
    public class EpisodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }
        public ITVService TVService { get; }

        public EpisodesController(ApplicationDbContext context,
            IMyMDBService myMDBService,
            ITVService tVService)
        {
            _context = context;
            MyMDBService = myMDBService;
            TVService = tVService;
        }

        // GET: Admin/Episodes
        public async Task<IActionResult> Index()
        {
            return View(await TVService.GetAllEpisodes());
        }

        // GET: Admin/Episodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episode = await TVService.GetEpisodeById(id.Value);
            if (episode == null)
            {
                return NotFound();
            }

            return View(episode);
        }

        // GET: Admin/Episodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Episodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Episode episode)
        {
            if (ModelState.IsValid)
            {
                episode.Created = DateTime.Now.ToLocalTime();
                _context.Add(episode);
                await _context.SaveChangesAsync();

                var tvShow = await TVService.GetTVShowById(episode.TVShowId);
                tvShow.Episodes.Add(episode);
                _context.TVShows.Update(tvShow);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(episode);
        }

        // GET: Admin/Episodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episode = await TVService.GetEpisodeById(id.Value);
            if (episode == null)
            {
                return NotFound();
            }
            return View(episode);
        }

        // POST: Admin/Episodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Episode episode)
        {
            if (id != episode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    episode.Edited = DateTime.Now.ToLocalTime();
                    _context.Update(episode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpisodeExists(episode.Id))
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
            return View(episode);
        }

        // GET: Admin/Episodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episode = await TVService.GetEpisodeById(id.Value);
            if (episode == null)
            {
                return NotFound();
            }

            return View(episode);
        }

        // POST: Admin/Episodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var episode = await TVService.GetEpisodeById(id);
            _context.Episodes.Remove(episode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpisodeExists(int id)
        {
            return _context.Episodes.Any(e => e.Id == id);
        }
    }
}
