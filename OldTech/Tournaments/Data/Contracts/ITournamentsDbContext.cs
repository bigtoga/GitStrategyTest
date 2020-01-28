using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Tournaments.Models;

namespace Tournaments.Contracts
{
    public interface ITournamentsDbContext
    {
        IDbSet<Team> Teams { get; set; }
        IDbSet<Tournament> Tournaments { get; set; }
        IDbSet<Player> Players { get; set; }
        IDbSet<Game> Games { get; set; }
        //IDbSet<SponsorsTournaments> SponsorsTournamentsTable();

        IDbSet<Sponsor> Sponsors { get; set; }
        

        int SaveChanges();

        DbEntityEntry Entry(object entity);

       // TournamentsDbContext Create(); 
    }
}
