using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxAggregate
{
    public class PrivateMessage
    {
        public int PrivateMessageId { get; set; }


        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 感兴趣的对象
        /// </summary>
        public string InterestingEmail { get; set; }

        public int ChannelCatagroy { get; set; }

        /// <summary>
        /// 帖子Id
        /// </summary>
        public int SourceId { get; set; }

        public PrivateMessage()
        {
            this.CreatedTime = DateTime.Now;
        }
    }
}
