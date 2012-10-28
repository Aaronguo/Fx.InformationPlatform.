using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Domain.FxSite.IService;
using Fx.Infrastructure;

namespace Fx.Domain.FxSite
{
    public class GoodsService : BaseIService<SiteContent>, IGoods, IDisposable
    {
        public GoodsService()
        {
            this.content = new SiteContent();
        }

        public List<Entity.FxSite.ChannelListDetail> GetChannelDetail(string ControllerName, string ActionName)
        {
            var channelList = content.ChannelLists.Where(
                r => r.ControllerName == ControllerName && r.ActionName == ActionName).FirstOrDefault();
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }
    }

}
