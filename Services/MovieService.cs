using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System;
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

        Task AddMovie(Movie itemToAdd);
        Task AddMovieSeries(MovieSeries itemToAdd);
        Task AddMovieStudio(MovieStudio itemToAdd);

        Task EditMovie(Movie itemToEdit);
        Task EditMovieSeries(MovieSeries itemToEdit);
        Task EditMovieStudio(MovieStudio itemToEdit);

        Task DeleteMovie(int id);
        Task DeleteMovieSeries(int id);
        Task DeleteMovieStudio(int id);
    }

    public class MovieService : IMovieService
    {
        public ApplicationDbContext DatabaseContext { get; }

        public MovieService(ApplicationDbContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }


        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await DatabaseContext.Movies             
                .Include(e => e.MovieStudio)
                .Include(e => e.Genres)
                .FirstOrDefaultAsync(e => e.Id == id);
            return movie;
        }

        public async Task<MovieSeries> GetMovieSeriesById(int id)
        {
            var x = await DatabaseContext.MovieSeries
                .Include(e => e.Movies)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<MovieStudio> GetMovieStudioById(int id)
        {
            var x = await DatabaseContext.MovieStudios
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var movies = await DatabaseContext.Movies
                .AsNoTracking()
                .Include(e => e.MovieStudio)
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<MovieSeries>> GetAllMovieSeries()
        {
            var series = await DatabaseContext.MovieSeries
                .AsNoTracking()
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return series;
        }

        public async Task<IEnumerable<MovieStudio>> GetAllMovieStudios()
        {
            var studios = await DatabaseContext.MovieStudios
                .AsNoTracking()
                .ToListAsync();
            return studios;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int id)
        {
            var genre = await DatabaseContext.Genres
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
            var movieSeries = await DatabaseContext.MovieSeries
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return movieSeries.Movies;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByMovieStudio(int id)
        {
            var movies = await DatabaseContext.Movies
                .AsNoTracking()
                .Where(e => e.MovieStudioId == id)
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return movies;
        }

        public async Task DeleteMovie(int id)
        {
            var item = await GetMovieById(id);
            item.Deleted = true;
            DatabaseContext.Movies.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteMovieSeries(int id)
        {
            var item = await GetMovieSeriesById(id);
            item.Deleted = true;
            DatabaseContext.MovieSeries.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteMovieStudio(int id)
        {
            var item = await GetMovieStudioById(id);
            item.Deleted = true;
            DatabaseContext.MovieStudios.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddMovie(Movie itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddMovieSeries(MovieSeries itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddMovieStudio(MovieStudio itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditMovie(Movie itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditMovieSeries(MovieSeries itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditMovieStudio(MovieStudio itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
