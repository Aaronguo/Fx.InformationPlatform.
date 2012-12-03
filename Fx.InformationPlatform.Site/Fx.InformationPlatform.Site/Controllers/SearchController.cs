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
        protected ISiteSearch<GoodsTransferInfo> transferGoodsSearch;
        protected ISiteSearch<HouseTransferInfo> transferHouseSearch;
        protected ISiteSearch<CarBuyInfo> buyCarSearch;
        protected ISiteSearch<GoodsBuyInfo> buyGoodsSearch;
        protected ISiteSearch<HouseBuyInfo> buyHouseSearch;
        protected IGoodsSearch<GoodsTransferInfo> goodsTransferSearch;
        public SearchController(ISiteSearch<CarTransferInfo> transferCarSearch,
            ISiteSearch<GoodsTransferInfo> transferGoodsSearch,
            ISiteSearch<HouseTransferInfo> transferHouseSearch,
            ISiteSearch<CarBuyInfo> buyCarSearch,
            ISiteSearch<GoodsBuyInfo> buyGoodsSearch,
            ISiteSearch<HouseBuyInfo> buyHouseSearch,
            IGoodsSearch<GoodsTransferInfo> goodsTransferSearch)
        {
            this.transferCarSearch = transferCarSearch;
            this.transferGoodsSearch = transferGoodsSearch;
            this.transferHouseSearch = transferHouseSearch;
            this.buyCarSearch = buyCarSearch;
            this.buyGoodsSearch = buyGoodsSearch;
            this.buyHouseSearch = buyHouseSearch;
            this.goodsTransferSearch = goodsTransferSearch;
        }

        //Transfer 

        public ActionResult GoodsTransferSearch(string goodsTransferSearchKey, int page, bool IsChangeByGoods, bool IsChangeByPrice)
        {
            var model = new GoodsTransferSearchModel(page);
            model.Key = goodsTransferSearchKey;
            model.IsChangeByGoods = IsChangeByGoods;
            model.IsChangeByPrice = IsChangeByPrice;
            if (IsChangeByGoods & IsChangeByPrice)
            {
                model.MainGoods = transferGoodsSearch.SearchByKey(goodsTransferSearchKey, page - 1, 10);              
            }
            else
            {
                if (IsChangeByGoods)
                {
                    model.MainGoods = goodsTransferSearch.SearchWhenChangeGoods(page - 1, 10);
                }
                else
                {
                    model.MainGoods = goodsTransferSearch.SearchWhenPrice(page - 1, 10);
                }
            }
            model.ModelCheck();
            return View(model);
        }


        public ActionResult CarTransferSearch(string carTransferSearchKey, int page)
        {
            var model = new CarTransferSearchModel(page);
            model.Key = carTransferSearchKey;
            model.MainCars = transferCarSearch.SearchByKey(carTransferSearchKey, page - 1, 10);
            model.ModelCheck();
            return View(model);
        }


        public ActionResult HouseTransferSearch(string houseTransferSearchKey, int page)
        {
            var model = new HouseTransferSearchModel(page);
            model.Key = houseTransferSearchKey;
            model.MainHouse = transferHouseSearch.SearchByKey(houseTransferSearchKey, page - 1, 10);
            model.ModelCheck();
            return View(model);
        }


        //Buy

        public ActionResult GoodsBuySearch(string goodsBuySearchKey, int page)
        {
            var model = new GoodsBuySearchModel(page);
            model.Key = goodsBuySearchKey;
            model.MainGoods = buyGoodsSearch.SearchByKey(goodsBuySearchKey, page - 1, 10);
            model.ModelCheck();
            return View(model);
        }


        public ActionResult CarBuySearch(string carBuySearchKey, int page)
        {
            var model = new CarBuySearchModel(page);
            model.Key = carBuySearchKey;
            model.MainCars = buyCarSearch.SearchByKey(carBuySearchKey, page - 1, 10);
            model.ModelCheck();
            return View(model);
        }


        public ActionResult HouseBuySearch(string houseBuySearchKey, int page)
        {
            var model = new HouseBuySearchModel(page);
            model.Key = houseBuySearchKey;
            model.MainHouse = buyHouseSearch.SearchByKey(houseBuySearchKey, page - 1, 10);
            model.ModelCheck();
            return View(model);
        }


    }
}
