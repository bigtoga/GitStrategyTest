using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    [PresenterBinding(typeof(TeamPlayersPresenter))]
    public partial class TeamPlayers : MvpPage<TeamPlayersViewModel>, ITeamPlayersView
    {
        public event EventHandler MyInit;
        public event EventHandler<IdEventArgs> OnSelectedIndexChanged;

        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.GetCurrent(this.Page).RegisterAsyncPostBackControl(this.GridViewTeams);
            if (!Page.IsPostBack)
            {
                this.MyInit?.Invoke(this, null);
                this.GridViewTeams.DataSource = this.Model.Teams;
                this.GridViewTeams.DataBind();
                //this.RebindOrders();
            }
        }

        protected void GridViewTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RebindOrders();
         }

        protected void GridViewPlayers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewPlayers.PageIndex = e.NewPageIndex;
            this.RebindOrders();
        }

        private void RebindOrders()
        {
            int teamId = Convert.ToInt32(this.GridViewTeams.SelectedValue);
            this.OnSelectedIndexChanged?.Invoke(this, new IdEventArgs(teamId));

            this.GridViewPlayers.DataSource = this.Model.Players.ToList();
            this.GridViewPlayers.DataBind();
        }

    }
}