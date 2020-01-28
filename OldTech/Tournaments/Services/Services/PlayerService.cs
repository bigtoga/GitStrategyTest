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
    public class PlayerService : IPlayerService
    {
        private readonly ITournamentsRepository<Player> playerRepository;

        public PlayerService(ITournamentsRepository<Player> playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return this.playerRepository.All();
        }

        public IEnumerable<Player> GetPlayerById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid id");
            }
            return this.playerRepository.All().Where(p => p.Id == id).ToList(); // TODO TO LIST?

        }

        public Team GetTeam(int playerId)  //get team
        {
            if (playerId < 0)
            {
                throw new ArgumentException("Invalid playerId");
            }
            return this.playerRepository.GetById(playerId).Team;
        }


        public int UpdatePlayer(Player player)
        {
            //var entry = this.tournamentsDbContext.Entry(team);
            //entry.State = EntityState.Modified;

            //return this.tournamentsDbContext.SaveChanges();

            if (player == null)
            {
                throw new ArgumentException("Player cannot be null.");
            }
            this.playerRepository.Update(player);
            return 1;
        }

        public int InsertPlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null.");
            }

            this.playerRepository.Add(player);

            return 1;
        }

        public int DeletePlayer(int playerId)
        {
            if (playerId < 0)
            {
                throw new ArgumentException("Invalid playerId");
            }

            Player player = this.playerRepository.GetById(playerId);
            this.playerRepository.Delete(player);
            return 1;
        }

        public IEnumerable<Player> GetAllPlayersSortedById()
        {
            return this.playerRepository.All(); // TODO OrderBy<Team>(t=>t.Id);
        }

        public void SavePlayer(Player player)
        {
            if (player == null)
                    {
                        throw new ArgumentException("Player cannot be null.");
                    }
                this.playerRepository.Add(player);
        }

        //public int JoinTeam(Team team)
        //{

        //    if (team == null)
        //    {
        //        throw new ArgumentException("Team cannot be null.");
        //    }


        //}
    }
}