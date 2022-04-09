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
    public class ListArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IArticleService ArticleService { get; }

        public ListArticlesController(ApplicationDbContext context,
            IArticleService articleService)
        {
            _context = context;
            ArticleService = articleService;
        }

        // GET: Admin/ListArticles
        public async Task<IActionResult> Index()
        {
            return View(await ArticleService.GetAllListArticles());
        }

        // GET: Admin/ListArticles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listArticle = await ArticleService.GetListArticleById(id.Value);
            if (listArticle == null)
            {
                return NotFound();
            }

            return View(listArticle);
        }

        // GET: Admin/ListArticles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ListArticles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Created,Edited,Deleted")] ListArticle listArticle)
        {
            if (ModelState.IsValid)
            {
                await ArticleService.AddListArticle(listArticle);
                return RedirectToAction(nameof(Index));
            }
            return View(listArticle);
        }

        // GET: Admin/ListArticles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listArticle = await ArticleService.GetListArticleById(id.Value);
            if (listArticle == null)
            {
                return NotFound();
            }
            return View(listArticle);
        }

        // POST: Admin/ListArticles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Created,Edited,Deleted")] ListArticle listArticle)
        {
            if (id != listArticle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await ArticleService.EditListArticle(listArticle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListArticleExists(listArticle.Id))
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
            return View(listArticle);
        }

        // GET: Admin/ListArticles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listArticle = await ArticleService.GetListArticleById(id.Value);
            if (listArticle == null)
            {
                return NotFound();
            }

            return View(listArticle);
        }

        // POST: Admin/ListArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listArticle = await ArticleService.GetListArticleById(id);
            await ArticleService.DeleteListArticle(listArticle.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool ListArticleExists(int id)
        {
            return _context.ListArticles.Any(e => e.Id == id);
        }
    }
}
