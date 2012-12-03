using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxGoods;
using Fx.Entity.Catagroy;

namespace Fx.Domain.FxGoods
{
    /// <summary>
    /// 用于GoodsList栏目中信息获取
    /// </summary>
    public class GoodsListService
    {
        public List<GoodsTransferInfo> CultureLife()
        {
            List<GoodsTransferInfo> list;
            using (FxGoodsContext context = new FxGoodsContext())
            {
                list = context.GoodsTransferInfos.Include(r => r.Pictures)
                        .Where(r => r.IsPublish &&
                            (r.GoodsTransferInfoId >= (int)ChannelListDetailCatagroy.MusicInstruments ||
                            r.GoodsTransferInfoId >= (int)ChannelListDetailCatagroy.CultureLifeOther))
                        .OrderByDescending(r => r.CreatedTime)
                        .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take(list.Count - list.Count % 4).ToList();
            }
            return list;
        }

        public List<GoodsTransferInfo> Electronics()
        {
            List<GoodsTransferInfo> list;
            using (FxGoodsContext context = new FxGoodsContext())
            {
                list = context.GoodsTransferInfos.Include(r => r.Pictures)
                        .Where(r => r.IsPublish &&
                            (r.GoodsTransferInfoId >= (int)ChannelListDetailCatagroy.Phone ||
                            r.GoodsTransferInfoId >= (int)ChannelListDetailCatagroy.ElectronicsOther))
                        .OrderByDescending(r => r.CreatedTime)
                        .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take(list.Count - list.Count % 4).ToList();
            }
            return list;
        }

        public List<GoodsTransferInfo> Fashion()
        {
            List<GoodsTransferInfo> list;
            using (FxGoodsContext context = new FxGoodsContext())
            {
                list = context.GoodsTransferInfos.Include(r => r.Pictures)
                        .Where(r => r.IsPublish &&
                            (r.GoodsTransferInfoId >= (int)ChannelListDetailCatagroy.Clothing ||
                            r.GoodsTransferInfoId >= (int)ChannelListDetailCatagroy.FashionOther))
                        .OrderByDescending(r => r.CreatedTime)
                        .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take(list.Count - list.Count % 4).ToList();
            }
            return list;
        }

        public List<GoodsTransferInfo> HomeSupplies()
        {
            List<GoodsTransferInfo> list;
            using (FxGoodsContext context = new FxGoodsContext())
            {
                list = context.GoodsTransferInfos.Include(r => r.Pictures)
                         .Where(r => r.IsPublish &&
                            (r.GoodsTransferInfoId >= (int)ChannelListDetailCatagroy.Furniture ||
                            r.GoodsTransferInfoId >= (int)ChannelListDetailCatagroy.HomeSuppliesOther))
                         .OrderByDescending(r => r.CreatedTime)
                         .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take(list.Count - list.Count % 4).ToList();
            }
            return list;
        }

        public List<GoodsTransferInfo> Other()
        {
            List<GoodsTransferInfo> list;
            using (FxGoodsContext context = new FxGoodsContext())
            {
                list = context.GoodsTransferInfos.Include(r => r.Pictures)
                         .Where(r => r.IsPublish &&
                            (r.GoodsTransferInfoId == (int)ChannelListDetailCatagroy.OtherOther))
                         .OrderByDescending(r => r.CreatedTime)
                         .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take(list.Count - list.Count % 4).ToList();
            }
            return list;
        }
    }
}
