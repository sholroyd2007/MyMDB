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
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IArticleService ArticleService { get; }

        public ArticlesController(ApplicationDbContext context,
            IArticleService articleService)
        {
            _context = context;
            ArticleService = articleService;
        }

        // GET: Admin/Articles
        public async Task<IActionResult> Index()
        {
            return View(await ArticleService.GetAllArticles());
        }

        // GET: Admin/Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await ArticleService.GetArticleById(id.Value);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Admin/Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Created,Edited,Deleted")] Article article)
        {
            if (ModelState.IsValid)
            {
                await ArticleService.AddArticle(article);
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Admin/Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await ArticleService.GetArticleById(id.Value);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Created,Edited,Deleted")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await ArticleService.EditArticle(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
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
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await ArticleService.GetArticleById(id.Value);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await ArticleService.GetArticleById(id);
            await ArticleService.DeleteArticle(article.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
