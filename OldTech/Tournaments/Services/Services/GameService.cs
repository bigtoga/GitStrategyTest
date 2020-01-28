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
    public class GameService : IGameService
    {
        private readonly ITournamentsRepository<Game> gameRepository;

        public GameService(ITournamentsRepository<Game> gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public IEnumerable<Game> GetGames()
        {
            return this.gameRepository.All();
        }

        public IEnumerable<Game> GetGameById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid id");
            }
            return this.gameRepository.All().Where(g => g.Id == id).ToList(); // TODO TO LIST?

        }

        //public Tournament GetTournament() 
        //{   
        //    return this.gameRepository.Tournament;
        //}

        //public IEnumerable<Team> GetTeams()
        //{            
        //    return this.gameRepository.Teams.ToList();
        //}


        public int UpdateGame(Game game)
        {        

            if (game == null)
            {
                throw new ArgumentException("Game cannot be null.");
            }
            this.gameRepository.Update(game);
            return 1;
        }

        public int InsertGame(Game game)
        {
            if (game == null)
            {
                throw new ArgumentException("Game cannot be null.");
            }

            this.gameRepository.Add(game);

            return 1;
        }

        public int DeleteGame(int gameId)
        {
            if (gameId < 0)
            {
                throw new ArgumentException("Invalid gameId");
            }

            Game game = this.gameRepository.GetById(gameId);
            this.gameRepository.Delete(game);
            return 1;
        }

        public IEnumerable<Game> GetAllGamesSortedById()
        {
            return this.gameRepository.All(); // TODO OrderBy<Team>(t=>t.Id);
        }

        //public int JoinGame(Team team)
        //{
        //    if (team == null)
        //    {
        //        throw new ArgumentException("Team cannot be null.");
        //    }

        //    if (this.gameRepository.Teams.Count()>1)
        //    {
        //        throw new ArgumentException("Game already full.");
        //    }

        //    this.gameRepository.Teams.Add(team);
        //    return 1;
        //}
    }
}