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
    public class TVShowsController : Controller
    {
        public ApplicationDbContext DatabaseContext { get; }
        public IMyMDBService MyMDBService { get; }
        public ITVService TVService { get; }

        public TVShowsController(ApplicationDbContext databaseContext,
            IMyMDBService myMDBService,
            ITVService tVService)
        {
            DatabaseContext = databaseContext;
            MyMDBService = myMDBService;
            TVService = tVService;
        }

        // GET: Admin/TVShows
        public async Task<IActionResult> Index()
        {
            return View(await TVService.GetAllTVShows());
        }

        // GET: Admin/TVShows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVShow = await TVService.GetTVShowById(id.Value);
            if (tVShow == null)
            {
                return NotFound();
            }

            return View(tVShow);
        }

        // GET: Admin/TVShows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TVShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TVShow tVShow)
        {
            if (ModelState.IsValid)
            {
                await TVService.AddTVShow(tVShow);
                return RedirectToAction(nameof(Index));
            }
            return View(tVShow);
        }

        // GET: Admin/TVShows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVShow = await TVService.GetTVShowById(id.Value);
            if (tVShow == null)
            {
                return NotFound();
            }
            return View(tVShow);
        }

        // POST: Admin/TVShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TVShow tVShow)
        {
            if (id != tVShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await TVService.EditTVShow(tVShow);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVShowExists(tVShow.Id))
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
            return View(tVShow);
        }

        // GET: Admin/TVShows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVShow = await TVService.GetTVShowById(id.Value);
            if (tVShow == null)
            {
                return NotFound();
            }

            return View(tVShow);
        }

        // POST: Admin/TVShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tVShow = await TVService.GetTVShowById(id);
            await TVService.DeleteTVShow(tVShow.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool TVShowExists(int id)
        {
            return DatabaseContext.TVShows.Any(e => e.Id == id);
        }
    }
}
