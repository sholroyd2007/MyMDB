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
    }

    public class MyMDBService : IMyMDBService
    {
        public MyMDBService(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

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

    }
}
