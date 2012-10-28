using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 二手物品新旧基础信息
    /// </summary>
    public class GoodsCondition
    {
        public int GoodsConditionId { get; set; }

        public string GoodsConditionName { get; set; }

        public string Description { get; set; }

        public virtual int Sorted { get; set; }
    }
}
