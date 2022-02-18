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
    public class FactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }

        public FactsController(ApplicationDbContext context,
            IMyMDBService myMDBService)
        {
            _context = context;
            MyMDBService = myMDBService;
        }

        // GET: Admin/Facts
        public async Task<IActionResult> Index()
        {
            return View(await MyMDBService.GetAllFacts());
        }

        // GET: Admin/Facts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await MyMDBService.GetFactById(id.Value);
            if (fact == null)
            {
                return NotFound();
            }

            return View(fact);
        }

        // GET: Admin/Facts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Facts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fact fact)
        {
            if (ModelState.IsValid)
            {
                fact.Created = DateTime.Now.ToLocalTime();
                _context.Add(fact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fact);
        }

        // GET: Admin/Facts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await MyMDBService.GetFactById(id.Value);
            if (fact == null)
            {
                return NotFound();
            }
            return View(fact);
        }

        // POST: Admin/Facts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fact fact)
        {
            if (id != fact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    fact.Edited = DateTime.Now.ToLocalTime();
                    _context.Update(fact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactExists(fact.Id))
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
            return View(fact);
        }

        // GET: Admin/Facts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await MyMDBService.GetFactById(id.Value);
            if (fact == null)
            {
                return NotFound();
            }

            return View(fact);
        }

        // POST: Admin/Facts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fact = await MyMDBService.GetFactById(id);
            _context.Facts.Remove(fact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactExists(int id)
        {
            return _context.Facts.Any(e => e.Id == id);
        }
    }
}
