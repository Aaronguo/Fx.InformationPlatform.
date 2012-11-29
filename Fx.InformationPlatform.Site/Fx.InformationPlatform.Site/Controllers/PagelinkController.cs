using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 页面资源控制器 一些仅仅只有文字的页面
    /// </summary>
    public class PagelinkController : Controller
    {
        /// <summary>
        /// 英淘网用户协议
        /// </summary>
        /// <returns></returns>
        public ActionResult Agreement()
        {
            return View();
        }

        /// <summary>
        /// 英淘网物品交易安全须知
        /// </summary>
        /// <returns></returns>
        public ActionResult PaymentNotice()
        {
            return View();
        }

        /// <summary>
        /// 英淘网禁止发布内容
        /// </summary>
        /// <returns></returns>
        public ActionResult Forbidden()
        {
            return View();
        }

        /// <summary>
        /// 英淘网公约
        /// </summary>
        /// <returns></returns>
        public ActionResult Convention()
        {
            return View();
        }

        /// <summary>
        /// 英淘网隐私权保护规则
        /// </summary>
        /// <returns></returns>
        public ActionResult Privacy()
        {
            return View();
        }


        public ActionResult PageNotFound()
        {
            return View();
        }

    }
}
