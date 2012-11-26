using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;
using Fx.Entity;
using Fx.Entity.FxAggregate;
using Fx.Entity.FxCar;
using Fx.Entity.FxGoods;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxAggregate
{
    public class TopShowService : ITopShow, IHomeTopShow
    {
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
                topShows=content.TopShows.Where(r => r.ChannelCatagroy == (int)ChannelCatagroy.FxCarTransfer).ToList();                
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
    }
}
