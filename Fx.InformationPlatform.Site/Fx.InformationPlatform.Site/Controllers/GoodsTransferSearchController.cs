using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.Catagroy;
using Fx.Entity.FxGoods;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxGoods;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class GoodsTransferSearchController : Controller
    {
        protected GoodsCache goodsCache;
        protected SiteCache siteCache;
        /// <summary>
        /// 用于一般检索
        /// </summary>
        protected Fx.Domain.Base.IService.ISiteSearch<GoodsTransferInfo> transferGoodsSearch;
        /// <summary>
        /// 用于二手分类查看
        /// </summary>
        protected Fx.Domain.Base.IService.IGoodsSearch<GoodsTransferInfo> goodsSearch;
        public GoodsTransferSearchController(GoodsCache goodsCache,
            Fx.Domain.Base.IService.ISiteSearch<GoodsTransferInfo> transferGoodsSearch,
            Fx.Domain.Base.IService.IGoodsSearch<GoodsTransferInfo> goodsSearch,
            SiteCache siteCache)
        {
            this.goodsCache = goodsCache;
            this.transferGoodsSearch = transferGoodsSearch;
            this.goodsSearch = goodsSearch;
            this.siteCache = siteCache;
        }

        public ActionResult Phone(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferPhone().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Computer(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferComputer().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult DigitalCamera(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferDigitalCamera().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult ComputerAccessories(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferComputerAccessories().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult PlayStations(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferPlayStations().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult PSAccessories(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferPSAccessories().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult PhoneAccessories(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferPhoneAccessories().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult ElectronicsOther(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferElectronicsOther().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Furniture(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferFurniture().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult KitchenAppliances(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferKitchenAppliances().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult AudioAppliances(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferAudioAppliances().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult KitchenDinningWares(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferKitchenDinningWares().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Decoration(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferDecoration().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult OtherElectronics(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferOtherElectronics().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult GymEquipment(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferGymEquipment().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Bike(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferBike().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult HomeSuppliesOther(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferHomeSuppliesOther().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Clothing(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferClothing().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Shoes(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferShoes().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Bag(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferBag().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Accessories(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferAccessories().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult FashionOther(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferFashionOther().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult MusicInstruments(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferMusicInstruments().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Books(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferBooks().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult Toys(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferToys().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }


        public ActionResult Stationary(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferStationary().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult CultureLifeOther(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferCultureLifeOther().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

        public ActionResult OtherOther(int id)
        {
            var model = new GoodsTransferSearchModel(id,siteCache);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsTransferOtherOther().Skip((id - 1) * 10).Take(10).ToList();
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
            model.TopGoods = goodsCache.GetGoodsTransferTopShow();
            model.CheckModel();
            return View(model);
        }

    }
}
