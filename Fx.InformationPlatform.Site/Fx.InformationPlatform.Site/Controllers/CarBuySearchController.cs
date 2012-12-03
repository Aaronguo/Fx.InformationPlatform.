using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.Catagroy;
using Fx.Entity.FxCar;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxCar;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class CarBuySearchController : Controller
    {
      protected CarCache carCache;
        /// <summary>
        /// 用于一般检索
        /// </summary>
        protected Fx.Domain.Base.IService.ISiteSearch<CarBuyInfo> BuyCarSearch;
        /// <summary>
        /// 用于汽车分类检索
        /// </summary>
        protected Fx.Domain.Base.IService.ICarSearch<CarBuyInfo> carSearch;
        public CarBuySearchController(CarCache carCache,
            Fx.Domain.Base.IService.ISiteSearch<CarBuyInfo> BuyCarSearch,
            Fx.Domain.Base.IService.ICarSearch<CarBuyInfo> carSearch)
        {
            this.carCache = carCache;
            this.BuyCarSearch = BuyCarSearch;
            this.carSearch = carSearch;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns></returns>
        public ActionResult Audi(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyAudi().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Audi, (id - 1), 10);                       
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult BMW(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyBMW().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.BMW, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Buick(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyBuick().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Buick, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Citroen(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyCitroen().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Citroen, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Ford(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyFord().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Ford, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Honda(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyHonda().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Honda, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Toyota(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyToyota().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Toyota, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Nissan(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyNissan().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Nissan, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult MINI(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyMINI().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.MINI, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult MercedesBenz(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyMercedesBenz().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.MercedesBenz, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Peugeot(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyPeugeot().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Peugeot, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult VW(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyVW().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.VW, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Volvo(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyVolvo().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Volvo, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult SecondHandCarOther(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuySecondHandCarOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.SecondHandCarOther, (id - 1), 10);
                }
            }
            model.TopCars = carCache.GetCarBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

    }
}
