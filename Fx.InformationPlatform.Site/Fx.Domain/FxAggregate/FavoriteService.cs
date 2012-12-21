using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;
using Fx.Entity;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate
{
    public class FavoriteService : IFavorite
    {
        protected IAggregateInfo aggregateInfoService;
        public FavoriteService(IAggregateInfo aggregateInfoService)
        {
            this.aggregateInfoService = aggregateInfoService;
        }

        public DomainResult AddFavorite(Entity.FxAggregate.Favorite favorite)
        {

            using (var context = new FxAggregateContext())
            {
                var fav = GetFavorite(favorite.ChannelCatagroy, favorite.InfoId, favorite.UserAccount);
                if (fav != null)
                {
                    return new DomainResult(false) { ResultMsg = "您已对此帖子进行收藏了" };
                }
                var info = aggregateInfoService.GetInfoByCatatgroyAndId(favorite.ChannelCatagroy, favorite.InfoId);
                if (info == null || aggregateInfoService.IsValid(info) == false)
                {
                    return new DomainResult(false) { ResultMsg = "您不能对此帖子进行收藏(可能已删除或者未发布)" };
                }
                else
                {
                    context.Favorites.Add(favorite);
                    context.SaveChanges();
                    return DomainResult.GetDefault();
                }
            }
        }

        public DomainResult DeleteFavorite(Entity.FxAggregate.Favorite favorite)
        {
            using (var context = new FxAggregateContext())
            {
                favorite = context.Favorites.Where(r => r.FavoriteId == favorite.FavoriteId).FirstOrDefault();
                if (favorite != null)
                {
                    context.Favorites.Remove(favorite);
                    context.SaveChanges();
                    return DomainResult.GetDefault();
                }
                else
                {
                    return new DomainResult(false) { ResultMsg = "收藏失败，此帖子可能已被删除" };
                }
            }
        }

        public Favorite GetFavorite(int ChannelCatagroy, int infoId, string userAccount)
        {
            using (var context = new FxAggregateContext())
            {
                return context.Favorites
                    .Where(r => r.ChannelCatagroy == ChannelCatagroy &&
                              r.InfoId == infoId &&
                              r.UserAccount == userAccount).FirstOrDefault();
            }
        }

        public List<Favorite> GetFavorite(string accountUser)
        {
            using (var context = new FxAggregateContext())
            {
                return context.Favorites
                    .Where(r => r.UserAccount == accountUser).ToList();
            }
        }


        public Favorite GetById(int id)
        {
            using (var context = new FxAggregateContext())
            {
                return context.Favorites
                    .Where(r => r.FavoriteId == id).FirstOrDefault();
            }
        }


        public bool IsFavorite(int ChannelCatagroy, int infoId, string accountUser)
        {
            return GetFavorite(ChannelCatagroy, infoId, accountUser) != null;
        }
    }
}
