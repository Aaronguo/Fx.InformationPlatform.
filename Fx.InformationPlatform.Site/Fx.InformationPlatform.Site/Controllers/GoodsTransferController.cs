using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxGoods.IService;
using Fx.Domain.FxSite.IService;
using Fx.Entity;
using Fx.Entity.FxGoods;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class GoodsTransferController : BaseController
    {
        IGoods goodsService;
        ITransferGoods transferService;
        public GoodsTransferController(IGoods goodsService, ITransferGoods transferService)
        {
            this.goodsService = goodsService;
            this.transferService = transferService;
        }

        public ActionResult Electronics()
        {
            BindCatagroy();
            return View();
        }

        public ActionResult Save()
        {
            var goods = new GoodsTransferInfo()
            {
                PublishTitle = "三星i9300手机，全新港版，未拆封，带发票，急转",
                AreaId = 1,
                CityId = 1,
                ChannelListId = 1,
                ChannelListDetailId = 1,
                GoodsconditonId = 1,
                IsChange = false,
                Pictures = new List<TransferPicture>(){
                        new  TransferPicture(){
                             TransferPictureCatagroy= TransferPictureCatagroy.Head,
                             ImageUrl="Goods/head.jpg"
                        },
                        new  TransferPicture(){
                             TransferPictureCatagroy= TransferPictureCatagroy.Other,
                             ImageUrl="Goods/other1.jpg"
                        },
                        new  TransferPicture(){
                             TransferPictureCatagroy= TransferPictureCatagroy.Other,
                             ImageUrl="Goods/other2.jpg"
                        },
                        new  TransferPicture(){
                             TransferPictureCatagroy= TransferPictureCatagroy.Other,
                             ImageUrl="Goods/other3.jpg"
                        },
                        new  TransferPicture(){
                             TransferPictureCatagroy= TransferPictureCatagroy.Bad,
                             ImageUrl="Goods/Bad.jpg"
                        },
                    },
                Price = 100,
                Mark = "Mark1",
                PublishUserEmail = "117822597@163.com"
            };
            bool isSuccess = transferService.SaveTransferGoods(goods);
            ViewData["lable"] = isSuccess;
            return View();
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



    }
}
