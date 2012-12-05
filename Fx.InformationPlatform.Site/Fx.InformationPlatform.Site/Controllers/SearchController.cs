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
    public class SearchController : Controller
    {
        protected ISiteSearch<CarTransferInfo> transferCarSearch;
        //protected ISiteSearch<GoodsTransferInfo> transferGoodsSearch;
        protected ISiteSearch<HouseTransferInfo> transferHouseSearch;
        protected ISiteSearch<CarBuyInfo> buyCarSearch;
        //protected ISiteSearch<GoodsBuyInfo> buyGoodsSearch;
        protected ISiteSearch<HouseBuyInfo> buyHouseSearch;
        protected IGoodsSearch<GoodsTransferInfo> goodsTransferSearch;
        protected IGoodsSearch<GoodsBuyInfo> goodsBuySearch;
        public SearchController(ISiteSearch<CarTransferInfo> transferCarSearch,
            //ISiteSearch<GoodsTransferInfo> transferGoodsSearch,
            ISiteSearch<HouseTransferInfo> transferHouseSearch,
            ISiteSearch<CarBuyInfo> buyCarSearch,
            //ISiteSearch<GoodsBuyInfo> buyGoodsSearch,
            ISiteSearch<HouseBuyInfo> buyHouseSearch,
            IGoodsSearch<GoodsTransferInfo> goodsTransferSearch,
            IGoodsSearch<GoodsBuyInfo> goodsBuySearch)
        {
            this.transferCarSearch = transferCarSearch;
            //this.transferGoodsSearch = transferGoodsSearch;
            this.transferHouseSearch = transferHouseSearch;
            this.buyCarSearch = buyCarSearch;
            //this.buyGoodsSearch = buyGoodsSearch;
            this.buyHouseSearch = buyHouseSearch;

            this.goodsTransferSearch = goodsTransferSearch;
            this.goodsBuySearch = goodsBuySearch;

        }

        //Transfer 

        public ActionResult GoodsTransferSearch(string goodsTransferSearchKey, int page,
            bool IsChangeByGoods, bool IsChangeByPrice,
            int area, int city)
        {
            var model = new GoodsTransferSearchModel(page);
            model.Key = goodsTransferSearchKey;
            model.IsChangeByGoods = IsChangeByGoods;
            model.IsChangeByPrice = IsChangeByPrice;
            model.AreaId = area;
            model.CityId = city;
            //if (IsChangeByGoods & IsChangeByPrice)
            //{
            //    model.MainGoods = transferGoodsSearch.SearchByKey(goodsTransferSearchKey, page - 1, 10);
            //}
            //else
            //{
            //    if (IsChangeByGoods)
            //    {
            //        model.MainGoods = goodsTransferSearch.SearchWhenChangeGoods(page - 1, 10);
            //    }
            //    else
            //    {
            //        model.MainGoods = goodsTransferSearch.SearchWhenPrice(page - 1, 10);
            //    }
            //}
            model.MainGoods = goodsTransferSearch.SearchByKey(goodsTransferSearchKey, area, city, page - 1, 10, IsChangeByGoods, IsChangeByPrice);
            model.CheckModel();
            return View(model);
        }


        public ActionResult CarTransferSearch(string carTransferSearchKey, int page, int area, int city)
        {
            var model = new CarTransferSearchModel(page);
            model.Key = carTransferSearchKey;
            model.MainCars = transferCarSearch.SearchByKey(carTransferSearchKey, area, city, page - 1, 10);
            model.CheckModel();
            return View(model);
        }


        public ActionResult HouseTransferSearch(string houseTransferSearchKey, int page, int area, int city)
        {
            var model = new HouseTransferSearchModel(page);
            model.Key = houseTransferSearchKey;
            model.MainHouse = transferHouseSearch.SearchByKey(houseTransferSearchKey, area, city, page - 1, 10);
            model.CheckModel();
            return View(model);
        }


        //Buy

        public ActionResult GoodsBuySearch(string goodsBuySearchKey, int page,
             bool IsChangeByGoods, bool IsChangeByPrice,
             int area, int city)
        {
            var model = new GoodsBuySearchModel(page);
            model.Key = goodsBuySearchKey;
            model.IsChangeByGoods = IsChangeByGoods;
            model.IsChangeByPrice = IsChangeByPrice;
            model.AreaId = area;
            model.CityId = city;
            model.MainGoods = goodsBuySearch.SearchByKey(goodsBuySearchKey, area, city, page - 1, 10, IsChangeByGoods, IsChangeByPrice);
            model.CheckModel();
            return View(model);
        }


        public ActionResult CarBuySearch(string carBuySearchKey, int page, int area, int city)
        {
            var model = new CarBuySearchModel(page);
            model.Key = carBuySearchKey;
            model.MainCars = buyCarSearch.SearchByKey(carBuySearchKey, area, city, page - 1, 10);
            model.CheckModel();
            return View(model);
        }


        public ActionResult HouseBuySearch(string houseBuySearchKey, int page, int area, int city)
        {
            var model = new HouseBuySearchModel(page);
            model.Key = houseBuySearchKey;
            model.MainHouse = buyHouseSearch.SearchByKey(houseBuySearchKey, area, city, page - 1, 10);
            model.CheckModel();
            return View(model);
        }


    }
}
