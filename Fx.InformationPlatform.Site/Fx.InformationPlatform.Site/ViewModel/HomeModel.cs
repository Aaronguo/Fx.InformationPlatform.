using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fx.InformationPlatform.Site.ViewModel
{
    public class HomeModel
    {
        public HomeGoodsModel HomeGoodsModel { get; set; }

        public HomeCarModel HomeCarModel { get; set; }

        public HomeHouseModel HomeHouseModel { get; set; }        

        public HomeModel()
        {
            this.HomeCarModel = new HomeCarModel();
            this.HomeGoodsModel = new HomeGoodsModel();
            this.HomeHouseModel = new HomeHouseModel();
        }
    }


    public class HomeGoodsModel
    {
        public List<Fx.Entity.FxGoods.GoodsTransferInfo> GoodsTransferInfo1s { get; set; }

        public List<Fx.Entity.FxGoods.GoodsTransferInfo> GoodsTransferInfo2s { get; set; }

        public List<Fx.Entity.FxGoods.GoodsTransferInfo> GoodsTransferInfo3s { get; set; }

        public HomeGoodsModel()
        {
            this.GoodsTransferInfo1s = new List<Entity.FxGoods.GoodsTransferInfo>();
            this.GoodsTransferInfo2s = new List<Entity.FxGoods.GoodsTransferInfo>();
            this.GoodsTransferInfo3s = new List<Entity.FxGoods.GoodsTransferInfo>();
        }
    }

    public class HomeCarModel
    {
        public List<Fx.Entity.FxCar.CarTransferInfo> CarTransferInfo1s { get; set; }

        public List<Fx.Entity.FxCar.CarTransferInfo> CarTransferInfo2s { get; set; }

        public List<Fx.Entity.FxCar.CarTransferInfo> CarTransferInfo3s { get; set; }

        public HomeCarModel()
        {
            this.CarTransferInfo1s = new List<Entity.FxCar.CarTransferInfo>();
            this.CarTransferInfo2s = new List<Entity.FxCar.CarTransferInfo>();
            this.CarTransferInfo3s = new List<Entity.FxCar.CarTransferInfo>();
        }
    }

    public class HomeHouseModel
    {
        public List<Fx.Entity.FxHouse.HouseTransferInfo> HouseTransferInfo1s { get; set; }

        public List<Fx.Entity.FxHouse.HouseTransferInfo> HouseTransferInfo2s { get; set; }

        public List<Fx.Entity.FxHouse.HouseTransferInfo> HouseTransferInfo3s { get; set; }

        public HomeHouseModel()
        {
            this.HouseTransferInfo1s = new List<Entity.FxHouse.HouseTransferInfo>();
            this.HouseTransferInfo2s = new List<Entity.FxHouse.HouseTransferInfo>();
            this.HouseTransferInfo3s = new List<Entity.FxHouse.HouseTransferInfo>();
        }
    }

}