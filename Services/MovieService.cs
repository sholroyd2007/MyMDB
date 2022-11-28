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
        Task<SeriesMovie> GetSeriesMovieById(int id);
        Task<SeriesMovie> GetSeriesMovieById(int movieId, int seriesId);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<IEnumerable<SeriesMovie>> GetAllSeriesMovies();
        Task<IEnumerable<MovieSeries>> GetAllMovieSeries();
        Task<IEnumerable<MovieStudio>> GetAllMovieStudios();
        Task<IEnumerable<Movie>> GetMoviesByGenre(int id);
        Task<IEnumerable<Movie>> GetMoviesByMovieSeries(int id);
        Task<IEnumerable<Movie>> GetMoviesByMovieStudio(int id);

        Task<MovieSeries> GetMovieSeriesByMovieId(int id);
        Task<IEnumerable<Genre>> GetMovieGenres(int id);

        Task AddMovie(Movie itemToAdd);
        Task AddMovieSeries(MovieSeries itemToAdd);
        Task AddMovieStudio(MovieStudio itemToAdd);
        Task AddSeriesMovie(SeriesMovie itemToAdd);

        Task EditMovie(Movie itemToEdit);
        Task EditMovieSeries(MovieSeries itemToEdit);
        Task EditMovieStudio(MovieStudio itemToEdit);
        Task EditSeriesMovie(SeriesMovie itemToEdit);

        Task DeleteMovie(int id);
        Task DeleteMovieSeries(int id);
        Task DeleteMovieStudio(int id);
        Task DeleteSeriesMovie(int id);

        Task<IEnumerable<Movie>> GetHomepageRecommendedMovies();
        Task<IEnumerable<Movie>> GetHomepageComingSoonMovies();
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
                .AsNoTracking()
                .Include(e => e.MovieStudio)
                .FirstOrDefaultAsync(e => e.Id == id);
            return movie;
        }

        public async Task<MovieSeries> GetMovieSeriesById(int id)
        {
            var x = await DatabaseContext.MovieSeries
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

            var genreLinks = await DatabaseContext.GenreLink
                .AsNoTracking()
                .Include(e => e.Genre)
                .Include(e => e.Movie)
                .Where(e => e.GenreId == genre.Id && e.Deleted == false)
                .ToListAsync();

            var movies = new List<Movie>();
            foreach (var item in genreLinks)
            {
                movies.Add(item.Movie);
            }
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByMovieSeries(int id)
        {
            var series = await GetMovieSeriesById(id);
            var allSeriesMovies = await GetAllSeriesMovies();
            var seriesMovies = allSeriesMovies.Where(e => e.SeriesId == series.Id && e.Deleted == false);
            var movies = new List<Movie>();
            foreach(var item in seriesMovies)
            {
                movies.Add(item.Movie);
            }
            return movies;

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

        public async Task<MovieSeries> GetMovieSeriesByMovieId(int id)
        {
            var movie = await GetMovieById(id);
            var seriesMovie = await DatabaseContext.SeriesMovie.AsNoTracking()
                .Include(e=>e.Series)
                .Include(e=>e.Movie)
                .FirstOrDefaultAsync(e=>e.MovieId == movie.Id && e.Deleted == false);
            if(seriesMovie != null)
            {
                return seriesMovie.Series;
            }
            return null;
            

        }

        public async Task AddSeriesMovie(SeriesMovie itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditSeriesMovie(SeriesMovie itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteSeriesMovie(int id)
        {
            var item = await GetSeriesMovieById(id);
            DatabaseContext.Remove(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task<SeriesMovie> GetSeriesMovieById(int id)
        {
            return await DatabaseContext.SeriesMovie
                .AsNoTracking()
                .Include(e=>e.Movie)
                .Include(e=>e.Series)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<SeriesMovie>> GetAllSeriesMovies()
        {
            return await DatabaseContext.SeriesMovie
                .AsNoTracking()
                .Include(e => e.Movie)
                .Include(e => e.Series)
                .Where(e=>e.Deleted == false)
                .ToListAsync();
        }

        public async Task<SeriesMovie> GetSeriesMovieById(int movieId, int seriesId)
        {
            var seriesMovie = await DatabaseContext.SeriesMovie
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.MovieId == movieId && e.SeriesId == seriesId);
            return seriesMovie;
        }

        public async Task<IEnumerable<Genre>> GetMovieGenres(int id)
        {
            var movie = await GetMovieById(id);
            var genres = await DatabaseContext.GenreLink
                .AsNoTracking()
                .Where(e => e.MovieId == movie.Id)
                .Select(e => e.Genre)
                .ToListAsync();
            return genres;
        }

        public async Task<IEnumerable<Movie>> GetHomepageRecommendedMovies()
        {
            var movies = await DatabaseContext.Featured
                .AsNoTracking()
                .Where(e => e.MovieId != null && e.Recommended)
                .Select(e => e.Movie)
                .ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetHomepageComingSoonMovies()
        {
            var movies = await GetAllMovies();
            return movies.Where(e => e.Release < DateTime.Now.Date);
        }
    }
}
