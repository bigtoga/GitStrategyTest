using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Tournaments.Models;

namespace Tournaments.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TournamentsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

            this.ContextKey = "Tournaments.TournamentsDbContext";
        }
        //https://docs.microsoft.com/en-us/azure/app-service-web/web-sites-dotnet-deploy-aspnet-mvc-app-membership-oauth-sql-database
        //In the Package Manager Console enter the command:  update-database
        protected override void Seed(TournamentsDbContext context)
        {
            if (context.Teams.Any())
            {
                return;
            }

            var teams = new List<Team>
            {
                new Team { Name="Team1",Rating=1},
                new Team { Name="Team2",Rating=2}
            };

            var tournaments = new List<Tournament>
            {
                new Tournament { Name="Tournament1",Date=new DateTime(2016,2,1), Prize=1},
                new Tournament { Name="Tournament2",Date=new DateTime(2016,2,2), Prize=2},

            };
            var players = new List<Player>
            {
                new Player() { FirstName="FirstName1", LastName="LastName1",NickName="NickName1", Picture="picture1",Email="email1",Rating=1,TeamId=1,IsCoach=false,CV="cv1"},
                new Player() { FirstName="FirstName2", LastName="LastName2",NickName="NickName2", Picture="picture2",Email="email2",Rating=1,TeamId=1,IsCoach=false,CV="cv2"},

            };

            var sponsors = new List<Sponsor>
            {
                new Sponsor() { Name = "Name1" },
                new Sponsor() { Name = "Name2" }
            };

            teams.ForEach(team => context.Teams.Add(team));
            tournaments.ForEach(tournament => context.Tournaments.Add(tournament));
            context.SaveChanges();
            players.ForEach(player => context.Players.Add(player));
            context.SaveChanges();

            sponsors.ForEach(sponsor => context.Sponsors.Add(sponsor));

        }
    }
}


