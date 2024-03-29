﻿using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMDB.Services
{
    public interface ITVService
    {
        Task<TVShow> GetTVShowById(int id);
        Task<Episode> GetEpisodeById(int id);
        Task<IEnumerable<TVShow>> GetAllTVShows();
        Task<IEnumerable<Episode>> GetAllEpisodes();
        Task<IEnumerable<TVShow>> GetTVShowsByGenre(int id);
        Task<IEnumerable<Episode>> GetEpisodesByTVShowId(int id);
        Task<int> GetEpisodeCountByProductionRoleId(int id);

        Task AddTVShow(TVShow itemToAdd);
        Task AddEpisode(Episode itemToAdd);

        Task EditTVShow(TVShow itemToEdit);
        Task EditEpisode(Episode itemToEdit);

        Task DeleteEpisode(int id);
        Task DeleteTVShow(int id);

        Task<IEnumerable<TVShow>> GetHomepageRecommendedTv();
        Task<IEnumerable<Episode>> GetHomepageComingSoonTv();
    }

    public class TVService : ITVService
    {
        public ApplicationDbContext DatabaseContext { get; }

        public TVService(ApplicationDbContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }


        public async Task<IEnumerable<TVShow>> GetAllTVShows()
        {
            var shows = await DatabaseContext.TVShows
                .AsNoTracking()
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return shows;
        }

        public async Task<IEnumerable<TVShow>> GetTVShowsByGenre(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TVShow> GetTVShowById(int id)
        {
            var show = await DatabaseContext.TVShows
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return show;
        }

        public async Task<IEnumerable<Episode>> GetAllEpisodes()
        {
            var episodes = await DatabaseContext.Episodes
                .AsNoTracking()
                .Include(e => e.TVShow)
                .Where(e => e.Deleted == false)
                .ToListAsync();
            return episodes;
        }
        public async Task<Episode> GetEpisodeById(int id)
        {
            var x = await DatabaseContext.Episodes
                .AsNoTracking()
                .Include(e => e.TVShow)
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<IEnumerable<Episode>> GetEpisodesByTVShowId(int id)
        {
            var tvShow = await GetTVShowById(id);
            var episodes = await DatabaseContext.Episodes.AsNoTracking()
                .Where(e => e.TVShowId == tvShow.Id && e.Deleted == false)
                .ToListAsync();
            return episodes;
        }

        public async Task<int> GetEpisodeCountByProductionRoleId(int id)
        {
            var productionRole = await DatabaseContext.ProductionRoles
                            .AsNoTracking()
                            .Include(e => e.CastCrewMember)
                            .Include(e => e.JobRole)
                            .Include(e => e.Character)
                            .Include(e => e.Movie)
                            .Include(e => e.Episode)
                            .FirstOrDefaultAsync(e => e.Id == id);

            var roles = await DatabaseContext.ProductionRoles.AsNoTracking()
                .Where(e => e.CastCrewMemberId == productionRole.CastCrewMemberId
                && e.JobRoleId == productionRole.JobRoleId
                && e.Episode.TVShowId == productionRole.Episode.TVShowId)
                .ToListAsync();

            return roles.Count();
        }

        public async Task DeleteEpisode(int id)
        {
            var item = await GetEpisodeById(id);
            item.Deleted = true;
            DatabaseContext.Episodes.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteTVShow(int id)
        {
            var item = await GetTVShowById(id);
            item.Deleted = true;
            DatabaseContext.TVShows.Update(item);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddTVShow(TVShow itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task AddEpisode(Episode itemToAdd)
        {
            itemToAdd.Created = DateTime.UtcNow;
            DatabaseContext.Add(itemToAdd);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditTVShow(TVShow itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task EditEpisode(Episode itemToEdit)
        {
            itemToEdit.Edited = DateTime.UtcNow;
            DatabaseContext.Update(itemToEdit);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TVShow>> GetHomepageRecommendedTv()
        {
            var tvShows = await GetAllTVShows();
            return tvShows.Take(10);
        }

        public async Task<IEnumerable<Episode>> GetHomepageComingSoonTv()
        {
            var episodes = await GetAllEpisodes();
            return episodes.Where(e => e.AirDate < DateTime.Now.Date);
        }
    }
}
