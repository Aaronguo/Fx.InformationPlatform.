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
    public class ChannelList
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

        public ICollection<ChannelListDetail> ChannelListDetails { get; set; }
    }
}
