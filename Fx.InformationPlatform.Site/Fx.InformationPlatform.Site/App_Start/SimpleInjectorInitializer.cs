[assembly: WebActivator.PreApplicationStartMethod(typeof(Fx.InformationPlatform.Site.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Fx.InformationPlatform.Site.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using Fx.Domain.Base.IService;
    using Fx.Entity.FxCar;
    using Fx.Entity.FxGoods;
    using Fx.Entity.FxHouse;
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
            InitSiteContainer(container);
            InitSearchContainer(container);
            InitCacheContainer(container);
            InitJobContainer(container);
            InitAggregateContainer(container);
        }

        private static void InitAggregateContainer(Container container)
        {
            container.Register<Fx.Domain.FxAggregate.IService.IDbAll, Fx.Domain.FxAggregate.DbAllService>();
            container.Register<Fx.Domain.FxAggregate.IService.ITopShow, Fx.Domain.FxAggregate.TopShowService>();
            container.Register<Fx.Domain.FxAggregate.IService.IHomeTopShow, Fx.Domain.FxAggregate.TopShowService>();
            container.Register<Fx.Domain.FxAggregate.IService.IFavorite, Fx.Domain.FxAggregate.FavoriteService>();
            container.Register<Fx.Domain.FxAggregate.IService.IAggregateInfo, Fx.Domain.FxAggregate.AggregateInfoService>();
            container.Register<Fx.Domain.FxAggregate.IService.IPrivateMessage, Fx.Domain.FxAggregate.PrivateMessageService>();
            
        }

        private static void InitCacheContainer(Container container)
        {
            //缓存服务
            container.RegisterSingle<Fx.Infrastructure.Caching.ICacheManager, Fx.Infrastructure.Caching.CacheManager>();
            container.RegisterSingle<FxCacheService.FxGoods.GoodsCache>();
            container.RegisterSingle<FxCacheService.FxHouse.HouseCache>();
            container.RegisterSingle<FxCacheService.FxCar.CarCache>();
            container.RegisterSingle<FxCacheService.FxSite.SiteCache>();
            //缓存查询服务  为什么不使用接口注册？ISiteSearch<CarBuyInfo> 保持对外一致性 用于缓存
            container.Register<Fx.Domain.FxCar.Search.CarBuySearchService>();
            container.Register<Fx.Domain.FxCar.Search.CarTransferSearchService>();
            container.Register<Fx.Domain.FxGoods.Search.GoodsBuySearchService>();
            container.Register<Fx.Domain.FxGoods.Search.GoodsTransferSearchService>();
            container.Register<Fx.Domain.FxHouse.Search.HouseBuySearchService>();
            container.Register<Fx.Domain.FxHouse.Search.HouseTransferSearchService>();
            //领域层提供给缓存服务层专门拉取数据的接口
            container.Register<Fx.Domain.FxCar.IService.IGlobalCacheCar,Fx.Domain.FxCar.GlobalCacheCar>();
            container.Register<Fx.Domain.FxGoods.IService.IGlobalCacheGoods, Fx.Domain.FxGoods.GlobalCacheGoods>();
            container.Register<Fx.Domain.FxHouse.IService.IGolbalCacheHouse, Fx.Domain.FxHouse.GlobalHouseCache>();
        }


        private static void InitJobContainer(Container container)
        {
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
            container.Register<IHomeSearch<Fx.Entity.FxGoods.GoodsTransferInfo>,Fx.Domain.FxGoods.Search.GoodsTransferSearchService>();
            container.Register<ISiteSearch<GoodsTransferInfo>, Fx.Domain.FxGoods.Search.GoodsTransferSearchService>();
            container.Register<ISiteSearch<GoodsBuyInfo>, Fx.Domain.FxGoods.Search.GoodsBuySearchService>();           
            //GoodsConditionSearch
            container.Register<IGoodsSearch<GoodsTransferInfo>, Fx.Domain.FxGoods.Search.GoodsTransferSearchService>();
            container.Register<IGoodsSearch<GoodsBuyInfo>, Fx.Domain.FxGoods.Search.GoodsBuySearchService>();

            //FxCarSearch
            container.Register<IHomeSearch<Fx.Entity.FxCar.CarTransferInfo>,Fx.Domain.FxCar.Search.CarTransferSearchService>();
            container.Register<ISiteSearch<CarTransferInfo>, Fx.Domain.FxCar.Search.CarTransferSearchService>();
            container.Register<ISiteSearch<CarBuyInfo>, Fx.Domain.FxCar.Search.CarBuySearchService>();
            //CarConditionSearch
            container.Register<ICarSearch<CarTransferInfo>, Fx.Domain.FxCar.Search.CarTransferSearchService>();
            container.Register<ICarSearch<CarBuyInfo>, Fx.Domain.FxCar.Search.CarBuySearchService>();

            //FxHouseSearch
            container.Register<IHomeSearch<Fx.Entity.FxHouse.HouseTransferInfo>,Fx.Domain.FxHouse.Search.HouseTransferSearchService>();
            container.Register<ISiteSearch<HouseTransferInfo>, Fx.Domain.FxHouse.Search.HouseTransferSearchService>();
            container.Register<ISiteSearch<HouseBuyInfo>, Fx.Domain.FxHouse.Search.HouseBuySearchService>();
            //HouseConditionSearch
            container.Register<IHouseSearch<HouseTransferInfo>, Fx.Domain.FxHouse.Search.HouseTransferSearchService>();
            container.Register<IHouseSearch<HouseBuyInfo>, Fx.Domain.FxHouse.Search.HouseBuySearchService>();
        }


        private static void InitSiteContainer(Container container)
        {
            container.Register<Fx.Domain.Account.IService.IAccountService, Fx.Domain.Account.UserAccountService>();
            container.Register<Fx.Domain.FxSite.IService.IChannelService, Fx.Domain.FxSite.ChannelService>();
            container.Register<Fx.Domain.FxSite.IService.IPageAjax, Fx.Domain.FxSite.PublishAjaxService>();

            //ForSite
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

            //ListGet
            container.Register<Fx.Domain.FxCar.CarListService>();
            container.Register<Fx.Domain.FxGoods.GoodsListService>();
            container.Register<Fx.Domain.FxHouse.HouseListService>();
        }
    }
}