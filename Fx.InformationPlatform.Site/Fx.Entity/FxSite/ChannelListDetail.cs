using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 频道分类明细
    /// </summary>
    public class ChannelListDetail : IAction
    {
        public int ChannelListDetailId { get; set; }

        /// <summary>
        /// 频道列表名称
        /// </summary>
        public string ChannelListDetailName { get; set; }

        /// <summary>
        /// 频道列表简介
        /// </summary>
        public string Description { get; set; }

        public virtual int Sorted { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string RoutePars { get; set; }
    }
}
