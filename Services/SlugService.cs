using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Helpers;
using MyMDB.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyMDB.Services
{
    public interface ISlugService
    {
        Task GenerateSlugs();
        Task ClearSlugs();
        Task DeleteSlug(long slugId);
        Task<int> GetEntityIdBySlug<TEntity>(string slug) where TEntity : Entity;
        Task<Slug> GetOrCreateSlugForEntity<TEntity>(TEntity entity) where TEntity : Entity;

        Task<Slug> GetSlugForEntity<TEntity>(TEntity entity) where TEntity : Entity;
    }

    public class SlugService : ISlugService
    {
        public SlugService(ApplicationDbContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public ApplicationDbContext DatabaseContext { get; }

        public async Task<Slug> GetOrCreateSlugForEntity<TEntity>(TEntity entity) where TEntity : Entity
        {
            var generatedSlug = SlugHelper.Slugify(entity);
            var slugObj = await DatabaseContext.Slugs.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Name == generatedSlug && e.EntityType == typeof(TEntity).Name && e.EntityId == entity.Id);

            if (slugObj == null)
            {
                slugObj = new Slug
                {
                    Name = generatedSlug,
                    EntityId = entity.Id,
                    EntityType = entity.GetType().Name
                };

                DatabaseContext.Add(slugObj);
                await DatabaseContext.SaveChangesAsync();
            }

            return slugObj;
        }

        public async Task DeleteSlug(long slugId)
        {
            var entity = await DatabaseContext.Slugs.FindAsync(slugId);
            DatabaseContext.Remove(entity);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task<int> GetEntityIdBySlug<TEntity>(string slug) where TEntity : Entity
        {

            var entity = await DatabaseContext.Slugs.AsNoTracking()
                .FirstOrDefaultAsync(e => e.EntityType == typeof(TEntity).Name && e.Name == slug);

            return entity.EntityId;
        }

        public async Task<Slug> GetSlugForEntity<TEntity>(TEntity entity) where TEntity : Entity
        {
            var slugs = await DatabaseContext.Slugs.AsNoTracking()
                .Where(e => e.EntityType == typeof(TEntity).Name && e.EntityId == entity.Id)
                .ToListAsync();

            return slugs.OrderByDescending(e => e.Created).FirstOrDefault();
        }

        public async Task ClearSlugs()
        {
            DatabaseContext.RemoveRange(DatabaseContext.Slugs);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task GenerateSlugs()
        {
            var movies = await DatabaseContext.Movies.AsNoTracking().ToListAsync();
            foreach (var item in movies)
            {
                await GetOrCreateSlugForEntity(item);
            }

            var castcrew = await DatabaseContext.CastCrewMember.AsNoTracking().ToListAsync();
            foreach (var item in castcrew)
            {
                await GetOrCreateSlugForEntity(item);
            }

            var characters = await DatabaseContext.Characters.AsNoTracking().ToListAsync();
            foreach (var item in characters)
            {
                await GetOrCreateSlugForEntity(item);
            }

            var articles = await DatabaseContext.Articles.AsNoTracking().ToListAsync();
            foreach (var item in articles)
            {
                await GetOrCreateSlugForEntity(item);
            }

            var genres = await DatabaseContext.Genres.AsNoTracking().ToListAsync();
            foreach (var item in genres)
            {
                await GetOrCreateSlugForEntity(item);
            }

            var tvshows = await DatabaseContext.TVShows.AsNoTracking().ToListAsync();
            foreach (var item in tvshows)
            {
                await GetOrCreateSlugForEntity(item);
            }
        }
    }
}
