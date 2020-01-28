using Bytes2you.Validation;
using Models.Contracts;
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
    public class TeamPresenter : Presenter<ITeamView>
    {
        private readonly ITeamService teamService;

        public TeamPresenter(ITeamView view, ITeamService teamService)
            : base(view)
        {
            Guard.WhenArgument(teamService, "TeamService").IsNull().Throw();
            Guard.WhenArgument(view, "TeamView").IsNull().Throw();

            this.teamService = teamService;
            this.View.MyInit += this.View_Init;
            this.View.OnGetData+=this.View_OnGetData;
            this.View.OnInsertItem += this.View_OnInsertItem;
            this.View.OnDeleteItem += this.View_OnDeleteItem;
            this.View.OnUpdateItem += this.View_OnUpdateItem;
            this.View.OnCreateItem += this.View_OnCreateItem;

        }

        private void View_Init(object sender, EventArgs e)
        {
            this.View.Model.Teams = this.teamService.GetTeams();
        }

        private void View_OnUpdateItem(object sender, IdEventArgs e)
        {
            if(e.Id==null){
                throw new ArgumentNullException("Update team Id cannot be null");
            }

            var team = this.teamService.GetTeamById((int)e.Id);
            if (team == null)
            {
                // The item wasn't found
                this.View.ModelState.
                    AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }

            Team item = this.teamService.GetTeamById((int) e.Id).FirstOrDefault();
            

            this.View.TryUpdateModel(item);
            if (this.View.ModelState.IsValid)
            {
                this.teamService.UpdateTeam(item);
            }else
            {
                this.View.ModelState.
                    AddModelError("", String.Format("Item with id {0} cannot be updated", e.Id));
                return;
            }

        }

        private void View_OnDeleteItem(object sender, IdEventArgs e)
        {
            if (e.Id == null)
            {
                throw new ArgumentNullException("Delete team Id cannot be null");
            }
            this.teamService.DeleteTeam((int) e.Id);
        }

        private void View_OnInsertItem(object sender, EventArgs e)
        {
            Team team = new Team();
            this.View.TryUpdateModel(team);
            if (this.View.ModelState.IsValid)
            {
                this.teamService.InsertTeam(team);
            }
        }

        private void View_OnGetData(object sender, EventArgs e)
        {
            this.View.Model.Teams = this.teamService.GetAllTeamsSortedById();
        }

        private void View_OnCreateItem(object sender, GenericEventArgs<Team> e)
        {
            Team team = new Team() { Name = e.EntityProp.Name,Rating=e.EntityProp.Rating };
            this.teamService.InsertTeam(team);
        }
    }

}
