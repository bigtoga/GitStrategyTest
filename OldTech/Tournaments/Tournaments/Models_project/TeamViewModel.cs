using Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.Models_project
{
    public class TeamPlayersViewModel
    {
        public IEnumerable<ITeam> Teams { get; set; }
        public IEnumerable<IPlayer> Players { get; set; }
    }
}