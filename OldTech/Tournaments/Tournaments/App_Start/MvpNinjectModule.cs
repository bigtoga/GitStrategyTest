using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournaments.Factories;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace Tournaments.App_Start
{
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            System.Diagnostics.Debug.WriteLine("We are in mvp ninject.module");
            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();

            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>().ToMethod(this.GetPresenter).NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var ctorParamter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, ctorParamter);
        }
    }
}