using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Domain.FxGoods.IService;

namespace Fx.Domain.FxGoods
{
    public class FxPublishGoodService : IPublishGoods
    {

        public Entity.FxGoods.CarPublishInfo Get(string Email)
        {
            FxGoodsContext context = new FxGoodsContext();
            return context.CarPublishInfos.Where(r => r.PublishUserEmail == Email).FirstOrDefault();
        }
    }
}
