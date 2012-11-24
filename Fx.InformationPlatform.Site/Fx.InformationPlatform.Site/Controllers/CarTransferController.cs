using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Domain.FxCar.IService;
using Fx.Domain.FxSite.IService;
using Fx.Entity;
using Fx.Entity.FxCar;
using Fx.InformationPlatform.Site.ViewModel;

namespace Fx.InformationPlatform.Site.Controllers
{
    [Authorize]
    public class CarTransferController : BaseController, ISiteJob
    {
        ICar carService;
        ITransferCar transferService;
        IAccountService accountService;

        public CarTransferController(ICar carService,
            ITransferCar buyService,
            IAccountService accountService)
        {
            this.carService = carService;
            this.transferService = buyService;
            this.accountService = accountService;
        }

        public ActionResult SecondHandCar()
        {
            BindData();
            return View();
        }

        public ActionResult CarAccessories()
        {
            BindData();
            return View();
        }
        


        [HttpPost]
        public ActionResult SecondHandCar(TransferViewCar car,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishCar(car, facefile, otherfile, badfile);
        }

        [HttpPost]
        public ActionResult CarAccessories(TransferViewCar car,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishCar(car, facefile, otherfile, badfile);
        }

        private ActionResult PublishCar(TransferViewCar car, List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            if (BuildCar(car, facefile, otherfile, badfile))
            {
                CarTransferInfo transfercar = MapperCar(car);
                transferService.SaveTransferCar(transfercar);
                RunJob();
                return View("Success");
            }
            return View("FaildTransfer");
        }

        public ActionResult FaildTransfer()
        {
            return View();
        }


        private CarTransferInfo MapperCar(TransferViewCar car)
        {
            var info = new CarTransferInfo();
            info.CarMileage = car.CarMileage;
            info.CarYear = car.CarYear;
            info.CatagroyId = car.CatagroyId;
            info.AreaId = car.AreaId;
            info.Controller = this.ControllerName;
            info.Action = this.ActionName;
            info.CityId = car.CityId;
            info.Mark = car.Mark;
            car.FaceFiles.ForEach(r => info.Pictures.Add(r));
            car.OtherFiles.ForEach(r => info.Pictures.Add(r));
            car.BadFiles.ForEach(r => info.Pictures.Add(r));
            info.Price = (int)car.Price;
            info.PublishTitle = car.Title;
            info.PublishUserEmail = car.Email;
            info.UserAccount = User.Identity.Name;
            return info;
        }

        private bool BuildCar(TransferViewCar car, List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            InitParas();
            string pictureName;
            //图片保存到
            #region FaceFile
            foreach (var face in facefile)
            {
                if (face.HasFile())
                {
                    pictureName = GetPictureName();
                    car.FaceFiles.Add(new TransferPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Head,
                        PhysicalPath = GetPhysicalPath() + pictureName
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
                    car.OtherFiles.Add(new TransferPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Head,
                        PhysicalPath = GetPhysicalPath() + pictureName
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
                    car.BadFiles.Add(new TransferPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Head,
                        PhysicalPath = GetPhysicalPath() + pictureName
                    });
                    SaveFile(bad, GetPhysicalPath(), GetPhysicalPath() + pictureName);
                }
            }
            #endregion

            return true;
        }




        #region BindData
        private void BindData()
        {
            BindCatagroy();
            BindCarYear();
            BindCarMileage();
        }

        private void BindCarMileage()
        {
            ViewData["carMileage"] = GetCarMileageDetail();
        }

        private void BindCarYear()
        {
            ViewData["carYear"] = GetCarYearDetail();
        }

        private void BindCatagroy()
        {
            InitParas();
            ViewData["catagroy"] = GetCatagroyDetail();
        }

        [OutputCache(Duration = 3600)]
        private List<SelectListItem> GetCatagroyDetail()
        {
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择车辆类别--" });
            carService.GetChannelTransferDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            return details;
        }


        [OutputCache(Duration = 3600)]
        private List<SelectListItem> GetCarYearDetail()
        {
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择生产年份--" });
            carService.GetCarShowYear().ForEach(r => details.Add(new SelectListItem() { Text = r.ToString(), Value = r.ToString() }));
            return details;
        }

        [OutputCache(Duration = 3600)]
        private object GetCarMileageDetail()
        {
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择里程数--" });
            foreach (var item in carService.GetCarMileage())
            {
                details.Add(new SelectListItem() { Value = item.Key.ToString(), Text = item.Value });
            }
            return details;
        }
        #endregion

        #region UpLoad
        private readonly string transferPhysicalImagePath = @"UploadImage\Transfer\CarImage\";
        private readonly string transferVirtualImagePath = "UploadImage/Transfer/CarImage/";


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
                new FxTask.FxCar.Transfer.CarTransferJobLoad().Execute();
            }).Start();
        }
    }
}
