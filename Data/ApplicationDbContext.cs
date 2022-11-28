using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CastCrewMember> Actors { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<AwardCategory> AwardCategories { get; set; }
        public DbSet<AwardRecipient> ActorAwards { get; set; }
        public DbSet<AwardRecipient> AwardRecipients { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieSeries> MovieSeries { get; set; }
        public DbSet<MovieStudio> MovieStudios { get; set; }
        public DbSet<JobRole> JobRoles { get; set; }
        public DbSet<TVShow> TVShows { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<FactType> FactTypes { get; set; }
        public DbSet<CastCrewMember> CastCrewMember { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<ProductionRole> ProductionRoles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ListArticle> ListArticles { get; set; }
        public DbSet<GenreLink> GenreLink { get; set; }
        public DbSet<SeriesMovie> SeriesMovie { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<ProductionLink> ProductionLinks { get; set; }
        public DbSet<TVNetwork> TVNetworks { get; set; }
        public DbSet<Slug> Slugs { get; set; }
        public DbSet<Featured> Featured { get; set; }
    }
}
