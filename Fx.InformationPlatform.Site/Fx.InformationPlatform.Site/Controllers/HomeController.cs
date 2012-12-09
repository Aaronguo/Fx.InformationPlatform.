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
    /// <summary>
    /// 首页
    /// </summary>
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

            model.HomeGoodsModel.GoodsTransferInfo1s = goodsCache.GetHomeLatest().Take(5).ToList();
            model.HomeGoodsModel.GoodsTransferInfo2s = goodsCache.GetHomeLatest().Skip(5).Take(5).ToList();
            model.HomeGoodsModel.GoodsTransferInfo3s = goodsCache.GetHomeTopShow();

            model.HomeCarModel.CarTransferInfo1s = carCache.GetHomeLatest().Take(5).ToList();
            model.HomeCarModel.CarTransferInfo2s = carCache.GetHomeLatest().Skip(5).Take(5).ToList();
            model.HomeCarModel.CarTransferInfo3s = carCache.GetHomeTopShow();

            model.HomeHouseModel.HouseTransferInfo1s = houseCache.GetHomeLatest().Take(5).ToList();
            model.HomeHouseModel.HouseTransferInfo2s = houseCache.GetHomeLatest().Skip(5).Take(5).ToList();
            model.HomeHouseModel.HouseTransferInfo3s = houseCache.GetHomeTopShow();
            return model;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchText">Key：查找关键字</param>
        /// <param name="logochose">Channel:二手物品</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult HomeSearchFacade(string searchTextModel, string logochoseModel)
        {
            string key = searchTextModel;
            string channel = logochoseModel;
            if (channel.Contains("二手"))
            {
                return RedirectToAction("GoodsTransferSearch", "Search",
                    new
                    {
                        key = key,
                        page = 1,
                        IsChangeByGoods = true,
                        IsChangeByPrice = true,
                        area = 0,
                        city = 0,
                        clc = 0
                    });
            }
            if (channel.Contains("汽车"))
            {
                return RedirectToAction("CarTransferSearch", "Search",
                    new
                    {
                        key = key,
                        page = 1,
                        area = 0,
                        city = 0,
                        clc = 0
                    });
            }
            if (channel.Contains("房屋"))
            {
                return RedirectToAction("HouseTransferSearch", "Search",
                    new
                    {
                        key = key,
                        page = 1,
                        area = 0,
                        city = 0,
                        clc = 0
                    });
            }
            return RedirectToAction("PageNotFound", "PageLink");
        }
    }
}
