using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxGoods
{
    public class GoodsBuyInfo : GoodsBase
    {
        public int GoodsBuyInfoId { get; set; }

        /// <summary>
        /// 新旧程度
        /// </summary>
        public int GoodsconditonId { get; set; }

        /// <summary>
        /// 物品功能问题
        /// </summary>
        public string GoodsConditionMsg { get; set; }

        public virtual List<BuyPicture> Pictures { get; set; }

        public virtual ICollection<GoodsBuyLog> Logs { get; set; }

        public GoodsBuyInfo()
        {
            this.Pictures = new List<BuyPicture>();
        }
    }
}
