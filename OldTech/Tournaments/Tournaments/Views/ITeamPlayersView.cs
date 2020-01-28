using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using Tournaments.Models_project;
using WebFormsMvp;

namespace Tournaments.Views
{
    public interface ITeamPlayersView : IView<TeamPlayersViewModel>
    {
        event EventHandler MyInit;
        event EventHandler<IdEventArgs> OnSelectedIndexChanged;          
        
    }
}
