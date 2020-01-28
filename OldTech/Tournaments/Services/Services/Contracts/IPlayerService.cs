using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models;

namespace Services.Services.Contracts
{
    public interface IPlayerService
    {
       IEnumerable<Player> GetPlayers();

        IEnumerable<Player> GetPlayerById(int id);

        Team GetTeam(int playerId);

        int UpdatePlayer(Player player);

        int InsertPlayer(Player player);

        int DeletePlayer(int playerId);

        IEnumerable<Player> GetAllPlayersSortedById();

        void SavePlayer(Player player);       
    }
}
