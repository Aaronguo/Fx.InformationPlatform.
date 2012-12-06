using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;
using Fx.Entity;

namespace Fx.Domain.FxAggregate
{
    public class AggregateInfoService : IAggregateInfo
    {
        public IInfo GetInfoByCatatgroyAndId(int ChannelCatagroy, int infoId)
        {
            if (ChannelCatagroy == (int)Fx.Entity.ChannelCatagroy.FxCarBuy)
            {
                using (var content = new Fx.Domain.FxCar.FxCarContext())
                {
                    return content.CarBuyInfos.Where(r => r.CarBuyInfoId == infoId).FirstOrDefault();
                }
            }
            if (ChannelCatagroy == (int)Fx.Entity.ChannelCatagroy.FxCarTransfer)
            {
                using (var content = new Fx.Domain.FxCar.FxCarContext())
                {
                    return content.CarTransferInfos.Where(r => r.CarTransferInfoId == infoId).FirstOrDefault();
                }
            }
            if (ChannelCatagroy == (int)Fx.Entity.ChannelCatagroy.FxGoodsBuy)
            {
                using (var content = new Fx.Domain.FxGoods.FxGoodsContext())
                {
                    return content.GoodsBuyInfos.Where(r => r.GoodsBuyInfoId == infoId).FirstOrDefault();
                }
            }

            if (ChannelCatagroy == (int)Fx.Entity.ChannelCatagroy.FxGoodsTransfer)
            {
                using (var content = new Fx.Domain.FxGoods.FxGoodsContext())
                {
                    return content.GoodsTransferInfos.Where(r => r.GoodsTransferInfoId == infoId).FirstOrDefault();
                }
            }

            if (ChannelCatagroy == (int)Fx.Entity.ChannelCatagroy.FxHouseBuy)
            {
                using (var content = new Fx.Domain.FxHouse.FxHouseContext())
                {
                    return content.HouseBuyInfos.Where(r => r.HouseBuyInfoId == infoId).FirstOrDefault();
                }
            }

            if (ChannelCatagroy == (int)Fx.Entity.ChannelCatagroy.FxHouseTrasnfer)
            {
                using (var content = new Fx.Domain.FxHouse.FxHouseContext())
                {
                    return content.HouseTransferInfos.Where(r => r.HouseTransferInfoId == infoId).FirstOrDefault();
                }
            }
            return null;
        }


        public bool IsValid(IInfo info)
        {
            return info.IsPublish;
        }
    }
}
