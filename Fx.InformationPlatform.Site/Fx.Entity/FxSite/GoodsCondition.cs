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

        /// <summary>
        /// 是否需要一些填写扩展信息
        /// </summary>
        public bool IsHasMessage { get; set; }

        /// <summary>
        /// 扩展信息填写要求
        /// </summary>
        public string PlaceHolder { get; set; }
    }
}
