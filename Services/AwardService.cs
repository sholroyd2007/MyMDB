using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMDB.Services
{
    public interface IAwardService
    {
        Task<Award> GetAwardById(int id);
        Task<AwardCategory> GetAwardCategoryById(int id);
        Task<AwardRecipient> GetAwardRecipientById(int id);
        Task<IEnumerable<Award>> GetAllAwards();
        Task<IEnumerable<AwardCategory>> GetAllAwardCategories();
        Task<IEnumerable<AwardRecipient>> GetAllAwardRecipients();
    }

    public class AwardService : IAwardService
    {
        public AwardService(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public async Task<IEnumerable<Award>> GetAllAwards()
        {
            var awards = await Context.Awards
                .AsNoTracking()
                .ToListAsync();
            return awards;
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

    }
}
