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

        [OutputCache(Duration = 3600)]
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

        [OutputCache(Duration = 3600)]
        public ActionResult City(int areaId)
        {
            if (Request.IsAjaxRequest() && areaId > 0)
            {
                string show = "<option value=\"0\">--请选择详细地址--</option>";
                var list = publishService.GetCitys(areaId);
                var json = from p in list
                           select string.Format("<option value=\"{0}\">{1}</option>", p.CityId, p.CityName);

                return Json(show + string.Join("", json), JsonRequestBehavior.DenyGet);
            }
            else
            {
                return new ContentResult() { Content = "Access Forbidden!" };
            }
        }


        [OutputCache(Duration = 3600)]
        public ActionResult GoodsBuyCondition()
        {
            if (Request.IsAjaxRequest())
            {
                string show = "<option value=\"0\">--请选择新旧程度--</option>";
                var list = publishService.GoodsConditions();
                var json = from p in list
                           select string.Format("<option value=\"{0}\" extend=\"{1}\" message=\"{2}\" >{3}</option>", p.GoodsConditionId, p.IsHasMessage.ToString().ToUpper(), p.PlaceHolder, "至少" + p.GoodsConditionName);

                return Json(show + string.Join("", json), JsonRequestBehavior.DenyGet);
            }
            else
            {
                return new ContentResult() { Content = "Access Forbidden!" };
            }
        }


        [OutputCache(Duration = 3600)]
        public ActionResult GoodsTransferCondition()
        {
            if (Request.IsAjaxRequest())
            {
                string show = "<option value=\"0\">--请选择新旧程度--</option>";
                var list = publishService.GoodsConditions();
                var json = from p in list
                           select string.Format("<option value=\"{0}\" extend=\"{1}\" message=\"{2}\" >{3}</option>", p.GoodsConditionId, p.IsHasMessage.ToString().ToUpper(), p.PlaceHolder, p.GoodsConditionName);

                return Json(show + string.Join("", json), JsonRequestBehavior.DenyGet);
            }
            else
            {
                return new ContentResult() { Content = "Access Forbidden!" };
            }
        }

    }
}
