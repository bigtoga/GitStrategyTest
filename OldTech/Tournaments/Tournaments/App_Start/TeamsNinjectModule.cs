using Ninject.Modules;
using Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Contracts;
using Tournaments.Models;

using Tournaments.Presenters;
using Tournaments.Services;

namespace Tournaments.App_Start
{
    public class TeamsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //this.Bind<IDbContext>().To<MyNorthwindDbContext>().InRequestScope();

            this.Bind<IPlayerService>().To<PlayerService>();
            this.Bind<ITeamService>().To<TeamService>();
            this.Bind<ITournamentService>().To<TournamentService>();
            this.Bind<IGameService>().To<GameService>();
            this.Bind<ISponsorService>().To<SponsorService>();

            this.Bind<TeamPresenter>().ToSelf();
            this.Bind<TournamentPresenter>().ToSelf();
            this.Bind<PlayerPresenter>().ToSelf();
            this.Bind<SponsorPresenter>().ToSelf();
            this.Bind<GamePresenter>().ToSelf();

            this.Bind<ITournamentsDbContext>().To<TournamentsDbContext>();
            this.Bind(typeof(ITournamentsRepository<>)).To(typeof(TournamentsRepository<>)).InSingletonScope();
            //this.Bind<EmpDetailsPresenter>().ToSelf();

            //this.Bind<IDataProvider>().To<DataProvider>();
            //this.Bind<ITeamService>().To<TeamService>();
        }
    }
}