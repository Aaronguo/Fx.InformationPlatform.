using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxHouse
{
   public class HouseBuyLog
    {
       public int HouseBuyLogId { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        public string OperteName { get; set; }

        /// <summary>
        /// 操作来源 
        /// </summary>
        public string Source { get; set; }

        public DateTime OperteTime { get; set; }

        public HouseBuyLog()
        {
            this.OperteTime = DateTime.Now;
        }
    }
}
