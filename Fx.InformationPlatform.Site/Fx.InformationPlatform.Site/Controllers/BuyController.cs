using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxSite.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 求购页面总控制器
    /// </summary>
    public class BuyController : Controller
    {
        IChannelService channelService;
        public BuyController(IChannelService channelService)
        {
            this.channelService = channelService;
        }

        //
        // GET: /Publish/
        public ActionResult Index(int id)
        {
            ViewBag.Select = id;
            return View(channelService.GetAllChannels());
        }
    }
}
