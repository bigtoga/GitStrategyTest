using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models;

namespace Services.Services.Contracts
{
    public interface ISponsorService
    {
        IEnumerable<Sponsor> GetSponsors();

        IEnumerable<Sponsor> GetSponsorById(int id);

        //IEnumerable<Tournament> GetSponsoredTournaments(int tournamentId);

        //IEnumerable<Team> GetSponsoredTeams(int teamId);

        int UpdateSponsor(Sponsor sponsor);

        int InsertSponsor(Sponsor sponsor);

        int DeleteSponsor(int sponsorId);

        IEnumerable<Sponsor> GetAllSponsorsSortedById();
        
        //int AddSponsoredTeam(Team team);
        
        //int AddSponsoredTournament(Tournament tournament);        
    }
}
