using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class CarTransferController : BaseController
    {
       
        public CarTransferController()
        {
                       
        }
        
        public ActionResult SecondHandCar()
        {           
            BindCatagroy();
            return View();
        }


        private void BindCatagroy()
        {
            InitParas();
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择物品类别--" });
            //goodsService.GetChannelTransferDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            ViewData["catagroy"] = details;
        }
    }
}
