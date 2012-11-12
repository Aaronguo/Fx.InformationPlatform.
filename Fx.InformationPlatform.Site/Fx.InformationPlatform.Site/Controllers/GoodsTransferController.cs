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
    public class GoodsTransferController : BaseController
    {
        IGoods goodsService;
        ITransferGoods transferService;
        IAccountService accountService;
        private readonly string transferImagePath = "~/UploadImage/Transfer/GoodsImage";

        public GoodsTransferController(IGoods goodsService,
            ITransferGoods transferService,
            IAccountService accountService)
        {
            this.goodsService = goodsService;
            this.transferService = transferService;
            this.accountService = accountService;
        }


        public ActionResult Electronics()
        {
            BindCatagroy();
            return View();
        }

        [HttpPost]
        public ActionResult Electronics(TransferViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            if (BuildGoods(goods, facefile, otherfile, badfile))
            {
                GoodsTransferInfo transfergoods = MapperGoods(goods);
                transferService.SaveTransferGoods(transfergoods);
                return View("Success");
            }
            return View("FaildTransfer");
        }

        public ActionResult FaildTransfer()
        {
            return View();
        }


        private GoodsTransferInfo MapperGoods(TransferViewGoods goods)
        {
            var info = new GoodsTransferInfo();
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

        private bool BuildGoods(TransferViewGoods goods, List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            InitParas();
            string date = Helper.GetDate();
            string userid = accountService.GetCurrentUser(User.Identity.Name).ToString();
            string timestamp;
            string folder;
            int random = 1;
            string fileVirtualPathTemplate = transferImagePath + "/{0}/{1}/{2}.jpg";
            //图片保存到
            #region FaceFile
            foreach (var face in facefile)
            {

                if (face.HasFile())
                {
                    timestamp = DateTime.Now.GetTimeStamp();
                    folder = Path.Combine(HttpContext.Server.MapPath(this.transferImagePath),
                                                   date, userid);
                    string filePhysicalPath = Path.Combine(HttpContext.Server.MapPath(this.transferImagePath),
                                                   date, userid, timestamp + random.ToString() + ".jpg");
                    string fileVirtualPath = string.Format(fileVirtualPathTemplate, date, userid, timestamp);
                    goods.FaceFiles.Add(new TransferPicture()
                    {
                        ImageUrl = fileVirtualPath,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Head,
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
                    folder = Path.Combine(HttpContext.Server.MapPath(this.transferImagePath),
                                                  date, userid);
                    string filePhysicalPath = Path.Combine(HttpContext.Server.MapPath(this.transferImagePath),
                                                   date, userid, timestamp + random.ToString() + ".jpg");
                    string fileVirtualPath = string.Format(fileVirtualPathTemplate, date, userid, timestamp);
                    goods.OtherFiles.Add(new TransferPicture()
                    {
                        ImageUrl = fileVirtualPath,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Other,
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
                    folder = Path.Combine(HttpContext.Server.MapPath(this.transferImagePath),
                                                  date, userid);
                    string filePhysicalPath = Path.Combine(HttpContext.Server.MapPath(this.transferImagePath),
                                                   date, userid, timestamp + random.ToString() + ".jpg");
                    string fileVirtualPath = string.Format(fileVirtualPathTemplate, date, userid, timestamp);
                    goods.BadFiles.Add(new TransferPicture()
                    {
                        ImageUrl = fileVirtualPath,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Bad,
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


        public ActionResult Get(int Id)
        {
            return View(transferService.Get(Id));
        }

        private void BindCatagroy()
        {
            InitParas();
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择物品类别--" });
            goodsService.GetChannelTransferDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            ViewData["catagroy"] = details;
        }


        public ActionResult Success()
        {
            return View();
        }
    }
}
