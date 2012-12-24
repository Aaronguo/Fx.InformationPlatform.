using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.Catagroy;
using Fx.Entity.FxCar;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxCar;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class CarTransferSearchController : Controller
    {
        protected CarCache carCache;
        protected SiteCache siteCache;
        /// <summary>
        /// 用于一般检索
        /// </summary>
        protected Fx.Domain.Base.IService.ISiteSearch<CarTransferInfo> transferCarSearch;
        /// <summary>
        /// 用于汽车分类检索
        /// </summary>
        protected Fx.Domain.Base.IService.ICarSearch<CarTransferInfo> carSearch;
        public CarTransferSearchController(CarCache carCache,
            Fx.Domain.Base.IService.ISiteSearch<CarTransferInfo> transferCarSearch,
            Fx.Domain.Base.IService.ICarSearch<CarTransferInfo> carSearch)
        {
            this.carCache = carCache;
            this.transferCarSearch = transferCarSearch;
            this.carSearch = carSearch;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns></returns>
        public ActionResult Audi(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferAudi().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    int page = id - 1;
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Audi, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult BMW(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferBMW().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.BMW, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult Buick(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferBuick().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Buick, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult Citroen(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferCitroen().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Citroen, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult Ford(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferFord().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Ford, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult Honda(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferHonda().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Honda, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult Toyota(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferToyota().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Toyota, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult Nissan(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferNissan().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Nissan, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult MINI(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferMINI().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.MINI, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult MercedesBenz(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferMercedesBenz().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.MercedesBenz, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult Peugeot(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferPeugeot().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Peugeot, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult VW(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferVW().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.VW, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult Volvo(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferVolvo().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Volvo, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        public ActionResult SecondHandCarOther(int id)
        {
            var model = new CarTransferSearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarTransferSecondHandCarOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.SecondHandCarOther, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }
    }
}
