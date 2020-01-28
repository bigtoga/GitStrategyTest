using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Contracts;
using Tournaments.Models;
using Tournaments.Services;

namespace Tournaments.App_Start
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            System.Diagnostics.Debug.WriteLine("from data ninject module");
            //this.Bind<ITournamentsDbContext>().To<TournamentsDbContext>();
            //this.Bind<IDataProvider>().To<DataProvider>();
        }
    }
}