using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxGoods.IService;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods
{
    public class GoodsViewService : IGoodsShow
    {
        public List<GoodsTransferInfo> GetLastedGoods(int page, string goodsAction)
        {
            using (var context = new FxGoodsContext())
            {
                var goods = context.GoodsTransferInfos.Where(r => r.IsPublish == true && r.Action == goodsAction)
                    //.Select(r => new { r.CreatedTime, r.AreaId, r.CityId, r.PublishTitle, r.Price, r.GoodsTransferInfoId })
                    .Take(20).Skip(page * 20).OrderBy(r => r.CreatedTime).ToList();
                return goods;
            }
        }
    }
}
