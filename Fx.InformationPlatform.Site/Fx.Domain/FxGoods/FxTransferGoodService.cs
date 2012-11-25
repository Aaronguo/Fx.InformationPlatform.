using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Fx.Domain.FxGoods.IService;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods
{
    public class FxTransferGoodService : ITransferGoods
    {
        public Entity.FxGoods.GoodsTransferInfo Get(int  Id)
        {
            using (FxGoodsContext context = new FxGoodsContext())
            {
                return context.GoodsTransferInfos.Include(r => r.Pictures)
                    .Where(r => r.GoodsTransferInfoId == Id).FirstOrDefault();
            }
        }


        public bool SaveTransferGoods(GoodsTransferInfo goods)
        {
            using (FxGoodsContext context = new FxGoodsContext())
            {
                context.GoodsTransferInfos.Add(goods);
                context.SaveChanges();
            }
            return goods.GoodsTransferInfoId > 0;
        }
    }
}
