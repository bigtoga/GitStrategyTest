using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models;

namespace Models.Contracts
{
    public interface IPlayer
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string NickName { get; set; }

        string Picture { get; set; }

        double? Rating { get; set; }

        bool? IsCoach { get; set; }

        string CV { get; set; }

        int? TeamId { get; set; }

        Team Team { get; set; }       
    }
}
