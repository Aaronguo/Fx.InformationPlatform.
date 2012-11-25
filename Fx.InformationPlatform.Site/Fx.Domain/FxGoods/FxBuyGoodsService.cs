using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Fx.Domain.FxGoods.IService;

namespace Fx.Domain.FxGoods
{
    public class FxBuyGoodsService : IBuyGoods
    {
        public Entity.FxGoods.GoodsBuyInfo Get(int Id)
        {
            using (FxGoodsContext context = new FxGoodsContext())
            {
                return context.GoodsBuyInfos.Include(r=>r.Pictures)
                    .Where(r => r.GoodsBuyInfoId == Id).FirstOrDefault();
            }
        }

        public bool SaveBuyGoods(Entity.FxGoods.GoodsBuyInfo goods)
        {
            using (FxGoodsContext context = new FxGoodsContext())
            {
                context.GoodsBuyInfos.Add(goods);
                context.SaveChanges();
            }
            return goods.GoodsBuyInfoId > 0;
        }
    }
}
