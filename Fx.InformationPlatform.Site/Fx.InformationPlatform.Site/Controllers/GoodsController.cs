using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxSite.IService;
using Fx.InformationPlatform.Site.Framework;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class GoodsController : BaseController
    {
        IGoods goodsService;
        public GoodsController(IGoods goodsService)
        {
            this.goodsService = goodsService;
        }

        //
        // GET: /Goods/

        public ActionResult Index()
        {
            return View();
        }
    }
}
