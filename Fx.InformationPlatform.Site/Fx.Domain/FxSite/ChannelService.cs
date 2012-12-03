using System;
using System.Collections.Generic;
using System.Linq;
using Fx.Entity.FxSite;
using Fx.Infrastructure;

namespace Fx.Domain.FxSite
{
    public class ChannelService : IService.IChannelService
    {
        public List<Channel> GetAllChannels()
        {
            using (var content = new SiteContext())
            {
                return content.Channels.OrderBy(r => r.Sorted).ToList();
            }
        }
    }
}
