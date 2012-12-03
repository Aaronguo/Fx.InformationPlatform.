using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.Catagroy;
using Fx.Entity.FxGoods;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxGoods;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class GoodsBuySearchController : Controller
    {
        protected GoodsCache goodsCache;
        /// <summary>
        /// 用于一般检索
        /// </summary>
        protected Fx.Domain.Base.IService.ISiteSearch<GoodsBuyInfo> buyGoodsSearch;
        /// <summary>
        /// 用于二手分类查看
        /// </summary>
        protected Fx.Domain.Base.IService.IGoodsSearch<GoodsBuyInfo> goodsSearch;
        public GoodsBuySearchController(GoodsCache goodsCache,
            Fx.Domain.Base.IService.ISiteSearch<GoodsBuyInfo> buyGoodsSearch,
            Fx.Domain.Base.IService.IGoodsSearch<GoodsBuyInfo> goodsSearch)
        {
            this.goodsCache = goodsCache;
            this.buyGoodsSearch = buyGoodsSearch;
            this.goodsSearch = goodsSearch;
        }

        public ActionResult Phone(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyPhone().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Phone, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Computer(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyComputer().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Computer, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult DigitalCamera(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyDigitalCamera().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.DigitalCamera, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult ComputerAccessories(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyComputerAccessories().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.ComputerAccessories, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult PlayStations(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyPlayStations().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.PlayStations, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult PSAccessories(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyPSAccessories().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.PSAccessories, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult PhoneAccessories(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyPhoneAccessories().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.PhoneAccessories, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult ElectronicsOther(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyElectronicsOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.ElectronicsOther, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Furniture(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyFurniture().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Furniture, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult KitchenAppliances(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyKitchenAppliances().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.KitchenAppliances, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult AudioAppliances(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyAudioAppliances().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.AudioAppliances, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult KitchenDinningWares(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyKitchenDinningWares().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.KitchenDinningWares, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Decoration(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyDecoration().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Decoration, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult OtherElectronics(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyOtherElectronics().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.OtherElectronics, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult GymEquipment(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyGymEquipment().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.GymEquipment, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Bike(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyBike().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Bike, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult HomeSuppliesOther(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyHomeSuppliesOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.HomeSuppliesOther, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Clothing(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyClothing().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Clothing, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Shoes(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyShoes().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Shoes, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Bag(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyBag().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Bag, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Accessories(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyAccessories().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Accessories, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult FashionOther(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyFashionOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.FashionOther, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult MusicInstruments(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyMusicInstruments().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.MusicInstruments, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Books(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyBooks().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Books, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult Toys(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyToys().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Toys, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }


        public ActionResult Stationary(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyStationary().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Stationary, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult CultureLifeOther(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyCultureLifeOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.CultureLifeOther, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }

        public ActionResult OtherOther(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyOtherOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.OtherOther, page, 10);
                }
            }
            model.TopGoods = goodsCache.GetGoodsBuyTopShow();
            model.ModelCheck();
            return View(model);
        }
    }
}
