using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxAggregate.IService;
using Fx.Domain.FxGoods.IService;
using Fx.Entity.FxGoods;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 具体二手求购详情页面
    /// </summary>
    public class GoodsBuyDetailController : Controller
    {
        protected IBuyGoods buyGoods;
        protected IFavorite favorite;
        public GoodsBuyDetailController(IBuyGoods buygoods,
             IFavorite favorite)
        {
            this.buyGoods = buygoods;
            this.favorite = favorite;
        }

        public ActionResult Index(int id)
        {
            GoodsBuyInfo goods;
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                goods = buyGoods.Get(id);
                if (goods == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
            }
            //换物
            if (goods.IsChange)
            {
                return View("IndexWithPicture", goods);
            }
            else
            {
                return View("IndexWithNoPicture", goods);
            }
        }

        public ActionResult Favorite(int infoId)
        {
            if (infoId > 0 && User.Identity.IsAuthenticated)
            {
                var goods = buyGoods.Get(infoId);
                var ret = favorite.AddFavorite(new Entity.FxAggregate.Favorite()
                {
                    ChannelCatagroy = (int)Fx.Entity.ChannelCatagroy.FxGoodsBuy,
                    InfoId = infoId,
                    Title = goods.PublishTitle,
                    UserAccount = User.Identity.Name
                });
                if (ret.isSuccess)
                {
                    TempData["Tip"] = "收藏成功";
                }
                else
                {
                    TempData["Tip"] = ret.ResultMsg;
                }
            }
            else
            {
                TempData["Tip"] = "收藏失败,您没有登录,请先登陆";
            }
            return RedirectToAction("Index", new { id = infoId });
        }

    }
}
