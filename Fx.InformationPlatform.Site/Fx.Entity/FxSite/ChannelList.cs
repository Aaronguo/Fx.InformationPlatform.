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
    public class ChannelList : IAction, IPublishAction
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

        public virtual int Sorted { get; set; }

        public virtual ICollection<ChannelListDetail> ChannelListDetails { get; set; }

        public string TransferController { get; set; }

        public string BuyController { get; set; }
    }
}
