using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxGoods.IService;

namespace Fx.Domain.FxGoods
{
    public class GlobalCacheGoods : IGlobalCacheGoods
    {

        public int InfoCount()
        {
            using (var context = new FxGoodsContext())
            {
                return context.GoodsBuyInfos.Count() + context.GoodsTransferInfos.Count();
            }
        }
    }
}
