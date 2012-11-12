using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Domain.FxGoods.IService;
using Fx.Domain.FxSite.IService;
using Fx.Entity;
using Fx.Entity.FxGoods;
using Fx.InformationPlatform.Site.ViewModel;

namespace Fx.InformationPlatform.Site.Controllers
{
    [Authorize]
    public class GoodsBuyController : BaseController
    {
        IGoods goodsService;
        IBuyGoods buyService;
        IAccountService accountService;
        private readonly string buyImagePath = "~/UploadImage/Buy/GoodsImage";
        public GoodsBuyController(IGoods goodsService,
            IBuyGoods buyService,
            IAccountService accountService)
        {
            this.goodsService = goodsService;
            this.buyService = buyService;
            this.accountService = accountService;
        }

        public ActionResult Electronics()
        {
            BindCatagroy();
            return View();
        }


        private void BindCatagroy()
        {
            InitParas();
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择物品类别--" });
            goodsService.GetChannelBuyDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            ViewData["catagroy"] = details;
        }


        [HttpPost]
        public ActionResult Electronics(BuyViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            if (BuildGoods(goods, facefile, otherfile, badfile))
            {
                GoodsBuyInfo transfergoods = MapperGoods(goods);
                buyService.SaveBuyGoods(transfergoods);
                return View("Success");
            }
            return View("FaildTransfer");
        }

        private bool BuildGoods(BuyViewGoods goods, List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            InitParas();
            string date = Helper.GetDate();
            string userid = accountService.GetCurrentUser(User.Identity.Name).ToString();
            string timestamp;
            string folder;
            int random = 1;
            string fileVirtualPathTemplate = buyImagePath + "/{0}/{1}/{2}.jpg";
            //图片保存到
            #region FaceFile
            foreach (var face in facefile)
            {

                if (face.HasFile())
                {
                    timestamp = DateTime.Now.GetTimeStamp();
                    folder = Path.Combine(HttpContext.Server.MapPath(this.buyImagePath),
                                                   date, userid);
                    string filePhysicalPath = Path.Combine(HttpContext.Server.MapPath(this.buyImagePath),
                                                   date, userid, timestamp + random.ToString() + ".jpg");
                    string fileVirtualPath = string.Format(fileVirtualPathTemplate, date, userid, timestamp);
                    goods.FaceFiles.Add(new BuyPicture()
                    {
                        ImageUrl = fileVirtualPath,
                        CdnUrl = "",
                        BuyPictureCatagroy = (int)PictureCatagroy.Head,
                        PhysicalPath = filePhysicalPath
                    });
                    if (!System.IO.File.Exists(folder))
                    {
                        System.IO.Directory.CreateDirectory(folder);
                    }
                    face.SaveAs(filePhysicalPath);
                    random++;
                }
            }
            #endregion

            #region OtherFile
            foreach (var other in otherfile)
            {
                if (other.HasFile())
                {
                    timestamp = DateTime.Now.GetTimeStamp();
                    folder = Path.Combine(HttpContext.Server.MapPath(this.buyImagePath),
                                                  date, userid);
                    string filePhysicalPath = Path.Combine(HttpContext.Server.MapPath(this.buyImagePath),
                                                   date, userid, timestamp + random.ToString() + ".jpg");
                    string fileVirtualPath = string.Format(fileVirtualPathTemplate, date, userid, timestamp);
                    goods.OtherFiles.Add(new BuyPicture()
                    {
                        ImageUrl = fileVirtualPath,
                        CdnUrl = "",
                        BuyPictureCatagroy = (int)PictureCatagroy.Other,
                        PhysicalPath = filePhysicalPath
                    });
                    other.SaveAs(filePhysicalPath);
                    random++;
                }
            }
            #endregion

            #region badFile
            foreach (var bad in badfile)
            {
                if (bad.HasFile())
                {
                    timestamp = DateTime.Now.GetTimeStamp();
                    folder = Path.Combine(HttpContext.Server.MapPath(this.buyImagePath),
                                                  date, userid);
                    string filePhysicalPath = Path.Combine(HttpContext.Server.MapPath(this.buyImagePath),
                                                   date, userid, timestamp + random.ToString() + ".jpg");
                    string fileVirtualPath = string.Format(fileVirtualPathTemplate, date, userid, timestamp);
                    goods.BadFiles.Add(new BuyPicture()
                    {
                        ImageUrl = fileVirtualPath,
                        CdnUrl = "",
                        BuyPictureCatagroy = (int)PictureCatagroy.Bad,
                        PhysicalPath = filePhysicalPath
                    });
                    if (!System.IO.File.Exists(folder))
                    {
                        System.IO.Directory.CreateDirectory(folder);
                    }
                    bad.SaveAs(filePhysicalPath);
                    random++;
                }
            }
            #endregion

            return true;
        }

        private GoodsBuyInfo MapperGoods(BuyViewGoods goods)
        {
            var info = new GoodsBuyInfo();
            info.CatagroyId = goods.CatagroyId;
            info.AreaId = goods.AreaId;
            info.ChangeMsg = goods.ChangeGoodsMsg;
            info.Controller = this.ControllerName;
            info.Action = this.ActionName;
            info.CityId = goods.CityId;
            info.GoodsConditionMsg = goods.GoodConditonMsg;
            info.GoodsconditonId = goods.GoodConditionId;
            info.IsChange = goods.IsChangeGoods;
            info.Mark = goods.Mark;
            goods.FaceFiles.ForEach(r => info.Pictures.Add(r));
            goods.OtherFiles.ForEach(r => info.Pictures.Add(r));
            goods.BadFiles.ForEach(r => info.Pictures.Add(r));
            info.Price = (int)goods.Price;
            info.PublishTitle = goods.Title;
            info.PublishUserEmail = goods.Email;
            info.UserAccount = User.Identity.Name;
            return info;
        }
    }
}
