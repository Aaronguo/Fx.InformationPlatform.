using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.IService
{
   public interface IBuyGoods
    {
        GoodsBuyInfo Get(int Id);

        bool SaveBuyGoods(GoodsBuyInfo goods);
    }
}
