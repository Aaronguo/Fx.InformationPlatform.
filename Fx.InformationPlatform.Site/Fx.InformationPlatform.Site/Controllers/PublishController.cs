using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxSite.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 发布信息
    /// </summary>
    public class PublishController : Controller
    {
        IChannelService channelService;
        public PublishController(IChannelService channelService)
        {
            this.channelService = channelService;
        }

        //
        // GET: /Publish/
        public ActionResult Index()
        {
            return View(channelService.GetAllChannels());
        }

    }
}
