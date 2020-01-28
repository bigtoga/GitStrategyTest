using Models.Contracts;
using Services.Services;
using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tournaments.Contracts;
using Tournaments.Models;

namespace Tournaments.Services
{
    public class TournamentService :ITournamentService
    {
        private readonly ITournamentsRepository<Tournament> tournamentRepository;

        public TournamentService(ITournamentsRepository<Tournament> tournamentRepository)
        {
            this.tournamentRepository = tournamentRepository;
        }

        public IEnumerable<Tournament> GetTournaments()
        {
            return this.tournamentRepository.All();
        }

        public IEnumerable<Tournament> GetTournamentById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid id");
            }
            return this.tournamentRepository.All().Where(p => p.Id == id).ToList(); // TODO TO LIST?

        }

        //public IEnumerable<Team> GetTeams(int tournamentId)  //get team
        //{
        //    if (tournamentId < 0)
        //    {
        //        throw new ArgumentException("Invalid tournamentId");
        //    }
        //    return this.tournamentRepository.Teams.ToList();
        //}


        public int UpdateTournament(Tournament tournament)
        {            
            if (tournament == null)
            {
                throw new ArgumentException("Tournament cannot be null.");
            }
            this.tournamentRepository.Update(tournament);
            return 1;
        }

        public int InsertTournament(Tournament tournament)
        {
            if (tournament == null)
            {
                throw new ArgumentException("Tournament cannot be null.");
            }

            this.tournamentRepository.Add(tournament);

            return 1;
        }

        public int DeleteTournament(int tournamentId)
        {
            if (tournamentId < 0)
            {
                throw new ArgumentException("Invalid tournamentId");
            }

            Tournament tournament = this.tournamentRepository.GetById(tournamentId);
            this.tournamentRepository.Delete(tournament);
            return 1;
        }

        public IEnumerable<Tournament> GetAllTournamentsSortedById()
        {
            return this.tournamentRepository.All(); // TODO OrderBy<Team>(t=>t.Id);
        }

        //public int JoinTournament(Team team)
        //{
        //    if (team == null)
        //    {
        //        throw new ArgumentException("Team cannot be null.");
        //    }

        //    if (this.tournamentRepository.Teams.Contains(team))
        //    {
        //        throw new ArgumentException("Team has already been added.");
        //    }

        //    this.tournamentRepository.Teams.Add(team);
        //}

        //public int LeaveTournament(Team team)
        //{
        //    if (team == null)
        //    {
        //        throw new ArgumentException("Team cannot be null.");
        //    }

        //    if (!this.tournamentRepository.Teams.Contains(team))
        //    {
        //        throw new ArgumentException("Team does not participate in tournament.");
        //    }

        //    this.tournamentRepository.Teams.Remove(team);
        //}


    }
}