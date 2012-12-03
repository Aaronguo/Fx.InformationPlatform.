using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxHouse.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 具体房屋转让详情页面
    /// </summary>
    public class HouseTransferDetailController : Controller
    {
       protected ITransferHouse transferHouse;
       public HouseTransferDetailController(ITransferHouse transferHouse)
        {
            this.transferHouse = transferHouse;
        }

        public ActionResult Index(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                var house = transferHouse.Get(id);
                if (house == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
                return View(house);
            }
        }
    }
}
