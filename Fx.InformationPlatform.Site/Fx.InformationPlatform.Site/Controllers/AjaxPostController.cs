using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxAggregate.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
#if DEBUG
#else
    [Authorize]
#endif
    public class AjaxPostController : Controller
    {
        protected IAggregateInfo aggregateInfoService;
        protected IPrivateMessage privateMessageService;
        public AjaxPostController(IAggregateInfo aggregateInfoService,
            IPrivateMessage privateMessageService)
        {
            this.aggregateInfoService = aggregateInfoService;
            this.privateMessageService = privateMessageService;
        }

        /// <summary>
        /// 发送一条私信
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="channelCatagroy"></param>
        /// <returns></returns>
        public ActionResult PrivateMessage(int infoId, int channelCatagroy, string privateTxt)
        {
            if (Request.IsAjaxRequest() && infoId > 0 && channelCatagroy >= 0)
            {
                var info = aggregateInfoService.GetInfoByCatatgroyAndId(channelCatagroy, infoId);
                if (info != null && aggregateInfoService.IsValid(info) == true)
                {
                    privateMessageService.AddPrivateMessage(new Entity.FxAggregate.PrivateMessage()
                    {
                        ChannelCatagroy = channelCatagroy,
                        InterestingEmail = User.Identity.Name,
                        UserAccount = info.UserAccount,
                        SourceId = infoId,
                        Title = info.PublishTitle,
                        Message = privateTxt

                    });
                    return Json("私信发送成功", JsonRequestBehavior.DenyGet);
                }
                else
                {
                    return Json("私信发送失败", JsonRequestBehavior.DenyGet);
                }

            }
            else
            {
                return new ContentResult() { Content = "Access Forbidden!" };
            }
        }
    }
}
