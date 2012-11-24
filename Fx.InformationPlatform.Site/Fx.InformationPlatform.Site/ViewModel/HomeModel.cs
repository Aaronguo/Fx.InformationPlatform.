using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class HomeModel
    {
        public List<Fx.Entity.FxGoods.GoodsTransferInfo> GoodsTransferInfos { get; set; }

        public List<Fx.Entity.FxCar.CarTransferInfo> CarTransferInfos { get; set; }

        public List<Fx.Entity.FxHouse.HouseTransferInfo> HouseTransferInfos { get; set; }
    }
}