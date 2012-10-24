using System.Collections.Generic;
using Fx.Entity.FxSite;

namespace Fx.Domain.FxSite.IService
{
   public interface IChannelService
    {
        /// <summary>
        /// 获取所有的频道列表
        /// </summary>
        /// <returns></returns>
        List<Channel> GetAllChannels();
    }
}
