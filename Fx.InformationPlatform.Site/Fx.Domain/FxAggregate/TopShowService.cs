using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;
using Fx.Domain.FxCar.IService;
using Fx.Domain.FxGoods.IService;
using Fx.Domain.FxHouse.IService;
using Fx.Entity;
using Fx.Entity.FxAggregate;
using Fx.Entity.FxCar;
using Fx.Entity.FxGoods;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxAggregate
{
    public class TopShowService : ITopShow, IHomeTopShow
    {
        protected IBuyCar buyCarService;
        protected ITransferCar transferCarService;
        protected IBuyHouse buyHouseService;
        protected ITransferHouse transferHouseService;
        protected IBuyGoods buyGoodsService;
        protected ITransferGoods transferGoodsService;

        public TopShowService(IBuyCar buyCarService,
            ITransferCar transferCarService,
            IBuyHouse buyHouseService,
            ITransferHouse transferHouseService,
            IBuyGoods buyGoodsService,
            ITransferGoods transferGoodsService)
        {
            this.buyCarService = buyCarService;
            this.buyGoodsService = buyGoodsService;
            this.buyHouseService = buyHouseService;
            this.transferCarService = transferCarService;
            this.transferGoodsService = transferGoodsService;
            this.transferHouseService = transferHouseService;
        }

        public void TopShow(TopShow entity)
        {
            if (!IsExist(entity))
            {
                using (var content = new FxAggregateContext())
                {
                    content.TopShows.Add(entity);
                    content.SaveChanges();
                }
            }
        }


        public bool IsExist(TopShow entity)
        {
            using (var content = new FxAggregateContext())
            {
                return content.TopShows
                    .Where(r => r.TopShowId == entity.TopShowId && r.ChannelCatagroy == entity.ChannelCatagroy)
                    .FirstOrDefault() != null;
            }
        }


        /// <summary>
        /// 取消置顶
        /// </summary>
        /// <param name="entity"></param>
        public void TopShowCancel(TopShow entity)
        {
            if (IsExist(entity))
            {
                using (var content = new FxAggregateContext())
                {
                    entity = content.TopShows
                    .Where(r => r.TopShowId == entity.TopShowId && r.ChannelCatagroy == entity.ChannelCatagroy)
                    .FirstOrDefault();
                    if (entity != null)
                    {
                        content.TopShows.Remove(entity);
                        content.SaveChanges();
                    }
                }
            }
        }


        public List<TopShow> GetAllTopShow()
        {
            using (var content = new FxAggregateContext())
            {
                return content.TopShows.ToList();
            }
        }


        public TopShow GetById(int id)
        {
            using (var content = new FxAggregateContext())
            {
                return content.TopShows.Where(r => r.TopShowId == id).FirstOrDefault();
            }
        }

       
        public List<CarTransferInfo> GetHomeCarTopShow()
        {
            var topShows = new List<TopShow>();
            var cars = new List<CarTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxCarTransfer).ToList();
            }
            foreach (var item in topShows)
            {
                cars.Add(new CarTransferInfo()
                {
                    CarTransferInfoId = item.InfoId,
                    Price = item.Price,
                    PublishTitle = item.Title,
                    Pictures = new List<TransferPicture>() { 
                        new  TransferPicture(){
                             TransferPictureCatagroy= (int)PictureCatagroy.Head,
                             ImageUrl=item.HeadPicture,
                        }
                    }
                });
            }
            return cars;
        }

        public List<GoodsTransferInfo> GetHomeGoodsTopShow()
        {
            var topShows = new List<TopShow>();
            var goods = new List<GoodsTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxGoodsTransfer).ToList();
            }
            foreach (var item in topShows)
            {
                goods.Add(new GoodsTransferInfo()
                {
                    GoodsTransferInfoId = item.InfoId,
                    Price = item.Price,
                    PublishTitle = item.Title,
                    Pictures = new List<TransferPicture>() { 
                        new  TransferPicture(){
                             TransferPictureCatagroy= (int)PictureCatagroy.Head,
                             ImageUrl=item.HeadPicture,
                        }
                    }
                });
            }
            return goods;
        }

        public List<HouseTransferInfo> GetHomeHouseTopShow()
        {
            var topShows = new List<TopShow>();
            var houses = new List<HouseTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxHouseTrasnfer).ToList();
            }
            foreach (var item in topShows)
            {
                houses.Add(new HouseTransferInfo()
                {
                    HouseTransferInfoId = item.InfoId,
                    Price = item.Price,
                    PublishTitle = item.Title,
                    Pictures = new List<TransferPicture>() { 
                        new  TransferPicture(){
                             TransferPictureCatagroy= (int)PictureCatagroy.Head,
                             ImageUrl=item.HeadPicture,
                        }
                    }
                });
            }
            return houses;
        }

    
        public List<CarTransferInfo> GetCarTransferTopShow()
        {
            var topShows = new List<TopShow>();
            var cars = new List<CarTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxCarTransfer).ToList();
            }
            foreach (var item in topShows)
            {
                cars.Add(this.transferCarService.Get(item.InfoId));
            }
            return cars;
        }

        public List<GoodsTransferInfo> GetGoodsTransferTopShow()
        {
            var topShows = new List<TopShow>();
            var goods = new List<GoodsTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxGoodsTransfer).ToList();
            }
            foreach (var item in topShows)
            {
                goods.Add(this.transferGoodsService.Get(item.InfoId));
            }
            return goods;
        }

        public List<HouseTransferInfo> GetHouseTransferTopShow()
        {
            var topShows = new List<TopShow>();
            var houses = new List<HouseTransferInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxHouseTrasnfer).ToList();
            }
            foreach (var item in topShows)
            {
                houses.Add(this.transferHouseService.Get(item.InfoId));
            }
            return houses;
        }


        public List<CarBuyInfo> GetCarBuyTopShow()
        {
            var topShows = new List<TopShow>();
            var cars = new List<CarBuyInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxCarBuy).ToList();
            }
            foreach (var item in topShows)
            {
                cars.Add(buyCarService.Get(item.InfoId));
            }
            return cars;
        }

        public List<GoodsBuyInfo> GetGoodsBuyTopShow()
        {
            var topShows = new List<TopShow>();
            var goods = new List<GoodsBuyInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxGoodsBuy).ToList();
            }
            foreach (var item in topShows)
            {
                goods.Add(this.buyGoodsService.Get(item.InfoId));
            }
            return goods;
        }

        public List<HouseBuyInfo> GetHouseBuyTopShow()
        {
            var topShows = new List<TopShow>();
            var houses = new List<HouseBuyInfo>();
            using (var content = new FxAggregateContext())
            {
                topShows = content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxHouseBuy).ToList();
            }
            foreach (var item in topShows)
            {
                houses.Add(this.buyHouseService.Get(item.InfoId));
            }
            return houses;
        }
    }
}
