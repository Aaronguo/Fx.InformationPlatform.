using System.Collections.Generic;
using Fx.Entity.FxSite;

namespace Fx.Domain.FxSite.IService
{
    public interface IGoods
    {
        List<ChannelListDetail> GetChannelDetail(string ControllerName, string ActionName);
    }
}
