using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models;

namespace Services.Services.Contracts
{
    public interface ITournamentService
    {
        IEnumerable<Tournament> GetTournaments();

        IEnumerable<Tournament> GetTournamentById(int id);

        //IEnumerable<Team> GetTeams(int tournamentId);

        int UpdateTournament(Tournament tournament);

        int InsertTournament(Tournament tournament);

        int DeleteTournament(int tournamentId);

        IEnumerable<Tournament> GetAllTournamentsSortedById();


        //int JoinTournament(Team team);//string teamName


        //int LeaveTournament(Team team); //string teamName

    }
}
