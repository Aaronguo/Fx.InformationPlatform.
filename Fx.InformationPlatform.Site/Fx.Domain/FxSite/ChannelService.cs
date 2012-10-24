using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity.FxSite;

namespace Fx.Domain.FxSite
{
    public class ChannelService : IService.IChannelService, IDisposable
    {
        SiteContent content = new SiteContent();

        private bool isDispose = false;

        public ChannelService()
        {

        }

        public List<Channel> GetAllChannels()
        {
            return content.Channels.ToList();
        }

        public void Dispose()
        {
            if (!isDispose)
            {
                content.Dispose();
                isDispose = true;
            }
        }
    }
}
