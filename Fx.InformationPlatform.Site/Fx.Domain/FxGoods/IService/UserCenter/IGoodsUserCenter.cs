using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.IService.UserCenter
{
    public interface IGoodsUserCenter
    {
        List<GoodsTransferInfo> GetTransfers(string email);

        List<GoodsBuyInfo> GetBuys(string email);

        List<GoodsTransferInfo> GetAdminTransfers(int page);

        List<GoodsBuyInfo> GetAdminBuys(int page);
    }
}
