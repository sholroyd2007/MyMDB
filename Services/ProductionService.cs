using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMDB.Services
{
    public interface IProductionService
    {
        Task<IEnumerable<ProductionCompany>> GetAllProductionCompanies();
        Task<IEnumerable<ProductionLink>> GetAllProductionLinks();
        Task<IEnumerable<TVNetwork>> GetAllTVNetworks();

        Task<ProductionCompany> GetProductionCompanyById(int id);
        Task<ProductionLink> GetProductionLinkById(int id);
        Task<TVNetwork> GetTVNetworkById(int id);

        Task AddProductionCompany(ProductionCompany itemToAdd);
        Task AddProductionLink(ProductionLink itemToAdd);
        Task AddTVNetwork(TVNetwork itemToAdd);

        Task EditProductionCompany(ProductionCompany itemToEdit);
        Task EditProductionLink(ProductionLink itemToEdit);
        Task EditTVNetwork(TVNetwork itemToEdit);

        Task DeleteProductionCompany(int id);
        Task DeleteProductionLink(int id);
        Task DeleteTVNetwork(int id);
    }
    public class ProductionService : IProductionService
    {
        public ProductionService(ApplicationDbContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public ApplicationDbContext DatabaseContext { get; }

        public async Task AddProductionCompany(ProductionCompany itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddProductionLink(ProductionLink itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddTVNetwork(TVNetwork itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteProductionCompany(int id)
        {
            var item = await GetProductionCompanyById(id);
            item.Deleted = true;
            DatabaseContext.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteProductionLink(int id)
        {
            var item = await GetProductionLinkById(id);
            DatabaseContext.Remove(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteTVNetwork(int id)
        {
            var item = await GetTVNetworkById(id);
            item.Deleted = true;
            DatabaseContext.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditProductionCompany(ProductionCompany itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditProductionLink(ProductionLink itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditTVNetwork(TVNetwork itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductionCompany>> GetAllProductionCompanies()
        {
            var items = await DatabaseContext.ProductionCompanies
                .AsNoTracking()
                .ToListAsync();
            return items;
        }

        public async Task<IEnumerable<ProductionLink>> GetAllProductionLinks()
        {
            var items = await DatabaseContext.ProductionLinks
                .AsNoTracking()
                .Include(e=>e.ProductionCompany)
                .Include(e=>e.TVNetwork)
                .Include(e=>e.TVShow)
                .Include(e=>e.Movie)
                .ToListAsync();
            return items;
        }

        public async Task<IEnumerable<TVNetwork>> GetAllTVNetworks()
        {
            var items = await DatabaseContext.TVNetworks
                .AsNoTracking()
                .ToListAsync();
            return items;
        }

        public async Task<ProductionCompany> GetProductionCompanyById(int id)
        {
            var item = await DatabaseContext.ProductionCompanies
                .AsNoTracking()
                .FirstOrDefaultAsync(e=>e.Id == id);
            return item;
        }

        public async Task<ProductionLink> GetProductionLinkById(int id)
        {
            var item = await DatabaseContext.ProductionLinks
                .AsNoTracking()
                .Include(e => e.ProductionCompany)
                .Include(e => e.TVNetwork)
                .Include(e => e.TVShow)
                .Include(e => e.Movie)
                .FirstOrDefaultAsync(e => e.Id == id);
            return item;
        }

        public async Task<TVNetwork> GetTVNetworkById(int id)
        {
            var item = await DatabaseContext.TVNetworks
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return item;
        }
    }
}
