using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using MyMDB.Services;

namespace MyMDB.Areas.Admin
{
    [Area("Admin")]
    public class JobRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }

        public JobRolesController(ApplicationDbContext context,
            IMyMDBService myMDBService)
        {
            _context = context;
            MyMDBService = myMDBService;
        }

        // GET: Admin/JobRoles
        public async Task<IActionResult> Index()
        {
            return View(await MyMDBService.GetAllJobRoles());
        }

        // GET: Admin/JobRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awardCategory = await MyMDBService.GetJobRoleById(id.Value);
            if (awardCategory == null)
            {
                return NotFound();
            }

            return View(awardCategory);
        }

        // GET: Admin/JobRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AwardCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobRole jobRole)
        {
            if (ModelState.IsValid)
            {
                jobRole.Created = DateTime.Now.ToLocalTime();
                _context.Add(jobRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobRole);
        }

        // GET: Admin/JobRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobRole = await MyMDBService.GetJobRoleById(id.Value);
            if (jobRole == null)
            {
                return NotFound();
            }
            return View(jobRole);
        }

        // POST: Admin/JobRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JobRole jobRole)
        {
            if (id != jobRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    jobRole.Edited = DateTime.Now.ToLocalTime();
                    _context.Update(jobRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobRoleExists(jobRole.Id))
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
            return View(jobRole);
        }

        // GET: Admin/JobRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobRole = await MyMDBService.GetJobRoleById(id.Value);
            if (jobRole == null)
            {
                return NotFound();
            }

            return View(jobRole);
        }

        // POST: Admin/JobRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobRole = await MyMDBService.GetJobRoleById(id);
            _context.JobRoles.Remove(jobRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobRoleExists(int id)
        {
            return _context.JobRoles.Any(e => e.Id == id);
        }
    }
}
