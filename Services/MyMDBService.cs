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
        Task<Movie> GetMovieById(int id);
        Task<TVShow> GetTVShowById(int id);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<IEnumerable<TVShow>> GetAllTVShows();
        Task<IEnumerable<ProductionRole>> GetProductionRolesByCastCrewMemberId(int id);
        Task<IEnumerable<CastCrewMember>> GetCastCrewMembersByMovieId(int id);
        Task<IEnumerable<Movie>> GetMoviesByGenre(int id);
        Task<IEnumerable<TVShow>> GetTVShowsByGenre(int id);
        Task<IEnumerable<Movie>> GetMoviesByMovieSeries(int id);
        Task<IEnumerable<Movie>> GetMoviesByMovieStudio(int id);
        Task<IEnumerable<Quote>> GetQuotesByMovieId(int id);
        Task<Rating> GetRatingByMovieId(int id);       
    }

    public class MyMDBService : IMyMDBService
    {
        public MyMDBService(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public async Task<IEnumerable<CastCrewMember>> GetCastCrewMembersByMovieId(int id)
        {
            var movie = await GetMovieById(id);
            return movie.CastCrewMembers;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var movies = await Context.Movies
                .AsNoTracking()
                .Include(e => e.CastCrewMembers)
                .Include(e => e.Facts)
                .Include(e => e.MediaFiles)
                .Include(e=>e.MovieStudio)
                .ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await Context.Movies
                .Include(e => e.CastCrewMembers)
                .Include(e => e.Facts)
                .Include(e => e.MediaFiles)
                .FirstOrDefaultAsync(e => e.Id == id);
            return movie;   
        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByCastCrewMemberId(int id)
        {
            var castCrewMember = await Context.CastCrewMember
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            var roles = await Context.ProductionRoles
                .AsNoTracking()
                .Include(e=>e.JobRole)
                .Include(e=>e.Character)
                .Include(e=>e.Movie)
                .Include(e=>e.Episode)
                .Where(e => e.CastCrewMemberId == castCrewMember.Id)
                .ToListAsync();

            return roles;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int id)
        {
            var genre = await Context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            var movies = new List<Movie>();
            foreach (var movie in await GetAllMovies())
            {
                foreach (var g in movie.Genres)
                {
                    if (g == genre)
                    {
                        movies.Add(movie);
                    }
                }
            }
            return movies;
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

        public async Task<IEnumerable<Movie>> GetMoviesByMovieSeries(int id)
        {
            var movieSeries = await Context.MovieSeries
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return movieSeries.Movies;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByMovieStudio(int id)
        {
            var movies = await Context.Movies
                .AsNoTracking()
                .Include(e => e.CastCrewMembers)
                .Include(e => e.Facts)
                .Include(e => e.MediaFiles)
                .Where(e => e.MovieStudioId == id)
                .ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<Quote>> GetQuotesByMovieId(int id)
        {
            var quotes = await Context.Quotes
                .AsNoTracking()
                .Where(e => e.MovieId == id).
                ToListAsync();
            return quotes;
        }

        public async Task<Rating> GetRatingByMovieId(int id)
        {
            var movie = await GetMovieById(id);
            return movie.Rating;
        }

        public async Task<TVShow> GetTVShowById(int id)
        {
            var show = await Context.TVShows
                .AsNoTracking()
                .Include(e=>e.Episodes)
                .ThenInclude(e => e.CastCrewMembers)
                .Include(e => e.Facts)
                .Include(e => e.MediaFiles)
                .FirstOrDefaultAsync(e => e.Id == id);
            return show;
        }

        public async Task<IEnumerable<TVShow>> GetAllTVShows()
        {
            var shows = await Context.TVShows
                .AsNoTracking()
                .Include(e=>e.Episodes)
                .ThenInclude(e => e.CastCrewMembers)
                .Include(e => e.Facts)
                .Include(e => e.MediaFiles)
                .ToListAsync();
            return shows;
        }
    }
}
