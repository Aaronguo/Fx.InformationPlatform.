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
            InitSiteContainer(container);
            InitSearchContainer(container);
            InitCacheContainer(container);
            InitTaskContainer(container);

        }

        private static void InitCacheContainer(Container container)
        {
            container.RegisterSingle<FxCacheService.FxGoods.GoodsCache>();
            container.RegisterSingle<FxCacheService.FxHouse.HouseCache>();
            container.RegisterSingle<FxCacheService.FxCar.CarCache>();
        }



        private static void InitTaskContainer(Container container)
        {

            //container.RegisterSingle<Fx.Infrastructure.Caching.ICacheManager, Fx.Infrastructure.Caching.CacheManager>();
            container.RegisterSingle<FxTask.AppSettings>();
            container.RegisterSingle<FxTask.Filter>();

            //FxTaskFxCar
            container.Register<Fx.Domain.FxCar.IService.ICarBuyJob, Fx.Domain.FxCar.CarBuyJobService>();
            container.Register<Fx.Domain.FxCar.IService.ICarTransferJob, Fx.Domain.FxCar.CarTransferJobService>();

            //FxTaskFxGoods
            container.Register<Fx.Domain.FxGoods.IService.IGoodsBuyJob, Fx.Domain.FxGoods.GoodsBuyJobService>();
            container.Register<Fx.Domain.FxGoods.IService.IGoodsTransferJob, Fx.Domain.FxGoods.GoodsTransferJobService>();

            //FxTaskFxHouse
            container.Register<Fx.Domain.FxHouse.IService.IHouseBuyJob, Fx.Domain.FxHouse.HouseBuyJobService>();
            container.Register<Fx.Domain.FxHouse.IService.IHouseTransferJob, Fx.Domain.FxHouse.HouseTransferJobService>();
        }

        private static void InitSearchContainer(Container container)
        {
            //FxGoodsSearch
            container.RegisterSingle<Fx.Domain.Base.IService.IHomeSearch<Fx.Entity.FxGoods.GoodsTransferInfo>,
                Fx.Domain.FxGoods.Search.GoodsTransferSearchService>();


            //FxCarSearch
            container.RegisterSingle<Fx.Domain.Base.IService.IHomeSearch<Fx.Entity.FxCar.CarTransferInfo>,
             Fx.Domain.FxCar.Search.CarTransferSearchService>();

            //FxHouseSearch
            container.RegisterSingle<Fx.Domain.Base.IService.IHomeSearch<Fx.Entity.FxHouse.HouseTransferInfo>,
             Fx.Domain.FxHouse.Search.HouseTransferSearchService>();


        }


        private static void InitSiteContainer(Container container)
        {
            container.Register<Fx.Domain.Account.IService.IAccountService, Fx.Domain.Account.UserAccountService>();
            container.Register<Fx.Domain.FxSite.IService.IChannelService, Fx.Domain.FxSite.ChannelService>();
            container.Register<Fx.Domain.FxSite.IService.IPageAjax, Fx.Domain.FxSite.PublishAjaxService>();

            container.Register<Fx.Domain.FxSite.IService.IGoods, Fx.Domain.FxSite.GoodsService>();
            container.Register<Fx.Domain.FxSite.IService.ICar, Fx.Domain.FxSite.CarService>();
            container.Register<Fx.Domain.FxSite.IService.IHouse, Fx.Domain.FxSite.HouseService>();

            //FxGoods
            container.Register<Fx.Domain.FxGoods.IService.ITransferGoods, Fx.Domain.FxGoods.FxTransferGoodService>();
            container.Register<Fx.Domain.FxGoods.IService.IBuyGoods, Fx.Domain.FxGoods.FxBuyGoodsService>();

            //FxCar
            container.Register<Fx.Domain.FxCar.IService.ITransferCar, Fx.Domain.FxCar.FxTransferCarService>();
            container.Register<Fx.Domain.FxCar.IService.IBuyCar, Fx.Domain.FxCar.FxBuyCarService>();

            //FxHouse
            container.Register<Fx.Domain.FxHouse.IService.ITransferHouse, Fx.Domain.FxHouse.FxTransferHouseService>();
            container.Register<Fx.Domain.FxHouse.IService.IBuyHouse, Fx.Domain.FxHouse.FxBuyHouseService>();

            //FxAggregate 
            container.Register<Fx.Domain.FxAggregate.IService.IDbAll, Fx.Domain.FxAggregate.DbAllService>();
            container.Register<Fx.Domain.FxAggregate.IService.IFavorite, Fx.Domain.FxAggregate.FavoriteService>();

            //»º´æ·þÎñ
            container.RegisterSingle<Fx.Infrastructure.Caching.ICacheManager, Fx.Infrastructure.Caching.CacheManager>();
        }
    }
}