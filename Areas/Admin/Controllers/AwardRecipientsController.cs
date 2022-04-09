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
    public class AwardRecipientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }
        public IAwardService AwardService { get; }
        public ITVService TVService { get; }
        public IMovieService MovieService { get; }

        public AwardRecipientsController(ApplicationDbContext context,
            IMyMDBService myMDBService,
            IAwardService awardService,
            ITVService tVService,
            IMovieService movieService,
            IMyMDBService MyMDBService)
        {
            _context = context;
            MyMDBService = myMDBService;
            AwardService = awardService;
            TVService = tVService;
            MovieService = movieService;
        }

        // GET: Admin/AwardRecipients
        public async Task<IActionResult> Index()
        {
            var recipients = await AwardService.GetAllAwardRecipients();
            return View(recipients);
        }

        // GET: Admin/AwardRecipients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardRecipient = await AwardService.GetAwardRecipientById(id.Value);
            if (awardRecipient == null)
            {
                return NotFound();
            }

            return View(awardRecipient);
        }

        // GET: Admin/AwardRecipients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AwardRecipients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AwardRecipient awardRecipient)
        {
            if (ModelState.IsValid)
            {
                await AwardService.AddAwardRecipient(awardRecipient);
                return RedirectToAction(nameof(Index));
            }
            return View(awardRecipient);
        }

        // GET: Admin/AwardRecipients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardRecipient = await AwardService.GetAwardRecipientById(id.Value);
            if (awardRecipient == null)
            {
                return NotFound();
            }
            return View(awardRecipient);
        }

        // POST: Admin/AwardRecipients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AwardRecipient awardRecipient)
        {
            if (id != awardRecipient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await AwardService.EditAwardRecipient(awardRecipient);
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
            return View(awardRecipient);
        }

        // GET: Admin/AwardRecipients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardRecipient = await AwardService.GetAwardRecipientById(id.Value);
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
            var awardRecipient = await AwardService.GetAwardRecipientById(id);
            await AwardService.DeleteAwardRecipient(awardRecipient.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool AwardRecipientExists(int id)
        {
            return _context.ActorAwards.Any(e => e.Id == id);
        }
    }
}
