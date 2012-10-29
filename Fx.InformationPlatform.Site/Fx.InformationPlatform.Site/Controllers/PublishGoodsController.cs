using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxGoods.IService;
using Fx.Entity.FxGoods;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class PublishGoodsController : Controller
    {
        IPublishGoods goodService;

        public PublishGoodsController(IPublishGoods goodService)
        {
            this.goodService = goodService;
        }
        //
        // GET: /PublishGoods/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            CarPublishInfo car = goodService.Get("117822597@163.com");
            return View(car);
        }
    }
}
