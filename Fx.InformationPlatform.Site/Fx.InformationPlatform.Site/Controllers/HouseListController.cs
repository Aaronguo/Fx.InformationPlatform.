using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxHouse;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 房屋列表页面 二级页面
    /// </summary>
    public class HouseListController : Controller
    {
        protected HouseCache houseCache;
        public HouseListController(HouseCache houseCache)
        {
            this.houseCache = houseCache;
        }

        public ActionResult Index()
        {
            var model = new HouseListModel();
            model.CommercialProperties = houseCache.GetHouseCommercialPropertiesList();
            model.Properties = houseCache.GetHousePropertiesList();
            return View(model);
        }

    }
}
