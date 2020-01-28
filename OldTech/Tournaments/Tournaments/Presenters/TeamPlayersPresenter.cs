using Bytes2you.Validation;
using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Models;
using Tournaments.Services;
using Tournaments.Views;
using WebFormsMvp;

namespace Tournaments.Presenters
{
    public class TeamPlayersPresenter : Presenter<ITeamPlayersView>
    {
        private readonly ITeamService teamService;

        public TeamPlayersPresenter(ITeamPlayersView view, ITeamService teamService)
            : base(view)
        {
            Guard.WhenArgument(teamService, "TeamService").IsNull().Throw();
            Guard.WhenArgument(view, "TeamView").IsNull().Throw();

            this.teamService = teamService;
             this.View.MyInit += this.View_Init;
            this.View.OnSelectedIndexChanged += this.View_OnSelectedIndexChanged;
            

    }

        private void View_Init(object sender, EventArgs e)
        {
            this.View.Model.Teams = this.teamService.GetTeams();
        }

        private void View_OnSelectedIndexChanged(object sender, IdEventArgs e)
        {
            if (e.Id == null)
            {
                throw new ArgumentNullException("Team in TeamPlayerPresenter id cannot be null"); 
            }
            this.View.Model.Players = this.teamService.GetPlayers((int)e.Id);// GetTeams();

        }


    }

}
