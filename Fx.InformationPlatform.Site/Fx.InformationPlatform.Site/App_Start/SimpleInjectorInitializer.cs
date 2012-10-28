[assembly: WebActivator.PreApplicationStartMethod(typeof(Fx.InformationPlatform.Site.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Fx.InformationPlatform.Site.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.RegisterMvcAttributeFilterProvider();

            // Using Entity Framework? Please read this: http://simpleinjector.codeplex.com/discussions/363935
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // Please note that if you updated the SimpleInjector.MVC3 package from a previous version, this
            // SimpleInjectorInitializer class replaces the previous SimpleInjectorMVC3 class. You should
            // move the registrations from the old SimpleInjectorMVC3.InitializeContainer to this method,
            // and remove the SimpleInjectorMVC3 and SimpleInjectorMVC3Extensions class from the App_Start
            // folder.
            //#error Register your services here (remove this line).
            container.Register<Fx.Domain.Account.IService.IAccountService, Fx.Domain.Account.UserAccountService>();
            container.Register<Fx.Domain.FxSite.IService.IChannelService, Fx.Domain.FxSite.ChannelService>();
            container.Register<Fx.Domain.FxSite.IService.IPageAjax, Fx.Domain.FxSite.PublishAjaxService>();
            container.Register<Fx.Domain.FxSite.IService.IGoods, Fx.Domain.FxSite.GoodsService>();
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>();
        }
    }
}