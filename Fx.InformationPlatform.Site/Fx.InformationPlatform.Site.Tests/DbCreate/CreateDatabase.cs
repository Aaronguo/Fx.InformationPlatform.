using System;
using Fx.Domain.FxCar;
using Fx.Domain.FxGoods;
using Fx.Domain.FxHouse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fx.InformationPlatform.Site.Tests.DbCreate
{
    [TestClass]
    public class CreateDatabase
    {
        [TestMethod]
        public void CreateAll()
        {
            CreateCar();
            CreateHouse();
            CreateGoods();
        }


        [TestMethod]
        public void CreateHouse()
        {
            System.Data.Entity.Database.SetInitializer(new FxHouseInitializer());
            FxHouseContext context = new FxHouseContext("fx.house-sqlserver");
            context.HouseBuyInfos.Add(new Fx.Entity.FxHouse.HouseBuyInfo()
            {
                Action = "Action",
                AreaId = 1,
                Bill = false,
                CatagroyId = 1,
                CityId = 1,
                Controller = "Controller",
                HasFurniture = false,
                Mark = "Mark",
                Price = 1000,
                PublishTitle = "Title",
                PublishUserEmail = "PublishUserEmail",
                RoomNumber = 6,
                UserAccount = "UserAccount"
            });
            context.HouseTransferInfos.Add(new Entity.FxHouse.HouseTransferInfo()
            {
                Action = "Action",
                AreaId = 1,
                Bill = false,
                CatagroyId = 1,
                CityId = 1,
                Controller = "Controller",
                HasFurniture = false,
                Mark = "Mark",
                IsDelete = false,
                IsPublish = false,
                PostCode = "",
                Price = 10003,
                PublishTitle = "PublishTitle",
                PublishUserEmail = "PublishUserEmail",
                RoadName = "RoadName",
                Pictures = new System.Collections.Generic.List<Entity.TransferPicture>() { 
                    new  Entity.TransferPicture(){
                         CdnUrl="CdnUrl", ImageUrl="ImageUrl", IsCdn=false, PhysicalPath="PhysicalPath", TransferPictureCatagroy=1                         
                    }
                },
                RoomNumber = 7,
                UserAccount = "UserAccount"
            });
            context.SaveChanges();

        }

        [TestMethod]
        public void CreateCar()
        {
            System.Data.Entity.Database.SetInitializer(new FxCarInitializer());
            FxCarContext context = new FxCarContext("fx.car-sqlserver");
            context.CarTransferInfos.Add(new Entity.FxCar.CarTransferInfo()
            {
                Action = "Action",
                AreaId = 1,
                CarMileage = 232,
                CarYear = 1998,
                CatagroyId = 1,
                CityId = 1,
                Controller = "Controller",
                IsDelete = false,
                IsPublish = false,
                Mark = "Mark",
                Pictures = new System.Collections.Generic.List<Entity.TransferPicture>() { 
                    new Entity.TransferPicture() { 
                         CdnUrl="CdnUrl", ImageUrl="CdnUrl", IsCdn=false, PhysicalPath="CdnUrl", TransferPictureCatagroy=2
                    } 
                },
                Price = 1232,
                PublishTitle = "PublishTitle",
                PublishUserEmail = "PublishUserEmail",
                UserAccount = "UserAccount"
            });
            context.CarBuyInfos.Add(new Entity.FxCar.CarBuyInfo()
            {
                Action = "Action",
                AreaId = 1,
                CarMileage = 1111,
                CarYear = 2000,
                CityId = 1,
                CatagroyId = 1,
                Controller = "Controller",
                IsDelete = false,
                IsPublish = false,
                Mark = "Mark",
                Price = 2000,
                PublishTitle = "PublishTitle",
                PublishUserEmail = "PublishUserEmail",
                UserAccount = "UserAccount"
            });
            context.SaveChanges();
        }

        [TestMethod]
        public void CreateGoods()
        {
            System.Data.Entity.Database.SetInitializer(new FxGoodsInitializer());
            FxGoodsContext context = new FxGoodsContext("fx.goods-sqlserver");
            context.GoodsTransferInfos.Add(new Entity.FxGoods.GoodsTransferInfo()
            {
                Action = "Action",
                AreaId = 1,
                ChangeMsg = "ChangeMsg",
                GoodsConditionMsg = "GoodsConditionMsg",
                GoodsconditonId = 1,
                IsChange = false,
                CatagroyId = 1,
                CityId = 1,
                Controller = "Controller",
                IsDelete = false,
                IsPublish = false,
                Mark = "Mark",
                Pictures = new System.Collections.Generic.List<Entity.TransferPicture>() { 
                    new Entity.TransferPicture() { 
                         CdnUrl="CdnUrl", ImageUrl="CdnUrl", IsCdn=false, PhysicalPath="CdnUrl", TransferPictureCatagroy=2
                    } 
                },
                Price = 1232,
                PublishTitle = "PublishTitle",
                PublishUserEmail = "PublishUserEmail",
                UserAccount = "UserAccount"
            });
            context.GoodsBuyInfos.Add(new Entity.FxGoods.GoodsBuyInfo()
            {
                Action = "Action",
                AreaId = 1,
                ChangeMsg = "ChangeMsg",
                GoodsConditionMsg = "GoodsConditionMsg",
                GoodsconditonId = 1,
                IsChange = false,
                CatagroyId = 1,
                CityId = 1,
                Controller = "Controller",
                IsDelete = false,
                IsPublish = false,
                Mark = "Mark",
                Pictures = new System.Collections.Generic.List<Entity.BuyPicture>() { 
                    new Entity.BuyPicture() { 
                         CdnUrl="CdnUrl", ImageUrl="CdnUrl", IsCdn=false, PhysicalPath="CdnUrl", BuyPictureCatagroy=2
                    } 
                },
                Price = 1232,
                PublishTitle = "PublishTitle",
                PublishUserEmail = "PublishUserEmail",
                UserAccount = "UserAccount"
            });
            context.SaveChanges();
        }




    }
}
