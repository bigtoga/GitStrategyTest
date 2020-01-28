using Microsoft.AspNet.Identity.EntityFramework;
using Models.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tournaments.Contracts;
using Tournaments.Migrations;
using System;
using System.Data.Entity.Infrastructure;

namespace Tournaments.Models
{
    public class TournamentsDbContext : IdentityDbContext<User>, ITournamentsDbContext
    {
        public TournamentsDbContext()
            : base("TournamentsDb2")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TournamentsDbContext, Configuration>());
        }

        public IDbSet<Team> Teams { get; set; }
    
        public IDbSet<Tournament> Tournaments { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Game> Games { get; set; }
        public IDbSet<Sponsor> Sponsors { get; set; }

        //public object DbSet { get; set; }

        public IDbSet<SponsorsTournaments> SponsorsTournamentsTable;

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new void Dispose()
        {
            base.Dispose();  // TODO CONTAINER?
        }

        public static TournamentsDbContext Create() //TODO HOW ABOUT NO
        {
            return new TournamentsDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        //IDbSet<SponsorsTournaments> ITournamentsDbContext.SponsorsTournamentsTable()
        //{
        //    throw new NotImplementedException();
        //}
    }
}