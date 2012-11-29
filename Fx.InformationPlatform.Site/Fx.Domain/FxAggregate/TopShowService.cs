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
        public List<Fx.Entity.FxAggregate.TopShow> GetAllTopShow()
        {
            using (FxAggregateContext context = new FxAggregateContext())
            {
                return context.TopShows.ToList<Fx.Entity.FxAggregate.TopShow>();
            }
        }

        public Fx.Entity.FxAggregate.TopShow GetById(int id)
        {
            using (FxAggregateContext context = new FxAggregateContext())
            {
                return (from r in context.TopShows
                        where r.TopShowId == id
                        select r).FirstOrDefault<Fx.Entity.FxAggregate.TopShow>();
            }
        }

        public List<CarTransferInfo> GetHomeCarTopShow()
        {
            List<Fx.Entity.FxAggregate.TopShow> list = new List<Fx.Entity.FxAggregate.TopShow>();
            List<CarTransferInfo> list2 = new List<CarTransferInfo>();
            using (FxAggregateContext context = new FxAggregateContext())
            {
                list = (from r in context.TopShows
                        where r.ChannelCatagroy == 0
                        select r).ToList<Fx.Entity.FxAggregate.TopShow>();
            }
            foreach (Fx.Entity.FxAggregate.TopShow show in list)
            {
                CarTransferInfo item = new CarTransferInfo
                {
                    CarTransferInfoId = show.InfoId,
                    Price = show.Price,
                    PublishTitle = show.Title
                };
                List<TransferPicture> list3 = new List<TransferPicture>();
                TransferPicture picture = new TransferPicture
                {
                    TransferPictureCatagroy = 0,
                    ImageUrl = show.HeadPicture
                };
                list3.Add(picture);
                item.Pictures = list3;
                list2.Add(item);
            }
            return list2;
        }

        public List<GoodsTransferInfo> GetHomeGoodsTopShow()
        {
            List<Fx.Entity.FxAggregate.TopShow> list = new List<Fx.Entity.FxAggregate.TopShow>();
            List<GoodsTransferInfo> list2 = new List<GoodsTransferInfo>();
            using (FxAggregateContext context = new FxAggregateContext())
            {
                list = (from r in context.TopShows
                        where r.ChannelCatagroy == 2
                        select r).ToList<Fx.Entity.FxAggregate.TopShow>();
            }
            foreach (Fx.Entity.FxAggregate.TopShow show in list)
            {
                GoodsTransferInfo item = new GoodsTransferInfo
                {
                    GoodsTransferInfoId = show.InfoId,
                    Price = show.Price,
                    PublishTitle = show.Title
                };
                List<TransferPicture> list3 = new List<TransferPicture>();
                TransferPicture picture = new TransferPicture
                {
                    TransferPictureCatagroy = 0,
                    ImageUrl = show.HeadPicture
                };
                list3.Add(picture);
                item.Pictures = list3;
                list2.Add(item);
            }
            return list2;
        }

        public List<HouseTransferInfo> GetHomeHouseTopShow()
        {
            List<Fx.Entity.FxAggregate.TopShow> list = new List<Fx.Entity.FxAggregate.TopShow>();
            List<HouseTransferInfo> list2 = new List<HouseTransferInfo>();
            using (FxAggregateContext context = new FxAggregateContext())
            {
                list = (from r in context.TopShows
                        where r.ChannelCatagroy == 4
                        select r).ToList<Fx.Entity.FxAggregate.TopShow>();
            }
            foreach (Fx.Entity.FxAggregate.TopShow show in list)
            {
                HouseTransferInfo item = new HouseTransferInfo
                {
                    HouseTransferInfoId = show.InfoId,
                    Price = show.Price,
                    PublishTitle = show.Title
                };
                List<TransferPicture> list3 = new List<TransferPicture>();
                TransferPicture picture = new TransferPicture
                {
                    TransferPictureCatagroy = 0,
                    ImageUrl = show.HeadPicture
                };
                list3.Add(picture);
                item.Pictures = list3;
                list2.Add(item);
            }
            return list2;
        }

        public bool IsExist(Fx.Entity.FxAggregate.TopShow entity)
        {
            using (FxAggregateContext context = new FxAggregateContext())
            {
                return ((from r in context.TopShows
                         where (r.TopShowId == entity.TopShowId) && (r.ChannelCatagroy == entity.ChannelCatagroy)
                         select r).FirstOrDefault<Fx.Entity.FxAggregate.TopShow>() != null);
            }
        }

        public void TopShow(Fx.Entity.FxAggregate.TopShow entity)
        {
            if (!this.IsExist(entity))
            {
                using (FxAggregateContext context = new FxAggregateContext())
                {
                    context.TopShows.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public void TopShowCancel(Fx.Entity.FxAggregate.TopShow entity)
        {
            if (this.IsExist(entity))
            {
                using (FxAggregateContext context = new FxAggregateContext())
                {
                    entity = (from r in context.TopShows
                              where (r.TopShowId == entity.TopShowId) && (r.ChannelCatagroy == entity.ChannelCatagroy)
                              select r).FirstOrDefault<Fx.Entity.FxAggregate.TopShow>();
                    if (entity != null)
                    {
                        context.TopShows.Remove(entity);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
