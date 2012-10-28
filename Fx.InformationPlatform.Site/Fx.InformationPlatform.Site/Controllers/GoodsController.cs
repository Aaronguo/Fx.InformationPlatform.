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


        public ActionResult Electronics()
        {
            InitParas();
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择物品类别--" });
            goodsService.GetChannelDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            ViewData["catagroy"] = details;
            return View();
        }
    }
}
