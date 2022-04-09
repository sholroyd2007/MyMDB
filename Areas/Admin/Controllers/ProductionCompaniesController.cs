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
    public class ProductionCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IProductionService ProductionService { get; }

        public ProductionCompaniesController(ApplicationDbContext context, 
            IProductionService productionService)
        {
            _context = context;
            ProductionService = productionService;
        }

        // GET: Admin/ProductionCompanies
        public async Task<IActionResult> Index()
        {
            return View(await ProductionService.GetAllProductionCompanies());
        }

        // GET: Admin/ProductionCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionCompany = await ProductionService.GetProductionCompanyById(id.Value);
            if (productionCompany == null)
            {
                return NotFound();
            }

            return View(productionCompany);
        }

        // GET: Admin/ProductionCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductionCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductionCompany productionCompany)
        {
            if (ModelState.IsValid)
            {
                await ProductionService.AddProductionCompany(productionCompany);
                return RedirectToAction(nameof(Index));
            }
            return View(productionCompany);
        }

        // GET: Admin/ProductionCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionCompany = await ProductionService.GetProductionCompanyById(id.Value);
            if (productionCompany == null)
            {
                return NotFound();
            }
            return View(productionCompany);
        }

        // POST: Admin/ProductionCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductionCompany productionCompany)
        {
            if (id != productionCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await ProductionService.EditProductionCompany(productionCompany);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionCompanyExists(productionCompany.Id))
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
            return View(productionCompany);
        }

        // GET: Admin/ProductionCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionCompany = await ProductionService.GetProductionCompanyById(id.Value);
            if (productionCompany == null)
            {
                return NotFound();
            }

            return View(productionCompany);
        }

        // POST: Admin/ProductionCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionCompany = await ProductionService.GetProductionCompanyById(id);
            await ProductionService.DeleteProductionCompany(productionCompany.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionCompanyExists(int id)
        {
            return _context.ProductionCompanies.Any(e => e.Id == id);
        }
    }
}
