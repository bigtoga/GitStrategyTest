[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Tournaments.App_Start.NinjectWeb), "Start")]

namespace Tournaments.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject.Web;
    using System;

    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {            
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
