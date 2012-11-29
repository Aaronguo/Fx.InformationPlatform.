using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxSite.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 求购页面频道选择
    /// </summary>
#if DEBUG

#else
    [Authorize]    
#endif
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
