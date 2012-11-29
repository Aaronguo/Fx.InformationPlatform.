using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Fx.Entity.FxGoods;
using Fx.Entity.Catagroy;

namespace Fx.Domain.FxGoods
{
    public class GoodsListService
    {
        public List<GoodsTransferInfo> CultureLife()
        {
            List<GoodsTransferInfo> list;
            using (FxGoodsContext context = new FxGoodsContext())
            {
                list = context.GoodsTransferInfos.Include(r => r.Pictures)
                        .Where(r => r.IsPublish && r.GoodsTransferInfoId == (int)ChannelListCatagroy.CultureLife)
                        .OrderByDescending(r => r.CreatedTime)
                        .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take<GoodsTransferInfo>((list.Count - (list.Count % 4))).ToList<GoodsTransferInfo>();
            }
            return list;
        }

        public List<GoodsTransferInfo> Electronics()
        {
            List<GoodsTransferInfo> list;
            using (FxGoodsContext context = new FxGoodsContext())
            {
                list = context.GoodsTransferInfos.Include(r => r.Pictures)
                        .Where(r => r.IsPublish && r.GoodsTransferInfoId == (int)ChannelListCatagroy.Electronics)
                        .OrderByDescending(r => r.CreatedTime)
                        .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take<GoodsTransferInfo>((list.Count - (list.Count % 4))).ToList<GoodsTransferInfo>();
            }
            return list;
        }

        public List<GoodsTransferInfo> Fashion()
        {
            List<GoodsTransferInfo> list;
            using (FxGoodsContext context = new FxGoodsContext())
            {
                list = context.GoodsTransferInfos.Include(r => r.Pictures)
                        .Where(r => r.IsPublish && r.GoodsTransferInfoId == (int)ChannelListCatagroy.Fashion)
                        .OrderByDescending(r => r.CreatedTime)
                        .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take<GoodsTransferInfo>((list.Count - (list.Count % 4))).ToList<GoodsTransferInfo>();
            }
            return list;
        }

        public List<GoodsTransferInfo> HomeSupplies()
        {
            List<GoodsTransferInfo> list;
            using (FxGoodsContext context = new FxGoodsContext())
            {
                list = context.GoodsTransferInfos.Include(r => r.Pictures)
                         .Where(r => r.IsPublish && r.GoodsTransferInfoId == (int)ChannelListCatagroy.HomeSupplies)
                         .OrderByDescending(r => r.CreatedTime)
                         .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take<GoodsTransferInfo>((list.Count - (list.Count % 4))).ToList<GoodsTransferInfo>();
            }
            return list;
        }

        public List<GoodsTransferInfo> Other()
        {
            List<GoodsTransferInfo> list;
            using (FxGoodsContext context = new FxGoodsContext())
            {
                list = context.GoodsTransferInfos.Include(r => r.Pictures)
                         .Where(r => r.IsPublish && r.GoodsTransferInfoId == (int)ChannelListCatagroy.Other)
                         .OrderByDescending(r => r.CreatedTime)
                         .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take<GoodsTransferInfo>((list.Count - (list.Count % 4))).ToList<GoodsTransferInfo>();
            }
            return list;
        }
    }
}
