using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxGoods.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 具体二手转让详情页面
    /// </summary>
    public class GoodsTransferDetailController : Controller
    {
        protected ITransferGoods transferGoods;
        public GoodsTransferDetailController(ITransferGoods transfergoods)
        {
            this.transferGoods = transfergoods;
        }

        public ActionResult Index(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                var goods = transferGoods.Get(id);
                if (goods == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
                return View(goods);
            }
        }

    }
}
