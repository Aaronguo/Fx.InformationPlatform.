
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxGoods
{
    public class GoodsBuyLog
    {
        public int GoodsBuyLogId { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        public string OperteName { get; set; }

        /// <summary>
        /// 操作来源 
        /// </summary>
        public string Source { get; set; }

        public virtual DateTime OperteTime { get; set; }

        public GoodsBuyLog()
        {
            this.OperteTime = DateTime.Now;
        }

    }
}
