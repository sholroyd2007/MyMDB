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
    public class ProductionRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductionRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductionRoles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductionRoles.Include(p => p.Character).Include(p => p.Episode).Include(p => p.JobRole).Include(p => p.Movie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/ProductionRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionRole = await _context.ProductionRoles
                .Include(p => p.Character)
                .Include(p => p.Episode)
                .Include(p => p.JobRole)
                .Include(p => p.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productionRole == null)
            {
                return NotFound();
            }

            return View(productionRole);
        }

        // GET: Admin/ProductionRoles/Create
        public IActionResult Create()
        {
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id");
            ViewData["EpisodeId"] = new SelectList(_context.Episodes, "Id", "Id");
            ViewData["JobRoleId"] = new SelectList(_context.JobRoles, "Id", "Id");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            return View();
        }

        // POST: Admin/ProductionRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CastCrewMemberId,JobRoleId,CharacterId,MovieId,EpisodeId,CreditOnly,Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] ProductionRole productionRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", productionRole.CharacterId);
            ViewData["EpisodeId"] = new SelectList(_context.Episodes, "Id", "Id", productionRole.EpisodeId);
            ViewData["JobRoleId"] = new SelectList(_context.JobRoles, "Id", "Id", productionRole.JobRoleId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", productionRole.MovieId);
            return View(productionRole);
        }

        // GET: Admin/ProductionRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionRole = await _context.ProductionRoles.FindAsync(id);
            if (productionRole == null)
            {
                return NotFound();
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", productionRole.CharacterId);
            ViewData["EpisodeId"] = new SelectList(_context.Episodes, "Id", "Id", productionRole.EpisodeId);
            ViewData["JobRoleId"] = new SelectList(_context.JobRoles, "Id", "Id", productionRole.JobRoleId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", productionRole.MovieId);
            return View(productionRole);
        }

        // POST: Admin/ProductionRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CastCrewMemberId,JobRoleId,CharacterId,MovieId,EpisodeId,CreditOnly,Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] ProductionRole productionRole)
        {
            if (id != productionRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionRoleExists(productionRole.Id))
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
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", productionRole.CharacterId);
            ViewData["EpisodeId"] = new SelectList(_context.Episodes, "Id", "Id", productionRole.EpisodeId);
            ViewData["JobRoleId"] = new SelectList(_context.JobRoles, "Id", "Id", productionRole.JobRoleId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", productionRole.MovieId);
            return View(productionRole);
        }

        // GET: Admin/ProductionRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionRole = await _context.ProductionRoles
                .Include(p => p.Character)
                .Include(p => p.Episode)
                .Include(p => p.JobRole)
                .Include(p => p.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productionRole == null)
            {
                return NotFound();
            }

            return View(productionRole);
        }

        // POST: Admin/ProductionRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionRole = await _context.ProductionRoles.FindAsync(id);
            _context.ProductionRoles.Remove(productionRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionRoleExists(int id)
        {
            return _context.ProductionRoles.Any(e => e.Id == id);
        }
    }
}
