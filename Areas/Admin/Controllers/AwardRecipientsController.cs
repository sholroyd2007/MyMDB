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
    public class AwardRecipientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AwardRecipientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AwardRecipients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ActorAwards.Include(a => a.Award).Include(a => a.AwardCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/AwardRecipients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardRecipient = await _context.ActorAwards
                .Include(a => a.Award)
                .Include(a => a.AwardCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awardRecipient == null)
            {
                return NotFound();
            }

            return View(awardRecipient);
        }

        // GET: Admin/AwardRecipients/Create
        public IActionResult Create()
        {
            ViewData["AwardId"] = new SelectList(_context.Awards, "Id", "Id");
            ViewData["AwardCategoryId"] = new SelectList(_context.AwardCategories, "Id", "Id");
            return View();
        }

        // POST: Admin/AwardRecipients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AwardId,AwardCategoryId,Year,Win,CastCrewMemberId,EpisodeId,TVShowId,MovieId,Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] AwardRecipient awardRecipient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(awardRecipient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwardId"] = new SelectList(_context.Awards, "Id", "Id", awardRecipient.AwardId);
            ViewData["AwardCategoryId"] = new SelectList(_context.AwardCategories, "Id", "Id", awardRecipient.AwardCategoryId);
            return View(awardRecipient);
        }

        // GET: Admin/AwardRecipients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardRecipient = await _context.ActorAwards.FindAsync(id);
            if (awardRecipient == null)
            {
                return NotFound();
            }
            ViewData["AwardId"] = new SelectList(_context.Awards, "Id", "Id", awardRecipient.AwardId);
            ViewData["AwardCategoryId"] = new SelectList(_context.AwardCategories, "Id", "Id", awardRecipient.AwardCategoryId);
            return View(awardRecipient);
        }

        // POST: Admin/AwardRecipients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AwardId,AwardCategoryId,Year,Win,CastCrewMemberId,EpisodeId,TVShowId,MovieId,Id,Name,Description,Created,Edited,Deleted,Recommended,Language,Website")] AwardRecipient awardRecipient)
        {
            if (id != awardRecipient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(awardRecipient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardRecipientExists(awardRecipient.Id))
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
            ViewData["AwardId"] = new SelectList(_context.Awards, "Id", "Id", awardRecipient.AwardId);
            ViewData["AwardCategoryId"] = new SelectList(_context.AwardCategories, "Id", "Id", awardRecipient.AwardCategoryId);
            return View(awardRecipient);
        }

        // GET: Admin/AwardRecipients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardRecipient = await _context.ActorAwards
                .Include(a => a.Award)
                .Include(a => a.AwardCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awardRecipient == null)
            {
                return NotFound();
            }

            return View(awardRecipient);
        }

        // POST: Admin/AwardRecipients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var awardRecipient = await _context.ActorAwards.FindAsync(id);
            _context.ActorAwards.Remove(awardRecipient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardRecipientExists(int id)
        {
            return _context.ActorAwards.Any(e => e.Id == id);
        }
    }
}
