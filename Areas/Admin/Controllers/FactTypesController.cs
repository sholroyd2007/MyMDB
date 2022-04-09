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
    public class FactTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }

        public FactTypesController(ApplicationDbContext context,
            IMyMDBService myMDBService)
        {
            _context = context;
            MyMDBService = myMDBService;
        }

        // GET: Admin/FactTypes
        public async Task<IActionResult> Index()
        {
            return View(await MyMDBService.GetAllFactTypes());
        }

        // GET: Admin/FactTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factType = await MyMDBService.GetFactTypeById(id.Value);
            if (factType == null)
            {
                return NotFound();
            }

            return View(factType);
        }

        // GET: Admin/FactTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FactTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FactType factType)
        {
            if (ModelState.IsValid)
            {
                await MyMDBService.AddFactType(factType);
                return RedirectToAction(nameof(Index));
            }
            return View(factType);
        }

        // GET: Admin/FactTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factType = await MyMDBService.GetFactTypeById(id.Value);
            if (factType == null)
            {
                return NotFound();
            }
            return View(factType);
        }

        // POST: Admin/FactTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FactType factType)
        {
            if (id != factType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await MyMDBService.EditFactType(factType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactTypeExists(factType.Id))
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
            return View(factType);
        }

        // GET: Admin/FactTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factType = await MyMDBService.GetFactTypeById(id.Value);
            if (factType == null)
            {
                return NotFound();
            }

            return View(factType);
        }

        // POST: Admin/FactTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factType = await MyMDBService.GetFactTypeById(id);
            await MyMDBService.DeleteFactType(factType.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool FactTypeExists(int id)
        {
            return _context.FactTypes.Any(e => e.Id == id);
        }
    }
}
