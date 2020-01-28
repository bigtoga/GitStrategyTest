using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;

namespace Tournaments.Models_project
{
    public class TournamentViewModel
    {
        public IEnumerable<Tournament> Tournaments { get; set; }
    }
}