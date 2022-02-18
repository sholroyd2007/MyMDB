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
        Task<Fact> GetFactById(int id);
        Task<FactType> GetFactTypeById(int id);
        Task<MovieSeries> GetMovieSeriesById(int id);
        Task<MovieStudio> GetMovieStudioById(int id);
        Task<Character> GetCharacterById(int id);
        Task<Rating> GetRatingById(int id);
        Task<MediaFile> GetMediaFileById(int id);
        Task<ProductionRole> GetProductionRoleById(int id);
        Task<JobRole> GetJobRoleById(int id);
        Task<Quote> GetQuoteById(int id);

        Task<IEnumerable<Movie>> GetAllMovies();
        Task<IEnumerable<TVShow>> GetAllTVShows();
        Task<IEnumerable<Episode>> GetAllEpisodes();
        Task<IEnumerable<Award>> GetAllAwards();
        Task<IEnumerable<AwardCategory>> GetAllAwardCategories();
        Task<IEnumerable<AwardRecipient>> GetAllAwardRecipients();
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<IEnumerable<MovieSeries>> GetAllMovieSeries();
        Task<IEnumerable<MovieStudio>> GetAllMovieStudios();
        Task<IEnumerable<CastCrewMember>> GetAllCastCrewMembers();
        Task<IEnumerable<Character>> GetAllCharacters();
        Task<IEnumerable<Fact>> GetAllFacts();
        Task<IEnumerable<FactType>> GetAllFactTypes();
        Task<IEnumerable<Rating>> GetAllRatings();
        Task<IEnumerable<MediaFile>> GetAllMediaFiles();
        Task<IEnumerable<ProductionRole>> GetAllProductionRoles();
        Task<IEnumerable<JobRole>> GetAllJobRoles();
        Task<IEnumerable<Quote>> GetAllQuotes();

        Task<IEnumerable<Movie>> GetMoviesByGenre(int id);
        Task<IEnumerable<TVShow>> GetTVShowsByGenre(int id);
        Task<IEnumerable<Movie>> GetMoviesByMovieSeries(int id);
        Task<IEnumerable<Movie>> GetMoviesByMovieStudio(int id);
        Task<IEnumerable<Quote>> GetQuotesByMovieId(int id);
    }

    public class MyMDBService : IMyMDBService
    {
        public MyMDBService(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var movies = await Context.Movies
                .AsNoTracking()
                .Include(e => e.MovieStudio)
                .ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await Context.Movies
                .Include(e => e.MovieStudio)
                .FirstOrDefaultAsync(e => e.Id == id);
            return movie;
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


        public async Task<TVShow> GetTVShowById(int id)
        {
            var show = await Context.TVShows
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return show;
        }

        public async Task<IEnumerable<TVShow>> GetAllTVShows()
        {
            var shows = await Context.TVShows
                .AsNoTracking()
                .ToListAsync();
            return shows;
        }

        public async Task<IEnumerable<CastCrewMember>> GetAllCastCrewMembers()
        {
            var castCrewMembers = await Context.CastCrewMember
                .AsNoTracking()
                .ToListAsync();
            return castCrewMembers;
        }

        public async Task<IEnumerable<Episode>> GetAllEpisodes()
        {
            var episodes = await Context.Episodes
                .AsNoTracking()
                .Include(e => e.TVShow)
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
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<Episode> GetEpisodeById(int id)
        {
            var x = await Context.Episodes
                .AsNoTracking()
                .Include(e => e.TVShow)
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
                .Include(e => e.Award)
                .Include(e => e.AwardCategory)
                .Include(e => e.CastCrewMember)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Episode)
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

        public async Task<IEnumerable<AwardCategory>> GetAllAwardCategories()
        {
            var categories = await Context.AwardCategories
                .AsNoTracking()
                .ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<AwardRecipient>> GetAllAwardRecipients()
        {
            var recipients = await Context.AwardRecipients
                .AsNoTracking()
                .Include(e => e.Award)
                .Include(e => e.AwardCategory)
                .Include(e => e.CastCrewMember)
                .Include(e => e.TVShow)
                .Include(e => e.Episode)
                .Include(e => e.Movie)
                .ToListAsync();
            return recipients;
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            var characters = await Context.Characters
                            .AsNoTracking()
                            .Include(e => e.CastCrewMember)
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .ToListAsync();
            return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await Context.Characters
                            .AsNoTracking()
                            .Include(e => e.CastCrewMember)
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .FirstOrDefaultAsync(e => e.Id == id);
            return character;
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

        public async Task<IEnumerable<Rating>> GetAllRatings()
        {
            var ratings = await Context.Ratings
                            .AsNoTracking()
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .ToListAsync();
            return ratings;
        }

        public async Task<Rating> GetRatingById(int id)
        {
            var rating = await Context.Ratings
                            .AsNoTracking()
                            .Include(e=>e.Movie)
                            .Include(e=>e.Episode)
                            .FirstOrDefaultAsync(e => e.Id == id);
            return rating;
        }

        public async Task<IEnumerable<MediaFile>> GetAllMediaFiles()
        {
            var mediaFiles = await Context.MediaFiles
                .AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .ToListAsync();
            return mediaFiles;
        }

        public async Task<MediaFile> GetMediaFileById(int id)
        {
            var mediaFile = await Context.MediaFiles
                .AsNoTracking()
                .Include(e => e.CastCrewMember)
                .Include(e => e.Episode)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .Include(e => e.Award)
                .Include(e => e.Genre)
                .Include(e => e.MovieSeries)
                .Include(e => e.MovieStudio)
                .Include(e => e.Character)
                .FirstOrDefaultAsync(e => e.Id == id);
            return mediaFile;
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

        public async Task<JobRole> GetJobRoleById(int id)
        {
            var jobRole = await Context.JobRoles
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);
            return jobRole;
        }

        public async Task<IEnumerable<JobRole>> GetAllJobRoles()
        {
            var jobRoles = await Context.JobRoles
                            .AsNoTracking()
                            .ToListAsync();
            return jobRoles;
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
    }
}
