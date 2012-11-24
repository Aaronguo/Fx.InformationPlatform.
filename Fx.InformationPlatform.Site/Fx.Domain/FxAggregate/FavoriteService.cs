using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;

namespace Fx.Domain.FxAggregate
{
    public class FavoriteService : IFavorite
    {
        public bool AddFavorite(Entity.FxAggregate.Favorite favorite)
        {
            using (var context = new FxAggregateContext())
            {
                context.Favorites.Add(favorite);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteFavorite(Entity.FxAggregate.Favorite favorite)
        {
            using (var context = new FxAggregateContext())
            {
                favorite = context.Favorites.Where(r => r.FavoriteId == favorite.FavoriteId).FirstOrDefault();
                if (favorite != null)
                {
                    context.Favorites.Remove(favorite);
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }
    }
}
