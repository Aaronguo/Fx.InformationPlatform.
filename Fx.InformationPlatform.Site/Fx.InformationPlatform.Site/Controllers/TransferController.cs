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
    public class TransferController : Controller
    {
        IChannelService channelService;
        public TransferController(IChannelService channelService)
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
