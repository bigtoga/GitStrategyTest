using System;
using System.Collections.Generic;
using System.Linq;
using Tournaments.Models;

namespace Tournaments.Services
{
    public interface IDataProvider
    {
        IEnumerable<Team> GetTeams();

        IEnumerable<Team> GetTeamById(int id);

        IEnumerable<Tournament> GetTournaments();

        IEnumerable<Tournament> GetTournamentById(int id);

        IEnumerable<Player> GetPlayers();

        Player GetPlayerById(int id);

        IEnumerable<Sponsor> GetSponsors();

        Sponsor GetSponsorById(int id);

        void SavePlayer(Player player);

        int UpdateTeam(Team team);

        int InsertTeam(Team team);

        int DeleteTeam(int id);

        //IQueryable<Category> GetAllCategoriesWithBooksIncluded();

        IQueryable<Team> GetAllTeamsSortedById();

       




    }
}
