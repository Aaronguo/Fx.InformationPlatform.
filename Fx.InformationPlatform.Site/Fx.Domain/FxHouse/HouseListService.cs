using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Fx.Entity.FxHouse;
using Fx.Entity.Catagroy;

namespace Fx.Domain.FxHouse
{
    public class HouseListService
    {
        public List<HouseTransferInfo> CommercialProperties()
        {
            List<HouseTransferInfo> list;
            using (FxHouseContext context = new FxHouseContext())
            {
                list = context.HouseTransferInfos.Include(r => r.Pictures)
                .Where(r => r.IsPublish && r.HouseTransferInfoId == (int)ChannelListCatagroy.CommercialProperties)
                .OrderByDescending(r => r.CreatedTime)
                .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take<HouseTransferInfo>((list.Count - (list.Count % 4))).ToList<HouseTransferInfo>();
            }
            return list;
        }

        public List<HouseTransferInfo> Properties()
        {
            List<HouseTransferInfo> list;
            using (FxHouseContext context = new FxHouseContext())
            {
                list = context.HouseTransferInfos.Include(r => r.Pictures)
                .Where(r => r.IsPublish && r.HouseTransferInfoId == (int)ChannelListCatagroy.Properties)
                .OrderByDescending(r => r.CreatedTime)
                .Take(20).ToList();
            }
            if ((list.Count % 4) != 0)
            {
                return list.Take<HouseTransferInfo>((list.Count - (list.Count % 4))).ToList<HouseTransferInfo>();
            }
            return list;
        }
    }
}
