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
    public class CastCrewMembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }
        public IJobService JobService { get; }

        public CastCrewMembersController(ApplicationDbContext context,
            IMyMDBService myMDBService,
            IJobService jobService)
        {
            _context = context;
            MyMDBService = myMDBService;
            JobService = jobService;
        }

        // GET: Admin/CastCrewMembers
        public async Task<IActionResult> Index()
        {
            var castCrewMembers = await JobService.GetAllCastCrewMembers();
            return View(castCrewMembers);
        }

        // GET: Admin/CastCrewMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castCrewMember = await JobService.GetCastCrewMemberById(id.Value);
            if (castCrewMember == null)
            {
                return NotFound();
            }

            return View(castCrewMember);
        }

        // GET: Admin/CastCrewMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CastCrewMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CastCrewMember castCrewMember)
        {
            if (ModelState.IsValid)
            {
                castCrewMember.Created = DateTime.Now.ToLocalTime();
                _context.Add(castCrewMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(castCrewMember);
        }

        // GET: Admin/CastCrewMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castCrewMember = await JobService.GetCastCrewMemberById(id.Value);
            if (castCrewMember == null)
            {
                return NotFound();
            }
            return View(castCrewMember);
        }

        // POST: Admin/CastCrewMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CastCrewMember castCrewMember)
        {
            if (id != castCrewMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    castCrewMember.Edited = DateTime.Now.ToLocalTime(); 
                    _context.Update(castCrewMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CastCrewMemberExists(castCrewMember.Id))
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
            return View(castCrewMember);
        }

        // GET: Admin/CastCrewMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var castCrewMember = await JobService.GetCastCrewMemberById(id.Value);
            if (castCrewMember == null)
            {
                return NotFound();
            }

            return View(castCrewMember);
        }

        // POST: Admin/CastCrewMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var castCrewMember = await JobService.GetCastCrewMemberById(id);
            _context.Actors.Remove(castCrewMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CastCrewMemberExists(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}
