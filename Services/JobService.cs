using Microsoft.EntityFrameworkCore;
using MyMDB.Data;
using MyMDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMDB.Services
{
    public interface IJobService
    {
        Task<CastCrewMember> GetCastCrewMemberById(int id);
        Task<IEnumerable<CastCrewMember>> GetAllCastCrewMembers();
        Task<ProductionRole> GetProductionRoleById(int id);
        Task<IEnumerable<ProductionRole>> GetAllProductionRoles();
        Task<JobRole> GetJobRoleById(int id);
        Task<IEnumerable<JobRole>> GetAllJobRoles();
        Task<Character> GetCharacterById(int id);
        Task<IEnumerable<Character>> GetAllCharacters();
        Task<IEnumerable<ProductionRole>> GetProductionRolesByCastCrewMemberId(int id);
        Task<IEnumerable<ProductionRole>> GetProductionRolesByTVShowId(int id);
        Task<IEnumerable<ProductionRole>> GetProductionRolesByCharacterId(int id);
    }

    public class JobService : IJobService
    {
        public JobService(ApplicationDbContext context,
            ITVService tVService,
            IMovieService movieService)
        {
            Context = context;
            TVService = tVService;
            MovieService = movieService;
        }

        public ApplicationDbContext Context { get; }
        public ITVService TVService { get; }
        public IMovieService MovieService { get; }

        public async Task<IEnumerable<CastCrewMember>> GetAllCastCrewMembers()
        {
            var castCrewMembers = await Context.CastCrewMember
                .AsNoTracking()
                .ToListAsync();
            return castCrewMembers;
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            var characters = await Context.Characters
                            .AsNoTracking()
                            .ToListAsync();
            return characters;
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

        public async Task<IEnumerable<JobRole>> GetAllJobRoles()
        {
            var jobRoles = await Context.JobRoles
                            .AsNoTracking()
                            .ToListAsync();
            return jobRoles;
        }

        public async Task<CastCrewMember> GetCastCrewMemberById(int id)
        {
            var x = await Context.CastCrewMember
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.Award)
                .Include(e => e.AwardRecipients)
                .ThenInclude(e => e.AwardCategory)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return x;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await Context.Characters
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);
            return character;
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

        public async Task<JobRole> GetJobRoleById(int id)
        {
            var jobRole = await Context.JobRoles
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == id);
            return jobRole;
        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByCastCrewMemberId(int id)
        {
            var castCrewMember = await GetCastCrewMemberById(id);
            var roles = await Context.ProductionRoles
                .Include(e => e.Movie)
                .Include(e => e.Episode)
                .Include(e => e.MediaFiles)
                .Include(e => e.Character)
                .Include(e => e.JobRole)
                .AsNoTracking()
                .Where(e => e.CastCrewMemberId == castCrewMember.Id)
                .ToListAsync();
            return roles;

        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByEpisodeId(int id)
        {
            var epsisode = await TVService.GetEpisodeById(id);
            var roles = await Context.ProductionRoles
                .Include(e => e.Movie)
                .Include(e => e.Episode)
                .Include(e => e.MediaFiles)
                .Include(e => e.Character)
                .Include(e => e.JobRole)
                .AsNoTracking()
                .Where(e => e.EpisodeId == epsisode.Id)
                .ToListAsync();
            return roles;

        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByTVShowId(int id)
        {
            var tvShow = await TVService.GetTVShowById(id);
            var episodes = await TVService.GetEpisodesByTVShowId(tvShow.Id);

            var roles = new List<ProductionRole>();
            foreach (var episode in episodes)
            {
                foreach (var role in episode.ProductionRoles)
                {
                    roles.Add(role);
                }
            }
            return roles;
        }

        public async Task<IEnumerable<ProductionRole>> GetProductionRolesByCharacterId(int id)
        {
            var character = await GetCharacterById(id);
            var roles = await Context.ProductionRoles
                .AsNoTracking()
                .Include(e => e.Movie)
                .Include(e => e.Episode)
                .Include(e => e.MediaFiles)
                .Include(e => e.Character)
                .Include(e => e.CastCrewMember)
                .Include(e => e.JobRole)
                .Where(e => e.CharacterId == character.Id)
                .ToListAsync();
            return roles;
        }

    }
}
