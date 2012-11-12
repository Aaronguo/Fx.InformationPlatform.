using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Domain.FxHouse.IService;
using Fx.Domain.FxSite.IService;
using Fx.Entity.FxHouse;
using Fx.InformationPlatform.Site.ViewModel;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class HouseBuyController : BaseController
    {
        IHouse houseService;        
        IBuyHouse buyService;
        IAccountService accountService;
        //private readonly string buyImagePath = "~/UploadImage/Buy/HouseImage";
        public HouseBuyController(IHouse houseService, 
            IBuyHouse buyService,
            IAccountService accountService)
        {
            this.houseService = houseService;
            this.buyService = buyService;
            this.accountService = accountService;
        }

        public ActionResult CommercialProperties()
        {
            BindCatagroy();
            return View();
        }


        [HttpPost]
        public ActionResult CommercialProperties(BuyViewHouse house)
        {
            if (BuildHouse(house))
            {
                HouseBuyInfo transferhouse = MapperCar(house);
                buyService.SaveBuyHouse(transferhouse);
                return View("Success");
            }
            return View("FaildTransfer");
        }

        private bool BuildHouse(BuyViewHouse car)
        {
            InitParas();
            return true;
        }

        private HouseBuyInfo MapperCar(BuyViewHouse house)
        {
            var info = new HouseBuyInfo();
            info.Bill = house.Bill;
            info.HasFurniture = house.HasFurniture;
            info.CatagroyId = house.CatagroyId;
            info.AreaId = house.AreaId; ;
            info.Controller = this.ControllerName;
            info.Action = this.ActionName;
            info.CityId = house.CityId;
            info.Mark = house.Mark;
            info.Price = (int)house.Price;
            info.PublishTitle = house.Title;
            info.PublishUserEmail = house.Email;
            info.UserAccount = User.Identity.Name;
            return info;
        }



        private void BindCatagroy()
        {
            InitParas();
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择物品类别--" });
            houseService.GetChannelBuyDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            ViewData["catagroy"] = details;
        }

    }
}
