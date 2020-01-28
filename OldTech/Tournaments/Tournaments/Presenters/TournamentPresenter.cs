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
    public class TournamentPresenter : Presenter<ITournamentView>
    {
        private readonly ITournamentService tournamentService;

        public TournamentPresenter(ITournamentView view, ITournamentService tournamentService)
            : base(view)
        {
            Guard.WhenArgument(tournamentService, "TournamentService").IsNull().Throw();
            Guard.WhenArgument(view, "TournamentView").IsNull().Throw();

            this.tournamentService = tournamentService;
            this.View.MyInit += this.View_Init;
            this.View.OnGetData += this.View_OnGetData;
            this.View.OnInsertItem += this.View_OnInsertItem;
            this.View.OnDeleteItem += this.View_OnDeleteItem;
            this.View.OnUpdateItem += this.View_OnUpdateItem;

        }

        private void View_Init(object sender, EventArgs e)
        {
            this.View.Model.Tournaments = this.tournamentService.GetTournaments();
        }

        private void View_OnUpdateItem(object sender, IdEventArgs e)
        {
            if (e.Id == null)
            {
                throw new ArgumentNullException("Update tournament Id cannot be null");
            }

            var tournament = this.tournamentService.GetTournamentById((int)e.Id);
            if (tournament == null)
            {
                // The item wasn't found
                this.View.ModelState.
                    AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }

            Tournament item = this.tournamentService.GetTournamentById((int)e.Id).FirstOrDefault();


            this.View.TryUpdateModel(item);
            if (this.View.ModelState.IsValid)
            {
                this.tournamentService.UpdateTournament(item);
            }
            else
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
                throw new ArgumentNullException("Delete tournament Id cannot be null");
            }
            this.tournamentService.DeleteTournament((int)e.Id);
        }

        private void View_OnInsertItem(object sender, EventArgs e)
        {
            Tournament tournament = new Tournament();
            this.View.TryUpdateModel(tournament);
            if (this.View.ModelState.IsValid)
            {
                this.tournamentService.InsertTournament(tournament);
            }
        }

        private void View_OnGetData(object sender, EventArgs e)
        {
            this.View.Model.Tournaments = this.tournamentService.GetAllTournamentsSortedById();
        }
    }
}