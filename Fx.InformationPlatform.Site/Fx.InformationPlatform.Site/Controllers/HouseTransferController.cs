using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Domain.FxHouse.IService;
using Fx.Domain.FxSite.IService;
using Fx.Entity;
using Fx.Entity.FxHouse;
using Fx.InformationPlatform.Site.ViewModel;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class HouseTransferController : BaseController
    {
        IHouse houseService;        
        ITransferHouse buyService;
        IAccountService accountService;
        private readonly string transferImagePath = "~/UploadImage/Transfer/HouseImage";
        public HouseTransferController(IHouse houseService,
            ITransferHouse buyService,
            IAccountService accountService)
        {
            this.houseService = houseService;
            this.buyService = buyService;
            this.accountService = accountService;
        }
        public HouseTransferController(IHouse houseService)
        {
            this.houseService = houseService;
        }
        
        public ActionResult CommercialProperties()
        {           
            BindCatagroy();
            return View();
        }


        [HttpPost]
        public ActionResult CommercialProperties(TransferViewHouse house,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            if (BuildHouse(house, facefile, otherfile, badfile))
            {
                HouseTransferInfo transferhouse = MapperHouse(house);
                buyService.SaveTransferHouse(transferhouse);
                return View("Success");
            }
            return View("FaildTransfer");
        }

        public ActionResult FaildTransfer()
        {
            return View();
        }


        private HouseTransferInfo MapperHouse(TransferViewHouse house)
        {
            var info = new HouseTransferInfo();
            info.Bill = house.Bill;
            info.HasFurniture = house.HasFurniture;
            info.PostCode = house.PostCode;
            info.RoadName = house.RoadName;
            info.CatagroyId = house.CatagroyId;
            info.AreaId = house.AreaId;
            info.Controller = this.ControllerName;
            info.Action = this.ActionName;
            info.CityId = house.CityId;
            info.Mark = house.Mark;
            house.FaceFiles.ForEach(r => info.Pictures.Add(r));
            house.OtherFiles.ForEach(r => info.Pictures.Add(r));
            house.BadFiles.ForEach(r => info.Pictures.Add(r));
            info.Price = (int)house.Price;
            info.PublishTitle = house.Title;
            info.PublishUserEmail = house.Email;
            info.UserAccount = User.Identity.Name;
            return info;
        }

        private bool BuildHouse(TransferViewHouse house, List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
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
                    house.FaceFiles.Add(new TransferPicture()
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
                    house.OtherFiles.Add(new TransferPicture()
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
                    house.BadFiles.Add(new TransferPicture()
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



        private void BindCatagroy()
        {
            InitParas();
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择物品类别--" });
            houseService.GetChannelTransferDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            ViewData["catagroy"] = details;
        }

    }
}
