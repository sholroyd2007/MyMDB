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
    public class ProductionLinksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IProductionService ProductionService { get; }

        public ProductionLinksController(ApplicationDbContext context,
            IProductionService productionService)
        {
            _context = context;
            ProductionService = productionService;
        }

        // GET: Admin/ProductionLinks
        public async Task<IActionResult> Index()
        {
            return View(await ProductionService.GetAllProductionLinks());
        }

        // GET: Admin/ProductionLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionLink = await ProductionService.GetProductionLinkById(id.Value);
            if (productionLink == null)
            {
                return NotFound();
            }

            return View(productionLink);
        }

        // GET: Admin/ProductionLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductionLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductionLink productionLink)
        {
            if (ModelState.IsValid)
            {
                await ProductionService.AddProductionLink(productionLink);
                return RedirectToAction(nameof(Index));
            }
            
            return View(productionLink);
        }

        // GET: Admin/ProductionLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionLink = await ProductionService.GetProductionLinkById(id.Value);
            if (productionLink == null)
            {
                return NotFound();
            }
           
            return View(productionLink);
        }

        // POST: Admin/ProductionLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductionLink productionLink)
        {
            if (id != productionLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await ProductionService.EditProductionLink(productionLink);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionLinkExists(productionLink.Id))
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
            
            return View(productionLink);
        }

        // GET: Admin/ProductionLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionLink = await ProductionService.GetProductionLinkById(id.Value);
            if (productionLink == null)
            {
                return NotFound();
            }

            return View(productionLink);
        }

        // POST: Admin/ProductionLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionLink = await ProductionService.GetProductionLinkById(id);
            await ProductionService.DeleteProductionLink(productionLink.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionLinkExists(int id)
        {
            return _context.ProductionLinks.Any(e => e.Id == id);
        }
    }
}
