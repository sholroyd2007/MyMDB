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

        Task DeleteMediaFile(int id);
    }

    public class MediaService : IMediaService
    {
        public ApplicationDbContext DatabaseContext { get; }

        public MediaService(ApplicationDbContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }


        public async Task<IEnumerable<MediaFile>> GetAllMediaFiles()
        {
            var mediaFiles = await DatabaseContext.MediaFiles
                .AsNoTracking()
                .Include(e => e.CastCrewMembers)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Characters)
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return mediaFiles;
        }

        public async Task<MediaFile> GetMediaFileById(int id)
        {
            var mediaFile = await DatabaseContext.MediaFiles
                .AsNoTracking()
                .Include(e => e.CastCrewMembers)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Characters)
                .FirstOrDefaultAsync(e => e.Id == id);
            return mediaFile;
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByMovieId(int id)
        {
            var allMediaFiles = await GetAllMediaFiles();
            return allMediaFiles.Where(e=>e.MovieId == id);
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByTVShowId(int id)
        {
            var allMediaFiles = await GetAllMediaFiles();
            return allMediaFiles.Where(e => e.TVShowId == id);
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByEpisodeId(int id)
        {
            var allMediaFiles = await GetAllMediaFiles();
            return allMediaFiles.Where(e => e.EpisodeId == id);
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByCastCrewMemberId(int id)
        {
            var castCrewMember = await DatabaseContext.CastCrewMember.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            var allMediaFiles = await GetAllMediaFiles();
            return allMediaFiles.Where(e => e.CastCrewMembers.Any(e=>e.Id == castCrewMember.Id));
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByCharacterId(int id)
        {
            var character = await DatabaseContext.Characters.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            var allMediaFiles = await GetAllMediaFiles();
            return allMediaFiles.Where(e => e.Characters.Any(e => e.Id == character.Id));
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByAwardId(int id)
        {
            var allMediaFiles = await GetAllMediaFiles();
            return allMediaFiles.Where(e => e.AwardId == id);
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByGenreId(int id)
        {
            var allMediaFiles = await GetAllMediaFiles();
            return allMediaFiles.Where(e => e.GenreId == id);
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByMovieSeriesId(int id)
        {
            var allMediaFiles = await GetAllMediaFiles();
            return allMediaFiles.Where(e => e.MovieSeriesId == id);
        }

        public async Task<IEnumerable<MediaFile>> GetMediaFilesByMovieStudioId(int id)
        {
            var allMediaFiles = await GetAllMediaFiles();
            return allMediaFiles.Where(e => e.MovieStudioId == id);
        }

        public async Task DeleteMediaFile(int id)
        {
            var item = await GetMediaFileById(id);
            item.Deleted = true;
            DatabaseContext.MediaFiles.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
