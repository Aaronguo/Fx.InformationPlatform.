using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.InformationPlatform.Site.ViewModel;
using Fx.Infrastructure.Caching;
using FxCacheService.FxCar;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 汽车列表页面 二级页面
    /// </summary>
    public class CarListController : Controller
    {
        protected CarCache carCache;
        public CarListController(CarCache carCache)
        {
            this.carCache = carCache;
        }
        public ActionResult Index()
        {
            var model = new CarListModel();
            model.SecondHandCars = carCache.GetCarSecondHandCarList();
            return View(model);
        }

    }
}
