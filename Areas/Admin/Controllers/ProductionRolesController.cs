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
    public class ProductionRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }
        public IMovieService MovieService { get; }
        public ITVService TVService { get; }

        public ProductionRolesController(ApplicationDbContext context,
            IMyMDBService myMDBService,
            IMovieService movieService,
            ITVService tVService)
        {
            _context = context;
            MyMDBService = myMDBService;
            MovieService = movieService;
            TVService = tVService;
        }

        // GET: Admin/ProductionRoles
        public async Task<IActionResult> Index()
        {
            return View(await MyMDBService.GetAllProductionRoles());
        }

        // GET: Admin/ProductionRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionRole = await MyMDBService.GetProductionRoleById(id.Value);
            if (productionRole == null)
            {
                return NotFound();
            }

            return View(productionRole);
        }

        // GET: Admin/ProductionRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductionRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductionRole productionRole)
        {
            if (ModelState.IsValid)
            {
                await MyMDBService.AddProductionRole(productionRole);

                return RedirectToAction(nameof(Index));
            }
            
            return View(productionRole);
        }

        // GET: Admin/ProductionRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionRole = await MyMDBService.GetProductionRoleById(id.Value);
            if (productionRole == null)
            {
                return NotFound();
            }
            return View(productionRole);
        }

        // POST: Admin/ProductionRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductionRole productionRole)
        {
            if (id != productionRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await MyMDBService.EditProductionRole(productionRole);
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
            return View(productionRole);
        }

        // GET: Admin/ProductionRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionRole = await MyMDBService.GetProductionRoleById(id.Value);
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
            var productionRole = await MyMDBService.GetProductionRoleById(id);
            await MyMDBService.DeleteProductionRole(productionRole.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionRoleExists(int id)
        {
            return _context.ProductionRoles.Any(e => e.Id == id);
        }
    }
}
