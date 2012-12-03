using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Entity.Catagroy;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse
{
    /// <summary>
    /// 用于HouseList的信息获取
    /// </summary>
    public class HouseListService
    {
        public List<HouseTransferInfo> CommercialProperties()
        {
            List<HouseTransferInfo> list;
            using (FxHouseContext context = new FxHouseContext())
            {
                list = context.HouseTransferInfos.Include(r => r.Pictures)
                .Where(r => r.IsPublish &&
                    (r.HouseTransferInfoId >= (int)ChannelListDetailCatagroy.Shop ||
                    r.HouseTransferInfoId <= (int)ChannelListDetailCatagroy.Office))
                .OrderByDescending(r => r.CreatedTime)
                .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take(list.Count - list.Count % 4).ToList();
            }
            return list;
        }

        public List<HouseTransferInfo> Properties()
        {
            List<HouseTransferInfo> list;
            using (FxHouseContext context = new FxHouseContext())
            {
                list = context.HouseTransferInfos.Include(r => r.Pictures)
                .Where(r => r.IsPublish &&
                    (r.HouseTransferInfoId >= (int)ChannelListDetailCatagroy.House ||
                    r.HouseTransferInfoId <= (int)ChannelListDetailCatagroy.StudentAparment))
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
