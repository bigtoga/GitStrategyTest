using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models;

namespace Models.Contracts
{
    public interface ITeam
    {

        int Id { get; set; }
        string Name { get; set; }
        double Rating { get; set; }
        ICollection<Player> Players { get; set; } //
    }
}
