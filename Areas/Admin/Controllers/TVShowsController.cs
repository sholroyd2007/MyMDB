﻿using System;
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
    public class TVShowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TVShowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TVShows
        public async Task<IActionResult> Index()
        {
            return View(await _context.TVShows.ToListAsync());
        }

        // GET: Admin/TVShows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVShow = await _context.TVShows
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Creator,Active,Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] TVShow tVShow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tVShow);
                await _context.SaveChangesAsync();
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

            var tVShow = await _context.TVShows.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Creator,Active,Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] TVShow tVShow)
        {
            if (id != tVShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tVShow);
                    await _context.SaveChangesAsync();
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

            var tVShow = await _context.TVShows
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var tVShow = await _context.TVShows.FindAsync(id);
            _context.TVShows.Remove(tVShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TVShowExists(int id)
        {
            return _context.TVShows.Any(e => e.Id == id);
        }
    }
}