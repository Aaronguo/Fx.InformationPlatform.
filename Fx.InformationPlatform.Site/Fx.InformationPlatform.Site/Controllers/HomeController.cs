using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Base.IService;
using Fx.Entity.FxCar;
using Fx.Entity.FxGoods;
using Fx.Entity.FxHouse;
using Fx.InformationPlatform.Site.ViewModel;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class HomeController : Controller
    {
        private FxCacheService.FxGoods.GoodsCache goodsCache;
        private FxCacheService.FxHouse.HouseCache houseCache;
        private FxCacheService.FxCar.CarCache carCache;
        public HomeController(FxCacheService.FxGoods.GoodsCache goodsCache,
            FxCacheService.FxHouse.HouseCache houseCache,
            FxCacheService.FxCar.CarCache carCache)
        {
            this.goodsCache = goodsCache;
            this.houseCache = houseCache;
            this.carCache = carCache;
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(CreateModel());
        }



        private HomeModel CreateModel()
        {
            var model = new HomeModel();
            model.GoodsTransferInfos = goodsCache.GetHomeLatest();
            model.CarTransferInfos = carCache.GetHomeLatest();
            model.HouseTransferInfos = houseCache.GetHomeLatest();
            return model;
        }


        public ActionResult GoodsShow()
        {
            return View();
        }
    }
}
