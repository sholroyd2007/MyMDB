using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMDB.Services
{
    public interface IMediaService
    {
        Task<MediaFile> GetMediaFileById(int id);
        Task<IEnumerable<MediaFile>> GetAllMediaFiles();
        Task<IEnumerable<MediaFile>> GetMediaFilesByMovieId(int id);
        Task<IEnumerable<MediaFile>> GetMediaFilesByCastCrewMemberId(int id);
        Task<IEnumerable<MediaFile>> GetMediaFilesByCharacterId(int id);
        Task<IEnumerable<MediaFile>> GetMediaFilesByTVShowId(int id);
        Task<IEnumerable<MediaFile>> GetMediaFilesByEpisodeId(int id);
        Task<IEnumerable<MediaFile>> GetMediaFilesByAwardId(int id);
        Task<IEnumerable<MediaFile>> GetMediaFilesByGenreId(int id);
        Task<IEnumerable<MediaFile>> GetMediaFilesByMovieSeriesId(int id);
        Task<IEnumerable<MediaFile>> GetMediaFilesByMovieStudioId(int id);
    }

    public class MediaService : IMediaService
    {
        public MediaService(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public async Task<IEnumerable<MediaFile>> GetAllMediaFiles()
        {
            var mediaFiles = await Context.MediaFiles
                .AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .ToListAsync();
            return mediaFiles;
        }

        public async Task<MediaFile> GetMediaFileById(int id)
        {
            var mediaFile = await Context.MediaFiles
                .AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .FirstOrDefaultAsync(e => e.Id == id);
            return mediaFile;
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByMovieId(int id)
        {
            return await Context.MediaFiles.AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .Where(e => e.MovieId == id).ToListAsync();
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByTVShowId(int id)
        {
            return await Context.MediaFiles.AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .Where(e => e.TVShowId == id).ToListAsync();
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByEpisodeId(int id)
        {
            return await Context.MediaFiles.AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .Where(e => e.EpisodeId == id).ToListAsync();
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByCastCrewMemberId(int id)
        {
            return await Context.MediaFiles.AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .Where(e => e.CastCrewMemberId == id).ToListAsync();
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByCharacterId(int id)
        {
            return await Context.MediaFiles.AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .Where(e => e.CharacterId == id).ToListAsync();
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByAwardId(int id)
        {
            return await Context.MediaFiles.AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .Where(e => e.AwardId == id).ToListAsync();
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByGenreId(int id)
        {
            return await Context.MediaFiles.AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .Where(e => e.GenreId == id).ToListAsync();
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByMovieSeriesId(int id)
        {
            return await Context.MediaFiles.AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .Where(e => e.MovieSeriesId == id).ToListAsync();
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByMovieStudioId(int id)
        {
            return await Context.MediaFiles.AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .Where(e => e.MovieStudioId == id).ToListAsync();
        }
    }
}
