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
using FxCacheService.FxCar;
using FxCacheService.FxGoods;
using FxCacheService.FxHouse;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class SearchController : Controller
    {
        protected ISiteSearch<CarTransferInfo> transferCarSearch;
        protected ISiteSearch<HouseTransferInfo> transferHouseSearch;
        protected ISiteSearch<CarBuyInfo> buyCarSearch;
        protected ISiteSearch<HouseBuyInfo> buyHouseSearch;
        protected IGoodsSearch<GoodsTransferInfo> goodsTransferSearch;
        protected IGoodsSearch<GoodsBuyInfo> goodsBuySearch;
        public SearchController(ISiteSearch<CarTransferInfo> transferCarSearch,
            ISiteSearch<HouseTransferInfo> transferHouseSearch,
            ISiteSearch<CarBuyInfo> buyCarSearch,
            ISiteSearch<HouseBuyInfo> buyHouseSearch,
            IGoodsSearch<GoodsTransferInfo> goodsTransferSearch,
            IGoodsSearch<GoodsBuyInfo> goodsBuySearch)
        {
            this.transferCarSearch = transferCarSearch;
            this.transferHouseSearch = transferHouseSearch;
            this.buyCarSearch = buyCarSearch;
            this.buyHouseSearch = buyHouseSearch;
            this.goodsTransferSearch = goodsTransferSearch;
            this.goodsBuySearch = goodsBuySearch;
        }

        //Transfer 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="page">第几页取数据默认0 页面会传递1（逻辑对应）</param>
        /// <param name="IsChangeByGoods">是否按换物交换</param>
        /// <param name="IsChangeByPrice">是否按价格交换</param>
        /// <param name="area">区域</param>
        /// <param name="city">城市</param>
        /// <param name="clc">二级分类，查找时候找出对应的所有分类，channelListCatagroy简写clc</param>
        /// <returns></returns>
        public ActionResult GoodsTransferSearch(string key, int page,
            bool IsChangeByGoods, bool IsChangeByPrice,
            int area, int city,
            int clc)
        {
            var model = new GoodsTransferSearchModel(page);
            model.Key = key;
            model.IsChangeByGoods = IsChangeByGoods;
            model.IsChangeByPrice = IsChangeByPrice;
            model.AreaId = area;
            model.CityId = city;
            model.Clc = clc;
            model.MainGoods = goodsTransferSearch.SearchByKey(key, area, 
                city, page - 1, 
                10, IsChangeByGoods, 
                IsChangeByPrice, clc);
            model.CheckModel();
            return View(model);
        }


        public ActionResult CarTransferSearch(string key, int page, 
            int area, int city,
            int clc)
        {
            var model = new CarTransferSearchModel(page);
            model.Key = key;
            model.AreaId = area;
            model.CityId = city;
            model.Clc = clc;
            model.MainCars = transferCarSearch.SearchByKey(key, area, city, page - 1, 10,clc);
            model.CheckModel();
            return View(model);
        }


        public ActionResult HouseTransferSearch(string key, int page, 
            int area, int city,
            int clc)
        {
            var model = new HouseTransferSearchModel(page);
            model.Key = key;
            model.AreaId = area;
            model.CityId = city;
            model.Clc = clc;
            model.MainHouse = transferHouseSearch.SearchByKey(key, area, city, page - 1, 10, clc);
            model.CheckModel();
            return View(model);
        }


        //Buy

        public ActionResult GoodsBuySearch(string key, int page,
             bool IsChangeByGoods, bool IsChangeByPrice,
             int area, int city,
             int clc)
        {
            var model = new GoodsBuySearchModel(page);
            model.Key = key;
            model.IsChangeByGoods = IsChangeByGoods;
            model.IsChangeByPrice = IsChangeByPrice;
            model.AreaId = area;
            model.CityId = city;
            model.Clc = clc;
            model.MainGoods = goodsBuySearch.SearchByKey(key, area, 
                city, page - 1, 
                10, IsChangeByGoods, 
                IsChangeByPrice, clc);
            model.CheckModel();
            return View(model);
        }


        public ActionResult CarBuySearch(string key, int page, 
            int area, int city,
            int clc)
        {
            var model = new CarBuySearchModel(page);
            model.Key = key;
            model.AreaId = area;
            model.CityId = city;
            model.Clc = clc;
            model.MainCars = buyCarSearch.SearchByKey(key, area, city, page - 1, 10, clc);
            model.CheckModel();
            return View(model);
        }


        public ActionResult HouseBuySearch(string key, int page, 
            int area, int city,
            int clc)
        {
            var model = new HouseBuySearchModel(page);
            model.Key = key;
            model.AreaId = area;
            model.CityId = city;
            model.Clc = clc;
            model.MainHouse = buyHouseSearch.SearchByKey(key, area, city, page - 1, 10, clc);
            model.CheckModel();
            return View(model);
        }


    }
}
