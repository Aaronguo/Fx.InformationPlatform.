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
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 房屋转让发布
    /// </summary>
#if DEBUG

#else
    [Authorize]    
#endif
    public class HouseTransferController : BaseController, ISiteJob
    {
        IHouse houseService;
        ITransferHouse transferService;
        IAccountService accountService;
        public HouseTransferController(IHouse houseService,
            ITransferHouse buyService,
            IAccountService accountService)
        {
            this.houseService = houseService;
            this.transferService = buyService;
            this.accountService = accountService;
        }

        public ActionResult CommercialProperties()
        {
            BindData();
            return View();
        }


        public ActionResult Properties()
        {
            BindData();
            return View();
        }


        [HttpPost]
        public ActionResult CommercialProperties(TransferViewHouse house,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishHouse(house, facefile, otherfile, badfile);
        }


        [HttpPost]
        public ActionResult Properties(TransferViewHouse house,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishHouse(house, facefile, otherfile, badfile);
        }



        private ActionResult PublishHouse(TransferViewHouse house, List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            if (BuildHouse(house, facefile, otherfile, badfile))
            {
                HouseTransferInfo transferhouse = MapperHouse(house);
                transferService.SaveTransferHouse(transferhouse);
                RunJob();
                FxCacheService.FxSite.GlobalCache cache = System.Web.Mvc.DependencyResolver.Current.GetService<FxCacheService.FxSite.GlobalCache>();
                cache.InfoPublishAllCountAdd();
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
            info.RoomNumber = house.RoomNumber;
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
            string pictureName;
            string pictureMinName;
            //图片保存到
            #region FaceFile
            foreach (var face in facefile)
            {

                if (face.HasFile())
                {
                    pictureName = GetPictureName();
                    pictureMinName = GetPictureMinName();
                    house.FaceFiles.Add(new TransferPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Head,
                        PhysicalPath = GetPhysicalPath() + pictureName,
                        MinImageUrl=GetVirtualPath()+pictureMinName,
                    });
                    SaveFile(face, GetPhysicalPath(), GetPhysicalPath() + pictureName);
                }
            }
            #endregion

            #region OtherFile
            foreach (var other in otherfile)
            {
                if (other.HasFile())
                {
                    pictureName = GetPictureName();
                    pictureMinName = GetPictureMinName();
                    house.OtherFiles.Add(new TransferPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        PhysicalPath = GetPhysicalPath() + pictureName,
                        MinImageUrl = GetVirtualPath() + pictureMinName,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Other
                    });
                    SaveFile(other, GetPhysicalPath(), GetPhysicalPath() + pictureName);
                }
            }
            #endregion

            #region badFile
            foreach (var bad in badfile)
            {
                if (bad.HasFile())
                {
                    pictureName = GetPictureName();
                    pictureMinName = GetPictureMinName();
                    house.BadFiles.Add(new TransferPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        MinImageUrl = GetVirtualPath() + pictureMinName,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Bad,
                        PhysicalPath = GetPhysicalPath() + pictureName
                    });
                    SaveFile(bad, GetPhysicalPath(), GetPhysicalPath() + pictureName);
                }
            }
            #endregion

            return true;
        }

        private void BindData()
        {
            BindCatagroy();
            BindArea();
        }

        private void BindArea()
        {
            var siteCache = System.Web.Mvc.DependencyResolver.Current.GetService<SiteCache>();
            ViewData["carMileage"] = siteCache.GetAreaHtml();
        }

        private void BindCatagroy()
        {
            InitParas();
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择物品类别--" });
            houseService.GetChannelTransferDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            ViewData["catagroy"] = details;
        }

        #region UpLoad
        private readonly string transferPhysicalImagePath = @"UploadImage\Transfer\HouseImage\";
        private readonly string transferVirtualImagePath = "UploadImage/Transfer/HouseImage/";


        private string GetPhysicalPath()
        {
            return string.Format(@"{0}{1}{2}\{3}\", HttpContext.Server.MapPath("../"), transferPhysicalImagePath, GetDate(), GetUserId());
        }

        private string GetVirtualPath()
        {
            return string.Format("{0}{1}/{2}/", transferVirtualImagePath, GetDate(), GetUserId());
        }


        string userId;
        private string GetUserId()
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = accountService.GetCurrentUser(User.Identity.Name).ToString();
            }
            return userId;
        }

        string date;
        private string GetDate()
        {
            if (string.IsNullOrEmpty(date))
            {
                date = Helper.GetDate();
            }
            return date;
        }


        int pictureCount = 100;
        string timestamp = DateTime.Now.GetTimeStamp();

        private string GetPictureName()
        {
            string pictureName = string.Format("{0}{1}.jpg", timestamp, pictureCount);
            pictureCount++;
            return pictureName;

        }


        private string GetPictureMinName()
        {
            string pictureName = string.Format("{0}{1}-64X64.jpg", timestamp, pictureCount);
            return pictureName;
        }

        public void SaveFile(HttpPostedFileBase file, string folderPath, string filePath)
        {
            if (!System.IO.File.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
            file.SaveAs(filePath);
        }
        #endregion

        public void RunJob()
        {
            new System.Threading.Thread(() =>
            {
                new FxTask.FxHouse.Transfer.HouseTransferJobLoad().Execute();
            }).Start();
        }
    }
}
