using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMDB.Services
{
    public interface ITVService
    {
        Task<TVShow> GetTVShowById(int id);
        Task<Episode> GetEpisodeById(int id);
        Task<IEnumerable<TVShow>> GetAllTVShows();
        Task<IEnumerable<Episode>> GetAllEpisodes();
        Task<IEnumerable<TVShow>> GetTVShowsByGenre(int id);
        Task<IEnumerable<Episode>> GetEpisodesByTVShowId(int id);
        Task<int> GetEpisodeCountByProductionRoleId(int id);
    }

    public class TVService : ITVService
    {
        public TVService(ApplicationDbContext context,
            IMyMDBService MyMDBService)
        {
            Context = context;
            MyMDBService = MyMDBService;
        }

        public ApplicationDbContext Context { get; }
        public IMyMDBService MyMDBService { get; }

        public async Task<IEnumerable<TVShow>> GetAllTVShows()
        {
            var shows = await Context.TVShows
                .AsNoTracking()
                .ToListAsync();
            return shows;
        }

        public async Task<IEnumerable<TVShow>> GetTVShowsByGenre(int id)
        {
            var genre = await Context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            var tvShows = new List<TVShow>();
            foreach (var show in await GetAllTVShows())
            {
                foreach (var g in show.Genres)
                {
                    if (g == genre)
                    {
                        tvShows.Add(show);
                    }
                }
            }
            return tvShows;
        }

        public async Task<TVShow> GetTVShowById(int id)
        {
            var show = await Context.TVShows
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.CastCrewMember)
                .AsNoTracking()
                .Include(e => e.Episodes)
                .FirstOrDefaultAsync(e => e.Id == id);
            return show;
        }

        public async Task<IEnumerable<Episode>> GetAllEpisodes()
        {
            var episodes = await Context.Episodes
                .AsNoTracking()
                .Include(e => e.TVShow)
                .ToListAsync();
            return episodes;
        }
        public async Task<Episode> GetEpisodeById(int id)
        {
            var x = await Context.Episodes
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.CastCrewMember)
                .AsNoTracking()
                .Include(e => e.TVShow)
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<IEnumerable<Episode>> GetEpisodesByTVShowId(int id)
        {
            var tvShow = await GetTVShowById(id);
            var episodes = await Context.Episodes.AsNoTracking()
                .Include(e => e.ProductionRoles)
                .Where(e => e.TVShowId == tvShow.Id)
                .ToListAsync();
            return episodes;
        }

        public async Task<int> GetEpisodeCountByProductionRoleId(int id)
        {
            var productionRole = await MyMDBService.GetProductionRoleById(id);

            var roles = await Context.ProductionRoles.AsNoTracking()
                .Where(e => e.CastCrewMemberId == productionRole.CastCrewMemberId
                && e.JobRoleId == productionRole.JobRoleId
                && e.Episode.TVShowId == productionRole.Episode.TVShowId)
                .ToListAsync();

            return roles.Count();
        }


    }
}
