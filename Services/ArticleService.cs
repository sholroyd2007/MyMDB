using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMDB.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAllArticles();
        Task<IEnumerable<ListArticle>> GetAllListArticles();

        Task<IEnumerable<ListArticle>> GetListArticlesByMovieId(int id);
        Task<IEnumerable<ListArticle>> GetListArticlesByEpisodeId(int id);
        Task<IEnumerable<ListArticle>> GetListArticlesByTVShowId(int id);
        Task<IEnumerable<ListArticle>> GetListArticlesByCastCrewMemberId(int id);
        Task<IEnumerable<ListArticle>> GetListArticlesByMovieStudioId(int id);
        Task<IEnumerable<ListArticle>> GetListArticlesByMovieSeriesId(int id);
        Task<IEnumerable<ListArticle>> GetListArticlesByAwardId(int id);
        Task<IEnumerable<ListArticle>> GetListArticlesByCharacterId(int id);

        Task<IEnumerable<Article>> GetHomepageArticles();
        Task<IEnumerable<ListArticle>> GetHomepageListArticles();

        Task<IEnumerable<Article>> GetArticlesByMovieId(int id);
        Task<IEnumerable<Article>> GetArticlesByEpisodeId(int id);
        Task<IEnumerable<Article>> GetArticlesByTVShowId(int id);
        Task<IEnumerable<Article>> GetArticlesByCastCrewMemberId(int id);
        Task<IEnumerable<Article>> GetArticlesByMovieStudioId(int id);
        Task<IEnumerable<Article>> GetArticlesByMovieSeriesId(int id);
        Task<IEnumerable<Article>> GetArticlesByAwardId(int id);
        Task<IEnumerable<Article>> GetArticlesByCharacterId(int id);

        Task<Article> GetArticleById(int id);
        Task<ListArticle> GetListArticleById(int id);

        Task AddArticle(Article itemToAdd);
        Task AddListArticle(ListArticle itemToAdd);

        Task EditArticle(Article itemToEdit);
        Task EditListArticle(ListArticle itemToEdit);

        Task DeleteArticle(int id);
        Task DeleteListArticle(int id);
    }

    public class ArticleService : IArticleService
    {
        public ArticleService(ApplicationDbContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public ApplicationDbContext DatabaseContext { get; }

        public async Task AddArticle(Article itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddListArticle(ListArticle itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteArticle(int id)
        {
            var article = await GetArticleById(id);
            article.Deleted = true;
            DatabaseContext.Articles.Update(article);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteListArticle(int id)
        {
            var listArticle = await GetListArticleById(id);
            listArticle.Deleted = true;
            DatabaseContext.ListArticles.Update(listArticle);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditArticle(Article itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditListArticle(ListArticle itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            return await DatabaseContext.Articles
                .Where(e => e.Deleted == false)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ListArticle>> GetAllListArticles()
        {
            return await DatabaseContext.ListArticles
                .AsNoTracking()
                .Include(e=>e.Movies)
                .Include(e=>e.Characters)
                .Include(e=>e.CastCrewMembers)
                .Include(e=>e.Episodes)
                .Include(e=>e.TVShows)
                .Where(e=>e.Deleted == false)
                .ToListAsync();
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await DatabaseContext.Articles
                .AsNoTracking()
                .FirstOrDefaultAsync(e=>e.Id == id);
        }

        public async Task<IEnumerable<Article>> GetArticlesByAwardId(int id)
        {
            var allArticles = await GetAllArticles();
            return allArticles.Where(e=>e.AwardId == id); 
        }

        public async Task<IEnumerable<Article>> GetArticlesByCastCrewMemberId(int id)
        {
            var allArticles = await GetAllArticles();
            return allArticles.Where(e => e.CastCrewMemberId == id);
        }

        public async Task<IEnumerable<Article>> GetArticlesByCharacterId(int id)
        {
            var allArticles = await GetAllArticles();
            return allArticles.Where(e => e.CharacterId == id);
        }

        public async Task<IEnumerable<Article>> GetArticlesByEpisodeId(int id)
        {
            var allArticles = await GetAllArticles();
            return allArticles.Where(e => e.EpisodeId == id);
        }

        public async Task<IEnumerable<Article>> GetArticlesByMovieId(int id)
        {
            var allArticles = await GetAllArticles();
            return allArticles.Where(e => e.MovieId == id);
        }

        public async Task<IEnumerable<Article>> GetArticlesByMovieSeriesId(int id)
        {
            var allArticles = await GetAllArticles();
            return allArticles.Where(e => e.MovieSeriesId == id);
        }

        public async Task<IEnumerable<Article>> GetArticlesByMovieStudioId(int id)
        {
            var allArticles = await GetAllArticles();
            return allArticles.Where(e => e.MovieStudioId == id);
        }

        public async Task<IEnumerable<Article>> GetArticlesByTVShowId(int id)
        {
            var allArticles = await GetAllArticles();
            return allArticles.Where(e => e.TVShowId == id);
        }

        public async Task<IEnumerable<Article>> GetHomepageArticles()
        {
            var allArticles = await GetAllArticles();
            var homepageArticles = allArticles.Take(10);
            return homepageArticles;
        }

        public async Task<IEnumerable<ListArticle>> GetHomepageListArticles()
        {
            var allListArticles = await GetAllListArticles();
            var homepageListArticles = allListArticles.Take(10);
            return homepageListArticles;
        }

        public async Task<ListArticle> GetListArticleById(int id)
        {
            return await DatabaseContext.ListArticles
                .AsNoTracking()
                .Include(e => e.Movies)
                .Include(e => e.Characters)
                .Include(e => e.CastCrewMembers)
                .Include(e => e.Episodes)
                .Include(e => e.TVShows)
                .Where(e => e.Deleted == false)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<ListArticle>> GetListArticlesByAwardId(int id)
        {
            var item = await DatabaseContext.Awards.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            var allListArticles = await GetAllListArticles();
            return allListArticles.Where(e => e.Awards.Contains(item));
        }

        public async Task<IEnumerable<ListArticle>> GetListArticlesByCastCrewMemberId(int id)
        {
            var item = await DatabaseContext.CastCrewMember.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            var allListArticles = await GetAllListArticles();
            return allListArticles.Where(e => e.CastCrewMembers.Contains(item));
        }

        public async Task<IEnumerable<ListArticle>> GetListArticlesByCharacterId(int id)
        {
            var item = await DatabaseContext.Characters.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            var allListArticles = await GetAllListArticles();
            return allListArticles.Where(e => e.Characters.Contains(item));
        }

        public async Task<IEnumerable<ListArticle>> GetListArticlesByEpisodeId(int id)
        {
            var item = await DatabaseContext.Episodes.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            var allListArticles = await GetAllListArticles();
            return allListArticles.Where(e => e.Episodes.Contains(item));
        }

        public async Task<IEnumerable<ListArticle>> GetListArticlesByMovieId(int id)
        {
            var item = await DatabaseContext.Movies.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            var allListArticles = await GetAllListArticles();
            return allListArticles.Where(e => e.Movies.Contains(item));
        }

        public async Task<IEnumerable<ListArticle>> GetListArticlesByMovieSeriesId(int id)
        {
            var item = await DatabaseContext.MovieSeries.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            var allListArticles = await GetAllListArticles();
            return allListArticles.Where(e => e.MovieSeries.Contains(item));
        }

        public async Task<IEnumerable<ListArticle>> GetListArticlesByMovieStudioId(int id)
        {
            var item = await DatabaseContext.MovieStudios.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            var allListArticles = await GetAllListArticles();
            return allListArticles.Where(e => e.MovieStudios.Contains(item));
        }

        public async Task<IEnumerable<ListArticle>> GetListArticlesByTVShowId(int id)
        {
            var item = await DatabaseContext.TVShows.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            var allListArticles = await GetAllListArticles();
            return allListArticles.Where(e => e.TVShows.Contains(item));
        }
    }
}
