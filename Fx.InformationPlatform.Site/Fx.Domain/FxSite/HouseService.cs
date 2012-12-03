using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxSite.IService;
using Fx.Entity.FxSite;
using Fx.Infrastructure;
using Fx.Infrastructure.Caching;

namespace Fx.Domain.FxSite
{
    public class HouseService : IHouse
    {
        ICacheManager cachemanager;
        public HouseService(ICacheManager cachemanager)
        {
            this.cachemanager = cachemanager;
        }

        public List<Entity.FxSite.ChannelListDetail> GetChannelBuyDetail(string ControllerName, string ActionName)
        {
            ChannelList channelList;
            using (var content = new SiteContext())
            {
                channelList = content.ChannelLists.Where(
                   r => r.BuyController == ControllerName && r.ActionName == ActionName).FirstOrDefault();
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
                channelList = content.ChannelLists.Where(
                   r => r.TransferController == ControllerName && r.ActionName == ActionName).FirstOrDefault();
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
