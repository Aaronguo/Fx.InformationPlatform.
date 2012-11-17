using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxGoods
{
    public class GoodsTransferLog
    {
        public int GoodsTransferLogId { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        public string OperteName { get; set; }

        /// <summary>
        /// 操作来源 
        /// </summary>
        public string Source { get; set; }

        public DateTime OperteTime { get; set; }

        public GoodsTransferLog()
        {
            this.OperteTime = DateTime.Now;
        }
    }
}
