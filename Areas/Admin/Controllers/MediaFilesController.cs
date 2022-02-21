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
using MyMDd;

namespace MyMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MediaFilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMyMDBService MyMDBService { get; }

        public MediaFilesController(ApplicationDbContext context,
            IMyMDBService myMDBService)
        {
            _context = context;
            MyMDBService = myMDBService;
        }

        // GET: Admin/MediaFiles
        public async Task<IActionResult> Index()
        {
            return View(await MyMDBService.GetAllMediaFiles());
        }

        // GET: Admin/MediaFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFile = await MyMDBService.GetMediaFileById(id.Value);
            if (mediaFile == null)
            {
                return NotFound();
            }

            return View(mediaFile);
        }

        // GET: Admin/MediaFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MediaFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MediaFile mediaFile)
        {
            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files.FirstOrDefault();
                if (file != null)
                {
                    mediaFile.Data = file.OpenReadStream().ReadFully();
                    mediaFile.ContentType = file.ContentType;
                    mediaFile.Created = DateTime.Now.ToLocalTime();
                }

                _context.Add(mediaFile);
                await _context.SaveChangesAsync();

                if (mediaFile.MovieId != null)
                {
                    var movie = await MyMDBService.GetMovieById(mediaFile.MovieId.Value);
                    movie.MediaFiles.Add(mediaFile);
                    _context.Movies.Update(movie);
                    await _context.SaveChangesAsync();
                }

                if (mediaFile.CastCrewMemberId != null)
                {
                    var castCrewMember = await MyMDBService.GetCastCrewMemberById(mediaFile.CastCrewMemberId.Value);
                    castCrewMember.MediaFiles.Add(mediaFile);
                    _context.CastCrewMember.Update(castCrewMember);
                    await _context.SaveChangesAsync();
                }

                if (mediaFile.CharacterId != null)
                {
                    var character = await MyMDBService.GetCharacterById(mediaFile.CharacterId.Value);
                    character.MediaFiles.Add(mediaFile);
                    _context.Characters.Update(character);
                    await _context.SaveChangesAsync();
                }

                if (mediaFile.TVShowId != null)
                {
                    var tvShow = await MyMDBService.GetTVShowById(mediaFile.TVShowId.Value);
                    tvShow.MediaFiles.Add(mediaFile);
                    _context.TVShows.Update(tvShow);
                    await _context.SaveChangesAsync();
                }

                if (mediaFile.EpisodeId != null)
                {
                    var episode = await MyMDBService.GetEpisodeById(mediaFile.EpisodeId.Value);
                    episode.MediaFiles.Add(mediaFile);
                    _context.Episodes.Update(episode);
                    await _context.SaveChangesAsync();
                }

                if (mediaFile.AwardId != null)
                {
                    var award = await MyMDBService.GetAwardById(mediaFile.AwardId.Value);
                    award.MediaFiles.Add(mediaFile);
                    _context.Awards.Update(award);
                    await _context.SaveChangesAsync();
                }

                if (mediaFile.GenreId != null)
                {
                    var genre = await MyMDBService.GetGenreById(mediaFile.GenreId.Value);
                    genre.MediaFiles.Add(mediaFile);
                    _context.Genres.Update(genre);
                    await _context.SaveChangesAsync();
                }

                if (mediaFile.MovieSeriesId != null)
                {
                    var series = await MyMDBService.GetMovieSeriesById(mediaFile.MovieSeriesId.Value);
                    series.MediaFiles.Add(mediaFile);
                    _context.MovieSeries.Update(series);
                    await _context.SaveChangesAsync();
                }

                if (mediaFile.MovieStudioId != null)
                {
                    var studio = await MyMDBService.GetMovieStudioById(mediaFile.MovieStudioId.Value);
                    studio.MediaFiles.Add(mediaFile);
                    _context.MovieStudios.Update(studio);
                    await _context.SaveChangesAsync();
                }


                return RedirectToAction(nameof(Index));
            }
            return View(mediaFile);
        }

        // GET: Admin/MediaFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFile = await MyMDBService.GetMediaFileById(id.Value);
            if (mediaFile == null)
            {
                return NotFound();
            }
            return View(mediaFile);
        }

        // POST: Admin/MediaFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MediaFile mediaFile)
        {
            if (id != mediaFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var file = HttpContext.Request.Form.Files.FirstOrDefault();
                    if (file != null)
                    {
                        mediaFile.Data = file.OpenReadStream().ReadFully();
                        mediaFile.ContentType = file.ContentType;
                        
                    }

                    mediaFile.Edited = DateTime.Now.ToLocalTime();
                    _context.Update(mediaFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaFileExists(mediaFile.Id))
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
            return View(mediaFile);
        }

        // GET: Admin/MediaFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFile = await MyMDBService.GetMediaFileById(id.Value);
            if (mediaFile == null)
            {
                return NotFound();
            }

            return View(mediaFile);
        }

        // POST: Admin/MediaFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaFile = await MyMDBService.GetMediaFileById(id);
            _context.MediaFiles.Remove(mediaFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaFileExists(int id)
        {
            return _context.MediaFiles.Any(e => e.Id == id);
        }
    }
}
