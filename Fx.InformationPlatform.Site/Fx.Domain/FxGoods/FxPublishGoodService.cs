using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Domain.FxGoods.IService;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods
{
    public class FxPublishGoodService : IPublishGoods
    {
        public Entity.FxGoods.GoodsTransferInfo Get(string Email)
        {
            using (FxGoodsContext context = new FxGoodsContext())
            {
                   return context.GoodsTransferInfos.Where(r => r.PublishUserEmail == Email).FirstOrDefault();
            }
        }
    }
}
