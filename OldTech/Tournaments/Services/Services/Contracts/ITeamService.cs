using Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models;

namespace Services.Services.Contracts
{
    public interface ITeamService
    {
        IEnumerable<Team> GetTeams();

        IEnumerable<Team> GetTeamById(int id);


        IEnumerable<Player> GetPlayers(int teamId);

        int UpdateTeam(Team team);

        int InsertTeam(Team team);


        int DeleteTeam(int teamId);

        IEnumerable<Team> GetAllTeamsSortedById();

    }
}
