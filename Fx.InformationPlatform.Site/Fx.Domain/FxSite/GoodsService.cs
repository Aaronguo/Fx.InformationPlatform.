using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Fx.Domain.FxSite.IService;
using Fx.Entity.FxSite;
using Fx.Infrastructure;

namespace Fx.Domain.FxSite
{
    public class GoodsService : IGoods
    {
        public List<Entity.FxSite.ChannelListDetail> GetChannelBuyDetail(string ControllerName, string ActionName)
        {
            ChannelList channelList;
            using (var content = new SiteContext())
            {
                channelList = content.ChannelLists.Include(r=>r.ChannelListDetails)
                    .Where(r => r.BuyController == ControllerName && 
                        r.ActionName == ActionName).FirstOrDefault();
            }
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }


        public List<Entity.FxSite.ChannelListDetail> GetChannelTransferDetail(string ControllerName, string ActionName)
        {
            ChannelList channelList;
            using (var content = new SiteContext())
            {
                channelList = content.ChannelLists.Include(r=>r.ChannelListDetails)
                    .Where(r => r.TransferController == ControllerName && 
                        r.ActionName == ActionName).FirstOrDefault();
            }
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }
    }

}
