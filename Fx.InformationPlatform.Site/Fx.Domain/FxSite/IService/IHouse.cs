using System.Collections.Generic;
using Fx.Entity.FxSite;

namespace Fx.Domain.FxSite.IService
{
    public interface IHouse
    {
        List<ChannelListDetail> GetChannelTransferDetail(string ControllerName, string ActionName);

        List<ChannelListDetail> GetChannelBuyDetail(string ControllerName, string ActionName);
    }
}
