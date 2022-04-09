using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        Task AddAward(Award itemToAdd);
        Task AddAwardCategory(AwardCategory itemToAdd);
        Task AddAwardRecipient(AwardRecipient itemToAdd);

        Task EditAward(Award itemToEdit);
        Task EditAwardCategory(AwardCategory itemToEdit);
        Task EditAwardRecipient(AwardRecipient itemToEdit);

        Task DeleteAward(int id);
        Task DeleteAwardCategory(int id);
        Task DeleteAwardRecipient(int id);
    }

    public class AwardService : IAwardService
    {
        public ApplicationDbContext DatabaseContext { get; }

        public AwardService(ApplicationDbContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }


        public async Task<IEnumerable<Award>> GetAllAwards()
        {
            var awards = await DatabaseContext.Awards
                .AsNoTracking()
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return awards;
        }

        public async Task<Award> GetAwardById(int id)
        {
            var x = await DatabaseContext.Awards
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<AwardCategory> GetAwardCategoryById(int id)
        {
            var x = await DatabaseContext.AwardCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<AwardRecipient> GetAwardRecipientById(int id)
        {
            var x = await DatabaseContext.AwardRecipients
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
            var categories = await DatabaseContext.AwardCategories
                .AsNoTracking()
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<AwardRecipient>> GetAllAwardRecipients()
        {
            var recipients = await DatabaseContext.AwardRecipients
                .AsNoTracking()
                .Include(e => e.Award)
                .Include(e => e.AwardCategory)
                .Include(e => e.CastCrewMember)
                .Include(e => e.TVShow)
                .Include(e => e.Episode)
                .Include(e => e.Movie)
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return recipients;
        }

        public async Task DeleteAward(int id)
        {
            var item = await GetAwardById(id);
            item.Deleted = true;
            DatabaseContext.Awards.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteAwardCategory(int id)
        {
            var item = await GetAwardCategoryById(id);
            item.Deleted = true;
            DatabaseContext.AwardCategories.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteAwardRecipient(int id)
        {
            var item = await GetAwardRecipientById(id);
            item.Deleted = true;
            DatabaseContext.AwardRecipients.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddAward(Award itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddAwardCategory(AwardCategory itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddAwardRecipient(AwardRecipient itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditAward(Award itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditAwardCategory(AwardCategory itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditAwardRecipient(AwardRecipient itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
