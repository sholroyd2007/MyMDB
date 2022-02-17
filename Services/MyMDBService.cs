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
        Task<CastCrewMember> GetCastCrewMemberById(int id);
        Task<Episode> GetEpisodeById(int id);
        Task<Award> GetAwardById(int id);
        Task<AwardCategory> GetAwardCategoryById(int id);
        Task<AwardRecipient> GetAwardRecipientById(int id);
        Task<Genre> GetGenreById(int id);
        Task<MovieSeries> GetMovieSeriesById(int id);
        Task<MovieStudio> GetMovieStudioById(int id);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<IEnumerable<TVShow>> GetAllTVShows();
        Task<IEnumerable<Episode>> GetAllEpisodes();
        Task<IEnumerable<Award>> GetAllAwards();
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<IEnumerable<MovieSeries>> GetAllMovieSeries();
        Task<IEnumerable<MovieStudio>> GetAllMovieStudios();
        Task<IEnumerable<CastCrewMember>> GetAllCastCrewMembers();
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
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
                .ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await Context.Movies
                .Include(e => e.CastCrewMembers)
                .Include(e => e.Facts)
                .Include(e => e.MediaFiles)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
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
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
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
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
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
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
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
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
                .ToListAsync();
            return shows;
        }

        public async Task<IEnumerable<CastCrewMember>> GetAllCastCrewMembers()
        {
            var castCrewMembers = await Context.CastCrewMember
                .AsNoTracking()
                .Include(e => e.Facts)
                .Include(e => e.MediaFiles)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e=>e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e=>e.AwardCategory)
                .ToListAsync();
            return castCrewMembers;
        }

        public async Task<IEnumerable<Episode>> GetAllEpisodes()
        {
            var episodes = await Context.Episodes
                .AsNoTracking()
                .Include(e => e.Facts)
                .Include(e => e.MediaFiles)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
                .ToListAsync();
            return episodes;
        }

        public async Task<IEnumerable<Award>> GetAllAwards()
        {
            var awards = await Context.Awards
                .AsNoTracking()
                .ToListAsync();
            return awards;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = await Context.Genres
                .AsNoTracking()
                .ToListAsync();
            return genres;
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

        public async Task<CastCrewMember> GetCastCrewMemberById(int id)
        {
            var x = await Context.CastCrewMember
                .AsNoTracking()
                .FirstOrDefaultAsync(e=>e.Id == id);
            return x;
        }

        public async Task<Episode> GetEpisodeById(int id)
        {
            var x = await Context.Episodes
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<Award> GetAwardById(int id)
        {
            var x = await Context.Awards
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<AwardCategory> GetAwardCategoryById(int id)
        {
            var x = await Context.AwardCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<AwardRecipient> GetAwardRecipientById(int id)
        {
            var x = await Context.AwardRecipients
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<Genre> GetGenreById(int id)
        {
            var x = await Context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<MovieSeries> GetMovieSeriesById(int id)
        {
            var x = await Context.MovieSeries
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
    }
}
