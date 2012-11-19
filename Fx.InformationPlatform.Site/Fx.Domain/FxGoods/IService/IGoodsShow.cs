using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.IService
{
    public interface IGoodsShow
    {
        List<GoodsTransferInfo> GetLastedGoods(int page,string action);

    }
}
