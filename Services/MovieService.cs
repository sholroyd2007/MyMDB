using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMDB.Services
{
    public interface IMovieService
    {
        Task<Movie> GetMovieById(int id);
        Task<MovieSeries> GetMovieSeriesById(int id);
        Task<MovieStudio> GetMovieStudioById(int id);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<IEnumerable<MovieSeries>> GetAllMovieSeries();
        Task<IEnumerable<MovieStudio>> GetAllMovieStudios();
        Task<IEnumerable<Movie>> GetMoviesByGenre(int id);
        Task<IEnumerable<Movie>> GetMoviesByMovieSeries(int id);
        Task<IEnumerable<Movie>> GetMoviesByMovieStudio(int id);
    }

    public class MovieService : IMovieService
    {
        public MovieService(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await Context.Movies
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.CastCrewMember)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
                .Include(e => e.ProductionRoles)
                .ThenInclude(e => e.CastCrewMember)
                .Include(e => e.ProductionRoles)
                .ThenInclude(e => e.JobRole)
                .Include(e => e.ProductionRoles)
                .ThenInclude(e => e.Character)
                .Include(e => e.MovieStudio)
                .Include(e => e.Genres)
                .FirstOrDefaultAsync(e => e.Id == id);
            return movie;
        }

        public async Task<MovieSeries> GetMovieSeriesById(int id)
        {
            var x = await Context.MovieSeries
                .Include(e => e.Movies)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<MovieStudio> GetMovieStudioById(int id)
        {
            var x = await Context.MovieStudios
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var movies = await Context.Movies
                .AsNoTracking()
                .Include(e => e.MovieStudio)
                .ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<MovieSeries>> GetAllMovieSeries()
        {
            var series = await Context.MovieSeries
                .AsNoTracking()
                .ToListAsync();
            return series;
        }

        public async Task<IEnumerable<MovieStudio>> GetAllMovieStudios()
        {
            var studios = await Context.MovieStudios
                .AsNoTracking()
                .ToListAsync();
            return studios;
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
                .Where(e => e.MovieStudioId == id)
                .ToListAsync();
            return movies;
        }

    }
}
