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

namespace Fx.InformationPlatform.Site.Controllers
{
    public class CarTransferController : BaseController
    {
        ICar carService;
        ITransferCar transferService;
        IAccountService accountService;
        private readonly string transferImagePath = "~/UploadImage/Transfer/CarImage";

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


        [HttpPost]
        public ActionResult Electronics(TransferViewCar car,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            if (BuildCar(car, facefile, otherfile, badfile))
            {
                CarTransferInfo transfergoods = MapperCar(car);
                transferService.SaveTransferCar(transfergoods);
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
                    car.FaceFiles.Add(new TransferPicture()
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
                    car.OtherFiles.Add(new TransferPicture()
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
                    car.BadFiles.Add(new TransferPicture()
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
    }
}
