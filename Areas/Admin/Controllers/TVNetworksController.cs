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
    public class TVNetworksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IProductionService ProductionService { get; }

        public TVNetworksController(ApplicationDbContext context,
            IProductionService productionService)
        {
            _context = context;
            ProductionService = productionService;
        }

        // GET: Admin/TVNetworks
        public async Task<IActionResult> Index()
        {
            return View(await ProductionService.GetAllTVNetworks());
        }

        // GET: Admin/TVNetworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVNetwork = await ProductionService.GetTVNetworkById(id.Value);
            if (tVNetwork == null)
            {
                return NotFound();
            }

            return View(tVNetwork);
        }

        // GET: Admin/TVNetworks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TVNetworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TVNetwork tVNetwork)
        {
            if (ModelState.IsValid)
            {
                await ProductionService.AddTVNetwork(tVNetwork);
                return RedirectToAction(nameof(Index));
            }
            return View(tVNetwork);
        }

        // GET: Admin/TVNetworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVNetwork = await ProductionService.GetTVNetworkById(id.Value);
            if (tVNetwork == null)
            {
                return NotFound();
            }
            return View(tVNetwork);
        }

        // POST: Admin/TVNetworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TVNetwork tVNetwork)
        {
            if (id != tVNetwork.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await ProductionService.EditTVNetwork(tVNetwork);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVNetworkExists(tVNetwork.Id))
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
            return View(tVNetwork);
        }

        // GET: Admin/TVNetworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVNetwork = await ProductionService.GetTVNetworkById(id.Value);
            if (tVNetwork == null)
            {
                return NotFound();
            }

            return View(tVNetwork);
        }

        // POST: Admin/TVNetworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tVNetwork = await ProductionService.GetTVNetworkById(id);
            await ProductionService.DeleteTVNetwork(tVNetwork.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool TVNetworkExists(int id)
        {
            return _context.TVNetworks.Any(e => e.Id == id);
        }
    }
}
