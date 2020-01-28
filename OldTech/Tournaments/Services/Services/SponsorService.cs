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
    public class SponsorService : ISponsorService
    {
        private readonly ITournamentsRepository<Sponsor> sponsorRepository;

        public SponsorService(ITournamentsRepository<Sponsor> sponsorRepository)
        {
            this.sponsorRepository = sponsorRepository;
        }

        public IEnumerable<Sponsor> GetSponsors()
        {
            return this.sponsorRepository.All();
        }

        public IEnumerable<Sponsor> GetSponsorById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid id");
            }
            return this.sponsorRepository.All().Where(t => t.Id == id).ToList(); // TODO TO LIST?

        }

        //public IEnumerable<Tournament> GetSponsoredTournaments(int tournamentId)
        //{
        //    if (tournamentId < 0)
        //    {
        //        throw new ArgumentException("Invalid tournamentId");
        //    }
        //    return this.sponsorRepository.Tournaments.Where(t=>t.id).ToList();
        //}

        //public IEnumerable<Team> GetSponsoredTeams(int teamId)
        //{
        //    if (teamId < 0)
        //    {
        //        throw new ArgumentException("Invalid teamId");
        //    }
        //    return this.sponsorRepository.Teams.Where(t=>t.id).ToList();
        //}


        public int UpdateSponsor(Sponsor sponsor)
        {

            if (sponsor == null)
            {
                throw new ArgumentException("Sponsor cannot be null.");
            }
            this.sponsorRepository.Update(sponsor);
            return 1;
        }

        public int InsertSponsor(Sponsor sponsor)
        {
            if (sponsor == null)
            {
                throw new ArgumentException("Sponsor cannot be null.");
            }

            this.sponsorRepository.Add(sponsor);

            return 1;
        }

        public int DeleteSponsor(int sponsorId)
        {
            if (sponsorId < 0)
            {
                throw new ArgumentException("Invalid sponsorId");
            }

            Sponsor sponsor = this.sponsorRepository.GetById(sponsorId);
            this.sponsorRepository.Delete(sponsor);
            return 1;
        }

        public IEnumerable<Sponsor> GetAllSponsorsSortedById()
        {
            return this.sponsorRepository.All(); // TODO OrderBy<Team>(t=>t.Id);
        }

        //public int AddSponsoredTeam(Team team)  //team id
        //{
        //    if (team == null)
        //    {
        //        throw new ArgumentException("Team cannot be null.");
        //    }
        //    this.sponsorRepository.Teams.Add(team);
        //return 1;
        //}

        //public int AddSponsoredTournament(Tournament tournament)  //tournament name
        //{
        //    if (tournament == null)
        //    {
        //        throw new ArgumentException("Tournament cannot be null.");
        //    }
        //    this.sponsorRepository.Tournaments.Add(tournament);
        //return 1;
        //}


    }
}