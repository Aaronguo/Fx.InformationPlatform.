using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxCar.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 具体车辆求购详情页面
    /// </summary>
    public class CarBuyDetailController : Controller
    {
        protected IBuyCar buyCar;
        public CarBuyDetailController(IBuyCar buyCar)
        {
            this.buyCar = buyCar;
        }

        public ActionResult Index(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                var car = buyCar.Get(id);
                if (car == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
                return View(car);
            }
        }
    }
}
