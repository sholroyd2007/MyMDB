using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMDB.Services
{

    public interface IMyMDBService
    {
        Task<Genre> GetGenreById(int id);
        Task<Fact> GetFactById(int id);
        Task<FactType> GetFactTypeById(int id);
        Task<Rating> GetRatingById(int id);
        Task<Quote> GetQuoteById(int id);
        Task<IEnumerable<Genre>> GetAllGenres();        
        Task<IEnumerable<Fact>> GetAllFacts();
        Task<IEnumerable<FactType>> GetAllFactTypes();
        Task<IEnumerable<Rating>> GetAllRatings();
        Task<IEnumerable<Quote>> GetAllQuotes();
        Task<IEnumerable<Quote>> GetQuotesByMovieId(int id);

        Task<CastCrewMember> GetCastCrewMemberById(int id);
        Task<IEnumerable<CastCrewMember>> GetAllCastCrewMembers();
        Task<ProductionRole> GetProductionRoleById(int id);
        Task<IEnumerable<ProductionRole>> GetAllProductionRoles();
        Task<JobRole> GetJobRoleById(int id);
        Task<IEnumerable<JobRole>> GetAllJobRoles();
        Task<Character> GetCharacterById(int id);
        Task<IEnumerable<Character>> GetAllCharacters();
        Task<IEnumerable<ProductionRole>> GetProductionRolesByCastCrewMemberId(int id);
        Task<IEnumerable<ProductionRole>> GetProductionRolesByTVShowId(int id);
        Task<IEnumerable<ProductionRole>> GetProductionRolesByCharacterId(int id);
    }

    public class MyMDBService : IMyMDBService
    {
        public MyMDBService(ApplicationDbContext context,
            ITVService tVService)
        {
            Context = context;
            TVService = tVService;
        }

        public ApplicationDbContext Context { get; }
        public ITVService TVService { get; }
        public IMovieService MovieService { get; }

        public async Task<Genre> GetGenreById(int id)
        {
            var x = await Context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }     

        public async Task<Fact> GetFactById(int id)
        {
            var fact = await Context.Facts
                        .AsNoTracking()
                        .Include(e => e.FactType)
                        .Include(e => e.CastCrewMember)
                        .Include(e => e.Episode)
                        .Include(e => e.TVShow)
                        .Include(e => e.Movie)
                        .FirstOrDefaultAsync(e => e.Id == id);
            return fact;
        }

        public async Task<FactType> GetFactTypeById(int id)
        {
            var factType = await Context.FactTypes
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);
            return factType;
        }

        public async Task<Rating> GetRatingById(int id)
        {
            var rating = await Context.Ratings
                            .AsNoTracking()
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .FirstOrDefaultAsync(e => e.Id == id);
            return rating;
        }

        public async Task<Quote> GetQuoteById(int id)
        {
            var quote = await Context.Quotes
                            .AsNoTracking()
                            .Include(e => e.Character)
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .FirstOrDefaultAsync(e => e.Id == id);
            return quote;
        }

        public async Task<IEnumerable<Quote>> GetAllQuotes()
        {
            var quotes = await Context.Quotes
                            .AsNoTracking()
                            .Include(e => e.Character)
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .ToListAsync();
            return quotes;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = await Context.Genres
                .AsNoTracking()
                .ToListAsync();
            return genres;
        }

        public async Task<IEnumerable<Fact>> GetAllFacts()
        {
            var facts = await Context.Facts
                        .AsNoTracking()
                        .Include(e => e.FactType)
                        .Include(e => e.CastCrewMember)
                        .Include(e => e.Episode)
                        .Include(e => e.TVShow)
                        .Include(e => e.Movie)
                        .ToListAsync();
            return facts;
        }

        public async Task<IEnumerable<FactType>> GetAllFactTypes()
        {
            var factTypes = await Context.FactTypes
                            .AsNoTracking()
                            .ToListAsync();
            return factTypes;
        }

        public async Task<IEnumerable<Rating>> GetAllRatings()
        {
            var ratings = await Context.Ratings
                            .AsNoTracking()
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .ToListAsync();
            return ratings;
        }

        public async Task<IEnumerable<Quote>> GetQuotesByMovieId(int id)
        {
            var quotes = await Context.Quotes
                .AsNoTracking()
                .Where(e => e.MovieId == id).
                ToListAsync();
            return quotes;
        }

        public async Task<IEnumerable<CastCrewMember>> GetAllCastCrewMembers()
        {
            var castCrewMembers = await Context.CastCrewMember
                .AsNoTracking()
                .ToListAsync();
            return castCrewMembers;
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            var characters = await Context.Characters
                            .AsNoTracking()
                            .ToListAsync();
            return characters;
        }

        public async Task<IEnumerable<ProductionRole>> GetAllProductionRoles()
        {
            var productionRoles = await Context.ProductionRoles
                            .AsNoTracking()
                            .Include(e => e.CastCrewMember)
                            .Include(e => e.JobRole)
                            .Include(e => e.Character)
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .ToListAsync();
            return productionRoles;
        }

        public async Task<IEnumerable<JobRole>> GetAllJobRoles()
        {
            var jobRoles = await Context.JobRoles
                            .AsNoTracking()
                            .ToListAsync();
            return jobRoles;
        }

        public async Task<CastCrewMember> GetCastCrewMemberById(int id)
        {
            var x = await Context.CastCrewMember
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await Context.Characters
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);
            return character;
        }

        public async Task<ProductionRole> GetProductionRoleById(int id)
        {
            var productionRole = await Context.ProductionRoles
                            .AsNoTracking()
                            .Include(e => e.CastCrewMember)
                            .Include(e => e.JobRole)
                            .Include(e => e.Character)
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .FirstOrDefaultAsync(e => e.Id == id);
            return productionRole;
        }

        public async Task<JobRole> GetJobRoleById(int id)
        {
            var jobRole = await Context.JobRoles
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);
            return jobRole;
        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByCastCrewMemberId(int id)
        {
            var castCrewMember = await GetCastCrewMemberById(id);
            var roles = await Context.ProductionRoles
                .Include(e => e.Movie)
                .Include(e => e.Episode)
                .Include(e => e.MediaFiles)
                .Include(e => e.Character)
                .Include(e => e.JobRole)
                .AsNoTracking()
                .Where(e => e.CastCrewMemberId == castCrewMember.Id)
                .ToListAsync();
            return roles;

        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByEpisodeId(int id)
        {
            var epsisode = await TVService.GetEpisodeById(id);
            var roles = await Context.ProductionRoles
                .Include(e => e.Movie)
                .Include(e => e.Episode)
                .Include(e => e.MediaFiles)
                .Include(e => e.Character)
                .Include(e => e.JobRole)
                .AsNoTracking()
                .Where(e => e.EpisodeId == epsisode.Id)
                .ToListAsync();
            return roles;

        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByTVShowId(int id)
        {
            var tvShow = await TVService.GetTVShowById(id);
            var episodes = await TVService.GetEpisodesByTVShowId(tvShow.Id);

            var roles = new List<ProductionRole>();
            foreach (var episode in episodes)
            {
                foreach (var role in episode.ProductionRoles)
                {
                    roles.Add(role);
                }
            }
            return roles;
        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByCharacterId(int id)
        {
            var character = await GetCharacterById(id);
            var roles = await Context.ProductionRoles
                .AsNoTracking()
                .Include(e => e.Movie)
                .Include(e => e.Episode)
                .Include(e => e.MediaFiles)
                .Include(e => e.Character)
                .Include(e => e.CastCrewMember)
                .Include(e => e.JobRole)
                .Where(e => e.CharacterId == character.Id)
                .ToListAsync();
            return roles;
        }

    }
}
