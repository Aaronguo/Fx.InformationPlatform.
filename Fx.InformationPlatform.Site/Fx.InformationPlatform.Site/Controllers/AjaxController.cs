using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Fx.Domain.FxSite.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class AjaxController : Controller
    {
        IPageAjax publishService;
        public AjaxController(IPageAjax publishService)
        {
            this.publishService = publishService;
        }

        [OutputCache(Duration = 60)]
        public ActionResult Aera()
        {
            if (Request.IsAjaxRequest())
            {
                string show = "<option value=\"0\">--请选择地区--</option>";
                var list = publishService.GetAreas();
                var json = from p in list
                           select string.Format("<option value=\"{0}\">{1}</option>", p.AreaId, p.AreaName);

                return Json(show + string.Join("", json), JsonRequestBehavior.DenyGet);
            }
            else
            {
                return new ContentResult() { Content = "Access Forbidden!" };
            }
        }

    }
}
