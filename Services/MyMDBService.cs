using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System;
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
        Task<GenreLink> GetGenreLinkById(int id);
        Task<GenreLink> GetGenreLinkById(int movieId, int genreId);
        Task<IEnumerable<Genre>> GetAllGenres();        
        Task<IEnumerable<GenreLink>> GetAllGenreLinks();        
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

        Task AddGenre(Genre itemToAdd);
        Task AddFact(Fact itemToAdd);
        Task AddFactType(FactType itemToAdd);
        Task AddRating(Rating itemToAdd);
        Task AddQuote(Quote itemToAdd);
        Task AddCastCrewMember(CastCrewMember itemToAdd);
        Task AddProductionRole(ProductionRole itemToAdd);
        Task AddJobRole(JobRole itemToAdd);
        Task AddCharacter(Character itemToAdd);
        Task AddGenreLink(GenreLink itemToAdd);

        Task EditGenre(Genre itemToEdit);
        Task EditFact(Fact itemToEdit);
        Task EditFactType(FactType itemToEdit);
        Task EditRating(Rating itemToEdit);
        Task EditQuote(Quote itemToEdit);
        Task EditCastCrewMember(CastCrewMember itemToEdit);
        Task EditProductionRole(ProductionRole itemToEdit);
        Task EditJobRole(JobRole itemToEdit);
        Task EditCharacter(Character itemToEdit);
        Task EditGenreLink(GenreLink itemToEdit);

        Task DeleteGenre(int id);
        Task DeleteGenreLink(int id);
        Task DeleteFact(int id);
        Task DeleteFactType(int id);
        Task DeleteRating(int id);
        Task DeleteQuote(int id);
        Task DeleteCastCrewMember(int id);
        Task DeleteProductionRole(int id);
        Task DeleteJobRole(int id);
        Task DeleteCharacter(int id);

        Task<IEnumerable<CastCrewMember>> GetHomepageBirthdays();

    }

    public class MyMDBService : IMyMDBService
    {
        public MyMDBService(ApplicationDbContext databaseContext,
            ITVService tVService)
        {
            DatabaseContext = databaseContext;
            TVService = tVService;
        }

        public ApplicationDbContext DatabaseContext { get; }
        public ITVService TVService { get; }
        public IMovieService MovieService { get; }

        public async Task<Genre> GetGenreById(int id)
        {
            var x = await DatabaseContext.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }     

        public async Task<Fact> GetFactById(int id)
        {
            var fact = await DatabaseContext.Facts
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
            var factType = await DatabaseContext.FactTypes
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);
            return factType;
        }

        public async Task<Rating> GetRatingById(int id)
        {
            var rating = await DatabaseContext.Ratings
                            .AsNoTracking()
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .FirstOrDefaultAsync(e => e.Id == id);
            return rating;
        }

        public async Task<Quote> GetQuoteById(int id)
        {
            var quote = await DatabaseContext.Quotes
                            .AsNoTracking()
                            .Include(e => e.Character)
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .FirstOrDefaultAsync(e => e.Id == id);
            return quote;
        }

        public async Task<IEnumerable<Quote>> GetAllQuotes()
        {
            var quotes = await DatabaseContext.Quotes
                            .AsNoTracking()
                            .Include(e => e.Character)
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .Where(e => e.Deleted == false)
                            .ToListAsync();
            return quotes;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = await DatabaseContext.Genres
                .AsNoTracking()
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return genres;
        }

        public async Task<IEnumerable<Fact>> GetAllFacts()
        {
            var facts = await DatabaseContext.Facts
                        .AsNoTracking()
                        .Include(e => e.FactType)
                        .Include(e => e.CastCrewMember)
                        .Include(e => e.Episode)
                        .Include(e => e.TVShow)
                        .Include(e => e.Movie)
                        .Where(e => e.Deleted == false)
                        .ToListAsync();
            return facts;
        }

        public async Task<IEnumerable<FactType>> GetAllFactTypes()
        {
            var factTypes = await DatabaseContext.FactTypes
                            .AsNoTracking()
                            .Where(e => e.Deleted == false)
                            .ToListAsync();
            return factTypes;
        }

        public async Task<IEnumerable<Rating>> GetAllRatings()
        {
            var ratings = await DatabaseContext.Ratings
                            .AsNoTracking()
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .Where(e => e.Deleted == false)
                            .ToListAsync();
            return ratings;
        }

        public async Task<IEnumerable<Quote>> GetQuotesByMovieId(int id)
        {
            var quotes = await DatabaseContext.Quotes
                .AsNoTracking()
                .Where(e => e.MovieId == id)
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return quotes;
        }

        public async Task<IEnumerable<CastCrewMember>> GetAllCastCrewMembers()
        {
            var castCrewMembers = await DatabaseContext.CastCrewMember
                .AsNoTracking()
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return castCrewMembers;
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            var characters = await DatabaseContext.Characters
                            .AsNoTracking()
                            .Where(e => e.Deleted == false)
                            .ToListAsync();
            return characters;
        }

        public async Task<IEnumerable<ProductionRole>> GetAllProductionRoles()
        {
            var productionRoles = await DatabaseContext.ProductionRoles
                            .AsNoTracking()
                            .Include(e => e.CastCrewMember)
                            .Include(e => e.JobRole)
                            .Include(e => e.Character)
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .Where(e => e.Deleted == false)
                            .ToListAsync();
            return productionRoles;
        }

        public async Task<IEnumerable<JobRole>> GetAllJobRoles()
        {
            var jobRoles = await DatabaseContext.JobRoles
                            .AsNoTracking()
                            .Where(e => e.Deleted == false)
                            .ToListAsync();
            return jobRoles;
        }

        public async Task<CastCrewMember> GetCastCrewMemberById(int id)
        {
            var x = await DatabaseContext.CastCrewMember
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await DatabaseContext.Characters
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);
            return character;
        }

        public async Task<ProductionRole> GetProductionRoleById(int id)
        {
            var productionRole = await DatabaseContext.ProductionRoles
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
            var jobRole = await DatabaseContext.JobRoles
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);
            return jobRole;
        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByCastCrewMemberId(int id)
        {
            var castCrewMember = await GetCastCrewMemberById(id);
            var roles = await DatabaseContext.ProductionRoles
                .Include(e => e.Movie)
                .Include(e => e.Episode)
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
            var roles = await DatabaseContext.ProductionRoles
                .Include(e => e.Movie)
                .Include(e => e.Episode)
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
                //foreach (var role in episode.ProductionRoles)
                //{
                //    roles.Add(role);
                //}
            }
            return roles;
        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByCharacterId(int id)
        {
            var character = await GetCharacterById(id);
            var roles = await DatabaseContext.ProductionRoles
                .AsNoTracking()
                .Include(e => e.Movie)
                .Include(e => e.Episode)
                .Include(e => e.Character)
                .Include(e => e.CastCrewMember)
                .Include(e => e.JobRole)
                .Where(e => e.CharacterId == character.Id)
                .ToListAsync();
            return roles;
        }

        public async Task DeleteGenre(int id)
        {
            var item = await GetGenreById(id);
            item.Deleted = true;
            DatabaseContext.Genres.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteFact(int id)
        {
            var item = await GetFactById(id);
            item.Deleted = true;
            DatabaseContext.Facts.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteFactType(int id)
        {
            var item = await GetFactTypeById(id);
            item.Deleted = true;
            DatabaseContext.FactTypes.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteRating(int id)
        {
            var item = await GetRatingById(id);
            item.Deleted = true;
            DatabaseContext.Ratings.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteQuote(int id)
        {
            var item = await GetQuoteById(id);
            item.Deleted = true;
            DatabaseContext.Quotes.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteCastCrewMember(int id)
        {
            var item = await GetCastCrewMemberById(id);
            item.Deleted = true;
            DatabaseContext.CastCrewMember.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteProductionRole(int id)
        {
            var item = await GetProductionRoleById(id);
            item.Deleted = true;
            DatabaseContext.ProductionRoles.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteJobRole(int id)
        {
            var item = await GetJobRoleById(id);
            item.Deleted = true;
            DatabaseContext.JobRoles.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteCharacter(int id)
        {
            var item = await GetCharacterById(id);
            item.Deleted = true;
            DatabaseContext.Characters.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddGenre(Genre itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddFact(Fact itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddFactType(FactType itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddRating(Rating itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddQuote(Quote itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddCastCrewMember(CastCrewMember itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddProductionRole(ProductionRole itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddJobRole(JobRole itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddCharacter(Character itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditGenre(Genre itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditFact(Fact itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditFactType(FactType itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditRating(Rating itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditQuote(Quote itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditCastCrewMember(CastCrewMember itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditProductionRole(ProductionRole itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditJobRole(JobRole itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditCharacter(Character itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task<GenreLink> GetGenreLinkById(int id)
        {
            return await DatabaseContext.GenreLink
                            .AsNoTracking()
                            .Include(e => e.TVShow)
                            .Include(e => e.Movie)
                            .Include(e => e.Genre)
                            .FirstOrDefaultAsync(e => e.Id == id); 
        }

        public async Task<IEnumerable<GenreLink>> GetAllGenreLinks()
        {
            return await DatabaseContext.GenreLink
                            .AsNoTracking()
                            .Include(e=>e.TVShow)
                            .Include(e=>e.Movie)
                            .Include(e=>e.Genre)
                            .Where(e => e.Deleted == false)
                            .ToListAsync();
        }

        public async Task AddGenreLink(GenreLink itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditGenreLink(GenreLink itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteGenreLink(int id)
        {
            var item = await GetGenreLinkById(id);
            DatabaseContext.Remove(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task<GenreLink> GetGenreLinkById(int movieId, int genreId)
        {
            var genreLink = await DatabaseContext.GenreLink
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.MovieId == movieId 
                && e.GenreId == genreId);
            return genreLink;
        }

        public async Task<IEnumerable<CastCrewMember>> GetHomepageBirthdays()
        {
            var allCastCrew = await GetAllCastCrewMembers();
            var birthdays = allCastCrew.Where(e => e.DOB == DateTime.Now.Date);
            return birthdays;
        }
    }
}
