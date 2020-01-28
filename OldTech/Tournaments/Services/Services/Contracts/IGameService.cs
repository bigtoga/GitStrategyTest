using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models;

namespace Services.Services.Contracts
{
    public interface IGameService
    {
        IEnumerable<Game> GetGames();

        IEnumerable<Game> GetGameById(int id);

        //Tournament GetTournament();        

        //IEnumerable<Team> GetTeams();

        int UpdateGame(Game game);

        int InsertGame(Game game);

        int DeleteGame(int gameId);

        IEnumerable<Game> GetAllGamesSortedById();        

        //int JoinGame(Team team)
        
    }
}
