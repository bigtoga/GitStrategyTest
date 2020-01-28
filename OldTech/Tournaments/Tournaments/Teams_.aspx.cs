using Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tournaments.Models;
using Tournaments.Models_project;
using Tournaments.Presenters;
using Tournaments.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Tournaments
{
    [PresenterBinding(typeof(TeamPresenter))]
    public partial class Teams_ : MvpPage<TeamViewModel>, ITeamView
    {
        public event EventHandler MyInit;
        public event EventHandler OnGetData;
        public event EventHandler OnInsertItem;
        public event EventHandler<IdEventArgs> OnDeleteItem;
        public event EventHandler<IdEventArgs> OnUpdateItem;
        public event EventHandler<GenericEventArgs<Team>> OnCreateItem;

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression

        public IQueryable<ITeam> GridViewTeams_GetData()
        {
            this.OnGetData?.Invoke(this, null);

            return this.Model.Teams.AsQueryable();
        }

        public void GridViewTeams_InsertItem()
        {
            this.OnInsertItem?.Invoke(this, null);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewTeams_DeleteItem(int? id)
        {

            this.OnDeleteItem?.Invoke(this, new IdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewTeams_UpdateItem(int? id)
        {
            this.OnUpdateItem?.Invoke(this, new IdEventArgs(id));
        }

    }
}