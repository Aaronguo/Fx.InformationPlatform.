using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxCar.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 具体车辆转让详情页面
    /// </summary>
    public class CarTransferDetailController : Controller
    {
        protected ITransferCar transferCar;
        public CarTransferDetailController(ITransferCar transferCar)
        {
            this.transferCar = transferCar;
        }

        public ActionResult Index(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                var car = transferCar.Get(id);
                if (car == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
                return View(car);
            }
        }
    }
}
