using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxHouse.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 具体房屋求购详情页面
    /// </summary>
    public class HouseBuyDetailController : Controller
    {
        protected IBuyHouse buyHouse;
        public HouseBuyDetailController(IBuyHouse buyHouse)
        {
            this.buyHouse = buyHouse;
        }

        public ActionResult Index(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                var house = buyHouse.Get(id);
                if (house == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
                return View(house);
            }
        }
    }
}
