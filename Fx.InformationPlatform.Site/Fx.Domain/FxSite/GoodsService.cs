using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Domain.FxSite.IService;
using Fx.Infrastructure;

namespace Fx.Domain.FxSite
{
    public class GoodsService : BaseIService<SiteContext>, IGoods, IDisposable
    {
        public GoodsService()
        {
            this.content = new Lazy<SiteContext>(() => new SiteContext());
        }

        public List<Entity.FxSite.ChannelListDetail> GetChannelBuyDetail(string ControllerName, string ActionName)
        {
            var channelList = content.Value.ChannelLists.Where(
                r => r.BuyController == ControllerName && r.ActionName == ActionName).FirstOrDefault();
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }


        public List<Entity.FxSite.ChannelListDetail> GetChannelTransferDetail(string ControllerName, string ActionName)
        {
            var channelList = content.Value.ChannelLists.Where(
                r => r.TransferController == ControllerName && r.ActionName == ActionName).FirstOrDefault();
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }
    }

}
