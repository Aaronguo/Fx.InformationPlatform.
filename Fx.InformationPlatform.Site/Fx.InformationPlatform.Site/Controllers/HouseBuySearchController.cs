using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.Catagroy;
using Fx.Entity.FxHouse;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxHouse;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class HouseBuySearchController : Controller
    {
           protected HouseCache houseCache;
        /// <summary>
        /// 用于一般检索
        /// </summary>
        protected Fx.Domain.Base.IService.ISiteSearch<HouseBuyInfo> BuyHouseSearch;
        /// <summary>
        /// 用于房屋分类查看
        /// </summary>
        protected Fx.Domain.Base.IService.IHouseSearch<HouseBuyInfo> houseSearch;
        public HouseBuySearchController(HouseCache houseCache,
            Fx.Domain.Base.IService.ISiteSearch<HouseBuyInfo> BuyHouseSearch,
            Fx.Domain.Base.IService.IHouseSearch<HouseBuyInfo> houseSearch)
        {
            this.houseCache = houseCache;
            this.BuyHouseSearch = BuyHouseSearch;
            this.houseSearch = houseSearch;
        }


        public ActionResult SecondShop(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyShop().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.Shop, page, 10);
                }
            }
            model.TopHouse = houseCache.GetHouseBuyTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Restaurants(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyRestaurants().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.Restaurants, page, 10);
                }
            }
            model.TopHouse = houseCache.GetHouseBuyTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Warehouse(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyWarehouse().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.Warehouse, page, 10);
                }
            }
            model.TopHouse = houseCache.GetHouseBuyTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Office(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyOffice().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.Office, page, 10);
                }
            }
            model.TopHouse = houseCache.GetHouseBuyTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult House(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyHouse().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.House, page, 10);
                }
            }
            model.TopHouse = houseCache.GetHouseBuyTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Flat(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyFlat().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.Flat, page, 10);
                }
            }
            model.TopHouse = houseCache.GetHouseBuyTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult StudentAparment(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyStudentAparment().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.StudentAparment, page, 10);
                }
            }
            model.TopHouse = houseCache.GetHouseBuyTopShow();
            model.CheckModel();
            return View(model);
        }
    }
}
