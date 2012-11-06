using System;
using System.Collections.Generic;
using System.Linq;
using Fx.Entity.FxSite;
using Fx.Infrastructure;

namespace Fx.Domain.FxSite
{
    public class ChannelService : BaseIService<SiteContext>, IService.IChannelService, IDisposable
    {
        public ChannelService()
        {
            this.content = new Lazy<SiteContext>(() => new SiteContext());
        }

        public List<Channel> GetAllChannels()
        {
            return content.Value.Channels.OrderBy(r => r.Sorted).ToList();
        }
    }
}
