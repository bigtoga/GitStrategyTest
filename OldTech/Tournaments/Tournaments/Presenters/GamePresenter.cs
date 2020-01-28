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
    public class GamePresenter : Presenter<IGameView>
    {
        private readonly IGameService gameService;

        public GamePresenter(IGameView view, IGameService gameService)
            : base(view)
        {
            Guard.WhenArgument(gameService, "GameService").IsNull().Throw();
            Guard.WhenArgument(view, "GameView").IsNull().Throw();

            this.gameService = gameService;
            this.View.MyInit += this.View_Init;
            this.View.OnGetData += this.View_OnGetData;
            this.View.OnInsertItem += this.View_OnInsertItem;
            this.View.OnDeleteItem += this.View_OnDeleteItem;
            this.View.OnUpdateItem += this.View_OnUpdateItem;

        }

        private void View_Init(object sender, EventArgs e)
        {
            this.View.Model.Games = this.gameService.GetGames();
        }

        private void View_OnUpdateItem(object sender, IdEventArgs e)
        {
            if (e.Id == null)
            {
                throw new ArgumentNullException("Update game Id cannot be null");
            }

            Game item = this.gameService.GetGameById((int)e.Id).FirstOrDefault();
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
                this.gameService.UpdateGame(item);
            }
        }

        private void View_OnDeleteItem(object sender, IdEventArgs e)
        {
            if (e.Id == null)
            {
                throw new ArgumentNullException("Delete team Id cannot be null");
            }
            this.gameService.DeleteGame((int)e.Id);
        }

        private void View_OnInsertItem(object sender, EventArgs e)
        {
            Game game = new Game();
            this.View.TryUpdateModel(game);
            if (this.View.ModelState.IsValid)
            {
                this.gameService.InsertGame(game);
            }
        }

        private void View_OnGetData(object sender, EventArgs e)
        {
            this.View.Model.Games = this.gameService.GetAllGamesSortedById();
        }
    }
}
