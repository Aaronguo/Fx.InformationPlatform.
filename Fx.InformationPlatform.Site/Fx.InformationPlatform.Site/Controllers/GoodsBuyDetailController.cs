using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxGoods.IService;
using Fx.Entity.FxGoods;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 具体二手求购详情页面
    /// </summary>
    public class GoodsBuyDetailController : Controller
    {
        protected IBuyGoods buyGoods;
        public GoodsBuyDetailController(IBuyGoods buygoods)
        {
            this.buyGoods = buygoods;
        }

        public ActionResult Index(int id)
        {
            GoodsBuyInfo goods;
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                goods = buyGoods.Get(id);
                if (goods == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
            }
            //换物
            if (goods.IsChange)
            {
                return View("IndexWithPicture", goods);
            }
            else
            {
                return View("IndexWithNoPicture", goods);
            }
        }

    }
}
