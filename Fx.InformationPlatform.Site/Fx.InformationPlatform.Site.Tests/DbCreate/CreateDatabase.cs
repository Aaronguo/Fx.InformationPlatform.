using System;
using System.Linq;
using System.Data.Entity;
using Fx.Domain.FxCar;
using Fx.Domain.FxGoods;
using Fx.Domain.FxHouse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fx.Entity.FxGoods;
using Fx.Entity;

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
            CreateAggregate();
        }


        [TestMethod]
        public void CreateHouse()
        {
            //System.Data.Entity.Database.SetInitializer(new FxHouseInitializer());
            FxHouseContext context = new FxHouseContext();
            var entity = new Fx.Entity.FxHouse.HouseBuyInfo()
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
            };
            context.HouseBuyInfos.Add(entity);
            context.SaveChanges();
            context.HouseBuyInfos.Remove(entity);
            context.SaveChanges();
        }

        [TestMethod]
        public void CreateCar()
        {
            FxCarContext context = new FxCarContext();
            var entity = new Entity.FxCar.CarTransferInfo()
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
            };
            context.SaveChanges();
            context.CarTransferInfos.Remove(entity);
        }

        [TestMethod]
        public void CreateGoods()
        {
            FxGoodsContext context = new FxGoodsContext();
            var entity = new Entity.FxGoods.GoodsTransferInfo()
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
            };
            context.GoodsTransferInfos.Add(entity);
            context.SaveChanges();
            context.GoodsTransferInfos.Remove(entity);
            context.SaveChanges();
        }

        [TestMethod]
        public void CreateAggregate()
        {
            Fx.Domain.FxAggregate.FxAggregateContext context = new Domain.FxAggregate.FxAggregateContext();
            var entity = new Entity.FxAggregate.Favorite()
            {
                Title = "",
                InfoId = 1000,
                ChannelCatagroy = (int)ChannelCatagroy.FxCarTransfer
            };
            context.Favorites.Add(entity);
            context.SaveChanges();
            context.Favorites.Remove(entity);
            context.SaveChanges();
        }
    }
}
