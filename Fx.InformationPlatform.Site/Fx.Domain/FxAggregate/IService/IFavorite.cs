using System.Collections.Generic;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate.IService
{
    /// <summary>
    /// 收藏相关接口
    /// </summary>
    public interface IFavorite
    {
        DomainResult AddFavorite(Favorite favorite);

        DomainResult DeleteFavorite(Favorite favorite);

        Favorite GetFavorite(int ChannelCatagroy, int infoId, string accountUser);

        List<Favorite> GetFavorite(string accountUser);

        Favorite GetById(int id);

        bool IsFavorite(int ChannelCatagroy, int infoId, string accountUser);
    }
}
