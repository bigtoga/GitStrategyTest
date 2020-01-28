using Bytes2you.Validation;
using Services.Services.Contracts;
using System;
using System.Linq;
using Tournaments.Models;
using Tournaments.Services;
using Tournaments.Views;
using WebFormsMvp;

namespace Tournaments.Presenters
{
    public class PlayerPresenter : Presenter<IPlayerView>
    {
        private readonly IPlayerService playerService;

        public PlayerPresenter(IPlayerView view, IPlayerService playerService)
            : base(view)
        {
            Guard.WhenArgument(playerService, "PlayerService").IsNull().Throw();
            Guard.WhenArgument(view, "PlayerView").IsNull().Throw();

            this.playerService = playerService;
            this.View.MyInit += this.View_Init;
            this.View.OnGetData += this.View_OnGetData;
            this.View.OnInsertItem += this.View_OnInsertItem;
            this.View.OnDeleteItem += this.View_OnDeleteItem;
            this.View.OnUpdateItem += this.View_OnUpdateItem;

        }

        private void View_Init(object sender, EventArgs e)
        {
            this.View.Model.Players = this.playerService.GetPlayers();
        }

        private void View_OnUpdateItem(object sender, IdEventArgs e)
        {
            if (e.Id == null)
            {
                throw new ArgumentNullException("Update player Id cannot be null");
            }

            Player item = this.playerService.GetPlayerById((int)e.Id).FirstOrDefault();
            if (item == null)
            {
                // The item wasn't found
                this.View.ModelState.
                    AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(item);
            if (this.View.ModelState.IsValid)
            {
                this.playerService.UpdatePlayer(item);
            }
        }

        private void View_OnDeleteItem(object sender, IdEventArgs e)
        {
            if (e.Id == null)
            {
                throw new ArgumentNullException("Delete player Id cannot be null");
            }
            this.playerService.DeletePlayer((int)e.Id);
        }

        private void View_OnInsertItem(object sender, EventArgs e)
        {
            Player player = new Player();
            this.View.TryUpdateModel(player);
            if (this.View.ModelState.IsValid)
            {
                this.playerService.InsertPlayer(player);
            }
        }

        private void View_OnGetData(object sender, EventArgs e)
        {
            this.View.Model.Players = this.playerService.GetAllPlayersSortedById();
        }
    }
}