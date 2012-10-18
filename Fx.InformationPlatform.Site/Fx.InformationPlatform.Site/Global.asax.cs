using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace Fx.InformationPlatform.Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        //public static Container Container { get; private set; }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Fx.InformationPlatform.Site.Framework.ElmahHandledErrorLoggerFilter());
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Account", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            //CreateContainer();
           

            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            //Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");
            //Database.DefaultConnectionFactory = new SqlConnectionFactory("fx.site");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        //private static void CreateContainer()
        //{
        //    // 1. Create a new Simple Injector container
        //    var container = new Container();

        //    // 2. Configure the container (register)
        //    container.Register<Fx.Domain.Account.IService.IAccountService, Fx.Domain.Account.UserAccountService>();

        //    //container.RegisterSingle<ILogger>(() => new CompositeLogger(
        //    //    container.GetInstance<DatabaseLogger>(),
        //    //    container.GetInstance<MailLogger>()
        //    //));

        //    // 3. Optionally verify the container's configuration.
        //    container.Verify();

        //    // 4. Register the container as MVC3 IDependencyResolver.
        //    DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));            
        //}
    }
}