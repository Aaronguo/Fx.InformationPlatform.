using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 频道列表
    /// </summary>
    public class ChannelList:IAction
    {
        public ChannelList()
        {
            this.ChannelListDetails = new List<ChannelListDetail>();
        }

        public int ChannelListId { get; set; }

        /// <summary>
        /// 频道列表名称
        /// </summary>
        public string ChannelListName { get; set; }

        /// <summary>
        /// 频道列表简介
        /// </summary>
        public string Description { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string RoutePars { get; set; }

        public ICollection<ChannelListDetail> ChannelListDetails { get; set; }
    }
}
