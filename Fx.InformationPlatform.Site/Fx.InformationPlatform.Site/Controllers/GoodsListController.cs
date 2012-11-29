using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxGoods;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 二手列表页面 二级页面
    /// </summary>
    public class GoodsListController : Controller
    {
        protected GoodsCache goodsCache;
        public GoodsListController(GoodsCache goodsCache)
        {
            this.goodsCache = goodsCache;
        }

        public ActionResult Index()
        {
            var model = new GoodsListModel();
            model.CultureLifes = goodsCache.GetGoodsCultureLifeList();
            model.Electronics = goodsCache.GetGoodsElectronicsList();
            model.Fashions = goodsCache.GetGoodsFashionList();
            model.HomeSupplies = goodsCache.GetGoodsHomeSuppliesList();
            model.Others = goodsCache.GetGoodsOtherList();
            return View(model);
        }

    }
}
