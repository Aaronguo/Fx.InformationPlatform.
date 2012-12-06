using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxAggregate.IService;
using Fx.Domain.FxCar.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 具体车辆求购详情页面
    /// </summary>
    public class CarBuyDetailController : Controller
    {
        protected IBuyCar buyCar;
        protected IFavorite favorite;
        public CarBuyDetailController(IBuyCar buyCar,
            IFavorite favorite)
        {
            this.buyCar = buyCar;
            this.favorite = favorite;
        }

        public ActionResult Index(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                var car = buyCar.Get(id);
                if (car == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
                return View(car);
            }
        }

        public ActionResult Favorite(int infoId)
        {
            if (infoId > 0 && User.Identity.IsAuthenticated)
            {
                var car = buyCar.Get(infoId);
                var ret = favorite.AddFavorite(new Entity.FxAggregate.Favorite()
                {
                    ChannelCatagroy = (int)Fx.Entity.ChannelCatagroy.FxCarBuy,
                    InfoId = infoId,
                    Title = car.PublishTitle,
                    UserAccount = User.Identity.Name
                });
                if (ret.isSuccess)
                {
                    TempData["Tip"] = "收藏成功";
                    //return JavaScript("function show(){alert('~');}");
                }
                else
                {
                    TempData["Tip"] = ret.ResultMsg;
                    //return JavaScript("function show(){alert('" + ret.ResultMsg + "');}");
                }
            }
            else
            {
                TempData["Tip"] = "收藏失败";
                //return JavaScript("function show(){alert('收藏失败~');}");
            }
            return RedirectToAction("Index", new { id = infoId });
        }
    }
}
